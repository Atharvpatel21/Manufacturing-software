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
    public partial class AvailablegridviewFrm : Form
    {
        SqlConnection scon = new SqlConnection(Connection.cs);
        SqlCommand scmd;
        SqlDataAdapter sda;
        DataTable dt;
        string str,str1;
        DataTable dttemp;
        DataRow row;
        public void bind( string str)
        {
            scon.Open();
            sda = new SqlDataAdapter(str, scon);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            scon.Close();
        }

        public void executequerey(string str)
        {
            scon.Open();
            scmd = new SqlCommand(str, scon);
            scmd.ExecuteNonQuery();
            scon.Close();
        }

        public AvailablegridviewFrm()
        {
            InitializeComponent();

           
        }

        private void AvailablegridviewFrm_Load(object sender, EventArgs e)
        {
            str = "Select DesignNo,PCS,QuantityMeters from AvailableStockIsuue_tbl";
            bind(str);
        }

        

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                scon.Open();
                SqlDataAdapter sda1 = new SqlDataAdapter("Select * from AvailableStockIsuue_tbl", scon);
                DataTable de = new DataTable();
                sda1.Fill(de);
                int i, j;
                i = e.RowIndex;
                j = e.ColumnIndex;
                labid.Text = de.Rows[i][0].ToString();
                scon.Close();
            }
            catch (Exception)
            {
            }
       }

        private void butUpdate_Click(object sender, EventArgs e)
        {
        //    try
        //    {
        //        dttemp = (System.Data.DataTable)dataGridView1.DataSource;

        //        str1 = "Delete From AvailableStockIsuue_tbl where Aid='" + labid.Text + "'";
        //        executequerey(str1);
        //        foreach (DataRow row in dttemp.Rows)
        //        {
        //            str = "Insert Into AvailableStockIsuue_tbl Values(DesignNo='" + row[0].ToString() + "', QuantityMeters='" + row[1].ToString() + "') ";
        //            executequerey(str);
        //        }
        //        MessageBox.Show("Your Record Update Successfully.");
        //    }
        //    catch (Exception es)
        //    {
        //        MessageBox.Show("Your Record Not Update. " + es.Message);
        //    }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                str = "Select DesignNo,PCS,QuantityMeters from AvailableStockIsuue_tbl where DesignNo='" + textBox1.Text + "' ";
            }
            else
            {
                str = "Select DesignNo,PCS,QuantityMeters from AvailableStockIsuue_tbl";
            }
            bind(str);
        }

      
    }
}
