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

using System.Transactions;
using CrystalDecisions.CrystalReports.Engine;

namespace plamen
{
    public partial class FormNoviNalog : Form
    {
        Metode metode = new Metode();
        ReportDocument ReportDoc;

        private string idNalog = "";
        private int napravljeno = 0;
        private int brojStavki = 0;
        private int rezervisano = 0;
        public FormNoviNalog()
        {
            InitializeComponent();

            ucitajKomitente();
            ucitajProizvode();
            ucitajStatus();

            tbBrojNaloga.Text = (maxBrNaloga() + 1).ToString();
            dtpDatum.Value = DateTime.Now;
            dtpRok.Value = DateTime.Now;
        }
        public FormNoviNalog(string idNaloga)
        {
            InitializeComponent();
            ucitajProizvode();
            ucitajStatus();
            ucitajKomitente();

            idNalog = idNaloga;
            prikaz(idNalog);

            this.WindowState = FormWindowState.Maximized;

            dgvStavkeNaloga_CellClick(null, null);
        }
        public GroupBox GetGroupBox()
        {
            return groupBox1;
        }

        private void ucitajStatus()
        {
            DataTable dt = metode.baza_upit("SELECT id, status FROM    SIF_Status");

            cbRealiz.DataSource = dt;
            cbRealiz.DisplayMember = "status";
            cbRealiz.ValueMember = "id";
            cbRealiz.SelectedValue = "2";
        }

        private void ucitajKomitente()
        {
            DataTable dt = metode.baza_upit("select ID_Komitenta, SifraKomitenta, Prezime + ' ' + Ime AS Naziv from Komitenti where aktivan = 1 ORDER BY SifraKomitenta");

            cbKupacSifra.DataSource = dt;
            cbKupacSifra.DisplayMember = "SifraKomitenta";
            cbKupacSifra.ValueMember = "ID_Komitenta";
            cbKupacSifra.SelectedIndex = -1;

            cbKupacNaziv.DataSource = dt;
            cbKupacNaziv.DisplayMember = "Naziv";
            cbKupacNaziv.ValueMember = "ID_Komitenta";
            cbKupacNaziv.SelectedIndex = -1;
        }

        private void ucitajProizvode()
        {
            DataTable dt = metode.baza_upit("SELECT       id, Sifra, Naziv FROM            GotovProizvod where aktivan=1");

            cbProizvodSifra.DataSource = dt;
            cbProizvodSifra.DisplayMember = "Sifra";
            cbProizvodSifra.ValueMember = "id";
            cbProizvodSifra.SelectedIndex = -1;

            cmproizvodNaziv.DataSource = dt;
            cmproizvodNaziv.DisplayMember = "Naziv";
            cmproizvodNaziv.ValueMember = "id";
            cmproizvodNaziv.SelectedIndex = -1;
        }

        private int maxBrNaloga()
        {
            int broj = 0;
            DataTable dt = (metode.baza_upit(" select broj from nalog order by broj desc"));

            if (dt.Rows.Count > 0)
            {
                broj = int.Parse(dt.Rows[0]["broj"].ToString());
            }
            return broj;
        }

        private void cbKupacSifra_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                try
                {
                    if (cbKupacSifra.Text.Length != 0)
                    {
                        int pom = int.Parse(cbKupacSifra.Text);
                        if (cbKupacSifra.Text.Length == 4)
                        {
                            cbKupacSifra.SelectedValue = "0" + cbKupacSifra.Text;
                        }
                        else if (cbKupacSifra.Text.Length == 3)
                        {
                            cbKupacSifra.SelectedValue = "00" + cbKupacSifra.Text;
                        }
                        else if (cbKupacSifra.Text.Length == 2)
                        {
                            cbKupacSifra.SelectedValue = "000" + cbKupacSifra.Text;
                        }
                        else if (cbKupacSifra.Text.Length == 1)
                        {
                            cbKupacSifra.SelectedValue = "0000" + cbKupacSifra.Text;
                        }
                    }
                    cbKupacSifra.Focus();
                }
                catch
                {
                    MessageBox.Show("Niste uneli dobru vrednost za kupca", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cbKupacSifra.Focus();
                    return;
                }
            }
        }

