using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Cloths_company
{
    class CityClass
    {
        SqlConnection scon = new SqlConnection(Connection.cs);
      
        private SqlCommand scmd;
      

        public int CityId { get; set; }

        public String StateName { get; set; }
        public string CityName { get; set; }


        public int instcity(CityClass inc)
        {
            try
            {
                SqlConnection scon = new SqlConnection(Connection.cs);
                scon.Open();
                scmd = new SqlCommand("insert into City_tbl(StateName,CityName)values(@StateName,@CityName)",scon);
                scmd.Parameters.AddWithValue("@StateName",inc.StateName);
                scmd.Parameters.AddWithValue("@CityName",inc.CityName);
                return scmd.ExecuteNonQuery();

            }
            finally
            {
                scmd.Parameters.Clear();
                scon.Close();
            }

            }
        public int udatecit(CityClass updc)
        {
            try
            {
                SqlConnection scon = new SqlConnection(Connection.cs);
                scon.Open();
                scmd = new SqlCommand("Update City_tbl set StateName=@StateName,CityName=@CityName where CityId=@CityId ", scon);
                scmd.Parameters.AddWithValue("@StateName",updc.StateName);
                scmd.Parameters.AddWithValue("@CityName",updc.CityName);
                scmd.Parameters.AddWithValue("@CityId", updc.CityId);
                return scmd.ExecuteNonQuery();
             
              }
            finally
            {
                scmd.Parameters.Clear();
                scon.Close();
            }
            
        }

        public int delete(CityClass de)
        {
            try
            {
                scon = new SqlConnection(Connection.cs);
                scon.Open();
                scmd = new SqlCommand("Delete from City_tbl Where CityId=@CityId", scon);

                scmd.Parameters.AddWithValue("@CityId", de.CityId);
                return scmd.ExecuteNonQuery();
            }
            finally
            {
                scmd.Parameters.Clear();
                scon.Close();
            }
        }
    }
    }

