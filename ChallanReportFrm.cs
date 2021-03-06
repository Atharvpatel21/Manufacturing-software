﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;

namespace Cloths_company
{
   
    public partial class ChallanReportFrm : Form
    {
        SqlConnection scon = new SqlConnection(Connection.cs);
        SqlCommand scmd;
        SqlDataReader sdr;

        string str;

        public void showReport()
        {
            try
            {

                SqlDataAdapter sda = new SqlDataAdapter(str, scon);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                ReportDocument rd = new ReportDocument();
                string a = Application.StartupPath;
                string a1 = a.Replace("bin\\Debug", "");
                string reportPath = a1 + "ChallanCrystalReport.rpt";
                rd.Load(reportPath);
                rd.SetDataSource(dt);
                //rd.SetDatabaseLogon("sa", "sql", "@COMPUTER-PC\\COMPUTER", "clothsprojects");
                rd.SetDatabaseLogon("","",@"COMPAQ-PC\SQLEXPRESS", "clothsprojects",true);

                Cursor = Cursors.Default;
                crystalReportViewer1.ReportSource = rd;
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }
        public ChallanReportFrm()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            try
            {
                scon.Open();
                scmd = new SqlCommand("Select ChallanNo from Challan1 ", scon);
                sdr = scmd.ExecuteReader();
                comboBox1.Items.Clear();
                while (sdr.Read() == true)
                {
                    comboBox1.Items.Add(sdr["ChallanNo"]);
                }
                sdr.Close();
                scon.Close();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        private void butSearch_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                str = "select * from Challan1 where ChallanNo='" + comboBox1.Text + "'";
                showReport();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
  
            }
        }

        private void butSearch_Click_1(object sender, EventArgs e)
        {
            try
            {
                str = "select * from Challan1 where ChallanNo='" + comboBox1.Text + "'";
                showReport();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);

            }
        }

       
    }
}
