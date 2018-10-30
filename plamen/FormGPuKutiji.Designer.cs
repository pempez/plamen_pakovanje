namespace plamen
{
    partial class FormGPuKutiji
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbProizvodNaziv = new System.Windows.Forms.ComboBox();
            this.cbProizvodSifra = new System.Windows.Forms.ComboBox();
            this.dgvGPkutija = new System.Windows.Forms.DataGridView();
            this.tbKomada = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnUnesi = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbVrstaKutije = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGPkutija)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbVrstaKutije);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnUnesi);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbKomada);
            this.groupBox1.Controls.Add(this.dgvGPkutija);
            this.groupBox1.Controls.Add(this.cbProizvodNaziv);
            this.groupBox1.Controls.Add(this.cbProizvodSifra);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(1, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(467, 394);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kolicina GP u Kutiji";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Proizvod";
            // 
            // cbProizvodNaziv
            // 
            this.cbProizvodNaziv.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbProizvodNaziv.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbProizvodNaziv.FormattingEnabled = true;
            this.cbProizvodNaziv.Location = new System.Drawing.Point(161, 32);
            this.cbProizvodNaziv.Name = "cbProizvodNaziv";
            this.cbProizvodNaziv.Size = new System.Drawing.Size(296, 21);
            this.cbProizvodNaziv.TabIndex = 16;
            // 
            // cbProizvodSifra
            // 
            this.cbProizvodSifra.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbProizvodSifra.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbProizvodSifra.FormattingEnabled = true;
            this.cbProizvodSifra.Location = new System.Drawing.Point(65, 32);
            this.cbProizvodSifra.Name = "cbProizvodSifra";
            this.cbProizvodSifra.Size = new System.Drawing.Size(90, 21);
            this.cbProizvodSifra.TabIndex = 15;
            this.cbProizvodSifra.SelectedValueChanged += new System.EventHandler(this.cbProizvodSifra_SelectedValueChanged);
            // 
            // dgvGPkutija
            // 
            this.dgvGPkutija.AllowUserToAddRows = false;
            this.dgvGPkutija.AllowUserToDeleteRows = false;
            this.dgvGPkutija.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvGPkutija.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvGPkutija.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGPkutija.Location = new System.Drawing.Point(2, 92);
            this.dgvGPkutija.Name = "dgvGPkutija";
            this.dgvGPkutija.Size = new System.Drawing.Size(455, 217);
            this.dgvGPkutija.TabIndex = 17;
            // 
            // tbKomada
            // 
            this.tbKomada.Location = new System.Drawing.Point(272, 59);
            this.tbKomada.Name = "tbKomada";
            this.tbKomada.Size = new System.Drawing.Size(100, 20);
            this.tbKomada.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(221, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Komada";
            // 
            // btnUnesi
            // 
            this.btnUnesi.Location = new System.Drawing.Point(378, 57);
            this.btnUnesi.Name = "btnUnesi";
            this.btnUnesi.Size = new System.Drawing.Size(75, 23);
            this.btnUnesi.TabIndex = 20;
            this.btnUnesi.Text = "Unesi";
            this.btnUnesi.UseVisualStyleBackColor = true;
            this.btnUnesi.Click += new System.EventHandler(this.btnUnesi_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Vrsta kutije";
            // 
            // cbVrstaKutije
            // 
            this.cbVrstaKutije.FormattingEnabled = true;
            this.cbVrstaKutije.Location = new System.Drawing.Point(65, 59);
            this.cbVrstaKutije.Name = "cbVrstaKutije";
            this.cbVrstaKutije.Size = new System.Drawing.Size(130, 21);
            this.cbVrstaKutije.TabIndex = 22;
            // 
            // FormGPuKutiji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 396);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormGPuKutiji";
            this.Text = "FormGPuKutiji";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGPkutija)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvGPkutija;
        private System.Windows.Forms.ComboBox cbProizvodNaziv;
        private System.Windows.Forms.ComboBox cbProizvodSifra;
        private System.Windows.Forms.Button btnUnesi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbKomada;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbVrstaKutije;
    }
}