using HekaEye.Helpers;
using HekaEye.Models;
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
    public partial class frmSkyCamera : Form
    {
        public frmSkyCamera()
        {
            InitializeComponent();
        }

        public int RecordId { get; set; }
        public int RecipeId { get; set; }
        public bool IsSaved { get; set; }

        DeviceHelper _deviceHelper = new DeviceHelper();

        CameraModel[] _cameraList = new CameraModel[0];

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                using (EyeBO bObj = new EyeBO())
                {
                    var selectedCam = cmbCamera.SelectedIndex > -1 ?
                        _cameraList[cmbCamera.SelectedIndex] : null;

                    var result = bObj.SaveCamera(new Data.RecipeCamera
                    {
                        Id = this.RecordId,
                        RecipeId = this.RecipeId,
                        CameraName = selectedCam != null ? selectedCam.DevicePath : null,
                        CameraAlias = txtCameraAlias.Text,
                        IsActive=true,
                        Exposure = txtExposure.Value,
                    });

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
            _cameraList = _deviceHelper.GetCameras();
            cmbCamera.DataSource = _cameraList;

            BindModel();
        }

        private void BindModel()
        {
            using (EyeBO bObj = new EyeBO())
            {
                var dbObj = bObj.GetCamera(this.RecordId);
                if (dbObj != null)
                {
                    var properCam = _cameraList.FirstOrDefault(d => d.DevicePath == dbObj.CameraName);
                    if (properCam != null)
                        cmbCamera.Text = properCam.Name;
                    else
                        cmbCamera.SelectedIndex = -1;

                    txtCameraAlias.Text = dbObj.CameraAlias;

                    this.RecipeId = dbObj.RecipeId;

                    txtExposure.Value = dbObj.Exposure ?? 0;
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
