namespace plamen
{
    partial class FormNoviNalog
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
            this.checkBoxRealizovan = new System.Windows.Forms.CheckBox();
            this.btnObrisi = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpRok = new System.Windows.Forms.DateTimePicker();
            this.lblNapravljeno = new System.Windows.Forms.Label();
            this.tbNapravljeno = new System.Windows.Forms.TextBox();
            this.gbNalogGP = new System.Windows.Forms.GroupBox();
            this.btnSacuvajNalog = new System.Windows.Forms.Button();
            this.gbStanjeProizvoda = new System.Windows.Forms.GroupBox();
            this.cbRealiz = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbNapomena = new System.Windows.Forms.TextBox();
            this.cbKupacNaziv = new System.Windows.Forms.ComboBox();
            this.groupBoxStavka = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbRezervisano = new System.Windows.Forms.TextBox();
            this.btnIzmeniStavku = new System.Windows.Forms.Button();
            this.btnUnesiStavku = new System.Windows.Forms.Button();
            this.tbKolicina = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmproizvodNaziv = new System.Windows.Forms.ComboBox();
            this.cbProizvodSifra = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnNovaStavka = new System.Windows.Forms.Button();
            this.btnObrisiStavku = new System.Windows.Forms.Button();
            this.dgvStavkeNaloga = new System.Windows.Forms.DataGridView();
            this.btnStampa = new System.Windows.Forms.Button();
            this.btnIzmeni = new System.Windows.Forms.Button();
            this.dtpDatum = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cbKupacSifra = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbBrojNaloga = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBoxStavka.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStavkeNaloga)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.checkBoxRealizovan);
            this.groupBox1.Controls.Add(this.btnObrisi);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.dtpRok);
            this.groupBox1.Controls.Add(this.lblNapravljeno);
            this.groupBox1.Controls.Add(this.tbNapravljeno);
            this.groupBox1.Controls.Add(this.gbNalogGP);
            this.groupBox1.Controls.Add(this.btnSacuvajNalog);
            this.groupBox1.Controls.Add(this.gbStanjeProizvoda);
            this.groupBox1.Controls.Add(this.cbRealiz);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbNapomena);
            this.groupBox1.Controls.Add(this.cbKupacNaziv);
            this.groupBox1.Controls.Add(this.groupBoxStavka);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btnStampa);
            this.groupBox1.Controls.Add(this.btnIzmeni);
            this.groupBox1.Controls.Add(this.dtpDatum);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbKupacSifra);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbBrojNaloga);
            this.groupBox1.Location = new System.Drawing.Point(1, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(920, 597);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // checkBoxRealizovan
            // 
            this.checkBoxRealizovan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxRealizovan.AutoSize = true;
            this.checkBoxRealizovan.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxRealizovan.Location = new System.Drawing.Point(12, 527);
            this.checkBoxRealizovan.Name = "checkBoxRealizovan";
            this.checkBoxRealizovan.Size = new System.Drawing.Size(79, 17);
            this.checkBoxRealizovan.TabIndex = 44;
            this.checkBoxRealizovan.Text = "Realizovan";
            this.checkBoxRealizovan.UseVisualStyleBackColor = true;
            this.checkBoxRealizovan.CheckedChanged += new System.EventHandler(this.checkBoxRealizovan_CheckedChanged);
            // 
            // btnObrisi
            // 
            this.btnObrisi.Enabled = false;
            this.btnObrisi.Location = new System.Drawing.Point(345, 19);
            this.btnObrisi.Name = "btnObrisi";
            this.btnObrisi.Size = new System.Drawing.Size(75, 23);
            this.btnObrisi.TabIndex = 37;
            this.btnObrisi.Text = "Obriši";
            this.btnObrisi.UseVisualStyleBackColor = true;
            this.btnObrisi.Click += new System.EventHandler(this.btnObrisi_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "Rok";
            // 
            // dtpRok
            // 
            this.dtpRok.CustomFormat = "dd.MM.yyyy";
            this.dtpRok.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpRok.Location = new System.Drawing.Point(77, 48);
            this.dtpRok.Name = "dtpRok";
            this.dtpRok.Size = new System.Drawing.Size(108, 20);
            this.dtpRok.TabIndex = 35;
            this.dtpRok.Value = new System.DateTime(2018, 1, 17, 18, 20, 13, 0);
            // 
            // lblNapravljeno
            // 
            this.lblNapravljeno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNapravljeno.AutoSize = true;
            this.lblNapravljeno.Location = new System.Drawing.Point(212, 526);
            this.lblNapravljeno.Name = "lblNapravljeno";
            this.lblNapravljeno.Size = new System.Drawing.Size(71, 13);
            this.lblNapravljeno.TabIndex = 34;
            this.lblNapravljeno.Text = "Zapakovano:";
            // 
            // tbNapravljeno
            // 
            this.tbNapravljeno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbNapravljeno.Location = new System.Drawing.Point(285, 524);
            this.tbNapravljeno.Name = "tbNapravljeno";
            this.tbNapravljeno.Size = new System.Drawing.Size(100, 20);
            this.tbNapravljeno.TabIndex = 33;
            // 
            // gbNalogGP
            // 
            this.gbNalogGP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbNalogGP.Location = new System.Drawing.Point(650, 352);
            this.gbNalogGP.Name = "gbNalogGP";
            this.gbNalogGP.Size = new System.Drawing.Size(264, 197);
            this.gbNalogGP.TabIndex = 28;
            this.gbNalogGP.TabStop = false;
            this.gbNalogGP.Text = "Spisak RN GP";
            // 
            // btnSacuvajNalog
            // 
            this.btnSacuvajNalog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSacuvajNalog.Location = new System.Drawing.Point(569, 526);
            this.btnSacuvajNalog.Name = "btnSacuvajNalog";
            this.btnSacuvajNalog.Size = new System.Drawing.Size(75, 23);
            this.btnSacuvajNalog.TabIndex = 27;
            this.btnSacuvajNalog.Text = "Sacuvaj";
            this.btnSacuvajNalog.UseVisualStyleBackColor = true;
            this.btnSacuvajNalog.Click += new System.EventHandler(this.btnSacuvajNalog_Click);
            // 
            // gbStanjeProizvoda
            // 
            this.gbStanjeProizvoda.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbStanjeProizvoda.Location = new System.Drawing.Point(650, 10);
            this.gbStanjeProizvoda.Name = "gbStanjeProizvoda";
            this.gbStanjeProizvoda.Size = new System.Drawing.Size(264, 335);
            this.gbStanjeProizvoda.TabIndex = 14;
            this.gbStanjeProizvoda.TabStop = false;
            // 
            // cbRealiz
            // 
            this.cbRealiz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbRealiz.FormattingEnabled = true;
            this.cbRealiz.Location = new System.Drawing.Point(67, 526);
            this.cbRealiz.Name = "cbRealiz";
            this.cbRealiz.Size = new System.Drawing.Size(131, 21);
            this.cbRealiz.TabIndex = 13;
            this.cbRealiz.Visible = false;
            this.cbRealiz.SelectedValueChanged += new System.EventHandler(this.cbRealiz_SelectedValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Napomena";
            // 
            // tbNapomena
            // 
            this.tbNapomena.Location = new System.Drawing.Point(77, 106);
            this.tbNapomena.Name = "tbNapomena";
            this.tbNapomena.Size = new System.Drawing.Size(553, 20);
            this.tbNapomena.TabIndex = 11;
            // 
            // cbKupacNaziv
            // 
            this.cbKupacNaziv.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbKupacNaziv.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbKupacNaziv.FormattingEnabled = true;
            this.cbKupacNaziv.Location = new System.Drawing.Point(193, 78);
            this.cbKupacNaziv.Name = "cbKupacNaziv";
            this.cbKupacNaziv.Size = new System.Drawing.Size(437, 21);
            this.cbKupacNaziv.TabIndex = 10;
            this.cbKupacNaziv.Leave += new System.EventHandler(this.cbKupacNaziv_Leave);
            // 
            // groupBoxStavka
            // 
            this.groupBoxStavka.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxStavka.BackColor = System.Drawing.SystemColors.Control;
            this.groupBoxStavka.Controls.Add(this.label6);
            this.groupBoxStavka.Controls.Add(this.tbRezervisano);
            this.groupBoxStavka.Controls.Add(this.btnIzmeniStavku);
            this.groupBoxStavka.Controls.Add(this.btnUnesiStavku);
            this.groupBoxStavka.Controls.Add(this.tbKolicina);
            this.groupBoxStavka.Controls.Add(this.label4);
            this.groupBoxStavka.Controls.Add(this.cmproizvodNaziv);
            this.groupBoxStavka.Controls.Add(this.cbProizvodSifra);
            this.groupBoxStavka.Controls.Add(this.button1);
            this.groupBoxStavka.Controls.Add(this.button6);
            this.groupBoxStavka.Controls.Add(this.button4);
            this.groupBoxStavka.Controls.Add(this.label3);
            this.groupBoxStavka.Location = new System.Drawing.Point(7, 400);
            this.groupBoxStavka.Name = "groupBoxStavka";
            this.groupBoxStavka.Size = new System.Drawing.Size(637, 113);
            this.groupBoxStavka.TabIndex = 9;
            this.groupBoxStavka.TabStop = false;
            this.groupBoxStavka.Text = "Stavke zahteva";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(194, 83);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Rezervisano";
            // 
            // tbRezervisano
            // 
            this.tbRezervisano.Location = new System.Drawing.Point(266, 80);
            this.tbRezervisano.Name = "tbRezervisano";
            this.tbRezervisano.Size = new System.Drawing.Size(100, 20);
            this.tbRezervisano.TabIndex = 26;
            // 
            // btnIzmeniStavku
            // 
            this.btnIzmeniStavku.Enabled = false;
            this.btnIzmeniStavku.Location = new System.Drawing.Point(391, 81);
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
            this.btnUnesiStavku.Location = new System.Drawing.Point(548, 81);
            this.btnUnesiStavku.Name = "btnUnesiStavku";
            this.btnUnesiStavku.Size = new System.Drawing.Size(75, 23);
            this.btnUnesiStavku.TabIndex = 23;
            this.btnUnesiStavku.Text = "Unesi";
            this.btnUnesiStavku.UseVisualStyleBackColor = true;
            this.btnUnesiStavku.Click += new System.EventHandler(this.btnUnesiStavku_Click);
            // 
            // tbKolicina
            // 
            this.tbKolicina.Location = new System.Drawing.Point(60, 83);
            this.tbKolicina.Name = "tbKolicina";
            this.tbKolicina.Size = new System.Drawing.Size(105, 20);
            this.tbKolicina.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Količina";
            // 
            // cmproizvodNaziv
            // 
            this.cmproizvodNaziv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmproizvodNaziv.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmproizvodNaziv.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmproizvodNaziv.FormattingEnabled = true;
            this.cmproizvodNaziv.Location = new System.Drawing.Point(247, 45);
            this.cmproizvodNaziv.Name = "cmproizvodNaziv";
            this.cmproizvodNaziv.Size = new System.Drawing.Size(371, 21);
            this.cmproizvodNaziv.TabIndex = 8;
            this.cmproizvodNaziv.Leave += new System.EventHandler(this.cmproizvodNaziv_Leave);
            // 
            // cbProizvodSifra
            // 
            this.cbProizvodSifra.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbProizvodSifra.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbProizvodSifra.FormattingEnabled = true;
            this.cbProizvodSifra.Location = new System.Drawing.Point(60, 45);
            this.cbProizvodSifra.Name = "cbProizvodSifra";
            this.cbProizvodSifra.Size = new System.Drawing.Size(105, 21);
            this.cbProizvodSifra.TabIndex = 7;
            this.cbProizvodSifra.Leave += new System.EventHandler(this.cbProizvodSifra_Leave);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(296, 272);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 20);
            this.button1.TabIndex = 19;
            this.button1.Text = "Potvrdi izmenu";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(447, 272);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(93, 20);
            this.button6.TabIndex = 20;
            this.button6.Text = "Odustani";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(154, 272);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(93, 20);
            this.button4.TabIndex = 1;
            this.button4.Text = "Unesi";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Proizvod";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.btnNovaStavka);
            this.groupBox2.Controls.Add(this.btnObrisiStavku);
            this.groupBox2.Controls.Add(this.dgvStavkeNaloga);
            this.groupBox2.Location = new System.Drawing.Point(7, 132);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(637, 262);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Prikaz Proizvoda";
            // 
            // btnNovaStavka
            // 
            this.btnNovaStavka.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNovaStavka.Location = new System.Drawing.Point(523, 227);
            this.btnNovaStavka.Name = "btnNovaStavka";
            this.btnNovaStavka.Size = new System.Drawing.Size(100, 23);
            this.btnNovaStavka.TabIndex = 9;
            this.btnNovaStavka.Text = "Nova stavka";
            this.btnNovaStavka.UseVisualStyleBackColor = true;
            this.btnNovaStavka.Click += new System.EventHandler(this.btnNovaStavka_Click);
            // 
            // btnObrisiStavku
            // 
            this.btnObrisiStavku.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnObrisiStavku.Location = new System.Drawing.Point(8, 227);
            this.btnObrisiStavku.Name = "btnObrisiStavku";
            this.btnObrisiStavku.Size = new System.Drawing.Size(97, 23);
            this.btnObrisiStavku.TabIndex = 8;
            this.btnObrisiStavku.Text = "Obrisi stavku";
            this.btnObrisiStavku.UseVisualStyleBackColor = true;
            this.btnObrisiStavku.Click += new System.EventHandler(this.btnObrisiStavku_Click);
            // 
            // dgvStavkeNaloga
            // 
            this.dgvStavkeNaloga.AllowUserToAddRows = false;
            this.dgvStavkeNaloga.AllowUserToDeleteRows = false;
            this.dgvStavkeNaloga.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvStavkeNaloga.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvStavkeNaloga.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStavkeNaloga.Location = new System.Drawing.Point(5, 19);
            this.dgvStavkeNaloga.Name = "dgvStavkeNaloga";
            this.dgvStavkeNaloga.ReadOnly = true;
            this.dgvStavkeNaloga.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStavkeNaloga.Size = new System.Drawing.Size(626, 196);
            this.dgvStavkeNaloga.TabIndex = 7;
            this.dgvStavkeNaloga.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStavkeNaloga_CellClick);
            this.dgvStavkeNaloga.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStavkeNaloga_RowEnter);
            // 
            // btnStampa
            // 
            this.btnStampa.Location = new System.Drawing.Point(555, 19);
            this.btnStampa.Name = "btnStampa";
            this.btnStampa.Size = new System.Drawing.Size(75, 23);
            this.btnStampa.TabIndex = 6;
            this.btnStampa.Text = "Stampa";
            this.btnStampa.UseVisualStyleBackColor = true;
            this.btnStampa.Click += new System.EventHandler(this.btnStampa_Click);
            // 
            // btnIzmeni
            // 
            this.btnIzmeni.Location = new System.Drawing.Point(264, 19);
            this.btnIzmeni.Name = "btnIzmeni";
            this.btnIzmeni.Size = new System.Drawing.Size(75, 23);
            this.btnIzmeni.TabIndex = 5;
            this.btnIzmeni.Text = "Izmeni";
            this.btnIzmeni.UseVisualStyleBackColor = true;
            this.btnIzmeni.Click += new System.EventHandler(this.btnIzmeni_Click);
            // 
            // dtpDatum
            // 
            this.dtpDatum.CustomFormat = "dd.MM.yyyy";
            this.dtpDatum.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDatum.Location = new System.Drawing.Point(150, 22);
            this.dtpDatum.Name = "dtpDatum";
            this.dtpDatum.Size = new System.Drawing.Size(108, 20);
            this.dtpDatum.TabIndex = 4;
            this.dtpDatum.Value = new System.DateTime(2018, 1, 17, 18, 20, 13, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Kupac";
            // 
            // cbKupacSifra
            // 
            this.cbKupacSifra.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbKupacSifra.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbKupacSifra.FormattingEnabled = true;
            this.cbKupacSifra.Location = new System.Drawing.Point(77, 78);
            this.cbKupacSifra.Name = "cbKupacSifra";
            this.cbKupacSifra.Size = new System.Drawing.Size(110, 21);
            this.cbKupacSifra.TabIndex = 2;
            this.cbKupacSifra.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbKupacSifra_KeyDown);
            this.cbKupacSifra.Leave += new System.EventHandler(this.cbKupacSifra_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Broj zahteva";
            // 
            // tbBrojNaloga
            // 
            this.tbBrojNaloga.Location = new System.Drawing.Point(77, 22);
            this.tbBrojNaloga.Name = "tbBrojNaloga";
            this.tbBrojNaloga.Size = new System.Drawing.Size(67, 20);
            this.tbBrojNaloga.TabIndex = 0;
            this.tbBrojNaloga.Leave += new System.EventHandler(this.tbBrojNaloga_Leave);
            // 
            // FormNoviNalog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 595);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormNoviNalog";
            this.Text = "Novi Nalog";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxStavka.ResumeLayout(false);
            this.groupBoxStavka.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStavkeNaloga)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpDatum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbKupacSifra;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbBrojNaloga;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnObrisiStavku;
        private System.Windows.Forms.DataGridView dgvStavkeNaloga;
        private System.Windows.Forms.Button btnStampa;
        private System.Windows.Forms.Button btnIzmeni;
        private System.Windows.Forms.GroupBox groupBoxStavka;
        private System.Windows.Forms.ComboBox cmproizvodNaziv;
        private System.Windows.Forms.ComboBox cbProizvodSifra;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnUnesiStavku;
        private System.Windows.Forms.TextBox tbKolicina;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbKupacNaziv;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbNapomena;
        private System.Windows.Forms.ComboBox cbRealiz;
        private System.Windows.Forms.Button btnIzmeniStavku;
        private System.Windows.Forms.Button btnNovaStavka;
        private System.Windows.Forms.GroupBox gbStanjeProizvoda;
        private System.Windows.Forms.Button btnSacuvajNalog;
        private System.Windows.Forms.GroupBox gbNalogGP;
        private System.Windows.Forms.Label lblNapravljeno;
        private System.Windows.Forms.TextBox tbNapravljeno;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbRezervisano;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpRok;
        private System.Windows.Forms.Button btnObrisi;
        private System.Windows.Forms.CheckBox checkBoxRealizovan;
    }
}