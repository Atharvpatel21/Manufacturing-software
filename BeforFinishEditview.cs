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
    public partial class BeforFinishEditview : Form
    {
        SqlConnection scon = new SqlConnection(Connection.cs);
        SqlCommand scmd;
        private SqlDataAdapter sqlDataAdapter = null;
        private SqlCommandBuilder sqlCommandBuilder = null;
        private DataTable dataTable = null;
        private BindingSource bindingSource = null;
        private String selectQueryString = null;

        string str, bfinvo;

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

        public BeforFinishEditview()
        {
            InitializeComponent();
        }
        public string sandy
        {
            get
            {
                return labinvoNo.Text;
            }
        }
        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BeforFinishEditview_Load(object sender, EventArgs e)
        {
            try
            {
                selectQueryString = "SELECT * FROM RecieveFinish1 ";
                scon.Open();
                sqlDataAdapter = new SqlDataAdapter(selectQueryString, scon);
                sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);
                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                bindingSource = new BindingSource();
                bindingSource.DataSource = dataTable;
                dataGridView1.DataSource = bindingSource;
                dataGridView1.Columns[0].Visible = false;
                scon.Close();
            }
            catch (Exception)
            {
            }
            //for (int i = 0; i < 12; i++)
            //{
            //    this.dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            //}
        }

        private void butUpdate_Click(object sender, EventArgs e)
        {
        //    try
        //    {
        //        var button = MessageBox.Show("Your Record Updated Successfully", "Cloths Project.", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
        //        if (button == DialogResult.Yes)
        //        {
        //            sqlDataAdapter.Update(dataTable);
        //        }
        //    }
        //    catch (Exception exceptionObj)
        //    {
        //        MessageBox.Show(exceptionObj.Message.ToString());
        //    }

            new RecieveAfterFinishing().Show();
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                openconnection();
                str = "Select * from RecieveFinish1 where SendSerialNo like '" + textBox1.Text + "%'";
                sqlDataAdapter = new SqlDataAdapter(str, scon);
                DataSet de = new DataSet();
                sqlDataAdapter.Fill(de);
                dataGridView1.DataSource = de.Tables[0];
                closeconnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void butDel_Click(object sender, EventArgs e)
        {

           var button = MessageBox.Show("Your Record Deleted Successfully", "Cloths Project.", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
           if (button == DialogResult.Yes)
           {
               str = "Delete From  RecieveFinish1 where SendSerialNo='" + textBox1.Text + "' ";
               executequerey(str);
            }


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                openconnection();

                sqlDataAdapter = new SqlDataAdapter("Select * from RecieveFinish1 ", scon);
                dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                int i;
                i = e.RowIndex;
                labinvoNo.Text = dataTable.Rows[i]["RecieveNo"].ToString();
                //labinvoNo.Text;
                dataGridView1.DataSource = dataTable;

                RecieveAfterFinishing rec = new RecieveAfterFinishing();
                rec.sandy = sandy;
                rec.Show();

               // closeconnection();
               // this.Close();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
            finally
            {
              //  closeconnection();
            }
        }

    }
}
