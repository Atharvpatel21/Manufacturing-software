using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Cloths_company
{
   
    class PurchaseClass
    {




        SqlConnection scon = new SqlConnection(Connection.cs);
        SqlCommand scmd;
        SqlDataAdapter sdap;
        //SqlDataReader sdr;
        DataSet ds = new DataSet();
       // DataRow row;
        DataTable dttemp;

        public string CompanyName { get; set; }
        public Decimal Invoice { get; set; }
        public DateTime Invoicedt { get; set; }
        public Decimal LRno { get; set; }
        public DateTime LRdt { get; set; }
        public string Transport { get; set; }
        public string AgentName { get; set; }
        public string FromStation { get; set; }
        public string ToStation { get; set; }
        public string TermDelivery { get; set; }
        public Decimal BaleNo { get; set; }
        public Decimal PCS { get; set; }
        public float quantity { get; set; }
        public float NetAmount { get; set; }
   

        public int SRno { get; set; }
       
        public string DescriptionofGood { get; set; }
        public Decimal PoNo { get; set; }
        public Decimal Baleno { get; set; }
        public Decimal Pcs { get; set; }
        public float Quantity { get; set; }
        public string Unit { get; set; }
        public float Rate { get; set; }
        public float TotalAmount { get; set; }

      
        public DateTime Pdate { get; set; }
        public string qualitycode { get; set; }
        public Decimal Bale { get; set; }
        public Decimal Lot { get; set; }
        public float TotalMeter { get; set; }


        public int pursave(PurchaseClass s)
        {

            try
            {
                scon.Open();
             
                scmd = new SqlCommand("Insert into Purchase_tbl(CompanyName,Invoice,Invoicedt,LRno,LRdt,Transport,AgentName,FromStation,ToStation,TermDelivery,NetAmount)values(@CompanyName,@Invoice,@Invoicedt,@LRno,@LRdt,@Transport,@AgentName,@FromStation,@ToStation,@TermDelivery,@NetAmount)", scon);
                scmd.Parameters.AddWithValue("@CompanyName",CompanyName);
                scmd.Parameters.AddWithValue("@Invoice", Invoice);
                scmd.Parameters.AddWithValue("@Invoicedt", Invoicedt);
                scmd.Parameters.AddWithValue("@LRno",LRno);
                scmd.Parameters.AddWithValue("@LRdt", LRdt);
                scmd.Parameters.AddWithValue("@Transport", Transport);
                scmd.Parameters.AddWithValue("@AgentName", AgentName);
                scmd.Parameters.AddWithValue("@FromStation", FromStation);
                scmd.Parameters.AddWithValue("@ToStation", ToStation);
                scmd.Parameters.AddWithValue("@TermDelivery", TermDelivery);
                scmd.Parameters.AddWithValue("@NetAmount",NetAmount);
            


                return scmd.ExecuteNonQuery();


            }
            finally
            {
                scmd.Parameters.Clear();
                scon.Close();
            }
        }

        public DataSet readCompanyName()
        {
            try
            {
                scon.Open();
                scmd = new SqlCommand("Select CompanyName from compmaster_tbl ", scon);
               // scmd.Parameters.AddWithValue("@CompanyName", CompanyName);
                sdap = new SqlDataAdapter(scmd);
                sdap.Fill(ds);
                return (ds);

            }
            finally
            {
                scon.Close();
            }
        }

        public int createtempAdditemsave()
        {
            try
            {

                scon.Open();

                scmd = new SqlCommand("Insert Into PuchaseItem_tbl(Invoice,DescriptionofGood,PoNo,Baleno,Pcs,Quantity,Unit,Rate,TotalAmount) values(@Invoice,@DescriptionofGood,@PoNo,@Baleno,@Pcs,@Quantity,@Unit,@Rate,@TotalAmount) ", scon);
                scmd.Parameters.AddWithValue("@Invoice", Invoice);
                scmd.Parameters.AddWithValue("@DescriptionofGood", DescriptionofGood);
                scmd.Parameters.AddWithValue("@PoNo", PoNo);
                scmd.Parameters.AddWithValue("@Baleno", BaleNo);
                scmd.Parameters.AddWithValue("@Pcs", Pcs);
                scmd.Parameters.AddWithValue("@Quantity", Quantity);
                scmd.Parameters.AddWithValue("@Unit", Unit);
                scmd.Parameters.AddWithValue("@Rate", Rate);
                scmd.Parameters.AddWithValue("@TotalAmount", TotalAmount);

                return scmd.ExecuteNonQuery();
               //// row = new DataRow();
               // row = dttemp.NewRow();
               // row[0] = "DescriptionofGood";
               // row[1] = "PoNo";
               // row[2] = "Baleno";
               // row[3] = "Pcs";
               // row[4] = "Quantity";
               // row[5] = "Unit";
               // row[6] = "Rate";
               // row[7] = "TotalAmount";
               // dttemp.Rows.Add(row);
               // return (row);

            }
            finally
            {
                scmd.Parameters.Clear();
                scon.Close();
            }
        }
        public DataTable ReadTemprary()
        {
            try
            {
                scon.Open();
                dttemp = new DataTable();
                if (dttemp == null || dttemp.Columns.Count <= 0)
                {
                    dttemp.Columns.Add("DescriptionofGood");
                    dttemp.Columns.Add("PoNo");
                    dttemp.Columns.Add("Baleno");
                    dttemp.Columns.Add("Pcs");
                    dttemp.Columns.Add("Quantity");
                    dttemp.Columns.Add("Unit");
                    dttemp.Columns.Add("Rate");
                    dttemp.Columns.Add("TotalAmount");

                  //  return (dttemp);
                }
                return (dttemp);
            }
            finally
            {
                scon.Close();
            }
        }

        public int purupdate()
        {
            try
            {
                scon.Open();
                scmd = new SqlCommand("Update Purchase_tbl set CompanyName=@CompanyName,Invoicedt=@Invoicedt,LRno=@LRno,LRdt=@LRdt,Transport=@Transport,AgentName=@AgentName,FromStation=@FromStation,ToStation=@ToStation,TermDelivery=@TermDelivery,NetAmount=@NetAmount where Invoice=@Invoice", scon);
                scmd.Parameters.AddWithValue("@CompanyName", CompanyName);
                scmd.Parameters.AddWithValue("@Invoicedt", Invoicedt);
                scmd.Parameters.AddWithValue("@LRno", LRno);
                scmd.Parameters.AddWithValue("@LRdt", LRdt);
                scmd.Parameters.AddWithValue("Transport", Transport);
                scmd.Parameters.AddWithValue("@AgentName", AgentName);
                scmd.Parameters.AddWithValue("@FromStation", FromStation);
                scmd.Parameters.AddWithValue("@ToStation", ToStation);
                scmd.Parameters.AddWithValue("@TermDelivery", TermDelivery);
                scmd.Parameters.AddWithValue("@NetAmount", NetAmount);
                scmd.Parameters.AddWithValue("@Invoice", Invoice);
                return scmd.ExecuteNonQuery();

            }
            finally
            {
                scmd.Parameters.Clear();
                scon.Close();
            }
        }
        public int puDelete()
        {
            try
            {
                scon.Open();
                scmd = new SqlCommand("Delete from Purchase_tbl where Invoice=@Invoice", scon);
                scmd.Parameters.AddWithValue("@Invoice", Invoice);

                return scmd.ExecuteNonQuery();
            }
            finally
            {
                scmd.Parameters.Clear();
                scon.Close();
            }
        }

        public int packsave()
        {
            try
            {
                scon.Open();
                scmd = new SqlCommand("Insert into Packing_tbl(CompanyName,Pdate,qualitycode,Bale,Lot,TotalMeter)values(@CompanyName,@Pdate,@qualitycode,@Bale,@Lot,@TotalMeter)", scon);
                scmd.Parameters.AddWithValue("@CompanyName", CompanyName);
                scmd.Parameters.AddWithValue("@Pdate", Pdate);
                scmd.Parameters.AddWithValue("@qualitycode", qualitycode);
                scmd.Parameters.AddWithValue("@Bale", Bale);
                scmd.Parameters.AddWithValue("@Lot", Lot);
                scmd.Parameters.AddWithValue("@TotalMeter", TotalMeter);
                return scmd.ExecuteNonQuery();
            }
            finally
            {
                scmd.Parameters.Clear();
                scon.Close();
            }
        }
        public int packupdate()
        {
            try
            {
                scon.Open();
                scmd = new SqlCommand("Update Packing_tbl set CompanyName=@CompanyName,Pdate=@Pdate,qualitycode=@qualitycode,Lot=@Lot,TotalMeter=@TotalMeter where Bale=@Bale ", scon);
                scmd.Parameters.AddWithValue("@CompanyName", CompanyName);
                scmd.Parameters.AddWithValue("@Pdate", Pdate);
                scmd.Parameters.AddWithValue("@qualitycode", qualitycode);
                scmd.Parameters.AddWithValue("@Lot", Lot);
                scmd.Parameters.AddWithValue("@TotalMeter", TotalMeter);
                scmd.Parameters.AddWithValue("@Bale", Bale);
                 return scmd.ExecuteNonQuery();
            }
            finally
            {
                scmd.Parameters.Clear();
                scon.Close();
            }
        }

        public int pakpuDelete()
        {
            try
            {
                scon.Open();
                scmd = new SqlCommand("Delete from Packing_tbl where Bale=@Bale", scon);
                scmd.Parameters.AddWithValue("@Bale",Bale);

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
