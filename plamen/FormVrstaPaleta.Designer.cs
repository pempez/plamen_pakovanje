namespace plamen
{
    partial class FormVrstaPaleta
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
            this.btnObrisi = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnIzmeni = new System.Windows.Forms.Button();
            this.btnUnesi = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbMasa = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbVisina = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSirina = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbDuzina = new System.Windows.Forms.TextBox();
            this.dgvVrstePaleta = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVrstePaleta)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnObrisi);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.dgvVrstePaleta);
            this.groupBox1.Location = new System.Drawing.Point(3, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(817, 589);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vrsta paleta";
            // 
            // btnObrisi
            // 
            this.btnObrisi.Location = new System.Drawing.Point(11, 336);
            this.btnObrisi.Name = "btnObrisi";
            this.btnObrisi.Size = new System.Drawing.Size(75, 23);
            this.btnObrisi.TabIndex = 2;
            this.btnObrisi.Text = "Obrisi";
            this.btnObrisi.UseVisualStyleBackColor = true;
            this.btnObrisi.Click += new System.EventHandler(this.btnObrisi_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnIzmeni);
            this.groupBox2.Controls.Add(this.btnUnesi);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tbMasa);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.tbVisina);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.tbSirina);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.tbDuzina);
            this.groupBox2.Location = new System.Drawing.Point(11, 368);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(793, 124);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // btnIzmeni
            // 
            this.btnIzmeni.Location = new System.Drawing.Point(20, 95);
            this.btnIzmeni.Name = "btnIzmeni";
            this.btnIzmeni.Size = new System.Drawing.Size(75, 23);
            this.btnIzmeni.TabIndex = 9;
            this.btnIzmeni.Text = "Izmeni";
            this.btnIzmeni.UseVisualStyleBackColor = true;
            this.btnIzmeni.Click += new System.EventHandler(this.btnIzmeni_Click);
            // 
            // btnUnesi
            // 
            this.btnUnesi.Location = new System.Drawing.Point(712, 95);
            this.btnUnesi.Name = "btnUnesi";
            this.btnUnesi.Size = new System.Drawing.Size(75, 23);
            this.btnUnesi.TabIndex = 8;
            this.btnUnesi.Text = "Unesi";
            this.btnUnesi.UseVisualStyleBackColor = true;
            this.btnUnesi.Click += new System.EventHandler(this.btnUnesi_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(649, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "masa";
            // 
            // tbMasa
            // 
            this.tbMasa.Location = new System.Drawing.Point(687, 32);
            this.tbMasa.Name = "tbMasa";
            this.tbMasa.Size = new System.Drawing.Size(100, 20);
            this.tbMasa.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(320, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "visina";
            // 
            // tbVisina
            // 
            this.tbVisina.Location = new System.Drawing.Point(360, 32);
            this.tbVisina.Name = "tbVisina";
            this.tbVisina.Size = new System.Drawing.Size(100, 20);
            this.tbVisina.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(174, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "sirina";
            // 
            // tbSirina
            // 
            this.tbSirina.Location = new System.Drawing.Point(211, 32);
            this.tbSirina.Name = "tbSirina";
            this.tbSirina.Size = new System.Drawing.Size(100, 20);
            this.tbSirina.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "duzina";
            // 
            // tbDuzina
            // 
            this.tbDuzina.Location = new System.Drawing.Point(61, 32);
            this.tbDuzina.Name = "tbDuzina";
            this.tbDuzina.Size = new System.Drawing.Size(100, 20);
            this.tbDuzina.TabIndex = 0;
            // 
            // dgvVrstePaleta
            // 
            this.dgvVrstePaleta.AllowUserToAddRows = false;
            this.dgvVrstePaleta.AllowUserToDeleteRows = false;
            this.dgvVrstePaleta.AllowUserToResizeColumns = false;
            this.dgvVrstePaleta.AllowUserToResizeRows = false;
            this.dgvVrstePaleta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvVrstePaleta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvVrstePaleta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVrstePaleta.Location = new System.Drawing.Point(11, 111);
            this.dgvVrstePaleta.MultiSelect = false;
            this.dgvVrstePaleta.Name = "dgvVrstePaleta";
            this.dgvVrstePaleta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVrstePaleta.Size = new System.Drawing.Size(793, 219);
            this.dgvVrstePaleta.TabIndex = 0;
            this.dgvVrstePaleta.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVrsteKutija_CellClick);
            // 
            // FormVrstaPaleta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 590);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormVrstaPaleta";
            this.Text = "FormVrstaPaleta";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVrstePaleta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnObrisi;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnIzmeni;
        private System.Windows.Forms.Button btnUnesi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbMasa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbVisina;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbSirina;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbDuzina;
        private System.Windows.Forms.DataGridView dgvVrstePaleta;
    }
}