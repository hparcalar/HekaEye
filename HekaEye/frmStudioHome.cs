﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HekaEye
{
    public partial class frmStudioHome : Form
    {
        public frmStudioHome()
        {
            InitializeComponent();
        }

        private void btnStudio_Click(object sender, EventArgs e)
        {
            frmStudioLogin frm = new frmStudioLogin();
            frm.ShowDialog(this);
            if (frm.LoggedIn)
            {
                frmHekaStudio frmStd = new frmHekaStudio();
                frmStd.ShowDialog(this);
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            frmHekaTest frm = new frmHekaTest();
            frm.ShowDialog(this);
        }
    }
}