namespace plamen
{
    partial class FormSastavnicaPPSirovina
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
            this.btnNoviPP = new System.Windows.Forms.Button();
            this.btnNovaStavka = new System.Windows.Forms.Button();
            this.btnObrisi = new System.Windows.Forms.Button();
            this.groupBoxStavka = new System.Windows.Forms.GroupBox();
            this.btnIzmeniStavku = new System.Windows.Forms.Button();
            this.btnUnesiStavku = new System.Windows.Forms.Button();
            this.tbKolicina = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbPPnaziv = new System.Windows.Forms.ComboBox();
            this.cbPPSif = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cbProizvodNaziv = new System.Windows.Forms.ComboBox();
            this.cbProizvodSifra = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnNovaStavkaGP = new System.Windows.Forms.Button();
            this.btnObrisiGP = new System.Windows.Forms.Button();
            this.btnIzmeniStavkuGP = new System.Windows.Forms.Button();
            this.btnUnesiStavkuGP = new System.Windows.Forms.Button();
            this.tbKolicinaGP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvGPSastavnica = new System.Windows.Forms.DataGridView();
            this.cbGPSastavnicaNaziv = new System.Windows.Forms.ComboBox();
            this.cbGPSastavnicaSifra = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnIzmeniStavkuPP = new System.Windows.Forms.Button();
            this.btnUnesiStavkuPP = new System.Windows.Forms.Button();
            this.tbKolicinaPP = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbPPSastavnicaNaziv = new System.Windows.Forms.ComboBox();
            this.btnNovaStavkaPP = new System.Windows.Forms.Button();
            this.cbPPSastavnicaSifra = new System.Windows.Forms.ComboBox();
            this.btnObrisiPP = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvPP = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBoxStavka.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGPSastavnica)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPP)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.btnNoviPP);
            this.groupBox1.Controls.Add(this.groupBoxStavka);
            this.groupBox1.Controls.Add(this.cbProizvodNaziv);
            this.groupBox1.Controls.Add(this.cbProizvodSifra);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(573, 772);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sastavnica poluproizvod";
            // 
            // btnNoviPP
            // 
            this.btnNoviPP.Location = new System.Drawing.Point(490, 17);
            this.btnNoviPP.Name = "btnNoviPP";
            this.btnNoviPP.Size = new System.Drawing.Size(75, 23);
            this.btnNoviPP.TabIndex = 16;
            this.btnNoviPP.Text = "Novi PP";
            this.btnNoviPP.UseVisualStyleBackColor = true;
            this.btnNoviPP.Click += new System.EventHandler(this.btnNoviPP_Click);
            // 
            // btnNovaStavka
            // 
            this.btnNovaStavka.Location = new System.Drawing.Point(449, 131);
            this.btnNovaStavka.Name = "btnNovaStavka";
            this.btnNovaStavka.Size = new System.Drawing.Size(97, 23);
            this.btnNovaStavka.TabIndex = 15;
            this.btnNovaStavka.Text = "Nova stavka";
            this.btnNovaStavka.UseVisualStyleBackColor = true;
            this.btnNovaStavka.Click += new System.EventHandler(this.btnNovaStavka_Click);
            // 
            // btnObrisi
            // 
            this.btnObrisi.Location = new System.Drawing.Point(4, 131);
            this.btnObrisi.Name = "btnObrisi";
            this.btnObrisi.Size = new System.Drawing.Size(75, 23);
            this.btnObrisi.TabIndex = 14;
            this.btnObrisi.Text = "Obriši";
            this.btnObrisi.UseVisualStyleBackColor = true;
            this.btnObrisi.Click += new System.EventHandler(this.btnObrisi_Click);
            // 
            // groupBoxStavka
            // 
            this.groupBoxStavka.BackColor = System.Drawing.SystemColors.Control;
            this.groupBoxStavka.Controls.Add(this.btnIzmeniStavku);
            this.groupBoxStavka.Controls.Add(this.btnNovaStavka);
            this.groupBoxStavka.Controls.Add(this.btnUnesiStavku);
            this.groupBoxStavka.Controls.Add(this.btnObrisi);
            this.groupBoxStavka.Controls.Add(this.tbKolicina);
            this.groupBoxStavka.Controls.Add(this.dataGridView1);
            this.groupBoxStavka.Controls.Add(this.label4);
            this.groupBoxStavka.Controls.Add(this.cbPPnaziv);
            this.groupBoxStavka.Controls.Add(this.cbPPSif);
            this.groupBoxStavka.Controls.Add(this.label1);
            this.groupBoxStavka.Location = new System.Drawing.Point(6, 46);
            this.groupBoxStavka.Name = "groupBoxStavka";
            this.groupBoxStavka.Size = new System.Drawing.Size(559, 247);
            this.groupBoxStavka.TabIndex = 13;
            this.groupBoxStavka.TabStop = false;
            this.groupBoxStavka.Text = "Sirovina";
            // 
            // btnIzmeniStavku
            // 
            this.btnIzmeniStavku.Enabled = false;
            this.btnIzmeniStavku.Location = new System.Drawing.Point(370, 211);
            this.btnIzmeniStavku.Name = "btnIzmeniStavku";
            this.btnIzmeniStavku.Size = new System.Drawing.Size(75, 23);
            this.btnIzmeniStavku.TabIndex = 24;
            this.btnIzmeniStavku.Text = "Izmeni";
            this.btnIzmeniStavku.UseVisualStyleBackColor = true;
            this.btnIzmeniStavku.Click += new System.EventHandler(this.btnIzmeniStavku_Click);
            // 
            // btnUnesiStavku
            // 
            this.btnUnesiStavku.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUnesiStavku.Location = new System.Drawing.Point(465, 209);
            this.btnUnesiStavku.Name = "btnUnesiStavku";
            this.btnUnesiStavku.Size = new System.Drawing.Size(75, 23);
            this.btnUnesiStavku.TabIndex = 23;
            this.btnUnesiStavku.Text = "Unesi";
            this.btnUnesiStavku.UseVisualStyleBackColor = true;
            this.btnUnesiStavku.Click += new System.EventHandler(this.btnUnesiStavku_Click);
            // 
            // tbKolicina
            // 
            this.tbKolicina.Location = new System.Drawing.Point(60, 211);
            this.tbKolicina.Name = "tbKolicina";
            this.tbKolicina.Size = new System.Drawing.Size(84, 20);
            this.tbKolicina.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Količina";
            // 
            // cbPPnaziv
            // 
            this.cbPPnaziv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPPnaziv.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbPPnaziv.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbPPnaziv.FormattingEnabled = true;
            this.cbPPnaziv.Location = new System.Drawing.Point(153, 173);
            this.cbPPnaziv.Name = "cbPPnaziv";
            this.cbPPnaziv.Size = new System.Drawing.Size(387, 21);
            this.cbPPnaziv.TabIndex = 8;
            this.cbPPnaziv.Leave += new System.EventHandler(this.cbPPnaziv_Leave);
            // 
            // cbPPSif
            // 
            this.cbPPSif.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbPPSif.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbPPSif.FormattingEnabled = true;
            this.cbPPSif.Location = new System.Drawing.Point(60, 173);
            this.cbPPSif.Name = "cbPPSif";
            this.cbPPSif.Size = new System.Drawing.Size(84, 21);
            this.cbPPSif.TabIndex = 7;
            this.cbPPSif.Leave += new System.EventHandler(this.cbPPSif_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 176);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sirovina";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(540, 103);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // cbProizvodNaziv
            // 
            this.cbProizvodNaziv.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbProizvodNaziv.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbProizvodNaziv.FormattingEnabled = true;
            this.cbProizvodNaziv.Location = new System.Drawing.Point(216, 19);
            this.cbProizvodNaziv.Name = "cbProizvodNaziv";
            this.cbProizvodNaziv.Size = new System.Drawing.Size(259, 21);
            this.cbProizvodNaziv.TabIndex = 11;
            this.cbProizvodNaziv.Leave += new System.EventHandler(this.cbProizvodNaziv_Leave);
            // 
            // cbProizvodSifra
            // 
            this.cbProizvodSifra.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbProizvodSifra.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbProizvodSifra.FormattingEnabled = true;
            this.cbProizvodSifra.Location = new System.Drawing.Point(77, 19);
            this.cbProizvodSifra.Name = "cbProizvodSifra";
            this.cbProizvodSifra.Size = new System.Drawing.Size(121, 21);
            this.cbProizvodSifra.TabIndex = 10;
            this.cbProizvodSifra.SelectedValueChanged += new System.EventHandler(this.cbProizvodSifra_SelectedValueChanged);
            this.cbProizvodSifra.Leave += new System.EventHandler(this.cbProizvodSifra_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Poluproizvod";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnNovaStavkaGP);
            this.groupBox3.Controls.Add(this.btnObrisiGP);
            this.groupBox3.Controls.Add(this.btnIzmeniStavkuGP);
            this.groupBox3.Controls.Add(this.btnUnesiStavkuGP);
            this.groupBox3.Controls.Add(this.tbKolicinaGP);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.dgvGPSastavnica);
            this.groupBox3.Controls.Add(this.cbGPSastavnicaNaziv);
            this.groupBox3.Controls.Add(this.cbGPSastavnicaSifra);
            this.groupBox3.Location = new System.Drawing.Point(5, 299);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(560, 235);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Gotovi proizvodi";
            // 
            // btnNovaStavkaGP
            // 
            this.btnNovaStavkaGP.Location = new System.Drawing.Point(454, 133);
            this.btnNovaStavkaGP.Name = "btnNovaStavkaGP";
            this.btnNovaStavkaGP.Size = new System.Drawing.Size(100, 23);
            this.btnNovaStavkaGP.TabIndex = 29;
            this.btnNovaStavkaGP.Text = "Nova stavka";
            this.btnNovaStavkaGP.UseVisualStyleBackColor = true;
            this.btnNovaStavkaGP.Click += new System.EventHandler(this.btnNovaStavkaGP_Click);
            // 
            // btnObrisiGP
            // 
            this.btnObrisiGP.Location = new System.Drawing.Point(6, 134);
            this.btnObrisiGP.Name = "btnObrisiGP";
            this.btnObrisiGP.Size = new System.Drawing.Size(75, 23);
            this.btnObrisiGP.TabIndex = 28;
            this.btnObrisiGP.Text = "Obriši";
            this.btnObrisiGP.UseVisualStyleBackColor = true;
            this.btnObrisiGP.Click += new System.EventHandler(this.btnObrisiGP_Click);
            // 
            // btnIzmeniStavkuGP
            // 
            this.btnIzmeniStavkuGP.Location = new System.Drawing.Point(389, 203);
            this.btnIzmeniStavkuGP.Name = "btnIzmeniStavkuGP";
            this.btnIzmeniStavkuGP.Size = new System.Drawing.Size(75, 23);
            this.btnIzmeniStavkuGP.TabIndex = 27;
            this.btnIzmeniStavkuGP.Text = "Izmeni";
            this.btnIzmeniStavkuGP.UseVisualStyleBackColor = true;
            this.btnIzmeniStavkuGP.Click += new System.EventHandler(this.btnIzmeniStavkuGP_Click);
            // 
            // btnUnesiStavkuGP
            // 
            this.btnUnesiStavkuGP.Location = new System.Drawing.Point(479, 203);
            this.btnUnesiStavkuGP.Name = "btnUnesiStavkuGP";
            this.btnUnesiStavkuGP.Size = new System.Drawing.Size(75, 23);
            this.btnUnesiStavkuGP.TabIndex = 26;
            this.btnUnesiStavkuGP.Text = "Unesi";
            this.btnUnesiStavkuGP.UseVisualStyleBackColor = true;
            this.btnUnesiStavkuGP.Click += new System.EventHandler(this.btnUnesiStavkuGP_Click);
            // 
            // tbKolicinaGP
            // 
            this.tbKolicinaGP.Location = new System.Drawing.Point(59, 190);
            this.tbKolicinaGP.Name = "tbKolicinaGP";
            this.tbKolicinaGP.Size = new System.Drawing.Size(105, 20);
            this.tbKolicinaGP.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 193);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Količina";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(30, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "GP";
            // 
            // dgvGPSastavnica
            // 
            this.dgvGPSastavnica.AllowUserToAddRows = false;
            this.dgvGPSastavnica.AllowUserToDeleteRows = false;
            this.dgvGPSastavnica.AllowUserToOrderColumns = true;
            this.dgvGPSastavnica.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvGPSastavnica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGPSastavnica.Location = new System.Drawing.Point(6, 28);
            this.dgvGPSastavnica.Name = "dgvGPSastavnica";
            this.dgvGPSastavnica.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGPSastavnica.Size = new System.Drawing.Size(548, 99);
            this.dgvGPSastavnica.TabIndex = 14;
            this.dgvGPSastavnica.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGPSastavnica_CellClick);
            // 
            // cbGPSastavnicaNaziv
            // 
            this.cbGPSastavnicaNaziv.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbGPSastavnicaNaziv.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbGPSastavnicaNaziv.FormattingEnabled = true;
            this.cbGPSastavnicaNaziv.Location = new System.Drawing.Point(174, 163);
            this.cbGPSastavnicaNaziv.Name = "cbGPSastavnicaNaziv";
            this.cbGPSastavnicaNaziv.Size = new System.Drawing.Size(380, 21);
            this.cbGPSastavnicaNaziv.TabIndex = 13;
            // 
            // cbGPSastavnicaSifra
            // 
            this.cbGPSastavnicaSifra.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbGPSastavnicaSifra.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbGPSastavnicaSifra.FormattingEnabled = true;
            this.cbGPSastavnicaSifra.Location = new System.Drawing.Point(59, 163);
            this.cbGPSastavnicaSifra.Name = "cbGPSastavnicaSifra";
            this.cbGPSastavnicaSifra.Size = new System.Drawing.Size(105, 21);
            this.cbGPSastavnicaSifra.TabIndex = 12;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.btnIzmeniStavkuPP);
            this.groupBox2.Controls.Add(this.btnUnesiStavkuPP);
            this.groupBox2.Controls.Add(this.tbKolicinaPP);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cbPPSastavnicaNaziv);
            this.groupBox2.Controls.Add(this.btnNovaStavkaPP);
            this.groupBox2.Controls.Add(this.cbPPSastavnicaSifra);
            this.groupBox2.Controls.Add(this.btnObrisiPP);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.dgvPP);
            this.groupBox2.Location = new System.Drawing.Point(5, 540);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(560, 226);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Poluproizvod";
            // 
            // btnIzmeniStavkuPP
            // 
            this.btnIzmeniStavkuPP.Enabled = false;
            this.btnIzmeniStavkuPP.Location = new System.Drawing.Point(392, 193);
            this.btnIzmeniStavkuPP.Name = "btnIzmeniStavkuPP";
            this.btnIzmeniStavkuPP.Size = new System.Drawing.Size(75, 23);
            this.btnIzmeniStavkuPP.TabIndex = 24;
            this.btnIzmeniStavkuPP.Text = "Izmeni";
            this.btnIzmeniStavkuPP.UseVisualStyleBackColor = true;
            this.btnIzmeniStavkuPP.Click += new System.EventHandler(this.btnIzmeniStavkuPP_Click);
            // 
            // btnUnesiStavkuPP
            // 
            this.btnUnesiStavkuPP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUnesiStavkuPP.Location = new System.Drawing.Point(472, 193);
            this.btnUnesiStavkuPP.Name = "btnUnesiStavkuPP";
            this.btnUnesiStavkuPP.Size = new System.Drawing.Size(75, 23);
            this.btnUnesiStavkuPP.TabIndex = 23;
            this.btnUnesiStavkuPP.Text = "Unesi";
            this.btnUnesiStavkuPP.UseVisualStyleBackColor = true;
            this.btnUnesiStavkuPP.Click += new System.EventHandler(this.btnUnesiStavkuPP_Click);
            // 
            // tbKolicinaPP
            // 
            this.tbKolicinaPP.Location = new System.Drawing.Point(61, 195);
            this.tbKolicinaPP.Name = "tbKolicinaPP";
            this.tbKolicinaPP.Size = new System.Drawing.Size(105, 20);
            this.tbKolicinaPP.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 195);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Količina";
            // 
            // cbPPSastavnicaNaziv
            // 
            this.cbPPSastavnicaNaziv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPPSastavnicaNaziv.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbPPSastavnicaNaziv.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbPPSastavnicaNaziv.FormattingEnabled = true;
            this.cbPPSastavnicaNaziv.Location = new System.Drawing.Point(173, 163);
            this.cbPPSastavnicaNaziv.Name = "cbPPSastavnicaNaziv";
            this.cbPPSastavnicaNaziv.Size = new System.Drawing.Size(371, 21);
            this.cbPPSastavnicaNaziv.TabIndex = 8;
            // 
            // btnNovaStavkaPP
            // 
            this.btnNovaStavkaPP.Location = new System.Drawing.Point(453, 125);
            this.btnNovaStavkaPP.Name = "btnNovaStavkaPP";
            this.btnNovaStavkaPP.Size = new System.Drawing.Size(94, 23);
            this.btnNovaStavkaPP.TabIndex = 15;
            this.btnNovaStavkaPP.Text = "Nova stavka";
            this.btnNovaStavkaPP.UseVisualStyleBackColor = true;
            this.btnNovaStavkaPP.Click += new System.EventHandler(this.btnNovaStavkaPP_Click);
            // 
            // cbPPSastavnicaSifra
            // 
            this.cbPPSastavnicaSifra.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbPPSastavnicaSifra.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbPPSastavnicaSifra.FormattingEnabled = true;
            this.cbPPSastavnicaSifra.Location = new System.Drawing.Point(62, 163);
            this.cbPPSastavnicaSifra.Name = "cbPPSastavnicaSifra";
            this.cbPPSastavnicaSifra.Size = new System.Drawing.Size(105, 21);
            this.cbPPSastavnicaSifra.TabIndex = 7;
            // 
            // btnObrisiPP
            // 
            this.btnObrisiPP.Location = new System.Drawing.Point(11, 125);
            this.btnObrisiPP.Name = "btnObrisiPP";
            this.btnObrisiPP.Size = new System.Drawing.Size(64, 23);
            this.btnObrisiPP.TabIndex = 14;
            this.btnObrisiPP.Text = "Obriši";
            this.btnObrisiPP.UseVisualStyleBackColor = true;
            this.btnObrisiPP.Click += new System.EventHandler(this.btnObrisiPP_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(32, 163);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "PP";
            // 
            // dgvPP
            // 
            this.dgvPP.AllowUserToAddRows = false;
            this.dgvPP.AllowUserToDeleteRows = false;
            this.dgvPP.AllowUserToOrderColumns = true;
            this.dgvPP.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPP.Location = new System.Drawing.Point(11, 19);
            this.dgvPP.Name = "dgvPP";
            this.dgvPP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPP.Size = new System.Drawing.Size(536, 100);
            this.dgvPP.TabIndex = 12;
            this.dgvPP.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPP_CellClick);
            // 
            // FormSastavnicaPPSirovina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 776);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormSastavnicaPPSirovina";
            this.Text = "Sastavnica poluproizvod-sirovina";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxStavka.ResumeLayout(false);
            this.groupBoxStavka.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGPSastavnica)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnNovaStavka;
        private System.Windows.Forms.Button btnObrisi;
        private System.Windows.Forms.GroupBox groupBoxStavka;
        private System.Windows.Forms.Button btnIzmeniStavku;
        private System.Windows.Forms.Button btnUnesiStavku;
        private System.Windows.Forms.TextBox tbKolicina;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbPPnaziv;
        private System.Windows.Forms.ComboBox cbPPSif;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cbProizvodNaziv;
        private System.Windows.Forms.ComboBox cbProizvodSifra;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnNoviPP;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnNovaStavkaGP;
        private System.Windows.Forms.Button btnObrisiGP;
        private System.Windows.Forms.Button btnIzmeniStavkuGP;
        private System.Windows.Forms.Button btnUnesiStavkuGP;
        private System.Windows.Forms.TextBox tbKolicinaGP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvGPSastavnica;
        private System.Windows.Forms.ComboBox cbGPSastavnicaNaziv;
        private System.Windows.Forms.ComboBox cbGPSastavnicaSifra;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnIzmeniStavkuPP;
        private System.Windows.Forms.Button btnUnesiStavkuPP;
        private System.Windows.Forms.TextBox tbKolicinaPP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbPPSastavnicaNaziv;
        private System.Windows.Forms.Button btnNovaStavkaPP;
        private System.Windows.Forms.ComboBox cbPPSastavnicaSifra;
        private System.Windows.Forms.Button btnObrisiPP;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvPP;
    }
}