        private void cbKupacSifra_Leave(object sender, EventArgs e)
        {
            if (cbKupacSifra.SelectedValue != null)
            {
                cbKupacNaziv.SelectedValue = cbKupacSifra.SelectedValue;
            }
        }

        private void cbKupacNaziv_Leave(object sender, EventArgs e)
        {
            if (cbKupacNaziv.SelectedValue != null)
            {
                cbKupacSifra.SelectedValue = cbKupacNaziv.SelectedValue;
            }
        }

        private void cbProizvodSifra_Leave(object sender, EventArgs e)
        {
            if (cbProizvodSifra.SelectedValue != null)
            {
                cmproizvodNaziv.SelectedValue = cbProizvodSifra.SelectedValue;
            }
        }

        private void cmproizvodNaziv_Leave(object sender, EventArgs e)
        {
            if (cmproizvodNaziv.SelectedValue != null)
            {
                cbProizvodSifra.SelectedValue = cmproizvodNaziv.SelectedValue;
            }
        }

        private void btnUnesiStavku_Click(object sender, EventArgs e)
        {
            if (idNalog != "" || UnosNaloga())
            {
                metode.pristup_bazi("INSERT INTO  StavkeNaloga( idNalog, idProizvod, kolicina,napravljeno, status,rezervisano) " +
                                    " VALUES        (N'" + idNalog + "'," + cbProizvodSifra.SelectedValue + ", " + tbKolicina.Text + ",0,2,0)");
                //  " update gotovProizvod set rezervisano = rezervisano +" + tbKolicina.Text + " where id = " + cbProizvodSifra.SelectedValue + "");

            }
            idNalogPublic.idNalog = int.Parse(idNalog);
            idNalogPublic.kolicina = int.Parse(tbKolicina.Text);
            ucitajStavkeNaloga();
            stanjeGotovProizvod(int.Parse(cbProizvodSifra.SelectedValue.ToString()));
            dgvStavkeNaloga_CellClick(null, null);
        }

