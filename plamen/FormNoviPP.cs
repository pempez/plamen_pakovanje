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
    public partial class FormNoviPP : Form
    {
        Metode metode = new Metode();
        int idPP = 0;
        public FormNoviPP()
        {
            InitializeComponent();
        }

        public FormNoviPP(int idP)
        {
            InitializeComponent();
            ucitajProizvod(idP);
        }
        private void ucitajProizvod(int id)
        {
            DataTable dt = metode.baza_upit("SELECT  Kod, Naziv, Stanje, Aktivan,  uProizvodnji,Rezervisano FROM  Poluproizvodi where id = " + id + "");
            tbNaziv.Text = dt.Rows[0]["Naziv"].ToString();
            tbRezer.Text = dt.Rows[0]["Rezervisano"].ToString();
            tbSifra.Text = dt.Rows[0]["Kod"].ToString();
            tbStanje.Text = dt.Rows[0]["Stanje"].ToString();
            tbUpr.Text = dt.Rows[0]["uProizvodnji"].ToString();
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
                    insert = "UPDATE  Poluproizvodi SET    kod =N'" + tbSifra.Text + "', Naziv =N'" + tbNaziv.Text + "', Stanje =N'" + tbStanje.Text + "', Aktivan ='" + cbAkt.Checked + "', Rezervisano =N'" + tbRezer.Text + "', uProizvodnji =N'" + tbUpr.Text + "' where id =" + idPP + " ";

                    fb = "Proizvod je izmenjen";
                }
                else
                {
                    insert = "INSERT into   Poluproizvodi( kod, Naziv, Stanje, Aktivan, Rezervisano, uProizvodnji) " +
                                    " VALUES        (N'" + tbSifra.Text + "',N'" + tbNaziv.Text + "',N'" + tbStanje.Text + "','" + cbAkt.Checked + "',N'" + tbRezer.Text + "',N'" + tbUpr.Text + "')";
                    fb = "Uspesno unet proizvod";
                }
                metode.pristup_bazi(insert);
                MessageBox.Show(fb, "Uspesno");
            }
            catch
            {
                MessageBox.Show("Vec postoji poluproizvod sa zadatom SIFROM");
            }

        }
    }
}
