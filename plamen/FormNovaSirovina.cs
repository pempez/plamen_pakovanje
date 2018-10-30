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
    public partial class FormNovaSirovina : Form
    {
        Metode metode = new Metode();
        string idSirovina = "0";
        public FormNovaSirovina()
        {
            InitializeComponent();
        }

        public FormNovaSirovina(int id)
        {
            InitializeComponent();
            string select = "SELECT       id, naziv, jedinicaMere, stanje, sifra,aktivan FROM            Sirovina where id = " + id + "";
            DataTable dt = metode.baza_upit(select);
            if (dt.Rows.Count > 0)
            {
                tbJedinica.Text = dt.Rows[0]["jedinicaMere"].ToString();
                tbNaziv.Text = dt.Rows[0]["naziv"].ToString();
                //  tbRezervisano.Text = dt.Rows[0]["rezervisano"].ToString();
                tbStanje.Text = dt.Rows[0]["stanje"].ToString();
                tbSifra.Text = dt.Rows[0]["sifra"].ToString();
                idSirovina = dt.Rows[0]["id"].ToString();
                cbAkt.Checked = bool.Parse(dt.Rows[0]["Aktivan"].ToString());
                btnUnesi.Text = "Izmeni";

            }
        }

        private void btnUnesi_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnUnesi.Text == "Izmeni")
                {
                    string update = " update sirovina set sifra = N'" + tbSifra.Text + "', naziv=N'" + tbNaziv.Text + "', jedinicaMere=N'" + tbJedinica.Text + "', stanje= N'" + tbStanje.Text.Replace(",", ".") + "', aktivan = '" + cbAkt.Checked + "' where id = " + idSirovina + "";
                    metode.pristup_bazi(update);
                    MessageBox.Show("Uspeno izmenjeno");
                }
                else
                {
                    string insert = "INSERT  INTO    Sirovina( sifra, naziv, jedinicaMere, stanje, rezervisano,aktivan) " +
                                    " VALUES        (N'" + tbSifra.Text + "', N'" + tbNaziv.Text + "',N'" + tbJedinica.Text + "',N'" + tbStanje.Text.Replace(",", ".") + "',0,'" + cbAkt.Checked + "')";
                    metode.pristup_bazi(insert);
                    MessageBox.Show("Uspeno uneto");
                }
            }
            catch
            {
                MessageBox.Show("Vec postoji sirovina sa zadatom SIFROM");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
