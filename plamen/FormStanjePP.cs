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
    public partial class FormStanjePP : Form
    {
        Metode metode = new Metode();
        public FormStanjePP()
        {
            InitializeComponent();
            ucitaj();
            ucitajProizvode();
            button1.Visible = true;
        }

        public FormStanjePP(int idPP)
        {
            InitializeComponent();
            ucitaj(idPP);
            ucitajProizvode();
            label3.Visible = false;
            cbProizvodSifra.Visible = false;
            cmproizvodNaziv.Visible = false;
            btnPretrazi.Visible = false;
        }

        public GroupBox GetGroupBox()
        {
            return groupBox1;
        }
        private void ucitaj()
        {
            dataGridView1.DataSource = metode.baza_upit(" SELECT id, Kod, Naziv,  stanje, uProizvodnji as [U proizvodnji], rezervisano FROM  Poluproizvodi order by kod");//Uputstvo, Telo, Guma, Cesalj, Plocica,
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Height = 200;

        }
        private void ucitaj(int id)
        {
            dataGridView1.DataSource = metode.baza_upit(" SELECT id, Kod, Naziv, stanje, uProizvodnji as [U proizvodnji], rezervisano FROM  Poluproizvodi where id = " + id + "");//Uputstvo, Telo, Guma, Cesalj, Plocica, 
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Height = 45;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //idNalogGp je setovan na 1
            FormRNPP f1 = new FormRNPP(int.Parse(dataGridView1.CurrentRow.Cells["id"].Value.ToString()), 1);
            f1.ShowDialog();
            ucitaj();
            
        }

        private void ucitajProizvode()
        {
            DataTable dt = metode.baza_upit("SELECT id, Kod, Naziv,  stanje FROM   Poluproizvodi order by kod");

            cbProizvodSifra.DataSource = dt;
            cbProizvodSifra.DisplayMember = "Kod";
            cbProizvodSifra.ValueMember = "id";
            cbProizvodSifra.SelectedValue = -1;
         

            cmproizvodNaziv.DataSource = dt;
            cmproizvodNaziv.DisplayMember = "Naziv";
            cmproizvodNaziv.ValueMember = "id";
            cmproizvodNaziv.SelectedValue = -1;
            
        }

        private void btnPretrazi_Click(object sender, EventArgs e)
        {
            if (cbProizvodSifra.Text == "")
            {
                ucitaj();
            }
            else
            {
                ucitaj(int.Parse(cbProizvodSifra.SelectedValue.ToString()));
            }
        }

        private void cbProizvodSifra_Leave(object sender, EventArgs e)
        {
            if (cbProizvodSifra.Text == "")
            {
                cmproizvodNaziv.Text = "";
                ucitaj();
            }
        }

        private void cmproizvodNaziv_Leave(object sender, EventArgs e)
        {
            if (cmproizvodNaziv.Text == "")
            {
                cbProizvodSifra.Text = "";
                ucitaj();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string select = "SELECT        dbo.StavkeRNPP.idRNPP, dbo.RadniNalogPP.broj, dbo.RadniNalogPP.datum, dbo.RadniNalogPP.rok, dbo.RadniNalogPP.napomena,dbo.StavkeRNPP.kolicina, dbo.StavkeRNPP.rezervisano, dbo.StavkeRNPP.napravljeno, " +
                       "  dbo.SIF_Status.status "+
                        " FROM            dbo.StavkeRNPP INNER JOIN "+
                       "  dbo.RadniNalogPP ON dbo.StavkeRNPP.idRNPP = dbo.RadniNalogPP.id INNER JOIN "+
                        " dbo.SIF_Status ON dbo.RadniNalogPP.status = dbo.SIF_Status.id"+
                             " WHERE        (dbo.StavkeRNPP.idPP =  " + int.Parse(dataGridView1.CurrentRow.Cells["id"].Value.ToString()) + ")";
            dgvSpisakRNPP.DataSource = metode.baza_upit(select);
            dgvSpisakRNPP.Columns["idRNPP"].Visible = false;
        }

        private void dgvSpisakRNPP_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FormRNPP f1 = new FormRNPP(dgvSpisakRNPP.CurrentRow.Cells["idRNPP"].Value.ToString());
            f1.ShowDialog();
        }

        
    }
}
