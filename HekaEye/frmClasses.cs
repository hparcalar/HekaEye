using HekaEye.Helpers;
using HekaEye.Models;
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
    public partial class frmClasses : Form
    {
        public frmClasses()
        {
            InitializeComponent();
        }

        DbHelper _db = new DbHelper();
        CaptureClassModel[] _classList = new CaptureClassModel[0];

        private void frmClasses_Load(object sender, EventArgs e)
        {
            BindList();
        }

        private void BindList()
        {
            _classList = _db.GetClassList();
            lstClasses.DataSource = _classList;
        }

        private void lstClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstClasses.SelectedIndex > -1)
            {
                var relatedClass = _classList[lstClasses.SelectedIndex];
                txtClassName.Text = relatedClass.Name;
            }
            else
                txtClassName.Text = "";
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            lstClasses.SelectedIndex = -1;
            txtClassName.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (lstClasses.SelectedIndex > -1)
            {
                var relatedClass = _classList[lstClasses.SelectedIndex];
                var qResult = _db.ExecuteSql("UPDATE CaptureClass SET Name = '" + txtClassName.Text + "' WHERE Id=" + relatedClass.Id);
                if (qResult)
                    BindList();
                else
                    MessageBox.Show("Bir hata meydana geldi. Lütfen tekrar deneyiniz.");
            }
            else
            {
                var qResult = _db.ExecuteSql("INSERT INTO CaptureClass(Name) VALUES('" + txtClassName.Text + "')");
                if (qResult)
                    BindList();
                else
                    MessageBox.Show("Bir hata meydana geldi. Lütfen tekrar deneyiniz.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstClasses.SelectedIndex > -1 &&
                MessageBox.Show("Bu sınıfı silmek istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.YesNo)
                == DialogResult.Yes)
            {
                var relatedClass = _classList[lstClasses.SelectedIndex];
                var qResult = _db.ExecuteSql("DELETE FROM CaptureClass WHERE Id=" + relatedClass.Id);
                if (qResult)
                    BindList();
                else
                    MessageBox.Show("Bir hata meydana geldi. Lütfen tekrar deneyiniz.");
            }
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSamples_Click(object sender, EventArgs e)
        {
            if (lstClasses.SelectedIndex < 0)
            {
                MessageBox.Show("Örnekleri listelenecek olan sınıfı seçiniz.");
                return;
            }

            var relatedClass = _classList[lstClasses.SelectedIndex];
            frmSamples frm = new frmSamples();
            frm.ClassId = relatedClass.Id;
            frm.ShowDialog(this);
        }
    }
}
