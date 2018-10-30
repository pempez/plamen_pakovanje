using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using System.Transactions;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using System.Globalization;

namespace plamen
{
    public partial class FormPackingList : Form
    {
        Metode metode = new Metode();
        string idNalog = "";
        int brojGPuKutiji = 0;
        int brojGP = 0;
        ReportDocument ReportDoc;



        public FormPackingList()
        {
            InitializeComponent();
           
            ucitajKomitente();
           
            ucitajPalete();
            ucitajKutije();
            ucitajProizvode();

            ucitajOdgovornoLice();
            ucitajparitet();

            tbBrojNaloga.Text = (maxBrNaloga() + 1).ToString();

        }

        public FormPackingList(int id)
        {
            InitializeComponent();
            ucitajProizvode();
            ucitajKomitente();
            ucitajKutije();
            ucitajPalete();
            ucitajOdgovornoLice();
            ucitajparitet();

            idNalog = id.ToString();

            ucitajNalog(id);

        }

        public GroupBox GetGroupBox()
        {
            return groupBox1;
        }

        private int maxBrNaloga()
        {
            int broj = 0;
            DataTable dt = (metode.baza_upit(" select rednibroj from PAK_NALOG order by rednibroj desc"));

            if (dt.Rows.Count > 0)
            {
                broj = int.Parse(dt.Rows[0]["rednibroj"].ToString());
            }
            return broj;
        }

        private void ucitajNalog(int id)
        {
            string upit = " SELECT       dbo.PAK_NALOG.idOdgovornoLice, dbo.PAK_NALOG.rednibroj,  dbo.PAK_NALOG.komentar,dbo.PAK_NALOG.brojFakture, dbo.PAK_NALOG.paritet, dbo.PAK_NALOG_STAVKE.idNaloga, dbo.PAK_NALOG.redniBroj, dbo.PAK_NALOG.idKupac, dbo.PAK_NALOG_STAVKE.id AS idStavke, dbo.PAK_NALOG_STAVKE.idGP, dbo.PAK_NALOG_STAVKE.kolicina,  " +
                        " dbo.PAK_NALOG_STAVKE.idKutija, dbo.PAK_NALOG_STAVKE.brojKutija, dbo.PAK_NALOG_STAVKE.opis, dbo.PAK_NALOG.maxRedova, dbo.GotovProizvod.masa AS masaGP, dbo.PAK_kutija.masa AS masaKutije " +
                        " FROM            dbo.PAK_NALOG_STAVKE INNER JOIN " +
                         " dbo.PAK_NALOG ON dbo.PAK_NALOG_STAVKE.idNaloga = dbo.PAK_NALOG.id INNER JOIN " +
                        " dbo.GotovProizvod ON dbo.PAK_NALOG_STAVKE.idGP = dbo.GotovProizvod.id INNER JOIN " +
            " dbo.PAK_kutija ON dbo.PAK_NALOG_STAVKE.idKutija = dbo.PAK_kutija.id " +
                          "   WHERE        (dbo.PAK_NALOG_STAVKE.idNaloga = " + id + ")";
            DataTable dt = metode.baza_upit(upit);

            cbKupacSifra.SelectedValue = int.Parse(dt.Rows[0]["idKupac"].ToString());
            cbProizvodSifra.SelectedValue = int.Parse(dt.Rows[0]["idGP"].ToString());
            cbOdgovornoLice.SelectedValue = int.Parse(dt.Rows[0]["idOdgovornoLice"].ToString());

            tbBrojFakture.Text = dt.Rows[0]["brojFakture"].ToString();
            cbParitet.Text = dt.Rows[0]["paritet"].ToString();
            tbKomentar.Text = dt.Rows[0]["komentar"].ToString();
            tbBrojNaloga.Text = dt.Rows[0]["rednibroj"].ToString(); ;

            ucitajPalete(id.ToString());

            ucitajStavke(id.ToString());

            //  tbMaxBrojRedova.Text = (dt.Rows[0]["maxRedova"].ToString());
            // tbMaxBrojRedova_Leave(null, null);

        }

