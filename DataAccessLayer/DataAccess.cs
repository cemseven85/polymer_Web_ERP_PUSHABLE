using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace polymer_Web_ERP_V4.Data_Access_Layer
{
    public class DataAccess
    {

        public SqlConnection Connection()
        {
            // This is for Local 
            SqlConnection conn = new SqlConnection(@"Data Source=CEMSEVENPC;Initial Catalog=polymer;Integrated Security=True");

            //This is for server
            //SqlConnection conn = new SqlConnection(@"Data Source=77.245.159.27,1433;Initial Catalog=polymerDB;User ID=adminpdb;Password=agc8490*0443;Integrated Security=False");

           conn.Open ();   
            return conn;
        }

        

    }
}