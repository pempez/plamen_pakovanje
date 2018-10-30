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
    public partial class FormVrstaKutija : Form
    {
        Metode metode = new Metode();

        public FormVrstaKutija()
        {
            InitializeComponent();
            ucitajKutije();

            btnIzmeni.Enabled = false;
            btnUnesi.Enabled = true;
        }

        public GroupBox GetGroupBox()
        {
            return groupBox1;
        }

        private void ucitajKutije()
        {

            DataTable dt = metode.baza_upit(" select id, cast(masa as nvarchar(4)) as masa, CAST(dubina AS nvarchar(4)) AS duzina, CAST(sirina AS nvarchar(4)) as sirina, CAST(visina AS nvarchar(4)) as visina FROM            PAK_kutija where aktiv = 1");

            dgvVrsteKutija.DataSource = dt;
          


        }

        private void btnUnesi_Click(object sender, EventArgs e)
        {
            string qUnesi = "INSERT  INTO      PAK_kutija( masa, sirina, visina, dubina) "+
                            " VALUES        (" + tbMasa.Text + "," + tbSirina.Text + "," + tbVisina.Text + "," + tbDuzina.Text + ")";
            metode.pristup_bazi(qUnesi);

            ucitajKutije();
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (dgvVrsteKutija.CurrentRow != null)
            {
                string qIzmeni = "UPDATE PAK_kutija SET    masa =N'" + tbMasa.Text + "', sirina =N'" + tbSirina.Text + "', visina = N'" + tbVisina.Text + "', dubina =N'" + tbDuzina.Text + "'" +
                                 " where id = " + dgvVrsteKutija.CurrentRow.Cells["id"].Value.ToString() + "";
                metode.pristup_bazi(qIzmeni);
                ucitajKutije();
            }
        }

        private void dgvVrsteKutija_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvVrsteKutija.CurrentRow != null)
            {
                btnIzmeni.Enabled = true;
              

                tbDuzina.Text = dgvVrsteKutija.CurrentRow.Cells["duzina"].Value.ToString();
                tbVisina.Text = dgvVrsteKutija.CurrentRow.Cells["visina"].Value.ToString();
                tbSirina.Text = dgvVrsteKutija.CurrentRow.Cells["sirina"].Value.ToString();
                tbMasa.Text = dgvVrsteKutija.CurrentRow.Cells["masa"].Value.ToString();
            }
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (dgvVrsteKutija.CurrentRow != null)
            {
                string qObrisi = "update           PAK_kutija  set aktiv=0 where id = " + dgvVrsteKutija.CurrentRow.Cells["id"].Value.ToString() + "";
                metode.pristup_bazi(qObrisi);
                ucitajKutije();
            }
        }

       
    }
}
