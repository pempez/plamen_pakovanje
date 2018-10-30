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
    public partial class FormSastavnicaPPSirovina : Form
    {
        Metode metode = new Metode();

        public FormSastavnicaPPSirovina()
        {
            InitializeComponent();
            ucitajPP();
            ucitajSirovine();
            ucitajGPSastavnica();
            ucitajPPSastavnica();
            dataGridView1.DataSource = null;
            dgvPP.DataSource = null;
            dgvGPSastavnica.DataSource = null;
            this.WindowState = FormWindowState.Maximized;

        }

        public FormSastavnicaPPSirovina(string idPP)
        {
            InitializeComponent();
            ucitajPP();
            ucitajSirovine();
            ucitajGPSastavnica();
            ucitajPPSastavnica();
            dataGridView1.DataSource = null;
            cbProizvodSifra.SelectedValue=idPP;
            cbProizvodNaziv.SelectedValue = idPP;
            ucitajSastavnicu(int.Parse(idPP));
            this.WindowState = FormWindowState.Maximized;
        }

        public GroupBox GetGroupBox()
        {
            return groupBox1;
        }

        private void ucitajSirovine()
        {
            DataTable dt = metode.baza_upit("SELECT        id, naziv, jedinicaMere, stanje, sifra FROM            Sirovina  where aktivan=1  order by naziv");

            cbPPSif.DataSource = dt;
            cbPPSif.DisplayMember = "sifra";
            cbPPSif.ValueMember = "id";
            cbPPSif.SelectedIndex = -1;

            cbPPnaziv.DataSource = dt;
            cbPPnaziv.DisplayMember = "Naziv";
            cbPPnaziv.ValueMember = "id";
            cbPPnaziv.SelectedIndex = -1;
        }

        private void ucitajPP()
        {
            DataTable dt = metode.baza_upit("SELECT    id, Kod, Naziv, Uputstvo, Telo, Guma, Cesalj, Plocica, stanje FROM            Poluproizvodi  where aktivan=1  order by naziv");

            cbProizvodSifra.DataSource = dt;
            cbProizvodSifra.DisplayMember = "Kod";
            cbProizvodSifra.ValueMember = "id";
            cbProizvodSifra.SelectedIndex = -1;

            cbProizvodNaziv.DataSource = dt;
            cbProizvodNaziv.DisplayMember = "Naziv";
            cbProizvodNaziv.ValueMember = "id";
            cbProizvodNaziv.SelectedIndex = -1;
        }

        private void ucitajPPSastavnica()
        {
            DataTable dt = metode.baza_upit("SELECT    id, Kod, Naziv, Uputstvo, Telo, Guma, Cesalj, Plocica, stanje FROM            Poluproizvodi  where aktivan=1  order by naziv");

            cbPPSastavnicaSifra.DataSource = dt;
            cbPPSastavnicaSifra.DisplayMember = "Kod";
            cbPPSastavnicaSifra.ValueMember = "id";
            cbPPSastavnicaSifra.SelectedIndex = -1;

            cbPPSastavnicaNaziv.DataSource = dt;
            cbPPSastavnicaNaziv.DisplayMember = "Naziv";
            cbPPSastavnicaNaziv.ValueMember = "id";
            cbPPSastavnicaNaziv.SelectedIndex = -1;
        }

        private void ucitajGPSastavnica()
        {
            DataTable dt = metode.baza_upit("SELECT       id, Sifra, Naziv FROM            GotovProizvod where aktivan=1 order by naziv");

            cbGPSastavnicaSifra.DataSource = dt;
            cbGPSastavnicaSifra.DisplayMember = "Sifra";
            cbGPSastavnicaSifra.ValueMember = "id";
            cbGPSastavnicaSifra.SelectedIndex = -1;

            cbGPSastavnicaNaziv.DataSource = dt;
            cbGPSastavnicaNaziv.DisplayMember = "Naziv";
            cbGPSastavnicaNaziv.ValueMember = "id";
            cbGPSastavnicaNaziv.SelectedIndex = -1;
        }

        private void ucitajSastavnicu(int idGP)
        {
            //za sirovine
            DataTable dt = metode.baza_upit("SELECT        dbo.Sirovina.id,  dbo.sastavnicaPP_sirovina.id as idSas , dbo.Sirovina.naziv , dbo.sastavnicaPP_sirovina.kolicinaSirovine as Kolicina, dbo.Sirovina.jedinicaMere " +
                            " FROM            dbo.sastavnicaPP_sirovina INNER JOIN " +
                          " dbo.Poluproizvodi ON dbo.sastavnicaPP_sirovina.idpoluprozivod = dbo.Poluproizvodi.id INNER JOIN " +
                         " dbo.Sirovina ON dbo.sastavnicaPP_sirovina.idSirovina = dbo.Sirovina.id " +
                                            " WHERE        (dbo.Poluproizvodi.id = " + idGP + ")");
            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;

                dataGridView1.Columns["id"].Visible = false;
                dataGridView1.Columns["idSas"].Visible = false;

            }
            else
            {
                dataGridView1.DataSource = null;
                tbKolicina.Text = "";
                btnIzmeniStavku.Enabled = false;
                btnUnesiStavku.Enabled = true;
                btnObrisi.Enabled = false;
            }

            //za pp
            DataTable dtpp = metode.baza_upit("SELECT        Poluproizvodi_1.id AS idPP, Poluproizvodi_1.Kod, Poluproizvodi_1.Naziv, dbo.sastavnicaPP_PP.id AS idSast, dbo.sastavnicaPP_PP.kolicina "+
                                        " FROM            dbo.Poluproizvodi INNER JOIN  dbo.sastavnicaPP_PP ON dbo.Poluproizvodi.id = dbo.sastavnicaPP_PP.idpoluprozivod INNER JOIN "+
                                    "  dbo.Poluproizvodi AS Poluproizvodi_1 ON dbo.sastavnicaPP_PP.idPP = Poluproizvodi_1.id"+
                                    " WHERE        (dbo.Poluproizvodi.id = " + idGP + ")");
            if (dtpp.Rows.Count > 0)
            {
                dgvPP.DataSource = dtpp;

                dgvPP.Columns["idSast"].Visible = false;
                dgvPP.Columns["idPP"].Visible = false;

            }
            else
            {
                dgvPP.DataSource = null;
            }

            //za gotov proizvod
            DataTable dtGP = metode.baza_upit("SELECT        dbo.GotovProizvod.Sifra, dbo.GotovProizvod.Naziv, dbo.sastavnicaPP_GP.id AS idSast, dbo.sastavnicaPP_GP.kolicina, dbo.GotovProizvod.id AS idGP "+
                                              " FROM            dbo.Poluproizvodi INNER JOIN  dbo.sastavnicaPP_GP ON dbo.Poluproizvodi.id = dbo.sastavnicaPP_GP.idpoluprozivod INNER JOIN "+
                        "  dbo.GotovProizvod ON dbo.sastavnicaPP_GP.idGP = dbo.GotovProizvod.id"+
                            " WHERE        (dbo.Poluproizvodi.id = " + idGP + ")");
            if (dtGP.Rows.Count > 0)
            {
                dgvGPSastavnica.DataSource = dtGP;

                dgvGPSastavnica.Columns["idSast"].Visible = false;
                dgvGPSastavnica.Columns["idGP"].Visible = false;

            }
            else
            {
                dgvGPSastavnica.DataSource = null;
            }
        }

        private void cbProizvodSifra_Leave(object sender, EventArgs e)
        {
            try
            {
                cbProizvodNaziv.SelectedValue = cbProizvodSifra.SelectedValue;
            }
            catch { }
        }

        private void cbProizvodNaziv_Leave(object sender, EventArgs e)
        {
            try
            {
                cbProizvodSifra.SelectedValue = cbProizvodNaziv.SelectedValue;
            }
            catch { }
        }

        private void cbPPSif_Leave(object sender, EventArgs e)
        {
            try
            {
                cbPPnaziv.SelectedValue = cbPPSif.SelectedValue;
            }
            catch { }
        }

        private void cbPPnaziv_Leave(object sender, EventArgs e)
        {
            try
            {
                cbPPSif.SelectedValue = cbPPnaziv.SelectedValue;
            }
            catch { }
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            metode.pristup_bazi("DELETE FROM  sastavnicaPP_sirovina WHERE        (idpoluprozivod =" + cbProizvodSifra.SelectedValue + ") AND (idSirovina = " + cbPPSif.SelectedValue + ") ");
            ucitajSastavnicu(int.Parse(cbProizvodSifra.SelectedValue.ToString()));
        }

        private void btnNovaStavka_Click(object sender, EventArgs e)
        {
            btnIzmeniStavku.Enabled = false;
            btnUnesiStavku.Enabled = true;
            tbKolicina.Text = "0";
            cbPPSif.SelectedValue = "0";
            cbPPnaziv.SelectedValue = "0";
        }

        private void btnUnesiStavku_Click(object sender, EventArgs e)
        {
            string insert = "INSERT INTO  sastavnicaPP_sirovina(idpoluprozivod, idSirovina, kolicinaSirovine) " +
                           " VALUES        (" + cbProizvodSifra.SelectedValue + "," + cbPPSif.SelectedValue + ",N'" + tbKolicina.Text.Replace(",",".") + "')";
            metode.pristup_bazi(insert);
            ucitajSastavnicu(int.Parse(cbProizvodSifra.SelectedValue.ToString()));
        }

        private void btnIzmeniStavku_Click(object sender, EventArgs e)
        {
            int idSasta = int.Parse(dataGridView1.CurrentRow.Cells["idSas"].Value.ToString());

            string update = "UPDATE  sastavnicaPP_sirovina SET   idSirovina = " + cbPPSif.SelectedValue + ", kolicinaSirovine = N'" + tbKolicina.Text.Replace(",", ".") + "' " +
                            " WHERE        (id = " + idSasta + ")";
            metode.pristup_bazi(update);

            ucitajSastavnicu(int.Parse(cbProizvodSifra.SelectedValue.ToString()));
        }

        private void cbProizvodSifra_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                ucitajSastavnicu(int.Parse(cbProizvodSifra.SelectedValue.ToString()));
                dataGridView1_CellClick(null, null);
                dataGridView1.Select();
            }
            catch { }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnUnesiStavku.Enabled = false;
            btnIzmeniStavku.Enabled = true;
            btnObrisi.Enabled = true;

            try
            {
                cbPPSif.SelectedValue = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
                cbPPnaziv.SelectedValue = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
                tbKolicina.Text = dataGridView1.CurrentRow.Cells["kolicina"].Value.ToString();


            }
            catch
            {
            }
        }

        private void btnNoviPP_Click(object sender, EventArgs e)
        {
            FormNoviPP f1 = new FormNoviPP();
            f1.ShowDialog();

            ucitajPP();
        }

        private void btnUnesiStavkuGP_Click(object sender, EventArgs e)
        {
            string insert = "INSERT INTO  sastavnicaPP_GP(idpoluprozivod, idGP, kolicina) " +
                          " VALUES        (" + cbProizvodSifra.SelectedValue + "," + cbGPSastavnicaSifra.SelectedValue + "," + tbKolicinaGP.Text + ")";
            metode.pristup_bazi(insert);
            ucitajSastavnicu(int.Parse(cbProizvodSifra.SelectedValue.ToString()));
        }

        private void btnIzmeniStavkuGP_Click(object sender, EventArgs e)
        {
            int idSasta = int.Parse(dgvGPSastavnica.CurrentRow.Cells["idSast"].Value.ToString());

            string update = "UPDATE  sastavnicaPP_GP SET   idGP = " + cbGPSastavnicaSifra.SelectedValue + ", kolicina = " + tbKolicinaGP.Text + " " +
                            " WHERE        (id = " + idSasta + ")";
            metode.pristup_bazi(update);

            ucitajSastavnicu(int.Parse(cbProizvodSifra.SelectedValue.ToString()));
        }

        private void btnNovaStavkaGP_Click(object sender, EventArgs e)
        {
            btnIzmeniStavkuGP.Enabled = false;
            btnUnesiStavkuGP.Enabled = true;
            tbKolicinaGP.Text = "0";
            cbGPSastavnicaSifra.SelectedValue = "0";
            cbGPSastavnicaNaziv.SelectedValue = "0";
        }

        private void btnObrisiGP_Click(object sender, EventArgs e)
        {
            metode.pristup_bazi("DELETE FROM  sastavnicaPP_GP WHERE id = " + dgvGPSastavnica.CurrentRow.Cells["idSast"].Value.ToString() + " ");
            ucitajSastavnicu(int.Parse(cbProizvodSifra.SelectedValue.ToString()));
        }

        private void btnNovaStavkaPP_Click(object sender, EventArgs e)
        {
            btnIzmeniStavkuPP.Enabled = false;
            btnUnesiStavkuPP.Enabled = true;
            tbKolicinaPP.Text = "0";
            cbPPSastavnicaSifra.SelectedValue = "0";
            cbPPSastavnicaNaziv.SelectedValue = "0";
        }

        private void btnUnesiStavkuPP_Click(object sender, EventArgs e)
        {
            string insert = "INSERT INTO  sastavnicaPP_PP(idpoluprozivod, idPP, kolicina) " +
                          " VALUES        (" + cbProizvodSifra.SelectedValue + "," + cbPPSastavnicaSifra.SelectedValue + "," + tbKolicinaPP.Text + ")";
            metode.pristup_bazi(insert);
            ucitajSastavnicu(int.Parse(cbProizvodSifra.SelectedValue.ToString()));
        }

        private void btnIzmeniStavkuPP_Click(object sender, EventArgs e)
        {
            int idSasta = int.Parse(dgvPP.CurrentRow.Cells["idSast"].Value.ToString());

            string update = "UPDATE  sastavnicaPP_PP SET   idPP = " + cbPPSastavnicaSifra.SelectedValue + ", kolicina = " + tbKolicinaPP.Text + " " +
                            " WHERE        (id = " + idSasta + ")";
            metode.pristup_bazi(update);

            ucitajSastavnicu(int.Parse(cbProizvodSifra.SelectedValue.ToString()));
        }

        private void btnObrisiPP_Click(object sender, EventArgs e)
        {
            metode.pristup_bazi("DELETE FROM  sastavnicaPP_PP WHERE id = " + dgvPP.CurrentRow.Cells["idSast"].Value.ToString() + " ");
            ucitajSastavnicu(int.Parse(cbProizvodSifra.SelectedValue.ToString()));
        }

        private void dgvGPSastavnica_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnUnesiStavkuGP.Enabled = false;
            btnIzmeniStavkuGP.Enabled = true;

            try
            {
                cbGPSastavnicaSifra.SelectedValue = dgvGPSastavnica.CurrentRow.Cells["idGP"].Value.ToString();
                cbGPSastavnicaNaziv.SelectedValue = dgvGPSastavnica.CurrentRow.Cells["idGP"].Value.ToString();
                tbKolicinaGP.Text = dgvGPSastavnica.CurrentRow.Cells["kolicina"].Value.ToString();

            }
            catch
            {
            }
        }

        private void dgvPP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnUnesiStavkuPP.Enabled = false;
            btnIzmeniStavkuPP.Enabled = true;

            try
            {
                cbPPSastavnicaSifra.SelectedValue = dgvPP.CurrentRow.Cells["idPP"].Value.ToString();
                cbPPSastavnicaNaziv.SelectedValue = dgvPP.CurrentRow.Cells["idPP"].Value.ToString();
                tbKolicinaPP.Text = dgvPP.CurrentRow.Cells["kolicina"].Value.ToString();

            }
            catch
            {
            }
        }
    }
}
