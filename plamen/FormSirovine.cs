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
    public partial class FormSirovine : Form
    {
        Metode metode = new Metode();
        public FormSirovine()
        {
            InitializeComponent();
            ucitaj();
        }

        public GroupBox GetGroupBox()
        {
            return groupBox1;
        }

        private void ucitaj()
        {
            string upit = "SELECT id,sifra, naziv, jedinicaMere, stanje FROM            Sirovina";
            DataTable dt = metode.baza_upit(upit);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["id"].Visible = false;

            cbSirovina.DataSource = dt;
            cbSirovina.DisplayMember = "naziv";
            cbSirovina.ValueMember = "id";

            cbSirovinaSifra.DataSource = dt;
            cbSirovinaSifra.DisplayMember = "sifra";
            cbSirovinaSifra.ValueMember = "id";

            cmproizvodNaziv.DataSource = dt;
            cmproizvodNaziv.DisplayMember = "naziv";
            cmproizvodNaziv.ValueMember = "id";

            cbProizvodSifra.DataSource = dt;
            cbProizvodSifra.DisplayMember = "sifra";
            cbProizvodSifra.ValueMember = "id";
        }

        private void btnNovi_Click(object sender, EventArgs e)
        {
            FormNovaSirovina f1 = new FormNovaSirovina();
            f1.ShowDialog();
            ucitaj();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FormNovaSirovina f1 = new FormNovaSirovina(int.Parse(dataGridView1.CurrentRow.Cells["id"].Value.ToString()));
            f1.ShowDialog();
            ucitaj();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbSirovina.SelectedValue = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
            tbKolicina.Text = dataGridView1.CurrentRow.Cells["stanje"].Value.ToString();
        }

        private void btnUnesi_Click(object sender, EventArgs e)
        {
            string update = " update Sirovina set  stanje = stanje + '" + tbKolicina.Text.Replace(",", ".") + "' where id = " + cbSirovina.SelectedValue + "" +
                " INSERT INTO  SirovinaUnos(idSirovina, kolicina, datumUnosa, napomena) "+
                " VALUES        (" + cbSirovina.SelectedValue + ",'" + tbKolicina.Text.Replace(",", ".") + "', getdate() ,'" + tbNapomena.Text + "') ";
            metode.pristup_bazi(update);

            ucitaj();
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

        private void ucitaj(int id)
        {
            dataGridView1.DataSource = metode.baza_upit(" SELECT       id, naziv,sifra, jedinicaMere, stanje " +
                            " FROM            Sirovina "+
                            " WHERE        id =  " + id + "");
            dataGridView1.Columns["id"].Visible = false;
            //  dataGridView1.Height = 45;
        }
      
    }
}
