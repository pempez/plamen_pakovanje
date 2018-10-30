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
    public partial class FormSastavnica : Form
    {
        Metode metode = new Metode();
        public FormSastavnica()
        {
            InitializeComponent();

            ucitajPP();
            ucitajProizvode();
            dataGridView1.DataSource = null;
            dgvGPSastavnica.DataSource = null;
            dgvSirovineSastavnica.DataSource = null;

            ucitajGPSastavnica();
            ucitajSirovine();

        }

        public GroupBox GetGroupBox()
        {
            return groupBox1;
        }

        private void ucitajProizvode()
        {
            DataTable dt = metode.baza_upit("SELECT       id, Sifra, Naziv FROM            GotovProizvod where aktivan=1 order by Naziv");

            cbProizvodSifra.DataSource = dt;
            cbProizvodSifra.DisplayMember = "Sifra";
            cbProizvodSifra.ValueMember = "id";
            cbProizvodSifra.SelectedIndex = -1;

            cbProizvodNaziv.DataSource = dt;
            cbProizvodNaziv.DisplayMember = "Naziv";
            cbProizvodNaziv.ValueMember = "id";
            cbProizvodNaziv.SelectedIndex = -1;

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

        private void ucitajPP()
        {
            DataTable dt = metode.baza_upit("SELECT    id, Kod, Naziv, Uputstvo, Telo, Guma, Cesalj, Plocica, stanje FROM  Poluproizvodi  where aktivan=1 order by naziv");

            cbPPSif.DataSource = dt;
            cbPPSif.DisplayMember = "Kod";
            cbPPSif.ValueMember = "id";
            cbPPSif.SelectedIndex = -1;

            cbPPnaziv.DataSource = dt;
            cbPPnaziv.DisplayMember = "Naziv";
            cbPPnaziv.ValueMember = "id";
            cbPPnaziv.SelectedIndex = -1;
        }

        private void ucitajSirovine()
        {
            DataTable dt = metode.baza_upit("SELECT        id, naziv, jedinicaMere, stanje, sifra FROM            Sirovina  where aktivan=1 order by naziv");

            cbSirovinaSifra.DataSource = dt;
            cbSirovinaSifra.DisplayMember = "sifra";
            cbSirovinaSifra.ValueMember = "id";
            cbSirovinaSifra.SelectedIndex = -1;

            cbSirovinaNaziv.DataSource = dt;
            cbSirovinaNaziv.DisplayMember = "Naziv";
            cbSirovinaNaziv.ValueMember = "id";
            cbSirovinaNaziv.SelectedIndex = -1;
        }

        private void btnUnesiStavku_Click(object sender, EventArgs e)
        {
            string insert = "INSERT INTO  Sastavnica(idGotovProzivod, idPoluProizvod, kolicinaPP) " +
                            " VALUES        (" + cbProizvodSifra.SelectedValue + "," + cbPPSif.SelectedValue + "," + tbKolicina.Text + ")";
            metode.pristup_bazi(insert);
            ucitajSastavnicu(int.Parse(cbProizvodSifra.SelectedValue.ToString()));
        }

        private void ucitajSastavnicu(int idGP)
        {
            DataTable dt = metode.baza_upit("SELECT    dbo.Poluproizvodi.Kod, dbo.Poluproizvodi.Naziv, dbo.Sastavnica.kolicinaPP AS kolicina, dbo.Sastavnica.id AS idSast, dbo.Poluproizvodi.id AS idPP " +
                                            " FROM  dbo.Sastavnica INNER JOIN    dbo.GotovProizvod ON dbo.Sastavnica.idGotovProzivod = dbo.GotovProizvod.id INNER JOIN " +
                                            " dbo.Poluproizvodi ON dbo.Sastavnica.idPoluProizvod = dbo.Poluproizvodi.id " +
                                            " WHERE        (dbo.GotovProizvod.id = " + idGP + ")");
            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;

                dataGridView1.Columns["idSast"].Visible = false;
                dataGridView1.Columns["idPP"].Visible = false;

            }
            else
            {
                dataGridView1.DataSource = null;
            }

            //za gotov proizvod
            DataTable dtGP = metode.baza_upit("SELECT        GotovProizvod_1.Sifra, GotovProizvod_1.Naziv, dbo.SastavnicaGP_GP.kolicinaGP, dbo.SastavnicaGP_GP.id AS idSast, GotovProizvod_1.id AS idGP " +
                                            " FROM            dbo.SastavnicaGP_GP INNER JOIN  dbo.GotovProizvod ON dbo.SastavnicaGP_GP.idGotovProzivod = dbo.GotovProizvod.id INNER JOIN " +
                                            "  dbo.GotovProizvod AS GotovProizvod_1 ON dbo.SastavnicaGP_GP.idGP = GotovProizvod_1.id " +
                                            " WHERE        (dbo.GotovProizvod.id = " + idGP + ")");
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

            //za sirovine
            DataTable dtSir = metode.baza_upit("SELECT        dbo.Sirovina.sifra, dbo.Sirovina.naziv, dbo.SastavnicaGP_sirovina.kolicinaSir AS kolicina, dbo.Sirovina.id AS idSir, dbo.SastavnicaGP_sirovina.id AS idSast " +
                                               " FROM            dbo.GotovProizvod INNER JOIN dbo.SastavnicaGP_sirovina ON dbo.GotovProizvod.id = dbo.SastavnicaGP_sirovina.idGotovProzivod INNER JOIN " +
                                              " dbo.Sirovina ON dbo.SastavnicaGP_sirovina.idSirovina = dbo.Sirovina.id " +
                                            " WHERE        (dbo.GotovProizvod.id = " + idGP + ")");
            if (dtSir.Rows.Count > 0)
            {
                dgvSirovineSastavnica.DataSource = dtSir;

                dgvSirovineSastavnica.Columns["idSast"].Visible = false;
                dgvSirovineSastavnica.Columns["idSir"].Visible = false;

            }
            else
            {
                dgvSirovineSastavnica.DataSource = null;
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
            catch
            {

            }
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

        private void cbProizvodSifra_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                ucitajSastavnicu(int.Parse(cbProizvodSifra.SelectedValue.ToString()));
                dataGridView1.Select();
                dataGridView1_CellClick(null, null);
            }
            catch { }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnUnesiStavku.Enabled = false;
            btnIzmeniStavku.Enabled = true;

            try
            {
                cbPPSif.SelectedValue = dataGridView1.CurrentRow.Cells["idPP"].Value.ToString();
                cbPPnaziv.SelectedValue = dataGridView1.CurrentRow.Cells["idPP"].Value.ToString();
                tbKolicina.Text = dataGridView1.CurrentRow.Cells["kolicina"].Value.ToString();

                FormSastavnicaPPSirovina f1 = new FormSastavnicaPPSirovina(dataGridView1.CurrentRow.Cells["idPP"].Value.ToString());
                groupBox2.Controls.Clear();
                groupBox2.Controls.Add(f1.GetGroupBox());
                f1.GetGroupBox().Dock = DockStyle.Fill;
                f1.GetGroupBox().Show();


            }
            catch
            {
            }


        }

        private void btnIzmeniStavku_Click(object sender, EventArgs e)
        {
            int idSasta = int.Parse(dataGridView1.CurrentRow.Cells["idSast"].Value.ToString());

            string update = "UPDATE Sastavnica SET   idPoluProizvod = " + cbPPSif.SelectedValue + ", kolicinaPP = " + tbKolicina.Text + " " +
                            " WHERE        (id = " + idSasta + ")";
            metode.pristup_bazi(update);

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

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            metode.pristup_bazi("DELETE FROM  Sastavnica WHERE        (idGotovProzivod =" + cbProizvodSifra.SelectedValue + ") AND (idPoluProizvod = " + cbPPSif.SelectedValue + ") ");
            ucitajSastavnicu(int.Parse(cbProizvodSifra.SelectedValue.ToString()));
        }

        private void btnNoviPP_Click(object sender, EventArgs e)
        {
            FormSastavnicaPPSirovina f1 = new FormSastavnicaPPSirovina();
            f1.ShowDialog();
            ucitajPP();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            btnIzmeniStavkuGP.Enabled = false;
            btnUnesiStavkuGP.Enabled = true;
            tbKolicinaGP.Text = "0";
            cbGPSastavnicaSifra.SelectedValue = "0";
            cbGPSastavnicaNaziv.SelectedValue = "0";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            metode.pristup_bazi("DELETE FROM  SastavnicaGP_GP WHERE id = " + dgvGPSastavnica.CurrentRow.Cells["idSast"].Value.ToString() + " ");
            ucitajSastavnicu(int.Parse(cbProizvodSifra.SelectedValue.ToString()));
        }

        private void btnUnesiStavkuGP_Click(object sender, EventArgs e)
        {
            string insert = "INSERT INTO  SastavnicaGP_GP(idGotovProzivod, idGP, kolicinaGP) " +
                           " VALUES        (" + cbProizvodSifra.SelectedValue + "," + cbGPSastavnicaSifra.SelectedValue + "," + tbKolicinaGP.Text + ")";
            metode.pristup_bazi(insert);

            ucitajSastavnicu(int.Parse(cbProizvodSifra.SelectedValue.ToString()));
        }

        private void dgvGPSastavnica_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnUnesiStavkuGP.Enabled = false;
            btnIzmeniStavkuGP.Enabled = true;

            try
            {
                cbGPSastavnicaSifra.SelectedValue = dgvGPSastavnica.CurrentRow.Cells["idGP"].Value.ToString();
                cbGPSastavnicaNaziv.SelectedValue = dgvGPSastavnica.CurrentRow.Cells["idGP"].Value.ToString();
                tbKolicinaGP.Text = dgvGPSastavnica.CurrentRow.Cells["kolicinaGP"].Value.ToString();

            }
            catch
            {
            }
        }

        private void btnIzmeniStavkuGP_Click(object sender, EventArgs e)
        {
            int idSasta = int.Parse(dgvGPSastavnica.CurrentRow.Cells["idSast"].Value.ToString());

            string update = "UPDATE SastavnicaGP_GP SET   idGP = " + cbGPSastavnicaSifra.SelectedValue + ", kolicinaGP = " + tbKolicinaGP.Text + " " +
                            " WHERE        (id = " + idSasta + ")";
            metode.pristup_bazi(update);

            ucitajSastavnicu(int.Parse(cbProizvodSifra.SelectedValue.ToString()));
        }

        private void btnNovaStavkaSir_Click(object sender, EventArgs e)
        {
            btnIzmeniStavkuSir.Enabled = false;
            btnUnesiStavkuSir.Enabled = true;
            tbKolicinaSir.Text = "0";
            cbSirovinaSifra.SelectedValue = "0";
            cbSirovinaNaziv.SelectedValue = "0";
        }

        private void btnUnesiStavkuSir_Click(object sender, EventArgs e)
        {

            string insert = "INSERT INTO    SastavnicaGP_sirovina(idGotovProzivod, idSirovina, kolicinaSir) " +
                          " VALUES        (" + cbProizvodSifra.SelectedValue + "," + cbSirovinaSifra.SelectedValue + ",N'" + tbKolicinaSir.Text.Replace(",", ".") + "')";
            metode.pristup_bazi(insert);

            ucitajSastavnicu(int.Parse(cbProizvodSifra.SelectedValue.ToString()));
        }

        private void btnIzmeniStavkuSir_Click(object sender, EventArgs e)
        {
            int idSasta = int.Parse(dgvSirovineSastavnica.CurrentRow.Cells["idSast"].Value.ToString());

            string update = "UPDATE SastavnicaGP_sirovina SET   idSirovina = " + cbSirovinaSifra.SelectedValue + ", kolicinaSir = N'" + tbKolicinaSir.Text.Replace(",", ".") + "' " +
                            " WHERE        (id = " + idSasta + ")";
            metode.pristup_bazi(update);

            ucitajSastavnicu(int.Parse(cbProizvodSifra.SelectedValue.ToString()));
        }

        private void dgvSirovineSastavnica_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnUnesiStavkuSir.Enabled = false;
            btnIzmeniStavkuSir.Enabled = true;

            try
            {
                cbSirovinaSifra.SelectedValue = dgvSirovineSastavnica.CurrentRow.Cells["idSir"].Value.ToString();
                cbSirovinaNaziv.SelectedValue = dgvSirovineSastavnica.CurrentRow.Cells["idSir"].Value.ToString();
                tbKolicinaSir.Text = dgvSirovineSastavnica.CurrentRow.Cells["kolicina"].Value.ToString();

            }
            catch
            {
            }
        }

        private void btnObrisiSirovinu_Click(object sender, EventArgs e)
        {
            metode.pristup_bazi("DELETE FROM  SastavnicaGP_sirovina WHERE id = " + dgvSirovineSastavnica.CurrentRow.Cells["idSast"].Value.ToString() + " ");
            ucitajSastavnicu(int.Parse(cbProizvodSifra.SelectedValue.ToString()));
        }
    }
}
