using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HekaEye.SkyStudio;

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
                //frmSkyEditor frmStd = new frmSkyEditor();
                //frmStd.ShowDialog(this);
                frmHekaStudio frmStd = new frmHekaStudio();
                frmStd.ShowDialog(this);
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            //frmHekaTest frm = new frmHekaTest();
            frmHekaHsvTest frm = new frmHekaHsvTest();
            frm.ShowDialog(this);
        }

        private void btnDefinitions_Click(object sender, EventArgs e)
        {
            frmDefinitions frm = new frmDefinitions();
            frm.ShowDialog(this);
        }
    }
}
