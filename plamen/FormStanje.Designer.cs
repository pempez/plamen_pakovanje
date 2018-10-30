namespace plamen
{
    partial class FormStanje
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
            this.gbNalozi = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvSpisakRN = new System.Windows.Forms.DataGridView();
            this.dgvSpisakNaloga = new System.Windows.Forms.DataGridView();
            this.btnPretrazi = new System.Windows.Forms.Button();
            this.cmproizvodNaziv = new System.Windows.Forms.ComboBox();
            this.cbProizvodSifra = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnNoviRNGP = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.gbNalozi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpisakRN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpisakNaloga)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gbNalozi);
            this.groupBox1.Controls.Add(this.btnPretrazi);
            this.groupBox1.Controls.Add(this.cmproizvodNaziv);
            this.groupBox1.Controls.Add(this.cbProizvodSifra);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnNoviRNGP);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(1, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(939, 522);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Gotovi prozivodi";
            // 
            // gbNalozi
            // 
            this.gbNalozi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbNalozi.Controls.Add(this.label4);
            this.gbNalozi.Controls.Add(this.label2);
            this.gbNalozi.Controls.Add(this.dgvSpisakRN);
            this.gbNalozi.Controls.Add(this.dgvSpisakNaloga);
            this.gbNalozi.Location = new System.Drawing.Point(6, 301);
            this.gbNalozi.Name = "gbNalozi";
            this.gbNalozi.Size = new System.Drawing.Size(933, 215);
            this.gbNalozi.TabIndex = 13;
            this.gbNalozi.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(577, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Spisak RN GP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Spisak Naloga";
            // 
            // dgvSpisakRN
            // 
            this.dgvSpisakRN.AllowUserToAddRows = false;
            this.dgvSpisakRN.AllowUserToDeleteRows = false;
            this.dgvSpisakRN.AllowUserToOrderColumns = true;
            this.dgvSpisakRN.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSpisakRN.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvSpisakRN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSpisakRN.Location = new System.Drawing.Point(580, 41);
            this.dgvSpisakRN.Name = "dgvSpisakRN";
            this.dgvSpisakRN.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSpisakRN.Size = new System.Drawing.Size(343, 150);
            this.dgvSpisakRN.TabIndex = 4;
            this.dgvSpisakRN.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSpisakRN_CellDoubleClick);
            // 
            // dgvSpisakNaloga
            // 
            this.dgvSpisakNaloga.AllowUserToAddRows = false;
            this.dgvSpisakNaloga.AllowUserToDeleteRows = false;
            this.dgvSpisakNaloga.AllowUserToOrderColumns = true;
            this.dgvSpisakNaloga.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvSpisakNaloga.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvSpisakNaloga.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSpisakNaloga.Location = new System.Drawing.Point(8, 41);
            this.dgvSpisakNaloga.Name = "dgvSpisakNaloga";
            this.dgvSpisakNaloga.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSpisakNaloga.Size = new System.Drawing.Size(528, 150);
            this.dgvSpisakNaloga.TabIndex = 3;
            this.dgvSpisakNaloga.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSpisakNaloga_CellDoubleClick);
            // 
            // btnPretrazi
            // 
            this.btnPretrazi.Location = new System.Drawing.Point(559, 272);
            this.btnPretrazi.Name = "btnPretrazi";
            this.btnPretrazi.Size = new System.Drawing.Size(75, 23);
            this.btnPretrazi.TabIndex = 12;
            this.btnPretrazi.Text = "Pretrazi";
            this.btnPretrazi.UseVisualStyleBackColor = true;
            this.btnPretrazi.Click += new System.EventHandler(this.btnPretrazi_Click);
            // 
            // cmproizvodNaziv
            // 
            this.cmproizvodNaziv.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmproizvodNaziv.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmproizvodNaziv.FormattingEnabled = true;
            this.cmproizvodNaziv.Location = new System.Drawing.Point(171, 274);
            this.cmproizvodNaziv.Name = "cmproizvodNaziv";
            this.cmproizvodNaziv.Size = new System.Drawing.Size(371, 21);
            this.cmproizvodNaziv.TabIndex = 11;
            this.cmproizvodNaziv.Leave += new System.EventHandler(this.cmproizvodNaziv_Leave);
            // 
            // cbProizvodSifra
            // 
            this.cbProizvodSifra.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbProizvodSifra.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbProizvodSifra.FormattingEnabled = true;
            this.cbProizvodSifra.Location = new System.Drawing.Point(60, 274);
            this.cbProizvodSifra.Name = "cbProizvodSifra";
            this.cbProizvodSifra.Size = new System.Drawing.Size(105, 21);
            this.cbProizvodSifra.TabIndex = 10;
            this.cbProizvodSifra.SelectedIndexChanged += new System.EventHandler(this.cbProizvodSifra_SelectedIndexChanged);
            this.cbProizvodSifra.Leave += new System.EventHandler(this.cbProizvodSifra_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 277);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Proizvod";
            // 
            // btnNoviRNGP
            // 
            this.btnNoviRNGP.Location = new System.Drawing.Point(6, 227);
            this.btnNoviRNGP.Name = "btnNoviRNGP";
            this.btnNoviRNGP.Size = new System.Drawing.Size(75, 23);
            this.btnNoviRNGP.TabIndex = 3;
            this.btnNoviRNGP.Text = "Novi RN GP";
            this.btnNoviRNGP.UseVisualStyleBackColor = true;
            this.btnNoviRNGP.Click += new System.EventHandler(this.btnNoviRNGP_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(923, 202);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 236);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 1;
            // 
            // FormStanje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 529);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormStanje";
            this.Text = "Stanje Gotovih Proizvoda";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbNalozi.ResumeLayout(false);
            this.gbNalozi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpisakRN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSpisakNaloga)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnNoviRNGP;
        private System.Windows.Forms.Button btnPretrazi;
        private System.Windows.Forms.ComboBox cmproizvodNaziv;
        private System.Windows.Forms.ComboBox cbProizvodSifra;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gbNalozi;
        private System.Windows.Forms.DataGridView dgvSpisakRN;
        private System.Windows.Forms.DataGridView dgvSpisakNaloga;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
    }
}