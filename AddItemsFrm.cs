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
    public partial class AddItemsFrm : Form
    {
        SqlConnection con = new SqlConnection(Connection.cs);
        DataSet ds;
        SqlDataAdapter da;
        SqlDataReader sdr;
        SqlCommand cmd;
        double a, b, c, d;
        DataTable dt;
        string abc, id, l;
        int S;


        public void executequerey(string str)
        {
            openconnection();
            cmd = new SqlCommand(str, con);
            cmd.ExecuteNonQuery();
            closeconnection();
        }
        public void openconnection()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }

        public void closeconnection()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
        public void total()
        {/////////////////Function Calculator////////////////
            try
            {
                a = Convert.ToDouble(txtpeces.Text);
                b = Convert.ToDouble(txtmetter.Text);
                c = Convert.ToDouble(txtrate.Text);
                d = a * b * c;
                txttotal.Text = d.ToString();
            }
            catch
            {
                if (txtpeces.Text == "")
                {
                    txtpeces.Text = "";
                }
                if (txtmetter.Text == "")
                {
                    txtmetter.Text = "";

                }
                if (txtrate.Text == "")
                {
                    txtrate.Text = "";
                }
            }///////////End Calculator Function///////////////////////
        }
        public AddItemsFrm()
        {
            InitializeComponent();
        }

        public string catchid
        {
            set
            {
                l = value;
            }
        }
        private void Blankfilled()
        {
            ////////////////Start Blank Field Function///////////////////////////
            txtbale.Text = "";
            txtdescription.Text = "";
            txtDesign.Text = "";
            txtmetter.Text = "";
            txtpeces.Text = "";
            txtrate.Text = "";
            txttotal.Text = "";
            ////////////////////End Blank Field Function////////////////////
        }


        private void fillgrid()
        {
            /////////////Start FillGrid function/////////
            openconnection();
            da = new SqlDataAdapter("select Description,DesignNo,BaleNo,PCS,Meters,Rate,Total from TempAddItem", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            closeconnection();
            for (int i = 0; i < 7; i++)
            {
                this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

            }
            ////////////End FillGrid Function///////////////////////////////
            ///////////Fill 
        }
        private void Btn_Additem_Click(object sender, EventArgs e)
        {
            try
            {

                openconnection();
                cmd = new SqlCommand("Select * from TempAddItem where  DesignNo ='" + txtDesign.Text + "'", con);
                object a = cmd.ExecuteScalar();
                if (a != null)
                {
                    MessageBox.Show("Design No. Already Exist.");
                    txtDesign.Focus();

                }

                /////////////////Start Insert Data in Temprary Table /////////

                else if (txtdescription.Text == "")
                {
                    MessageBox.Show("Please Enter Cloths Description");
                    txtdescription.Focus();
                    return;
                }

                else if (txtbale.Text == "")
                {
                    MessageBox.Show("please Enter Cloths Bale No.");
                    txtbale.Focus();
                    return;
                }
                else if (txtpeces.Text == "")
                {
                    MessageBox.Show("Please Enter No Of Cloths Peces");
                    txtpeces.Focus();
                    return;
                }
                else if (txtmetter.Text == "")
                {
                    MessageBox.Show("Please Enter No Of Cloths Meters");
                    txtmetter.Focus();
                    return;
                }
                else if (txtrate.Text == "")
                {
                    MessageBox.Show("Please Enter Cloths Rate");
                    txtrate.Focus();
                    return;
                }
                else
                {

                    da = new SqlDataAdapter();
                    ds = new DataSet();
                    abc = "insert into TempAddItem(Description,DesignNo,BaleNo,PCS,Meters,Rate,Total)values('" + txtdescription.Text.Replace("'", "") + "','" + txtDesign.Text + "','" + txtbale.Text + "','" + txtpeces.Text + "','" + txtmetter.Text + "','" + txtrate.Text + "','" + txttotal.Text + "')";

                    da.InsertCommand = new SqlCommand(abc, con);
                    closeconnection();
                    openconnection();
                    da.InsertCommand.ExecuteNonQuery();
                    closeconnection();

                    ///////////////End Insert Data In Temprary Function///////////////////
                    /////////////Start Fillgrid Function//////////////\\\\\\\\\\\\\\\\\\\\
                    fillgrid();
                    MessageBox.Show("Your Record  Save Successfully.");
                    ///////////End Fillgrid Function///////////////////
                }
            }
            catch (Exception es)
            {
                MessageBox.Show("Your Record Not Save.", es.Message);
            }
            finally
            {
                closeconnection();
            }
        }

        private void AddItemsFrm_Load(object sender, EventArgs e)
        {
            con.Close();
            //con.Open();
            //cmd = new SqlCommand("Select Max(StockId) from TempAddItem", con);
        
            //sdr = cmd.ExecuteReader();
            //while (sdr.Read() == true)
            //{
            //    label4.Text = sdr[0].ToString();
            //}
            //sdr.Close();
            //con.Close();

            //////////////////////Start Fill Grid Function   Coll ////////////
            fillgrid();
           
                /////////////Close Fill Grid Function///////////////////////
                /////////////Fill Text Box On GridView Cell Click///////////////////


                try
                {
                    if (l != null)
                    {
                        ds = new DataSet();
                        da = new SqlDataAdapter();
                        abc = "select * from mainAddItem where StockId =" + l;
                        da.SelectCommand = new SqlCommand(abc, con);
                        da.Fill(ds);

                        txtdescription.Text = ds.Tables[0].Rows[0]["Description"].ToString();
                        txtDesign.Text = ds.Tables[0].Rows[0]["DesignNo"].ToString();
                        txtbale.Text = ds.Tables[0].Rows[0]["BaleNo"].ToString();
                        txtpeces.Text = ds.Tables[0].Rows[0]["PCS"].ToString();
                        txtmetter.Text = ds.Tables[0].Rows[0]["Meters"].ToString();
                        txtrate.Text = ds.Tables[0].Rows[0]["Rate"].ToString();
                        txttotal.Text = ds.Tables[0].Rows[0]["Total"].ToString();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            
        }

        private void Btn_cencel_Click(object sender, EventArgs e)
        {
            ////////////Cancel Butten//////////////////////
            try
            {
                con.Close();
                con.Open();
                cmd = new SqlCommand("truncate table TempAddItem", con);
                cmd.ExecuteNonQuery();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            //////////////End////////////////////////////////////
 
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("update TempAddItem set Description = '" + txtdescription.Text.Replace("'","") + "',DesignNo = '" + txtDesign.Text + "',BaleNo = '" + txtbale.Text + "',PCS = '" + txtpeces.Text + "',Meters = '" + txtmetter.Text + "',Rate = '" + txtrate.Text + "',Total = '" + txttotal.Text + "' where StockId = '" + label4.Text + "' ", con);
                con.Open();
                cmd.ExecuteNonQuery();
                fillgrid();
                con.Close();
                MessageBox.Show("Your Record Successfull Update");
            }
            catch (Exception es)
            {
                MessageBox.Show("Do Not Update Record.", es.Message);
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {

                var button = MessageBox.Show("Do You Want to Delete ?. ", "Cloth_Company......", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (button == DialogResult.Yes)
                {
                    
                    //cmd = new SqlCommand("delete from TempAddItem where StockId='" + label4.Text + "' ", con);
                    cmd = new SqlCommand("Delete from TempAddItem where DesignNo='" + txtDesign.Text + "'", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    fillgrid();
                    con.Close();
                    //  MessageBox.Show("Your Record Successful Delete");
                }
                if (button == DialogResult.No)
                {

                }
            }
            catch (Exception es )
            {
                MessageBox.Show("Not Delete."+es.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                abc = "select * from TempAddItem";
                openconnection();
                SqlDataAdapter da1 = new SqlDataAdapter(abc, con);
                DataTable dt = new DataTable();
                da1.Fill(dt);
                dataGridView1.DataSource = dt;
                int i, j;
                i = e.RowIndex;
                j = e.ColumnIndex;
                label4.Text = dt.Rows[i][0].ToString();
                txtdescription.Text =dt.Rows[i][1].ToString();
                 txtDesign.Text = dt.Rows[i][2].ToString();
                txtbale.Text = dt.Rows[i][3].ToString();
               txtpeces.Text = dt.Rows[i][4].ToString();
               txtmetter.Text = dt.Rows[i][5].ToString();
               txtrate.Text = dt.Rows[i][6].ToString();
               txttotal.Text = dt.Rows[i][7].ToString();
               closeconnection();
            }
            catch (Exception )
            {
               // MessageBox.Show(ex.Message.ToString());
            }
            //////////////End/////////////////////
        }

        private void btnAddrecord_Click(object sender, EventArgs e)
        {
            new GrayStockEntryFrm().Show();
        }

      

        private void txtpeces_TextChanged(object sender, EventArgs e)
        {
            total();
        }

        private void txtmetter_TextChanged(object sender, EventArgs e)
        {
            total();
        }

        private void txtrate_TextChanged(object sender, EventArgs e)
        {
            total();
        }

        private void txtrate_KeyPress(object sender, KeyPressEventArgs e)
        {
            /////////Only Number Insert Ho //////////
            try
            {
                if (((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 45 || e.KeyChar == 46) != true)
                {
                    e.Handled = true; ;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            ///////////////////////End//////////////////// 
        }

        private void txtmetter_KeyPress(object sender, KeyPressEventArgs e)
        {
            /////////Only Number Insert Ho //////////
            try
            {
                if (((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 45 || e.KeyChar == 46) != true)
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }////////////End////////////////////
        }

        private void txtpeces_KeyPress(object sender, KeyPressEventArgs e)
        {
            /////////Only Number Insert Ho //////////
            try
            {
                if (((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 45 || e.KeyChar == 46) != true)
                {
                    e.Handled = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }////////////End////////////////
        }

        private void txtbale_KeyPress(object sender, KeyPressEventArgs e)
        {
            /////////Only Number Insert Ho //////////
            try
            {
                if (((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == 8 || e.KeyChar == 45 || e.KeyChar == 46) != true)
                {
                    e.Handled = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }////////////End////////////////
        }

        private void butclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da1 = new SqlDataAdapter("select * from TempAddItem ", con);
                DataTable dt = new DataTable();
                da1.Fill(dt);
                if (S <= dt.Rows.Count - 1)
                {
                    S--;
                    label4.Text = dt.Rows[S]["StockId"].ToString();
                    txtdescription.Text = dt.Rows[S]["Description"].ToString();
                    txtDesign.Text = dt.Rows[S]["DesignNo"].ToString();
                    txtbale.Text = dt.Rows[S]["BaleNo"].ToString();
                    txtpeces.Text = dt.Rows[S]["PCS"].ToString();
                    txtmetter.Text = dt.Rows[S]["Meters"].ToString();
                    txtrate.Text = dt.Rows[S]["Rate"].ToString();
                    txttotal.Text = dt.Rows[S]["Total"].ToString();

                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void butNext_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter da1 = new SqlDataAdapter("select * from TempAddItem ", con);
                DataTable dt = new DataTable();
                da1.Fill(dt);
                if (S <= dt.Rows.Count - 1)
                {
                    S++;
                    label4.Text = dt.Rows[S]["StockId"].ToString();
                    txtdescription.Text = dt.Rows[S]["Description"].ToString();
                    txtDesign.Text = dt.Rows[S]["DesignNo"].ToString();
                    txtbale.Text = dt.Rows[S]["BaleNo"].ToString();
                    txtpeces.Text = dt.Rows[S]["PCS"].ToString();
                    txtmetter.Text = dt.Rows[S]["Meters"].ToString();
                    txtrate.Text = dt.Rows[S]["Rate"].ToString();
                    txttotal.Text = dt.Rows[S]["Total"].ToString();
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void butClear_Click(object sender, EventArgs e)
        {
            Blankfilled();
        }

        private void butShow_Click(object sender, EventArgs e)
        {
            fillgrid();
        }
    }
}
