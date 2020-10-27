using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
namespace Cloths_company
{
    class Vendor
    {
        private SqlConnection scon;
        private SqlCommand scmd;
    

        public int custID { get; set; }
        public string CompanyName { get; set; }
        public string address { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string phone { get; set; }
        public string mobile { get; set; }
        public string faxno { get; set; }
        public string email { get; set; }
        public string pinno { get; set; }
        public string compwebsite { get; set; }
        public string agentname { get; set; }
        public string agentadd { get; set; }
        public string narration { get; set; }

        public int Vendoraddcust(Vendor a)
        {
            try
            {
                scon = new SqlConnection(Connection.cs);
                scon.Open();
                scmd = new SqlCommand("Insert Into customerdetail_tbl(CompanyName,address,state,city,phone,mobile,faxno,email,pinno,compwebsite,agentname,agentadd,narration) values(@CompanyName,@address,@state,@city,@phone,@mobile,@faxno,@email,@pinno,@compwebsite,@agentname,@agentadd,@narration) ", scon);
                scmd.Parameters.AddWithValue("@CompanyName", a.CompanyName);
                scmd.Parameters.AddWithValue("@address", a.address);
                scmd.Parameters.AddWithValue("@state", a.state);
                scmd.Parameters.AddWithValue("@city", a.city);
                scmd.Parameters.AddWithValue("@phone", a.phone);
                scmd.Parameters.AddWithValue("@mobile", a.mobile);
                scmd.Parameters.AddWithValue("@faxno", a.faxno);
                scmd.Parameters.AddWithValue("@email", a.email);
                scmd.Parameters.AddWithValue("@pinno", a.pinno);
                scmd.Parameters.AddWithValue("@compwebsite", a.compwebsite);
                scmd.Parameters.AddWithValue("@agentname", a.agentname);
                scmd.Parameters.AddWithValue("@agentadd", a.agentadd);
                scmd.Parameters.AddWithValue("@narration", a.narration);

                return scmd.ExecuteNonQuery();
             
            }
            finally
            {
                scmd.Parameters.Clear();
                scon.Close();
            }
        }
       /************************************************************************************************/
        public int vendorupdate(Vendor u)
        {
            try
            {
                scon = new SqlConnection(Connection.cs);
                scon.Open();
                scmd = new SqlCommand("Update customerdetail_tbl set CompanyName=@CompanyName,address=@address,state=@state,city=@city,phone=@phone,mobile=@mobile,faxno=@faxno,email=@email,pinno=@pinno,compwebsite=@compwebsite,agentname=@agentname,agentadd=@agentadd,narration=@narration where custID=@custID", scon);
                scmd.Parameters.AddWithValue("@CompanyName", u.CompanyName);
                scmd.Parameters.AddWithValue("@address", u.address);
                scmd.Parameters.AddWithValue("@state", u.state);
                scmd.Parameters.AddWithValue("@city", u.city);
                scmd.Parameters.AddWithValue("@phone", u.phone);
                scmd.Parameters.AddWithValue("@mobile", u.mobile);
                scmd.Parameters.AddWithValue("@faxno", u.faxno);
                scmd.Parameters.AddWithValue("@email", u.email);
                scmd.Parameters.AddWithValue("@pinno", u.pinno);
                scmd.Parameters.AddWithValue("@compwebsite", u.compwebsite);
                scmd.Parameters.AddWithValue("@agentname", u.agentname);
                scmd.Parameters.AddWithValue("@agentadd", u.agentadd);
                scmd.Parameters.AddWithValue("@narration", u.narration);
                scmd.Parameters.AddWithValue("@custID ",u.custID);

                return scmd.ExecuteNonQuery();
             
            
            }
            finally
            {
                scmd.Parameters.Clear();
                scon.Close();
            }
        }
     /************************************************************************************************/
        public int vendordele(Vendor d)
        {
            try
            {
                scon = new SqlConnection(Connection.cs);
                scon.Open();

                scmd = new SqlCommand("Delete From customerdetail_tbl Where custID=@custID", scon);

                scmd.Parameters.AddWithValue("@custID", d.custID);
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
