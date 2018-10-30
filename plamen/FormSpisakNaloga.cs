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
    public partial class FormSpisakNaloga : Form
    {
        Metode metode = new Metode();
        int id = 0;
        string idProizovd = "";
        public FormSpisakNaloga()
        {
            InitializeComponent();
            ucitajStatus();

        }

        public FormSpisakNaloga(int idNalog, string vrsta)
        {
            InitializeComponent();
            ucitajStatus();
            cbVrsta.SelectedValue = vrsta;
            id = idNalog;
            btnPrikazeNaloge_Click(null, null);
            label1.Visible = false;
            btnPrikazeNaloge.Visible = false;
            cbVrsta.Visible = false;
            dgvSpisakNaloga.Height = 150;
            this.WindowState = FormWindowState.Maximized;
           
        }

        public FormSpisakNaloga(string idGP, string vrsta)
        {
            InitializeComponent();
            ucitajStatus();
            cbVrsta.SelectedValue = vrsta;
            idProizovd = idGP;
            btnPrikazeNaloge_Click(null, null);
            label1.Visible = false;
            btnPrikazeNaloge.Visible = false;
            cbVrsta.Visible = false;
            radioButton1.Visible = false;
            radioButton2.Visible = false;
            radioButton3.Visible = false;

            dgvSpisakNaloga.Height = 150;
            this.WindowState = FormWindowState.Maximized;

        }

        public GroupBox GetGroupBox()
        {
            return groupBox1;
        }

        private void ucitajStatus()
        {
            DataTable dt = metode.baza_upit("SELECT id, naziv FROM    SIF_vrstaNaloga");

            cbVrsta.DataSource = dt;
            cbVrsta.DisplayMember = "naziv";
            cbVrsta.ValueMember = "id";
            cbVrsta.SelectedValue = "1";
        }


        private void btnPrikazeNaloge_Click(object sender, EventArgs e)
        {
            string upit = "";
            dgvSpisakNaloga.DataSource = null;
            if (cbVrsta.SelectedValue.ToString() == "1")
            {
                upit = "SELECT        dbo.Nalog.id, dbo.Nalog.broj, dbo.KOMITENTI.SifraKomitenta, dbo.KOMITENTI.Ime + ' ' + dbo.KOMITENTI.Prezime AS Kupac, dbo.Nalog.datum, dbo.Nalog.napomena,  dbo.SIF_Status.status, dbo.Nalog.datumRealizacije as [datum realizacije] " +
                       " FROM            dbo.Nalog INNER JOIN   dbo.SIF_Status ON dbo.Nalog.Status = dbo.SIF_Status.id INNER JOIN "+
                     "        dbo.KOMITENTI ON dbo.Nalog.idKupac = dbo.KOMITENTI.ID_KOMITENTA ";

                if (radioButton2.Checked)
                {
                    upit += " where dbo.Nalog.obrisan = 1";
                }

                if (radioButton1.Checked)
                {
                    upit += " where dbo.Nalog.obrisan = 0";
                }

                upit += "  order by dbo.Nalog.broj desc";
               
            }
            else if (cbVrsta.SelectedValue.ToString() == "2")
            {
                //upit = "SELECT        TOP (100) PERCENT dbo.RadniNalogGP.id, dbo.RadniNalogGP.broj, dbo.Nalog.broj AS [Nalog za proizvodnju], dbo.GotovProizvod.Sifra, dbo.GotovProizvod.Naziv, "+
                //     "     dbo.StavkeRNGP.kolicina,dbo.StavkeRNGP.napravljeno, dbo.RadniNalogGP.datum, dbo.RadniNalogGP.rok, dbo.RadniNalogGP.datumPromene as [Datum promene], dbo.RadniNalogGP.napomena, dbo.SIF_Status.status, dbo.GotovProizvod.Stanje, dbo.GotovProizvod.uProizvodnji AS [U proizvodnji],  " +
                //     "    dbo.GotovProizvod.Stanje - dbo.GotovProizvod.Rezervisano AS Raspolozivo,      dbo.GotovProizvod.Rezervisano AS [Rezervisane zalihe GP] " +// dbo.StavkeRNGP.rezervisano,
                //    " FROM            dbo.SIF_Status INNER JOIN "+
                //         "  dbo.RadniNalogGP ON dbo.SIF_Status.id = dbo.RadniNalogGP.status INNER JOIN "+
                //         "  dbo.StavkeRNGP ON dbo.RadniNalogGP.id = dbo.StavkeRNGP.idRNGP INNER JOIN "+
                //         "  dbo.GotovProizvod ON dbo.StavkeRNGP.idProizvod = dbo.GotovProizvod.id LEFT OUTER JOIN "+
                //         "  dbo.Nalog ON dbo.RadniNalogGP.idNalog = dbo.Nalog.id ";
                upit = "SELECT        TOP (100) PERCENT dbo.RadniNalogGP.id, dbo.RadniNalogGP.broj, dbo.Nalog.broj AS [Nalog za proizvodnju],dbo.KOMITENTI.SifraKomitenta + ' ' + dbo.KOMITENTI.Prezime AS Kupac,  dbo.GotovProizvod.Sifra, dbo.GotovProizvod.Naziv, dbo.StavkeRNGP.kolicina, dbo.StavkeRNGP.napravljeno,  " +
                        "   dbo.RadniNalogGP.datum, dbo.RadniNalogGP.rok, dbo.RadniNalogGP.datumPromene AS [Datum promene],dbo.RadniNalogGP.datumRealizacije AS [Datum realizacije], dbo.RadniNalogGP.napomena, dbo.SIF_Status.status, dbo.GotovProizvod.Stanje,  " +
                         "  dbo.GotovProizvod.uProizvodnji AS [U proizvodnji], dbo.GotovProizvod.Stanje - dbo.GotovProizvod.Rezervisano AS Raspolozivo, dbo.GotovProizvod.Rezervisano AS [Rezervisane zalihe GP]  " +
                        
                             " FROM            dbo.KOMITENTI INNER JOIN " +
                       "    dbo.Nalog ON dbo.KOMITENTI.ID_KOMITENTA = dbo.Nalog.idKupac RIGHT OUTER JOIN " +
                         "  dbo.SIF_Status INNER JOIN " +
                        "   dbo.RadniNalogGP ON dbo.SIF_Status.id = dbo.RadniNalogGP.status INNER JOIN " +
                          " dbo.StavkeRNGP ON dbo.RadniNalogGP.id = dbo.StavkeRNGP.idRNGP INNER JOIN " +
                         "  dbo.GotovProizvod ON dbo.StavkeRNGP.idProizvod = dbo.GotovProizvod.id ON dbo.Nalog.id = dbo.RadniNalogGP.idNalog ";
                      

                if (id != 0 && idProizovd=="")
                {
                    upit += " where dbo.RadniNalogGP.idNalog = " + id + "";
                    
                    if (radioButton2.Checked)
                    {
                        upit += " and dbo.RadniNalogG.obrisan = 1";
                    }

                    if (radioButton1.Checked)
                    {
                        upit += " and  dbo.RadniNalogG.obrisan = 0";
                    }
                }
                else if (idProizovd != "" && id == 0)
                {
                    upit += " WHERE        (dbo.StavkeRNGP.idProizvod = " + idProizovd + ")";

                    if (radioButton2.Checked)
                    {
                        upit += " and dbo.RadniNalogGp.obrisan = 1";
                    }

                    if (radioButton1.Checked)
                    {
                        upit += " and  dbo.RadniNalogGp.obrisan = 0";
                    }
                }
                else
                {
                    if (radioButton2.Checked)
                    {
                        upit += " where  dbo.RadniNalogGp.obrisan = 1";
                    }

                    if (radioButton1.Checked)
                    {
                        upit += " where  dbo.RadniNalogGp.obrisan = 0";
                    }
                }
              

                upit += " ORDER BY dbo.RadniNalogGP.broj DESC";
            }
            else if (cbVrsta.SelectedValue.ToString() == "3")
            {
                upit = "SELECT        TOP (100) PERCENT dbo.RadniNalogPP.id, dbo.RadniNalogPP.broj, dbo.RadniNalogGP.broj AS [Radni nalog GP], dbo.Poluproizvodi.Kod, dbo.Poluproizvodi.Naziv, dbo.StavkeRNPP.kolicina, dbo.StavkeRNPP.napravljeno,  " +
                         "   dbo.RadniNalogPP.datum,dbo.RadniNalogPP.rok,dbo.RadniNalogPP.datumPromene as [Datum promene], dbo.RadniNalogPP.datumRealizacije AS [Datum realizacije], dbo.RadniNalogPP.napomena, dbo.SIF_Status.status, dbo.Poluproizvodi.stanje, dbo.Poluproizvodi.uProizvodnji AS [U proizvodnji], dbo.Poluproizvodi.Rezervisano, " +
                        " dbo.Poluproizvodi.stanje - dbo.Poluproizvodi.Rezervisano AS Raspolozivo " +
                        "  FROM            dbo.SIF_Status INNER JOIN " +
                     "       dbo.RadniNalogPP ON dbo.SIF_Status.id = dbo.RadniNalogPP.status INNER JOIN " +
                   "         dbo.StavkeRNPP ON dbo.RadniNalogPP.id = dbo.StavkeRNPP.idRNPP INNER JOIN " +
                      "      dbo.Poluproizvodi ON dbo.StavkeRNPP.idPP = dbo.Poluproizvodi.id  LEFT OUTER JOIN " +
                      "      dbo.RadniNalogGP ON dbo.RadniNalogPP.idNalogGP = dbo.RadniNalogGP.id ";

                if (id != 0)
                {
                    upit += " where dbo.RadniNalogPP.idNalogGP = " + id + "";

                    if (radioButton2.Checked)
                    {
                        upit += " and dbo.RadniNalogPP.obrisan = 1";
                    }

                    if (radioButton1.Checked)
                    {
                        upit += " and  dbo.RadniNalogPP.obrisan = 0";
                    }
                }

                else
                {
                    if (radioButton2.Checked)
                    {
                        upit += " where  dbo.RadniNalogPP.obrisan = 1";
                    }

                    if (radioButton1.Checked)
                    {
                        upit += " where  dbo.RadniNalogPP.obrisan = 0";
                    }
                }
               

                upit += " ORDER BY dbo.RadniNalogPP.broj DESC";
            }
            dgvSpisakNaloga.DataSource = metode.baza_upit(upit);
            dgvSpisakNaloga.Columns["id"].Visible = false;
          


        }

        private void dgvSpisakNaloga_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dgvSpisakNaloga.CurrentRow.Cells["id"].Value.ToString();

            if (cbVrsta.SelectedValue.ToString() == "1")
            {
                FormNoviNalog f1 = new FormNoviNalog(id);
                f1.ShowDialog();
            }
            if (cbVrsta.SelectedValue.ToString() == "2")
            {
                FormRNGP f1 = new FormRNGP(id);
                f1.ShowDialog();
            }
            if (cbVrsta.SelectedValue.ToString() == "3")
            {
                FormRNPP f1 = new FormRNPP(id);
                f1.ShowDialog();
            }

            btnPrikazeNaloge_Click(null, null);
        }

        private void cbVrsta_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbVrsta.SelectedValue.ToString() == "1" || cbVrsta.SelectedValue.ToString() == "2" || cbVrsta.SelectedValue.ToString() == "3")
            btnPrikazeNaloge_Click(null, null);
        }

      

        private void radioButton3_Click(object sender, EventArgs e)
        {
            btnPrikazeNaloge_Click(null, null);
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            btnPrikazeNaloge_Click(null, null);
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            btnPrikazeNaloge_Click(null, null);
        }
    }
}
