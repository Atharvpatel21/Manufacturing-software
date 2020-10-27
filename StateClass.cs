using System;
using System.Data;
using System.Data.SqlClient;


namespace Cloths_company
{
    class StateClass
    {

        private SqlConnection scon;
        private SqlCommand scmd;
        private SqlDataAdapter sdap;
       // private SqlDataReader sdar;

        public int StateId { get; set; }
        public String  StateName { get; set; }
        public string login { get; set; }
        public string pwd { get; set; }

        public DataSet readllstate( )
        {
            try
            {
                
                scon = new SqlConnection(Connection.cs);
                scon.Open();
                scmd = new SqlCommand("Select StateName from State_tbl", scon);
                sdap = new SqlDataAdapter(scmd);
                DataSet ds = new DataSet();
                ds.Clear();
                sdap.Fill(ds);
                return ds;
            }
            finally
            {
                scon.Close();
            }
        }

       

        public int insert(StateClass st)
        {
            try
            {
                scon = new SqlConnection(Connection.cs);
               scon.Open();
                scmd = new SqlCommand("Insert into State_tbl(StateName)values(@StateName)", scon);
                scmd.Parameters.AddWithValue("@StateName", st.StateName);
                return scmd.ExecuteNonQuery();
            }
            finally
            {
                scmd.Parameters.Clear();
                scon.Close();
            }
        }

        public int update(StateClass up)
        {
            try
            {
                scon = new SqlConnection(Connection.cs);
                scon.Open();
                scmd = new SqlCommand("update State_tbl set StateName=@StateName WHERE StateId=@StateId", scon);
                scmd.Parameters.AddWithValue("@StateName", up.StateName);
                scmd.Parameters.AddWithValue("@StateId", up.StateId);
                return scmd.ExecuteNonQuery();
            }
            finally
            {
                scmd.Parameters.Clear();
                scon.Close();
            }
    }

        public int delete(StateClass de)
        {
            try
            {
                scon = new SqlConnection(Connection.cs);
                scon.Open();
                scmd = new SqlCommand("Delete from State_tbl Where StateId=@StateId", scon);

                scmd.Parameters.AddWithValue("@StateId", de.StateId);
                return scmd.ExecuteNonQuery();
            }
           finally
            {
                scmd.Parameters.Clear();
                scon.Close();
            }
        }

        public int loginsert(StateClass ls)
        {
            try
            {
                scon = new SqlConnection(Connection.cs);
                scon.Open();
                scmd = new SqlCommand("Insert Into admin (login,pwd) Values(@login,@pwd)", scon);
                scmd.Parameters.AddWithValue("@login",ls.login);
                scmd.Parameters.AddWithValue("@pwd", ls.pwd);
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