        private bool UnosNaloga()
        {
            if (tbBrojNaloga.Text == "")
            {
                MessageBox.Show("Morate odabrati nalog !!!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            DateTime datum = dtpDatum.Value;
            DateTime rok = dtpRok.Value;
            string da = datum.Day.ToString() + "." + datum.Month.ToString() + "." + datum.Year.ToString();
            string datumRok = rok.Day.ToString() + "." + rok.Month.ToString() + "." + rok.Year.ToString();

            string query = "INSERT   INTO    Nalog( broj, idKupac, datum, napomena, status, rok) " +                          // CONVERT(DATETIME, '18.1.2018', 105))
                           " VALUES        (N'" + tbBrojNaloga.Text + "'," + cbKupacSifra.SelectedValue + ",convert(datetime,'" + da + "',105), N'" + tbNapomena.Text + "', 2,convert(datetime,'" + datumRok + "',105))";

            metode.pristup_bazi(query);

            string queryVrati = " SELECT ID FROM nalog WHERE broj = N'" + tbBrojNaloga.Text + "'";
            idNalog = metode.baza_upit(queryVrati).Rows[0]["id"].ToString();

            return true;
        }

        private void ucitajStavkeNaloga()
        {
            DataTable dt = metode.baza_upit("  SELECT        dbo.StavkeNaloga.id, dbo.StavkeNaloga.idNalog, dbo.StavkeNaloga.idProizvod, dbo.GotovProizvod.Sifra,  dbo.GotovProizvod.Naziv, dbo.StavkeNaloga.kolicina, dbo.StavkeNaloga.napravljeno as Zapakovano, dbo.StavkeNaloga.status,dbo.StavkeNaloga.Rezervisano, dbo.SIF_Status.status AS realizovan " +
                                       " frOM            dbo.StavkeNaloga INNER JOIN   dbo.GotovProizvod ON dbo.StavkeNaloga.idProizvod = dbo.GotovProizvod.id INNER JOIN  dbo.SIF_Status ON dbo.StavkeNaloga.Status = dbo.SIF_Status.id " +
                                       " WHERE        (dbo.StavkeNaloga.idNalog = " + idNalog + ")");

            if (dt.Rows.Count > 0)
            {
                dgvStavkeNaloga.DataSource = dt;
                dgvStavkeNaloga.Columns["id"].Visible = false;
                dgvStavkeNaloga.Columns["idNalog"].Visible = false;
                dgvStavkeNaloga.Columns["idProizvod"].Visible = false;
                dgvStavkeNaloga.Columns["Status"].Visible = false;
                tbNapravljeno.Text = dgvStavkeNaloga.Rows[0].Cells["Zapakovano"].Value.ToString();
                tbRezervisano.Text = dgvStavkeNaloga.Rows[0].Cells["Rezervisano"].Value.ToString();

                napravljeno = int.Parse(tbNapravljeno.Text);
                if (brojStavki == 0)
                    brojStavki = dt.Rows.Count;
            }
            else
            {
                dgvStavkeNaloga.DataSource = null;
            }
        }

        private void dgvStavkeNaloga_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //btnUnesiStavku.Enabled = false;
            //btnIzmeniStavku.Enabled = true;

            //try
            //{
            //    cbProizvodSifra.SelectedValue = dgvStavkeNaloga.CurrentRow.Cells["idProizvod"].Value.ToString();
            //    tbKolicina.Text = dgvStavkeNaloga.CurrentRow.Cells["kolicina"].Value.ToString();
            //}
            //catch
            //{
            //}
        }

        private void btnIzmeniStavku_Click(object sender, EventArgs e)
        {
            //if (cbProizvodSifra.SelectedValue != dgvStavkeNaloga.CurrentRow.Cells["idProizvod"].Value.ToString())
            //{
            //    metode.pristup_bazi(" update gotovProizvod set rezervisano = rezervisano -" + dgvStavkeNaloga.CurrentRow.Cells["Kolicina"].Value.ToString() + " where id = " + dgvStavkeNaloga.CurrentRow.Cells["idProizvod"].Value.ToString() + "");
            //}
            if (tbRezervisano.Text == "") tbRezervisano.Text = "0";
            int rezervisanoPom = int.Parse(tbRezervisano.Text) - rezervisano;
            metode.pristup_bazi("update StavkeNaloga set  idProizvod=" + cbProizvodSifra.SelectedValue + " , kolicina= " + tbKolicina.Text + ", rezervisano=" + tbRezervisano.Text + " where id= " + dgvStavkeNaloga.CurrentRow.Cells["id"].Value + " ;" +
             " UPDATE        GotovProizvod SET             Rezervisano = Rezervisano + " + rezervisanoPom + " where id =" + cbProizvodSifra.SelectedValue + "  ");
            ucitajStavkeNaloga();

            dgvStavkeNaloga_CellClick(null, null);
        }

        private void prikaz(string idN)
        {
            ucitajStavkeNaloga();

            DataTable dt = metode.baza_upit("SELECT  broj, idKupac, datum, napomena, Status,rok FROM  Nalog where id = " + idN + "");
            tbBrojNaloga.Text = (dt.Rows[0]["broj"].ToString());
            cbKupacSifra.SelectedValue = (dt.Rows[0]["idkupac"].ToString());
            tbNapomena.Text = dt.Rows[0]["napomena"].ToString();
            cbRealiz.SelectedValue = dt.Rows[0]["status"].ToString();
            dtpDatum.Value = DateTime.Parse(dt.Rows[0]["datum"].ToString());
            dtpRok.Value = DateTime.Parse(dt.Rows[0]["rok"].ToString());

            if (dt.Rows[0]["status"].ToString() == "1")
            {

                cbRealiz.Enabled = false;
                // btnSacuvajNalog.Enabled = false;
                sveEnable(false);
            }
            else
            {

                cbRealiz.Enabled = true;
                // btnSacuvajNalog.Enabled = true;
                sveEnable(true);
            }

        }
        private void sveEnable(Boolean t)
        {
            groupBoxStavka.Enabled = t;
            btnIzmeni.Enabled = t;

            cbRealiz.Enabled = t;
            // btnSacuvajNalog.Enabled = t;
            tbNapomena.Enabled = t;

            btnObrisiStavku.Enabled = t;
            btnNovaStavka.Enabled = t;
            cbKupacNaziv.Enabled = t;
            cbKupacSifra.Enabled = t;
            tbNapravljeno.Enabled = t;
        }

        private void tbBrojNaloga_Leave(object sender, EventArgs e)
        {
            try
            {
                brojStavki = 0;
                DataTable dt = metode.baza_upit(" select id, obrisan from Nalog where broj = " + tbBrojNaloga.Text + "");
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["obrisan"].ToString() == "1" || dt.Rows[0]["obrisan"].ToString() == "True" || dt.Rows[0]["obrisan"].ToString() == "true")
                    {
                        idNalog = dt.Rows[0]["id"].ToString();

                        MessageBox.Show("Zahtev je obrisan, ne mozete ga menjati.");
                        prikaz(idNalog);
                        sveEnable(false);
                        checkBoxRealizovan.Enabled = false;
                        btnSacuvajNalog.Enabled = false;
                        btnObrisi.Enabled = false;
                        return;
                    }
                    idNalog = dt.Rows[0]["id"].ToString();
                    idNalogPublic.idNalog = int.Parse(idNalog);
                    prikaz(idNalog);
                    gbNalogGP.Visible = true;
                    gbStanjeProizvoda.Visible = true;
                    dgvStavkeNaloga.Select();
                    dgvStavkeNaloga_CellClick(null, null);
                    btnObrisi.Enabled = true;

                }
                else
                {
                    tbNapomena.Text = "";
                    tbKolicina.Text = "";
                    tbRezervisano.Text = "";
                    tbNapravljeno.Text = "";
                    dtpDatum.Value = DateTime.Now;
                    dtpRok.Value = DateTime.Now;

                    cbProizvodSifra.SelectedValue = "1";
                    cmproizvodNaziv.SelectedValue = "1";
                    cbRealiz.SelectedValue = "2";
                    dgvStavkeNaloga.DataSource = null;
                    idNalog = "";
                    idNalogPublic.idNalog = 0;
                    sveEnable(true);
                    gbNalogGP.Visible = false;
                    gbStanjeProizvoda.Visible = false;
                    btnObrisi.Enabled = false;
                }
            }
            catch { }
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (idNalog != "" || UnosNaloga())
            {

                DateTime datum = dtpDatum.Value;
                DateTime rok = dtpRok.Value;
                string da = datum.Day.ToString() + "." + datum.Month.ToString() + "." + datum.Year.ToString();
                string datumRok = rok.Day.ToString() + "." + rok.Month.ToString() + "." + rok.Year.ToString();

                string query = "update    Nalog set rok = convert(datetime,'" + datumRok + "',105), idKupac=" + cbKupacSifra.SelectedValue + ", datum = convert(datetime,'" + da + "',105), " +
                    " napomena=N'" + tbNapomena.Text + "' where id = " + idNalog + "";

                metode.pristup_bazi(query);

                MessageBox.Show("Uspesno ste promenili nalog", "Uspesno");
            }
        }

        private void btnNovaStavka_Click(object sender, EventArgs e)
        {
            btnIzmeniStavku.Enabled = false;
            btnUnesiStavku.Enabled = true;
            cbProizvodSifra.SelectedValue = "1";
            cmproizvodNaziv.SelectedValue = "1";
            tbKolicina.Text = "0";
        }

        private void ucitajNalogGP(int idNalog)
        {
            FormSpisakNaloga f1 = new FormSpisakNaloga(idNalog, "2");
            this.gbNalogGP.Controls.Clear();
            this.gbNalogGP.Controls.Add(f1.GetGroupBox());
            f1.GetGroupBox().Dock = DockStyle.Top;
            f1.GetGroupBox().Show();
        }

        private void ucitajNalogGP(string idGP)
        {
            FormSpisakNaloga f1 = new FormSpisakNaloga(idGP, "2");
            this.gbNalogGP.Controls.Clear();
            this.gbNalogGP.Controls.Add(f1.GetGroupBox());
            f1.GetGroupBox().Dock = DockStyle.Top;
            f1.GetGroupBox().Show();
        }
        private void dgvStavkeNaloga_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnUnesiStavku.Enabled = false;
            btnIzmeniStavku.Enabled = true;
            gbNalogGP.Visible = true;
            gbStanjeProizvoda.Visible = true;

            //.Cells["idProizvod"].Value.ToString()
            try
            {
                if (dgvStavkeNaloga.CurrentRow != null)// || dgvStavkeNaloga.CurrentRow.Cells["idProizvod"].Value.ToString()!="")
                {
                    cbProizvodSifra.SelectedValue = dgvStavkeNaloga.CurrentRow.Cells["idProizvod"].Value.ToString();
                    cmproizvodNaziv.SelectedValue = dgvStavkeNaloga.CurrentRow.Cells["idProizvod"].Value.ToString();
                    tbKolicina.Text = dgvStavkeNaloga.CurrentRow.Cells["kolicina"].Value.ToString();
                    tbNapravljeno.Text = dgvStavkeNaloga.CurrentRow.Cells["Zapakovano"].Value.ToString();
                    cbRealiz.SelectedValue = dgvStavkeNaloga.CurrentRow.Cells["Status"].Value.ToString();
                    tbRezervisano.Text = dgvStavkeNaloga.CurrentRow.Cells["rezervisano"].Value.ToString();

                    stanjeGotovProizvod(int.Parse(dgvStavkeNaloga.CurrentRow.Cells["idProizvod"].Value.ToString()));


                }
                else
                {
                    cbProizvodSifra.SelectedValue = dgvStavkeNaloga.Rows[0].Cells["idProizvod"].Value.ToString();
                    cmproizvodNaziv.SelectedValue = dgvStavkeNaloga.Rows[0].Cells["idProizvod"].Value.ToString();
                    tbKolicina.Text = dgvStavkeNaloga.Rows[0].Cells["kolicina"].Value.ToString();
                    tbNapravljeno.Text = dgvStavkeNaloga.Rows[0].Cells["Zapakovano"].Value.ToString();
                    cbRealiz.SelectedValue = dgvStavkeNaloga.Rows[0].Cells["Status"].Value.ToString();
                    tbRezervisano.Text = dgvStavkeNaloga.Rows[0].Cells["rezervisano"].Value.ToString();

                    stanjeGotovProizvod(int.Parse(dgvStavkeNaloga.Rows[0].Cells["idProizvod"].Value.ToString()));
                }
                rezervisano = int.Parse(tbRezervisano.Text);
                napravljeno = int.Parse(tbNapravljeno.Text);
            }
            catch { }
            try
            {
                ucitajNalogGP(cbProizvodSifra.SelectedValue.ToString());
            }
            catch { }
        }

        private void btnObrisiStavku_Click(object sender, EventArgs e)
        {
            metode.pristup_bazi(" delete from stavkeNaloga where id = " + dgvStavkeNaloga.CurrentRow.Cells["id"].Value.ToString() + "");
            ucitajStavkeNaloga();
        }

        private void stanjeGotovProizvod(int idGotPro)
        {
            FormStanje fStanje = new FormStanje(idGotPro);
            this.gbStanjeProizvoda.Controls.Clear();
            this.gbStanjeProizvoda.Controls.Add(fStanje.GetGroupBox());
            fStanje.GetGroupBox().Dock = DockStyle.Fill;
            fStanje.GetGroupBox().Show();
        }

        private void unesiMagacin(int id)
        {
            int broj = 1;
            DataTable dt = metode.baza_upit("select max (broj) as broj from magacin");
            if (dt.Rows[0]["broj"].ToString() != "")
            {
                broj = int.Parse(dt.Rows[0]["broj"].ToString()) + 1;

            }
            string qinsert = " INSERT INTO   Magacin(broj, idNalog, napomena, datum) " +
                            " VALUES        (" + broj + "," + id + ",N'napomena',getdate())";
            metode.pristup_bazi(qinsert);
        }

        private void updateNalog(string id)
        {
            int status1 = 0;
            int status2 = 0;
            int status3 = 0;
            foreach (DataGridViewRow r in dgvStavkeNaloga.Rows)
            {
                if (r.Cells["Status"].Value.ToString() == "1")
                {
                    status1 = 1;
                }
                else if (r.Cells["Status"].Value.ToString() == "2")
                {
                    status2 = 1;
                }
                else
                {
                    status3 = 1;
                }

            }
            if (status3 == 0 && status2 == 0 && status1 == 1)
            {
                metode.pristup_bazi("UPDATE Nalog SET status = 1 , datumRealizacije=getdate() where id = " + id + " ");

                unesiMagacin(int.Parse(idNalog));
            }
            else if (status3 == 1 && status2 == 0 && status1 == 0)
            {
                metode.pristup_bazi("UPDATE Nalog SET status = 2 where id = " + id + " ");
            }
            else
            {
                metode.pristup_bazi("UPDATE Nalog SET status = 2 where id = " + id + " ");
            }

            prikaz(id);
        }
        private void btnSacuvajNalog_Click(object sender, EventArgs e)
        {
            //if (cbRealiz.SelectedValue.ToString() == "1" && int.Parse(tbKolicina.Text) > int.Parse(tbNapravljeno.Text))
            //{
            //    MessageBox.Show("Kod realizovanog Naloga broj proizvoda  mora biti veci ili jednak od kolicine koja je zadata!");
            //    return;
            //}

            //if (int.Parse(tbKolicina.Text) <= int.Parse(tbNapravljeno.Text))
            //{
            //    cbRealiz.SelectedValue = 1;
            //}
            int stanjeProizvoda = int.Parse(metode.baza_upit(" select stanje from GotovProizvod where id = " + cbProizvodSifra.SelectedValue.ToString() + "").Rows[0]["stanje"].ToString());
            if (int.Parse(tbNapravljeno.Text) - napravljeno > stanjeProizvoda)
            {
                MessageBox.Show("Nema dovoljno  ' " + dgvStavkeNaloga.CurrentRow.Cells["sifra"].Value.ToString() + " - " + dgvStavkeNaloga.CurrentRow.Cells["naziv"].Value.ToString() + "' na stanju");
                dgvStavkeNaloga_CellClick(null, null);
                return;
            }

            string a = metode.baza_upit("SELECT status FROM  Nalog WHERE  (id = " + idNalog + ")").Rows[0]["status"].ToString();
            int stanje = 0;
            int uProiz = 0;
            string update = "";
            if (a == "")
            {
                //foreach (DataGridViewRow r in dgvStavkeNaloga.Rows)
                //{
                if (cbRealiz.SelectedValue.ToString() == "1")
                {
                    stanje = int.Parse(tbNapravljeno.Text);
                    //unesiMagacin(int.Parse(idNalog));
                }
                else if (cbRealiz.SelectedValue.ToString() == "2")
                {
                    stanje = int.Parse(tbNapravljeno.Text) - napravljeno;
                    uProiz = int.Parse(tbKolicina.Text) - stanje;
                }
                else
                {
                    uProiz = int.Parse(dgvStavkeNaloga.CurrentRow.Cells["kolicina"].Value.ToString());
                }
                update = " UPDATE gotovProizvod SET  stanje = stanje - " + stanje + ", uProizvodnji = uProizvodnji +" + uProiz + " where id =" + dgvStavkeNaloga.CurrentRow.Cells["idProizvod"].Value.ToString() + "  " +
                     " update    StavkeNaloga set  status = " + cbRealiz.SelectedValue + ",  napravljeno = napravljeno + " + stanje + " where id=" + dgvStavkeNaloga.CurrentRow.Cells["id"].Value.ToString() + " and idProizvod= " + dgvStavkeNaloga.CurrentRow.Cells["idProizvod"].Value.ToString() + " ";

                metode.pristup_bazi(update);
                // }
                prikaz(idNalog);
                updateNalog(idNalog);
                //  metode.pristup_bazi("UPDATE Nalog SET status = " + cbRealiz.SelectedValue + " where id = " + idNalog + " ");
            }
            else if (a == "2" || a == "3" || a == "1")
            {
                if (cbRealiz.SelectedValue.ToString() == "1")
                {
                    //foreach (DataGridViewRow r in dgvStavkeNaloga.Rows)
                    //{

                    stanje = int.Parse(tbNapravljeno.Text) - napravljeno;
                    uProiz = int.Parse(dgvStavkeNaloga.CurrentRow.Cells["kolicina"].Value.ToString()) - napravljeno;

                    update = " UPDATE gotovProizvod SET  stanje = stanje - " + stanje + "  where id =" + dgvStavkeNaloga.CurrentRow.Cells["idProizvod"].Value.ToString() + "  " +
                          " update    StavkeNaloga set   status = " + cbRealiz.SelectedValue + ",     napravljeno = napravljeno + " + stanje + " where id=" + dgvStavkeNaloga.CurrentRow.Cells["id"].Value.ToString() + " and idProizvod= " + dgvStavkeNaloga.CurrentRow.Cells["idProizvod"].Value.ToString() + " ";

                    metode.pristup_bazi(update);
                    //  }
                    // unesiMagacin(int.Parse(idNalog));

                }
                else if (cbRealiz.SelectedValue.ToString() == "2")
                {
                    //foreach (DataGridViewRow r in dgvStavkeNaloga.Rows)
                    //{

                    stanje = int.Parse(tbNapravljeno.Text) - napravljeno;
                    uProiz = int.Parse(tbKolicina.Text) - stanje;

                    update = " UPDATE gotovProizvod SET  stanje = stanje - " + stanje + "  where id =" + dgvStavkeNaloga.CurrentRow.Cells["idProizvod"].Value.ToString() + "  " +
                          " update    StavkeNaloga set    status = " + cbRealiz.SelectedValue + ",    napravljeno = napravljeno + " + stanje + " where id=" + dgvStavkeNaloga.CurrentRow.Cells["id"].Value.ToString() + " and idProizvod= " + dgvStavkeNaloga.CurrentRow.Cells["idProizvod"].Value.ToString() + " ";

                    metode.pristup_bazi(update);
                    //}
                }
                else
                {
                    //for (int i = brojStavki; i < dgvStavkeNaloga.Rows.Count; i++)
                    //{
                    //    stanje = int.Parse(dgvStavkeNaloga.Rows[i].Cells["kolicina"].Value.ToString());

                    //    update = " UPDATE poluproizvodi SET   uProizvodnji = uProizvodnji +" + stanje + " where id =" + dgvStavkeNaloga.Rows[i].Cells["idPP"].Value.ToString() + "  ";
                    //    metode.pristup_bazi(update);
                    //}

                }
                // metode.pristup_bazi("UPDATE Nalog SET status = " + cbRealiz.SelectedValue + " where id = " + idNalog + " ");
                prikaz(idNalog);
                updateNalog(idNalog);
            }

            // prikaz(idNalog);
            brojStavki = dgvStavkeNaloga.Rows.Count;
            //brojStavki = dgvStavkeNaloga.Rows.Count;
            dgvStavkeNaloga_CellClick(null, null);
            MessageBox.Show("Uspesno sacuvano.", "Uspesno");
        }

        private void cbRealiz_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbRealiz.SelectedValue.ToString() == "2")
            {
                checkBoxRealizovan.Checked = false;
            }
            else
            {
                checkBoxRealizovan.Checked = true;
            }
        }

        private void btnStampa_Click(object sender, EventArgs e)
        {
            if (idNalog == "")
            {
                MessageBox.Show("Ne postoji Zahtev. Prvo sacuvajte Zahtev ili odaberite vec postojeci.");
                return;
            }

            makeReport("C:\\Program files\\IT\\Plamen\\Zahtev.rpt");

            SetParameters(int.Parse(idNalog));

            Report rep = new Report(ReportDoc);
            rep.ShowDialog();
        }

        private void makeReport(string ReportFile)
        {
            ReportDoc = new ReportDocument();
            TextReader textReader = new StreamReader("c:\\Program files\\IT\\plamen\\dblogon.txt");
            string uid = textReader.ReadLine();
            string pwd = textReader.ReadLine();
            string server = textReader.ReadLine();
            string db = textReader.ReadLine();
            textReader.Close();

            ReportDoc.Load(ReportFile);
            ReportDoc.SetDatabaseLogon(uid, pwd, server, db);
        }

        private void SetParameters(int idNalog)
        {
            ReportDoc.SetParameterValue("idNaloga", idNalog);

        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (idNalog == "")
            {
                MessageBox.Show("Ne postoji Zahtev. Prvo sacuvajte Zahtev ili odaberite vec postojeci.");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Da li ste sigurni da zelite da obrisete zahtev?", "Brisanje zahteva", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //sredjuje stanje
                DataTable dtNalog = metode.baza_upit("SELECT        dbo.StavkeNaloga.idNalog, dbo.StavkeNaloga.idProizvod, dbo.StavkeNaloga.kolicina, dbo.StavkeNaloga.napravljeno, dbo.StavkeNaloga.Status, dbo.StavkeNaloga.rezervisano, dbo.Nalog.id " +
                                    " FROM            dbo.Nalog INNER JOIN  dbo.StavkeNaloga ON dbo.Nalog.id = dbo.StavkeNaloga.idNalog " +
                                    " WHERE        (dbo.Nalog.id = " + idNalog + ")");
                foreach (DataRow r in dtNalog.Rows)
                {
                    int napravljeno = int.Parse(r["napravljeno"].ToString());
                    int rezervisano = int.Parse(r["rezervisano"].ToString());
                    string idProizvod = r["idProizvod"].ToString();

                    metode.pristup_bazi(" update gotovproizvod set stanje = stanje + " + napravljeno + ", rezervisano = rezervisano - " + rezervisano + " where id = " + idProizvod + "");

                }
                metode.pristup_bazi(" update nalog set obrisan = 1 where id = " + idNalog + "");
            }
        }

        private void checkBoxRealizovan_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBoxRealizovan.Checked)
                {
                    cbRealiz.SelectedValue = "1";
                    sveEnable(false);

                }
                else
                {
                    cbRealiz.SelectedValue = "2";
                    sveEnable(true);
                }
            }
            catch { }
        }











    }


}
