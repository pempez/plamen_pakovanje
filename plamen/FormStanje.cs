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
    public partial class FormStanje : Form
    {
        Metode metode = new Metode();
        public FormStanje()
        {
            InitializeComponent();
            ucitajProizvode();
            ucitaj();
        }

        public FormStanje(int idGotovProizvod)
        {
            InitializeComponent();

            ucitaj(idGotovProizvod);
            label3.Visible = false;
            cbProizvodSifra.Visible = false;
            cmproizvodNaziv.Visible = false;
            btnPretrazi.Visible = false;

        }

        public GroupBox GetGroupBox()
        {
            return groupBox1;
        }
        private void ucitajProizvode()
        {
            DataTable dt = metode.baza_upit("SELECT       id, Sifra, Naziv FROM            GotovProizvod where aktivan=1 order by sifra");

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
            dataGridView1.DataSource = metode.baza_upit(" SELECT id, Sifra, Naziv, Stanje, uproizvodnji as [u proizvodnji], Rezervisano, stanje - rezervisano as Raspolozivo FROM GotovProizvod where aktivan = 1 order by sifra");
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Height = 202;

        }
        private void ucitaj(int id)
        {
            dataGridView1.DataSource = metode.baza_upit(" SELECT id, Sifra, Naziv, Stanje,  uproizvodnji as [u proizvodnji], Rezervisano, stanje - rezervisano as Raspolozivo FROM GotovProizvod where id = " + id + "");
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Height = 75;
        }

        private void btnNoviRNGP_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Da li ste sigurni da zelite napraviti novi Nalog za GP", "Upozorenje", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
                int idProizvod = int.Parse(dataGridView1.CurrentRow.Cells["id"].Value.ToString());
                FormRNGP rn = new FormRNGP(idProizvod);
                rn.ShowDialog();
            }
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
            {
                cmproizvodNaziv.Text = "";
                ucitaj();
            }
        }

        private void cmproizvodNaziv_Leave(object sender, EventArgs e)
        {
            if (cmproizvodNaziv.Text == "")
            {
                cbProizvodSifra.Text = "";
                ucitaj();
            }
        }

        private void cbProizvodSifra_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ucitaj(int.Parse(cbProizvodSifra.SelectedValue.ToString()));
            }
            catch { }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            string selectRNGP = "SELECT        dbo.RadniNalogGP.broj,  dbo.RadniNalogGP.datum,  dbo.RadniNalogGP.rok, dbo.RadniNalogGP.napomena, dbo.SIF_Status.status, dbo.StavkeRNGP.kolicina, dbo.StavkeRNGP.rezervisano, dbo.StavkeRNGP.napravljeno, dbo.StavkeRNGP.idRNGP " +
                             " FROM            dbo.StavkeRNGP INNER JOIN  dbo.RadniNalogGP ON dbo.StavkeRNGP.idRNGP = dbo.RadniNalogGP.id inner join" +
                              "  dbo.SIF_Status ON dbo.RadniNalogGP.status = dbo.SIF_Status.id " +
                             " WHERE        (dbo.StavkeRNGP.idProizvod = " + int.Parse(dataGridView1.CurrentRow.Cells["id"].Value.ToString()) + ")";
            dgvSpisakRN.DataSource = metode.baza_upit(selectRNGP);
            dgvSpisakRN.Columns["idRNGP"].Visible = false;

            string selectNalog = "SELECT        dbo.Nalog.broj, dbo.Nalog.datum, dbo.Nalog.rok, dbo.Nalog.napomena, dbo.SIF_Status.status,  dbo.Nalog.id, dbo.KOMITENTI.SifraKomitenta + ' ' + dbo.KOMITENTI.Prezime AS Kupac " +
                                     " FROM            dbo.Nalog INNER JOIN "+
                       "   dbo.StavkeNaloga ON dbo.Nalog.id = dbo.StavkeNaloga.idNalog INNER JOIN "+
                        "  dbo.SIF_Status ON dbo.Nalog.Status = dbo.SIF_Status.id  INNER JOIN "+
                        " dbo.KOMITENTI ON dbo.Nalog.idKupac = dbo.KOMITENTI.ID_KOMITENTA "+
                            " WHERE        (dbo.StavkeNaloga.idProizvod = " + int.Parse(dataGridView1.CurrentRow.Cells["id"].Value.ToString()) + ")";

            dgvSpisakNaloga.DataSource = metode.baza_upit(selectNalog);
            dgvSpisakNaloga.Columns["id"].Visible = false;
        }

        private void dgvSpisakNaloga_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FormNoviNalog f1 = new FormNoviNalog(dgvSpisakNaloga.CurrentRow.Cells["id"].Value.ToString());
            f1.ShowDialog();
        }

        private void dgvSpisakRN_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FormRNGP f1 = new FormRNGP(dgvSpisakRN.CurrentRow.Cells["idRNGP"].Value.ToString());
            f1.ShowDialog();
        }



    }
}
