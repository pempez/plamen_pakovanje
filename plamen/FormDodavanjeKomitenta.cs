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
    public partial class FormDodavanjeKomitenta : Form
    {
        Metode metode = new Metode();
        int idKomi = 0;
        public FormDodavanjeKomitenta()
        {
            InitializeComponent();
        }
        public FormDodavanjeKomitenta(int id)
        {
            InitializeComponent();

            DataTable dt = metode.baza_upit(" select id_komitenta, SifraKomitenta, Prezime,  OPSTINA, MESTO, ULICA, BROJ,drzava from KOMITENTI where id_komitenta = " + id + "");
           
            tbSifraq.Text = dt.Rows[0]["SifraKomitenta"].ToString();
            tbNaziv.Text = dt.Rows[0]["Prezime"].ToString();
            tbDrzava.Text = dt.Rows[0]["drzava"].ToString();
            tbOpstina.Text = dt.Rows[0]["OPSTINA"].ToString();
            tbMesto.Text = dt.Rows[0]["MESTO"].ToString();
            tbUlica.Text = dt.Rows[0]["ULICA"].ToString();
            tbBroj.Text = dt.Rows[0]["BROJ"].ToString();

            idKomi = id;
            btnUnesi.Text = "Izmeni";
        }

        private void btnUnesi_Click(object sender, EventArgs e)
        {
            if (btnUnesi.Text == "Unesi")
            {
                metode.pristup_bazi("INSERT INTO   KOMITENTI( drzava, SifraKomitenta, Prezime,pravno_lice,ime, OPSTINA, MESTO, ULICA, BROJ) " +
                                    " VALUES        (N'" + tbDrzava.Text + "',N'" + tbSifraq.Text + "',N'" + tbNaziv.Text + "',1, '', N'" + tbOpstina.Text + "',N'" + tbMesto.Text + "', N'" + tbUlica.Text + "',N'" + tbBroj.Text + "')");
                MessageBox.Show("Uspesno unet novi Kupac");
            }
            else
            {
                metode.pristup_bazi("update   KOMITENTi set drzava=N'" + tbDrzava.Text + "', SifraKomitenta=N'" + tbSifraq.Text + "', Prezime=N'" + tbNaziv.Text + "', OPSTINA=N'" + tbOpstina.Text + "', MESTO=N'" + tbMesto.Text + "', ULICA=N'" + tbUlica.Text + "', BROJ=N'" + tbBroj.Text + "' where  id_komitenta=" + idKomi + " ");
                                  
                MessageBox.Show("Uspesno promenjeni podaci o kupcu");
            }
        }
    }
}
