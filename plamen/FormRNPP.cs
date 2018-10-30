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
    public partial class FormRNPP : Form
    {
        Metode metode = new Metode();
        ReportDocument ReportDoc;

        private string idNalogPP = "";
        private int brojStavki = 0;
        private int napravljeno = 0;
        private int rezervisano = 0;
        string putanja = "";

        int kolicina = 0;
        public FormRNPP()
        {
            InitializeComponent();
            ucitajProizvode();
            tbBrojNaloga.Text = (maxBrNaloga() + 1).ToString();
            dtpDatum.Value = DateTime.Now;
            dtpRok.Value = DateTime.Now;
            ucitajStatus();
            ucitajNalogGP();
            ucitajSmena();

        }

        public FormRNPP(int idPP, int idNalogGP)
        {
            InitializeComponent();
            ucitajProizvode();

            tbBrojNaloga.Text = (maxBrNaloga() + 1).ToString();
            dtpDatum.Value = DateTime.Now;
            dtpRok.Value = DateTime.Now;

            cbProizvodSifra.SelectedValue = idPP;
            cmproizvodNaziv.SelectedValue = idPP;
            ucitajStatus();
            ucitajNalogGP();
            ucitajSmena();
            cbRNGP.SelectedValue = idNalogGP;
            tbKolicina.Text = idNalogPublic.kolicina.ToString();

            btnUnesiStavku_Click(null, null);

            this.WindowState = FormWindowState.Maximized;
            //DataTable dt = metode.baza_upit("SELECT  dbo.RadniNalogPP.id, dbo.StavkeRNPP.idPP, dbo.RadniNalogPP.idNalogGP,dbo.StavkeRNPP.napravljeno FROM   dbo.StavkeRNPP INNER JOIN " +
            //          "  dbo.RadniNalogPP ON dbo.StavkeRNPP.idRNPP = dbo.RadniNalogPP.id " +
            //                " WHERE        (dbo.RadniNalogPP.idNalogGP = " + idNalogGP + ") AND (dbo.StavkeRNPP.idPP = " + idPP + ")");
            //if (dt.Rows.Count > 0)
            //{
            //    idNalogPP = dt.Rows[0]["id"].ToString();
            //    napravljeno = int.Parse(dt.Rows[0]["napravljeno"].ToString());
            //    prikaz(idNalogPP);
            //}
            //else
            //{
            //    btnUnesiStavku_Click(null, null);
            //}
        }
        public FormRNPP(string idNaloga)
        {
            InitializeComponent();
            ucitajProizvode();
            ucitajStatus();
            idNalogPP = idNaloga;
            ucitajSmena();
            ucitajNalogGP();
            prikaz(idNalogPP);
            // btnUnesiStavku_Click(null, null);
            dgvStavkeNaloga_CellContentClick(null, null);
            this.WindowState = FormWindowState.Maximized;
        }


        public GroupBox GetGroupBox()
        {
            return groupBox1;
        }

        private void ucitajNalogGP()
        {
            DataTable dt = metode.baza_upit("SELECT  id, broj, idNalog FROM    RadniNalogGP order by broj");
            cbRNGP.DataSource = dt;
            cbRNGP.DisplayMember = "broj";
            cbRNGP.ValueMember = "id";

        }
        private void ucitajProizvode()
        {
            DataTable dt = metode.baza_upit("SELECT id, Kod, Naziv,  stanje FROM   Poluproizvodi order by kod");

            cbProizvodSifra.DataSource = dt;
            cbProizvodSifra.DisplayMember = "Kod";
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
            DataTable dt = (metode.baza_upit(" select broj from radninalogPP order by broj desc"));

            if (dt.Rows.Count > 0)
            {
                broj = int.Parse(dt.Rows[0]["broj"].ToString());
            }
            return broj;
        }

        private void ucitajSmena()
        {
            DataTable dt = metode.baza_upit("SELECT id, Smena FROM    SIF_Smena");

            cbSmena.DataSource = dt;
            cbSmena.DisplayMember = "Smena";
            cbSmena.ValueMember = "id";
            cbSmena.SelectedValue = "1";
        }

        private void ucitajStatus()
        {
            DataTable dt = metode.baza_upit("SELECT id, status FROM    SIF_Status");

            cbReal.DataSource = dt;
            cbReal.DisplayMember = "status";
            cbReal.ValueMember = "id";
            cbReal.SelectedValue = "2";
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


        private void ucitajStavkeNaloga()
        {
            DataTable dt = metode.baza_upit("  SELECT        dbo.StavkeRNPP.id, dbo.StavkeRNPP.idRNPP, dbo.StavkeRNPP.idPP, dbo.Poluproizvodi.Kod, dbo.Poluproizvodi.Naziv, dbo.StavkeRNPP.kolicina, dbo.StavkeRNPP.napravljeno " +
                                            " FROM            dbo.StavkeRNPP INNER JOIN  dbo.Poluproizvodi ON dbo.StavkeRNPP.idPP = dbo.Poluproizvodi.id " +
                                        " WHERE        (dbo.StavkeRNPP.idRNPP = " + idNalogPP + ") order by id");

            if (dt.Rows.Count > 0)
            {
                dgvStavkeNaloga.DataSource = dt;
                dgvStavkeNaloga.Columns["id"].Visible = false;
                dgvStavkeNaloga.Columns["idRNPP"].Visible = false;
                dgvStavkeNaloga.Columns["idPP"].Visible = false;
                tbNapravljeno.Text = dgvStavkeNaloga.Rows[0].Cells["napravljeno"].Value.ToString();
                // tbRezervisano.Text = dgvStavkeNaloga.Rows[0].Cells["rezervisano"].Value.ToString();

                napravljeno = int.Parse(tbNapravljeno.Text);
                //rezervisano = int.Parse(tbRezervisano.Text);

                if (brojStavki == 0)
                    brojStavki = dt.Rows.Count;
                dgvStavkeNaloga_CellContentClick(null, null);
            }
            else
            {
                dgvStavkeNaloga.DataSource = null;
                metode.pristup_bazi(" delete from radniNalogPP where id =" + idNalogPP + "");
                idNalogPP = "";
                btnIzmeni.Enabled = false;
                btnUnesiStavku.Enabled = true;
                tbKolicina.Text = "";
            }
        }


        private void btnUnesiStavku_Click(object sender, EventArgs e)
        {
            if (idNalogPP != "" || UnosNaloga())
            {
                metode.pristup_bazi("INSERT INTO   StavkeRNPP( idRNPP, idPP, kolicina,napravljeno,rezervisano) " +
                                    " VALUES        (N'" + idNalogPP + "'," + cbProizvodSifra.SelectedValue + ", " + tbKolicina.Text + ",0,0)");

                //ubaci u rezervisano nule
                string sastavnica = "SELECT  idSirovina FROM  sastavnicaPP_sirovina WHERE  (idpoluprozivod = " + cbProizvodSifra.SelectedValue + ")";
                DataTable dt = metode.baza_upit(sastavnica);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        string rezervisano = " INSERT  INTO   RezervisanoSirovine( idRNPP, IDSirovina, rezervisano) VALUES        (" + idNalogPP + "," + r["idSirovina"].ToString() + ",0) ";

                        metode.pristup_bazi(rezervisano);
                    }
                }

                DataTable dtPP = metode.baza_upit(" SELECT   idPP FROM sastavnicaPP_PP WHERE        (idpoluprozivod = " + cbProizvodSifra.SelectedValue + ")");
                if (dtPP.Rows.Count > 0)
                {
                    foreach (DataRow r in dtPP.Rows)
                    {
                        string rezervisano = " INSERT  INTO    RezervisanoPP_PP( idRNPP, IDPP, rezervisano) VALUES        (" + idNalogPP + "," + r["idPP"].ToString() + ",0) ";

                        metode.pristup_bazi(rezervisano);
                    }
                }

                DataTable dtGP = metode.baza_upit(" SELECT   idGP FROM sastavnicaPP_GP WHERE        (idpoluprozivod = " + cbProizvodSifra.SelectedValue + ")");
                if (dtGP.Rows.Count > 0)
                {
                    foreach (DataRow r in dtGP.Rows)
                    {
                        string rezervisano = " INSERT  INTO    RezervisanoPP_GP( idRNPP, IDGP, rezervisano) VALUES        (" + idNalogPP + "," + r["idGP"].ToString() + ",0) ";

                        metode.pristup_bazi(rezervisano);
                    }
                }

            }
            ucitajStavkeNaloga();
            prikasStanjaPP(int.Parse(cbProizvodSifra.SelectedValue.ToString()));
            btnSacuvajRN_Click(null, null);
            groupBox3.Visible = true;
        }

        private void prikasStanjaPP(int idPP)
        {
            FormStanjePP f1 = new FormStanjePP(idPP);
            this.groupBox3.Controls.Clear();
            this.groupBox3.Controls.Add(f1.GetGroupBox());
            f1.GetGroupBox().Dock = DockStyle.Fill;
            f1.GetGroupBox().Show();
        }

        private bool UnosNaloga()
        {
            if (tbBrojNaloga.Text == "")
            {
                MessageBox.Show("Morate odabrati nalog !!!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            string idNalogPom = "0";
            if (cbRNGP.SelectedValue != null) idNalogPom = cbRNGP.SelectedValue.ToString();

            DateTime datum = dtpDatum.Value;
            DateTime rok = dtpDatum.Value;
            string da = datum.Day.ToString() + "." + datum.Month.ToString() + "." + datum.Year.ToString();
            string datumRok = rok.Day.ToString() + "." + rok.Month.ToString() + "." + rok.Year.ToString();

            string query = "INSERT   INTO     RadniNalogPP(idNalogGP, broj,  datum, napomena, rok) " +                          // CONVERT(DATETIME, '18.1.2018', 105))
                           " VALUES        (" + idNalogPom + ", N'" + tbBrojNaloga.Text + "', convert(datetime,'" + da + "',105), N'" + tbNapomena.Text + "', convert(datetime,'" + datumRok + "',105))";

            metode.pristup_bazi(query);

            string queryVrati = " SELECT ID FROM  RadniNalogPP WHERE broj = N'" + tbBrojNaloga.Text + "'";
            idNalogPP = metode.baza_upit(queryVrati).Rows[0]["id"].ToString();

            return true;
        }

        private void btnNovaStavka_Click(object sender, EventArgs e)
        {
            btnIzmeniStavku.Enabled = false;
            btnUnesiStavku.Enabled = true;
            cbProizvodSifra.SelectedValue = "1";
            cmproizvodNaziv.SelectedValue = "1";
            tbKolicina.Text = "0";
        }

        private void btnObrisiStavku_Click(object sender, EventArgs e)
        {

            string status = metode.baza_upit("select status from radniNalogPP where id = " + idNalogPP + "").Rows[0]["status"].ToString();
            if (status != "")
            {
                metode.pristup_bazi(" update poluproizvodi set uProizvodnji = uproizvodnji - " + dgvStavkeNaloga.CurrentRow.Cells["kolicina"].Value.ToString() + " where id =" + dgvStavkeNaloga.CurrentRow.Cells["idPP"].Value.ToString() + "");
            }

            string obrisi = " delete from stavkeRNPP where id =" + dgvStavkeNaloga.CurrentRow.Cells["id"].Value.ToString() + " ";
            metode.pristup_bazi(obrisi);
            ucitajStavkeNaloga();
        }

        private void btnIzmeniStavku_Click(object sender, EventArgs e)
        {
            if (tbRezervisano.Text == "") tbRezervisano.Text = "0";
            int rezerisanoPom = int.Parse(tbRezervisano.Text) - rezervisano;
            metode.pristup_bazi("update StavkeRNPP set  idPP=" + cbProizvodSifra.SelectedValue + " , kolicina= " + tbKolicina.Text + " where id = " + dgvStavkeNaloga.CurrentRow.Cells["id"].Value + " " +
              " UPDATE       poluproizvodi SET uproizvodnji = uproizvodnji +" + (int.Parse(tbKolicina.Text) - kolicina) + " where id =" + cbProizvodSifra.SelectedValue.ToString() + "  ");

            ucitajStavkeNaloga();
            dgvStavkeNaloga_CellContentClick(null, null);
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (idNalogPP != "" || UnosNaloga())
            {

                DateTime datum = dtpDatum.Value;
                DateTime rok = dtpRok.Value;
                string da = datum.Day.ToString() + "." + datum.Month.ToString() + "." + datum.Year.ToString();
                string datumRok = rok.Day.ToString() + "." + rok.Month.ToString() + "." + rok.Year.ToString();

                metode.pristup_bazi(" UPDATE  RadniNalogPP SET  rok = convert(datetime,'" + datumRok + "',105),   datum = convert(datetime,'" + da + "',105), napomena =N'" + tbNapomena.Text + "' where id = " + idNalogPP + "");
            }
        }

        private void dgvStavkeNaloga_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnUnesiStavku.Enabled = false;
            btnIzmeniStavku.Enabled = true;

            if (dgvStavkeNaloga.CurrentRow == null)
            {
                cbProizvodSifra.SelectedValue = dgvStavkeNaloga.Rows[0].Cells["idPP"].Value.ToString();
                cmproizvodNaziv.SelectedValue = dgvStavkeNaloga.Rows[0].Cells["idPP"].Value.ToString();
                tbKolicina.Text = dgvStavkeNaloga.Rows[0].Cells["kolicina"].Value.ToString();
                // tbRezervisano.Text = dgvStavkeNaloga.Rows[0].Cells["rezervisano"].Value.ToString();

                stanjeSirovina(int.Parse(dgvStavkeNaloga.Rows[0].Cells["idPP"].Value.ToString()), int.Parse(tbKolicina.Text));
                stanjePP(int.Parse(dgvStavkeNaloga.Rows[0].Cells["idPP"].Value.ToString()), int.Parse(tbKolicina.Text));
                stanjeGP(int.Parse(dgvStavkeNaloga.Rows[0].Cells["idPP"].Value.ToString()), int.Parse(tbKolicina.Text));

                gbStanjeProizvoda.Visible = true;
                gbSastavnicaPP.Visible = true;
                gbSastavnicaGP.Visible = true;

            }
            else
            {
                cbProizvodSifra.SelectedValue = dgvStavkeNaloga.CurrentRow.Cells["idPP"].Value.ToString();
                cmproizvodNaziv.SelectedValue = dgvStavkeNaloga.CurrentRow.Cells["idPP"].Value.ToString();
                tbKolicina.Text = dgvStavkeNaloga.CurrentRow.Cells["kolicina"].Value.ToString();
                //  tbRezervisano.Text = dgvStavkeNaloga.CurrentRow.Cells["rezervisano"].Value.ToString();

                stanjeSirovina(int.Parse(dgvStavkeNaloga.Rows[0].Cells["idPP"].Value.ToString()), int.Parse(tbKolicina.Text));
                stanjePP(int.Parse(dgvStavkeNaloga.Rows[0].Cells["idPP"].Value.ToString()), int.Parse(tbKolicina.Text));
                stanjeGP(int.Parse(dgvStavkeNaloga.Rows[0].Cells["idPP"].Value.ToString()), int.Parse(tbKolicina.Text));

                gbStanjeProizvoda.Visible = true;
                gbSastavnicaPP.Visible = true;
                gbSastavnicaGP.Visible = true;
            }
            // rezervisano = int.Parse(tbRezervisano.Text);
            prikasStanjaPP(int.Parse(cbProizvodSifra.SelectedValue.ToString()));
            tbNapravljeno.Text = "0";
            tbSkart.Text = "0";
            tbBrojRadnika.Text = "0";
            kolicina = int.Parse(tbKolicina.Text);

        }

        private void stanjeSirovina(int idPP, int kolicina)
        {
            string select = "SELECT        dbo.Sirovina.id, dbo.Sirovina.naziv, dbo.Sirovina.jedinicaMere, dbo.Sirovina.stanje,dbo.sastavnicaPP_sirovina.kolicinaSirovine * " + kolicina + " AS [Potrebna kolicina], dbo.Sirovina.rezervisano, " +
                       "  dbo.RezervisanoSirovine.rezervisano AS RezervisanoIzOvogNaloga" +
                          " FROM            dbo.sastavnicaPP_sirovina INNER JOIN " +
                        "    dbo.Sirovina ON dbo.sastavnicaPP_sirovina.idSirovina = dbo.Sirovina.id LEFT OUTER JOIN " +
                         "   dbo.RezervisanoSirovine ON dbo.Sirovina.id = dbo.RezervisanoSirovine.IDSirovina " +
                          " WHERE        (dbo.sastavnicaPP_sirovina.idpoluprozivod = " + idPP + ") AND (dbo.RezervisanoSirovine.idRNPP = " + idNalogPP + ") ";
            //    " WHERE        (dbo.Sastavnica.idGotovProzivod = " + idPP + ") AND (dbo.RezervisanoPP.idRNGP = " + idNalogGP + ")";

            //string select = "SELECT        dbo.Poluproizvodi.id, dbo.Poluproizvodi.Kod, dbo.Poluproizvodi.Naziv, CAST(dbo.Sastavnica.kolicinaPP AS int) * 40 AS [Potrebna kolicina], dbo.Poluproizvodi.stanje, dbo.Poluproizvodi.uProizvodnji AS [U proizvodnji],  "+
            //             "  CAST(dbo.Poluproizvodi.Rezervisano AS int) AS rezervisano, ISNULL(dbo.RezervisanoPP.rezervisano, 0) AS RezervisanoIzOvogNaloga "+
            //         " FROM            dbo.Sastavnica INNER JOIN "+
            //           "    dbo.Poluproizvodi ON dbo.Sastavnica.idPoluProizvod = dbo.Poluproizvodi.id LEFT OUTER JOIN "+
            //           "    dbo.RezervisanoPP ON dbo.Sastavnica.idGotovProzivod = dbo.RezervisanoPP.idGP" +
            //            " WHERE        (dbo.Sastavnica.idGotovProzivod = " + idPP + ") AND (dbo.RezervisanoPP.idRNGP = " + idNalogGP + ")";

            DataTable dt = metode.baza_upit(select);
            if (dt.Rows.Count > 0)
            {
                dgvPP.DataSource = dt;
                dgvPP.Columns["id"].Visible = false;
                dgvPP.Columns["rezervisano"].DefaultCellStyle.Format = "0.000";

                //  dgvPP_CellClick(null, null);
            }
            else
            {
                dgvPP.DataSource = null;
            }
        }

        private void stanjePP(int idPP, int kolicina)
        {


            string select = "SELECT        dbo.Poluproizvodi.id, dbo.Poluproizvodi.Kod, dbo.Poluproizvodi.Naziv,dbo.Poluproizvodi.stanje, CAST(dbo.sastavnicaPP_PP .kolicina AS int) * " + kolicina + " AS [Potrebna kolicina],   " +//dbo.Poluproizvodi.uProizvodnji AS [U proizvodnji],
                            " cast(dbo.Poluproizvodi.Rezervisano as int) as Rezervisano , isnull(dbo.RezervisanoPP_PP.rezervisano,0) AS RezervisanoIzOvogNaloga " +
                            " FROM            dbo.sastavnicaPP_PP INNER JOIN dbo.Poluproizvodi ON dbo.sastavnicaPP_PP.idPP = dbo.Poluproizvodi.id  LEFT OUTER JOIN " +
                            " dbo.RezervisanoPP_pp ON dbo.Poluproizvodi.id = dbo.RezervisanoPP_pp.IDPP " +
                            " WHERE        (dbo.sastavnicaPP_PP.idpoluprozivod = " + idPP + ") AND (dbo.RezervisanoPP_PP.idRNPP = " + idNalogPP + ")";



            DataTable dt = metode.baza_upit(select);
            if (dt.Rows.Count > 0)
            {
                dgvPP_PP.DataSource = dt;
                dgvPP_PP.Columns["id"].Visible = false;
                dgvPP_PP.Columns["rezervisano"].DefaultCellStyle.Format = "0";

                // dgvPP_CellClick(null, null);
            }
            else
            {
                dgvPP_PP.DataSource = null;
            }
        }

        private void stanjeGP(int idPP, int kolicina)
        {


            string select = "  SELECT        dbo.GotovProizvod.id,   dbo.GotovProizvod.Sifra, dbo.GotovProizvod.Naziv, dbo.GotovProizvod.Stanje, cast(dbo.sastavnicaPP_GP.kolicina as int) *" + kolicina + " AS [Potrebna kolicina], cast(dbo.GotovProizvod.Rezervisano as int) as rezervisano, " +
                            "  isnull(dbo.RezervisanoPP_GP.rezervisano,0) AS RezervisanoIzOvogNaloga " +
                            " FROM            dbo.GotovProizvod INNER JOIN " +
                         " dbo.sastavnicaPP_GP ON dbo.GotovProizvod.id = dbo.sastavnicaPP_GP.idGP LEFT OUTER JOIN " +
                        "  dbo.RezervisanoPP_GP ON dbo.GotovProizvod.id = dbo.RezervisanoPP_GP.IDGP " +
                        " WHERE        (dbo.sastavnicaPP_GP.idpoluprozivod =" + idPP + ") AND (dbo.RezervisanoPP_GP.idRNPP = " + idNalogPP + ") ";
                          

           

            DataTable dt = metode.baza_upit(select);
            if (dt.Rows.Count > 0)
            {
                dgvPP_GP.DataSource = dt;
                dgvPP_GP.Columns["id"].Visible = false;
                dgvPP_GP.Columns["rezervisano"].DefaultCellStyle.Format = "0";

               // dgvPP_CellClick(null, null);
            }
            else
            {
                dgvPP_GP.DataSource = null;
            }
        }



        private void prikaz(string idN)
        {
            ucitajStavkeNaloga();

            DataTable dt = metode.baza_upit("SELECT  broj, idNalogGP, datum, napomena, status, rok,putanja FROM    RadniNalogPP where id = " + idN + "");
            tbNapomena.Text = dt.Rows[0]["napomena"].ToString();
            tbBrojNaloga.Text = dt.Rows[0]["broj"].ToString();
            cbRNGP.SelectedValue = dt.Rows[0]["idNalogGP"].ToString();
            dtpDatum.Value = DateTime.Parse(dt.Rows[0]["datum"].ToString());
            dtpRok.Value = DateTime.Parse(dt.Rows[0]["rok"].ToString());

            if ((dt.Rows[0]["putanja"].ToString() != null) && (dt.Rows[0]["putanja"].ToString() != ""))
            {
                tbRL.Text = dt.Rows[0]["putanja"].ToString().Substring(dt.Rows[0]["putanja"].ToString().LastIndexOf(@"\"), dt.Rows[0]["putanja"].ToString().Length - dt.Rows[0]["putanja"].ToString().LastIndexOf(@"\"));
                putanja = dt.Rows[0]["putanja"].ToString();
                btnStampaDokument.Visible = true;
            }
            else
            {
                tbRL.Text = "";
            }


            if (dt.Rows[0]["status"].ToString() == "1")
            {
                cbReal.SelectedValue = dt.Rows[0]["status"].ToString();
                cbReal.Enabled = false;
                //btnSacuvajRN.Enabled = false;
                sveEnable(false);
                checkBoxRealizovan.Checked = true;
            }
            else
            {
                try
                {
                    cbReal.SelectedValue = dt.Rows[0]["status"].ToString();
                }
                catch
                {
                }
                cbReal.Enabled = true;
                btnSacuvajRN.Enabled = true;
                sveEnable(true);
                checkBoxRealizovan.Checked = false;
            }


        }

        private void tbBrojNaloga_Leave(object sender, EventArgs e)
        {
            try
            {
                brojStavki = 0;
                DataTable dt = metode.baza_upit(" select id,obrisan from radniNalogPP where broj = " + tbBrojNaloga.Text + "");
                if (dt.Rows.Count > 0)
                {
                    idNalogPP = dt.Rows[0]["id"].ToString();

                    if (dt.Rows[0]["obrisan"].ToString() == "True" || dt.Rows[0]["obrisan"].ToString() == "1" || dt.Rows[0]["obrisan"].ToString() == "true")
                    {
                        MessageBox.Show("RN PP je obrisan, ne mozete ga menjati.");
                        prikaz(idNalogPP);
                        sveEnable(false);
                        checkBoxRealizovan.Enabled = false;
                        btnSacuvajRN.Enabled = false;
                        btnObrisi.Enabled = false;
                        return;
                    }

                    prikaz(idNalogPP);
                    prikasStanjaPP(int.Parse(dgvStavkeNaloga.Rows[0].Cells["idPP"].Value.ToString()));
                    groupBox3.Visible = true;
                    gbStanjeProizvoda.Visible = true;

                    dgvStavkeNaloga.Select();
                    dgvStavkeNaloga_CellContentClick(null, null);
                }
                else
                {
                    tbNapomena.Text = "";
                    tbKolicina.Text = "";
                    //cbProizvodSifra.SelectedValue = "1";
                    // cmproizvodNaziv.SelectedValue = "1";
                    cbReal.SelectedValue = "2";
                    dgvStavkeNaloga.DataSource = null;
                    idNalogPP = "";
                    sveEnable(true);
                    groupBox3.Visible = false;
                    gbStanjeProizvoda.Visible = false;
                    btnIzmeni.Enabled = false;
                    btnUnesiStavku.Enabled = true;
                    tbRL.Text = "";


                }
            }
            catch { }
        }

        private void sveEnable(Boolean t)
        {
            groupBoxStavka.Enabled = t;
            btnIzmeni.Enabled = t;

            //cbReal.Enabled = t;
            // btnSacuvajRN.Enabled = t;
            tbNapomena.Enabled = t;

            btnObrisiStavku.Enabled = t;
            btnNovaStavka.Enabled = t;
            // groupBox2.Enabled = t;
            tbNapravljeno.Enabled = t;
            tbSkart.Enabled = t;
            tbBrojRadnika.Enabled = t;
            dtpDatum.Enabled = t;
            dtpRok.Enabled = t;
            dtpSmena.Enabled = t;
            cbSmena.Enabled = t;

        }

        private void btnSacuvajRN_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow p in dgvPP.Rows)
            {
                string aaaa = metode.baza_upit(" select stanje from Sirovina where id = " + p.Cells["id"].Value.ToString() + "").Rows[0]["stanje"].ToString();

                double stanjeProizvoda = double.Parse(aaaa);
                double potrebnaKolicina = double.Parse(p.Cells["Potrebna kolicina"].Value.ToString()) / double.Parse(tbKolicina.Text);

                if ((double.Parse(tbNapravljeno.Text) + double.Parse(tbSkart.Text)) * potrebnaKolicina > stanjeProizvoda)
                {
                    MessageBox.Show("Nema dovoljno sirovine  '" + p.Cells["naziv"].Value.ToString() + "' na stanju");
                    dgvStavkeNaloga_CellContentClick(null, null);
                    return;
                }
            }

            foreach (DataGridViewRow p in dgvPP_PP.Rows)
            {
                string aaaa = metode.baza_upit(" select stanje from poluproizvodi where id = " + p.Cells["id"].Value.ToString() + "").Rows[0]["stanje"].ToString();

                int stanjeProizvoda = int.Parse(aaaa);
                int potrebnaKolicina = int.Parse(p.Cells["Potrebna kolicina"].Value.ToString()) / int.Parse(tbKolicina.Text);

                if ((int.Parse(tbNapravljeno.Text) + int.Parse(tbSkart.Text)) * potrebnaKolicina > stanjeProizvoda)
                {
                    MessageBox.Show("Nema dovoljno poluproizvoda  '" + p.Cells["naziv"].Value.ToString() + "' na stanju");
                    dgvStavkeNaloga_CellContentClick(null, null);
                    return;
                }
            }

            foreach (DataGridViewRow p in dgvPP_GP.Rows)
            {
                string aaaa = metode.baza_upit(" select stanje from gotovProizvod where id = " + p.Cells["id"].Value.ToString() + "").Rows[0]["stanje"].ToString();

                int stanjeProizvoda = int.Parse(aaaa);
                int potrebnaKolicina = int.Parse(p.Cells["Potrebna kolicina"].Value.ToString()) / int.Parse(tbKolicina.Text);

                if ((int.Parse(tbNapravljeno.Text) + int.Parse(tbSkart.Text)) * potrebnaKolicina > stanjeProizvoda)
                {
                    MessageBox.Show("Nema dovoljno proizvoda  '" + p.Cells["naziv"].Value.ToString() + "' na stanju");
                    dgvStavkeNaloga_CellContentClick(null, null);
                    return;
                }
            }


            string a = metode.baza_upit("SELECT status FROM  RadniNalogPP WHERE  (id = " + idNalogPP + ")").Rows[0]["status"].ToString();
            int stanje = 0;
            int uProiz = 0;
            int rezervisano = 0;
            string update = "";
            if (a == "")
            {
                foreach (DataGridViewRow r in dgvStavkeNaloga.Rows)
                {
                    if (cbReal.SelectedValue.ToString() == "1")
                    {
                        // tbNapravljeno.Text = r.Cells["kolicina"].Value.ToString();
                        //  stanje = int.Parse(r.Cells["kolicina"].Value.ToString());
                        stanje = int.Parse(tbNapravljeno.Text);
                        // uProiz = int.Parse(r.Cells["kolicina"].Value.ToString());

                        //
                        DataTable dt = metode.baza_upit(" SELECT idSirovina, kolicinaSirovine froM sastavnicaPP_sirovina WHERE        (idpoluprozivod = " + r.Cells["idPP"].Value.ToString() + ")");
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow sr in dt.Rows)
                            {
                                double kolicina = int.Parse(sr["kolicinaSirovine"].ToString());
                                string idSirovina = sr["idSirovina"].ToString();
                                double pomStanje = (stanje) * kolicina;


                                metode.pristup_bazi("update sirovina set stanje = stanje -" + pomStanje + " where id = " + idSirovina + "");
                            }
                        }
                        //

                    }
                    else if (cbReal.SelectedValue.ToString() == "2")
                    {
                        stanje = int.Parse(tbNapravljeno.Text) - napravljeno;
                        uProiz = int.Parse(tbKolicina.Text) - stanje;
                    }
                    else
                    {
                        uProiz = int.Parse(r.Cells["kolicina"].Value.ToString());
                    }

                    update = " UPDATE poluproizvodi SET  stanje = stanje + " + stanje + " , uProizvodnji = uProizvodnji +" + uProiz + " where id =" + r.Cells["idPP"].Value.ToString() + "; " +
                                " update    StavkeRNPP set    napravljeno = napravljeno + " + stanje + " where id=" + r.Cells["id"].Value.ToString() + " ";

                    //
                    DataTable dt1 = metode.baza_upit(" SELECT idSirovina, kolicinaSirovine froM sastavnicaPP_sirovina WHERE        (idpoluprozivod = " + r.Cells["idPP"].Value.ToString() + ")");
                    if (dt1.Rows.Count > 0)
                    {
                        foreach (DataRow sr in dt1.Rows)
                        {
                            double kolicina = double.Parse(sr["kolicinaSirovine"].ToString());
                            string idSirovina = sr["idSirovina"].ToString();
                            double pomStanje = (stanje) * kolicina;


                            metode.pristup_bazi("update sirovina set stanje = stanje -" + pomStanje + " where id = " + idSirovina + "");
                        }
                    }
                    //

                    metode.pristup_bazi(update);
                }
                metode.pristup_bazi("UPDATE RadniNalogPP SET status = " + cbReal.SelectedValue + ", datumPromene=getdate() where id = " + idNalogPP + " ");
            }
            else if (a == "2" || a == "3" || a == "1")
            {
                if (cbReal.SelectedValue.ToString() == "1")
                {
                    foreach (DataGridViewRow r in dgvStavkeNaloga.Rows)
                    {
                        int kolicinaPom = int.Parse(r.Cells["kolicina"].Value.ToString());
                        int napravljenoPom = int.Parse(r.Cells["napravljeno"].Value.ToString());

                        stanje = int.Parse(tbNapravljeno.Text);// -napravljeno;
                        uProiz = stanje;// int.Parse(r.Cells["kolicina"].Value.ToString()) - napravljeno;

                        if (a == "1")
                        {
                            //if (kolicinaPom > (napravljenoPom + stanje))
                            //{
                            //    uProiz = kolicinaPom - napravljenoPom;
                            //}
                        }
                        else
                        {
                            if (kolicinaPom > (napravljenoPom + stanje))
                            {
                                uProiz = kolicinaPom - napravljenoPom;
                            }
                        }

                        update = " UPDATE poluproizvodi SET  stanje = stanje + " + stanje + " , uProizvodnji = uProizvodnji -" + uProiz + " where id =" + r.Cells["idPP"].Value.ToString() + " ; " +
                             " update RadniNalogPP SET  datumRealizacije=getdate() where id = " + idNalogPP + " " +
                             " update    StavkeRNPP set        napravljeno = napravljeno + " + stanje + " where id=" + r.Cells["id"].Value.ToString() + " ";
                        metode.pristup_bazi(update);

                        //update stanje sirovina
                        DataTable dt1 = metode.baza_upit(" SELECT idSirovina, kolicinaSirovine froM sastavnicaPP_sirovina WHERE        (idpoluprozivod = " + r.Cells["idPP"].Value.ToString() + ")");
                        if (dt1.Rows.Count > 0)
                        {
                            foreach (DataRow sr in dt1.Rows)
                            {
                                double kolicina = double.Parse(sr["kolicinaSirovine"].ToString());
                                string idSirovina = sr["idSirovina"].ToString();
                                double pomStanje = (stanje) * kolicina;


                                metode.pristup_bazi("update sirovina set stanje = stanje - '" + pomStanje.ToString().Replace(",", ".") + "' where id = " + idSirovina + "");
                            }
                        }

                        DataTable dt = metode.baza_upit(" SELECT idPP, kolicina FROM  sastavnicaPP_PP WHERE        (idpoluprozivod = " + r.Cells["idPP"].Value.ToString() + ")");
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow sr in dt.Rows)
                            {
                                int kolicina = int.Parse(sr["kolicina"].ToString());
                                string idPP = sr["idPP"].ToString();
                                int pomStanje = (stanje + int.Parse(tbSkart.Text)) * kolicina;


                                metode.pristup_bazi("update poluproizvodi set stanje = stanje -" + pomStanje + " where id = " + idPP + "");
                            }
                        }
                        DataTable dtGP = metode.baza_upit(" SELECT  idGP, kolicinaGP FROM    SastavnicaPP_GP WHERE        (idpoluprozivod = " + r.Cells["idPP"].Value.ToString() + ")");
                        if (dtGP.Rows.Count > 0)
                        {
                            foreach (DataRow sr in dtGP.Rows)
                            {
                                int kolicina = int.Parse(sr["kolicina"].ToString());
                                string idPP = sr["idGP"].ToString();
                                int pomStanje = (stanje + int.Parse(tbSkart.Text)) * kolicina;


                                metode.pristup_bazi("update GotovProizvod set stanje = stanje -" + pomStanje + " where id = " + idPP + "");
                            }
                        }
                        //

                    }

                }
                else if (cbReal.SelectedValue.ToString() == "2")
                {
                    foreach (DataGridViewRow r in dgvStavkeNaloga.Rows)
                    {
                        stanje = int.Parse(tbNapravljeno.Text);// -napravljeno;
                        uProiz = int.Parse(tbKolicina.Text) - stanje;
                        update = " UPDATE poluproizvodi SET  stanje = stanje + " + stanje + " , uProizvodnji = uProizvodnji -" + stanje + "  where id =" + r.Cells["idPP"].Value.ToString() + " ; " +
                             " update    StavkeRNPP set        napravljeno = napravljeno + " + stanje + " where id=" + r.Cells["id"].Value.ToString() + " ";
                        metode.pristup_bazi(update);

                        //
                        DataTable dt1 = metode.baza_upit(" SELECT idSirovina, kolicinaSirovine froM sastavnicaPP_sirovina WHERE        (idpoluprozivod = " + r.Cells["idPP"].Value.ToString() + ")");
                        if (dt1.Rows.Count > 0)
                        {
                            foreach (DataRow sr in dt1.Rows)
                            {
                                double kolicina = double.Parse(sr["kolicinaSirovine"].ToString().Replace(".", ","));
                                string idSirovina = sr["idSirovina"].ToString();
                                double pomStanje = (stanje) * kolicina;


                                metode.pristup_bazi("update sirovina set stanje = stanje -'" + pomStanje.ToString().Replace(",", ".") + "' where id = " + idSirovina + "");
                            }
                        }

                        DataTable dt = metode.baza_upit(" SELECT idPP, kolicina FROM  sastavnicaPP_PP WHERE        (idpoluprozivod = " + r.Cells["idPP"].Value.ToString() + ")");
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow sr in dt.Rows)
                            {
                                int kolicina = int.Parse(sr["kolicina"].ToString());
                                string idPP = sr["idPP"].ToString();
                                int pomStanje = (stanje + int.Parse(tbSkart.Text)) * kolicina;


                                metode.pristup_bazi("update poluproizvodi set stanje = stanje -" + pomStanje + " where id = " + idPP + "");
                            }
                        }
                        DataTable dtGP = metode.baza_upit(" SELECT  idGP, kolicina FROM    SastavnicaPP_GP WHERE        (idpoluprozivod = " + r.Cells["idPP"].Value.ToString() + ")");
                        if (dtGP.Rows.Count > 0)
                        {
                            foreach (DataRow sr in dtGP.Rows)
                            {
                                int kolicina = int.Parse(sr["kolicina"].ToString());
                                string idPP = sr["idGP"].ToString();
                                int pomStanje = (stanje + int.Parse(tbSkart.Text)) * kolicina;


                                metode.pristup_bazi("update GotovProizvod set stanje = stanje -" + pomStanje + " where id = " + idPP + "");
                            }
                        }
                        //
                    }
                }
                else
                {
                    for (int i = brojStavki; i < dgvStavkeNaloga.Rows.Count; i++)
                    {
                        stanje = int.Parse(dgvStavkeNaloga.Rows[i].Cells["kolicina"].Value.ToString());

                        update = " UPDATE poluproizvodi SET   uProizvodnji = uProizvodnji +" + stanje + " where id =" + dgvStavkeNaloga.Rows[i].Cells["idPP"].Value.ToString() + " ; " +
                             " update    StavkeRNPP set        napravljeno = napravljeno + " + stanje + " where id=" + dgvStavkeNaloga.Rows[i].Cells["id"].Value.ToString() + " ";
                        metode.pristup_bazi(update);
                    }

                }
                metode.pristup_bazi("UPDATE RadniNalogPP SET status = " + cbReal.SelectedValue + ",datumPromene=getdate() where id = " + idNalogPP + " ");

                //ubacivanje podataka u napredakPP
                if (tbNapravljeno.Text != "0" || tbSkart.Text != "0")
                {
                    DateTime datumSmena = dtpSmena.Value;
                    string datumSm = datumSmena.Day.ToString() + "." + datumSmena.Month.ToString() + "." + datumSmena.Year.ToString();

                    int skart = int.Parse(tbSkart.Text);
                    string unesiNapredak = "INSERT INTO      napredakPP( idStavkePP, datum, brojRadnika,smena,  skart, dobriKomadi,minuti) " +
                                           " VALUES        (" + dgvStavkeNaloga.CurrentRow.Cells["id"].Value.ToString() + ",convert(datetime,'" + datumSm + "',105),N'" + tbBrojRadnika.Text + "'," + cbSmena.SelectedValue + "," + tbSkart.Text + "," + tbNapravljeno.Text + ", " + tbMinuti.Text + "*60)";

                    metode.pristup_bazi(unesiNapredak);
                }
            }

            metode.pristup_bazi(" UPDATE GotovProizvod SET Stanje =0 WHERE  (Stanje < 0); UPDATE poluproizvodi SET  Stanje =0 WHERE (Stanje < 0); UPDATE sirovina SET  Stanje =0 WHERE (Stanje < 0)");
           
            prikaz(idNalogPP);
            brojStavki = dgvStavkeNaloga.Rows.Count;
            prikasStanjaPP(int.Parse(cbProizvodSifra.SelectedValue.ToString()));
            dgvStavkeNaloga_CellContentClick(null, null);
            MessageBox.Show("Uspesno sacuvano.", "Uspesno");
        }

        private void cbReal_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbReal.SelectedValue.ToString() == "2")
            {
                checkBoxRealizovan.Checked = false;
            }
            else
            {
                checkBoxRealizovan.Checked = true;
            }
        }

        private void dgvPP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                tbRezervisano.Text = dgvPP.CurrentRow.Cells["RezervisanoIzOvogNaloga"].Value.ToString();
            }
            catch { }
        }

        private void btnRezervisi_Click(object sender, EventArgs e)
        {
            if (tbRezervisano.Text == "") tbRezervisano.Text = "0";
            double rezervisano = double.Parse(tbRezervisano.Text.Replace(".", ","));

            double rezerisanoPom = rezervisano - double.Parse(dgvPP.CurrentRow.Cells["RezervisanoIzOvogNaloga"].Value.ToString());


            string rezer = " UPDATE        sirovina SET             Rezervisano = Rezervisano + '" + rezerisanoPom.ToString().Replace(",", ".") + "' where id =" + dgvPP.CurrentRow.Cells["id"].Value.ToString() + " ; " +
                " delete from RezervisanoSirovine where idRNPP=" + idNalogPP + " and IDSirovina=" + dgvPP.CurrentRow.Cells["id"].Value.ToString() + " " +
                            " INSERT  INTO  RezervisanoSirovine(idRNPP, IDSirovina, rezervisano) VALUES        (" + idNalogPP + "," + dgvPP.CurrentRow.Cells["id"].Value.ToString() + ",'" + rezervisano.ToString().Replace(",", ".") + "')   ";

            metode.pristup_bazi(rezer);


            dgvStavkeNaloga_CellContentClick(null, null);
        }

        private void btnIzaberiRL_Click(object sender, EventArgs e)
        {
            string server = @"\\192.168.0.22\radne_liste\";

            if (idNalogPP == "")
            {
                MessageBox.Show("Prvo unesite RN PP pa onda dodajte dokument");
                return;
            }

            //DirectoryInfo dir = new DirectoryInfo("d:\\RadneListe");
            //if (!dir.Exists)
            //{
            //    Directory.CreateDirectory("d:\\RadneListe");
            //}

            OpenFileDialog fileFaktura = new OpenFileDialog();
            fileFaktura.ShowDialog();

            tbRL.Text = fileFaktura.FileName;

            if (fileFaktura.FileName != "")
            {
                string naziv = "";
                try
                {
                    naziv = "Radna lista RNPP " + tbBrojNaloga.Text + "-" + dtpDatum.Value.Year.ToString() + fileFaktura.FileName.Substring(fileFaktura.FileName.LastIndexOf(@"."), (fileFaktura.FileName.Length - fileFaktura.FileName.LastIndexOf(@".")));
                    File.Copy(@tbRL.Text, server + naziv, false);


                }
                catch
                {
                    if (MessageBox.Show("Postoji fajl sa tim imenom. Želite li da ga presnimite?", "Promenite ime fajla", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                    {
                        File.Copy(@tbRL.Text, server + naziv, true);


                    }
                    else
                    {
                        return;
                    }
                }
                putanja = server + naziv;
                metode.pristup_bazi(" update RadniNalogPP set putanja = N'" + server + "" + naziv + "' where id=" + idNalogPP + "");

                tbRL.Text = putanja.Substring(putanja.LastIndexOf(@"\"), putanja.Length - putanja.LastIndexOf(@"\"));
                btnStampaDokument.Visible = true;

            }
        }

        private void btnStampaDokument_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable dataBrojac = metode.baza_upit("select putanja putanja FROM            RadniNalogPP where id=" + idNalogPP + "");

                if (dataBrojac.Rows.Count == 0)
                {
                    MessageBox.Show("Ne postoji dokument vezan za ovaj radni nalog.", "Ne postoji dokument", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                foreach (DataRow row in dataBrojac.Rows)
                {
                    if ((row["putanja"].ToString() == "") || (row["putanja"].ToString() == null))
                    {
                        MessageBox.Show("Ne postoji dokument vezan za ovaj radni nalog.", "Ne postoji dokument", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return;
                    }
                    else
                    {

                        string putanja = row["putanja"].ToString();
                        System.Diagnostics.Process.Start(putanja);

                    }
                }
            }
            catch
            {
                MessageBox.Show("Odaberite dokument.", "Ne postoji dokument", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
        }

        private void checkBoxRealizovan_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBoxRealizovan.Checked)
                {
                    cbReal.SelectedValue = "1";
                    sveEnable(false);

                }
                else
                {
                    cbReal.SelectedValue = "2";
                    sveEnable(true);
                }
            }
            catch { }
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (idNalogPP == "")
            {
                MessageBox.Show("Ne postoji nalog. Prvo sacuvajte nalog ili odaberite vec postojeci.");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Da li ste sigurni da zelite da obrisete RN PP?", "Brisanje RN PP", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //sredjuje stanje
                DataTable dtNalog = metode.baza_upit("SELECT        dbo.StavkeRNPP.idRNPP, dbo.StavkeRNPP.idPP, dbo.StavkeRNPP.kolicina- dbo.StavkeRNPP.napravljeno AS uPro, dbo.RezervisanoSirovine.IDSirovina,  dbo.RezervisanoSirovine.rezervisano " +
                             " FROM            dbo.StavkeRNPP INNER JOIN dbo.RadniNalogPP ON dbo.StavkeRNPP.idRNPP = dbo.RadniNalogPP.id INNER JOIN " +
                         " dbo.RezervisanoSirovine ON dbo.StavkeRNPP.idRNPP = dbo.RezervisanoSirovine.idRNPP " +
                        "WHERE        (dbo.StavkeRNPP.idRNPP = " + idNalogPP + ")");
                foreach (DataRow r in dtNalog.Rows)
                {

                    int rezervisano = int.Parse(r["rezervisano"].ToString());
                    string idSir = r["IDSirovina"].ToString();
                    string idRNPP = r["idRNPP"].ToString();

                    metode.pristup_bazi(" update sirovina set Rezervisano = Rezervisano - " + rezervisano + " where id = " + idSir + "" +
                         " update RezervisanoSirovine set rezervisano = 0 where idRNPP =" + idRNPP + " and idSirovina = " + idSir + "");

                }
                metode.pristup_bazi(" update RadniNalogPP set obrisan = 1 where id = " + idNalogPP + "" +
                                    " update POLUPROIZVODI set uProizvodnji = uProizvodnji - " + dtNalog.Rows[0]["uPro"].ToString() + " where id = " + dtNalog.Rows[0]["idPP"].ToString() + "");
            }
        }

        private void btnStampaRL_Click(object sender, EventArgs e)
        {
            if (idNalogPP == "")
            {
                MessageBox.Show("Ne postoji nalog. Prvo sacuvajte nalog ili odaberite vec postojeci.");
                return;
            }

            makeReport("C:\\Program files\\IT\\Plamen\\RadnaListaPP.rpt");

            SetParameters(int.Parse(idNalogPP));

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

        private void btnStampa_Click(object sender, EventArgs e)
        {
            if (idNalogPP == "")
            {
                MessageBox.Show("Ne postoji nalog. Prvo sacuvajte nalog ili odaberite vec postojeci.");
                return;
            }

            makeReport("C:\\Program files\\IT\\Plamen\\NalogPP.rpt");

            SetParameters(int.Parse(idNalogPP));

            Report rep = new Report(ReportDoc);
            rep.ShowDialog();

        }

        private void btnRezervisiPP_Click(object sender, EventArgs e)
        {
            if (tbRezervisanoPP.Text == "") tbRezervisanoPP.Text = "0";

            int rezerisanoPom = int.Parse(tbRezervisanoPP.Text) - int.Parse(dgvPP_PP.CurrentRow.Cells["RezervisanoIzOvogNaloga"].Value.ToString());


            string rezer = " UPDATE        poluproizvodi SET             Rezervisano = Rezervisano + " + rezerisanoPom + " where id =" + dgvPP_PP.CurrentRow.Cells["id"].Value.ToString() + " ; " +
                " delete from RezervisanoPP_PP where idRNPP=" + idNalogPP + " and IDPP=" + dgvPP_PP.CurrentRow.Cells["id"].Value.ToString() + " " +
                            " INSERT  INTO  RezervisanoPP_PP(idRNPP, IDPP, rezervisano) VALUES        (" + idNalogPP + "," + dgvPP_PP.CurrentRow.Cells["id"].Value.ToString() + "," + tbRezervisanoPP.Text + ")   ";

            metode.pristup_bazi(rezer);


            dgvStavkeNaloga_CellContentClick(null, null);
        }

        private void dgvPP_PP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                tbRezervisanoPP.Text = dgvPP_PP.CurrentRow.Cells["RezervisanoIzOvogNaloga"].Value.ToString();
            }
            catch { }
        }

        private void btnRezervisiGP_Click(object sender, EventArgs e)
        {
            if (tbRezervisanoGP.Text == "") tbRezervisanoGP.Text = "0";

            int rezerisanoPom = int.Parse(tbRezervisanoGP.Text) - int.Parse(dgvPP_GP.CurrentRow.Cells["RezervisanoIzOvogNaloga"].Value.ToString());


            string rezer = " UPDATE        GotovProizvod SET             Rezervisano = Rezervisano + " + rezerisanoPom + " where id =" + dgvPP_GP.CurrentRow.Cells["id"].Value.ToString() + " ; " +
                " delete from RezervisanoPP_GP where idRNPP=" + idNalogPP + " and IDGP=" + dgvPP_GP.CurrentRow.Cells["id"].Value.ToString() + " " +
                            " INSERT  INTO  RezervisanoPP_GP(idRNPP, IDGP, rezervisano) VALUES        (" + idNalogPP + "," + dgvPP_GP.CurrentRow.Cells["id"].Value.ToString() + "," + tbRezervisanoGP.Text + ")   ";

            metode.pristup_bazi(rezer);


            dgvStavkeNaloga_CellContentClick(null, null);
        }

        private void dgvPP_GP_Click(object sender, EventArgs e)
        {
            try
            {
                tbRezervisanoGP.Text = dgvPP_GP.CurrentRow.Cells["RezervisanoIzOvogNaloga"].Value.ToString();
            }
            catch { }
        }

        private void dgvPP_GP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                tbRezervisanoGP.Text = dgvPP_GP.CurrentRow.Cells["RezervisanoIzOvogNaloga"].Value.ToString();
            }
            catch { }
        }

       
    }
}
