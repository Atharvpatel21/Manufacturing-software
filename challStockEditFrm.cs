using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Cloths_company
{
    public partial class challStockEditFrm : Form
    {
        SqlConnection scon = new SqlConnection(Connection.cs);
        SqlCommand scmd;
        SqlDataAdapter sda;
        DataTable dt;
        DataSet ds;
        string str;
        private int PageSize = 500;
        private int CurrentPageIndex = 1;
        private int TotalPage = 0; 

       
        public void executequerey(string str)
        {
            scon.Open();
            scmd = new SqlCommand(str, scon);
            scmd.ExecuteNonQuery();
            scon.Close();
        }
        public void openconnection()
        {
            if (scon.State == ConnectionState.Closed)
            {
                scon.Open();
            }
        }

        public void closeconnection()
        {
            if (scon.State == ConnectionState.Open)
            {
                scon.Close();
            }
        }
        public string sandy
        {
            get
            {
                return labinvoNo.Text;

            }
        }
        public challStockEditFrm()
        {
            InitializeComponent();
        }
        private void CalculateTotalPages()
        {
            try
            {
                int rowCount = ds.Tables["StokId"].Rows.Count;
                this.TotalPage = rowCount / PageSize;
                if (rowCount % PageSize > 0) // if remainder is more than  zero 
                {
                    this.TotalPage += 1;
                }
            }
            catch (Exception)
            {
            }
        }

        private DataTable GetCurrentRecords(int page, SqlConnection scon)
        {
           
            DataTable dt = new DataTable();

            if (page == 1)
            {
                scmd = new SqlCommand("Select TOP " + PageSize + " * from StockIssueEntry_tbl ORDER BY StokId", scon);
            }
            else
            {
                int PreviouspageLimit = (page - 1) * PageSize;

                scmd = new SqlCommand("Select TOP " + PageSize +
                    " * from StockIssueEntry_tbl " +
                    "WHERE StokId NOT IN " +
                "(Select TOP " + PreviouspageLimit + " StokId from StockIssueEntry_tbl ORDER BY StokId) ", scon); // +
                //"order by customerid", con);
            }
            try
            {
                // con.Open();
                this.sda.SelectCommand = scmd;
                this.sda.Fill(dt);
            }
            finally
            {
                scon.Close();
            }
            return dt;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void challStockEditFrm_Load(object sender, EventArgs e)
        {
            try
            {
                openconnection();
                sda = new SqlDataAdapter("Select * from StockIssueEntry_tbl", scon);
                ds = new DataSet();
                sda.Fill(ds, "StokId");
                dataGridView1.DataSource = ds;
                this.CalculateTotalPages();
                this.dataGridView1.ReadOnly = true;

                this.dataGridView1.DataSource = GetCurrentRecords(1, scon);
                closeconnection();
            }
            catch (Exception)
            {

            }
        }

      

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                openconnection();
                SqlDataAdapter sda1 = new SqlDataAdapter("Select * from StockIssueEntry_tbl", scon);
                DataTable de = new DataTable();
                sda1.Fill(de);
                int i, j;
                i = e.RowIndex;
                j = e.ColumnIndex;
                // labinvoNo.Text= de.Rows[i][0].ToString();
                labinvoNo.Text = de.Rows[i]["InvoiceNo"].ToString();
                dataGridView1.DataSource = de;
                ChallanMasterFrm chal = new ChallanMasterFrm();
                chal.sandy = sandy;
                chal.Show();

               closeconnection();
                  this.Close();
            }
            catch(Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        private void butBrows_Click(object sender, EventArgs e)
        {
            new ChallanMasterFrm().Show();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void butNext_Click(object sender, EventArgs e)
        {
            if (this.CurrentPageIndex < this.TotalPage)
            {
                this.CurrentPageIndex++;
                this.dataGridView1.DataSource = GetCurrentRecords(this.CurrentPageIndex, scon);
            }
        }

        private void butPrevious_Click(object sender, EventArgs e)
        {
            if (this.CurrentPageIndex > 1)
            {
                this.CurrentPageIndex--;
                this.dataGridView1.DataSource = GetCurrentRecords(this.CurrentPageIndex, scon);
            } 
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                openconnection();
                str = "Select * from StockIssueEntry_tbl where InvoiceNo like '" + textBox1.Text + "%'";
                sda = new SqlDataAdapter(str, scon);
                DataSet de = new DataSet();
                sda.Fill(de);
                dataGridView1.DataSource = de.Tables[0];
                closeconnection();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }
    }
}
