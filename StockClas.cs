using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Cloths_company
{

    
    class StockClas
    {
        SqlConnection scon = new SqlConnection(Connection.cs);
        SqlCommand scmd;
      

   
        public  Decimal InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime LRDate { get; set; }
        public string VanderName { get; set; }
        public string Transport { get; set; }
        public Decimal LrNo { get; set; }
        public string FromStation { get; set; }
        public string ToStation { get; set; }
        public float GrossTotal { get; set; }

      
        public int Finishing_Id { get; set; }
        public string Description_goods { get; set; }
        public Decimal Lr_No { get; set; }
        public Decimal Lot_No { get; set; }
        public float Gray_Mts { get; set; }
        public Decimal Pcs { get; set; }
        public float Total_Meter { get; set; }
        //public float Finish_Meters { get; set; }
        //public float Job_Charge { get; set; }
        //public float Amount { get; set; }
        //public float Total_Amount { get; set; }
        public int Stok_Id { get; set; }


        public int stacksave()
        {
            try
            {
                scon.Open();
                scmd = new SqlCommand("Insert into StockEntry_tbl(InvoiceNo,InvoiceDate,OrderDate,LRDate,VanderName,Transport,LrNo,FromStation,ToStation,GrossTotal)values(@InvoiceNo,@InvoiceDate,@OrderDate,@LRDate,@VanderName,@Transport,@LrNo,@FromStation,@ToStation,@GrossTotal)", scon);
                scmd.Parameters.AddWithValue("@InvoiceNo", InvoiceNo);
                scmd.Parameters.AddWithValue("@InvoiceDate", InvoiceDate);
                scmd.Parameters.AddWithValue("@OrderDate", OrderDate);
                scmd.Parameters.AddWithValue("@LRDate", LRDate);
                scmd.Parameters.AddWithValue("@VanderName", VanderName);
                scmd.Parameters.AddWithValue("@Transport", Transport);
                scmd.Parameters.AddWithValue("@LrNo", LrNo);
                scmd.Parameters.AddWithValue("@FromStation", FromStation);
                scmd.Parameters.AddWithValue("@ToStation", ToStation);
                scmd.Parameters.AddWithValue("@GrossTotal", GrossTotal);
                return scmd.ExecuteNonQuery();
           }
            finally
            {
                scmd.Parameters.Clear();
                scon.Close();
            }
     }
        public int stockupdate()
        {
            try
            {
                scon.Open();
                scmd = new SqlCommand("Update StockEntry_tbl set InvoiceDate=@InvoiceDate,OrderDate=@OrderDate,LRDate=@LRDate,VanderName=@VanderName,Transport=@Transport,LrNo=@LrNo,FromStation=@FromStation,ToStation=@ToStation,GrossTotal=@GrossTotal where InvoiceNo=@InvoiceNo", scon);
                scmd.Parameters.AddWithValue("@InvoiceDate", InvoiceDate);
                scmd.Parameters.AddWithValue("@OrderDate", OrderDate);
                scmd.Parameters.AddWithValue("@LRDate", LRDate);
                scmd.Parameters.AddWithValue("@VanderName", VanderName);
                scmd.Parameters.AddWithValue("@Transport", Transport);
                scmd.Parameters.AddWithValue("@LrNo", LrNo);
                scmd.Parameters.AddWithValue("@FromStation", FromStation);
                scmd.Parameters.AddWithValue("@ToStation", ToStation);
                scmd.Parameters.AddWithValue("@GrossTotal", GrossTotal);
                scmd.Parameters.AddWithValue("@InvoiceNo", InvoiceNo);
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
                scmd = new SqlCommand("Delete from StockEntry_tbl where InvoiceNo=@InvoiceNo", scon);
                scmd.Parameters.AddWithValue("@InvoiceNo", InvoiceNo);
                 return scmd.ExecuteNonQuery();
            }
            finally
            {
                scmd.Parameters.Clear();
                scon.Close();
            }
        }

        public int finsave()
        {
            try
            {
                scon.Open();
                scmd = new SqlCommand("Insert into Beforefinish_tbl(InvoiceNo,InvoiceDate,VanderName,Transport,LrNo,FromStation,ToStation,Description_goods,Lot_No,Gray_Mts,Pcs,Total_Meter,Stok_Id)values(@InvoiceNo,@InvoiceDate,@VanderName,@Transport,@LrNo,@FromStation,@ToStation,@Description_goods,@Lot_No,@Gray_Mts,@Pcs,@Total_Meter,@Stok_Id) ", scon);
                scmd.Parameters.AddWithValue("@InvoiceNo", InvoiceNo);
                scmd.Parameters.AddWithValue("@InvoiceDate", InvoiceDate);
                scmd.Parameters.AddWithValue("@VanderName", VanderName);
                scmd.Parameters.AddWithValue("@Transport", Transport);
                scmd.Parameters.AddWithValue("@LrNo", LrNo);
                scmd.Parameters.AddWithValue("@FromStation", FromStation);
                scmd.Parameters.AddWithValue("@ToStation", ToStation);
                scmd.Parameters.AddWithValue("@Description_goods", Description_goods);
                scmd.Parameters.AddWithValue("@Lot_No", Lot_No);
                scmd.Parameters.AddWithValue("@Gray_Mts", Gray_Mts);
                scmd.Parameters.AddWithValue("@Pcs", Pcs);
                scmd.Parameters.AddWithValue("@Total_Meter", Total_Meter);
                scmd.Parameters.AddWithValue("@Stok_Id", Stok_Id);
                return scmd.ExecuteNonQuery();
            }
            finally
            {
                scmd.Parameters.Clear();
                scon.Close();
            }
        }

        public int finUpdate()
        {
            try
            {
                scon.Open();
                scmd = new SqlCommand("Update  Beforefinish_tbl set InvoiceDate=@InvoiceDate,VanderName=@VanderName,Transport=@Transport,LrNo=@LrNo,FromStation=@FromStation,ToStation=@ToStation,Description_goods=@Description_goods,Lot_No=@Lot_No,Gray_Mts=@Gray_Mts,Pcs=@Pcs,Total_Meter=@Total_Meter,Stok_Id=@Stok_Id where InvoiceNo=@InvoiceNo ", scon);
                scmd.Parameters.AddWithValue("@InvoiceDate", InvoiceDate);
                scmd.Parameters.AddWithValue("@VanderName", VanderName);
                scmd.Parameters.AddWithValue("@Transport", Transport);
                scmd.Parameters.AddWithValue("@LrNo", LrNo);
                scmd.Parameters.AddWithValue("@FromStation", FromStation);
                scmd.Parameters.AddWithValue("@ToStation", ToStation);
                scmd.Parameters.AddWithValue("@Description_goods", Description_goods);
                scmd.Parameters.AddWithValue("@Lot_No", Lot_No);
                scmd.Parameters.AddWithValue("@Gray_Mts", Gray_Mts);
                scmd.Parameters.AddWithValue("@Pcs", Pcs);
                scmd.Parameters.AddWithValue("@Total_Meter", Total_Meter);
                scmd.Parameters.AddWithValue("@Stok_Id", Stok_Id);
                scmd.Parameters.AddWithValue("@InvoiceNo", InvoiceNo);
                return scmd.ExecuteNonQuery();
            }
            finally
            {
                scmd.Parameters.Clear();
                scon.Close();
            }
        }

        public int findelete()
        {
            try
            {
                scon.Open();
                scmd = new SqlCommand("Delete from Beforefinish_tbl where InvoiceNo=@InvoiceNo", scon);
                scmd.Parameters.AddWithValue("@InvoiceNo", InvoiceNo);
                return scmd.ExecuteNonQuery();
            }
            finally
            {
                scmd.Parameters.Clear();
                scon.Close();
            }
        }
        public int Sefinsave()
        {
            try
            {
                scon.Open();
                scmd = new SqlCommand("Insert into SendFinish_tbl(InvoiceNo,InvoiceDate,VanderName,Transport,LrNo,FromStation,ToStation,Description_goods,Lot_No,Gray_Mts,Pcs,Total_Meter)values(@InvoiceNo,@InvoiceDate,@VanderName,@Transport,@LrNo,@FromStation,@ToStation,@Description_goods,@Lot_No,@Gray_Mts,@Pcs,@Total_Meter) ", scon);
                scmd.Parameters.AddWithValue("@InvoiceNo", InvoiceNo);
                scmd.Parameters.AddWithValue("@InvoiceDate", InvoiceDate);
                scmd.Parameters.AddWithValue("@VanderName", VanderName);
                scmd.Parameters.AddWithValue("@Transport", Transport);
                scmd.Parameters.AddWithValue("@LrNo", LrNo);
                scmd.Parameters.AddWithValue("@FromStation", FromStation);
                scmd.Parameters.AddWithValue("@ToStation", ToStation);
                scmd.Parameters.AddWithValue("@Description_goods", Description_goods);
                scmd.Parameters.AddWithValue("@Lot_No", Lot_No);
                scmd.Parameters.AddWithValue("@Gray_Mts", Gray_Mts);
                scmd.Parameters.AddWithValue("@Pcs", Pcs);
                scmd.Parameters.AddWithValue("@Total_Meter", Total_Meter);
                return scmd.ExecuteNonQuery();
            }
            finally
            {
                scmd.Parameters.Clear();
                scon.Close();
            }
        }
        public int SeinUpdate()
        {
            try
            {
                scon.Open();
                scmd = new SqlCommand("Update  SendFinish_tbl set InvoiceDate=@InvoiceDate,VanderName=@VanderName,Transport=@Transport,LrNo=@LrNo,FromStation=@FromStation,ToStation=@ToStation,Description_goods=@Description_goods,Lot_No=@Lot_No,Gray_Mts=@Gray_Mts,Pcs=@Pcs,Total_Meter=@Total_Meter  where InvoiceNo=@InvoiceNo ", scon);
                scmd.Parameters.AddWithValue("@InvoiceDate", InvoiceDate);
                scmd.Parameters.AddWithValue("@VanderName", VanderName);
                scmd.Parameters.AddWithValue("@Transport", Transport);
                scmd.Parameters.AddWithValue("@LrNo", LrNo);
                scmd.Parameters.AddWithValue("@FromStation", FromStation);
                scmd.Parameters.AddWithValue("@ToStation", ToStation);
                scmd.Parameters.AddWithValue("@Description_goods", Description_goods);
                scmd.Parameters.AddWithValue("@Lot_No", Lot_No);
                scmd.Parameters.AddWithValue("@Gray_Mts", Gray_Mts);
                scmd.Parameters.AddWithValue("@Pcs", Pcs);
                scmd.Parameters.AddWithValue("@Total_Meter", Total_Meter);
                scmd.Parameters.AddWithValue("@InvoiceNo", InvoiceNo);

                return scmd.ExecuteNonQuery();
            }
            finally
            {
                scmd.Parameters.Clear();
                scon.Close();
            }
        }

        public int Sefindelete()
        {
            try
            {
                scon.Open();
                scmd = new SqlCommand("Delete from SendFinish_tbl where InvoiceNo=@InvoiceNo", scon);
                scmd.Parameters.AddWithValue("@InvoiceNo", InvoiceNo);
                return scmd.ExecuteNonQuery();
            }
            finally
            {
                scmd.Parameters.Clear();
                scon.Close();
            }
      }

        public int stokIsusave()
        {
            try
            {
                scon.Open();
                scmd = new SqlCommand("Insert into StockIssueEntry_tbl(InvoiceNo,InvoiceDate,VanderName,Transport,LrNo,FromStation,ToStation,GrossTotal)values(@InvoiceNo,@InvoiceDate,@VanderName,@Transport,@LrNo,@FromStation,@ToStation,@GrossTotal)", scon);
                scmd.Parameters.AddWithValue("@InvoiceNo", InvoiceNo);
                scmd.Parameters.AddWithValue("@InvoiceDate", InvoiceDate);
                scmd.Parameters.AddWithValue("@VanderName", VanderName);
                scmd.Parameters.AddWithValue("@Transport", Transport);
                scmd.Parameters.AddWithValue("@LrNo", LrNo);
                scmd.Parameters.AddWithValue("@FromStation", FromStation);
                scmd.Parameters.AddWithValue("@ToStation", ToStation);
                scmd.Parameters.AddWithValue("@GrossTotal", GrossTotal);
                return scmd.ExecuteNonQuery();
            }
            finally
            {
                scmd.Parameters.Clear();
                scon.Close();
            }
        }

        public int stokIsuupdate()
        {
            try
            {
                scon.Open();
                scmd = new SqlCommand("Update StockIssueEntry_tbl set InvoiceDate=@InvoiceDate,VanderName=@VanderName,Transport=@Transport,LrNo=@LrNo,FromStation=@FromStation,ToStation=@ToStation,GrossTotal=@GrossTotal where InvoiceNo=@InvoiceNo", scon);
                scmd.Parameters.AddWithValue("@InvoiceDate", InvoiceDate);
                scmd.Parameters.AddWithValue("@VanderName", VanderName);
                scmd.Parameters.AddWithValue("@Transport", Transport);
                scmd.Parameters.AddWithValue("@LrNo", LrNo);
                scmd.Parameters.AddWithValue("@FromStation", FromStation);
                scmd.Parameters.AddWithValue("@ToStation", ToStation);
                scmd.Parameters.AddWithValue("@GrossTotal", GrossTotal);
                scmd.Parameters.AddWithValue("@InvoiceNo", InvoiceNo);
                return scmd.ExecuteNonQuery();
            }
            finally
            {
                scmd.Parameters.Clear();
                scon.Close();
            }
        }

        public int Isuelete()
        {
            try
            {
                scon.Open();
                scmd = new SqlCommand("Delete from StockIssueEntry_tbl where InvoiceNo=@InvoiceNo", scon);
                scmd.Parameters.AddWithValue("@InvoiceNo", InvoiceNo);
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
