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
    public partial class FormNoviProizvod : Form
    {
        Metode metode = new Metode();
        int idPP = 0;
        public FormNoviProizvod()
        {
            InitializeComponent();
        }

        public FormNoviProizvod(int idP)
        {
            InitializeComponent();
            ucitajProizvod(idP);
        }
        private void ucitajProizvod(int id)
        {
            DataTable dt = metode.baza_upit("SELECT EngleskiNaziv, Sifra, Naziv, Stanje, Aktivan, Rezervisano, uProizvodnji, ISNULL(masa, 0) AS masa FROM  GotovProizvod where id = " + id + "");
            tbNaziv.Text = dt.Rows[0]["Naziv"].ToString();
            tbRezer.Text = dt.Rows[0]["Rezervisano"].ToString();
            tbSifra.Text = dt.Rows[0]["Sifra"].ToString();
            tbStanje.Text = dt.Rows[0]["Stanje"].ToString();
            tbUpr.Text = dt.Rows[0]["uProizvodnji"].ToString();
            tbEngleski.Text = dt.Rows[0]["EngleskiNaziv"].ToString();
            tbMasa.Text = dt.Rows[0]["masa"].ToString();
            cbAkt.Checked = bool.Parse(dt.Rows[0]["Aktivan"].ToString());
            btnSacuvaj.Text = "Izmeni";
            idPP = id;
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            string insert = "";
            string fb = "";
            try
            {
                if (btnSacuvaj.Text == "Izmeni")
                {
                    insert = "UPDATE  GotovProizvod SET EngleskiNaziv=N'" + tbEngleski.Text + "',  masa=" + tbMasa.Text.Replace(",", ".") + ", Sifra =N'" + tbSifra.Text + "', Naziv =N'" + tbNaziv.Text + "', Stanje =N'" + tbStanje.Text + "', Aktivan ='" + cbAkt.Checked + "', Rezervisano =N'" + tbRezer.Text + "', uProizvodnji =N'" + tbUpr.Text + "' where id =" + idPP + " ";

                    fb = "Proizvod je izmenjen";
                }
                else
                {
                    insert = "INSERT into   GotovProizvod( EngleskiNaziv,masa, Sifra, Naziv, Stanje, Aktivan, Rezervisano, uProizvodnji) " +
                                   " VALUES        (N'" + tbEngleski.Text + "'," + tbMasa.Text.Replace(",", ".") + ",N'" + tbSifra.Text + "',N'" + tbNaziv.Text + "',N'" + tbStanje.Text + "','" + cbAkt.Checked + "',N'" + tbRezer.Text + "',N'" + tbUpr.Text + "')";
                    fb = "Uspesno unet proizvod";
                }
                metode.pristup_bazi(insert);
                MessageBox.Show(fb, "Uspesno");
            }
            catch
            {
                MessageBox.Show("Vec postoji gotov proizvod sa zadatom SIFROM");
            }

        }
    }
}
