namespace plamen
{
    partial class FormKutijaNaPaleti
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
            this.label5 = new System.Windows.Forms.Label();
            this.cbVrstaKutije = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnUnesi = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbKomada = new System.Windows.Forms.TextBox();
            this.dgvGPkutija = new System.Windows.Forms.DataGridView();
            this.cbPaleta = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGPkutija)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbPaleta);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbVrstaKutije);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnUnesi);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbKomada);
            this.groupBox1.Controls.Add(this.dgvGPkutija);
            this.groupBox1.Location = new System.Drawing.Point(2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(470, 365);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kolicina Kutija na paleti";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Kutija";
            // 
            // cbVrstaKutije
            // 
            this.cbVrstaKutije.FormattingEnabled = true;
            this.cbVrstaKutije.Location = new System.Drawing.Point(43, 28);
            this.cbVrstaKutije.Name = "cbVrstaKutije";
            this.cbVrstaKutije.Size = new System.Drawing.Size(156, 21);
            this.cbVrstaKutije.TabIndex = 22;
            this.cbVrstaKutije.SelectedValueChanged += new System.EventHandler(this.cbVrstaKutije_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 21;
            // 
            // btnUnesi
            // 
            this.btnUnesi.Location = new System.Drawing.Point(217, 80);
            this.btnUnesi.Name = "btnUnesi";
            this.btnUnesi.Size = new System.Drawing.Size(75, 23);
            this.btnUnesi.TabIndex = 20;
            this.btnUnesi.Text = "Unesi";
            this.btnUnesi.UseVisualStyleBackColor = true;
            this.btnUnesi.Click += new System.EventHandler(this.btnUnesi_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Broj kutija po redu";
            // 
            // tbKomada
            // 
            this.tbKomada.Location = new System.Drawing.Point(99, 82);
            this.tbKomada.Name = "tbKomada";
            this.tbKomada.Size = new System.Drawing.Size(100, 20);
            this.tbKomada.TabIndex = 18;
            // 
            // dgvGPkutija
            // 
            this.dgvGPkutija.AllowUserToAddRows = false;
            this.dgvGPkutija.AllowUserToDeleteRows = false;
            this.dgvGPkutija.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvGPkutija.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvGPkutija.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGPkutija.Location = new System.Drawing.Point(4, 142);
            this.dgvGPkutija.Name = "dgvGPkutija";
            this.dgvGPkutija.Size = new System.Drawing.Size(455, 217);
            this.dgvGPkutija.TabIndex = 17;
            // 
            // cbPaleta
            // 
            this.cbPaleta.FormattingEnabled = true;
            this.cbPaleta.Location = new System.Drawing.Point(43, 55);
            this.cbPaleta.Name = "cbPaleta";
            this.cbPaleta.Size = new System.Drawing.Size(156, 21);
            this.cbPaleta.TabIndex = 72;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 73;
            this.label1.Text = "Paleta";
            // 
            // FormKutijaNaPaleti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 365);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormKutijaNaPaleti";
            this.Text = "FormKutijaNaPaleti";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGPkutija)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbVrstaKutije;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnUnesi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbKomada;
        private System.Windows.Forms.DataGridView dgvGPkutija;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbPaleta;
    }
}