        private void ucitajProizvode()
        {
            DataTable dt = metode.baza_upit("SELECT       id, Sifra, Naziv FROM            GotovProizvod where aktivan=1 order by Naziv");

            cbProizvodSifra.DataSource = dt;
            cbProizvodSifra.DisplayMember = "Sifra";
            cbProizvodSifra.ValueMember = "id";
            cbProizvodSifra.SelectedIndex = 0;

            cbProizvodNaziv.DataSource = dt;
            cbProizvodNaziv.DisplayMember = "Naziv";
            cbProizvodNaziv.ValueMember = "id";
            cbProizvodNaziv.SelectedIndex = 0;

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
        private void ucitajOdgovornoLice()
        {
            DataTable dt = metode.baza_upit("SELECT  id, ime +' '+  prezime as disp FROM   PAK_ODGOVORNA_OSOBA where aktiv=1");

            cbOdgovornoLice.DataSource = dt;
            cbOdgovornoLice.DisplayMember = "disp";
            cbOdgovornoLice.ValueMember = "id";
            cbOdgovornoLice.SelectedIndex = -1;


        }

        private void ucitajKutije()
        {

            DataTable dt = metode.baza_upit(" select id, masa, CAST(sirina AS nvarchar(4)) + 'x' + CAST(visina AS nvarchar(4)) + 'x' + CAST(dubina AS nvarchar(4)) AS display FROM            PAK_kutija where aktiv=1");

            cbVrstaKutije.DataSource = dt;
            cbVrstaKutije.DisplayMember = "display";
            cbVrstaKutije.ValueMember = "id";
            cbVrstaKutije.SelectedIndex = 0;


        }

        private void ucitajPalete()
        {

            DataTable dt = metode.baza_upit(" SELECT  id, masa, CAST(sirina AS nvarchar(4)) + 'x' + CAST(visina AS nvarchar(4)) + 'x' + CAST(dubina AS nvarchar(4)) AS display FROM PAK_PALETA where aktiv=1");

            cbPaleta.DataSource = dt;
            cbPaleta.DisplayMember = "display";
            cbPaleta.ValueMember = "id";
            cbPaleta.SelectedIndex = 0;


        }

        private void izracunaj()
        {
            if (cbProizvodSifra.SelectedValue.ToString() != "-1" && tbBrojKomada.Text != null && tbBrojKomada.Text != "")
            {
                //ucitaj koliko ide u kutiju
                try
                {
                    DataTable dt = metode.baza_upit(" SELECT idGotovProizvod, idKutija, kolicina FROM  PAK_GP_KUTIJA " +
                                     " WHERE        (idGotovProizvod = " + cbProizvodSifra.SelectedValue.ToString() + ") and idKutija=" + cbVrstaKutije.SelectedValue.ToString() + "");


                    brojGPuKutiji = int.Parse(dt.Rows[0]["kolicina"].ToString());
                    //  cbVrstaKutije.SelectedValue = dt.Rows[0]["idKutija"].ToString();
                }
                catch
                {
                    MessageBox.Show("Za GP '" + cbProizvodNaziv.Text + "' nije uneta kolicina koja staje u '" + cbVrstaKutije.Text + "' kutiju");
                    return;
                }


                int broj = brojGP / brojGPuKutiji;
                int ostatak = brojGP % brojGPuKutiji;

                // string puneKutije = broj.ToString() + "-" + brojGPuKutiji.ToString();


                tbCelihKutija.Text = broj.ToString();
                tbCelihKutijaGP.Text = brojGPuKutiji.ToString();

                tbPraznihKutija.Text = "0";
                tbPraznihKutijaGP.Text = "0";

                if (ostatak > 0)
                {
                    broj = broj + 1;
                    //     puneKutije += " + 1 - " + ostatak.ToString();
                    tbPraznihKutija.Text = "1";
                    tbPraznihKutijaGP.Text = ostatak.ToString();
                }
                tbBrojKutija.Text = broj.ToString();

                //koliko paleta treba
                int brojKutijaUosnovi = int.Parse(metode.baza_upit("SELECT brojKutijaUosnovi FROM  dbo.PAK_KUTIJA_PALETA WHERE   (idKutija = " + cbVrstaKutije.SelectedValue.ToString() + ")").Rows[0]["brojKutijaUosnovi"].ToString());

                int brojRedova = broj / brojKutijaUosnovi;
                int ostatakKutija = broj % brojKutijaUosnovi;

                if (ostatakKutija > 0) brojRedova = brojRedova + 1;

                tbPaletaRedova.Text = brojRedova.ToString();
                tbBrojPaleta.Text = "1";
            }



        }

        private void cbProizvodSifra_SelectedValueChanged(object sender, EventArgs e)
        {

            try
            {
                DataTable dtKutije = metode.baza_upit("SELECT idGotovProizvod, idKutija, kolicina " +
                                 " FROM  PAK_GP_KUTIJA WHERE        (idGotovProizvod =" + cbProizvodSifra.SelectedValue.ToString() + ")");

                string idKutije = "0";

                if (dtKutije.Rows.Count > 0)
                {
                    foreach (DataRow r in dtKutije.Rows)
                    {
                        idKutije += ", " + r["idKutija"].ToString();
                    }
                    //DataTable dt = metode.baza_upit(" select id, masa, CAST(sirina AS nvarchar(4)) + 'x' + CAST(visina AS nvarchar(4)) + 'x' + CAST(dubina AS nvarchar(4)) AS display FROM            PAK_kutija where aktiv=1 ");
                    DataTable dt = metode.baza_upit(" select id, masa, CAST(sirina AS nvarchar(4)) + 'x' + CAST(visina AS nvarchar(4)) + 'x' + CAST(dubina AS nvarchar(4)) AS display FROM            PAK_kutija where aktiv=1 and id in(" + idKutije + ")");

                    cbVrstaKutije.DataSource = dt;
                    cbVrstaKutije.DisplayMember = "display";
                    cbVrstaKutije.ValueMember = "id";
                    cbVrstaKutije.SelectedIndex = 0;
                    btnUnesi.Enabled = true;

                    try
                    {
                        izracunaj();
                    }
                    catch { }

                }
                else
                {
                    btnUnesi.Enabled = false;
                    cbVrstaKutije.DataSource = null;
                    MessageBox.Show("Za odabrani Gotov Proizvod nije uneta kolicina koja staje u kutiju!");
                }
            }
            catch { }



        }

        private void tbBrojKomada_Leave(object sender, EventArgs e)
        {
            try
            {
                brojGP = int.Parse(tbBrojKomada.Text);
                izracunaj();
            }
            catch { }
        }

        private void cbVrstaKutije_SelectedValueChanged(object sender, EventArgs e)
        {
          //  ucitajPalete();
            try
            {
                DataTable dtPalete = metode.baza_upit("SELECT idKutija, idPaleta, brojKutijaUosnovi " +
                                 " FROM  PAK_KUTIJA_PALETA WHERE        (idKutija  =" + cbVrstaKutije.SelectedValue.ToString() + ")");

                string idPalete = "0";

                if (dtPalete.Rows.Count > 0)
                {
                    foreach (DataRow r in dtPalete.Rows)
                    {
                        idPalete += ", " + r["idPaleta"].ToString();
                    }
                    DataTable dt = metode.baza_upit(" SELECT  id, masa, CAST(sirina AS nvarchar(4)) + 'x' + CAST(visina AS nvarchar(4)) + 'x' + CAST(dubina AS nvarchar(4)) AS display FROM PAK_PALETA where aktiv=1 and id in(" + idPalete + ")");
                    if (dt.Rows.Count > 0)
                    {
                        cbPaleta.DataSource = dt;
                        cbPaleta.DisplayMember = "display";
                        cbPaleta.ValueMember = "id";
                        cbPaleta.SelectedIndex = 0;

                        try
                        {
                            izracunaj();
                        }
                        catch { }
                        btnUnesi.Enabled = true;
                    }
                    else
                    {
                        btnUnesi.Enabled = false;
                        cbPaleta.DataSource = null;
                        MessageBox.Show("Za odabranu Kutiju nije uneta kolicina koja staje na paletu!");
                    }
                }
                else
                {
                    cbPaleta.DataSource = null;
                    MessageBox.Show("Za odabranu Kutiju nije uneta kolicina koja staje na paletu!");
                    btnUnesi.Enabled = false;
                }
            }
            catch { }
        }


        private void btnUnesi_Click(object sender, EventArgs e)
        {
            if (dgvPalete.Rows.Count == 0)
            {
                MessageBox.Show("Prvo unesite paletu");
                return;
            }
            if (dgvPalete.CurrentRow == null)
            {
                MessageBox.Show("Prvo oznacite  paletu");
                return;
            }

            //uneti u bazu
            if (idNalog != "" || UnosNaloga())
            {
                string opis = "";
                if (tbPraznihKutijaGP.Text == "0")
                {
                    opis = tbCelihKutija.Text + "x" + tbCelihKutijaGP.Text ;
                }
                else
                {
                    opis = tbCelihKutija.Text + "x" + tbCelihKutijaGP.Text + " + 1x" + tbPraznihKutijaGP.Text;
                }
                string qUnesi = "INSERT  INTO              PAK_NALOG_STAVKE( idNaloga, idGP, kolicina, idKutija, brojKutija,opis, idNALOG_PALETA) " +
                                " VALUES        (" + idNalog + "," + cbProizvodSifra.SelectedValue.ToString() + "," + tbBrojKomada.Text + "," + cbVrstaKutije.SelectedValue.ToString() + "," + tbBrojKutija.Text + ",N'" + opis + "', " + dgvPalete.CurrentRow.Cells["id"].Value.ToString() + " )";

                metode.pristup_bazi(qUnesi);

                // ucitajStavke(idNalog);
                ucitajStavkePoPaleti(dgvPalete.CurrentRow.Cells["id"].Value.ToString());
                //tbMaxBrojRedova_Leave(null, null);
                sacuvajNalog();
            }

            btnSacuvaj_Click(null, null);

        }

        private bool UnosNaloga()
        {
            if (tbBrojNaloga.Text == "")
            {
                MessageBox.Show("Morate odabrati nalog !!!", "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            string idPom = "0";


            //DateTime datum = dtpDatum.Value;
            //DateTime rok = dtpRok.Value;
            //string da = datum.Day.ToString() + "." + datum.Month.ToString() + "." + datum.Year.ToString();
            //string datumRok = rok.Day.ToString() + "." + rok.Month.ToString() + "." + rok.Year.ToString();
            string query = "INSERT  INTO  PAK_NALOG( redniBroj, idKupac, brojFakture,paritet,komentar, idOdgovornoLice) VALUES        (" + tbBrojNaloga.Text + "," + cbKupacSifra.SelectedValue.ToString() + ",N'" + tbBrojFakture.Text + "',N'" + cbParitet.Text + "',N'" + tbKomentar.Text + "'," + cbOdgovornoLice.SelectedValue + ")";

            metode.pristup_bazi(query);

            string queryVrati = " SELECT ID FROM  PAK_NALOG WHERE redniBroj = N'" + tbBrojNaloga.Text + "'";
            idNalog = metode.baza_upit(queryVrati).Rows[0]["id"].ToString();

            metode.pristup_bazi("INSERT INTO   PAK_NALOG_PALETA(idNalog, idPalete) VALUES        (" + idNalog + ",1)");

            ucitajPalete(idNalog);
            return true;
        }

        private void ucitajStavke(string idNal)
        {
            try
            {
                string paleta = dgvPalete.CurrentRow.Cells["id"].Value.ToString();
            }
            catch
            {
            }
            string query = "SELECT          dbo.PAK_NALOG_STAVKE.idGP, dbo.PAK_NALOG_STAVKE.idKutija, dbo.PAK_NALOG_STAVKE.id, dbo.GotovProizvod.Sifra, " +
            " dbo.PAK_NALOG_STAVKE.kolicina, CAST(dbo.PAK_kutija.sirina AS nvarchar(4)) + 'x' + CAST(dbo.PAK_kutija.visina AS nvarchar(4)) + 'x' + CAST(dbo.PAK_kutija.dubina AS nvarchar(4)) AS kutija, dbo.PAK_NALOG_STAVKE.brojKutija,dbo.PAK_NALOG_STAVKE.opis, " +
            "  cast(dbo.GotovProizvod.masa * dbo.PAK_NALOG_STAVKE.kolicina as decimal) /1000  AS [ukupna masa proizovda kg], cast(dbo.PAK_kutija.masa * dbo.PAK_NALOG_STAVKE.brojKutija as decimal)/1000  AS [ukupna masa kutija kg]" +
                    " FROM            dbo.PAK_NALOG_STAVKE INNER JOIN dbo.GotovProizvod ON dbo.PAK_NALOG_STAVKE.idGP = dbo.GotovProizvod.id INNER JOIN " +
                    " dbo.PAK_kutija ON dbo.PAK_NALOG_STAVKE.idKutija = dbo.PAK_kutija.id" +
                    " WHERE        (dbo.PAK_NALOG_STAVKE.idNaloga = " + idNal + ")";

            DataTable dt = metode.baza_upit(query);

            dgvStavke.DataSource = dt;
            dgvStavke.Columns["id"].Visible = false;
            dgvStavke.Columns["idGP"].Visible = false;
            dgvStavke.Columns["idKutija"].Visible = false;
            dgvStavke.Columns["ukupna masa proizovda kg"].DefaultCellStyle.Format = "N2";
            dgvStavke.Columns["ukupna masa kutija kg"].DefaultCellStyle.Format = "N2";

            dgvStavke.Columns["ukupna masa proizovda kg"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvStavke.Columns["ukupna masa kutija kg"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            //koliko paleta treba
            int brojKutija = int.Parse(metode.baza_upit("SELECT SUM(brojKutija) AS br FROM PAK_NALOG_STAVKE WHERE  (idNaloga = " + idNal + ")").Rows[0]["br"].ToString());
            int brojKutijaUosnovi = int.Parse(metode.baza_upit("SELECT brojKutijaUosnovi FROM  dbo.PAK_KUTIJA_PALETA WHERE   (idKutija = " + cbVrstaKutije.SelectedValue.ToString() + ")").Rows[0]["brojKutijaUosnovi"].ToString());

            lblUkupnoKutija.Text = "Ukupan broj kutija: " + brojKutija.ToString();

            int brojRedova = brojKutija / brojKutijaUosnovi;
            int ostatakKutija = brojKutija % brojKutijaUosnovi;

            if (ostatakKutija > 0) brojRedova = brojRedova + 1;

            tbUkupnoRedova.Text = brojRedova.ToString();
            tbUkupnoPaleta.Text = "1";
            tbUkupnoPaletaPraznih.Text = "0";
            tbUkupnoRedovaPraznih.Text = "0";

            //ukupna tezina
            double ukupnaMasaGP = 0;
            double ukupnaMasaKutija = 0;
            foreach (DataGridViewRow r in dgvStavke.Rows)
            {
                ukupnaMasaGP += double.Parse(r.Cells["ukupna masa proizovda kg"].Value.ToString());
                ukupnaMasaKutija += double.Parse(r.Cells["ukupna masa kutija kg"].Value.ToString());
            }

            tbUkupnaMasaGP.Text = ukupnaMasaGP.ToString();
            tbUkupnaMasaKutija.Text = ukupnaMasaKutija.ToString();

        }

        private void tbBrojNaloga_Leave(object sender, EventArgs e)
        {
            tbMaxBrojRedova.Text = "";
            DataTable dt = metode.baza_upit(" SELECT  id, redniBroj, idKupac,brojFakture, paritet FROM PAK_NALOG WHERE   (redniBroj = " + tbBrojNaloga.Text + ")");
            if (dt.Rows.Count > 0)
            {
                idNalog = (dt.Rows[0]["id"].ToString());
                ucitajNalog(int.Parse(idNalog));
                dgvPalete.Rows[0].Selected = true;
                dgvPalete_Click(null, null);

                dgvStavke.Rows[0].Selected = true;
                dgvStavke_CellClick(null, null);
            }
            else
            {
                ocisti();
            }
        }

        private void ocisti()
        {
            idNalog = "";
            dgvStavke.DataSource = null;
            cbKupacSifra.SelectedValue = -1;
            cbKupacNaziv.SelectedValue = -1;
            cbProizvodNaziv.SelectedValue = -1;
            cbProizvodSifra.SelectedValue = -1;
            tbBrojKomada.Text = "0";
            tbUkupnoPaleta.Text = "0";
            tbUkupnoRedova.Text = "0";
            dgvPalete.DataSource = null;
            cbParitet.Text = "";
            tbBrojFakture.Text = "";
            tbKomentar.Text = "";
        }

        private void tbMaxBrojRedova_Leave(object sender, EventArgs e)
        {

            if (tbMaxBrojRedova.Text != "" && tbMaxBrojRedova.Text != "0")
            {

                try
                {
                    int.Parse(tbMaxBrojRedova.Text);
                }
                catch
                {
                    MessageBox.Show("Maksimalni broj redova mora biti iskazan celim brojem");
                    return;
                }

                ucitajStavke(idNalog);
                int palete = int.Parse(tbUkupnoPaleta.Text);
                int redova = int.Parse(tbUkupnoRedova.Text);

                int max = int.Parse(tbMaxBrojRedova.Text);

                if (max < redova)
                {
                    int pomPal = redova / max;
                    int pomRed = redova % max;
                    tbUkupnoRedovaPraznih.Text = "0";
                    tbUkupnoPaletaPraznih.Text = "0";
                    if (pomPal > 0 && pomRed > 0)
                    {
                        tbUkupnoRedovaPraznih.Text = pomRed.ToString();
                        tbUkupnoPaletaPraznih.Text = "1";


                    }

                    tbUkupnoPaleta.Text = pomPal.ToString();
                    tbUkupnoRedova.Text = tbMaxBrojRedova.Text;

                    kubikaza();
                }
            }
            else
            {
                ucitajStavke(idNalog);
            }

        }

        private void kubikaza()
        {
            double kubika2 = double.Parse(dgvPalete.CurrentRow.Cells["kubika2"].Value.ToString());
            double kubika = kubika2 * double.Parse(tbUkupnaVisina.Text);
            kubika = kubika / 1000000000;
            tbUkupnoKubika.Text = kubika.ToString();



            //    int brojPunihPalete = int.Parse(tbUkupnoPaleta.Text);
            //    int brojPunihRedova = int.Parse(tbUkupnoRedova.Text);
            //    int brojKutijaUosnovi = int.Parse(metode.baza_upit("SELECT brojKutijaUosnovi FROM  dbo.PAK_KUTIJA_PALETA WHERE   (idKutija = " + cbVrstaKutije.SelectedValue.ToString() + ")").Rows[0]["brojKutijaUosnovi"].ToString());


            //    //kubika
            //    string qKubikaPunih = "SELECT        " + brojKutijaUosnovi + " * CAST(dbo.PAK_kutija.sirina * dbo.PAK_kutija.visina * dbo.PAK_kutija.dubina AS decimal) / 1000000000 AS zapreminaKutije, CAST(dbo.PAK_PALETA.sirina * dbo.PAK_PALETA.visina * dbo.PAK_PALETA.dubina AS decimal)  / 1000000000 AS zapreminaPalete " +
            //                        " FROM            dbo.PAK_KUTIJA_PALETA INNER JOIN   dbo.PAK_kutija ON dbo.PAK_KUTIJA_PALETA.idKutija = dbo.PAK_kutija.id INNER JOIN " +
            //                        " dbo.PAK_PALETA ON dbo.PAK_KUTIJA_PALETA.idPaleta = dbo.PAK_PALETA.id" +
            //                        " WHERE        (dbo.PAK_KUTIJA_PALETA.idKutija = " + cbVrstaKutije.SelectedValue.ToString() + ") AND (dbo.PAK_KUTIJA_PALETA.idPaleta = 1) ";
            //    DataTable dt = metode.baza_upit(qKubikaPunih);

            //    double kubikaPoPunojPaleti = ((double.Parse(dt.Rows[0]["zapreminaKutije"].ToString())) * brojPunihRedova) + double.Parse(dt.Rows[0]["zapreminaPalete"].ToString());
            //    // lblUkupnoKubikaCelih.Text = "Ukupno kubika po paleti: " + kubikaPoPunojPaleti.ToString();

            //    int brojPraznihPalete = int.Parse(tbUkupnoPaletaPraznih.Text);
            //    int brojPraznihRedova = int.Parse(tbUkupnoRedovaPraznih.Text);

            //    double kubikaPoPraznojPaleti = (double.Parse(dt.Rows[0]["zapreminaKutije"].ToString()) + double.Parse(dt.Rows[0]["zapreminaPalete"].ToString())) * brojPraznihRedova;
            //    // lblUkupnoKubikaPrazna.Text = "Ukupno kubika po paleti: " + kubikaPoPraznojPaleti.ToString();
            //    tbUkupnoKubika.Text = kubikaPoPunojPaleti.ToString();


        }
        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            string insert = "UPDATE  PAK_NALOG SET  idOdgovornoLice=" + cbOdgovornoLice.SelectedValue + ", komentar=N'" + tbKomentar.Text + "', redniBroj =" + tbBrojNaloga.Text + ", idKupac =" + cbKupacSifra.SelectedValue + ",  brojFakture =N'" + tbBrojFakture.Text + "', paritet =N'" + cbParitet.Text + "' " +
                        " where id = " + idNalog + "";
            metode.pristup_bazi(insert);
            sacuvajNalog();

            ucitajNalog(int.Parse(idNalog));
            MessageBox.Show("Uspesno sacuvano");
        }

        private void sacuvajNalog()
        {
            double neto = double.Parse(tbUkupnaMasaGP.Text) * 1000;
            double bruto = double.Parse(tbUkupnaMasaKutija.Text) * 1000 + neto;
            string update = "UPDATE     PAK_NALOG_PALETA SET visina=" + tbUkupnaVisina.Text + ",   masaNeto =N'" + (neto) + "', masaBruto =N'" + bruto + "', kubikaza =N'" + tbUkupnoKubika.Text + "' " +
                                " WHERE        (id =" + dgvPalete.CurrentRow.Cells["id"].Value.ToString() + ")";
            metode.pristup_bazi(update);

        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            string obrisi = " DELETE FROM   PAK_NALOG_STAVKE WHERE   id  =" + dgvStavke.CurrentRow.Cells["id"].Value.ToString() + " ";

            metode.pristup_bazi(obrisi);
            //  ucitajStavke(idNalog);
            ucitajStavkePoPaleti(dgvPalete.CurrentRow.Cells["id"].Value.ToString());

            //   tbMaxBrojRedova_Leave(null, null);
        }

        private void dgvStavke_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvStavke.CurrentRow != null)
            {
                cbProizvodSifra.SelectedValue = dgvStavke.CurrentRow.Cells["idGP"].Value.ToString();
                cbProizvodNaziv.SelectedValue = dgvStavke.CurrentRow.Cells["idGP"].Value.ToString();
                tbBrojKomada.Text = dgvStavke.CurrentRow.Cells["kolicina"].Value.ToString();
                cbVrstaKutije.SelectedValue = dgvStavke.CurrentRow.Cells["idKutija"].Value.ToString();

                tbBrojKomada_Leave(null, null);



            }
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (dgvStavke.CurrentRow != null)
            {
                string idStavke = dgvStavke.CurrentRow.Cells["id"].Value.ToString();
                string opis = tbCelihKutija.Text + "x" + tbCelihKutijaGP.Text + " + 1x" + tbPraznihKutijaGP.Text;


                string qUpdate = "UPDATE  PAK_NALOG_STAVKE SET   idGP =" + cbProizvodSifra.SelectedValue.ToString() + ",  kolicina = " + tbBrojKomada.Text + ", " +
                    " idKutija =" + cbVrstaKutije.SelectedValue.ToString() + ", brojKutija = " + tbBrojKutija.Text + ", opis = N'" + opis + "'  WHERE        (id = " + idStavke + ")";

                metode.pristup_bazi(qUpdate);

                //ucitajStavke(idNalog);

                //tbMaxBrojRedova_Leave(null, null);
                try
                {
                    ucitajStavkePoPaleti(dgvPalete.CurrentRow.Cells["id"].Value.ToString());
                }
                catch
                {
                    dgvPalete.CurrentCell = dgvPalete[1, 0];

                    ucitajStavkePoPaleti(dgvPalete.CurrentRow.Cells["id"].Value.ToString());
                }
                sacuvajNalog();
            }
        }

        private void ucitajPalete(string id)
        {
            DataTable dt = metode.baza_upit("SELECT       dbo.PAK_NALOG_PALETA.id, dbo.PAK_PALETA.masa, dbo.PAK_PALETA.visina,  dbo.PAK_NALOG_PALETA.visina as ukupnaVisina, CAST(dbo.PAK_PALETA.sirina AS nvarchar) + 'x' + CAST(dbo.PAK_PALETA.dubina AS nvarchar) + 'x' + CAST(dbo.PAK_PALETA.visina AS nvarchar) AS dimenzije, " +
                                "  dbo.PAK_PALETA.sirina * dbo.PAK_PALETA.dubina as kubika2 " +
                                " FROM            dbo.PAK_NALOG_PALETA INNER JOIN  dbo.PAK_PALETA ON dbo.PAK_NALOG_PALETA.idPalete = dbo.PAK_PALETA.id " +
                                " WHERE        (dbo.PAK_NALOG_PALETA.idNalog = " + id + ") order by id");

            dgvPalete.DataSource = dt;

            dgvPalete.Columns["id"].Visible = false;
            dgvPalete.Columns["visina"].Visible = false;
            dgvPalete.Columns["kubika2"].Visible = false;


            //dgvPalete.CurrentCell = dgvPalete.Rows[0].Cells[1];
            //dgvPalete_Click(null, null);

        }

        private void dgvPalete_Click(object sender, EventArgs e)
        {
            try
            {
                string a = dgvPalete.CurrentRow.Cells["id"].Value.ToString();
                ucitajStavkePoPaleti((dgvPalete.CurrentRow.Cells["id"].Value.ToString()));
            }
            catch
            {
            }
        }

        //private void ucitajStavkePoPaleti(string idPaletaNalog)
        //{
        //    string query = "SELECT          dbo.PAK_NALOG_STAVKE.idGP, dbo.PAK_NALOG_STAVKE.idKutija, dbo.PAK_NALOG_STAVKE.id, dbo.GotovProizvod.Sifra, " +
        //       " dbo.PAK_NALOG_STAVKE.kolicina, CAST(dbo.PAK_kutija.sirina AS nvarchar(4)) + 'x' + CAST(dbo.PAK_kutija.visina AS nvarchar(4)) + 'x' + CAST(dbo.PAK_kutija.dubina AS nvarchar(4)) AS kutija, dbo.PAK_NALOG_STAVKE.brojKutija,dbo.PAK_NALOG_STAVKE.opis, " +
        //       "  cast(dbo.GotovProizvod.masa * dbo.PAK_NALOG_STAVKE.kolicina as decimal) /1000  AS [ukupna masa proizovda kg], cast(dbo.PAK_kutija.masa * dbo.PAK_NALOG_STAVKE.brojKutija as decimal)/1000  AS [ukupna masa kutija kg]" +
        //               " FROM            dbo.PAK_NALOG_STAVKE INNER JOIN dbo.GotovProizvod ON dbo.PAK_NALOG_STAVKE.idGP = dbo.GotovProizvod.id INNER JOIN " +
        //               " dbo.PAK_kutija ON dbo.PAK_NALOG_STAVKE.idKutija = dbo.PAK_kutija.id" +
        //               " WHERE        (dbo.PAK_NALOG_STAVKE.idNaloga = " + idNalog + ") AND (dbo.PAK_NALOG_STAVKE.idNALOG_PALETA =" + idPaletaNalog + ")";

        //    DataTable dt = metode.baza_upit(query);

        //    dgvStavke.DataSource = dt;
        //    dgvStavke.Columns["id"].Visible = false;
        //    dgvStavke.Columns["idGP"].Visible = false;
        //    dgvStavke.Columns["idKutija"].Visible = false;
        //    dgvStavke.Columns["ukupna masa proizovda kg"].DefaultCellStyle.Format = "N2";
        //    dgvStavke.Columns["ukupna masa kutija kg"].DefaultCellStyle.Format = "N2";

        //    dgvStavke.Columns["ukupna masa proizovda kg"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        //    dgvStavke.Columns["ukupna masa kutija kg"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        //    //koliko paleta treba
        //    try
        //    {
        //        DataTable dtBK = metode.baza_upit("SELECT SUM(brojKutija) AS br FROM PAK_NALOG_STAVKE WHERE  (idNaloga = " + idNalog + ") AND (idNALOG_PALETA = " + idPaletaNalog + ")");

        //        if (dtBK.Rows[0]["br"].ToString() !="")
        //        {
        //            int brojKutija = int.Parse(dtBK.Rows[0]["br"].ToString());
        //            int brojKutijaUosnovi = int.Parse(metode.baza_upit("SELECT brojKutijaUosnovi FROM  dbo.PAK_KUTIJA_PALETA WHERE   (idKutija = " +  dgvStavke.Rows[0].Cells["idKutija"].Value.ToString() + ")").Rows[0]["brojKutijaUosnovi"].ToString());

        //            lblUkupnoKutija.Text = "Ukupan broj kutija: " + brojKutija.ToString();

        //            int brojRedova = brojKutija / brojKutijaUosnovi;
        //            int ostatakKutija = brojKutija % brojKutijaUosnovi;

        //            if (ostatakKutija > 0) brojRedova = brojRedova + 1;

        //            tbUkupnoRedova.Text = brojRedova.ToString();
        //            tbUkupnoPaleta.Text = "1";
        //            tbUkupnoPaletaPraznih.Text = "0";
        //            tbUkupnoRedovaPraznih.Text = "0";

        //            //ukupna tezina
        //            double ukupnaMasaGP = 0;
        //            double ukupnaMasaKutija = 0;
        //            foreach (DataGridViewRow r in dgvStavke.Rows)
        //            {
        //                ukupnaMasaGP += double.Parse(r.Cells["ukupna masa proizovda kg"].Value.ToString());
        //                ukupnaMasaKutija += double.Parse(r.Cells["ukupna masa kutija kg"].Value.ToString());
        //            }

        //            tbUkupnaMasaGP.Text = ukupnaMasaGP.ToString();
        //            tbUkupnaMasaKutija.Text = ukupnaMasaKutija.ToString();

        //            kubikaza();
        //            visina();
        //        }
        //        else
        //        {
        //            tbUkupnaMasaGP.Text = "";
        //            tbUkupnaMasaKutija.Text = "";
        //            tbUkupnoRedova.Text = "";
        //            lblUkupnoKubikaCelih.Text = "";
        //        }
        //    }
        //    catch
        //    {
        //    }
        //}



        private void ucitajStavkePoPaleti(string idPaletaNalog)
        {
            string query = "SELECT          dbo.PAK_NALOG_STAVKE.idGP, dbo.PAK_NALOG_STAVKE.idKutija, dbo.PAK_NALOG_STAVKE.id, dbo.GotovProizvod.Sifra, " +
               " dbo.PAK_NALOG_STAVKE.kolicina, CAST(dbo.PAK_kutija.sirina AS nvarchar(4)) + 'x' + CAST(dbo.PAK_kutija.dubina AS nvarchar(4)) + 'x' + CAST(dbo.PAK_kutija.visina AS nvarchar(4)) AS kutija, dbo.PAK_NALOG_STAVKE.brojKutija,dbo.PAK_NALOG_STAVKE.opis, " +
               "  cast(dbo.GotovProizvod.masa * dbo.PAK_NALOG_STAVKE.kolicina as decimal) /1000  AS [ukupna masa proizovda kg], cast(dbo.PAK_kutija.masa * dbo.PAK_NALOG_STAVKE.brojKutija as decimal)/1000  AS [ukupna masa kutija kg]" +
                       " FROM            dbo.PAK_NALOG_STAVKE INNER JOIN dbo.GotovProizvod ON dbo.PAK_NALOG_STAVKE.idGP = dbo.GotovProizvod.id INNER JOIN " +
                       " dbo.PAK_kutija ON dbo.PAK_NALOG_STAVKE.idKutija = dbo.PAK_kutija.id" +
                       " WHERE        (dbo.PAK_NALOG_STAVKE.idNaloga = " + idNalog + ") AND (dbo.PAK_NALOG_STAVKE.idNALOG_PALETA =" + idPaletaNalog + ")";

            DataTable dt = metode.baza_upit(query);

            dgvStavke.DataSource = dt;
            dgvStavke.Columns["id"].Visible = false;
            dgvStavke.Columns["idGP"].Visible = false;
            dgvStavke.Columns["idKutija"].Visible = false;
            dgvStavke.Columns["ukupna masa proizovda kg"].DefaultCellStyle.Format = "N2";
            dgvStavke.Columns["ukupna masa kutija kg"].DefaultCellStyle.Format = "N2";

            dgvStavke.Columns["ukupna masa proizovda kg"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvStavke.Columns["ukupna masa kutija kg"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


            tbUkupnaVisina.Text = dgvPalete.CurrentRow.Cells["ukupnaVisina"].Value.ToString();

            //koliko paleta treba
            try
            {
                DataTable dtBK = metode.baza_upit("SELECT SUM(brojKutija) AS br FROM PAK_NALOG_STAVKE WHERE  (idNaloga = " + idNalog + ") AND (idNALOG_PALETA = " + idPaletaNalog + ")");

                if (dtBK.Rows[0]["br"].ToString() != "")
                {
                    int brojKutija = 0;
                    int brojKutijaUosnovi = 0;
                    double ukupnaMasaGP = 0;
                    double ukupnaMasaKutija = 0;
                    int ukupnoRedova = 0;
                    int ukupnoKutija = 0;
                    int ukupnaVisina = int.Parse(dgvPalete.CurrentRow.Cells["visina"].Value.ToString());

                    foreach (DataGridViewRow r in dgvStavke.Rows)
                    {
                        brojKutija = int.Parse(r.Cells["brojKutija"].Value.ToString());
                        brojKutijaUosnovi = int.Parse(metode.baza_upit("SELECT brojKutijaUosnovi FROM  dbo.PAK_KUTIJA_PALETA WHERE   (idKutija = " + r.Cells["idKutija"].Value.ToString() + ")").Rows[0]["brojKutijaUosnovi"].ToString());
                        ukupnoKutija += brojKutija;

                        int brojRedova = brojKutija / brojKutijaUosnovi;
                        int ostatakKutija = brojKutija % brojKutijaUosnovi;

                        if (ostatakKutija > 0) brojRedova = brojRedova + 1;

                        ukupnoRedova += brojRedova;


                        //visina broj redvoa*visina kutije
                        ukupnaVisina += brojRedova * int.Parse(metode.baza_upit("SELECT   visina FROM  PAK_kutija WHERE  (id = " + r.Cells["idKutija"].Value.ToString() + ")").Rows[0]["visina"].ToString());

                        //ukupna tezina
                        ukupnaMasaGP += double.Parse(r.Cells["ukupna masa proizovda kg"].Value.ToString());
                        ukupnaMasaKutija += double.Parse(r.Cells["ukupna masa kutija kg"].Value.ToString());
                    }

                    tbUkupnoRedova.Text = ukupnoRedova.ToString();
                    lblUkupnoKutija.Text = "Ukupan broj kutija: " + ukupnoKutija.ToString();
                    tbUkupnoPaleta.Text = "1";
                    tbUkupnoPaletaPraznih.Text = "0";
                    tbUkupnoRedovaPraznih.Text = "0";
                    tbUkupnaVisina.Text = ukupnaVisina.ToString();
                    tbUkupnaMasaGP.Text = ukupnaMasaGP.ToString();
                    tbUkupnaMasaKutija.Text = ukupnaMasaKutija.ToString();

                    kubikaza();

                }
                else
                {
                    tbUkupnaMasaGP.Text = "";
                    tbUkupnaMasaKutija.Text = "";
                    tbUkupnoRedova.Text = "";
                    lblUkupnoKubikaCelih.Text = "";
                }
            }
            catch
            {
            }
        }


        private void btnDodaj_Click(object sender, EventArgs e)
        {

            if (idNalog != "")
            {
                metode.pristup_bazi("INSERT INTO   PAK_NALOG_PALETA(idNalog, idPalete) VALUES        (" + idNalog + "," + cbPaleta.SelectedValue + ")");
                ucitajPalete(idNalog);
            }

            if (idNalog != "" || UnosNaloga())
            {
                //  metode.pristup_bazi("INSERT INTO   PAK_NALOG_PALETA(idNalog, idPalete) VALUES        (" + idNalog + ",1)");
                ucitajPalete(idNalog);

            }


        }

        private void btnObrisiPaletu_Click(object sender, EventArgs e)
        {
            //provera da li ima na paleti nesta
            DataTable dt = metode.baza_upit(" SELECT        TOP (200) id FROM PAK_NALOG_STAVKE WHERE  (idNALOG_PALETA = " + dgvPalete.CurrentRow.Cells["id"].Value.ToString() + ")");
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Ne mozeste brisati paletu na kojoj se nalaze stavke");
                return;
            }
            else
            {
                metode.pristup_bazi("DELETE TOP (200) FROM  PAK_NALOG_PALETA WHERE        (id = " + dgvPalete.CurrentRow.Cells["id"].Value.ToString() + ")");
                ucitajPalete(idNalog);
            }
        }

        private void btnStampa_Click(object sender, EventArgs e)
        {
            if (idNalog == "")
            {
                MessageBox.Show("Ne postoji nalog. Prvo sacuvajte nalog ili odaberite vec postojeci.");
                return;
            }

            makeReport("C:\\Program files\\IT\\Plamen\\Pakovanje.rpt");

            SetParameters((idNalog));

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

        private void ucitajparitet()
        {
            DataTable dt = metode.baza_upit("select * from pak_paritet where aktiv =1");
            cbParitet.DataSource = dt;
            cbParitet.DisplayMember = "naziv";
            cbParitet.ValueMember = "id";
        }


    }
}
