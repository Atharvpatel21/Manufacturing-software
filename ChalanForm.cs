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
    public partial class ChalanForm : Form
    {
        SqlConnection scon = new SqlConnection(Connection.cs);
        SqlCommand scmd,cmd2,cmd1;
        DataTable dt, dttemp;
        SqlDataAdapter sda,adp1;
        SqlDataReader sdr;
        DataRow row;
        string str;
        DataSet ds;
        private int PageSize = 10;
        private int CurrentPageIndex = 1;
        private int TotalPage = 0; 

        private DataGridView dGV1 = new DataGridView();
       // private BindingSource bindingSource1 = new BindingSource();
      

        public void executequerey(string str)
        {
            scon.Open();
            scmd = new SqlCommand(str, scon);
            scmd.ExecuteNonQuery();
            scon.Close();
        }
        public void bind()
        {
            //scon.Open();
            //adp1 = new SqlDataAdapter("Select*from RecieveFinish2",scon);
            //dt = new DataTable();
            //adp1.Fill(dt, "sid");
            //dGV1.DataSource = dt;

            //scon.Close();
        }
        private void CalculateTotalPages()
        {
            int rowCount = ds.Tables["sid"].Rows.Count;
            this.TotalPage = rowCount / PageSize;
            if (rowCount % PageSize > 0) // if remainder is more than  zero 
            {
                this.TotalPage += 1;
            }
        }

        private DataTable GetCurrentRecords(int page, SqlConnection scon)
        {
            DataTable dt = new DataTable();

            if (page == 1)
            {
                cmd2 = new SqlCommand("Select TOP " + PageSize + " * from RecieveFinish2 ORDER BY sid", scon);
            }
            else
            {
                int PreviouspageLimit = (page - 1) * PageSize;

                cmd2 = new SqlCommand("Select TOP " + PageSize +
                    " * from RecieveFinish2 " +
                    "WHERE sid NOT IN " +
                "(Select TOP " + PreviouspageLimit + " sid from RecieveFinish2 ORDER BY sid) ", scon); // +
                //"order by customerid", con);
            }
            try
            {
                // con.Open();
                this.adp1.SelectCommand = cmd2;
                this.adp1.Fill(dt);
            }
            finally
            {
                scon.Close();
            }
            return dt;
        }
        //private void goFirst()
        //{

        //    this.mintCurrentPage = 0;
        //     loadPage();

        //}

        //private void goPrevious()
        //{

        //    if (this.ChalanForm_Load== this.ChalanForm_Load)

        //        this.ChalanForm_Load = this.ChalanForm_Load - 1;
        //        this.ChalanForm_Load--;
        //if (this.ChalanForm_Load < 1)

        //        this.ChalanForm_Load = 0;
        //ChalanForm_Load();
        //    // loadPage();

        //}
        private void goNext()
        {

           // this.mintCurrentPage++;
           //if (this.mintCurrentPage > (this.mintPageCount - 1))
           //this.mintCurrentPage = this.mintPageCount - 1;
           //loadPage();

        }

        private void goLast()
        {

            //this.mintCurrentPage = this.mintPageCount - 1;
            //loadPage();

        }


        //public void st()
        //{
        //    scon.Open();
        //    sda = new SqlDataAdapter("Select StoreName from RecieveFinish2", scon);
        //    dttemp = new DataTable();
        //    sda.Fill(dttemp);
        //    dGV1.DataSource =dttemp ;
        //}
             
        private static DataTable GetData(string selectCommand)
        {
            //   string connectionString = 
            //"Integrated Security=SSPI;Persist Security Info=False;" +
            //"Initial Catalog=Northwind;Data Source=localhost;Packet Size=4096";
            SqlDataAdapter sp = new SqlDataAdapter(selectCommand,Connection.cs);
            // // Connect to the database and fill a data table.
            // SqlDataAdapter adapter =
            //new SqlDataAdapter(selectCommand, connectionString);

            DataTable data = new DataTable();
            data.Locale = System.Globalization.CultureInfo.InvariantCulture;
            sp.Fill(data);

            return data;
        }

        public ChalanForm()
        {
              InitializeComponent();
            this.dGV1.Dock= DockStyle.Fill;
            this.Load += new EventHandler(ChalanForm_Load);
           // this.Text = "DataGridView Validation demo(disallows empty DescriptionGood )";
                    
      
             dttemp = new DataTable();
            if (dttemp == null || dttemp.Columns.Count <= 0)
            {
                dttemp.Columns.Add("DescriptionGood");
                dttemp.Columns.Add("DesignNo");
                dttemp.Columns.Add("BaleNo");
                dttemp.Columns.Add("PCS");
                dttemp.Columns.Add("GrayMeter");
              //  dttemp.Columns.Add("StoreName");
                 dGV1.DataSource = dttemp;
            }
        }

        static void vali()
        {
           // Application.EnableVisualStyles();
           // Application.Run(new ChalanForm());
        }
        private void ChalanForm_Load(object sender, EventArgs e)
        {


            cmd1 = new SqlCommand("Select * from RecieveFinish2 ", scon);
            ds = new DataSet();
            adp1 = new SqlDataAdapter(cmd1);
            adp1.Fill(ds, "sid");
            dataGridView1.DataSource = ds;

            this.CalculateTotalPages();
            this.dataGridView1.ReadOnly = true;
            // Load the first page of data; 
            this.dataGridView1.DataSource = GetCurrentRecords(1, scon);
           // st();

         //   this.dGV1.CellValidating += new DataGridViewCellValidatingEventHandler(dataGridView1_CellValidating);
          //  this.dGV1.CellEndEdit += new DataGridViewCellEventHandler(dataGridView1_CellEndEdit);
            // Initialize the BindingSource and bind the DataGridView to it.
       
          //  bindingSource1.DataSource =GetData("Select * from RecieveFinish2");
            //this.dataGridView1.DataSource = bindingSource1;
          //  this.dGV1.DataSource = bindingSource1;
        
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dttemp=(System.Data.DataTable)dataGridView1.DataSource;
              foreach (DataRow row in dttemp.Rows)
                    {
                        str= "Insert Into RecieveFinish2 Values('" + row[0].ToString() + "','" + row[1].ToString() + "','" + row[2].ToString() + "','" + row[3].ToString() + "','" + row[4].ToString() + "','" + row[5].ToString() + "')";
                        executequerey(str);
                     }
              MessageBox.Show("data save");
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

            //dttemp = (System.Data.DataTable)dGV1.DataSource;

              foreach (DataRow row in dttemp.Rows)
             {
                string headerText = dGV1.Columns[e.ColumnIndex].HeaderText;
                if (headerText.Equals("DescriptionGood"))

                    // 
                    return;
                else if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
                {
                    dGV1.Rows[e.RowIndex].ErrorText = "Description Of Good Must Not be empty";
                    MessageBox.Show("Description must not empty");
                    e.Cancel = true;
                }
            }
          }

        private void butNext_Click(object sender, EventArgs e)
        {
            if (this.CurrentPageIndex < this.TotalPage)
            {
                this.CurrentPageIndex++;
                this.dataGridView1.DataSource = GetCurrentRecords(this.CurrentPageIndex, scon);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.CurrentPageIndex > 1)
            {
                this.CurrentPageIndex--;
                this.dataGridView1.DataSource = GetCurrentRecords(this.CurrentPageIndex, scon);
            } 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.CurrentPageIndex = TotalPage;
            this.dataGridView1.DataSource = GetCurrentRecords(this.CurrentPageIndex, scon); 
        }
    }
}
