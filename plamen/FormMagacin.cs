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
    public partial class FormMagacin : Form
    {
        Metode metode = new Metode();
        public FormMagacin()
        {
            InitializeComponent();
            
        }

        public FormMagacin(int id)
        {
            InitializeComponent();
            ucitaj(id);
            this.WindowState = FormWindowState.Maximized;
        }

        public GroupBox GetGroupBox()
        {
            return groupBox1;
        }

        private void ucitaj(int id)
        {
            string query = "SELECT        dbo.Magacin.id, dbo.Magacin.broj, dbo.Magacin.napomena, dbo.Magacin.datum, dbo.Nalog.broj AS brojNaloga, dbo.Nalog.datum AS datumNaloga, dbo.Nalog.napomena AS NapomenaNaloga, dbo.KOMITENTI.SifraKomitenta, " +
                        " dbo.KOMITENTI.SifraKomitenta +' ' + dbo.KOMITENTI.Prezime + ' ' + dbo.KOMITENTI.Ime AS Kupac, dbo.GotovProizvod.Sifra, dbo.GotovProizvod.Naziv, dbo.StavkeNaloga.kolicina,dbo.StavkeNaloga.napravljeno AS Zapakovano " +
                            " FROM            dbo.Magacin INNER JOIN " +
                        "  dbo.Nalog ON dbo.Magacin.idNalog = dbo.Nalog.id INNER JOIN " +
                      "    dbo.KOMITENTI ON dbo.Nalog.idKupac = dbo.KOMITENTI.ID_KOMITENTA INNER JOIN " +
                       "   dbo.StavkeNaloga ON dbo.Nalog.id = dbo.StavkeNaloga.idNalog INNER JOIN " +
                       "   dbo.GotovProizvod ON dbo.StavkeNaloga.idProizvod = dbo.GotovProizvod.id" +
                       " where  dbo.Magacin.id = " + id + "";

            DataTable dt = metode.baza_upit(query);
            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
             
                tbBroj.Text = dt.Rows[0]["broj"].ToString();
                dtpDatum.Value = DateTime.Parse(dt.Rows[0]["datumNaloga"].ToString());
                tbKupac.Text = dt.Rows[0]["Kupac"].ToString();
                tbNalog.Text = dt.Rows[0]["brojnaloga"].ToString();
                tbNapomena.Text = dt.Rows[0]["napomena"].ToString();

              
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[7].Visible = false;
                dataGridView1.Columns[8].Visible = false;
              
            }
        }
    }
}
