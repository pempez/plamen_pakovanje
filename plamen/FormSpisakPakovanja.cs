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
    public partial class FormSpisakPakovanja : Form
    {
        Metode metode = new Metode();
        public FormSpisakPakovanja()
        {
            InitializeComponent();
            ucitaj();

        }

        public GroupBox GetGroupBox()
        {
            return groupBox1;
        }

        private void ucitaj()
        {
            dgvSpisak.DataSource = metode.baza_upit("SELECT   dbo.PAK_NALOG.id,dbo.PAK_NALOG.redniBroj, dbo.KOMITENTI.SifraKomitenta, dbo.KOMITENTI.Prezime " +
                            " FROM            dbo.PAK_NALOG INNER JOIN dbo.KOMITENTI ON dbo.PAK_NALOG.idKupac = dbo.KOMITENTI.ID_KOMITENTA");
            dgvSpisak.Columns["id"].Visible = false;
        }

        private void dgvSpisak_DoubleClick(object sender, EventArgs e)
        {
            int idNaloga = int.Parse(dgvSpisak.CurrentRow.Cells["id"].Value.ToString());
            FormPackingList f1 = new FormPackingList(idNaloga);
            f1.ShowDialog();
        }

      
    }
}
