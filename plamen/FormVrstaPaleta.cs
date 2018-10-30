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
    public partial class FormVrstaPaleta : Form
    {
        Metode metode = new Metode();

        public FormVrstaPaleta()
        {
            InitializeComponent();

            ucitajPalete();

            btnIzmeni.Enabled = false;
            btnUnesi.Enabled = true;
        }

        public GroupBox GetGroupBox()
        {
            return groupBox1;
        }

        private void ucitajPalete()
        {

            DataTable dt = metode.baza_upit(" select id, cast(masa as nvarchar(4)) as masa, CAST(dubina AS nvarchar(4)) AS duzina, CAST(sirina AS nvarchar(4)) as sirina, CAST(visina AS nvarchar(4)) as visina FROM            PAK_paleta where aktiv=1");

            dgvVrstePaleta.DataSource = dt;

            dgvVrstePaleta.Columns["id"].Visible = false;


        }

        private void btnUnesi_Click(object sender, EventArgs e)
        {
            string qUnesi = "INSERT  INTO      PAK_paleta( masa, sirina, visina, dubina,aktiv) " +
                            " VALUES        (" + tbMasa.Text + "," + tbSirina.Text + "," + tbVisina.Text + "," + tbDuzina.Text + ",1)";
            metode.pristup_bazi(qUnesi);

            ucitajPalete();
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            if (dgvVrstePaleta.CurrentRow != null)
            {
                string qIzmeni = "UPDATE PAK_paleta SET    masa =N'" + tbMasa.Text + "', sirina =N'" + tbSirina.Text + "', visina = N'" + tbVisina.Text + "', dubina =N'" + tbDuzina.Text + "'" +
                                 " where id = " + dgvVrstePaleta.CurrentRow.Cells["id"].Value.ToString() + "";
                metode.pristup_bazi(qIzmeni);
                ucitajPalete();
            }
        }

        private void dgvVrsteKutija_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvVrstePaleta.CurrentRow != null)
            {
                btnIzmeni.Enabled = true;


                tbDuzina.Text = dgvVrstePaleta.CurrentRow.Cells["duzina"].Value.ToString();
                tbVisina.Text = dgvVrstePaleta.CurrentRow.Cells["visina"].Value.ToString();
                tbSirina.Text = dgvVrstePaleta.CurrentRow.Cells["sirina"].Value.ToString();
                tbMasa.Text = dgvVrstePaleta.CurrentRow.Cells["masa"].Value.ToString();
            }
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (dgvVrstePaleta.CurrentRow != null)
            {
                string qObrisi = "update     PAK_paleta  set aktiv =0 where id = " + dgvVrstePaleta.CurrentRow.Cells["id"].Value.ToString() + "";
                metode.pristup_bazi(qObrisi);
                ucitajPalete();
            }
        }

        
    }
}
