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
    public partial class FormSpisakMagacin : Form
    {
        Metode metode = new Metode();

        public FormSpisakMagacin()
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

            dgvSpisakNaloga.DataSource = metode.baza_upit("SELECT        dbo.Magacin.id, dbo.Magacin.broj, dbo.Magacin.datum,dbo.Nalog.broj AS [Broj Naloga], dbo.KOMITENTI.SifraKomitenta AS [Sifra Kupca],  dbo.KOMITENTI.Prezime + ' ' + dbo.KOMITENTI.Ime AS Kupac, dbo.Magacin.napomena " +
                                                        " FROM            dbo.Magacin INNER JOIN dbo.Nalog ON dbo.Magacin.idNalog = dbo.Nalog.id INNER JOIN "+
                                                       "      dbo.KOMITENTI ON dbo.Nalog.idKupac = dbo.KOMITENTI.ID_KOMITENTA");
            dgvSpisakNaloga.Columns[0].Visible = false;
        }

        private void dgvSpisakNaloga_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvSpisakNaloga_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FormMagacin f1 = new FormMagacin(int.Parse(dgvSpisakNaloga.CurrentRow.Cells["id"].Value.ToString()));
            f1.Show();
        }
    }
}
