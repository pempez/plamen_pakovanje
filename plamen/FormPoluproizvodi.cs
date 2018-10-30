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
    public partial class FormPoluproizvodi : Form
    {
        Metode metode = new Metode();
        public FormPoluproizvodi()
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
            DataTable dt = metode.baza_upit("SELECT id, Kod, Naziv,aktivan FROM  Poluproizvodi order by Kod");

            cbProizvodSifra.DataSource = dt;
            cbProizvodSifra.DisplayMember = "Kod";
            cbProizvodSifra.ValueMember = "id";
            cbProizvodSifra.SelectedIndex = -1;

            cmproizvodNaziv.DataSource = dt;
            cmproizvodNaziv.DisplayMember = "Naziv";
            cmproizvodNaziv.ValueMember = "id";
            cmproizvodNaziv.SelectedIndex = -1;
        }
        private void ucitaj()
        {
            string upit = "SELECT id, Kod, Naziv,aktivan FROM  Poluproizvodi ";

            if (radioButton1.Checked == true)
                upit += " where aktivan = 1";
            else if (radioButton2.Checked == true)
                upit += " where aktivan = 0";

            upit += " order by Kod";



            dataGridView1.DataSource = metode.baza_upit(upit);
            dataGridView1.Columns["id"].Visible = false;
            //  dataGridView1.Height = 202;

        }
        private void ucitaj(int id)
        {
            dataGridView1.DataSource = metode.baza_upit(" SELECT id, Kod, Naziv,aktivan FROM  Poluproizvodi where id = " + id + "");
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
            FormNoviPP f1 = new FormNoviPP();
            f1.ShowDialog();
            ucitaj();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = int.Parse(dataGridView1.CurrentRow.Cells["id"].Value.ToString());
            FormNoviPP f1 = new FormNoviPP(id);
            f1.ShowDialog();
          //  ucitaj(id);
            ucitaj();
        }
    }
}
