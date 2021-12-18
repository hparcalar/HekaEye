using HekaEye.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace HekaEye
{
    public partial class frmSamples : Form
    {
        public frmSamples()
        {
            InitializeComponent();
        }

        DbHelper _db = new DbHelper();

        public int ClassId { get; set; }

        private void frmSamples_Load(object sender, EventArgs e)
        {
            BindModel();
        }

        private void BindModel()
        {
            flPanel.Controls.Clear();

            if (ClassId > 0)
            {
                var classList = _db.GetClassList();
                var currentClass = classList.FirstOrDefault(d => d.Id == ClassId);
                if (currentClass != null)
                {
                    lblClassName.Text = currentClass.Name + " | ÖRNEKLER";

                    var samples = _db.GetSamples(ClassId);
                    if (samples.Length > 0)
                    {
                        var dirPath = System.AppDomain.CurrentDomain.BaseDirectory + "Samples";
                        foreach (var sample in samples)
                        {
                            if (File.Exists(dirPath + "\\" + sample.ImgFileName))
                            {
                                PictureBox pBox = new PictureBox();
                                pBox.Width = 75;
                                pBox.Height = 75;
                                pBox.Image = Image.FromFile(dirPath + "\\" + sample.ImgFileName);
                                pBox.SizeMode = PictureBoxSizeMode.CenterImage;
                                pBox.DoubleClick += PBox_DoubleClick;
                                pBox.Tag = sample.Id.ToString();

                                flPanel.Controls.Add(pBox);
                            }
                        }
                    }
                }
            }
        }

        private void PBox_DoubleClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bu örneği silmek istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.YesNo)
                == DialogResult.Yes)
            {
                var qResult = _db.ExecuteSql("DELETE FROM ClassSample WHERE Id=" + (sender as Control).Tag);
                if (qResult)
                    BindModel();
                else
                    MessageBox.Show("Bir hata meydana geldi. Lütfen tekrar deneyiniz.");
            }
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
