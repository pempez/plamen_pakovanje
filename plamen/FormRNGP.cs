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
    public partial class FormRNGP : Form
    {
        Metode metode = new Metode();
        private string idNalogGP = "";
        private int brojStavki = 0;
        private int napravljeno = 0;
        private int rezervisano = 0;
        int kolicina = 0;
        string putanja = "";
        ReportDocument ReportDoc;

        public FormRNGP()
        {
            InitializeComponent();
            ucitajProizvode();

            tbBrojNaloga.Text = (maxBrNaloga() + 1).ToString();
            dtpDatum.Value = DateTime.Now;
            dtpRok.Value = DateTime.Now;
            ucitajStatus();
            ucitajNaloge();
            ucitajSmena();
        }

        public FormRNGP(int idProizvod)
        {

            InitializeComponent();
            ucitajProizvode();
            ucitajSmena();

            tbBrojNaloga.Text = (maxBrNaloga() + 1).ToString();
            dtpDatum.Value = DateTime.Now;
            dtpRok.Value = DateTime.Now;

            cbProizvodSifra.SelectedValue = idProizvod;
            cmproizvodNaziv.SelectedValue = idProizvod;
            ucitajStatus();
            ucitajNaloge();
            cbBrojNaloga.SelectedValue = idNalogPublic.idNalog;
            tbKolicina.Text = idNalogPublic.kolicina.ToString();
            btnUnesiStavku_Click(null, null);
            this.WindowState = FormWindowState.Maximized;
        }
        public FormRNGP(string idNaloga)
        {
            InitializeComponent();
            ucitajProizvode();
            ucitajStatus();
            ucitajSmena();
            idNalogGP = idNaloga;
            ucitajNaloge();
            prikaz(idNalogGP);
            dgvStavkeNaloga_CellClick(null, null);

            this.WindowState = FormWindowState.Maximized;

        }
        private void ucitajNaloge()
        {
            DataTable dt = metode.baza_upit(" select id, broj from nalog order by broj");
            cbBrojNaloga.DataSource = dt;
            cbBrojNaloga.DisplayMember = "broj";
            cbBrojNaloga.ValueMember = "id";
        }

        public GroupBox GetGroupBox()
        {
            return groupBox1;
        }

        private void ucitajStatus()
        {
            DataTable dt = metode.baza_upit("SELECT id, status FROM    SIF_Status");

            cbReal.DataSource = dt;
            cbReal.DisplayMember = "status";
            cbReal.ValueMember = "id";
            cbReal.SelectedValue = "2";
        }

        private void ucitajSmena()
        {
            DataTable dt = metode.baza_upit("SELECT id, Smena FROM    SIF_Smena");

            cbSmena.DataSource = dt;
            cbSmena.DisplayMember = "Smena";
            cbSmena.ValueMember = "id";
            cbSmena.SelectedValue = "1";
        }

        private void ucitajProizvode()
        {
            DataTable dt = metode.baza_upit("SELECT       id, Sifra, Naziv, Rezervisano FROM            GotovProizvod where aktivan=1 order by sifra");

            cbProizvodSifra.DataSource = dt;
            cbProizvodSifra.DisplayMember = "Sifra";
            cbProizvodSifra.ValueMember = "id";
            cbProizvodSifra.SelectedIndex = -1;

            cmproizvodNaziv.DataSource = dt;
            cmproizvodNaziv.DisplayMember = "Naziv";
            cmproizvodNaziv.ValueMember = "id";
            cmproizvodNaziv.SelectedIndex = -1;
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

        private int maxBrNaloga()
        {
            int broj = 0;
            DataTable dt = (metode.baza_upit(" select cast(broj as int) as broj from radninalogGP order by broj desc"));

            if (dt.Rows.Count > 0)
            {
                broj = int.Parse(dt.Rows[0]["broj"].ToString());
            }
            return broj;
        }

        private void btnUnesiStavku_Click(object sender, EventArgs e)
        {
            if (idNalogGP != "" || UnosNaloga())
            {
                metode.pristup_bazi("INSERT INTO   StavkeRNGP( idRNGP, idProizvod, kolicina,napravljeno,rezervisano) " +
                                    " VALUES        (N'" + idNalogGP + "'," + cbProizvodSifra.SelectedValue + ", " + tbKolicina.Text + ",0,0)" +
                                    " update gotovProizvod set uproizvodnji = uProizvodnji + " + tbKolicina.Text + " where id = " + cbProizvodSifra.SelectedValue.ToString() + "");

                //ubaci u rezervisano nule
                string sastavnica = "SELECT         idPoluProizvod FROM            Sastavnica WHERE        (idGotovProzivod = " + cbProizvodSifra.SelectedValue + ")";
                DataTable dt = metode.baza_upit(sastavnica);
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow r in dt.Rows)
                    {
                        string rezervisano = " INSERT  INTO   RezervisanoPP(idRNGP, IDPP, rezervisano) VALUES        (" + idNalogGP + "," + r["idPoluProizvod"].ToString() + ",0) ";

                        metode.pristup_bazi(rezervisano);
                    }
                }

                DataTable dtSir = metode.baza_upit(" SELECT   idSirovina FROM  SastavnicaGP_sirovina WHERE        (idGotovProzivod = " + cbProizvodSifra.SelectedValue + ")");
                if (dtSir.Rows.Count > 0)
                {
                    foreach (DataRow r in dtSir.Rows)
                    {
                        string rezervisano = " INSERT  INTO     RezervisanoGP_SIR( idRNGP, IDSirovina, rezervisano) VALUES        (" + idNalogGP + "," + r["idSirovina"].ToString() + ",0) ";

                        metode.pristup_bazi(rezervisano);
                    }
                }

                DataTable dtGP = metode.baza_upit(" SELECT   idGP FROM sastavnicaGP_GP WHERE        (idGotovProzivod = " + cbProizvodSifra.SelectedValue + ")");
                if (dtGP.Rows.Count > 0)
                {
                    foreach (DataRow r in dtGP.Rows)
                    {
                        string rezervisano = " INSERT  INTO    RezervisanoGP_GP( idRNGP, IDGP, rezervisano) VALUES        (" + idNalogGP + "," + r["idGP"].ToString() + ",0) ";

                        metode.pristup_bazi(rezervisano);
                    }
                }

            }
            ucitajStavkeNaloga();
            btnSacuvajRN_Click(null, null);

            try
            {
                cbProizvodSifra.SelectedValue = dgvStavkeNaloga.Rows[0].Cells["idProizvod"].Value.ToString();
                cmproizvodNaziv.SelectedValue = dgvStavkeNaloga.Rows[0].Cells["idProizvod"].Value.ToString();
                tbKolicina.Text = dgvStavkeNaloga.Rows[0].Cells["kolicina"].Value.ToString();

                stanjePP(int.Parse(dgvStavkeNaloga.Rows[0].Cells["idProizvod"].Value.ToString()), int.Parse(dgvStavkeNaloga.Rows[0].Cells["kolicina"].Value.ToString()));
                stanjeGP(int.Parse(dgvStavkeNaloga.Rows[0].Cells["idProizvod"].Value.ToString()), int.Parse(dgvStavkeNaloga.Rows[0].Cells["kolicina"].Value.ToString()));

                gbStanjeProizvoda.Visible = true;
                gbSastavnicaGP.Visible = true;
                gbSastavnicaSir.Visible = true;
            }
            catch
            {
            }
        }

        private void ucitajNalogPP(int idNalog)
        {
            FormSpisakNaloga f1 = new FormSpisakNaloga(idNalog, "3");
            this.gbNalogPP.Controls.Clear();
            this.gbNalogPP.Controls.Add(f1.GetGroupBox());
            f1.GetGroupBox().Dock = DockStyle.Top;
            f1.GetGroupBox().Show();
        }

        private void ucitajStavkeNaloga()
        {
            DataTable dt = metode.baza_upit("  SELECT        dbo.stavkeRNGP.id, dbo.stavkeRNGP.idRNGP, dbo.stavkeRNGP.idProizvod, dbo.GotovProizvod.Sifra,  dbo.GotovProizvod.Naziv, dbo.stavkeRNGP.kolicina, dbo.StavkeRNGP.napravljeno " +
                                       " frOM            dbo.stavkeRNGP INNER JOIN   dbo.GotovProizvod ON dbo.stavkeRNGP.idProizvod = dbo.GotovProizvod.id " +
                                       " WHERE        (dbo.stavkeRNGP.idRNGP = " + idNalogGP + ")");

            if (dt.Rows.Count > 0)
            {
                dgvStavkeNaloga.DataSource = dt;
                dgvStavkeNaloga.Columns["id"].Visible = false;
                dgvStavkeNaloga.Columns["idRNGP"].Visible = false;
                dgvStavkeNaloga.Columns["idProizvod"].Visible = false;
                if (brojStavki == 0)
                    brojStavki = dt.Rows.Count;

                //tbNapravljeno.Text = dgvStavkeNaloga.Rows[0].Cells["napravljeno"].Value.ToString();

                //napravljeno = int.Parse(tbNapravljeno.Text);
            }
            else
            {
                dgvStavkeNaloga.DataSource = null;
            }

            tbNapravljeno.Text = "0";
            tbSkart.Text = "0";
            tbBrojRadnika.Text = "0";
        }

        private bool UnosNaloga()
        {
            if (tbBrojNaloga.Text == "")
            {
                MessageBox.Show("Morate odabrati nalog !!!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            string idPom = "0";
            if (cbBrojNaloga.SelectedValue != null)
            {
                idPom = cbBrojNaloga.SelectedValue.ToString();
            }

            DateTime datum = dtpDatum.Value;
            DateTime rok = dtpRok.Value;
            string da = datum.Day.ToString() + "." + datum.Month.ToString() + "." + datum.Year.ToString();
            string datumRok = rok.Day.ToString() + "." + rok.Month.ToString() + "." + rok.Year.ToString();
            string query = "INSERT   INTO     RadniNalogGP(idNalog, broj,  datum, napomena,napravljeno, rok) " +                          // CONVERT(DATETIME, '18.1.2018', 105))
                           " VALUES        (" + idPom + ",N'" + tbBrojNaloga.Text + "', convert(datetime,'" + da + "',105), N'" + tbNapomena.Text + "',0, convert(datetime,'" + datumRok + "',105))";

            metode.pristup_bazi(query);

            string queryVrati = " SELECT ID FROM  RadniNalogGP WHERE broj = N'" + tbBrojNaloga.Text + "'";
            idNalogGP = metode.baza_upit(queryVrati).Rows[0]["id"].ToString();



            return true;
        }

        private void tbBrojNaloga_Leave(object sender, EventArgs e)
        {
            try
            {
                brojStavki = 0;
                DataTable dt = metode.baza_upit(" select id, status, obrisan from radniNalogGP where broj = " + tbBrojNaloga.Text + "");
                if (dt.Rows.Count > 0)
                {
                   
                    idNalogGP = dt.Rows[0]["id"].ToString();
                    if (dt.Rows[0]["obrisan"].ToString() == "True" || dt.Rows[0]["obrisan"].ToString() == "1" || dt.Rows[0]["obrisan"].ToString() == "true")
                    {
                        MessageBox.Show("RN GP je obrisan, ne mozete ga menjati.");
                        prikaz(idNalogGP);
                        sveEnable(false);
                        checkBoxRealizovan.Enabled = false;
                        btnSacuvajRN.Enabled = false;
                        btnObrisi.Enabled = false;
                        return;
                    }
                    prikaz(idNalogGP);
                    dgvStavkeNaloga.Select();
                    dgvStavkeNaloga_CellClick(null, null);

                    gbNalogPP.Visible = true;
                    gbStanjeProizvoda.Visible = true;
                    cbReal.SelectedValue = dt.Rows[0]["status"].ToString();
                    btnUnesiStavku.Enabled = false;
                    btnIzmeniStavku.Enabled = true;
                    btnStampaRL.Enabled = true;
                    btnStampa.Enabled = true;
                }
                else
                {
                    tbNapomena.Text = "";
                    tbKolicina.Text = "";
                    //cbProizvodSifra.SelectedValue = "1";
                    // cmproizvodNaziv.SelectedValue = "1";
                    cbReal.SelectedValue = "2";
                    dgvStavkeNaloga.DataSource = null;
                    idNalogGP = "";
                    sveEnable(true);
                    gbNalogPP.Visible = false;
                    gbStanjeProizvoda.Visible = false;
                    btnUnesiStavku.Enabled = true;
                    btnIzmeniStavku.Enabled = false;
                    tbRL.Text = "";
                    btnStampaRL.Enabled = false;
                    btnStampa.Enabled = false;
                }

            }
            catch { }
        }

        private void prikaz(string idN)
        {
            ucitajStavkeNaloga();

            DataTable dt = metode.baza_upit("SELECT  broj, idNalog, datum, napomena, status,rok, putanja FROM    RadniNalogGP where id = " + idN + "");
            tbNapomena.Text = dt.Rows[0]["napomena"].ToString();
            tbBrojNaloga.Text = dt.Rows[0]["broj"].ToString();
            cbBrojNaloga.SelectedValue = dt.Rows[0]["idNalog"].ToString();
            cbReal.SelectedValue = dt.Rows[0]["status"].ToString();
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

                cbReal.Enabled = false;
                // btnSacuvajRN.Enabled = false;
                sveEnable(false);

            }
            else
            {

                cbReal.Enabled = true;
                btnSacuvajRN.Enabled = true;
                sveEnable(true);

            }


        }

        private void sveEnable(Boolean t)
        {
            groupBoxStavka.Enabled = t;
            btnIzmeni.Enabled = t;

            cbReal.Enabled = t;
            //btnSacuvajRN.Enabled = t;
            tbNapomena.Enabled = t;

            btnObrisiStavku.Enabled = t;
            btnNovaStavka.Enabled = t;
            // groupBox2.Enabled = t;

            tbNapravljeno.Enabled = t;
            tbSkart.Enabled = t;
            tbBrojRadnika.Enabled = t;
            cbSmena.Enabled = t;
            dtpDatum.Enabled = t;
            dtpRok.Enabled = t;
            dtpSmena.Enabled = t;
        }
        private void btnNovaStavka_Click(object sender, EventArgs e)
        {
            btnIzmeniStavku.Enabled = false;
            btnUnesiStavku.Enabled = true;
            cbProizvodSifra.SelectedValue = "1";
            cmproizvodNaziv.SelectedValue = "1";
            tbKolicina.Text = "0";
        }

        private void btnIzmeniStavku_Click(object sender, EventArgs e)
        {

            //if (tbRezervisano.Text == "") tbRezervisano.Text = "0";
            //int rezerisanoPom = int.Parse(tbRezervisano.Text) - rezervisano;
            metode.pristup_bazi("update StavkeRNGP set  idProizvod=" + cbProizvodSifra.SelectedValue + " , kolicina= " + tbKolicina.Text + " where id = " + dgvStavkeNaloga.CurrentRow.Cells["id"].Value + "; " +
                //" UPDATE        GotovProizvod SET             Rezervisano = Rezervisano + " + rezerisanoPom + " where id =" + cbProizvodSifra.SelectedValue + "  ");
             " update gotovProizvod set uproizvodnji = uProizvodnji + " + (int.Parse(tbKolicina.Text) - kolicina) + " where id = " + cbProizvodSifra.SelectedValue.ToString() + "");
            ucitajStavkeNaloga();
            dgvStavkeNaloga_CellClick(null, null);

        }

        private void dgvStavkeNaloga_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnUnesiStavku.Enabled = false;
            btnIzmeniStavku.Enabled = true;


            if (dgvStavkeNaloga.CurrentRow != null)
            {
                cbProizvodSifra.SelectedValue = dgvStavkeNaloga.CurrentRow.Cells["idProizvod"].Value.ToString();
                cmproizvodNaziv.SelectedValue = dgvStavkeNaloga.CurrentRow.Cells["idProizvod"].Value.ToString();
                tbKolicina.Text = dgvStavkeNaloga.CurrentRow.Cells["kolicina"].Value.ToString();
                //  tbRezervisano.Text = dgvStavkeNaloga.CurrentRow.Cells["rezervisano"].Value.ToString();


                stanjePP(int.Parse(dgvStavkeNaloga.CurrentRow.Cells["idProizvod"].Value.ToString()), int.Parse(dgvStavkeNaloga.CurrentRow.Cells["kolicina"].Value.ToString()));
                stanjeGP(int.Parse(dgvStavkeNaloga.CurrentRow.Cells["idProizvod"].Value.ToString()), int.Parse(dgvStavkeNaloga.CurrentRow.Cells["kolicina"].Value.ToString()));
                stanjeGP_sir(int.Parse(dgvStavkeNaloga.CurrentRow.Cells["idProizvod"].Value.ToString()), int.Parse(dgvStavkeNaloga.CurrentRow.Cells["kolicina"].Value.ToString()));
                
                
                gbStanjeProizvoda.Visible = true;
            }
            else
            {
                cbProizvodSifra.SelectedValue = dgvStavkeNaloga.Rows[0].Cells["idProizvod"].Value.ToString();
                cmproizvodNaziv.SelectedValue = dgvStavkeNaloga.Rows[0].Cells["idProizvod"].Value.ToString();
                tbKolicina.Text = dgvStavkeNaloga.Rows[0].Cells["kolicina"].Value.ToString();
                // tbRezervisano.Text = dgvStavkeNaloga.Rows[0].Cells["rezervisano"].Value.ToString();

                stanjePP(int.Parse(dgvStavkeNaloga.Rows[0].Cells["idProizvod"].Value.ToString()), int.Parse(dgvStavkeNaloga.Rows[0].Cells["kolicina"].Value.ToString()));
                stanjeGP(int.Parse(dgvStavkeNaloga.Rows[0].Cells["idProizvod"].Value.ToString()), int.Parse(dgvStavkeNaloga.Rows[0].Cells["kolicina"].Value.ToString()));
                stanjeGP_sir(int.Parse(dgvStavkeNaloga.Rows[0].Cells["idProizvod"].Value.ToString()), int.Parse(dgvStavkeNaloga.Rows[0].Cells["kolicina"].Value.ToString()));
               
                gbStanjeProizvoda.Visible = true;
            }
            gbSastavnicaGP.Visible = true;
            gbSastavnicaSir.Visible = true;
            // rezervisano = int.Parse(tbRezervisano.Text);
            ucitajNalogPP(int.Parse(idNalogGP));

            ucitajProizvod(int.Parse(cbProizvodSifra.SelectedValue.ToString()));

            kolicina = int.Parse(tbKolicina.Text);
        }
        private void ucitajProizvod(int id)
        {
            FormStanje fStanje = new FormStanje(id);
            this.btnpogledaj.Controls.Clear();
            this.btnpogledaj.Controls.Add(fStanje.GetGroupBox());
            fStanje.GetGroupBox().Dock = DockStyle.Fill;
            fStanje.GetGroupBox().Show();
        }
        private void stanjePP(int idPP, int kolicina)
        {
            string select = "SELECT        dbo.Poluproizvodi.id, dbo.Poluproizvodi.Kod, dbo.Poluproizvodi.Naziv, CAST(dbo.Sastavnica.kolicinaPP AS int) * " + kolicina + " AS [Potrebna kolicina], dbo.Poluproizvodi.stanje, dbo.Poluproizvodi.uProizvodnji AS [U proizvodnji],  " +
                          "  CAST(dbo.Poluproizvodi.Rezervisano AS int) AS rezervisano, ISNULL(dbo.RezervisanoPP.rezervisano, 0) AS RezervisanoIzOvogNaloga " +
                        " FROM            dbo.Sastavnica INNER JOIN " +
                         " dbo.Poluproizvodi ON dbo.Sastavnica.idPoluProizvod = dbo.Poluproizvodi.id LEFT OUTER JOIN " +
                         " dbo.RezervisanoPP ON dbo.Poluproizvodi.id = dbo.RezervisanoPP.IDPP " +
                        " WHERE        (dbo.Sastavnica.idGotovProzivod = " + idPP + ") AND (dbo.RezervisanoPP.idRNGP = " + idNalogGP + ")";

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
                dgvPP.Columns["rezervisano"].DefaultCellStyle.Format = "0";

                dgvPP_CellClick(null, null);
            }
            else
            {
                dgvPP.DataSource = null;
            }
        }

        private void stanjeGP(int idGP, int kolicina)
        {

            string select = "SELECT        dbo.GotovProizvod.id, dbo.GotovProizvod.Sifra, dbo.GotovProizvod.Naziv, dbo.GotovProizvod.Stanje,cast(dbo.SastavnicaGP_GP.kolicinaGP as int) *" + kolicina + " AS [Potrebna kolicina], cast(dbo.GotovProizvod.Rezervisano as int) as rezervisano,  isnull(dbo.RezervisanoGP_GP.rezervisano,0) AS RezervisanoIzOvogNaloga " +
                            " FROM            dbo.GotovProizvod INNER JOIN "+
                            " dbo.SastavnicaGP_GP ON dbo.GotovProizvod.id = dbo.SastavnicaGP_GP.idGP left outer JOIN "+
                            " dbo.RezervisanoGP_GP ON dbo.GotovProizvod.id = dbo.RezervisanoGP_GP.IDGP "+
                            " WHERE        (dbo.SastavnicaGP_GP.idGotovProzivod = " + idGP + ") AND (dbo.RezervisanoGP_GP.idRNGP = " + idNalogGP + ")";


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

        private void stanjeGP_sir(int idGP, int kolicina)
        {

            //string select = "SELECT        dbo.Sirovina.id, dbo.Sirovina.sifra, dbo.Sirovina.naziv, dbo.Sirovina.stanje, CAST(dbo.SastavnicaGP_sirovina.kolicinaSir AS int) AS [Potrebna kolicina], " +
            //                " CAST(dbo.Sirovina.rezervisano AS int) AS rezervisano, ISNULL(dbo.RezervisanoGP_SIR.rezervisano, 0) AS RezervisanoIzOvogNaloga " +
            //                " FROM            dbo.SastavnicaGP_sirovina INNER JOIN dbo.Sirovina ON dbo.SastavnicaGP_sirovina.idSirovina = dbo.Sirovina.id LEFT OUTER JOIN " +
            //                " dbo.RezervisanoGP_SIR ON dbo.Sirovina.id = dbo.RezervisanoGP_SIR.IDSirovina " +
            //                " WHERE        (dbo.SastavnicaGP_sirovina.idGotovProzivod = " + idGP + ") AND (dbo.RezervisanoGP_SIR.idRNGP = " + idNalogGP + ")";

            string select = "SELECT        dbo.Sirovina.id, dbo.Sirovina.sifra, dbo.Sirovina.naziv, dbo.Sirovina.stanje, dbo.SastavnicaGP_sirovina.kolicinaSir * " + kolicina + "  AS [Potrebna kolicina], " +
                           " dbo.Sirovina.rezervisano AS rezervisano, ISNULL(dbo.RezervisanoGP_SIR.rezervisano, 0) AS RezervisanoIzOvogNaloga " +
                           " FROM            dbo.SastavnicaGP_sirovina INNER JOIN dbo.Sirovina ON dbo.SastavnicaGP_sirovina.idSirovina = dbo.Sirovina.id LEFT OUTER JOIN " +
                           " dbo.RezervisanoGP_SIR ON dbo.Sirovina.id = dbo.RezervisanoGP_SIR.IDSirovina " +
                           " WHERE        (dbo.SastavnicaGP_sirovina.idGotovProzivod = " + idGP + ") AND (dbo.RezervisanoGP_SIR.idRNGP = " + idNalogGP + ")";
                     


            DataTable dt = metode.baza_upit(select);
            if (dt.Rows.Count > 0)
            {
                dgvGP_Sir.DataSource = dt;
                dgvGP_Sir.Columns["id"].Visible = false;
                dgvGP_Sir.Columns["rezervisano"].DefaultCellStyle.Format = "0.000";

                // dgvPP_CellClick(null, null);
            }
            else
            {
                dgvGP_Sir.DataSource = null;
            }
        }

        private void btnSacuvajRN_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow p in dgvGP_Sir.Rows)
            {

                double stanjeProizvoda = double.Parse(metode.baza_upit(" select stanje from sirovina where id = " + p.Cells["id"].Value.ToString() + "").Rows[0]["stanje"].ToString());
                double potrebnaKolicina = double.Parse(p.Cells["Potrebna kolicina"].Value.ToString()) / double.Parse(tbKolicina.Text);

                if ((double.Parse(tbNapravljeno.Text) + double.Parse(tbSkart.Text)) * potrebnaKolicina > stanjeProizvoda)
                {
                    MessageBox.Show("Nema dovoljno sirovina '" + p.Cells["sifra"].Value.ToString() + "  " + p.Cells["naziv"].Value.ToString() + "' na stanju");
                    dgvStavkeNaloga_CellClick(null, null);
                    return;
                }
            }

            foreach (DataGridViewRow p in dgvPP.Rows)
            {

                int stanjeProizvoda = int.Parse(metode.baza_upit(" select stanje from poluproizvodi where id = " + p.Cells["id"].Value.ToString() + "").Rows[0]["stanje"].ToString());
                int potrebnaKolicina = int.Parse(p.Cells["Potrebna kolicina"].Value.ToString()) / int.Parse(tbKolicina.Text);

                if ((int.Parse(tbNapravljeno.Text) + int.Parse(tbSkart.Text)) * potrebnaKolicina > stanjeProizvoda)
                {
                    MessageBox.Show("Nema dovoljno gotovih poluproizvoda '" + p.Cells["kod"].Value.ToString() + "  " + p.Cells["naziv"].Value.ToString() + "' na stanju");
                    dgvStavkeNaloga_CellClick(null, null);
                    return;
                }
            }
            foreach (DataGridViewRow p in dgvPP_GP.Rows)
            {

                int stanjeProizvoda = int.Parse(metode.baza_upit(" select stanje from gotovProizvod where id = " + p.Cells["id"].Value.ToString() + "").Rows[0]["stanje"].ToString());
                int potrebnaKolicina = int.Parse(p.Cells["Potrebna kolicina"].Value.ToString()) / int.Parse(tbKolicina.Text);

                if ((int.Parse(tbNapravljeno.Text) + int.Parse(tbSkart.Text)) * potrebnaKolicina > stanjeProizvoda)
                {
                    MessageBox.Show("Nema dovoljno gotovih proizovda '" + p.Cells["sifra"].Value.ToString() + "  " + p.Cells["naziv"].Value.ToString() + "' na stanju");
                    dgvStavkeNaloga_CellClick(null, null);
                    return;
                }
            }
            


            string a = metode.baza_upit("SELECT status FROM  RadniNalogGP WHERE  (id = " + idNalogGP + ")").Rows[0]["status"].ToString();
            int stanje = 0;
            int uProiz = 0;
            string update = "";
            if (a == "")
            {
                foreach (DataGridViewRow r in dgvStavkeNaloga.Rows)
                {
                    if (cbReal.SelectedValue.ToString() == "1")
                    {
                        stanje = int.Parse(r.Cells["kolicina"].Value.ToString());

                        //
                        DataTable dt = metode.baza_upit(" SELECT idPoluProizvod, kolicinaPP FROM Sastavnica WHERE        (idGotovProzivod = " + r.Cells["idProizvod"].Value.ToString() + ")");
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow sr in dt.Rows)
                            {
                                int kolicina = int.Parse(sr["kolicinaPP"].ToString());
                                string idPP = sr["idPoluProizvod"].ToString();
                                int pomStanje = (stanje) * kolicina;


                                metode.pristup_bazi("update poluproizvodi set stanje = stanje -" + pomStanje + " where id = " + idPP + "");
                            }
                        }
                        //

                    }
                    else if (cbReal.SelectedValue.ToString() == "2")
                    {
                        foreach (DataGridViewRow rr in dgvStavkeNaloga.Rows)
                        {
                            stanje = int.Parse(tbNapravljeno.Text) - napravljeno;

                            update = " UPDATE GotovProizvod SET  stanje = stanje + " + stanje + " , uProizvodnji = uProizvodnji -" + stanje + " where id =" + rr.Cells["idProizvod"].Value.ToString() + "  " +
                            " update    StavkeRNGP set        napravljeno = napravljeno + " + stanje + " where id=" + rr.Cells["id"].Value.ToString() + " ";

                            metode.pristup_bazi(update);

                            DataTable dt = metode.baza_upit(" SELECT idPoluProizvod, kolicinaPP FROM Sastavnica WHERE        (idGotovProzivod = " + rr.Cells["idProizvod"].Value.ToString() + ")");
                            if (dt.Rows.Count > 0)
                            {
                                foreach (DataRow sr in dt.Rows)
                                {
                                    int kolicina = int.Parse(sr["kolicinaPP"].ToString());
                                    string idPP = sr["idPoluProizvod"].ToString();
                                    int pomStanje = stanje * kolicina;


                                    metode.pristup_bazi("update poluproizvodi set stanje = stanje -" + pomStanje + " where id = " + idPP + "");
                                }
                            }
                        }
                    }
                    else uProiz = int.Parse(r.Cells["kolicina"].Value.ToString()); ;

                    update = " UPDATE GotovProizvod SET  stanje = stanje + " + stanje + " , uProizvodnji = uProizvodnji +" + uProiz + " where id =" + r.Cells["idProizvod"].Value.ToString() + "  " +
                    " update    StavkeRNGP set        napravljeno = napravljeno + " + stanje + " where id=" + r.Cells["id"].Value.ToString() + " ";

                    metode.pristup_bazi(update);
                }
                metode.pristup_bazi("UPDATE RadniNalogGP SET status = " + cbReal.SelectedValue + ", datumPromene=getdate() where id = " + idNalogGP + " ");
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
                        //  uProiz = int.Parse(r.Cells["kolicina"].Value.ToString()) - napravljeno;
                        uProiz = stanje;
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
                        //update = " UPDATE GotovProizvod SET  stanje = stanje + " + stanje + " , uProizvodnji = uProizvodnji -" + uProiz + " where id =" + r.Cells["idProizvod"].Value.ToString() + "  " +
                        update = " UPDATE GotovProizvod SET  stanje = stanje + " + stanje + " , uProizvodnji = uProizvodnji -" + uProiz + " where id =" + r.Cells["idProizvod"].Value.ToString() + "  " +
                            " update RadniNalogGP SET  datumRealizacije=getdate() where id = " + idNalogGP + " " +
                             " update    StavkeRNGP set        napravljeno = napravljeno + " + stanje + " where id=" + r.Cells["id"].Value.ToString() + " ";

                        metode.pristup_bazi(update);

                        //skida sa stanja 
                        DataTable dt = metode.baza_upit(" SELECT idPoluProizvod, kolicinaPP FROM Sastavnica WHERE        (idGotovProzivod = " + r.Cells["idProizvod"].Value.ToString() + ")");
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow sr in dt.Rows)
                            {
                                int kolicina = int.Parse(sr["kolicinaPP"].ToString());
                                string idPP = sr["idPoluProizvod"].ToString();
                                int pomStanje = (stanje + int.Parse(tbSkart.Text)) * kolicina;


                                metode.pristup_bazi("update poluproizvodi set stanje = stanje -" + pomStanje + " where id = " + idPP + "");
                            }
                        }
                        DataTable dtGP = metode.baza_upit(" SELECT  idGP, kolicinaGP FROM    SastavnicaGP_GP WHERE        (idGotovProzivod = " + r.Cells["idProizvod"].Value.ToString() + ")");
                        if (dtGP.Rows.Count > 0)
                        {
                            foreach (DataRow sr in dtGP.Rows)
                            {
                                int kolicina = int.Parse(sr["kolicinaGP"].ToString());
                                string idPP = sr["idGP"].ToString();
                                int pomStanje = (stanje + int.Parse(tbSkart.Text)) * kolicina;


                                metode.pristup_bazi("update GotovProizvod set stanje = stanje -" + pomStanje + " where id = " + idPP + "");
                            }
                        }
                        DataTable dtSir = metode.baza_upit(" SELECT  idSirovina, kolicinaSir FROM    SastavnicaGP_sirovina WHERE        (idGotovProzivod = " + r.Cells["idProizvod"].Value.ToString() + ")");
                        if (dtSir.Rows.Count > 0)
                        {
                            foreach (DataRow sr in dtSir.Rows)
                            {
                                int kolicina = int.Parse(sr["kolicinaSir"].ToString());
                                string idPP = sr["idSirovina"].ToString();
                                int pomStanje = (stanje + int.Parse(tbSkart.Text)) * kolicina;


                                metode.pristup_bazi("update Sirovina set stanje = stanje -" + pomStanje + " where id = " + idPP + "");
                            }
                        }
                        ////////
                    }
                }
                else if (cbReal.SelectedValue.ToString() == "2")
                {
                    foreach (DataGridViewRow r in dgvStavkeNaloga.Rows)
                    {
                        stanje = int.Parse(tbNapravljeno.Text);// -napravljeno;

                        update = " UPDATE GotovProizvod SET  stanje = stanje + " + stanje + " , uProizvodnji = uProizvodnji -" + stanje + " where id =" + r.Cells["idProizvod"].Value.ToString() + "  " +
                        " update    StavkeRNGP set        napravljeno = napravljeno + " + stanje + " where id=" + r.Cells["id"].Value.ToString() + " ";

                        metode.pristup_bazi(update);
                     
                        //skida sa stanja
                        DataTable dt = metode.baza_upit(" SELECT idPoluProizvod, kolicinaPP FROM Sastavnica WHERE        (idGotovProzivod = " + r.Cells["idProizvod"].Value.ToString() + ")");
                        if (dt.Rows.Count > 0)
                        {
                            foreach (DataRow sr in dt.Rows)
                            {
                                int kolicina = int.Parse(sr["kolicinaPP"].ToString());
                                string idPP = sr["idPoluProizvod"].ToString();
                                int pomStanje = (stanje + int.Parse(tbSkart.Text)) * kolicina;


                                metode.pristup_bazi("update poluproizvodi set stanje = stanje -" + pomStanje + " where id = " + idPP + "");
                            }
                        }
                        DataTable dtGP = metode.baza_upit(" SELECT  idGP, kolicinaGP FROM    SastavnicaGP_GP WHERE        (idGotovProzivod = " + r.Cells["idProizvod"].Value.ToString() + ")");
                        if (dtGP.Rows.Count > 0)
                        {
                            foreach (DataRow sr in dtGP.Rows)
                            {
                                int kolicina = int.Parse(sr["kolicinaGP"].ToString());
                                string idPP = sr["idGP"].ToString();
                                int pomStanje = (stanje + int.Parse(tbSkart.Text)) * kolicina;


                                metode.pristup_bazi("update GotovProizvod set stanje = stanje -" + pomStanje + " where id = " + idPP + "");
                            }
                        }
                        DataTable dtSir = metode.baza_upit(" SELECT  idSirovina, kolicinaSir FROM    SastavnicaGP_sirovina WHERE        (idGotovProzivod = " + r.Cells["idProizvod"].Value.ToString() + ")");
                        if (dtSir.Rows.Count > 0)
                        {
                            foreach (DataRow sr in dtSir.Rows)
                            {
                                double kolicina = double.Parse(sr["kolicinaSir"].ToString());
                                string idPP = sr["idSirovina"].ToString();
                                double pomStanje = (stanje + int.Parse(tbSkart.Text)) * kolicina;


                                metode.pristup_bazi("update Sirovina set stanje = stanje -'" + pomStanje.ToString().Replace(",", ".") + "' where id = " + idPP + "");
                            }
                        }
                        ////////
                    }
                }
                else
                {           //brojStavki
                    for (int i = brojStavki; i < dgvStavkeNaloga.Rows.Count; i++)
                    {
                        stanje = int.Parse(dgvStavkeNaloga.Rows[i].Cells["kolicina"].Value.ToString());

                        update = " UPDATE GotovProizvod SET   uProizvodnji = uProizvodnji +" + stanje + " where id =" + dgvStavkeNaloga.Rows[i].Cells["idProizvod"].Value.ToString() + "  ";

                        metode.pristup_bazi(update);
                    }

                }
                metode.pristup_bazi("UPDATE RadniNalogGP SET status = " + cbReal.SelectedValue + ", datumPromene=getdate() where id = " + idNalogGP + " ");

                //ubacivanje podataka u napredakGP
                if (tbNapravljeno.Text != "0" || tbSkart.Text != "0")
                {
                    DateTime datumSmena = dtpSmena.Value;
                    string datumSm = datumSmena.Day.ToString() + "." + datumSmena.Month.ToString() + "." + datumSmena.Year.ToString();

                    int skart = int.Parse(tbSkart.Text);
                    string unesiNapredak = "INSERT INTO      napredakGP( idStavkeGP, datum, brojRadnika,smena,  skart, dobriKomadi,minuti) " +
                                           " VALUES        (" + dgvStavkeNaloga.CurrentRow.Cells["id"].Value.ToString() + ",convert(datetime,'" + datumSm + "',105),N'" + tbBrojRadnika.Text + "'," + cbSmena.SelectedValue + "," + tbSkart.Text + "," + tbNapravljeno.Text + ", " + tbMinuti.Text + "*60)";

                    metode.pristup_bazi(unesiNapredak);
                }
            }
            metode.pristup_bazi(" UPDATE GotovProizvod SET Stanje =0 WHERE  (Stanje < 0); UPDATE poluproizvodi SET  Stanje =0 WHERE (Stanje < 0); UPDATE sirovina SET  Stanje =0 WHERE (Stanje < 0)");
            prikaz(idNalogGP);
            brojStavki = dgvStavkeNaloga.Rows.Count;
            dgvStavkeNaloga_CellClick(null, null);
            MessageBox.Show("Uspesno sacuvano.", "Uspesno");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Da li ste sigurni da zelite napraviti novi Nalog za PP", "Upozorenje", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                idNalogPublic.kolicina = int.Parse(dgvPP.CurrentRow.Cells["Potrebna kolicina"].Value.ToString());
                FormRNPP f1 = new FormRNPP(int.Parse(dgvPP.CurrentRow.Cells["id"].Value.ToString()), int.Parse(idNalogGP));
                f1.ShowDialog();

                dgvStavkeNaloga_CellClick(null, null);
            }
        }

        private void btnObrisiStavku_Click(object sender, EventArgs e)
        {
            string obrisi = " delete from stavkeRNGP where id =" + dgvStavkeNaloga.CurrentRow.Cells["id"].Value.ToString() + " ";

            metode.pristup_bazi(obrisi);
            ucitajStavkeNaloga();
            gbStanjeProizvoda.Visible = false;
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (idNalogGP != "" || UnosNaloga())
            {

                DateTime datum = dtpDatum.Value;
                DateTime rok = dtpRok.Value;
                string da = datum.Day.ToString() + "." + datum.Month.ToString() + "." + datum.Year.ToString();
                string datumRok = rok.Day.ToString() + "." + rok.Month.ToString() + "." + rok.Year.ToString();

                metode.pristup_bazi(" UPDATE  RadniNalogGP SET  rok = convert(datetime,'" + datumRok + "',105),   datum = convert(datetime,'" + da + "',105), napomena =N'" + tbNapomena.Text + "' where id = " + idNalogGP + "");

            }
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

        private void btnRezervisi_Click(object sender, EventArgs e)
        {
            if (tbRezervisano.Text == "") tbRezervisano.Text = "0";

            int rezerisanoPom = int.Parse(tbRezervisano.Text) - int.Parse(dgvPP.CurrentRow.Cells["RezervisanoIzOvogNaloga"].Value.ToString());


            string rezer = " UPDATE        poluproizvodi SET             Rezervisano = Rezervisano + " + rezerisanoPom + " where id =" + dgvPP.CurrentRow.Cells["id"].Value.ToString() + " ; " +
                " delete from RezervisanoPP where idRNGP=" + idNalogGP + " and IDPP=" + dgvPP.CurrentRow.Cells["id"].Value.ToString() + " " +
                            " INSERT  INTO  RezervisanoPP(idRNGP, IDPP, rezervisano) VALUES        (" + idNalogGP + "," + dgvPP.CurrentRow.Cells["id"].Value.ToString() + "," + tbRezervisano.Text + ")   ";

            metode.pristup_bazi(rezer);

            dgvStavkeNaloga_CellClick(null, null);
        }

        private void dgvPP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                tbRezervisano.Text = dgvPP.CurrentRow.Cells["RezervisanoIzOvogNaloga"].Value.ToString();
            }
            catch { }
        }

        private void btnIzaberiRL_Click(object sender, EventArgs e)
        {

            string server = @"\\192.168.0.22\radne_liste\";
            if (idNalogGP == "")
            {
                MessageBox.Show("Prvo unesite RN GP pa onda dodajte dokument");
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
                    naziv = "Radna lista RNGP " + tbBrojNaloga.Text + "-" + dtpDatum.Value.Year.ToString() + fileFaktura.FileName.Substring(fileFaktura.FileName.LastIndexOf(@"."), (fileFaktura.FileName.Length - fileFaktura.FileName.LastIndexOf(@".")));
                   // File.Copy(@tbRL.Text, @"d:\RadneListe\" + naziv, false);
                    // @"\\ibm-server\FinKnjigovodstvo\"
                    File.Copy(@tbRL.Text, server + naziv, false);
                  

                }
                catch
                {
                    if (MessageBox.Show("Postoji fajl sa tim imenom. Želite li da ga presnimite?", "Promenite ime fajla", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                    {
                        //File.Copy(@tbRL.Text, @"d:\RadneListe\" + naziv, true);
                        File.Copy(@tbRL.Text, server + naziv, true);


                    }
                    else
                    {
                        return;
                    }
                }
                //putanja = @"d:\RadneListe\" + naziv;
                putanja = server + naziv;

              //  metode.pristup_bazi(" update RadniNalogGP set putanja = N'd:\\RadneListe\\" + naziv + "' where id=" + idNalogGP + "");
                metode.pristup_bazi(" update RadniNalogGP set putanja = N'"+server+"" + naziv + "' where id=" + idNalogGP + "");


                tbRL.Text = putanja.Substring(putanja.LastIndexOf(@"\"), putanja.Length - putanja.LastIndexOf(@"\"));
                
                btnStampaDokument.Visible = true;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable dataBrojac = metode.baza_upit("select putanja putanja FROM            RadniNalogGP where id=" + idNalogGP + "");

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

        private void FormRNGP_FormClosed(object sender, FormClosedEventArgs e)
        {
            //FormNoviNalog fn = new FormNoviNalog(idNalogPublic.idNalog.ToString());
            //Form1 f1 = new Form1();
            //f1.Show();




        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (idNalogGP == "")
            {
                MessageBox.Show("Ne postoji nalog. Prvo sacuvajte nalog ili odaberite vec postojeci.");
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Da li ste sigurni da zelite da obrisete RN GP?", "Brisanje RN GP", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //sredjuje stanje
                DataTable dtNalog = metode.baza_upit("SELECT        dbo.StavkeRNGP.idRNGP, dbo.StavkeRNGP.kolicina - dbo.StavkeRNGP.napravljeno AS uPro, dbo.StavkeRNGP.idProizvod, dbo.RezervisanoPP.IDPP, dbo.RezervisanoPP.rezervisano " +
                                                    " FROM            dbo.RadniNalogGP INNER JOIN " +
                         " dbo.StavkeRNGP ON dbo.RadniNalogGP.id = dbo.StavkeRNGP.idRNGP INNER JOIN " +
                      "    dbo.RezervisanoPP ON dbo.StavkeRNGP.idRNGP = dbo.RezervisanoPP.idRNGP " +
                                " WHERE        (dbo.StavkeRNGP.idRNGP = " + idNalogGP + ")");
                foreach (DataRow r in dtNalog.Rows)
                {

                    int rezervisano = int.Parse(r["rezervisano"].ToString());
                    string idPP = r["IDPP"].ToString();
                    string idRNGP = r["idRNGP"].ToString();

                    metode.pristup_bazi(" update Poluproizvodi set Rezervisano = Rezervisano - " + rezervisano + " where id = " + idPP + "" +
                         " update rezervisanopp set rezervisano = 0 where idRNGP =" + idRNGP + " and idpp = " + idPP + "");

                }
                metode.pristup_bazi(" update RadniNalogGP set obrisan = 1 where id = " + idNalogGP + "" +
                                    " update gotovProizvod set uProizvodnji = uProizvodnji - " + dtNalog.Rows[0]["uPro"].ToString() + " where id = " + dtNalog.Rows[0]["idProizvod"].ToString() + "");
            }
        }

        private void btnStampaRL_Click(object sender, EventArgs e)
        {
            if (idNalogGP == "")
            {
                MessageBox.Show("Ne postoji nalog. Prvo sacuvajte nalog ili odaberite vec postojeci.");
                return;
            }

            makeReport("C:\\Program files\\IT\\Plamen\\RadnaListaGP.rpt");
            SetParameters(idNalogGP);

            Report rep = new Report(ReportDoc);
            rep.ShowDialog();

        }

        private void SetParameters(string idN)
        {
            ReportDoc.SetParameterValue("idNaloga", idN);
          
        }
        private void makeReport(string ReportFile)
        {
            ReportDoc = new ReportDocument();
            TextReader textReader = new StreamReader("c:\\Program files\\IT\\Plamen\\dblogon.txt");
            string uid = textReader.ReadLine();
            string pwd = textReader.ReadLine();
            string server = textReader.ReadLine();
            string db = textReader.ReadLine();
            textReader.Close();

            ReportDoc.Load(ReportFile);
            ReportDoc.SetDatabaseLogon(uid, pwd, server, db);
        }

        private void btnStampa_Click(object sender, EventArgs e)
        {
            if (idNalogGP == "")
            {
                MessageBox.Show("Ne postoji nalog. Prvo sacuvajte nalog ili odaberite vec postojeci.");
                return;
            }

            makeReport("C:\\Program files\\IT\\Plamen\\NalogGP.rpt");

            SetParameters((idNalogGP));

            Report rep = new Report(ReportDoc);
            rep.ShowDialog();
        }

        private void btnRezervisiGP_Click(object sender, EventArgs e)
        {
            if (tbRezervisanoGP.Text == "") tbRezervisanoGP.Text = "0";

            int rezerisanoPom = int.Parse(tbRezervisanoGP.Text) - int.Parse(dgvPP_GP.CurrentRow.Cells["RezervisanoIzOvogNaloga"].Value.ToString());


            string rezer = " UPDATE        GotovProizvod SET             Rezervisano = Rezervisano + " + rezerisanoPom + " where id =" + dgvPP_GP.CurrentRow.Cells["id"].Value.ToString() + " ; " +
                " delete from  RezervisanoGP_GP where idRNGP=" + idNalogGP + " and IDGP=" + dgvPP_GP.CurrentRow.Cells["id"].Value.ToString() + " " +
                            " INSERT  INTO  RezervisanoGP_GP(idRNGP, IDGP, rezervisano) VALUES        (" + idNalogGP + "," + dgvPP_GP.CurrentRow.Cells["id"].Value.ToString() + "," + tbRezervisanoGP.Text + ")   ";

            metode.pristup_bazi(rezer);

            dgvStavkeNaloga_CellClick(null, null);
        }

        private void btnRezervisiSirovina_Click(object sender, EventArgs e)
        {
            if (tbRezervisanoSir.Text == "") tbRezervisanoSir.Text = "0";

            double rezervisano = double.Parse(tbRezervisanoSir.Text.Replace(".",","));

            double rezerisanoPom = rezervisano - double.Parse(dgvGP_Sir.CurrentRow.Cells["RezervisanoIzOvogNaloga"].Value.ToString());


            string rezer = " UPDATE        Sirovina SET             Rezervisano = Rezervisano + '" + rezerisanoPom.ToString().Replace(",",".") + "' where id =" + dgvGP_Sir.CurrentRow.Cells["id"].Value.ToString() + " ; " +
                " delete from  RezervisanoGP_SIR where idRNGP=" + idNalogGP + " and IDSirovina=" + dgvGP_Sir.CurrentRow.Cells["id"].Value.ToString() + " " +
                            " INSERT  INTO  RezervisanoGP_SIR(idRNGP, IDSirovina, rezervisano) VALUES        (" + idNalogGP + "," + dgvGP_Sir.CurrentRow.Cells["id"].Value.ToString() + ",'" + rezervisano.ToString().Replace(",", ".") + "')   ";

            metode.pristup_bazi(rezer);

            dgvStavkeNaloga_CellClick(null, null);
        }

        private void dgvPP_GP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                tbRezervisanoGP.Text = dgvPP_GP.CurrentRow.Cells["RezervisanoIzOvogNaloga"].Value.ToString();
            }
            catch { }
        }

        private void dgvGP_Sir_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                tbRezervisanoSir.Text = dgvGP_Sir.CurrentRow.Cells["RezervisanoIzOvogNaloga"].Value.ToString();
            }
            catch { }
        }

    }
}
