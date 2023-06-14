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

namespace HekaEye.NewGen
{
    public partial class frmCameraList : Form
    {
        public frmCameraList()
        {
            InitializeComponent();
        }

        DeviceHelper _deviceHelper = new DeviceHelper();
        CameraModel[] _cameraList = new CameraModel[0];

        public CameraModel SelectedCamera { get; set; }

        private void frmCameraList_Load(object sender, EventArgs e)
        {
            _cameraList = _deviceHelper.GetCameras();
            gridCameraList.DataSource = _cameraList;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            CameraModel row = gridView1.GetRow(gridView1.FocusedRowHandle) as CameraModel;
            if (row != null)
            {
                this.SelectedCamera = row;
                this.Close();
            }
        }
    }
}
