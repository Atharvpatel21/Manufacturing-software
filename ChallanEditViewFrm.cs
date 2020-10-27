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
    public partial class ChallanEditViewFrm : Form
    {
        SqlConnection scon = new SqlConnection(Connection.cs);
        SqlCommand scmd;
        SqlDataAdapter sda;
        DataTable dt;
        string str;
        public void bind()
        {
            openconnection();
            sda = new SqlDataAdapter("Select * from Challan1", scon);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            closeconnection();

        }

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
        public string priya
        {
            get
            {
                return labinvoNo.Text;

            }
        }
        public ChallanEditViewFrm()
        {
            InitializeComponent();
        }

        private void ChallanEditViewFrm_Load(object sender, EventArgs e)
        {
            bind();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                openconnection();
                SqlDataAdapter sda1 = new SqlDataAdapter("Select * from Challan1", scon);
                DataTable de = new DataTable();
                sda1.Fill(de);
                int i, j;
                i = e.RowIndex;
                j = e.ColumnIndex;
                // labinvoNo.Text= de.Rows[i][0].ToString();
                labinvoNo.Text = de.Rows[i]["ChallanNo"].ToString();
                dataGridView1.DataSource = de;

                   ChallanMasterFrm cha = new ChallanMasterFrm();
                   cha.priya = priya;
                   cha.Show();

                closeconnection();
                this.Close();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        private void butBrows_Click(object sender, EventArgs e)
        {
            new ChallanMasterFrm().Show();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                openconnection();
                str = "Select * from Challan1 where ChallanNo like '" + textBox1.Text + "%'";
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
