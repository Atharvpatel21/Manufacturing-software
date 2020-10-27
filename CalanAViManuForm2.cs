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
    public partial class CalanAViManuForm2 : Form
    {
        SqlConnection scon = new SqlConnection(Connection.cs);
        SqlCommand scmd;
        SqlDataAdapter sda;
        DataTable dt;
        string str, str1;
        DataTable dttemp;
        DataRow row;
        public void bind(string str)
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

        public CalanAViManuForm2()
        {
            InitializeComponent();
        }

        private void CalanAViManuForm2_Load(object sender, EventArgs e)
        {
            str = "Select DesignNo,PCS,QuantityMeters from ChallanDebit_tbl";
            bind(str);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                str = "Select DesignNo,PCS,QuantityMeters from ChallanDebit_tbl where DesignNo='" + textBox1.Text + "' ";
            }
            else
            {
                str = "Select DesignNo,PCS,QuantityMeters from ChallanDebit_tbl";
            }
            bind(str);
        }
    }
}
