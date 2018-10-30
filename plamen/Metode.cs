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
    class Metode
    {

        string connection = "";

        public void pristup_bazi(string query)
        {
            TextReader tr = new StreamReader("c:\\Program files\\IT\\Plamen\\conn.txt");
            connection = tr.ReadLine();
            tr.Close();

            SqlConnection myconnection = new SqlConnection(connection);

            myconnection.Open();

            SqlCommand mycommand = new SqlCommand();
            mycommand.CommandText = query;
            mycommand.Connection = myconnection;
            mycommand.ExecuteNonQuery();

            myconnection.Close();
        }

        public DataTable baza_upit(string query)
        {
            TextReader tr = new StreamReader("c:\\Program files\\IT\\Plamen\\conn.txt");
            connection = tr.ReadLine();
            tr.Close();

            SqlDataAdapter myAdapterPretraga = new SqlDataAdapter(query, connection);
            DataTable pretraga = new DataTable();
            myAdapterPretraga.Fill(pretraga);

            return pretraga;
        }

        public DataTable baza_upit(string query, SqlConnection conn)
        {
            SqlDataAdapter st = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            st.Fill(dt);
            return dt;
        }
    }

    public static class idNalogPublic
    {
        public static int idNalog;
        public static int kolicina;
    }
}
