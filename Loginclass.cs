using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Cloths_company
{

    class Loginclass
    {
        String login { get; set; }
        string pwd { get; set; }

        SqlCommand cmd;
        SqlDataReader table;
        SqlConnection con;

        public Boolean logincheck(string userlogin, string password)
        {
            try
            {
                con = new SqlConnection(Connection.cs);
                con.Open();
                cmd = new SqlCommand("select * from admin where login=@login and pwd=@pwd", con);
                cmd.Parameters.AddWithValue("@login", userlogin);
                cmd.Parameters.AddWithValue("@pwd", password);
                table = cmd.ExecuteReader();
                if (table.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            finally
            {
                cmd.Parameters.Clear();
                con.Close();
            }
        }


        public Boolean passwordavibity(string uname, string pwd)
        {
            try
            {
                con = new SqlConnection(Connection.cs);
                con.Open();
                cmd = new SqlCommand("select login,pwd from admin where login=@login and pwd=@pwd", con);
                cmd.Parameters.AddWithValue("@login",uname);
                cmd.Parameters.AddWithValue("@pwd",pwd);
                table = cmd.ExecuteReader();
                if (table.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            finally
            {
                cmd.Parameters.Clear();
                con.Close();
            }
        }


}

}


