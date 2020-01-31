﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetTest.Models;
using NetTest.DataSets;
using NetTest.DataSets.sitedbTableAdapters;

namespace NetTest.UserControls
{
    public partial class ucLogin : UserControl
    {
        private mUCs p_mucs = null;

        public ucLogin()
        {
            InitializeComponent();
        }
        public void setUCs(mUCs mucs)
        {
            this.p_mucs = mucs;
        }

        private void liSubmit_Click(object sender, EventArgs e)
        {
            spAccountLoginOutTableAdapter ta = new spAccountLoginOutTableAdapter();
            sitedb.spAccountLoginOutDataTable dt = ta.GetData(LIusername.Text, LIpwd.Text, DateTime.Now, "Li");
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    sitedb.spAccountLoginOutRow dr = dt[0];
                    Licontinue.Visible = true;
                    LIstatus.Text = "Logged in";
                    LIusername.Enabled = false;
                    LIpwd.Enabled = false;
                    LIsubmit.Enabled = false;
                }
            }
        }

        private void ucLogin_Load(object sender, EventArgs e)
        {
            Licontinue.Visible = false;
            LIstatus.Text = "";
        }

        private void Licontinue_Click(object sender, EventArgs e)
        {
            mUCs p_mucs = PettyCash.c_mUCs;

            p_mucs.m_ucLogin.Hide();
            if (p_mucs != null)
            {
                p_mucs.m_ucLoggedIn.Left = p_mucs.m_ucLogin.Left;
                p_mucs.m_ucLoggedIn.Top = p_mucs.m_ucLogin.Top;
                p_mucs.m_ucLoggedIn.Show();
            }
        }
    }
}
