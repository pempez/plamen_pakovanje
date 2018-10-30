namespace plamen
{
    partial class FormSastavnica
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
            this.groupBoxStavka = new System.Windows.Forms.GroupBox();
            this.btnIzmeniStavku = new System.Windows.Forms.Button();
            this.btnUnesiStavku = new System.Windows.Forms.Button();
            this.tbKolicina = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbPPnaziv = new System.Windows.Forms.ComboBox();
            this.btnNovaStavka = new System.Windows.Forms.Button();
            this.cbPPSif = new System.Windows.Forms.ComboBox();
            this.btnObrisi = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnNovaStavkaSir = new System.Windows.Forms.Button();
            this.btnObrisiSirovinu = new System.Windows.Forms.Button();
            this.btnIzmeniStavkuSir = new System.Windows.Forms.Button();
            this.btnUnesiStavkuSir = new System.Windows.Forms.Button();
            this.tbKolicinaSir = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvSirovineSastavnica = new System.Windows.Forms.DataGridView();
            this.cbSirovinaNaziv = new System.Windows.Forms.ComboBox();
            this.cbSirovinaSifra = new System.Windows.Forms.ComboBox();
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
            this.btnNoviPP = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbProizvodNaziv = new System.Windows.Forms.ComboBox();
            this.cbProizvodSifra = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBoxStavka.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSirovineSastavnica)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGPSastavnica)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBoxStavka);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.btnNoviPP);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.cbProizvodNaziv);
            this.groupBox1.Controls.Add(this.cbProizvodSifra);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1149, 829);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sastavnica gotov proizvod";
            // 
            // groupBoxStavka
            // 
            this.groupBoxStavka.BackColor = System.Drawing.SystemColors.Control;
            this.groupBoxStavka.Controls.Add(this.btnIzmeniStavku);
            this.groupBoxStavka.Controls.Add(this.btnUnesiStavku);
            this.groupBoxStavka.Controls.Add(this.tbKolicina);
            this.groupBoxStavka.Controls.Add(this.label4);
            this.groupBoxStavka.Controls.Add(this.cbPPnaziv);
            this.groupBoxStavka.Controls.Add(this.btnNovaStavka);
            this.groupBoxStavka.Controls.Add(this.cbPPSif);
            this.groupBoxStavka.Controls.Add(this.btnObrisi);
            this.groupBoxStavka.Controls.Add(this.label1);
            this.groupBoxStavka.Controls.Add(this.dataGridView1);
            this.groupBoxStavka.Location = new System.Drawing.Point(9, 46);
            this.groupBoxStavka.Name = "groupBoxStavka";
            this.groupBoxStavka.Size = new System.Drawing.Size(560, 280);
            this.groupBoxStavka.TabIndex = 13;
            this.groupBoxStavka.TabStop = false;
            this.groupBoxStavka.Text = "Poluproizvod";
            // 
            // btnIzmeniStavku
            // 
            this.btnIzmeniStavku.Enabled = false;
            this.btnIzmeniStavku.Location = new System.Drawing.Point(389, 248);
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
            this.btnUnesiStavku.Location = new System.Drawing.Point(469, 248);
            this.btnUnesiStavku.Name = "btnUnesiStavku";
            this.btnUnesiStavku.Size = new System.Drawing.Size(75, 23);
            this.btnUnesiStavku.TabIndex = 23;
            this.btnUnesiStavku.Text = "Unesi";
            this.btnUnesiStavku.UseVisualStyleBackColor = true;
            this.btnUnesiStavku.Click += new System.EventHandler(this.btnUnesiStavku_Click);
            // 
            // tbKolicina
            // 
            this.tbKolicina.Location = new System.Drawing.Point(58, 250);
            this.tbKolicina.Name = "tbKolicina";
            this.tbKolicina.Size = new System.Drawing.Size(105, 20);
            this.tbKolicina.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 250);
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
            this.cbPPnaziv.Location = new System.Drawing.Point(170, 218);
            this.cbPPnaziv.Name = "cbPPnaziv";
            this.cbPPnaziv.Size = new System.Drawing.Size(371, 21);
            this.cbPPnaziv.TabIndex = 8;
            this.cbPPnaziv.Leave += new System.EventHandler(this.cbPPnaziv_Leave);
            // 
            // btnNovaStavka
            // 
            this.btnNovaStavka.Location = new System.Drawing.Point(451, 189);
            this.btnNovaStavka.Name = "btnNovaStavka";
            this.btnNovaStavka.Size = new System.Drawing.Size(94, 23);
            this.btnNovaStavka.TabIndex = 15;
            this.btnNovaStavka.Text = "Nova stavka";
            this.btnNovaStavka.UseVisualStyleBackColor = true;
            this.btnNovaStavka.Click += new System.EventHandler(this.btnNovaStavka_Click);
            // 
            // cbPPSif
            // 
            this.cbPPSif.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbPPSif.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbPPSif.FormattingEnabled = true;
            this.cbPPSif.Location = new System.Drawing.Point(59, 218);
            this.cbPPSif.Name = "cbPPSif";
            this.cbPPSif.Size = new System.Drawing.Size(105, 21);
            this.cbPPSif.TabIndex = 7;
            this.cbPPSif.Leave += new System.EventHandler(this.cbPPSif_Leave);
            // 
            // btnObrisi
            // 
            this.btnObrisi.Location = new System.Drawing.Point(9, 189);
            this.btnObrisi.Name = "btnObrisi";
            this.btnObrisi.Size = new System.Drawing.Size(64, 23);
            this.btnObrisi.TabIndex = 14;
            this.btnObrisi.Text = "Obriši";
            this.btnObrisi.UseVisualStyleBackColor = true;
            this.btnObrisi.Click += new System.EventHandler(this.btnObrisi_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 218);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "PP";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(11, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(536, 164);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnNovaStavkaSir);
            this.groupBox4.Controls.Add(this.btnObrisiSirovinu);
            this.groupBox4.Controls.Add(this.btnIzmeniStavkuSir);
            this.groupBox4.Controls.Add(this.btnUnesiStavkuSir);
            this.groupBox4.Controls.Add(this.tbKolicinaSir);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.dgvSirovineSastavnica);
            this.groupBox4.Controls.Add(this.cbSirovinaNaziv);
            this.groupBox4.Controls.Add(this.cbSirovinaSifra);
            this.groupBox4.Location = new System.Drawing.Point(6, 559);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(560, 228);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Sirovine";
            // 
            // btnNovaStavkaSir
            // 
            this.btnNovaStavkaSir.Location = new System.Drawing.Point(454, 134);
            this.btnNovaStavkaSir.Name = "btnNovaStavkaSir";
            this.btnNovaStavkaSir.Size = new System.Drawing.Size(100, 23);
            this.btnNovaStavkaSir.TabIndex = 29;
            this.btnNovaStavkaSir.Text = "Nova stavka";
            this.btnNovaStavkaSir.UseVisualStyleBackColor = true;
            this.btnNovaStavkaSir.Click += new System.EventHandler(this.btnNovaStavkaSir_Click);
            // 
            // btnObrisiSirovinu
            // 
            this.btnObrisiSirovinu.Location = new System.Drawing.Point(6, 134);
            this.btnObrisiSirovinu.Name = "btnObrisiSirovinu";
            this.btnObrisiSirovinu.Size = new System.Drawing.Size(75, 23);
            this.btnObrisiSirovinu.TabIndex = 28;
            this.btnObrisiSirovinu.Text = "Obriši";
            this.btnObrisiSirovinu.UseVisualStyleBackColor = true;
            this.btnObrisiSirovinu.Click += new System.EventHandler(this.btnObrisiSirovinu_Click);
            // 
            // btnIzmeniStavkuSir
            // 
            this.btnIzmeniStavkuSir.Location = new System.Drawing.Point(392, 193);
            this.btnIzmeniStavkuSir.Name = "btnIzmeniStavkuSir";
            this.btnIzmeniStavkuSir.Size = new System.Drawing.Size(75, 23);
            this.btnIzmeniStavkuSir.TabIndex = 27;
            this.btnIzmeniStavkuSir.Text = "Izmeni";
            this.btnIzmeniStavkuSir.UseVisualStyleBackColor = true;
            this.btnIzmeniStavkuSir.Click += new System.EventHandler(this.btnIzmeniStavkuSir_Click);
            // 
            // btnUnesiStavkuSir
            // 
            this.btnUnesiStavkuSir.Location = new System.Drawing.Point(479, 193);
            this.btnUnesiStavkuSir.Name = "btnUnesiStavkuSir";
            this.btnUnesiStavkuSir.Size = new System.Drawing.Size(75, 23);
            this.btnUnesiStavkuSir.TabIndex = 26;
            this.btnUnesiStavkuSir.Text = "Unesi";
            this.btnUnesiStavkuSir.UseVisualStyleBackColor = true;
            this.btnUnesiStavkuSir.Click += new System.EventHandler(this.btnUnesiStavkuSir_Click);
            // 
            // tbKolicinaSir
            // 
            this.tbKolicinaSir.Location = new System.Drawing.Point(59, 190);
            this.tbKolicinaSir.Name = "tbKolicinaSir";
            this.tbKolicinaSir.Size = new System.Drawing.Size(105, 20);
            this.tbKolicinaSir.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 193);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Količina";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 166);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Sirovina";
            // 
            // dgvSirovineSastavnica
            // 
            this.dgvSirovineSastavnica.AllowUserToAddRows = false;
            this.dgvSirovineSastavnica.AllowUserToDeleteRows = false;
            this.dgvSirovineSastavnica.AllowUserToOrderColumns = true;
            this.dgvSirovineSastavnica.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvSirovineSastavnica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSirovineSastavnica.Location = new System.Drawing.Point(6, 19);
            this.dgvSirovineSastavnica.Name = "dgvSirovineSastavnica";
            this.dgvSirovineSastavnica.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSirovineSastavnica.Size = new System.Drawing.Size(548, 109);
            this.dgvSirovineSastavnica.TabIndex = 14;
            this.dgvSirovineSastavnica.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSirovineSastavnica_CellContentClick);
            // 
            // cbSirovinaNaziv
            // 
            this.cbSirovinaNaziv.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbSirovinaNaziv.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbSirovinaNaziv.FormattingEnabled = true;
            this.cbSirovinaNaziv.Location = new System.Drawing.Point(174, 163);
            this.cbSirovinaNaziv.Name = "cbSirovinaNaziv";
            this.cbSirovinaNaziv.Size = new System.Drawing.Size(380, 21);
            this.cbSirovinaNaziv.TabIndex = 13;
            // 
            // cbSirovinaSifra
            // 
            this.cbSirovinaSifra.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbSirovinaSifra.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbSirovinaSifra.FormattingEnabled = true;
            this.cbSirovinaSifra.Location = new System.Drawing.Point(59, 163);
            this.cbSirovinaSifra.Name = "cbSirovinaSifra";
            this.cbSirovinaSifra.Size = new System.Drawing.Size(105, 21);
            this.cbSirovinaSifra.TabIndex = 12;
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
            this.groupBox3.Location = new System.Drawing.Point(9, 332);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(560, 221);
            this.groupBox3.TabIndex = 18;
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
            this.btnNovaStavkaGP.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnObrisiGP
            // 
            this.btnObrisiGP.Location = new System.Drawing.Point(6, 134);
            this.btnObrisiGP.Name = "btnObrisiGP";
            this.btnObrisiGP.Size = new System.Drawing.Size(75, 23);
            this.btnObrisiGP.TabIndex = 28;
            this.btnObrisiGP.Text = "Obriši";
            this.btnObrisiGP.UseVisualStyleBackColor = true;
            this.btnObrisiGP.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnIzmeniStavkuGP
            // 
            this.btnIzmeniStavkuGP.Location = new System.Drawing.Point(389, 193);
            this.btnIzmeniStavkuGP.Name = "btnIzmeniStavkuGP";
            this.btnIzmeniStavkuGP.Size = new System.Drawing.Size(75, 23);
            this.btnIzmeniStavkuGP.TabIndex = 27;
            this.btnIzmeniStavkuGP.Text = "Izmeni";
            this.btnIzmeniStavkuGP.UseVisualStyleBackColor = true;
            this.btnIzmeniStavkuGP.Click += new System.EventHandler(this.btnIzmeniStavkuGP_Click);
            // 
            // btnUnesiStavkuGP
            // 
            this.btnUnesiStavkuGP.Location = new System.Drawing.Point(479, 193);
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
            this.dgvGPSastavnica.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvGPSastavnica_CellContentClick);
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
            // btnNoviPP
            // 
            this.btnNoviPP.Location = new System.Drawing.Point(494, 17);
            this.btnNoviPP.Name = "btnNoviPP";
            this.btnNoviPP.Size = new System.Drawing.Size(75, 23);
            this.btnNoviPP.TabIndex = 17;
            this.btnNoviPP.Text = "Novi PP";
            this.btnNoviPP.UseVisualStyleBackColor = true;
            this.btnNoviPP.Click += new System.EventHandler(this.btnNoviPP_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Location = new System.Drawing.Point(588, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(555, 821);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            // 
            // cbProizvodNaziv
            // 
            this.cbProizvodNaziv.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbProizvodNaziv.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbProizvodNaziv.FormattingEnabled = true;
            this.cbProizvodNaziv.Location = new System.Drawing.Point(199, 19);
            this.cbProizvodNaziv.Name = "cbProizvodNaziv";
            this.cbProizvodNaziv.Size = new System.Drawing.Size(281, 21);
            this.cbProizvodNaziv.TabIndex = 11;
            this.cbProizvodNaziv.Leave += new System.EventHandler(this.cbProizvodNaziv_Leave);
            // 
            // cbProizvodSifra
            // 
            this.cbProizvodSifra.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbProizvodSifra.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbProizvodSifra.FormattingEnabled = true;
            this.cbProizvodSifra.Location = new System.Drawing.Point(88, 19);
            this.cbProizvodSifra.Name = "cbProizvodSifra";
            this.cbProizvodSifra.Size = new System.Drawing.Size(105, 21);
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
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Gotov proizvod";
            // 
            // FormSastavnica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 802);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormSastavnica";
            this.Text = "Sastavnica ";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxStavka.ResumeLayout(false);
            this.groupBoxStavka.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSirovineSastavnica)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGPSastavnica)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbProizvodNaziv;
        private System.Windows.Forms.ComboBox cbProizvodSifra;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBoxStavka;
        private System.Windows.Forms.Button btnIzmeniStavku;
        private System.Windows.Forms.Button btnUnesiStavku;
        private System.Windows.Forms.TextBox tbKolicina;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbPPnaziv;
        private System.Windows.Forms.ComboBox cbPPSif;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnObrisi;
        private System.Windows.Forms.Button btnNovaStavka;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnNoviPP;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tbKolicinaGP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvGPSastavnica;
        private System.Windows.Forms.ComboBox cbGPSastavnicaNaziv;
        private System.Windows.Forms.ComboBox cbGPSastavnicaSifra;
        private System.Windows.Forms.Button btnIzmeniStavkuGP;
        private System.Windows.Forms.Button btnUnesiStavkuGP;
        private System.Windows.Forms.Button btnNovaStavkaGP;
        private System.Windows.Forms.Button btnObrisiGP;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnNovaStavkaSir;
        private System.Windows.Forms.Button btnObrisiSirovinu;
        private System.Windows.Forms.Button btnIzmeniStavkuSir;
        private System.Windows.Forms.Button btnUnesiStavkuSir;
        private System.Windows.Forms.TextBox tbKolicinaSir;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvSirovineSastavnica;
        private System.Windows.Forms.ComboBox cbSirovinaNaziv;
        private System.Windows.Forms.ComboBox cbSirovinaSifra;
    }
}