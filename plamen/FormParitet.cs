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
    public partial class FormParitet : Form
    {
        Metode metode = new Metode();
        public FormParitet()
        {
            InitializeComponent();

            ucitaj();
        }

        private void ucitaj()
        {
            DataTable dt = metode.baza_upit(" SELECT    id, naziv, aktiv FROM            PAK_Paritet");
            if (dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;
                dataGridView1.Columns["id"].Visible = false;
                dataGridView1.Columns["aktiv"].Visible = false;

            }
            else dataGridView1.DataSource = null;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            metode.pristup_bazi("insert into pak_paritet(naziv) values(N'"+tbParitet.Text+"')");
            ucitaj();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                metode.pristup_bazi(" delete from pak_paritet where id = "+dataGridView1.CurrentRow.Cells["id"].Value.ToString() +"");
                ucitaj();
            }
        }
    }
}
