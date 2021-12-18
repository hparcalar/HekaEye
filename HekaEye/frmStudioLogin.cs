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
    public partial class frmStudioLogin : Form
    {
        public frmStudioLogin()
        {
            InitializeComponent();
        }

        public bool LoggedIn { get; set; } = false;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text == "heka" && txtPassword.Text == "root")
            {
                LoggedIn = true;
                this.Close();
            }
            else
                MessageBox.Show("Hatalı giriş", "Uyarı");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoggedIn = false;
            this.Close();
        }
    }
}
