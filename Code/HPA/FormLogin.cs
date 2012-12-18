﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace HPA
{
    public partial class FormLogin : Form
    {
        HPA.SQL.DataDaigramDataContext dt = new SQL.DataDaigramDataContext();
        public FormLogin()
        {
            InitializeComponent();
        }
        private void Dangnhap(string id,string pass)
        {
            int Loginid=dt.SC_Login_CheckLogin(id, pass);
            if (Loginid == -1 || Loginid == -2)
            {
                HPA.Common.Methods.ShowMessage(HPA.Common.CommonConst.LOGIN_FAILURE);
            }
            else
            {
                HPA.Common.StaticVars.LoginID = Loginid ;
                HPA.Common.StaticVars.UserName = txtName.Text;
                this.Hide();
                HPA_Main main = new HPA_Main();
                main.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dangnhap(txtName.Text, txtPass.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            if (File.Exists((HPA.Properties.Settings.Default.BackGroundLogin))==true)
            {
                this.BackgroundImage = System.Drawing.Image.FromFile(HPA.Properties.Settings.Default.BackGroundLogin);
                this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            }
            else
            {
                this.BackgroundImage = null;
            }
        }
    }
}