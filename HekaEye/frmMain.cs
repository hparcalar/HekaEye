using System;
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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTakeSamples_Click(object sender, EventArgs e)
        {
            frmTakeSamples frm = new frmTakeSamples();
            frm.ShowDialog(this);
        }

        private void btnClasses_Click(object sender, EventArgs e)
        {
            frmClasses frm = new frmClasses();
            frm.ShowDialog(this);
        }

        private void btnLiveTest_Click(object sender, EventArgs e)
        {
            frmLiveTest frm = new frmLiveTest();
            frm.ShowDialog(this);
        }

        private void btnEyeStudio_Click(object sender, EventArgs e)
        {
            frmEyeStudio frm = new frmEyeStudio();
            frm.ShowDialog(this);
        }
    }
}
