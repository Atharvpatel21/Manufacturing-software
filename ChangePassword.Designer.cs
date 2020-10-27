namespace Cloths_company
{
    partial class ChangePassword
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePassword));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_oldpassword = new System.Windows.Forms.TextBox();
            this.txt_newpasswor = new System.Windows.Forms.TextBox();
            this.txt_conpassword = new System.Windows.Forms.TextBox();
            this.btn_Changepassword = new System.Windows.Forms.Button();
            this.labid = new System.Windows.Forms.Label();
            this.butclose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comUserName = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(78, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Old Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(78, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "New Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(78, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Confirm Password";
            // 
            // txt_oldpassword
            // 
            this.txt_oldpassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_oldpassword.Location = new System.Drawing.Point(228, 80);
            this.txt_oldpassword.MaxLength = 10;
            this.txt_oldpassword.Name = "txt_oldpassword";
            this.txt_oldpassword.Size = new System.Drawing.Size(206, 23);
            this.txt_oldpassword.TabIndex = 0;
            this.txt_oldpassword.UseSystemPasswordChar = true;
            this.txt_oldpassword.TextChanged += new System.EventHandler(this.txt_oldpassword_TextChanged);
            // 
            // txt_newpasswor
            // 
            this.txt_newpasswor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_newpasswor.Location = new System.Drawing.Point(228, 122);
            this.txt_newpasswor.MaxLength = 10;
            this.txt_newpasswor.Name = "txt_newpasswor";
            this.txt_newpasswor.Size = new System.Drawing.Size(206, 23);
            this.txt_newpasswor.TabIndex = 1;
            this.txt_newpasswor.UseSystemPasswordChar = true;
            this.txt_newpasswor.TextChanged += new System.EventHandler(this.txt_newpasswor_TextChanged);
            // 
            // txt_conpassword
            // 
            this.txt_conpassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_conpassword.Location = new System.Drawing.Point(228, 160);
            this.txt_conpassword.MaxLength = 10;
            this.txt_conpassword.Name = "txt_conpassword";
            this.txt_conpassword.Size = new System.Drawing.Size(206, 23);
            this.txt_conpassword.TabIndex = 2;
            this.txt_conpassword.UseSystemPasswordChar = true;
            this.txt_conpassword.TextChanged += new System.EventHandler(this.txt_conpassword_TextChanged);
            // 
            // btn_Changepassword
            // 
            this.btn_Changepassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Changepassword.Location = new System.Drawing.Point(188, 238);
            this.btn_Changepassword.Name = "btn_Changepassword";
            this.btn_Changepassword.Size = new System.Drawing.Size(174, 28);
            this.btn_Changepassword.TabIndex = 3;
            this.btn_Changepassword.Text = "Change Password";
            this.btn_Changepassword.UseVisualStyleBackColor = true;
            this.btn_Changepassword.Click += new System.EventHandler(this.btn_Changepassword_Click);
            // 
            // labid
            // 
            this.labid.AutoSize = true;
            this.labid.Location = new System.Drawing.Point(494, 56);
            this.labid.Name = "labid";
            this.labid.Size = new System.Drawing.Size(29, 13);
            this.labid.TabIndex = 4;
            this.labid.Text = "labid";
            this.labid.Visible = false;
            // 
            // butclose
            // 
            this.butclose.BackColor = System.Drawing.Color.Transparent;
            this.butclose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("butclose.BackgroundImage")));
            this.butclose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.butclose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.butclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.butclose.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butclose.Location = new System.Drawing.Point(497, 1);
            this.butclose.Name = "butclose";
            this.butclose.Size = new System.Drawing.Size(39, 36);
            this.butclose.TabIndex = 5;
            this.butclose.TabStop = false;
            this.butclose.UseVisualStyleBackColor = false;
            this.butclose.Click += new System.EventHandler(this.butclose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.MediumBlue;
            this.label1.Location = new System.Drawing.Point(182, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 20);
            this.label1.TabIndex = 75;
            this.label1.Text = "Change Password";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Visible = false;
            // 
            // comUserName
            // 
            this.comUserName.FormattingEnabled = true;
            this.comUserName.Location = new System.Drawing.Point(228, 48);
            this.comUserName.Name = "comUserName";
            this.comUserName.Size = new System.Drawing.Size(206, 21);
            this.comUserName.TabIndex = 76;
            this.comUserName.SelectedIndexChanged += new System.EventHandler(this.comUserName_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(79, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 17);
            this.label5.TabIndex = 77;
            this.label5.Text = "User Name";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(435, 80);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 23);
            this.pictureBox1.TabIndex = 78;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Location = new System.Drawing.Point(435, 121);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(31, 23);
            this.pictureBox2.TabIndex = 79;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Location = new System.Drawing.Point(435, 160);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(31, 23);
            this.pictureBox3.TabIndex = 80;
            this.pictureBox3.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(538, 379);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comUserName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_Changepassword);
            this.Controls.Add(this.butclose);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labid);
            this.Controls.Add(this.txt_conpassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_newpasswor);
            this.Controls.Add(this.txt_oldpassword);
            this.Name = "ChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ChangePassword_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_oldpassword;
        private System.Windows.Forms.TextBox txt_newpasswor;
        private System.Windows.Forms.TextBox txt_conpassword;
        private System.Windows.Forms.Button btn_Changepassword;
        private System.Windows.Forms.Label labid;
        private System.Windows.Forms.Button butclose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comUserName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Timer timer4;
    }
}