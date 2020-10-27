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
    public partial class CityForm : Form
    {
        SqlConnection scon = new SqlConnection(Connection.cs);
        SqlCommand scmd;
        SqlDataAdapter sdap;
        SqlDataReader sdr;
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        public void statebind()
        {
            sdap = new SqlDataAdapter("Select StateName from State_tbl", scon);
            sdap.Fill(dt);
            combStateName.Items.Add(dt.ToString());
          
        }
        public void bind()
        {
            scon.Open();
            sdap = new SqlDataAdapter("Select StateName from State_tbl", scon);
            DataSet ds = new DataSet();
            ds.Clear();
            sdap.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            scon.Close();
        }
        public void Citybind()
        {
            scon.Open();
            sdap = new SqlDataAdapter("Select * from City_tbl ", scon );
            DataSet ds= new DataSet();
            ds.Clear();
            sdap.Fill(ds);
            dataGridView1.DataSource= ds.Tables[0];
            scon.Close();
      }

        public CityForm()
        {
            InitializeComponent();
        }

        private void butsave_Click(object sender, EventArgs e)
        {
            var button = MessageBox.Show("Data Save Successfully.......", "Colths_Company", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (button == DialogResult.Yes)
            {

                CityClass inc = new  CityClass();
                inc.StateName =combStateName.Text;
                inc.CityName = TxtCityName.Text;
                inc.instcity(inc);
                Citybind();
                combStateName.Text = "";
                 TxtCityName.Text = "";
            }
        }

        private void CityForm_Load(object sender, EventArgs e)
        {
            Citybind();
            scon.Open();
            scmd = new SqlCommand("Select StateName from State_tbl", scon);
            sdr = scmd.ExecuteReader();
            combStateName.Items.Clear();
            while (sdr.Read() == true)
            {
                combStateName.Items.Add(sdr[0].ToString());
            }
            sdr.Close();
            scon.Close();
        }

        private void combStateName_SelectedIndexChanged(object sender, EventArgs e)
        {
            statebind();
           
        }

        private void butupdate_Click(object sender, EventArgs e)
        {
            var button = MessageBox.Show("Data Update Successfully.......", "Colths_Company", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (button == DialogResult.Yes)
            {

               CityClass us = new CityClass();
               us.StateName = combStateName.Text;
               us.CityName = TxtCityName.Text;
               us.CityId= Convert.ToInt32(TxtCityId.Text);
               us.udatecit(us);
               Citybind();
               combStateName.Text = "";
               TxtCityId.Text="";
               TxtCityName.Text = "";
            }

        }

        private void butclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butDelete_Click(object sender, EventArgs e)
        {

            var button = MessageBox.Show("Data Delete Successfully....... ", "Cloth_Company.", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
            if (button == DialogResult.Yes)
            {
                CityClass d = new CityClass();
                d.CityId = Convert.ToInt32(TxtCityId.Text);
                d.delete(d);
                Citybind();
                TxtCityName.Text = "";
                combStateName.Text = "";
                TxtCityId.Text = "";
           }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                scon.Open();
                sdap = new SqlDataAdapter("Select * from City_tbl", scon);
                DataTable dt = new DataTable();
                sdap.Fill(dt);
                int i;
                int j;
                i = e.RowIndex;
                j = e.ColumnIndex;
                TxtCityId.Text=dt.Rows[i][0].ToString();
                TxtCityName.Text=dt.Rows[i][1].ToString();
                combStateName.Text=dt.Rows[i][2].ToString();
                scon.Close();
            }
            catch (Exception)
            {
                //  MessageBox.Show(x.Message);
            }
        }
    }
}
