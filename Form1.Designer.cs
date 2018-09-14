namespace finalnotutahmini
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.GroupBox groupBox1;
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.lnkYukle = new System.Windows.Forms.LinkLabel();
            this.lblExcelDosyasi = new System.Windows.Forms.Label();
            this.btnExcelSec = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnArtan = new System.Windows.Forms.Button();
            this.btnAzalan = new System.Windows.Forms.Button();
            this.chart1_Ogretim = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cBoxOgrenim = new System.Windows.Forms.ComboBox();
            this.btnGoruntule = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.StandartSapmaTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.enBasariliOgrenciTextBox = new System.Windows.Forms.TextBox();
            this.btnCikis = new System.Windows.Forms.Button();
            this.btnFinalNotTahmin = new System.Windows.Forms.Button();
            this.gecerNotTextBox = new System.Windows.Forms.TextBox();
            this.kalırNotTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.sinifOrtTextBox = new System.Windows.Forms.TextBox();
            this.enDusukNotTestBox = new System.Windows.Forms.TextBox();
            this.enYuksekNotTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            groupBox1 = new System.Windows.Forms.GroupBox();
            groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1_Ogretim)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(this.label1);
            groupBox1.Controls.Add(this.lnkYukle);
            groupBox1.Controls.Add(this.lblExcelDosyasi);
            groupBox1.Controls.Add(this.btnExcelSec);
            groupBox1.Location = new System.Drawing.Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(720, 62);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Vize Notları";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ara Sınav Notlarını İçeren Excel Dosyası:";
            // 
            // lnkYukle
            // 
            this.lnkYukle.AutoSize = true;
            this.lnkYukle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lnkYukle.Location = new System.Drawing.Point(644, 23);
            this.lnkYukle.Name = "lnkYukle";
            this.lnkYukle.Size = new System.Drawing.Size(44, 18);
            this.lnkYukle.TabIndex = 3;
            this.lnkYukle.TabStop = true;
            this.lnkYukle.Text = "Yükle";
            this.lnkYukle.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkYukle_LinkClicked);
            // 
            // lblExcelDosyasi
            // 
            this.lblExcelDosyasi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblExcelDosyasi.Location = new System.Drawing.Point(305, 23);
            this.lblExcelDosyasi.Name = "lblExcelDosyasi";
            this.lblExcelDosyasi.Size = new System.Drawing.Size(267, 23);
            this.lblExcelDosyasi.TabIndex = 1;
            this.lblExcelDosyasi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblExcelDosyasi.Click += new System.EventHandler(this.lblExcelDosyasi_Click);
            // 
            // btnExcelSec
            // 
            this.btnExcelSec.Location = new System.Drawing.Point(578, 23);
            this.btnExcelSec.Name = "btnExcelSec";
            this.btnExcelSec.Size = new System.Drawing.Size(44, 23);
            this.btnExcelSec.TabIndex = 2;
            this.btnExcelSec.Text = "Seç";
            this.btnExcelSec.UseVisualStyleBackColor = true;
            this.btnExcelSec.Click += new System.EventHandler(this.btnExcelSec_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnArtan);
            this.groupBox2.Controls.Add(this.btnAzalan);
            this.groupBox2.Controls.Add(this.chart1_Ogretim);
            this.groupBox2.Location = new System.Drawing.Point(13, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(455, 365);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Puan Grafikleri";
            // 
            // btnArtan
            // 
            this.btnArtan.Location = new System.Drawing.Point(238, 290);
            this.btnArtan.Name = "btnArtan";
            this.btnArtan.Size = new System.Drawing.Size(100, 50);
            this.btnArtan.TabIndex = 2;
            this.btnArtan.Text = "Artan Fonksiyon Grafiği";
            this.btnArtan.UseVisualStyleBackColor = true;
            this.btnArtan.Click += new System.EventHandler(this.btnArtan_Click);
            // 
            // btnAzalan
            // 
            this.btnAzalan.Location = new System.Drawing.Point(122, 290);
            this.btnAzalan.Name = "btnAzalan";
            this.btnAzalan.Size = new System.Drawing.Size(100, 50);
            this.btnAzalan.TabIndex = 1;
            this.btnAzalan.Text = "Azalan Fonksiyon Grafiği";
            this.btnAzalan.UseVisualStyleBackColor = true;
            this.btnAzalan.Click += new System.EventHandler(this.btnAzalan_Click);
            // 
            // chart1_Ogretim
            // 
            this.chart1_Ogretim.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.chart1_Ogretim.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            this.chart1_Ogretim.BorderlineWidth = 10;
            this.chart1_Ogretim.BorderSkin.BackColor = System.Drawing.Color.Black;
            this.chart1_Ogretim.BorderSkin.PageColor = System.Drawing.Color.Transparent;
            this.chart1_Ogretim.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss;
            chartArea1.Area3DStyle.Enable3D = true;
            chartArea1.AxisX.LabelStyle.IsStaggered = true;
            chartArea1.AxisX.LabelStyle.TruncatedLabels = true;
            chartArea1.AxisX.MaximumAutoSize = 90F;
            chartArea1.AxisX.ScrollBar.Enabled = false;
            chartArea1.AxisX.ScrollBar.LineColor = System.Drawing.Color.Black;
            chartArea1.AxisX.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Horizontal;
            chartArea1.CursorX.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.CursorX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chartArea1.InnerPlotPosition.Auto = false;
            chartArea1.InnerPlotPosition.Height = 75F;
            chartArea1.InnerPlotPosition.Width = 85F;
            chartArea1.InnerPlotPosition.X = 12.22808F;
            chartArea1.InnerPlotPosition.Y = 13F;
            chartArea1.Name = "ChartArea1";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 80F;
            chartArea1.Position.Width = 87F;
            chartArea1.Position.X = 3F;
            chartArea1.Position.Y = 5F;
            this.chart1_Ogretim.ChartAreas.Add(chartArea1);
            this.chart1_Ogretim.Cursor = System.Windows.Forms.Cursors.Default;
            this.chart1_Ogretim.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chart1_Ogretim.Location = new System.Drawing.Point(6, 19);
            this.chart1_Ogretim.Name = "chart1_Ogretim";
            this.chart1_Ogretim.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chart1_Ogretim.Size = new System.Drawing.Size(443, 268);
            this.chart1_Ogretim.TabIndex = 0;
            this.chart1_Ogretim.Text = "chart1";
            this.chart1_Ogretim.Click += new System.EventHandler(this.chart1_Ogretim_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cBoxOgrenim);
            this.groupBox3.Controls.Add(this.btnGoruntule);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.StandartSapmaTextBox);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.enBasariliOgrenciTextBox);
            this.groupBox3.Controls.Add(this.btnCikis);
            this.groupBox3.Controls.Add(this.btnFinalNotTahmin);
            this.groupBox3.Controls.Add(this.gecerNotTextBox);
            this.groupBox3.Controls.Add(this.kalırNotTextBox);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.sinifOrtTextBox);
            this.groupBox3.Controls.Add(this.enDusukNotTestBox);
            this.groupBox3.Controls.Add(this.enYuksekNotTextBox);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(474, 80);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(258, 365);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Sınav Analizi";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // cBoxOgrenim
            // 
            this.cBoxOgrenim.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBoxOgrenim.FormattingEnabled = true;
            this.cBoxOgrenim.Items.AddRange(new object[] {
            1,
            2});
            this.cBoxOgrenim.Location = new System.Drawing.Point(110, 30);
            this.cBoxOgrenim.Name = "cBoxOgrenim";
            this.cBoxOgrenim.Size = new System.Drawing.Size(121, 21);
            this.cBoxOgrenim.TabIndex = 20;
            // 
            // btnGoruntule
            // 
            this.btnGoruntule.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnGoruntule.Location = new System.Drawing.Point(75, 66);
            this.btnGoruntule.Name = "btnGoruntule";
            this.btnGoruntule.Size = new System.Drawing.Size(103, 32);
            this.btnGoruntule.TabIndex = 16;
            this.btnGoruntule.Text = "Görüntüle";
            this.btnGoruntule.UseVisualStyleBackColor = true;
            this.btnGoruntule.Click += new System.EventHandler(this.btnGoruntule_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(14, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 15);
            this.label9.TabIndex = 19;
            this.label9.Text = "Öğrenim Türü:";
            // 
            // StandartSapmaTextBox
            // 
            this.StandartSapmaTextBox.Location = new System.Drawing.Point(140, 210);
            this.StandartSapmaTextBox.Name = "StandartSapmaTextBox";
            this.StandartSapmaTextBox.ReadOnly = true;
            this.StandartSapmaTextBox.Size = new System.Drawing.Size(100, 20);
            this.StandartSapmaTextBox.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(16, 210);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 15);
            this.label5.TabIndex = 17;
            this.label5.Text = "Standart Sapma:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(16, 110);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 15);
            this.label8.TabIndex = 12;
            this.label8.Text = "En Başarılı Öğrenci:";
            // 
            // enBasariliOgrenciTextBox
            // 
            this.enBasariliOgrenciTextBox.Location = new System.Drawing.Point(140, 110);
            this.enBasariliOgrenciTextBox.Name = "enBasariliOgrenciTextBox";
            this.enBasariliOgrenciTextBox.ReadOnly = true;
            this.enBasariliOgrenciTextBox.Size = new System.Drawing.Size(100, 20);
            this.enBasariliOgrenciTextBox.TabIndex = 13;
            // 
            // btnCikis
            // 
            this.btnCikis.Location = new System.Drawing.Point(132, 308);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(103, 32);
            this.btnCikis.TabIndex = 15;
            this.btnCikis.Text = "Çıkış";
            this.btnCikis.UseVisualStyleBackColor = true;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // btnFinalNotTahmin
            // 
            this.btnFinalNotTahmin.Location = new System.Drawing.Point(23, 308);
            this.btnFinalNotTahmin.Name = "btnFinalNotTahmin";
            this.btnFinalNotTahmin.Size = new System.Drawing.Size(103, 32);
            this.btnFinalNotTahmin.TabIndex = 14;
            this.btnFinalNotTahmin.Text = "Final Not Tahmini";
            this.btnFinalNotTahmin.UseVisualStyleBackColor = true;
            this.btnFinalNotTahmin.Click += new System.EventHandler(this.btnFinalNotTahmin_Click);
            // 
            // gecerNotTextBox
            // 
            this.gecerNotTextBox.Location = new System.Drawing.Point(140, 260);
            this.gecerNotTextBox.Name = "gecerNotTextBox";
            this.gecerNotTextBox.ReadOnly = true;
            this.gecerNotTextBox.Size = new System.Drawing.Size(100, 20);
            this.gecerNotTextBox.TabIndex = 11;
            // 
            // kalırNotTextBox
            // 
            this.kalırNotTextBox.Location = new System.Drawing.Point(140, 235);
            this.kalırNotTextBox.Name = "kalırNotTextBox";
            this.kalırNotTextBox.ReadOnly = true;
            this.kalırNotTextBox.Size = new System.Drawing.Size(100, 20);
            this.kalırNotTextBox.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(16, 260);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 15);
            this.label7.TabIndex = 9;
            this.label7.Text = "Geçer Not Sayısı:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(16, 235);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "Kalır Not Sayısı:";
            // 
            // sinifOrtTextBox
            // 
            this.sinifOrtTextBox.Location = new System.Drawing.Point(140, 185);
            this.sinifOrtTextBox.Name = "sinifOrtTextBox";
            this.sinifOrtTextBox.ReadOnly = true;
            this.sinifOrtTextBox.Size = new System.Drawing.Size(100, 20);
            this.sinifOrtTextBox.TabIndex = 5;
            this.sinifOrtTextBox.TextChanged += new System.EventHandler(this.sinifOrtTextBox_TextChanged);
            // 
            // enDusukNotTestBox
            // 
            this.enDusukNotTestBox.Location = new System.Drawing.Point(140, 160);
            this.enDusukNotTestBox.Name = "enDusukNotTestBox";
            this.enDusukNotTestBox.ReadOnly = true;
            this.enDusukNotTestBox.Size = new System.Drawing.Size(100, 20);
            this.enDusukNotTestBox.TabIndex = 4;
            // 
            // enYuksekNotTextBox
            // 
            this.enYuksekNotTextBox.Location = new System.Drawing.Point(140, 135);
            this.enYuksekNotTextBox.Name = "enYuksekNotTextBox";
            this.enYuksekNotTextBox.ReadOnly = true;
            this.enYuksekNotTextBox.Size = new System.Drawing.Size(100, 20);
            this.enYuksekNotTextBox.TabIndex = 3;
            this.enYuksekNotTextBox.TextChanged += new System.EventHandler(this.enYuksekNotTextBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(16, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Sınıf Ortalaması:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(16, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "En Düşük Puan:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(16, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "En Yüksek Puan:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(6, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(233, 408);
            this.dataGridView1.TabIndex = 7;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dataGridView1);
            this.groupBox4.Location = new System.Drawing.Point(738, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(245, 433);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Puan Listesi";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(985, 457);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Form1";
            this.Text = "Ara Sınav Bilgileri";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1_Ogretim)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblExcelDosyasi;
        private System.Windows.Forms.Button btnExcelSec;
        private System.Windows.Forms.LinkLabel lnkYukle;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox enDusukNotTestBox;
        private System.Windows.Forms.TextBox enYuksekNotTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox sinifOrtTextBox;
        private System.Windows.Forms.TextBox gecerNotTextBox;
        private System.Windows.Forms.TextBox kalırNotTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCikis;
        private System.Windows.Forms.Button btnFinalNotTahmin;
        private System.Windows.Forms.TextBox enBasariliOgrenciTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1_Ogretim;
        private System.Windows.Forms.Button btnGoruntule;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnArtan;
        private System.Windows.Forms.Button btnAzalan;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox StandartSapmaTextBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cBoxOgrenim;
        private System.Windows.Forms.Label label9;
    }
}

