using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.Odbc;

namespace finalnotutahmini
{

    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }


        string excelDosyaAdresi = null;
        string sqlConStr = "server=172.16.22.5;database=STAJ;uid=hobim;password=hobim";
        int kontrol = 0;


        private void btnExcelSec_Click(object sender, EventArgs e)
        {

            try
            {
                SqlConnection conSql = new SqlConnection(sqlConStr);
                conSql.Open();
                SqlCommand commSql = new SqlCommand("Drop Table FinalTahmin", conSql);
                commSql.ExecuteNonQuery();
            }
            catch (Exception)
            {

            }


            MessageBox.Show("Girilecek tablonun sahip olması gereken kolonlar sırasıyla aşağıdadır:\n\nÖğrenci No ---> Sayısal (9 Karakter) \nAd ---> Maksimum 25 Harf\nSoyad ---> Maksimum 25 Harf\nVize Puan ---> Sayısal (0-100)", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel Dosyası|*.XLSX";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                excelDosyaAdresi = ofd.FileName;
                lblExcelDosyasi.Text = excelDosyaAdresi;
            }
        }

        private void btnGoruntule_Click(object sender, EventArgs e)
        {
            try
            {
                if (cBoxOgrenim.Text=="")
                {
                    MessageBox.Show("Öğrenim türü seçmelisiniz","HATA",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }



                var con = new SqlConnection(sqlConStr);
                con.Open();

                int sorgu = Convert.ToInt32(cBoxOgrenim.Text);

                //En Yüksek Vize Puanı*****************
                SqlCommand enYuksek = new SqlCommand("SELECT MAX ([Vize Puan]) as Puan FROM FinalTahmin where [Öğretim]=@sorgu",con);
                enYuksek.Parameters.AddWithValue("@sorgu", sorgu);
                enYuksek.ExecuteNonQuery();
                SqlDataReader dr = enYuksek.ExecuteReader();
                if (dr.Read())
                {
                    enYuksekNotTextBox.Text = dr["Puan"].ToString();
                }
                dr.Close();

                //En Başarılı Öğrenci******************
                SqlCommand basarili = new SqlCommand("Select [Ad Soyad] as isim from FinalTahmin where [Vize Puan]=(Select max([Vize Puan]) from FinalTahmin where [Öğretim]=@sorgu) and [Öğretim]=@sorgu", con);
                basarili.Parameters.AddWithValue("@sorgu", sorgu);
                basarili.ExecuteNonQuery();
                SqlDataReader dr_basarili = basarili.ExecuteReader();
                if (dr_basarili.Read())
                    enBasariliOgrenciTextBox.Text = dr_basarili["isim"].ToString();
                dr_basarili.Close();

                //En Düşük Vize Puanı*****************
                SqlCommand enDusuk = new SqlCommand("Select MIN([Vize Puan]) as Puan from FinalTahmin where [Öğretim]=@sorgu",con);
                enDusuk.Parameters.AddWithValue("@sorgu", sorgu);
                enDusuk.ExecuteNonQuery();
                SqlDataReader dr_dusuk = enDusuk.ExecuteReader();
                if (dr_dusuk.Read())
                    enDusukNotTestBox.Text = dr_dusuk["Puan"].ToString();
                dr_dusuk.Close();

                //Sınıf Ortalaması*********************
                SqlCommand ortalama = new SqlCommand("Select AVG([Vize Puan]) as ortalamalar from FinalTahmin where [Öğretim]=@sorgu",con);
                ortalama.Parameters.AddWithValue("@sorgu", sorgu);
                ortalama.ExecuteNonQuery();
                SqlDataReader dr_ort = ortalama.ExecuteReader();
                if (dr_ort.Read())
                    sinifOrtTextBox.Text = dr_ort["ortalamalar"].ToString();
                dr_ort.Close();

                //Standart Sapma*****************
                SqlCommand stnSapma = new SqlCommand("Select STDEV([Vize Puan]) as sapma from FinalTahmin where [Öğretim]=@sorgu",con);
                stnSapma.Parameters.AddWithValue("@sorgu", sorgu);
                stnSapma.ExecuteNonQuery();
                SqlDataReader dr_sapma = stnSapma.ExecuteReader();
                if (dr_sapma.Read())
                {
                    StandartSapmaTextBox.Text = dr_sapma["sapma"].ToString();
                }
                dr_sapma.Close();

                //Kalır Not Sayısı******************
                SqlCommand kalan = new SqlCommand("Select Count([Vize Puan]) as kalır from FinalTahmin where [Vize Puan]<35 and [Öğretim]=@sorgu ",con);
                kalan.Parameters.AddWithValue("@sorgu", sorgu);
                kalan.ExecuteNonQuery();
                SqlDataReader dr_kalan = kalan.ExecuteReader();
                if (dr_kalan.Read())
                {
                    kalırNotTextBox.Text = dr_kalan["kalır"].ToString();
                }
                dr_kalan.Close();

                //Geçer Not Sayısı******************
                SqlCommand gecer = new SqlCommand("Select Count([Vize Puan]) as gecer from FinalTahmin where [Vize Puan]>=35 and [Öğretim]=@sorgu",con);
                gecer.Parameters.AddWithValue("@sorgu", sorgu);
                gecer.ExecuteNonQuery();
                SqlDataReader dr_gecer = gecer.ExecuteReader();
                if (dr_gecer.Read())
                {
                    gecerNotTextBox.Text = dr_gecer["gecer"].ToString();
                }
                dr_gecer.Close();

                //Sonuçların datagridciewda gösterilmesi************************
                SqlCommand data = new SqlCommand("Select [Öğrenci No],[Vize Puan] from FinalTahmin where [Öğretim]=@sorgu", con);
                data.Parameters.AddWithValue("@sorgu", sorgu);
                data.ExecuteNonQuery();
                SqlDataReader dr_data = data.ExecuteReader();
                DataTable dt_data = new DataTable();
                dt_data.Load(dr_data);
                dataGridView1.DataSource = dt_data;
                dr_data.Close();


                //Grafik oluşturulması*************
                this.chart1_Ogretim.Series.Clear();  
                Series series = this.chart1_Ogretim.Series.Add("Vize Puanları");
                series.ChartType = SeriesChartType.Column;
                SqlCommand chart = new SqlCommand("Select [Öğrenci No],[Vize Puan] from FinalTahmin where [Öğretim]=@sorgu",con);
                chart.Parameters.AddWithValue("@sorgu", sorgu);
                chart.ExecuteNonQuery();
                SqlDataReader dr_chart = chart.ExecuteReader();
                int sayac = 0;
                while (dr_chart.Read())
                {
                    series.Points.AddXY(dr_chart["Öğrenci No"], dr_chart["Vize Puan"]);
                    series.IsValueShownAsLabel = true;
                    sayac++;
                }
                dr_chart.Close();
                con.Close();
                kontrol = 1;
            }

            catch (Exception)
            {
                MessageBox.Show("Veritabanında kayıtlı vize bilgisi bulunamamıştır.\nLütfen bilgileri veritabanına yükleyin.","HATA",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void lnkYukle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OleDbConnection conEx = null;
            SqlConnection conSql = null;
            try
            {
                if (excelDosyaAdresi==null)
                {
                    MessageBox.Show("Lütfen vize bilgilerini içeren dosyayı seçiniz","HATA",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }

                string excelConStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excelDosyaAdresi + " ;Extended Properties=\"Excel 12.0 Xml;HDR=yes\"";
                conEx = new OleDbConnection(excelConStr);
                conEx.Open();
                conSql = new SqlConnection(sqlConStr);
                conSql.Open();

                string sorguEx = "SELECT [Öğrenci No],Ad,Soyad,[Vize Puan] FROM [SAYFA]"; 
                string sayfaAdi = conEx.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null).Rows.Cast<DataRow>().Where(w => !w["TABLE_NAME"].ToString().Contains("FilterDatabase")).First()["TABLE_NAME"].ToString();
                sorguEx = sorguEx.Replace("[SAYFA]", "[" + sayfaAdi + "]");

                OleDbCommand comEx = new OleDbCommand(sorguEx, conEx);
                comEx.CommandType = CommandType.Text;
                OleDbDataReader dr = comEx.ExecuteReader();
                if (dr.Read())
                {
                    try
                    {
                        SqlCommand commSql = new SqlCommand("Create Table FinalTahmin (id int identity(1,1) not null primary key,[Öğrenci No] char(9),[Ad Soyad] varchar(50),Devamsızlık float,Ödev float,[Vize Puan] float,[Final Tahmin] float,[Öğretim] int ) ", conSql);
                        commSql.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Seçilen veriler veritabanında kayıtlı.\nYeni kayıt girmek için verileri içeren excel dosyasını seçin.","HATA",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        return;
                    }          
                }

                int ogretim = 0;

                while (dr.Read())
                {
                    string ogrenci_no = dr[0].ToString().Trim();
                    string ad = dr[1].ToString().Trim();
                    string soyad = dr[2].ToString().Trim();
                    string vize_puan = dr[3].ToString().Trim();
                    if (Convert.ToInt32(vize_puan) > 100)
                    {
                        MessageBox.Show(ogrenci_no + " numaralı öğrencinin vize notu hatalı,lütfen kontrol ediniz.","HATA",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        vize_puan = "0";
                    }

                    if (Convert.ToInt32(vize_puan) <0)
                    {
                        MessageBox.Show(ogrenci_no + " numaralı öğrencinin vize notu hatalı,lütfen kontrol ediniz.","HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        vize_puan = "0";
                    }
                    

                    if (ogrenci_no.IndexOf("255") > 0)
                    {
                        ogretim = 2;
                    }
                    else
                        ogretim=1;


                    if (ogrenci_no!="" && ad!="" && soyad!="" && vize_puan!="")
                    {
                        SqlCommand comSql = new SqlCommand("INSERT INTO FinalTahmin ([Öğrenci No],[Ad Soyad],[Vize Puan],[Öğretim]) VALUES(@ogrenci_no,@ad,@vize_puan,@ogretim)", conSql);

                        comSql.Parameters.AddWithValue("@ogrenci_no", ogrenci_no);
                        comSql.Parameters.AddWithValue("@ad", ad + " " + soyad);
                        comSql.Parameters.AddWithValue("@vize_puan", vize_puan);
                        comSql.Parameters.AddWithValue("@ogretim", ogretim);
                        comSql.ExecuteNonQuery();
                    }
                    else if(ogrenci_no=="" ||ad==""||soyad==""||vize_puan=="")
                    {
                        MessageBox.Show(" Hatalı kayıt!" + "\nÖğrenci No: " + ogrenci_no + "\nAd: " + ad + "\nSoyad: " + soyad + "\nVize Puan: " + vize_puan, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                MessageBox.Show("Veritabanı başarılı bir şekilde güncellendi","",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                kontrol = 1;
            }

            catch (Exception)
            {
                MessageBox.Show("Girilen excel dosyası istenilen kolonlara sahip değil.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                if (conSql != null)
                    conSql.Close();
                if (conEx != null)
                    conEx.Close();
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnFinalNotTahmin_Click(object sender, EventArgs e)
        {
            if (kontrol==1)
            {
                frmFinal frm = new frmFinal();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Final tahmini yaptırmak için vize bilgilerini yüklemeniz gerekli.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblExcelDosyasi_Click(object sender, EventArgs e)
        {

        }

        private void enYuksekNotTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void sinifOrtTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAzalan_Click(object sender, EventArgs e)
        {
            try
            {   
                if (cBoxOgrenim.Text.ToString()=="")
                {
                    MessageBox.Show("Öğrenim türü girmelisiniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int sorgu = Convert.ToInt32(cBoxOgrenim.Text);
                var con = new SqlConnection(sqlConStr);
                con.Open();
                this.chart1_Ogretim.Series.Clear();

                Series series = this.chart1_Ogretim.Series.Add("Vize Puanları Eğrisi");
                series.ChartType = SeriesChartType.Column;
                SqlCommand chart = new SqlCommand("Select [Öğrenci No],[Vize Puan] from FinalTahmin where [Öğretim]=@sorgu order by [Vize Puan] desc", con);
                chart.Parameters.AddWithValue("@sorgu", sorgu);
                chart.ExecuteNonQuery();
                SqlDataReader dr_chart = chart.ExecuteReader();
                int sayac = 0;
                while (dr_chart.Read())
                {
                    series.Points.AddXY(dr_chart["Öğrenci No"], dr_chart["Vize Puan"]);
                    series.IsValueShownAsLabel = true;
                    sayac++;
                }
                con.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Vize bilgisi bulunamamıştır.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnArtan_Click(object sender, EventArgs e)
        {
            try
            {
                int sorgu = Convert.ToInt32(cBoxOgrenim.Text);
                var con = new SqlConnection(sqlConStr);
                con.Open();
                this.chart1_Ogretim.Series.Clear();
                Series series = this.chart1_Ogretim.Series.Add("Vize Puanları Eğrisi");
                series.ChartType = SeriesChartType.Column;
                SqlCommand chart = new SqlCommand("Select [Öğrenci No],[Vize Puan] from FinalTahmin where [Öğretim]=@sorgu order by [Vize Puan] asc",con);
                chart.Parameters.AddWithValue("@sorgu", sorgu);
                chart.ExecuteNonQuery();
                SqlDataReader dr_chart = chart.ExecuteReader();
                int sayac = 0;
                while (dr_chart.Read())
                {
                    series.Points.AddXY(dr_chart["Öğrenci No"], dr_chart["Vize Puan"]);
                    series.IsValueShownAsLabel = true;
                    sayac++;
                }
                con.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Vize bilgisi bulunamamıştır", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnVtSil_Click(object sender, EventArgs e)
        {
            try
            {

                kontrol = 0;
                dataGridView1.Columns.Clear();

                cBoxOgrenim.SelectedItem = null;
                enYuksekNotTextBox.Clear();
                enDusukNotTestBox.Clear();
                sinifOrtTextBox.Clear();
                StandartSapmaTextBox.Clear();
                kalırNotTextBox.Clear();
                gecerNotTextBox.Clear();
                enBasariliOgrenciTextBox.Clear();
                
                this.chart1_Ogretim.Series.Clear();

            }
            catch (Exception)
            {

                MessageBox.Show("İlgili alanlarda temizlenmesi gereken bir veri bulunamadı.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chart1_Ogretim_Click(object sender, EventArgs e)
        {

        }
    }
}
