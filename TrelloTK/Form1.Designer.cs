using System;

namespace TrelloTK
{
    partial class formHome
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnKartEkleTamamlandı = new System.Windows.Forms.Button();
            this.btnKartEkleYapılıyor = new System.Windows.Forms.Button();
            this.btnKartEkle = new System.Windows.Forms.Button();
            this.txtYapılacaklar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.btnTahmin = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.btnYenile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Coral;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox1.Location = new System.Drawing.Point(372, 47);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(195, 24);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "Yapılıyor";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.YellowGreen;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox2.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox2.Location = new System.Drawing.Point(669, 47);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(195, 24);
            this.textBox2.TabIndex = 9;
            this.textBox2.Text = "Tamamlandı";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnKartEkleTamamlandı
            // 
            this.btnKartEkleTamamlandı.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKartEkleTamamlandı.Location = new System.Drawing.Point(669, 76);
            this.btnKartEkleTamamlandı.Name = "btnKartEkleTamamlandı";
            this.btnKartEkleTamamlandı.Size = new System.Drawing.Size(195, 23);
            this.btnKartEkleTamamlandı.TabIndex = 14;
            this.btnKartEkleTamamlandı.Text = "+ Kart Ekle";
            this.btnKartEkleTamamlandı.UseVisualStyleBackColor = true;
            this.btnKartEkleTamamlandı.Click += new System.EventHandler(this.btnKartEkleTamamlandı_Click);
            // 
            // btnKartEkleYapılıyor
            // 
            this.btnKartEkleYapılıyor.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKartEkleYapılıyor.Location = new System.Drawing.Point(372, 76);
            this.btnKartEkleYapılıyor.Name = "btnKartEkleYapılıyor";
            this.btnKartEkleYapılıyor.Size = new System.Drawing.Size(195, 23);
            this.btnKartEkleYapılıyor.TabIndex = 15;
            this.btnKartEkleYapılıyor.Text = "+ Kart Ekle";
            this.btnKartEkleYapılıyor.UseVisualStyleBackColor = true;
            this.btnKartEkleYapılıyor.Click += new System.EventHandler(this.btnKartEkleYapılıyor_Click);
            // 
            // btnKartEkle
            // 
            this.btnKartEkle.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKartEkle.Location = new System.Drawing.Point(53, 76);
            this.btnKartEkle.Name = "btnKartEkle";
            this.btnKartEkle.Size = new System.Drawing.Size(195, 23);
            this.btnKartEkle.TabIndex = 12;
            this.btnKartEkle.Text = "+ Kart Ekle";
            this.btnKartEkle.UseVisualStyleBackColor = true;
            this.btnKartEkle.Click += new System.EventHandler(this.btnKartEkle_Click);
            // 
            // txtYapılacaklar
            // 
            this.txtYapılacaklar.BackColor = System.Drawing.Color.CadetBlue;
            this.txtYapılacaklar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtYapılacaklar.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtYapılacaklar.ForeColor = System.Drawing.SystemColors.Window;
            this.txtYapılacaklar.Location = new System.Drawing.Point(53, 47);
            this.txtYapılacaklar.Name = "txtYapılacaklar";
            this.txtYapılacaklar.Size = new System.Drawing.Size(195, 24);
            this.txtYapılacaklar.TabIndex = 4;
            this.txtYapılacaklar.Text = "Yapılacaklar";
            this.txtYapılacaklar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(305, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 650);
            this.label1.TabIndex = 18;
            this.label1.Text = "||\r\n||\r\n||\r\n||\r\n||\r\n||\r\n||\r\n||\r\n||\r\n||\r\n||\r\n||\r\n||\r\n||\r\n||\r\n||\r\n||\r\n||\r\n||\r\n||\r\n|" +
    "|\r\n||\r\n||\r\n||\r\n||\r\n||\r\n||\r\n||\r\n||\r\n||\r\n||\r\n||\r\n||\r\n||\r\n||\r\n||\r\n||\r\n||\r\n||\r\n||\r\n|" +
    "|\r\n||\r\n||\r\n||\r\n||\r\n||\r\n||||\r\n||\r\n\r\n\r\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(610, -1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 624);
            this.label2.TabIndex = 19;
            this.label2.Text = "||\r\n||\r\n||\r\n||\r\n||\r\n||\r\n||\r\n||\r\n||\r\n||\r\n||\r\n||\r\n||\r\n||\r\n||\r\n||\r\n||\r\n||\r\n||\r\n||\r\n|" +
    "|\r\n||\r\n||\r\n||\r\n||\r\n||\r\n||\r\n||\r\n||\r\n||\r\n||\r\n||\r\n||\r\n||\r\n||\r\n||\r\n||\r\n||\r\n||\r\n||\r\n|" +
    "|\r\n||\r\n||\r\n||\r\n||\r\n||\r\n||\r\n||";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.CadetBlue;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox3.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox3.Location = new System.Drawing.Point(-3, -1);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(313, 16);
            this.textBox3.TabIndex = 20;
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.Coral;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox4.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox4.Location = new System.Drawing.Point(310, 0);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(306, 16);
            this.textBox4.TabIndex = 21;
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.YellowGreen;
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox5.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox5.Location = new System.Drawing.Point(616, 0);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(306, 16);
            this.textBox5.TabIndex = 22;
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnTahmin
            // 
            this.btnTahmin.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnTahmin.Font = new System.Drawing.Font("Calibri Light", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTahmin.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTahmin.Location = new System.Drawing.Point(839, 498);
            this.btnTahmin.Name = "btnTahmin";
            this.btnTahmin.Size = new System.Drawing.Size(83, 50);
            this.btnTahmin.TabIndex = 23;
            this.btnTahmin.Text = "Proje Bitiş Tahmin";
            this.btnTahmin.UseVisualStyleBackColor = false;
            this.btnTahmin.Click += new System.EventHandler(this.btnTahmin_Click);
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.Color.YellowGreen;
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox6.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox6.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox6.Location = new System.Drawing.Point(615, 550);
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(306, 16);
            this.textBox6.TabIndex = 26;
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.Color.Coral;
            this.textBox7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox7.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox7.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox7.Location = new System.Drawing.Point(309, 550);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(306, 16);
            this.textBox7.TabIndex = 25;
            this.textBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox8
            // 
            this.textBox8.BackColor = System.Drawing.Color.CadetBlue;
            this.textBox8.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox8.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox8.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox8.Location = new System.Drawing.Point(-5, 549);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(313, 16);
            this.textBox8.TabIndex = 24;
            this.textBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnYenile
            // 
            this.btnYenile.BackColor = System.Drawing.Color.YellowGreen;
            this.btnYenile.Font = new System.Drawing.Font("Calibri Light", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnYenile.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnYenile.Location = new System.Drawing.Point(839, 475);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(82, 26);
            this.btnYenile.TabIndex = 29;
            this.btnYenile.Text = "Yenile";
            this.btnYenile.UseVisualStyleBackColor = false;
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // formHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 564);
            this.Controls.Add(this.btnYenile);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.btnTahmin);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnKartEkle);
            this.Controls.Add(this.txtYapılacaklar);
            this.Controls.Add(this.btnKartEkleYapılıyor);
            this.Controls.Add(this.btnKartEkleTamamlandı);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "formHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TrelloTK";
            this.Load += new System.EventHandler(this.formHome_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnKartEkleTamamlandı;
        private System.Windows.Forms.Button btnKartEkleYapılıyor;
        private System.Windows.Forms.Button btnKartEkle;
        private System.Windows.Forms.TextBox txtYapılacaklar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button btnTahmin;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        public System.Windows.Forms.Button btnYenile;
    }
}

