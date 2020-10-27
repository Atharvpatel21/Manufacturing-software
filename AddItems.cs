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
    public partial class AddItems : Form
    {
        SqlConnection con = new SqlConnection(Connection.cs);
        //SqlDataAdapter sda;
        DataSet ds;
        //SqlDataReader sdr;
        SqlCommand cmd;
        SqlDataAdapter da;
       // SqlDataReader sdr;
        string abc,id;
        double a;
        public AddItems()
        {
            InitializeComponent();
        }
        private void blank()
        {
            btn_Delete.Enabled = false;
            btn_Update.Enabled = false;
            Btn_Additem.Enabled = true;
            txt_description.Focus();
            txt_amount.Text = "";
            txt_description.Text = "";
            txt_Grey_metter.Text = "";
            txt_Lot_No.Text = "";
            txt_Lr_No.Text = "";
            txt_peces.Text = "";
            txt_total_Amount.Text = "";
            txt_remarks.Text = "";

        }
        private void bind()
        {
            ds = new DataSet();
            da = new SqlDataAdapter("Select * from stock", con);
            da.Fill(ds);
            //dataGridView1.DataSource = ds.Tables[0];
        }


        private void Btn_Additem_Click(object sender, EventArgs e)
        {
            con.Close();

            con.Open();
            ds = new DataSet();

            if (txt_description.Text == "")
            {
                MessageBox.Show("Please Enterb Goods Description");
                txt_description.Focus();
                return;
            }
            if (txt_Lr_No.Text == "")
            {
                MessageBox.Show("Please Enter Goods Lr No");
                txt_Lr_No.Focus();
                return;
            }
            if (txt_Lot_No.Text == "")
            {
                MessageBox.Show("Please Enter Goods Lot No");
                txt_Lot_No.Focus();
                return;
            }
            if (txt_Grey_metter.Text == "")
            {
                MessageBox.Show("Please Enter Grey Metters");
                txt_Grey_metter.Focus();
                return;
            }

            if (txt_peces.Text == "")
            {
                MessageBox.Show("Please Enter Total Peces");
                txt_peces.Focus();
                return;
            }
            if (txt_amount.Text == "")
            {
                MessageBox.Show("Please Enter Amount");
                txt_amount.Focus();
                return;
            }
            if (txt_remarks.Text == "")
            {
                MessageBox.Show("Please Enter Remarks");
                txt_remarks.Focus();
                return;
            }
            a = Convert.ToDouble(txt_peces.Text) * Convert.ToDouble(txt_Grey_metter.Text) * Convert.ToDouble(txt_amount.Text);

            
            abc = "insert into stock(Des_Goods,Lr_No,Lot_No,Gray_Mts,Pcs,Amount,Total_Amount,Remarks)values('" + txt_description.Text + "','" + txt_Lr_No.Text + "','" + txt_Lot_No.Text + "','" + txt_Grey_metter.Text + "','" + txt_peces.Text + "','" + txt_amount.Text + "','" + a + "','" + txt_remarks.Text + "')";


            cmd = new SqlCommand(abc, con);
            cmd.ExecuteNonQuery();
            bind();
            blank();
            con.Close();

        }

        private void AddItems_Load(object sender, EventArgs e)
        {
            btn_Delete.Enabled = false;
            btn_Update.Enabled = false;
            bind();
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            Btn_Additem.Enabled = true;
            con.Open();
            da = new SqlDataAdapter();
            ds = new DataSet();
            abc = "delete from stock where stok_id=" + id;
            cmd = new SqlCommand(abc, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Your Record Successfull Delete");
            con.Close();
            bind();
        }

        //private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    con.Open();
        //    SqlDataAdapter da = new SqlDataAdapter("select * from stock", con);
        //    DataTable td = new DataTable();
        //    da.Fill(td);
        //    btn_Update.Enabled = true;
           
        //    btn_Delete.Enabled = true;
        //    Btn_Additem.Enabled = false;
        //    dataGridView1.DataSource = td;
        //    int i, j;
        //    i = e.RowIndex;
        //    j = e.ColumnIndex;
        //    id = td.Rows[i][0].ToString();
        //    txt_description.Text = td.Rows[i][1].ToString();
        //    txt_Lr_No.Text = td.Rows[i][2].ToString();
        //    txt_Lot_No.Text = td.Rows[i][3].ToString();
        //    txt_Grey_metter.Text = td.Rows[i][4].ToString();
        //    txt_peces.Text = td.Rows[i][5].ToString();
        //    txt_amount.Text = td.Rows[i][6].ToString();
        //    txt_total_Amount.Text = td.Rows[i][7].ToString();
        //    txt_remarks.Text = td.Rows[i][8].ToString();
        //    con.Close();

        //}

        private void btn_Update_Click(object sender, EventArgs e)
        {
            con.Open();
            ds = new DataSet();

            

            a = Convert.ToDouble(txt_peces.Text) * Convert.ToDouble(txt_Grey_metter.Text) * Convert.ToDouble(txt_amount.Text);

            abc = "update stock set Des_Goods='" + txt_description.Text + "',Lr_No='" + txt_Lr_No.Text + "',Lot_No='" + txt_Lot_No.Text + "',Gray_Mts='" + txt_Grey_metter.Text + "',Pcs='" + txt_peces.Text + "',Amount='" + txt_amount.Text + "',Total_Amount='" + a + "',Remarks='" + txt_remarks.Text + "' where stok_id='" + id + "'";
            cmd = new SqlCommand(abc, con);
          //  da = new SqlDataAdapter(abc, con); 
            cmd.ExecuteNonQuery();
            blank();
            bind();


            con.Close();
        }

        private void Btn_cencel_Click(object sender, EventArgs e)
        {
            blank();
            this.Close();

        }

        private void txt_Grey_metter_KeyPress(object sender, KeyPressEventArgs e)
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
                MessageBox.Show(ex.Message.ToString());
            }

        }

        private void txt_peces_KeyPress(object sender, KeyPressEventArgs e)
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
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void txt_amount_KeyPress(object sender, KeyPressEventArgs e)
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
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void txt_Lr_No_KeyPress(object sender, KeyPressEventArgs e)
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
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void txt_Lot_No_KeyPress(object sender, KeyPressEventArgs e)
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
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void txt_total_Amount_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            
        }

        private void txt_total_Amount_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void txt_total_Amount_KeyUp(object sender, KeyEventArgs e)
        {
            a = Convert.ToDouble(txt_peces.Text) * Convert.ToDouble(txt_Grey_metter.Text) * Convert.ToDouble(txt_amount.Text);
            txt_total_Amount.Text = a.ToString();
        }

        private void txt_total_Amount_TextChanged(object sender, EventArgs e)
        {

        }







    }
        }
        
