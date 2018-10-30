using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace plamen
{
    public partial class FormGotoviProizvodi : Form
    {
        Metode metode = new Metode();

        public FormGotoviProizvodi()
        {
            InitializeComponent();
            ucitajProizvode();
            ucitaj();
        }

        public GroupBox GetGroupBox()
        {
            return groupBox1;
        }
        private void ucitajProizvode()
        {
            DataTable dt = metode.baza_upit("SELECT   id, Sifra, Naziv,EngleskiNaziv as [engleski naziv], masa, aktivan FROM  GotovProizvod  order by sifra");

            cbProizvodSifra.DataSource = dt;
            cbProizvodSifra.DisplayMember = "Sifra";
            cbProizvodSifra.ValueMember = "id";
            cbProizvodSifra.SelectedIndex = -1;

            cmproizvodNaziv.DataSource = dt;
            cmproizvodNaziv.DisplayMember = "Naziv";
            cmproizvodNaziv.ValueMember = "id";
            cmproizvodNaziv.SelectedIndex = -1;
        }
        private void ucitaj()
        {
            string upit = "SELECT        dbo.GotovProizvod.id, dbo.GotovProizvod.Sifra, dbo.GotovProizvod.Naziv, dbo.GotovProizvod.EngleskiNaziv as [engleski naziv], dbo.GotovProizvod.masa, ISNULL(dbo.potraznjaGP.Potraznja, 0) AS potraznja, dbo.GotovProizvod.Aktivan " +
                            " FROM            dbo.GotovProizvod LEFT OUTER JOIN " +
                        " dbo.potraznjaGP ON dbo.GotovProizvod.id = dbo.potraznjaGP.idProizvod  ";
            
            if(radioButton1.Checked==true)
               upit += " where aktivan = 1";
            else if(radioButton2.Checked==true)
                upit += " where aktivan = 0";

            upit += " order by sifra";
           


            dataGridView1.DataSource = metode.baza_upit(upit);
            dataGridView1.Columns["id"].Visible = false;
          //  dataGridView1.Height = 202;

        }
        private void ucitaj(int id)
        {
            dataGridView1.DataSource = metode.baza_upit(" SELECT        dbo.GotovProizvod.id, dbo.GotovProizvod.Sifra, dbo.GotovProizvod.Naziv, ISNULL(dbo.potraznjaGP.Potraznja, 0) AS potraznja, dbo.GotovProizvod.Aktivan " +
                            " FROM            dbo.GotovProizvod LEFT OUTER JOIN " +
                        " dbo.potraznjaGP ON dbo.GotovProizvod.id = dbo.potraznjaGP.idProizvod where dbo.GotovProizvod.id = " + id + "");
            dataGridView1.Columns["id"].Visible = false;
          //  dataGridView1.Height = 45;
        }

        private void btnNoviRNGP_Click(object sender, EventArgs e)
        {
            int idProizvod = int.Parse(dataGridView1.CurrentRow.Cells["id"].Value.ToString());
            FormRNGP rn = new FormRNGP(idProizvod);
            rn.ShowDialog();
        }

        private void btnPretrazi_Click(object sender, EventArgs e)
        {
            if (cbProizvodSifra.Text == "")
            {
                ucitaj();
            }
            else
            {
                ucitaj(int.Parse(cbProizvodSifra.SelectedValue.ToString()));
            }
        }

        private void cbProizvodSifra_Leave(object sender, EventArgs e)
        {
            if (cbProizvodSifra.Text == "")
                cmproizvodNaziv.Text = "";
        }

        private void cmproizvodNaziv_Leave(object sender, EventArgs e)
        {
            if (cmproizvodNaziv.Text == "")
                cbProizvodSifra.Text = "";
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            ucitaj();
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            ucitaj();
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            ucitaj();
        }

        private void btnNovi_Click(object sender, EventArgs e)
        {
            FormNoviProizvod f1 = new FormNoviProizvod();
            f1.ShowDialog();
            ucitaj();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id= int.Parse(dataGridView1.CurrentRow.Cells["id"].Value.ToString());
            FormNoviProizvod f1 = new FormNoviProizvod(id);
            f1.ShowDialog();
            ucitaj();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            FormGPuKutiji f1 = new FormGPuKutiji(int.Parse(dataGridView1.CurrentRow.Cells["id"].Value.ToString()));
            this.groupBox2.Controls.Clear();
            this.groupBox2.Controls.Add(f1.GetGroupBox());
            f1.GetGroupBox().Dock = DockStyle.Top;
            f1.GetGroupBox().Show();
        }
    }
}
