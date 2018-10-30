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
    public partial class FormGPuKutiji : Form
    {
        Metode metode = new Metode();
        public FormGPuKutiji()
        {
            InitializeComponent();
            ucitajProizvode();
            ucitajKutije();
        }

        public FormGPuKutiji(int GP)
        {
            InitializeComponent();
            ucitajProizvode();
            ucitajKutije();
            ucitajGPuKutiji(GP);
            cbProizvodSifra.SelectedValue = GP.ToString();

        }

        public GroupBox GetGroupBox()
        {
            return groupBox1;
        }
        private void ucitajProizvode()
        {
            DataTable dt = metode.baza_upit("SELECT       id, Sifra, Naziv FROM            GotovProizvod where aktivan=1 order by Naziv");

            cbProizvodSifra.DataSource = dt;
            cbProizvodSifra.DisplayMember = "Sifra";
            cbProizvodSifra.ValueMember = "id";
            cbProizvodSifra.SelectedIndex = -1;

            cbProizvodNaziv.DataSource = dt;
            cbProizvodNaziv.DisplayMember = "Naziv";
            cbProizvodNaziv.ValueMember = "id";
            cbProizvodNaziv.SelectedIndex = -1;

        }

        private void ucitajGPuKutiji(int GP)
        {

            DataTable dt = metode.baza_upit(" SELECT        dbo.PAK_GP_KUTIJA.idKutija, dbo.PAK_GP_KUTIJA.idGotovProizvod, dbo.PAK_GP_KUTIJA.kolicina, CAST(dbo.PAK_kutija.sirina AS nvarchar(4)) + 'x' + CAST(dbo.PAK_kutija.visina AS nvarchar(4)) "+
                      "   + 'x' + CAST(dbo.PAK_kutija.dubina AS nvarchar(4)) AS [Vrsta kutije] "+
                   "   FROM            dbo.PAK_GP_KUTIJA INNER JOIN  dbo.PAK_kutija ON dbo.PAK_GP_KUTIJA.idKutija = dbo.PAK_kutija.id INNER JOIN  "+
                     "      dbo.GotovProizvod ON dbo.PAK_GP_KUTIJA.idGotovProizvod = dbo.GotovProizvod.id " +
                                 " WHERE        (dbo.PAK_GP_KUTIJA.idGotovProizvod = "+GP+")");

            dgvGPkutija.DataSource = dt;
            dgvGPkutija.Columns["idKutija"].Visible = false;
            dgvGPkutija.Columns["idGotovProizvod"].Visible = false;
         
        }

        private void ucitajKutije()
        {

            DataTable dt = metode.baza_upit(" select id, masa, CAST(sirina AS nvarchar(4)) + 'x' + CAST(visina AS nvarchar(4)) + 'x' + CAST(dubina AS nvarchar(4)) AS display FROM            PAK_kutija");

            cbVrstaKutije.DataSource = dt;
            cbVrstaKutije.DisplayMember = "display";
            cbVrstaKutije.ValueMember = "id";
            cbVrstaKutije.SelectedIndex = 1;

        }

        private void btnUnesi_Click(object sender, EventArgs e)
        {
            string qObrisi = "   DELETE FROM   PAK_GP_KUTIJA WHERE        (idGotovProizvod = " + cbProizvodSifra.SelectedValue + ") AND (idKutija = " + cbVrstaKutije.SelectedValue + ")";
            metode.pristup_bazi(qObrisi);
         

            string aUnesi = "INSERT INTO       PAK_GP_KUTIJA(idGotovProizvod, idKutija, kolicina) "+
                             " VALUES        (" + cbProizvodSifra.SelectedValue + "," + cbVrstaKutije.SelectedValue + "," + tbKomada.Text + ")";
            metode.pristup_bazi(aUnesi);
            ucitajGPuKutiji(int.Parse(cbProizvodSifra.SelectedValue.ToString()));
        }

        private void cbProizvodSifra_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                ucitajGPuKutiji(int.Parse(cbProizvodSifra.SelectedValue.ToString()));
            }
            catch { }
        }
    }
}
