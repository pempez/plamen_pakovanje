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
    public partial class FormOdgovorneOsobe : Form
    {
        Metode metode = new Metode();
        public FormOdgovorneOsobe()
        {
            InitializeComponent();
            ucitajOsobe();

        }

        private void btnUnesi_Click(object sender, EventArgs e)
        {
            string qUnesi = "INSERT INTO  PAK_ODGOVORNA_OSOBA( ime, prezime,aktiv, pozicija)" +
                           " VALUES        (N'" + tbIme.Text + "',N'" + tbPrezime.Text + "',1, N'"+tbPozicija.Text+"')";
            metode.pristup_bazi(qUnesi);
            ucitajOsobe();
        }

        public GroupBox GetGroupBox()
        {
            return groupBox1;
        }

        private void ucitajOsobe()
        {
            DataTable dt = metode.baza_upit(" select id, ime, prezime, pozicija, aktiv from   PAK_ODGOVORNA_OSOBA");

            dataGridView1.DataSource = dt;
            dataGridView1.Columns["id"].Visible = false;

        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            string qUnesi = "update PAK_ODGOVORNA_OSOBA set   pozicija=N'" + tbPozicija.Text + "', ime=N'" + tbIme.Text + "', prezime=N'" + tbPrezime.Text + "'" +
                " where id = " + dataGridView1.CurrentRow.Cells["id"].Value.ToString() + "";

            metode.pristup_bazi(qUnesi);
            ucitajOsobe();
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            string qUnesi = " update  PAK_ODGOVORNA_OSOBA set aktiv=0 " +
                       " where id = " + dataGridView1.CurrentRow.Cells["id"].Value.ToString() + "";

            metode.pristup_bazi(qUnesi);
            ucitajOsobe();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                btnIzmeni.Enabled = true;
                tbIme.Text = dataGridView1.CurrentRow.Cells["ime"].Value.ToString();
                tbPrezime.Text = dataGridView1.CurrentRow.Cells["prezime"].Value.ToString();
                tbPozicija.Text = dataGridView1.CurrentRow.Cells["pozicija"].Value.ToString();
              
            }
        }
    }
}
