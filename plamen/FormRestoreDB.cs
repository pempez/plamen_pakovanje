using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Transactions;
using System.Threading;
using System.Globalization;
using System.IO;

namespace plamen
{
    public partial class FormRestoreDB : Form
    {
        Metode metode = new Metode();
        string connection = "";
        public FormRestoreDB()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string datum = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString();
            //metode.pristup_bazi(" backup database [plamen] to disk = 'C:\\Program files\\IT\\Plamen\\plamen"+datum+".Bak' ");

            string restoreDB = "restore database [plamen] from disk = 'C:\\Program files\\IT\\Plamen\\plamen.Bak' with replace;";
          
            TextReader tr = new StreamReader("c:\\Program files\\IT\\Plamen\\connRestore.txt");
            connection = tr.ReadLine();
            tr.Close();

            SqlConnection myconnection = new SqlConnection(connection);

            myconnection.Open();

            SqlCommand mycommand = new SqlCommand();
            mycommand.CommandText = restoreDB;
            mycommand.Connection = myconnection;
            mycommand.ExecuteNonQuery();

            myconnection.Close();

            MessageBox.Show("Uspesno");
        }
    }
}
