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
    public partial class FormKutijaNaPaleti : Form
    {
        Metode metode = new Metode();
        public FormKutijaNaPaleti()
        {
            InitializeComponent();
            ucitajKutije();
            ucitajPalete();
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

            DataTable dt = metode.baza_upit(" SELECT  id, masa, CAST(sirina AS nvarchar(4)) + 'x' + CAST(visina AS nvarchar(4)) + 'x' + CAST(dubina AS nvarchar(4)) AS display FROM PAK_PALETA  where aktiv=1");

            cbPaleta.DataSource = dt;
            cbPaleta.DisplayMember = "display";
            cbPaleta.ValueMember = "id";
            cbPaleta.SelectedIndex = 0;


        }

        public GroupBox GetGroupBox()
        {
            return groupBox1;
        }

        private void btnUnesi_Click(object sender, EventArgs e)
        {
            string qObrisi = "   DELETE FROM     PAK_KUTIJA_PALETA WHERE        (idPaleta = " + cbPaleta.SelectedValue + ") AND (idKutija = " + cbVrstaKutije.SelectedValue + ")";
            metode.pristup_bazi(qObrisi);


            string aUnesi = "INSERT INTO       PAK_KUTIJA_PALETA(idPaleta, idKutija, brojKutijaUosnovi) " +
                             " VALUES        (" + cbPaleta.SelectedValue + "," + cbVrstaKutije.SelectedValue + "," + tbKomada.Text + ")";
            metode.pristup_bazi(aUnesi);
            ucitajKutijeNaPaleti(int.Parse(cbVrstaKutije.SelectedValue.ToString()));
        }

        private void ucitajKutijeNaPaleti(int kutija)
        {

            DataTable dt = metode.baza_upit(" SELECT        dbo.PAK_KUTIJA_PALETA.idKutija, dbo.PAK_KUTIJA_PALETA.idPaleta, dbo.PAK_KUTIJA_PALETA.brojKutijaUosnovi, CAST(dbo.PAK_PALETA.sirina AS nvarchar(4)) + 'x' + CAST(dbo.PAK_PALETA.visina AS nvarchar(4))  "+
                       "  + 'x' + CAST(dbo.PAK_PALETA.dubina AS nvarchar(4)) AS [Vrsta palete] "+
                " FROM            dbo.PAK_KUTIJA_PALETA INNER JOIN "+
                   "       dbo.PAK_kutija ON dbo.PAK_KUTIJA_PALETA.idKutija = dbo.PAK_kutija.id INNER JOIN "+
                       "   dbo.PAK_PALETA ON dbo.PAK_KUTIJA_PALETA.idPaleta = dbo.PAK_PALETA.id "+
                    "  WHERE        (dbo.PAK_KUTIJA_PALETA.idKutija =" + kutija + ") and  dbo.pak_paleta.aktiv=1");

            dgvGPkutija.DataSource = dt;
            dgvGPkutija.Columns["idKutija"].Visible = false;
            dgvGPkutija.Columns["idPaleta"].Visible = false;

        }

        private void cbVrstaKutije_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                ucitajKutijeNaPaleti(int.Parse(cbVrstaKutije.SelectedValue.ToString()));
            }
            catch { }
        }
    }
}
