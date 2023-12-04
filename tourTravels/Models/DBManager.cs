using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace tourTravels.Models
{
    public class DBManager
    {
        SqlConnection conn = new SqlConnection(@"Data Source=Priyanshu\SQLEXPRESS;Initial Catalog=letstravel;Integrated Security=True");
        SqlCommand cmd = null;
        //method for insert update delete management
        public bool myinsertupdatedelete(string command)
        {
            cmd = new SqlCommand(command, conn);
            conn.Open();
            int n = cmd.ExecuteNonQuery();
            conn.Close();
            if (n > 0)
                return true;
            else
                return false;
        }

        public DataTable getallrecord(string command)
        {
            cmd = new SqlCommand(command, conn);
            conn.Open();
            SqlDataAdapter sa = new SqlDataAdapter(command, conn);
            DataTable dt = new DataTable();
            sa.Fill(dt);
            conn.Close();


            return dt;
        }
    }
}