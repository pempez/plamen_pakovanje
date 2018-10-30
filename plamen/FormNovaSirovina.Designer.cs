namespace plamen
{
    partial class FormNovaSirovina
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
            this.tbSifra = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbRezervisano = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbStanje = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbJedinica = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbNaziv = new System.Windows.Forms.TextBox();
            this.btnUnesi = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbAkt = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbAkt);
            this.groupBox1.Controls.Add(this.tbSifra);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbRezervisano);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbStanje);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbJedinica);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbNaziv);
            this.groupBox1.Controls.Add(this.btnUnesi);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(267, 193);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // tbSifra
            // 
            this.tbSifra.Location = new System.Drawing.Point(88, 16);
            this.tbSifra.Name = "tbSifra";
            this.tbSifra.Size = new System.Drawing.Size(173, 20);
            this.tbSifra.TabIndex = 45;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 44;
            this.label2.Text = "Sifra";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbRezervisano
            // 
            this.tbRezervisano.Location = new System.Drawing.Point(88, 127);
            this.tbRezervisano.Name = "tbRezervisano";
            this.tbRezervisano.Size = new System.Drawing.Size(173, 20);
            this.tbRezervisano.TabIndex = 43;
            this.tbRezervisano.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 42;
            this.label5.Text = "Rezervisano";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label5.Visible = false;
            // 
            // tbStanje
            // 
            this.tbStanje.Location = new System.Drawing.Point(88, 101);
            this.tbStanje.Name = "tbStanje";
            this.tbStanje.Size = new System.Drawing.Size(173, 20);
            this.tbStanje.TabIndex = 41;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "Stanje";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbJedinica
            // 
            this.tbJedinica.Location = new System.Drawing.Point(88, 75);
            this.tbJedinica.Name = "tbJedinica";
            this.tbJedinica.Size = new System.Drawing.Size(173, 20);
            this.tbJedinica.TabIndex = 39;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = "Jedinica mere";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tbNaziv
            // 
            this.tbNaziv.Location = new System.Drawing.Point(88, 49);
            this.tbNaziv.Name = "tbNaziv";
            this.tbNaziv.Size = new System.Drawing.Size(173, 20);
            this.tbNaziv.TabIndex = 37;
            // 
            // btnUnesi
            // 
            this.btnUnesi.Location = new System.Drawing.Point(186, 165);
            this.btnUnesi.Name = "btnUnesi";
            this.btnUnesi.Size = new System.Drawing.Size(75, 23);
            this.btnUnesi.TabIndex = 35;
            this.btnUnesi.Text = "Unesi";
            this.btnUnesi.UseVisualStyleBackColor = true;
            this.btnUnesi.Click += new System.EventHandler(this.btnUnesi_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Naziv";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cbAkt
            // 
            this.cbAkt.AutoSize = true;
            this.cbAkt.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbAkt.Location = new System.Drawing.Point(38, 165);
            this.cbAkt.Name = "cbAkt";
            this.cbAkt.Size = new System.Drawing.Size(62, 17);
            this.cbAkt.TabIndex = 46;
            this.cbAkt.Text = "Aktivan";
            this.cbAkt.UseVisualStyleBackColor = true;
            // 
            // FormNovaSirovina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 207);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormNovaSirovina";
            this.Text = "FormNovaSirovina";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbRezervisano;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbStanje;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbJedinica;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbNaziv;
        private System.Windows.Forms.Button btnUnesi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSifra;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbAkt;
    }
}