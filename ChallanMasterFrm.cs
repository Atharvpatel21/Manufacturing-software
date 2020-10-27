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
    public partial class ChallanMasterFrm : Form
    {
        SqlConnection scon = new SqlConnection(Connection.cs);
        SqlCommand scmd;
        DataTable dt, dttemp;
        SqlDataAdapter sda;
        SqlDataReader sdr;
        DataRow row;
        String str1, str2, chaid,invid,ched;
        string mkl;
        int s;
        float a, b, c,K,L,M,N,O,P;
        public void executequerey(string str)
        {
            openconnection();
            scmd = new SqlCommand(str, scon);
            scmd.ExecuteNonQuery();
            closeconnection();
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
        public void calculation()
        {
            try
            {
                dttemp = (System.Data.DataTable)dataGridView1.DataSource;

                foreach (DataRow row in dttemp.Rows)
                {
                    float a = float.Parse(row[2].ToString());
                    float b = float.Parse(row[3].ToString());
                    //float c = float.Parse(row[4].ToString());
                    float c = a * b;
                    row[4] = c.ToString();


                }
            }
            catch (Exception)
            {
                // MessageBox.Show(es.Message);
            }
        }
        public void Clear()
        {
            challanbind();
            TextName.Text = "";
            textAddress.Text = "";
            textAgentname.Text = "";
            dataGridView1.DataSource = "";
            dtpDate.Text = "";
            txtBillNo.Text = "";
            dttemp.Rows.Clear();
            dataGridView1.DataSource = dttemp;
        
       }
        public string sandy
        {
            set
            {
                invid = value;
            }
        }
        public string priya
        {
            set
            {
                ched = value;
            }
        }
        public void chedit()
        {
            try
            {
                openconnection();
                SqlDataAdapter sda = new SqlDataAdapter("Select Description,NoOfpieces,Quantity,Rate,totalamount from Challan2 where ChallanNo='" +ched.ToString() + "' ", scon);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                dataGridView1.DataSource = dt;
                TxtChallano.Text = ched.ToString();


                SqlDataAdapter sdap = new SqlDataAdapter("Select BillNo,ChallanDate,Name,Address,AgentName from Challan1 where ChallanNo='" + ched.ToString() + "'", scon);
                DataTable dp = new DataTable();
                sdap.Fill(dp);
                txtBillNo.Text = dp.Rows[0]["BillNo"].ToString();
                dtpDate.Text = dp.Rows[0]["ChallanDate"].ToString();
                TextName.Text = dp.Rows[0]["Name"].ToString();
                textAddress.Text = dp.Rows[0]["Address"].ToString();
                textAgentname.Text = dp.Rows[0]["AgentName"].ToString();

               
                closeconnection();
                for (int i = 0; i < 5; i++)
                {
                    this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                // txtBillNo.Text = dt.Rows[0]["InvoiceNo"].ToString();
                //  invid = dt.ToString();

            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        public void billview()
        {
            try
            {
                openconnection();
                SqlDataAdapter sda = new SqlDataAdapter("Select DesignNo,PCS,Meters,Rate,Total from stockIssueItem_tbl where InvoiceNo='" + invid.ToString() + "' ", scon);
                DataTable dt = new DataTable();
                sda.Fill(dt);
               
                dataGridView1.DataSource = dt;
                txtBillNo.Text = invid.ToString();

                SqlDataAdapter sdap = new SqlDataAdapter("Select VanderName from StockIssueEntry_tbl where InvoiceNo='" + invid.ToString() + "'",scon);
                DataTable dp = new DataTable();
                sdap.Fill(dp);
                TextName.Text = dp.Rows[0]["VanderName"].ToString();
                closeconnection();
                for (int i = 0; i < 5; i++)
                {
                    this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }

               // txtBillNo.Text = dt.Rows[0]["InvoiceNo"].ToString();
              //  invid = dt.ToString();
        
            }
            catch (Exception)
            {
                //MessageBox.Show(ex.Message);
            }
        }
        public void challanbind()
        {
            try
            {

                openconnection();
                scmd = new SqlCommand("Select Max(ChallanNo) from Challan1", scon);
                mkl = scmd.ExecuteScalar().ToString();

                if (mkl != "")
                {
                    TxtChallano.Text = (Convert.ToInt32(mkl) + 1).ToString();
                }
                else
                {
                    TxtChallano.Text = "1";
                }

               closeconnection();
            }
            catch (Exception)
            {

            }
        }
        public ChallanMasterFrm()
        {
            InitializeComponent();
            dttemp = new DataTable();
            if (dttemp == null || dttemp.Columns.Count <= 0)
            {

                dttemp.Columns.Add("Description");
                dttemp.Columns.Add("NoOfpieces");
                dttemp.Columns.Add("Quantity");
                dttemp.Columns.Add("Rate");
                dttemp.Columns.Add("totalamount");

                dataGridView1.DataSource = dttemp;
               // Total();
                for (int i = 0; i < 5; i++)
                {
                    this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }

            }

        }

        private void ChallanMasterFrm_Load(object sender, EventArgs e)
        {
           
            try
            {

                challanbind();
              
                billview();
                chedit();
              
            }
            catch (Exception)
            {

            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                calculation();
                openconnection();
                scmd = new SqlCommand("Select * from Challan1 where  ChallanNo ='" + TxtChallano.Text + "'", scon);
                object a = scmd.ExecuteScalar();
                if (a != null)
                {
                    MessageBox.Show("Challan No. Already Exist.");
                    TxtChallano.Focus();

                }
                
               else if (TextName.Text == "")
                {
                    MessageBox.Show("Please Fill Name");
                    TextName.Focus();
                }
               
                else
                {
                    dttemp = (System.Data.DataTable)dataGridView1.DataSource;
                    str1 = "Insert Into Challan1 values('"+txtBillNo.Text+"','" + TxtChallano.Text + "','" + Convert.ToDateTime(dtpDate.Text).ToString("MM/dd/yyyy") + "','" + TextName.Text + "','" + textAddress.Text + "','" + textAgentname.Text + "')";
                    executequerey(str1);

                    foreach (DataRow row in dttemp.Rows)
                    {
                        str2 = "Insert Into Challan2 values('" + TxtChallano.Text + "','" + row[0].ToString() + "','" + row[1].ToString() + "','" + row[2].ToString() + "','" + row[3].ToString() + "','" + row[4].ToString() + "')";
                        executequerey(str2);

                     
                        SqlDataAdapter SDAG = new SqlDataAdapter("select PCS, QuantityMeters from  ChallanDebit_tbl where  DesignNo='" + row[0].ToString() + "'", scon);
                        DataTable dgA = new DataTable();
                        SDAG.Fill(dgA);
                        if (dgA.Rows.Count > 0)
                        {

                            M = float.Parse(dgA.Rows[0]["PCS"].ToString());
                            P = float.Parse(row[1].ToString());

                            N = float.Parse(dgA.Rows[0]["QuantityMeters"].ToString());
                            O = float.Parse(row[2].ToString());

                            var PC = M + P;
                            var Mt = N + O;

                            string stup = "Update ChallanDebit_tbl set PCS='" + PC.ToString() + "', QuantityMeters='" + Mt.ToString() + "' where DesignNo='" + row[0].ToString() + "'  ";
                            executequerey(stup);
                        }
                        else
                        {

                            var PC = row[1].ToString();
                            var Qu = row[2].ToString();
                            string devi = "Insert Into ChallanDebit_tbl Values('" + row[0].ToString() + "','" + PC.ToString() + "','" + Qu.ToString() + "')";
                            executequerey(devi);
                        }

                    }
                    executequerey("Update StockIssueEntry_tbl set Status='1' where InvoiceNo='"+txtBillNo.Text+"' ");

                    MessageBox.Show("Your Record Save Successfully.");
                    Clear();
                }
            }
            catch (Exception es)
            {
                if (TxtChallano.Text == "")
                {
                    MessageBox.Show("Please Fill Challan No. " +es.Message);
                }

            }
            finally
            {
                closeconnection();
            }
        
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dttemp = (System.Data.DataTable)dataGridView1.DataSource;

                foreach (DataRow row in dttemp.Rows)
                {
                    float a = float.Parse(row[2].ToString());
                    float b = float.Parse(row[3].ToString());
                    //float c = float.Parse(row[4].ToString());
                    float c = a * b;
                    row[4] = c.ToString();


                }
            }
            catch (Exception )
            {
               // MessageBox.Show(es.Message);
            }
        }
        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                calculation();
                 if (TextName.Text == "")
                {
                    MessageBox.Show("Please Fill Name.");
                    TextName.Focus();
                }
                else
                {

                    dttemp = (System.Data.DataTable)dataGridView1.DataSource;
                    str1 = "Update Challan1 Set BillNo='" + txtBillNo.Text + "',ChallanDate='" + Convert.ToDateTime(dtpDate.Text).ToString("MM/dd/yyyy") +"',Name='" + TextName.Text + "',Address='" + textAddress.Text + "',AgentName='" + textAgentname.Text + "' where ChallanNo='" + TxtChallano.Text + "' ";
                    executequerey(str1);
                    str2 = " Delete From Challan2 where ChallanNo='" + TxtChallano.Text + "' ";
                    executequerey(str2);
                    foreach (DataRow row in dttemp.Rows)
                    {
                        str2 = "Insert Into Challan2 values('" + TxtChallano.Text + "','" + row[0].ToString() + "','" + row[1].ToString() + "','" + row[2].ToString() + "','" + row[3].ToString() + "','" + row[4].ToString() + "')";
                        executequerey(str2);

                        SqlDataAdapter SDAG = new SqlDataAdapter("select PCS, QuantityMeters from  ChallanDebit_tbl where  DesignNo='" + row[0].ToString() + "'", scon);
                        DataTable dgA = new DataTable();
                        SDAG.Fill(dgA);

                          M = float.Parse(dgA.Rows[0]["PCS"].ToString());
                          N = float.Parse(dgA.Rows[0]["QuantityMeters"].ToString());
                          
                            SqlDataAdapter SDG = new SqlDataAdapter("select PCS, QuantityMeters from  AvailableStock_tbl where  DesignNo='" + row[0].ToString() + "'", scon);
                            DataTable dg = new DataTable();
                            SDG.Fill(dg);

                            P = float.Parse(dg.Rows[0]["PCS"].ToString());
                            O = float.Parse(dg.Rows[0]["QuantityMeters"].ToString());
                             
                            var PC = M + P;
                            var Mt = N + O;
                            string stup = "Update AvailableStock_tbl set PCS='" + PC.ToString() + "', QuantityMeters='" + Mt.ToString() + "' where DesignNo='" + row[0].ToString() + "'  ";
                            executequerey(stup);
                            string del = "Delete From ChallanDebit_tbl where DesignNo ='" + row[0].ToString() + "'";
                            executequerey(del);
                    }
                    MessageBox.Show("Your Record Update Successfully.");

                }
            }
            catch (Exception ed)
            {
                MessageBox.Show("Your Record Not Update" +ed.Message);
            }
            finally
            {
                Clear();
            }
        }

        private void butPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                TxtChallano.Text = (Convert.ToInt32(TxtChallano.Text) - 1).ToString();
                sda = new SqlDataAdapter("Select * from Challan1 where ChallanNo='"+TxtChallano.Text+"'", scon);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                //if (s <= dt.Rows.Count)
                //{
                //    s--;
                   // labstocitemid.Text=dt.Rows[s]["CId"].ToString();
                    txtBillNo.Text = dt.Rows[s]["BillNo"].ToString();
                    TxtChallano.Text = dt.Rows[s]["ChallanNo"].ToString();
                    dtpDate.Text = dt.Rows[s]["ChallanDate"].ToString();
                    TextName.Text = dt.Rows[s]["Name"].ToString();
                    textAddress.Text = dt.Rows[s]["Address"].ToString();
                    textAgentname.Text = dt.Rows[s]["AgentName"].ToString();

                    SqlDataAdapter sda1 = new SqlDataAdapter("select Description,NoOfpieces,Quantity,Rate,totalamount from Challan2 where ChallanNo='" + TxtChallano.Text + "'", scon);
                    DataTable dt1 = new DataTable();
                    sda1.Fill(dt1);
                    dataGridView1.DataSource = dt1;
                    for (int i = 0; i < 5; i++)
                    {
                        this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                //}
                //else
                //{
                //}
            }
            catch
            {
                TxtChallano.Text = (Convert.ToInt32(TxtChallano.Text) +1).ToString();
                MessageBox.Show(" No More Data Found.");
            }
        }

        private void butNext_Click(object sender, EventArgs e)
        {
            try
            {
                TxtChallano.Text = (Convert.ToInt32(TxtChallano.Text) + 1).ToString();
                sda = new SqlDataAdapter("Select * from Challan1 where ChallanNo='"+TxtChallano.Text+"'", scon);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                   //labstocitemid.Text=dt.Rows[s]["CId"].ToString();
                    txtBillNo.Text = dt.Rows[s]["BillNo"].ToString();
                    TxtChallano.Text = dt.Rows[s]["ChallanNo"].ToString();
                    dtpDate.Text = dt.Rows[s]["ChallanDate"].ToString();
                    TextName.Text = dt.Rows[s]["Name"].ToString();
                    textAddress.Text = dt.Rows[s]["Address"].ToString();
                    textAgentname.Text = dt.Rows[s]["AgentName"].ToString();

                    SqlDataAdapter sda1 = new SqlDataAdapter("select Description,NoOfpieces,Quantity,Rate,totalamount from Challan2 where ChallanNo='" + TxtChallano.Text + "'", scon);
                    DataTable dt1 = new DataTable();
                    sda1.Fill(dt1);
                    dataGridView1.DataSource = dt1;
                    for (int i = 0; i < 5; i++)
                    {
                        this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                //}
                //else
                //{
                //}
            }
            catch (Exception ED)
            {
                MessageBox.Show("Data Not Found." + ED.Message);
                Clear();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                     sda = new SqlDataAdapter("Select * from Challan2 ", scon);
                    dt = new DataTable();
                    sda.Fill(dt);
                    int i;
                    int j;
                    i = e.RowIndex;
                    j = e.ColumnIndex;
                    chaid = dt.Rows[i][0].ToString();
                    labRid.Text = dt.Rows[i]["Itemid"].ToString();
                  
             }
            catch (Exception)
            {
                // MessageBox.Show(es.Message);
            }   
            
        }

        private void butDelete_Click(object sender, EventArgs e)
        {
            try
            {
               var button = MessageBox.Show("Do You Want to Delete ?", "Cloth Company.", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
               if (button == DialogResult.Yes)
               {

                   if (TextName.Text == "")
                   {
                       MessageBox.Show("Please Fill Name");
                       TextName.Focus();
                   }
                   else
                   {
                       str1 = " Delete From Challan1 where ChallanNo='" + TxtChallano.Text + "' ";
                       executequerey(str1);

                       str2 = " Delete From Challan2 where ChallanNo=" +TxtChallano.Text + " ";
                       executequerey(str2);
                       MessageBox.Show("Your Record Deleted");
                       Clear();
                   }
               }
               if (button == DialogResult.No)
               {
               }   
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
            finally
            {
              
            }
        }

        private void butClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

       
        private void butBrows_Click(object sender, EventArgs e)
        {
            new challStockEditFrm().ShowDialog();
            this.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var button = MessageBox.Show("Do You Want to Delete ?", "Cloth Company.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (button == DialogResult.Yes)
                {

                    dttemp.Rows.RemoveAt(e.RowIndex);
                    dataGridView1.DataSource = dttemp;
                }
                if (button == DialogResult.No)
                {
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
  
            }
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                dttemp = (System.Data.DataTable)dataGridView1.DataSource;
                string headerText = dataGridView1.Columns[e.ColumnIndex].HeaderText;
                int count = dataGridView1.Rows.Count - 1;
                if (e.RowIndex != count)
                {
                    if (headerText.Equals("NoOfpieces"))
                    {
                        if (string.IsNullOrEmpty(e.FormattedValue.ToString()))
                        {
                            //  dataGridView1.Rows[e.RowIndex].ErrorText = "Description Of Good Must Not be empty";
                            MessageBox.Show("No.Of pieces Good Must not empty");
                            e.Cancel = true;
                        }
                    }
                }

            }
            catch (Exception)
            {
                // MessageBox.Show(es.Message);
            }
        }

        private void butAll_Click(object sender, EventArgs e)
        {
            new ChallanEditViewFrm().ShowDialog();
            this.Close();
        }

        private void butDebit_Click(object sender, EventArgs e)
        {
            new CalanAViManuForm2().Show();

        }

        private void TxtChallano_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 46 || e.KeyChar == 45) != true)
                {
                    e.Handled = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtBillNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 46 || e.KeyChar == 45) != true)
                {
                    e.Handled = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
    }
}