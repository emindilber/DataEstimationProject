using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using Microsoft.Office.Interop.Excel;
using System.Collections.Generic;
using System.Collections;
using System.Drawing;
using System.Drawing.Printing;

namespace finalnotutahmini
{
    public partial class frmFinal : Form
    {
        public frmFinal()
        {
            InitializeComponent();
        }

        string sqlConStr= "server=172.16.22.5;database=STAJ;uid=hobim;password=hobim";

        string excelDzDosyaAdresi=null;
        string excelOdevDosyaAdresi=null;


        StringFormat strFormat;
        ArrayList arrColumnLefts = new ArrayList();
        ArrayList arrColumnWidths = new ArrayList();

        int iCellHeight = 0;
        int iTotalWidth = 0;
        int iRow = 0;
        bool bFirstPage = false;
        bool bNewPage = false;
        int iHeaderHeight = 0;

        private void btnDevamExcelSec_Click(object sender,EventArgs e)
        {
            MessageBox.Show("Yüklenecek tablonun sahip olması gereken kolonlar:\nÖğrenci No\nDevamsızlık", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel Dosyası|*.XLSX";
            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                excelDzDosyaAdresi = ofd.FileName;
                lblExcelDzDosyasi.Text = excelDzDosyaAdresi;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Yüklenecek tablonun sahip olması gereken kolonlar:\nÖğrenci No\nÖdev Sayısı", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            OpenFileDialog ofdOdev = new OpenFileDialog();
            ofdOdev.Filter = "Excel Dosyası|*.XLSX";
            if (ofdOdev.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                excelOdevDosyaAdresi = ofdOdev.FileName;
                lblExcelOdevDosyasi.Text = excelOdevDosyaAdresi;
            }
        }

        private void linkDzYukle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OleDbConnection conEx = null;
            SqlConnection conSql = null;
            try
            {
                string excelConStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excelDzDosyaAdresi + " ;Extended Properties=\"Excel 12.0 Xml;HDR=YES\"";
                conEx = new OleDbConnection(excelConStr);
                conEx.Open();

                conSql = new SqlConnection(sqlConStr);
                conSql.Open();

                string sorguEx = "SELECT [Öğrenci No],Devamsızlık FROM [SAYFA]";
                string sayfaAdi = conEx.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null).Rows.Cast<DataRow>().Where(w => !w["TABLE_NAME"].ToString().Contains("FilterDatabase")).First()["TABLE_NAME"].ToString();
                sorguEx = sorguEx.Replace("[SAYFA]", "[" + sayfaAdi + "]");

                OleDbCommand comEx = new OleDbCommand(sorguEx, conEx);
                comEx.CommandType = CommandType.Text;

                OleDbDataReader dr = comEx.ExecuteReader();
                while (dr.Read())
                {
                    string ogrenci_no = dr[0].ToString().Trim();
                    string devamsızlık = dr[1].ToString().Trim().Replace("'", "");

                    try
                    {
                        if (Convert.ToInt32(devamsızlık) < 0)
                        {
                            devamsızlık = "0";
                            MessageBox.Show(ogrenci_no + " numaralı kişinin devamsızlık bilgisi negatif değerdir, 0 olarak kabul edilmiştir.\nLütfen kontrol ediniz.", "HATALI KAYIT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        SqlCommand comSql = new SqlCommand("UPDATE FinalTahmin set Devamsızlık=@devamsızlık WHERE [Öğrenci No]=@ogrenci_no", conSql);

                        comSql.Parameters.AddWithValue("@ogrenci_no", ogrenci_no);
                        comSql.Parameters.AddWithValue("@devamsızlık", devamsızlık);
                        comSql.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Gririlen dosyada hatalı kayıt bulundu.", "HATALI KAYIT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                dr.Close();

                MessageBox.Show("Devamsızlık Durumları Veritabanına Eklendi.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception)
            {
                MessageBox.Show("Girilen Excel dosyası hatalı!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conSql != null)
                    conSql.Close();
                if (conEx != null)
                    conEx.Close();
            }
        }

        private void linkOdevYukle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OleDbConnection conEx = null;
            SqlConnection conSql = null;
            try
            {
                string excelConStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excelOdevDosyaAdresi + " ;Extended Properties=\"Excel 12.0 Xml;HDR=YES\"";
                conEx = new OleDbConnection(excelConStr);
                conEx.Open();
                conSql = new SqlConnection(sqlConStr);
                conSql.Open();

                string sorguEx = "Select [Öğrenci No],[Ödev Sayısı] from [SAYFA]";
                string sayfaAdi = conEx.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null).Rows.Cast<DataRow>().Where(w => !w["TABLE_NAME"].ToString().Contains("FilterDatabase")).First()["TABLE_NAME"].ToString();
                sorguEx = sorguEx.Replace("[SAYFA]", "[" + sayfaAdi + "]");

                OleDbCommand comEx = new OleDbCommand(sorguEx, conEx);
                comEx.CommandType = CommandType.Text;
                OleDbDataReader dr = comEx.ExecuteReader();

                while (dr.Read())
                {
                    string ogrenci_no = dr[0].ToString().Trim();
                    string odev = dr[1].ToString().Trim();

                    try
                    {
                        if (Convert.ToInt32(odev) < 0)
                        {
                            odev = "0";
                            MessageBox.Show(ogrenci_no + " numaralı kişiye ait ödev bilgisi negatif değerdir, 0 olarak kabul edilmiştir.\nLütfen kontrol ediniz.", "HATALI KAYIT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        SqlCommand cmd = new SqlCommand("UPDATE FinalTahmin set [Ödev]=@odev WHERE [Öğrenci No]=@ogrenci_no", conSql);
                        cmd.Parameters.AddWithValue("@ogrenci_no", ogrenci_no);
                        cmd.Parameters.AddWithValue("@odev", odev);
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Dosyanın içinde hatalı kayıt bulundu.", "HATALI KAYIT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                }
                MessageBox.Show("Yapılan Ödevler Veritabanına Eklendi.", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception)
            {
                MessageBox.Show("Girilen Excel dosyası hatalı!", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFinalTahmin_Click(object sender, EventArgs e)
        {
            try
            {
                List<Ogrenci> kayitlar = new List<Ogrenci>();
                float finalDegeri = 0;

                float vizeDegeri = 0;
                float vizeOrt = 0;
                float maxVizeDegeri = 0;
                float minVizeDegeri = 0;

                float odevDegeri = 0;
                float odevMaxDegeri = 0;
                float minOdevDegeri = 0;

                float dzDegeri = 0;
                float dzMaxDegeri = 0;
                float minDzDegeri = 0;

                int databoyut = 0;
                int sorgu =Convert.ToInt32(comboBox1.Text);

                var con = new SqlConnection(sqlConStr);
                con.Open();

                //Ödev ortalamaları*************************
                SqlCommand odevMax = new SqlCommand("Select max([Ödev]) as ortalamalar from FinalTahmin where [Öğretim]=@sorgu",con);
                odevMax.Parameters.AddWithValue("@sorgu", sorgu);
                odevMax.ExecuteNonQuery();
                SqlDataReader dr_maxOdev = odevMax.ExecuteReader();
                if (dr_maxOdev.Read())
                {
                    odevMaxDegeri = Convert.ToSingle(dr_maxOdev["ortalamalar"]);
                }
                dr_maxOdev.Close();
                //Devamsızlık ortalamaları****************
                SqlCommand dz_max = new SqlCommand("Select max([Devamsızlık]) as ortalamalar from FinalTahmin where [Öğretim]=@sorgu", con);
                dz_max.Parameters.AddWithValue("@sorgu", sorgu);
                dz_max.ExecuteNonQuery();
                SqlDataReader dr_dzmax = dz_max.ExecuteReader();
                if (dr_dzmax.Read())
                {
                    dzMaxDegeri = Convert.ToSingle(dr_dzmax["ortalamalar"]);
                }
                dr_dzmax.Close();
                //Maksimum Vize**********************
                SqlCommand maxVize = new SqlCommand("Select max([Vize Puan]) as vizeortalama from FinalTahmin where [Öğretim]=@sorgu", con);
                maxVize.Parameters.AddWithValue("@sorgu", sorgu);
                maxVize.ExecuteNonQuery();
                SqlDataReader dr_maxVize = maxVize.ExecuteReader();
                if (dr_maxVize.Read())
                {
                    maxVizeDegeri = Convert.ToSingle(dr_maxVize["vizeortalama"]);
                }
                dr_maxVize.Close();
                //Minimum Vize************************
                SqlCommand minVize = new SqlCommand("Select min([Vize Puan]) as minvize from FinalTahmin where [Öğretim]=@sorgu", con);
                minVize.Parameters.AddWithValue("@sorgu", sorgu);
                minVize.ExecuteNonQuery();
                SqlDataReader dr_minVize = minVize.ExecuteReader();
                if (dr_minVize.Read())
                {
                    minVizeDegeri = Convert.ToSingle(dr_minVize["minvize"]);
                }
                dr_minVize.Close();
                //Minimum devamsızlık sayısı********
                SqlCommand minDz = new SqlCommand("Select min([Devamsızlık]) as mindevamsızlık from FinalTahmin where [Öğretim]=@sorgu", con);
                minDz.Parameters.AddWithValue("@sorgu", sorgu);
                minDz.ExecuteNonQuery();
                SqlDataReader dr_minDz = minDz.ExecuteReader();
                if (dr_minDz.Read())
                {
                    minDzDegeri = Convert.ToSingle(dr_minDz["mindevamsızlık"]);
                }
                dr_minDz.Close();
                //Minimum ödev sayısı*****************
                SqlCommand minOdev = new SqlCommand("Select min([Ödev]) as minodev from FinalTahmin where [Öğretim]=@sorgu", con);
                minOdev.Parameters.AddWithValue("@sorgu", sorgu);
                minOdev.ExecuteNonQuery();
                SqlDataReader dr_minOdev = minOdev.ExecuteReader();
                if (dr_minOdev.Read())
                {
                    minOdevDegeri = Convert.ToSingle(dr_minOdev["minodev"]);
                }
                dr_minOdev.Close();
                //Sınıf Ortalaması*********************
                SqlCommand ortalama = new SqlCommand("Select AVG([Vize Puan]) as ortalamalar from FinalTahmin where [Öğretim]=@sorgu", con);
                ortalama.Parameters.AddWithValue("@sorgu", sorgu);
                ortalama.ExecuteNonQuery();
                SqlDataReader dr_ort = ortalama.ExecuteReader();
                if (dr_ort.Read())
                    vizeOrt = Convert.ToSingle(dr_ort["ortalamalar"]);
                dr_ort.Close();
                //Tablodaki kayıt sayısı************
                SqlCommand boyut = new SqlCommand("Select Count([Öğrenci No]) as boyut from FinalTahmin", con);
                boyut.ExecuteNonQuery();
                SqlDataReader dr_boyut = boyut.ExecuteReader();
                if (dr_boyut.Read())
                {
                    databoyut = Convert.ToInt32(dr_boyut["boyut"]);
                    dr_boyut.Close();
                }

                SqlCommand tahmin = new SqlCommand("Select [Vize Puan],[Ödev],[Devamsızlık],[Ad Soyad],[Öğretim],[Öğrenci No] from FinalTahmin where [Öğretim]=@sorgu", con);
                tahmin.Parameters.AddWithValue("@sorgu", sorgu);
                tahmin.ExecuteNonQuery();
                SqlDataReader dr_tahmin = tahmin.ExecuteReader();
                while (dr_tahmin.Read())
                {
                    vizeDegeri = Convert.ToSingle(dr_tahmin["Vize Puan"]);
                    string isim = Convert.ToString(dr_tahmin["Ad Soyad"]);
                    int ogr = Convert.ToInt32(dr_tahmin["Öğretim"]);
                    int ogr_no =Convert.ToInt32(dr_tahmin["Öğrenci No"]);

                    try
                    {
                        dzDegeri = Convert.ToSingle(dr_tahmin["Devamsızlık"]);
                        
                    }
                    catch (Exception)
                    {
                        dzDegeri = 12;
                        MessageBox.Show(isim + " kişisine ait devamsızlık değeri bulunamadığı için 12 kabul edildi.\nLütfen kontrol ediniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    try
                    {
                        odevDegeri = Convert.ToSingle(dr_tahmin["Ödev"]);
                    }
                    catch (Exception)
                    {
                        odevDegeri = 0;
                        MessageBox.Show(isim + " kişisine ait ödev değeri bulunamadığı için 0 kabul edildi.\nLütfen kontrol ediniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    if (vizeDegeri==0)
                    {
                        finalDegeri = vizeOrt / 2 * (((odevDegeri - minOdevDegeri) / (odevMaxDegeri - minOdevDegeri)) - ((dzDegeri - minDzDegeri) / (dzMaxDegeri - minDzDegeri)) / 2);
                    }

                    else if (vizeDegeri < 10)
                    {
                        finalDegeri = vizeDegeri +
                        (10 * vizeDegeri * (((((vizeDegeri - minVizeDegeri) / (maxVizeDegeri - minVizeDegeri)) +
                        ((odevDegeri - minOdevDegeri) / (odevMaxDegeri - minOdevDegeri))) / 2)-
                        (((dzDegeri - minDzDegeri) / (dzMaxDegeri - minDzDegeri)) / 2)));
                    }
                    else if (vizeDegeri < 20)
                    {
                        finalDegeri = vizeDegeri +
                        (3  * vizeDegeri * (((((vizeDegeri - minVizeDegeri) / (maxVizeDegeri - minVizeDegeri)) +
                        ((((odevDegeri - minOdevDegeri) / (odevMaxDegeri - minOdevDegeri))) * 2)) /2) -
                        (((dzDegeri - minDzDegeri) / (dzMaxDegeri - minDzDegeri)) / 2)));
                    }
                    else if (vizeDegeri < 30)
                    {
                        finalDegeri = vizeDegeri +
                        (2 * vizeDegeri * (((((vizeDegeri - minVizeDegeri) / (maxVizeDegeri - minVizeDegeri)) +
                        ((odevDegeri - minOdevDegeri) / (odevMaxDegeri - minOdevDegeri))) / 2) -
                        (((dzDegeri - minDzDegeri) / (dzMaxDegeri - minDzDegeri)) / 2)));
                    }
                    else if (vizeDegeri < 40)
                    {
                        finalDegeri = vizeDegeri +
                        ((3 / 2) * vizeDegeri * (((((vizeDegeri - minVizeDegeri) / (maxVizeDegeri - minVizeDegeri)) +
                        ((odevDegeri - minOdevDegeri) / (odevMaxDegeri - minOdevDegeri))) / 2) -
                        (((dzDegeri - minDzDegeri) / (dzMaxDegeri - minDzDegeri)) / 2)));
                    }
                    else if (vizeDegeri < 50)
                    {
                        finalDegeri = vizeDegeri +
                        (vizeDegeri * (((((vizeDegeri - minVizeDegeri) / (maxVizeDegeri - minVizeDegeri)) +
                        ((odevDegeri - minOdevDegeri) / (odevMaxDegeri - minOdevDegeri))) / 2) -
                        (((dzDegeri - minDzDegeri) / (dzMaxDegeri - minDzDegeri)) / 2)));
                    }
                    else if (vizeDegeri < 60)
                    {
                        finalDegeri = vizeDegeri +
                        (vizeDegeri * (((((vizeDegeri - minVizeDegeri) / (maxVizeDegeri - minVizeDegeri)) +
                        ((odevDegeri - minOdevDegeri) / (odevMaxDegeri - minOdevDegeri))) / 2) -
                        ((dzDegeri - minDzDegeri) / (dzMaxDegeri - minDzDegeri))) / 2);
                    }
                    else if (vizeDegeri < 70)
                    {
                        finalDegeri = vizeDegeri +
                        (vizeDegeri * (((((vizeDegeri - minVizeDegeri) / (maxVizeDegeri - minVizeDegeri)) +
                        ((odevDegeri - minOdevDegeri) / (odevMaxDegeri - minOdevDegeri))) / 2) -
                        (((dzDegeri - minDzDegeri) / (dzMaxDegeri - minDzDegeri)) * 2)) / 3);
                    }
                    else if (vizeDegeri < 80)
                    {
                        finalDegeri = vizeDegeri +
                        (vizeDegeri * (((((vizeDegeri - minVizeDegeri) / (maxVizeDegeri - minVizeDegeri)) +
                        ((odevDegeri - minOdevDegeri) / (odevMaxDegeri - minOdevDegeri))) / 2) -
                        (((dzDegeri - minDzDegeri) / (dzMaxDegeri - minDzDegeri)) * 2)) / 4);
                    }
                    else if (vizeDegeri < 90)
                    {
                        finalDegeri = vizeDegeri +
                        (vizeDegeri * (((((vizeDegeri - minVizeDegeri) / (maxVizeDegeri - minVizeDegeri)) +
                        ((odevDegeri - minOdevDegeri) / (odevMaxDegeri - minOdevDegeri))) / 2) -
                        (((dzDegeri - minDzDegeri) / (dzMaxDegeri - minDzDegeri)) * 2)) / 10);
                    }
                    else if (vizeDegeri <= 100)
                    {
                        finalDegeri = vizeDegeri +
                        (vizeDegeri * (((((vizeDegeri - minVizeDegeri) / (maxVizeDegeri - minVizeDegeri)) +
                        ((odevDegeri - minOdevDegeri) / (odevMaxDegeri - minOdevDegeri))) / 4) -
                        (((dzDegeri - minDzDegeri) / (dzMaxDegeri - minDzDegeri)) * 2 ))/4);
                    }
                    else
                    {
                        MessageBox.Show(isim + " kişisinin vize değeri hatalı olduğundan final notu hesaplanamadı.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        finalDegeri = 0;
                    }
                    
                    if (finalDegeri>100)
                    {
                        finalDegeri = 100;
                    }
                    if (finalDegeri<0)
                    {
                        finalDegeri = 0;
                    }
                    if (dzDegeri>12)
                    {
                        if (ogr==sorgu)
                        {
                            MessageBox.Show(isim + " devamsızlık sınırını aştığı için final notuna 0 girilmiştir.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        finalDegeri = 0; 
                    }
                    finalDegeri = Convert.ToInt32(finalDegeri);
                    Ogrenci kayit = new Ogrenci {No=ogr_no,Final=finalDegeri };
                    kayitlar.Add(kayit);
                }
                dr_tahmin.Close();

                for (int j = 0; j < kayitlar.Count; j++)
                {
                    SqlCommand comSql = new SqlCommand("Update FinalTahmin set [Final Tahmin]=@final where [Öğrenci No]=@ogrNo", con);
                    comSql.Parameters.AddWithValue("@final", kayitlar[j].Final);
                    comSql.Parameters.AddWithValue("@ogrNo", kayitlar[j].No);
                    comSql.ExecuteNonQuery();
                }

                SqlCommand data = new SqlCommand("Select [Öğrenci No],[Ad Soyad],[Ödev],[Devamsızlık],[Vize Puan],[Final Tahmin] from FinalTahmin where [Öğretim]=@sorgu", con);
                data.Parameters.AddWithValue("@sorgu", sorgu);
                data.ExecuteNonQuery();
                SqlDataReader dr_data = data.ExecuteReader();
                System.Data.DataTable dt_data = new System.Data.DataTable();
                dt_data.Load(dr_data);
                dataGridView1.DataSource = dt_data;
                dr_data.Close();
            }
            catch (Exception)
            {
                if (comboBox1.Text == "")
                {
                    MessageBox.Show("Öğrenim türü seçiniz", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Final tahmini yapılabilmesi için gerekli bilgiler eksik.\nLütfen yüklenen dosyaları kontrol edin.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExceleKaydet_Click(object sender, EventArgs e)
        {

            int satır = dataGridView1.Rows.Count;
            if (satır == 0)
            {
                MessageBox.Show("Final Notu Tahminleri alanında excele aktarılacak bir veri bulunamadı.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            Microsoft.Office.Interop.Excel.Application xlOrn = new Microsoft.Office.Interop.Excel.Application();
            xlOrn.Visible = true;
            object Missing = Type.Missing;

            Workbook workbook = xlOrn.Workbooks.Add(Missing);
            Worksheet sheet1 = (Worksheet)workbook.Sheets[1];

            int baslamakolonu = 1;
            int baslamasatiri = 1;

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                Range myRange = (Range)sheet1.Cells[baslamasatiri, baslamakolonu + i];
                myRange.Value2 = dataGridView1.Columns[i].HeaderText;
            }
            baslamasatiri++;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    Range myRange = (Range)sheet1.Cells[baslamasatiri + i, baslamakolonu + j];
                    myRange.Value2 = dataGridView1[j, i].Value;
                    myRange.Select();
                }
            }
        }

        //Printer button//
        string dersadi;
        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
               
                if (dataGridView1.Rows[0].Cells[0].Value.ToString() != string.Empty)
                {
                    dersadi = Microsoft.VisualBasic.Interaction.InputBox("Tahmin yapılan dersin adını giriniz.", "DERS", "", 150, 150);
                    PrintPreviewDialog onizleme = new PrintPreviewDialog();
                    onizleme.Document = printDocument1;
                    ((Form)onizleme).WindowState = FormWindowState.Maximized;
                    onizleme.PrintPreviewControl.Zoom = 1.0;
                    onizleme.ShowDialog();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Final notu tahmini alanında yazdırılacak bir veri bulunamadı.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {

                int iLeftMargin = e.MarginBounds.Left;
                int iTopMargin = e.MarginBounds.Top;
                bool bMorePagesToPrint = false;
                int iTmpWidth = 0;
                bFirstPage = true;

                if (bFirstPage)
                {
                    foreach (DataGridViewColumn GridCol in dataGridView1.Columns)
                    {
                        iTmpWidth = (int)(Math.Floor((double)((double)GridCol.Width / (double)iTotalWidth * (double)iTotalWidth *
                            ((double)e.MarginBounds.Width / (double)iTotalWidth))));

                        iHeaderHeight = (int)(e.Graphics.MeasureString(GridCol.HeaderText, GridCol.InheritedStyle.Font, iTmpWidth).Height) + 11;

                        arrColumnLefts.Add(iLeftMargin);
                        arrColumnWidths.Add(iTmpWidth);
                        iLeftMargin += iTmpWidth;
                    }
                }

                while (iRow<=dataGridView1.Rows.Count-1)
                {
                    DataGridViewRow GridRow = dataGridView1.Rows[iRow];
                    iCellHeight = GridRow.Height + 5;
                    int iCount = 0; 

                    if (iTopMargin+iCellHeight>=e.MarginBounds.Height+e.MarginBounds.Top)
                    {
                        bNewPage = true;
                        bFirstPage = false;
                        bMorePagesToPrint = true;
                        break;
                    }
                    else
                    {
                        if (bNewPage)
                        {
                            e.Graphics.DrawString(dersadi + " Dersi Final Tahmin Verileri", new System.Drawing.Font(dataGridView1.Font, FontStyle.Bold),
                                Brushes.Black, e.MarginBounds.Left, e.MarginBounds.Top - e.Graphics.MeasureString(dersadi + " Dersi Final Tahmin Verileri", 
                                new System.Drawing.Font(dataGridView1.Font, FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            string strDate = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToShortTimeString();

                            e.Graphics.DrawString(strDate, new System.Drawing.Font(dataGridView1.Font, FontStyle.Bold), Brushes.Black,
                                e.MarginBounds.Left + (e.MarginBounds.Width - e.Graphics.MeasureString(strDate, new System.Drawing.Font(dataGridView1.Font,
                                FontStyle.Bold),e.MarginBounds.Width).Width),e.MarginBounds.Top - e.Graphics.MeasureString(dersadi + " Dersi Final Tahmin Verileri", 
                                new System.Drawing.Font(new System.Drawing.Font(dataGridView1.Font, FontStyle.Bold),FontStyle.Bold), e.MarginBounds.Width).Height - 13);

                            iTopMargin = e.MarginBounds.Top;
                            foreach (DataGridViewColumn GridCol in dataGridView1.Columns)
                            {
                                e.Graphics.FillRectangle(new SolidBrush(Color.LightGray), new System.Drawing.Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount],iHeaderHeight));

                                e.Graphics.DrawRectangle(Pens.Black, new System.Drawing.Rectangle((int)arrColumnLefts[iCount], iTopMargin,
                                    (int)arrColumnWidths[iCount], iHeaderHeight));

                                e.Graphics.DrawString(GridCol.HeaderText, GridCol.InheritedStyle.Font, new SolidBrush(GridCol.InheritedStyle.ForeColor),
                                    new RectangleF((int)arrColumnLefts[iCount], iTopMargin, (int)arrColumnWidths[iCount], iHeaderHeight), strFormat);

                                iCount++;
                            }
                            bNewPage = false;
                            iTopMargin += iHeaderHeight;
                        }
                        iCount = 0;
                        foreach (DataGridViewCell Cel in GridRow.Cells)
                        {
                            if (Cel.Value!=null)
                            {
                                e.Graphics.DrawString(Cel.Value.ToString(), Cel.InheritedStyle.Font, new SolidBrush(Cel.InheritedStyle.ForeColor),
                                    new RectangleF((int)arrColumnLefts[iCount], (float)iTopMargin, (int)arrColumnWidths[iCount], (float)iCellHeight), strFormat);
                            }

                            e.Graphics.DrawRectangle(Pens.Black, new System.Drawing.Rectangle((int)arrColumnLefts[iCount], iTopMargin, (int)arrColumnWidths[iCount], iCellHeight));
                            iCount++;
                        }
                    }
                    iRow++;
                    iTopMargin += iCellHeight;

                }

                if (bMorePagesToPrint)
                    e.HasMorePages = true;
                else
                    e.HasMorePages = false;
            }
            catch (Exception exc)
            {

                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
           
        private void printDocument1_BeginPrint(object sender, PrintEventArgs e)
        {
            try
            {
                strFormat = new StringFormat();
                strFormat.Alignment = StringAlignment.Near;

                strFormat.LineAlignment = StringAlignment.Center;
                strFormat.Trimming = StringTrimming.EllipsisCharacter;

                arrColumnLefts.Clear();
                arrColumnWidths.Clear();

                iCellHeight = 0;
                iRow = 0;
                bFirstPage = true;
                bNewPage = true;

                iTotalWidth = 0;

                foreach (DataGridViewColumn dgvGridCol in dataGridView1.Columns)
                {
                    iTotalWidth += dgvGridCol.Width;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCikis_Click_1(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblExcelDzDosyasi_Click(object sender, EventArgs e)
        {

        }

        private void lblExcelOdevDosyasi_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }

    public class Ogrenci
    {
        public int No { get; set; }
        public float Final { get; set; }
    }
}



