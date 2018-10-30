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
    public partial class FormKupci : Form
    {
        Metode metode = new Metode();
        public FormKupci()
        {
            InitializeComponent();
            ucitajKupce();
        }

        public GroupBox GetGroupBox()
        {
            return groupBox1;
        }

        private void ucitajKupce()
        {
            dataGridView1.DataSource = metode.baza_upit("SELECT         ID_KOMITENTA, SifraKomitenta as Sifra ,  Prezime as Naziv , OPSTINA, MESTO, ULICA, BROJ,drzava FROM            KOMITENTI");
            dataGridView1.Columns[0].Visible = false;
        }

        private void ucitajKupce(string naziv)
        {
            dataGridView1.DataSource = metode.baza_upit("SELECT         ID_KOMITENTA, SifraKomitenta as Sifra ,  Prezime as Naziv  , OPSTINA, MESTO, ULICA, BROJ ,drzava    FROM      KOMITENTI where prezime like N'%" + naziv + "%'");
            dataGridView1.Columns[0].Visible = false;
        }

        private void btnPronadji_Click(object sender, EventArgs e)
        {
            if (txtNaziv.Text == "")
            {
                ucitajKupce();
            }
            else
            {
                ucitajKupce(txtNaziv.Text);
            }
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            metode.pristup_bazi(" delete from komitenti where id_komitenta = '" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'");
            ucitajKupce();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            FormDodavanjeKomitenta f1 = new FormDodavanjeKomitenta();
            f1.ShowDialog();
            ucitajKupce();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FormDodavanjeKomitenta f1 = new FormDodavanjeKomitenta(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));
            f1.ShowDialog();
            ucitajKupce();
        }
    }
}
