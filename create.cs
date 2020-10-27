using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;


namespace Cloths_company
{
    
    class create
    {
     
        private SqlConnection scon;
        private SqlCommand scmd;
       // private SqlDataAdapter sdap;
       // private SqlDataReader sdar;


        public int compID { get; set; }
        public string companyname { get; set; }
        public string address { get; set; }
        public string authoriseperson { get; set; }
        public string registeroffice { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string phone { get; set; }
        public string mob { get; set; }
        public string faxno { get; set; }
        public string email { get; set; }
        public string pinno { get; set; }
        public string companywebsite { get; set; }
        public string branchname { get; set; }
        public string narration { get; set; }
          
        

        public int createaddcomp(create obj)
        {
            try
            {
                scon = new SqlConnection(Connection.cs);
                scon.Open();
                scmd = new SqlCommand("Insert into compmaster_tbl(companyname,address,authoriseperson,registeroffice,state,city,phone,mob,faxno,email,pinno,companywebsite,branchname,narration) values(@companyname,@address,@authoriseperson,@registeroffice,@state,@city,@phone,@mob,@faxno,@email,@pinno,@companywebsite,@branchname,@narration)", scon);
                scmd.Parameters.AddWithValue("@companyname", obj.companyname);
                scmd.Parameters.AddWithValue("@address", obj.address);
                scmd.Parameters.AddWithValue("@authoriseperson", obj.authoriseperson);
                scmd.Parameters.AddWithValue("@registeroffice", obj.registeroffice);
                scmd.Parameters.AddWithValue("@state", obj.state);
                scmd.Parameters.AddWithValue("@city", obj.city);
                scmd.Parameters.AddWithValue("@phone", obj.phone);
                scmd.Parameters.AddWithValue("@mob", obj.mob);
                scmd.Parameters.AddWithValue("@faxno", obj.faxno);
                scmd.Parameters.AddWithValue("@email", obj.email);
                scmd.Parameters.AddWithValue("@pinno", obj.pinno);
                scmd.Parameters.AddWithValue("@companywebsite", obj.companywebsite);
                scmd.Parameters.AddWithValue("@branchname", obj.branchname);
                scmd.Parameters.AddWithValue("@narration", obj.narration);
           
                return scmd.ExecuteNonQuery();
            }
            finally
            {
                scmd.Parameters.Clear();
                scon.Close();
            }
        }
        /*********************************************************************************/
        public int updatecomp(create u)
        {
            try
            {
                scon = new SqlConnection(Connection.cs);
                scon.Open();
                scmd = new SqlCommand("Update compmaster_tbl set  companyname=@companyname,address=@address,authoriseperson=@authoriseperson,registeroffice=@registeroffice,state=@state,city=@city,phone=@phone,mob=@mob,faxno=@faxno,email=@email,pinno=@pinno,companywebsite=@companywebsite,branchname=@branchname,narration=@narration where compID=@compID", scon);
                scmd.Parameters.AddWithValue("@companyname", u.companyname);
                scmd.Parameters.AddWithValue("@address", u.address);
                scmd.Parameters.AddWithValue("@authoriseperson", u.authoriseperson);
                scmd.Parameters.AddWithValue("@registeroffice", u.registeroffice);
                scmd.Parameters.AddWithValue("@state", u.state);
                scmd.Parameters.AddWithValue("@city", u.city);
                scmd.Parameters.AddWithValue("@phone", u.phone);
                scmd.Parameters.AddWithValue("@mob", u.mob);
                scmd.Parameters.AddWithValue("@faxno", u.faxno);
                scmd.Parameters.AddWithValue("@email", u.email);
                scmd.Parameters.AddWithValue("@pinno", u.pinno);
                scmd.Parameters.AddWithValue("@companywebsite", u.companywebsite);
                scmd.Parameters.AddWithValue("@branchname", u.branchname);
                scmd.Parameters.AddWithValue("@narration",u.narration);
                scmd.Parameters.AddWithValue("@compID", u.compID);
                return scmd.ExecuteNonQuery();
            }
            finally
            {
                scmd.Parameters.Clear();

                scon.Close();
            }
        }
        /*****************************************************************************************/
        public int createdele(create d)
        {
            try
            {
                scon = new SqlConnection(Connection.cs);
                scon.Open();

                scmd = new SqlCommand("Delete From compmaster_tbl Where compID=@compID", scon);
              
                scmd.Parameters.AddWithValue("@compID", d.compID);
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

    



    






