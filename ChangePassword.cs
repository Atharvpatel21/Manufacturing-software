using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml;
using System.Security.Cryptography;
using System.IO;

namespace Cloths_company
{
    public partial class ChangePassword : Form
    {
        SqlConnection scon = new SqlConnection(Connection.cs);
        DataSet ds = new DataSet();
      
        string abc,l;
        SqlCommand scmd;
        SqlDataReader sdr=null;

        const string DESKey = "AQWSEDRF";
        const string DESIV = "HGFEDCBA";

        public static string DESEncrypt(string stringToEncrypt)
        {

            byte[] key;
            byte[] IV;

            byte[] inputByteArray;
            try
            {

                key = Convert2ByteArray(DESKey);

                IV = Convert2ByteArray(DESIV);

                inputByteArray = Encoding.UTF8.GetBytes(stringToEncrypt);
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();

                MemoryStream ms = new MemoryStream(); CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(key, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);

                cs.FlushFinalBlock();

                return Convert.ToBase64String(ms.ToArray());
            }

            catch (System.Exception ex)
            {

                throw ex;
            }

        }

        static byte[] Convert2ByteArray(string strInput)
        {

            int intCounter; char[] arrChar;
            arrChar = strInput.ToCharArray();

            byte[] arrByte = new byte[arrChar.Length];

            for (intCounter = 0; intCounter <= arrByte.Length - 1; intCounter++)
                arrByte[intCounter] = Convert.ToByte(arrChar[intCounter]);

            return arrByte;
        }
        

   
        public void executequerey(string abc)
        {
            scon.Open();
            scmd = new SqlCommand(abc, scon);
            scmd.ExecuteNonQuery();
            scon.Close();
        }
        public ChangePassword()
        {
            InitializeComponent();
        }
         public string textbox
        {
            set
            {
                l = value;
                //updt = value;
            }
        }
        private void ChangePassword_Load(object sender, EventArgs e)
        {
            try
            {
                scon.Open();
                scmd = new SqlCommand("Select login from Admin", scon);
                sdr = scmd.ExecuteReader();
                while (sdr.Read() == true)
                {
                    comUserName.Items.Add(sdr[0].ToString());
                }
                sdr.Close();
                scon.Close();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
           
           
        }

        private void btn_Changepassword_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (comUserName.Text == "")
                {
                    MessageBox.Show("UserName Should Not Be Blank!");
                    comUserName.Focus();

                }
                else if (txt_oldpassword.Text == "")
                {
                    MessageBox.Show("OldPassword Should Not Be Blank!");
                    txt_oldpassword.Focus();

                }
                else if (txt_newpasswor.Text == "")
                {
                    MessageBox.Show("NewPassword Should Not Be Blank!");
                    txt_newpasswor.Focus();

                }
                else if (DESEncrypt(txt_newpasswor.Text) != DESEncrypt(txt_conpassword.Text))
                {
                    MessageBox.Show("New Password or Confrim Password Should MATCH!");
                    txt_newpasswor.Focus();
                    txt_conpassword.Text = "";
                    txt_newpasswor.Text = "";
                }

                else
                {
                    scon.Open();
                    Loginclass m = new Loginclass();
                    if (m.passwordavibity(comUserName.Text, DESEncrypt(txt_oldpassword.Text)))
                    {
                        string abc1 = "update Admin set pwd='" + DESEncrypt(txt_newpasswor.Text) + "' where login='" + comUserName.Text + "' and pwd='" + DESEncrypt(txt_oldpassword.Text) + "'";
                        scmd = new SqlCommand(abc1, scon);
                        scmd.ExecuteNonQuery();
                        MessageBox.Show("Your Password Change SuccessFully.");
                        txt_conpassword.Text = "";
                        txt_newpasswor.Text = "";
                        txt_conpassword.Text = "";
                        txt_oldpassword.Text = "";
                        comUserName.Text = "";

                    }
                    else
                    {
                        MessageBox.Show("Old password not exists"); 
                    }
                     
                    
              }

           }

            catch (Exception x)
             {
                MessageBox.Show("Please Enter The Valid Password!!!" + x.Message);
             }
            finally
            {
                scon.Close();
               
            }
             
        }

        private void butclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comUserName_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void txt_oldpassword_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
                    }

        private void txt_newpasswor_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            
        }

        private void txt_conpassword_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            
        }

      
    }
}
