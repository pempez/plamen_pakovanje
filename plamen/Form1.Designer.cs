namespace plamen
{
    partial class Form1
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Zahtev za proizvodnju");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Novi RN GP");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Novi RN PP");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Spisak Zahteva");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Nalozi", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Stanje GP");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Stanje PP");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Stanje", new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Sastavnica gotov proizvod");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Sastavnica poluproizvod");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Sastavnica", new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode10});
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Gotovi proizvodi");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Poluproizvodi");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Sirovine");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Proizvodi", new System.Windows.Forms.TreeNode[] {
            treeNode12,
            treeNode13,
            treeNode14});
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Spisak");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Realizovani zahtevi", new System.Windows.Forms.TreeNode[] {
            treeNode16});
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Kupci");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Kupci", new System.Windows.Forms.TreeNode[] {
            treeNode18});
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Pakovanje");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Spisak Pakovanja");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Vrste kutija");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Vrsta paleta");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("Odgovorne osobe");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("GP u kutiji");
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("Kutija na paleti");
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("Paritet");
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("Pakovanje", new System.Windows.Forms.TreeNode[] {
            treeNode20,
            treeNode21,
            treeNode22,
            treeNode23,
            treeNode24,
            treeNode25,
            treeNode26,
            treeNode27});
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.naloziToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noviNalogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noviRadniNalogGPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noviRadniNalogPPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spisakNalogaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.šifarnikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stanjeGotovihProizvodaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stanjePoluproizvodaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stanjeRepromaterijalaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.šifarnikToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.sastavnicaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sastavnicaPoluproizvodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proizvodiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gotoviProizvodiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.poluproizvodiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sirovineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.magacinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.magacinToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.spisakToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kupciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kupciToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bazaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateBazuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pakovanjeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pakovanjeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.spisakPakovanjaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vrsteKutijaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vrstaPaletaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.odgovorneOsobeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gPUKutijiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kutijeNaPaletiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paritetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.naloziToolStripMenuItem,
            this.šifarnikToolStripMenuItem,
            this.šifarnikToolStripMenuItem1,
            this.proizvodiToolStripMenuItem,
            this.magacinToolStripMenuItem,
            this.kupciToolStripMenuItem,
            this.bazaToolStripMenuItem,
            this.pakovanjeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1424, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // naloziToolStripMenuItem
            // 
            this.naloziToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noviNalogToolStripMenuItem,
            this.noviRadniNalogGPToolStripMenuItem,
            this.noviRadniNalogPPToolStripMenuItem,
            this.spisakNalogaToolStripMenuItem});
            this.naloziToolStripMenuItem.Name = "naloziToolStripMenuItem";
            this.naloziToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.naloziToolStripMenuItem.Text = "Nalozi";
            // 
            // noviNalogToolStripMenuItem
            // 
            this.noviNalogToolStripMenuItem.Name = "noviNalogToolStripMenuItem";
            this.noviNalogToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.noviNalogToolStripMenuItem.Text = "Novi Zahtev za proizvodnju";
            this.noviNalogToolStripMenuItem.Click += new System.EventHandler(this.noviNalogToolStripMenuItem_Click);
            // 
            // noviRadniNalogGPToolStripMenuItem
            // 
            this.noviRadniNalogGPToolStripMenuItem.Name = "noviRadniNalogGPToolStripMenuItem";
            this.noviRadniNalogGPToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.noviRadniNalogGPToolStripMenuItem.Text = "Novi radni nalog GP";
            this.noviRadniNalogGPToolStripMenuItem.Click += new System.EventHandler(this.noviRadniNalogGPToolStripMenuItem_Click);
            // 
            // noviRadniNalogPPToolStripMenuItem
            // 
            this.noviRadniNalogPPToolStripMenuItem.Name = "noviRadniNalogPPToolStripMenuItem";
            this.noviRadniNalogPPToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.noviRadniNalogPPToolStripMenuItem.Text = "Novi radni nalog PP";
            this.noviRadniNalogPPToolStripMenuItem.Click += new System.EventHandler(this.noviRadniNalogPPToolStripMenuItem_Click);
            // 
            // spisakNalogaToolStripMenuItem
            // 
            this.spisakNalogaToolStripMenuItem.Name = "spisakNalogaToolStripMenuItem";
            this.spisakNalogaToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.spisakNalogaToolStripMenuItem.Text = "Spisak Zahteva";
            this.spisakNalogaToolStripMenuItem.Click += new System.EventHandler(this.spisakNalogaToolStripMenuItem_Click);
            // 
            // šifarnikToolStripMenuItem
            // 
            this.šifarnikToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stanjeGotovihProizvodaToolStripMenuItem,
            this.stanjePoluproizvodaToolStripMenuItem,
            this.stanjeRepromaterijalaToolStripMenuItem});
            this.šifarnikToolStripMenuItem.Name = "šifarnikToolStripMenuItem";
            this.šifarnikToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.šifarnikToolStripMenuItem.Text = "Stanje";
            // 
            // stanjeGotovihProizvodaToolStripMenuItem
            // 
            this.stanjeGotovihProizvodaToolStripMenuItem.Name = "stanjeGotovihProizvodaToolStripMenuItem";
            this.stanjeGotovihProizvodaToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.stanjeGotovihProizvodaToolStripMenuItem.Text = "Stanje gotovih proizvoda";
            this.stanjeGotovihProizvodaToolStripMenuItem.Click += new System.EventHandler(this.stanjeGotovihProizvodaToolStripMenuItem_Click);
            // 
            // stanjePoluproizvodaToolStripMenuItem
            // 
            this.stanjePoluproizvodaToolStripMenuItem.Name = "stanjePoluproizvodaToolStripMenuItem";
            this.stanjePoluproizvodaToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.stanjePoluproizvodaToolStripMenuItem.Text = "Stanje poluproizvoda";
            this.stanjePoluproizvodaToolStripMenuItem.Click += new System.EventHandler(this.stanjePoluproizvodaToolStripMenuItem_Click);
            // 
            // stanjeRepromaterijalaToolStripMenuItem
            // 
            this.stanjeRepromaterijalaToolStripMenuItem.Name = "stanjeRepromaterijalaToolStripMenuItem";
            this.stanjeRepromaterijalaToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.stanjeRepromaterijalaToolStripMenuItem.Text = "Stanje repromaterijala";
            this.stanjeRepromaterijalaToolStripMenuItem.Visible = false;
            // 
            // šifarnikToolStripMenuItem1
            // 
            this.šifarnikToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sastavnicaToolStripMenuItem,
            this.sastavnicaPoluproizvodToolStripMenuItem});
            this.šifarnikToolStripMenuItem1.Name = "šifarnikToolStripMenuItem1";
            this.šifarnikToolStripMenuItem1.Size = new System.Drawing.Size(74, 20);
            this.šifarnikToolStripMenuItem1.Text = "Sastavnica";
            // 
            // sastavnicaToolStripMenuItem
            // 
            this.sastavnicaToolStripMenuItem.Name = "sastavnicaToolStripMenuItem";
            this.sastavnicaToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.sastavnicaToolStripMenuItem.Text = "Sastavnica gotov proizvod";
            this.sastavnicaToolStripMenuItem.Click += new System.EventHandler(this.sastavnicaToolStripMenuItem_Click);
            // 
            // sastavnicaPoluproizvodToolStripMenuItem
            // 
            this.sastavnicaPoluproizvodToolStripMenuItem.Name = "sastavnicaPoluproizvodToolStripMenuItem";
            this.sastavnicaPoluproizvodToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.sastavnicaPoluproizvodToolStripMenuItem.Text = "Sastavnica poluproizvod";
            this.sastavnicaPoluproizvodToolStripMenuItem.Click += new System.EventHandler(this.sastavnicaPoluproizvodToolStripMenuItem_Click);
            // 
            // proizvodiToolStripMenuItem
            // 
            this.proizvodiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gotoviProizvodiToolStripMenuItem,
            this.poluproizvodiToolStripMenuItem,
            this.sirovineToolStripMenuItem});
            this.proizvodiToolStripMenuItem.Name = "proizvodiToolStripMenuItem";
            this.proizvodiToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.proizvodiToolStripMenuItem.Text = "Proizvodi";
            // 
            // gotoviProizvodiToolStripMenuItem
            // 
            this.gotoviProizvodiToolStripMenuItem.Name = "gotoviProizvodiToolStripMenuItem";
            this.gotoviProizvodiToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.gotoviProizvodiToolStripMenuItem.Text = "Gotovi proizvodi";
            this.gotoviProizvodiToolStripMenuItem.Click += new System.EventHandler(this.gotoviProizvodiToolStripMenuItem_Click);
            // 
            // poluproizvodiToolStripMenuItem
            // 
            this.poluproizvodiToolStripMenuItem.Name = "poluproizvodiToolStripMenuItem";
            this.poluproizvodiToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.poluproizvodiToolStripMenuItem.Text = "Poluproizvodi";
            this.poluproizvodiToolStripMenuItem.Click += new System.EventHandler(this.poluproizvodiToolStripMenuItem_Click);
            // 
            // sirovineToolStripMenuItem
            // 
            this.sirovineToolStripMenuItem.Name = "sirovineToolStripMenuItem";
            this.sirovineToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.sirovineToolStripMenuItem.Text = "Sirovine";
            this.sirovineToolStripMenuItem.Click += new System.EventHandler(this.sirovineToolStripMenuItem_Click);
            // 
            // magacinToolStripMenuItem
            // 
            this.magacinToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.magacinToolStripMenuItem1,
            this.spisakToolStripMenuItem});
            this.magacinToolStripMenuItem.Name = "magacinToolStripMenuItem";
            this.magacinToolStripMenuItem.Size = new System.Drawing.Size(118, 20);
            this.magacinToolStripMenuItem.Text = "Realizovani zahtevi";
            // 
            // magacinToolStripMenuItem1
            // 
            this.magacinToolStripMenuItem1.Name = "magacinToolStripMenuItem1";
            this.magacinToolStripMenuItem1.Size = new System.Drawing.Size(120, 22);
            this.magacinToolStripMenuItem1.Text = "Magacin";
            this.magacinToolStripMenuItem1.Visible = false;
            this.magacinToolStripMenuItem1.Click += new System.EventHandler(this.magacinToolStripMenuItem1_Click);
            // 
            // spisakToolStripMenuItem
            // 
            this.spisakToolStripMenuItem.Name = "spisakToolStripMenuItem";
            this.spisakToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.spisakToolStripMenuItem.Text = "Spisak";
            this.spisakToolStripMenuItem.Click += new System.EventHandler(this.spisakToolStripMenuItem_Click);
            // 
            // kupciToolStripMenuItem
            // 
            this.kupciToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kupciToolStripMenuItem1});
            this.kupciToolStripMenuItem.Name = "kupciToolStripMenuItem";
            this.kupciToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.kupciToolStripMenuItem.Text = "Kupci";
            // 
            // kupciToolStripMenuItem1
            // 
            this.kupciToolStripMenuItem1.Name = "kupciToolStripMenuItem1";
            this.kupciToolStripMenuItem1.Size = new System.Drawing.Size(104, 22);
            this.kupciToolStripMenuItem1.Text = "Kupci";
            this.kupciToolStripMenuItem1.Click += new System.EventHandler(this.kupciToolStripMenuItem1_Click);
            // 
            // bazaToolStripMenuItem
            // 
            this.bazaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateBazuToolStripMenuItem,
            this.backupToolStripMenuItem});
            this.bazaToolStripMenuItem.Name = "bazaToolStripMenuItem";
            this.bazaToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.bazaToolStripMenuItem.Text = "baza";
            this.bazaToolStripMenuItem.Visible = false;
            // 
            // updateBazuToolStripMenuItem
            // 
            this.updateBazuToolStripMenuItem.Name = "updateBazuToolStripMenuItem";
            this.updateBazuToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.updateBazuToolStripMenuItem.Text = "update bazu";
            this.updateBazuToolStripMenuItem.Click += new System.EventHandler(this.updateBazuToolStripMenuItem_Click);
            // 
            // backupToolStripMenuItem
            // 
            this.backupToolStripMenuItem.Name = "backupToolStripMenuItem";
            this.backupToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.backupToolStripMenuItem.Text = "backup";
            this.backupToolStripMenuItem.Visible = false;
            this.backupToolStripMenuItem.Click += new System.EventHandler(this.backupToolStripMenuItem_Click);
            // 
            // pakovanjeToolStripMenuItem
            // 
            this.pakovanjeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pakovanjeToolStripMenuItem1,
            this.spisakPakovanjaToolStripMenuItem,
            this.vrsteKutijaToolStripMenuItem,
            this.vrstaPaletaToolStripMenuItem,
            this.odgovorneOsobeToolStripMenuItem,
            this.gPUKutijiToolStripMenuItem,
            this.kutijeNaPaletiToolStripMenuItem,
            this.paritetToolStripMenuItem});
            this.pakovanjeToolStripMenuItem.Name = "pakovanjeToolStripMenuItem";
            this.pakovanjeToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.pakovanjeToolStripMenuItem.Text = "Pakovanje";
            // 
            // pakovanjeToolStripMenuItem1
            // 
            this.pakovanjeToolStripMenuItem1.Name = "pakovanjeToolStripMenuItem1";
            this.pakovanjeToolStripMenuItem1.Size = new System.Drawing.Size(169, 22);
            this.pakovanjeToolStripMenuItem1.Text = "Pakovanje";
            this.pakovanjeToolStripMenuItem1.Click += new System.EventHandler(this.pakovanjeToolStripMenuItem1_Click);
            // 
            // spisakPakovanjaToolStripMenuItem
            // 
            this.spisakPakovanjaToolStripMenuItem.Name = "spisakPakovanjaToolStripMenuItem";
            this.spisakPakovanjaToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.spisakPakovanjaToolStripMenuItem.Text = "Spisak pakovanja";
            this.spisakPakovanjaToolStripMenuItem.Click += new System.EventHandler(this.spisakPakovanjaToolStripMenuItem_Click);
            // 
            // vrsteKutijaToolStripMenuItem
            // 
            this.vrsteKutijaToolStripMenuItem.Name = "vrsteKutijaToolStripMenuItem";
            this.vrsteKutijaToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.vrsteKutijaToolStripMenuItem.Text = "Vrste kutija";
            this.vrsteKutijaToolStripMenuItem.Click += new System.EventHandler(this.vrsteKutijaToolStripMenuItem_Click);
            // 
            // vrstaPaletaToolStripMenuItem
            // 
            this.vrstaPaletaToolStripMenuItem.Name = "vrstaPaletaToolStripMenuItem";
            this.vrstaPaletaToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.vrstaPaletaToolStripMenuItem.Text = "Vrsta paleta";
            this.vrstaPaletaToolStripMenuItem.Click += new System.EventHandler(this.vrstaPaletaToolStripMenuItem_Click);
            // 
            // odgovorneOsobeToolStripMenuItem
            // 
            this.odgovorneOsobeToolStripMenuItem.Name = "odgovorneOsobeToolStripMenuItem";
            this.odgovorneOsobeToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.odgovorneOsobeToolStripMenuItem.Text = "Odgovorne osobe";
            this.odgovorneOsobeToolStripMenuItem.Click += new System.EventHandler(this.odgovorneOsobeToolStripMenuItem_Click);
            // 
            // gPUKutijiToolStripMenuItem
            // 
            this.gPUKutijiToolStripMenuItem.Name = "gPUKutijiToolStripMenuItem";
            this.gPUKutijiToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.gPUKutijiToolStripMenuItem.Text = "GP u kutiji";
            this.gPUKutijiToolStripMenuItem.Click += new System.EventHandler(this.gPUKutijiToolStripMenuItem_Click);
            // 
            // kutijeNaPaletiToolStripMenuItem
            // 
            this.kutijeNaPaletiToolStripMenuItem.Name = "kutijeNaPaletiToolStripMenuItem";
            this.kutijeNaPaletiToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.kutijeNaPaletiToolStripMenuItem.Text = "Kutije na paleti";
            this.kutijeNaPaletiToolStripMenuItem.Click += new System.EventHandler(this.kutijeNaPaletiToolStripMenuItem_Click);
            // 
            // paritetToolStripMenuItem
            // 
            this.paritetToolStripMenuItem.Name = "paritetToolStripMenuItem";
            this.paritetToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.paritetToolStripMenuItem.Text = "Paritet";
            this.paritetToolStripMenuItem.Click += new System.EventHandler(this.paritetToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Location = new System.Drawing.Point(172, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(1252, 791);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.treeView1);
            this.groupBox2.Location = new System.Drawing.Point(0, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(166, 790);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.Location = new System.Drawing.Point(7, 11);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "NodeNoviNalog";
            treeNode1.Text = "Zahtev za proizvodnju";
            treeNode2.Name = "NodeNoviRNGP";
            treeNode2.Text = "Novi RN GP";
            treeNode3.Name = "NodeNoviRNPP";
            treeNode3.Text = "Novi RN PP";
            treeNode4.Name = "NodeSpisakNaloga";
            treeNode4.Text = "Spisak Zahteva";
            treeNode5.Name = "NodeNalozi";
            treeNode5.Text = "Nalozi";
            treeNode6.Name = "NodeStanjeGP";
            treeNode6.Text = "Stanje GP";
            treeNode7.Name = "NodeStanjePP";
            treeNode7.Text = "Stanje PP";
            treeNode8.Name = "NodeStanje";
            treeNode8.Text = "Stanje";
            treeNode9.Name = "NodeSastavnicaGP";
            treeNode9.Text = "Sastavnica gotov proizvod";
            treeNode10.Name = "NodeSastavnicaPP";
            treeNode10.Text = "Sastavnica poluproizvod";
            treeNode11.Name = "NodeSastavnica";
            treeNode11.Text = "Sastavnica";
            treeNode12.Name = "NodeGP";
            treeNode12.Text = "Gotovi proizvodi";
            treeNode13.Name = "NodePP";
            treeNode13.Text = "Poluproizvodi";
            treeNode14.Name = "NodeSirovine";
            treeNode14.Text = "Sirovine";
            treeNode15.Name = "NodeProizvodi";
            treeNode15.Text = "Proizvodi";
            treeNode16.Name = "NodeMagacinSpisak";
            treeNode16.Text = "Spisak";
            treeNode17.Name = "NodeMag";
            treeNode17.Text = "Realizovani zahtevi";
            treeNode18.Name = "NodeKupci";
            treeNode18.Text = "Kupci";
            treeNode19.Name = "NodeK";
            treeNode19.Text = "Kupci";
            treeNode20.Name = "NodePakovanje";
            treeNode20.Text = "Pakovanje";
            treeNode21.Name = "NodeSpisakPakovanja";
            treeNode21.Text = "Spisak Pakovanja";
            treeNode22.Name = "NodeKutije";
            treeNode22.Text = "Vrste kutija";
            treeNode23.Name = "NodePalete";
            treeNode23.Text = "Vrsta paleta";
            treeNode24.Name = "NodeOdgovorneOsobe";
            treeNode24.Text = "Odgovorne osobe";
            treeNode25.Name = "NodeGPKutija";
            treeNode25.Text = "GP u kutiji";
            treeNode26.Name = "NodeKutijaPaleta";
            treeNode26.Text = "Kutija na paleti";
            treeNode27.Name = "NodeParitet";
            treeNode27.Text = "Paritet";
            treeNode28.Name = "NodePak";
            treeNode28.Text = "Pakovanje";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode8,
            treeNode11,
            treeNode15,
            treeNode17,
            treeNode19,
            treeNode28});
            this.treeView1.Size = new System.Drawing.Size(153, 773);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 821);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1280, 858);
            this.Name = "Form1";
            this.Text = "Stanje proizvoda";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStripMenuItem naloziToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noviNalogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spisakNalogaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem šifarnikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stanjeGotovihProizvodaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stanjePoluproizvodaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stanjeRepromaterijalaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem šifarnikToolStripMenuItem1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ToolStripMenuItem noviRadniNalogGPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sastavnicaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sastavnicaPoluproizvodToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noviRadniNalogPPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proizvodiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gotoviProizvodiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem poluproizvodiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sirovineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bazaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateBazuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem magacinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem magacinToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem spisakToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kupciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kupciToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem backupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pakovanjeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pakovanjeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem vrsteKutijaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spisakPakovanjaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vrstaPaletaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem odgovorneOsobeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gPUKutijiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kutijeNaPaletiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paritetToolStripMenuItem;
    }
}

