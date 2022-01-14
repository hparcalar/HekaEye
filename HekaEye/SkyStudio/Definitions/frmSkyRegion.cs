using HekaEye.UseCase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HekaEye.SkyStudio.Definitions
{
    public partial class frmSkyRegion : Form
    {
        public frmSkyRegion()
        {
            InitializeComponent();
        }

        public int RecordId { get; set; }
        public int CameraId { get; set; }
        public bool IsSaved { get; set; }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                using (EyeBO bObj = new EyeBO())
                {
                    var dbCam = bObj.GetCamera(this.CameraId);
                    var dbRegion = bObj.GetRegion(this.RecordId);

                    var result = bObj.SaveRegion(new Data.Region
                    {
                        Id = this.RecordId,
                        CameraId = CameraId,
                        Enabled = chkEnabled.Checked,
                        Title = txtRegionName.Text,
                        RecipeId = dbCam.RecipeId,
                    }, this.RecordId == 0 ?
                        (new StudioModels.HekaRegion { 
                        Title = txtRegionName.Text,
                        RegionType = 1,
                        Path = new Point[0],
                    })
                    :
                    dbRegion
                    );

                    this.IsSaved = result.Result;
                }
            }
            catch (Exception)
            {
                this.IsSaved = false;
            }

            this.Close();
        }

        private void frmSkyRecipe_Load(object sender, EventArgs e)
        {
            txtRegionName.Focus();
            BindModel();
        }

        private void BindModel()
        {
            using (EyeBO bObj = new EyeBO())
            {
                var dbObj = bObj.GetRegion(this.RecordId);
                if (dbObj != null)
                {
                    txtRegionName.Text = dbObj.Title;
                    chkEnabled.Checked = dbObj.Enabled;
                    this.CameraId = dbObj.CameraId;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.IsSaved = false;
            this.Close();
        }
    }
}
