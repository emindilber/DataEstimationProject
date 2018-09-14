namespace finalnotutahmini
{
    partial class frmFinal
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCikis = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExceleKaydet = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnFinalTahmin = new System.Windows.Forms.Button();
            this.linkOdevYukle = new System.Windows.Forms.LinkLabel();
            this.odevDosyaSec = new System.Windows.Forms.Button();
            this.lblExcelOdevDosyasi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.linkDzYukle = new System.Windows.Forms.LinkLabel();
            this.btnDevamExcelSec = new System.Windows.Forms.Button();
            this.lblExcelDzDosyasi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCikis);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnExceleKaydet);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnFinalTahmin);
            this.groupBox1.Controls.Add(this.linkOdevYukle);
            this.groupBox1.Controls.Add(this.odevDosyaSec);
            this.groupBox1.Controls.Add(this.lblExcelOdevDosyasi);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.linkDzYukle);
            this.groupBox1.Controls.Add(this.btnDevamExcelSec);
            this.groupBox1.Controls.Add(this.lblExcelDzDosyasi);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(694, 104);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Devamsızlık Bilgileri";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnCikis
            // 
            this.btnCikis.Location = new System.Drawing.Point(588, 71);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(77, 21);
            this.btnCikis.TabIndex = 16;
            this.btnCikis.Text = "Çıkış";
            this.btnCikis.UseVisualStyleBackColor = true;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click_1);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            1,
            2});
            this.comboBox1.Location = new System.Drawing.Point(616, 20);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(49, 21);
            this.comboBox1.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(507, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 18);
            this.label2.TabIndex = 14;
            this.label2.Text = "Öğrenim Türü:";
            // 
            // btnExceleKaydet
            // 
            this.btnExceleKaydet.Location = new System.Drawing.Point(588, 47);
            this.btnExceleKaydet.Name = "btnExceleKaydet";
            this.btnExceleKaydet.Size = new System.Drawing.Size(77, 21);
            this.btnExceleKaydet.TabIndex = 13;
            this.btnExceleKaydet.Text = "Excele Aktar";
            this.btnExceleKaydet.UseVisualStyleBackColor = true;
            this.btnExceleKaydet.Click += new System.EventHandler(this.btnExceleKaydet_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(492, 73);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 21);
            this.button1.TabIndex = 12;
            this.button1.Text = "Yazdır";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnFinalTahmin
            // 
            this.btnFinalTahmin.Location = new System.Drawing.Point(492, 47);
            this.btnFinalTahmin.Name = "btnFinalTahmin";
            this.btnFinalTahmin.Size = new System.Drawing.Size(77, 21);
            this.btnFinalTahmin.TabIndex = 10;
            this.btnFinalTahmin.Text = "Görüntüle";
            this.btnFinalTahmin.UseVisualStyleBackColor = true;
            this.btnFinalTahmin.Click += new System.EventHandler(this.btnFinalTahmin_Click);
            // 
            // linkOdevYukle
            // 
            this.linkOdevYukle.AutoSize = true;
            this.linkOdevYukle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.linkOdevYukle.Location = new System.Drawing.Point(425, 74);
            this.linkOdevYukle.Name = "linkOdevYukle";
            this.linkOdevYukle.Size = new System.Drawing.Size(44, 18);
            this.linkOdevYukle.TabIndex = 9;
            this.linkOdevYukle.TabStop = true;
            this.linkOdevYukle.Text = "Yükle";
            this.linkOdevYukle.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkOdevYukle_LinkClicked);
            // 
            // odevDosyaSec
            // 
            this.odevDosyaSec.Location = new System.Drawing.Point(375, 74);
            this.odevDosyaSec.Name = "odevDosyaSec";
            this.odevDosyaSec.Size = new System.Drawing.Size(44, 23);
            this.odevDosyaSec.TabIndex = 8;
            this.odevDosyaSec.Text = "Seç";
            this.odevDosyaSec.UseVisualStyleBackColor = true;
            this.odevDosyaSec.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblExcelOdevDosyasi
            // 
            this.lblExcelOdevDosyasi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblExcelOdevDosyasi.Location = new System.Drawing.Point(179, 74);
            this.lblExcelOdevDosyasi.Name = "lblExcelOdevDosyasi";
            this.lblExcelOdevDosyasi.ReadOnly = true;
            this.lblExcelOdevDosyasi.Size = new System.Drawing.Size(190, 20);
            this.lblExcelOdevDosyasi.TabIndex = 7;
            this.lblExcelOdevDosyasi.Click += new System.EventHandler(this.lblExcelOdevDosyasi_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(8, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Ödev Yapan Öğrenciler:";
            // 
            // linkDzYukle
            // 
            this.linkDzYukle.AutoSize = true;
            this.linkDzYukle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.linkDzYukle.Location = new System.Drawing.Point(424, 30);
            this.linkDzYukle.Name = "linkDzYukle";
            this.linkDzYukle.Size = new System.Drawing.Size(44, 18);
            this.linkDzYukle.TabIndex = 3;
            this.linkDzYukle.TabStop = true;
            this.linkDzYukle.Text = "Yükle";
            this.linkDzYukle.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDzYukle_LinkClicked);
            // 
            // btnDevamExcelSec
            // 
            this.btnDevamExcelSec.Location = new System.Drawing.Point(374, 30);
            this.btnDevamExcelSec.Name = "btnDevamExcelSec";
            this.btnDevamExcelSec.Size = new System.Drawing.Size(44, 23);
            this.btnDevamExcelSec.TabIndex = 2;
            this.btnDevamExcelSec.Text = "Seç";
            this.btnDevamExcelSec.UseVisualStyleBackColor = true;
            this.btnDevamExcelSec.Click += new System.EventHandler(this.btnDevamExcelSec_Click);
            // 
            // lblExcelDzDosyasi
            // 
            this.lblExcelDzDosyasi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblExcelDzDosyasi.Location = new System.Drawing.Point(178, 30);
            this.lblExcelDzDosyasi.Name = "lblExcelDzDosyasi";
            this.lblExcelDzDosyasi.ReadOnly = true;
            this.lblExcelDzDosyasi.Size = new System.Drawing.Size(190, 20);
            this.lblExcelDzDosyasi.TabIndex = 1;
            this.lblExcelDzDosyasi.Click += new System.EventHandler(this.lblExcelDzDosyasi_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(7, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Devamsızlık Durumu:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(12, 122);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(694, 329);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Final Notu Tahminleri";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 25);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(682, 298);
            this.dataGridView1.TabIndex = 0;
            // 
            // printDocument1
            // 
            this.printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_BeginPrint);
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // frmFinal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(714, 457);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmFinal";
            this.Text = "Final Not Tahmini";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox lblExcelDzDosyasi;
        private System.Windows.Forms.Button btnDevamExcelSec;
        private System.Windows.Forms.LinkLabel linkDzYukle;
        private System.Windows.Forms.LinkLabel linkOdevYukle;
        private System.Windows.Forms.Button odevDosyaSec;
        private System.Windows.Forms.TextBox lblExcelOdevDosyasi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnFinalTahmin;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnExceleKaydet;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.Button btnCikis;
    }
}