using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;




using System.Data.SqlClient;
using System.IO;
using System.Threading;
using System.Globalization;

using System.Net;
using System.Net.Mail;
using System.IO.Compression;

namespace plamen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        

            this.WindowState = FormWindowState.Maximized;
        }

        private void stanjeGotovihProizvodaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormStanje f1 = new FormStanje();
            this.groupBox1.Controls.Clear();
            this.groupBox1.Controls.Add(f1.GetGroupBox());
            f1.GetGroupBox().Dock = DockStyle.Fill;
            f1.GetGroupBox().Show();
        }

        private void noviNalogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNoviNalog f1 = new FormNoviNalog();
            this.groupBox1.Controls.Clear();
            this.groupBox1.Controls.Add(f1.GetGroupBox());
            f1.GetGroupBox().Dock = DockStyle.Fill;
            f1.GetGroupBox().Show();
        }

        private void stanjePoluproizvodaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormStanjePP f1 = new FormStanjePP();
            this.groupBox1.Controls.Clear();
            this.groupBox1.Controls.Add(f1.GetGroupBox());
            f1.GetGroupBox().Dock = DockStyle.Fill;
            f1.GetGroupBox().Show();
        }

        private void noviRadniNalogGPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRNGP f1 = new FormRNGP();
            this.groupBox1.Controls.Clear();
            this.groupBox1.Controls.Add(f1.GetGroupBox());
            f1.GetGroupBox().Dock = DockStyle.Fill;
            f1.GetGroupBox().Show();
        }

        private void sastavnicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSastavnica f1 = new FormSastavnica();
            this.groupBox1.Controls.Clear();
            this.groupBox1.Controls.Add(f1.GetGroupBox());
            f1.GetGroupBox().Dock = DockStyle.Fill;
            f1.GetGroupBox().Show();
        }

        private void noviRadniNalogPPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRNPP f1 = new FormRNPP();
            this.groupBox1.Controls.Clear();
            this.groupBox1.Controls.Add(f1.GetGroupBox());
            f1.GetGroupBox().Dock = DockStyle.Fill;
            f1.GetGroupBox().Show();
        }

        private void spisakNalogaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSpisakNaloga f1 = new FormSpisakNaloga();
            this.groupBox1.Controls.Clear();
            this.groupBox1.Controls.Add(f1.GetGroupBox());
            f1.GetGroupBox().Dock = DockStyle.Fill;
            f1.GetGroupBox().Show();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = ((TreeView)sender).SelectedNode;
            switch (node.Name)
            {
                case "NodeNalozi":
                    node.Expand();
                    break;
                case "NodeStanje":
                    node.Expand();
                    break;
                case "NodeSastavnica":
                    node.Expand();
                    break;
                case "NodeNoviNalog":
                    noviNalogToolStripMenuItem_Click(null, null);
                    break;
                case "NodeNoviRNGP":
                    noviRadniNalogGPToolStripMenuItem_Click(null, null);
                    break;
                case "NodeNoviRNPP":
                    noviRadniNalogPPToolStripMenuItem_Click(null, null);
                    break;
                case "NodeStanjeGP":
                    stanjeGotovihProizvodaToolStripMenuItem_Click(null, null);
                    break;
                case "NodeStanjePP":
                    stanjePoluproizvodaToolStripMenuItem_Click(null, null);
                    break;
                case "NodeSastavnicaGP":
                    sastavnicaToolStripMenuItem_Click(null, null);
                    break;
                case "NodeSpisakNaloga":
                    spisakNalogaToolStripMenuItem_Click(null, null);
                    break;
                case "NodeGP":
                    gotoviProizvodiToolStripMenuItem_Click(null, null);
                    break;
                case "NodePP":
                    poluproizvodiToolStripMenuItem_Click(null, null);
                    break;
                case "NodeMagacin":
                    // magacinToolStripMenuItem1_Click(null, null);
                    break;
                case "NodeMagacinSpisak":
                    spisakToolStripMenuItem_Click(null, null);
                    break;
                case "NodeKupci":
                    kupciToolStripMenuItem1_Click(null, null);
                    break;
                case "NodeSirovine":
                    sirovineToolStripMenuItem_Click(null, null);
                    break;
                case "NodeSastavnicaPP":
                    sastavnicaPoluproizvodToolStripMenuItem_Click(null, null);
                    break;
                case "NodePakovanje":
                    pakovanjeToolStripMenuItem1_Click(null, null);
                    break;
                case "NodeSpisakPakovanja":
                    spisakPakovanjaToolStripMenuItem_Click(null, null);
                    break;
                case "NodeKutije":
                    vrsteKutijaToolStripMenuItem_Click(null, null);
                    break;
                case "NodePalete":
                    vrstaPaletaToolStripMenuItem_Click(null, null);
                    break;
                case "NodeOdgovorneOsobe":
                    odgovorneOsobeToolStripMenuItem_Click(null, null);
                    break;
                case "NodeGPKutija":
                    gPUKutijiToolStripMenuItem_Click(null, null);
                    break;
                case "NodeKutijaPaleta":
                    kutijeNaPaletiToolStripMenuItem_Click(null, null);
                    break;
                case "NodeParitet":
                    paritetToolStripMenuItem_Click(null, null);
                    break;
            }
        }

        private void gotoviProizvodiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGotoviProizvodi f1 = new FormGotoviProizvodi();
            this.groupBox1.Controls.Clear();
            this.groupBox1.Controls.Add(f1.GetGroupBox());
            f1.GetGroupBox().Dock = DockStyle.Fill;
            f1.GetGroupBox().Show();
        }

        private void poluproizvodiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPoluproizvodi f1 = new FormPoluproizvodi();
            this.groupBox1.Controls.Clear();
            this.groupBox1.Controls.Add(f1.GetGroupBox());
            f1.GetGroupBox().Dock = DockStyle.Fill;
            f1.GetGroupBox().Show();
        }

        private void updateBazuToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //  backupToolStripMenuItem_Click(null,null);
            FormRestoreDB f1 = new FormRestoreDB();
            f1.Show();
        }

        private void magacinToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormMagacin f1 = new FormMagacin();
            this.groupBox1.Controls.Clear();
            this.groupBox1.Controls.Add(f1.GetGroupBox());
            f1.GetGroupBox().Dock = DockStyle.Fill;
            f1.GetGroupBox().Show();
        }

        private void spisakToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSpisakMagacin f1 = new FormSpisakMagacin();
            this.groupBox1.Controls.Clear();
            this.groupBox1.Controls.Add(f1.GetGroupBox());
            f1.GetGroupBox().Dock = DockStyle.Fill;
            f1.GetGroupBox().Show();
        }

        private void kupciToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormKupci f1 = new FormKupci();
            this.groupBox1.Controls.Clear();
            this.groupBox1.Controls.Add(f1.GetGroupBox());
            f1.GetGroupBox().Dock = DockStyle.Fill;
            f1.GetGroupBox().Show();
        }

        private void sastavnicaPoluproizvodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSastavnicaPPSirovina f1 = new FormSastavnicaPPSirovina();
            this.groupBox1.Controls.Clear();
            this.groupBox1.Controls.Add(f1.GetGroupBox());
            f1.GetGroupBox().Dock = DockStyle.Fill;
            f1.GetGroupBox().Show();
        }

        private void sirovineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSirovine f1 = new FormSirovine();
            this.groupBox1.Controls.Clear();
            this.groupBox1.Controls.Add(f1.GetGroupBox());
            f1.GetGroupBox().Dock = DockStyle.Fill;
            f1.GetGroupBox().Show();
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string server = "c:\\BackupIT\\";
            //string server = @"\\192.168.0.22\BackupIT\";

            string connection = "";
            TextReader tr = new StreamReader("c:\\Program files\\IT\\Plamen\\conn.txt");
            connection = tr.ReadLine();
            tr.Close();

            DateTime god = DateTime.Now;

            //string godina = god.Year.ToString();
            string godina = "plamen";

            string query = "backup database  [plamen] to disk='"+server+"" + DateTime.Now.ToString("ddMMyyyy_HHmmss") + "_" + godina + ".bak'";
           
            ////putanja za zip-ovanje
            //string bazaTekuce = query.Substring(35, 36);

            ///////putanja do .bak 
            //string bazaTekuceCopy = query.Substring(47, 25);

            SqlConnection myConnection = new SqlConnection(connection);
            myConnection.Open();
            SqlCommand myCommand_table = new SqlCommand(query, myConnection);
            myCommand_table.ExecuteNonQuery();
            myConnection.Close();
        }

        private void pakovanjeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormPackingList f1 = new FormPackingList();
            this.groupBox1.Controls.Clear();
            this.groupBox1.Controls.Add(f1.GetGroupBox());
            f1.GetGroupBox().Dock = DockStyle.Fill;
            f1.GetGroupBox().Show();
        }

        private void vrsteKutijaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormVrstaKutija f1 = new FormVrstaKutija();
            this.groupBox1.Controls.Clear();
            this.groupBox1.Controls.Add(f1.GetGroupBox());
            f1.GetGroupBox().Dock = DockStyle.Fill;
            f1.GetGroupBox().Show();
        }

        private void spisakPakovanjaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormSpisakPakovanja f1 = new FormSpisakPakovanja();
            this.groupBox1.Controls.Clear();
            this.groupBox1.Controls.Add(f1.GetGroupBox());
            f1.GetGroupBox().Dock = DockStyle.Fill;
            f1.GetGroupBox().Show();
        }

        private void vrstaPaletaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormVrstaPaleta f1 = new FormVrstaPaleta();
            this.groupBox1.Controls.Clear();
            this.groupBox1.Controls.Add(f1.GetGroupBox());
            f1.GetGroupBox().Dock = DockStyle.Fill;
            f1.GetGroupBox().Show();
        }

        private void odgovorneOsobeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormOdgovorneOsobe f1= new FormOdgovorneOsobe();
            this.groupBox1.Controls.Clear();
            this.groupBox1.Controls.Add(f1.GetGroupBox());
            f1.GetGroupBox().Dock = DockStyle.Fill;
            f1.GetGroupBox().Show();
        }

        private void gPUKutijiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormGPuKutiji f1 = new FormGPuKutiji();
            f1.ShowDialog();
        }

        private void kutijeNaPaletiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormKutijaNaPaleti f1 = new FormKutijaNaPaleti();
            f1.ShowDialog();
        }

        private void paritetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormParitet f1 = new FormParitet();
            f1.ShowDialog();
        }
    }
}
