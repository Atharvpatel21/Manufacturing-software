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
    public partial class AvailableGrayStockEdit : Form
    {
        

       
        SqlConnection scon = new SqlConnection(Connection.cs);
        SqlCommand scmd;
        SqlDataAdapter sda;
        DataTable dt;
        string str;

        public void bind(string str)
        {
            try
            {
                scon.Open();
                sda = new SqlDataAdapter(str, scon);
                dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                scon.Close();
            }
            catch (Exception)
            {

            }
        }

        public void executequerey(string str)
        {
            try
            {
                scon.Open();
                scmd = new SqlCommand(str, scon);
                scmd.ExecuteNonQuery();
                scon.Close();
            }
            catch (Exception)
            {
            }
        }

        public AvailableGrayStockEdit()
        {
            InitializeComponent();
        }

        private void AvailableReportFrm_Load(object sender, EventArgs e)
        {
            str = "Select DesignNo,PCS,QuantityMeters from AvailableStock_tbl";
            bind(str);
        }

        private void butDelete_Click(object sender, EventArgs e)
        {

            str = "Delete from AvailableStock_tbl where Aid ='" + labAid.Text + "'";
            executequerey(str);
            MessageBox.Show("Are you Sure Deleted");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                scon.Open();
                SqlDataAdapter sda1 = new SqlDataAdapter("Select * from AvailableStock_tbl", scon);
                DataTable de = new DataTable();
                sda1.Fill(de);
                int i, j;
                i = e.RowIndex;
                j = e.ColumnIndex;
                labAid.Text = de.Rows[i][0].ToString();
                scon.Close();
            }
            catch (Exception )
            {
                
            }
        }

       
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                str = "Select DesignNo,PCS,QuantityMeters from AvailableStock_tbl where DesignNo='" + textBox1.Text + "' ";
            }
            else
            {
                str = "Select DesignNo,PCS,QuantityMeters from AvailableStock_tbl";
            }            
            bind(str);
            
        }
    }
}
