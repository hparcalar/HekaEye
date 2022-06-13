using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using HekaEye.Data;
using HekaEye.Helpers;
using HekaEye.Models;
using HekaEye.StudioModels;
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

namespace HekaEye
{
    public partial class frmHekaStudio : Form
    {
        DeviceHelper _deviceHelper = new DeviceHelper();
        CameraModel[] _cameraList = new CameraModel[0];

        VideoCapture _activeCapture = null;
        Task _tCapture = null;

        bool _cameraSelection = false;
        bool _captureRunning = false;

        bool _selectionRunning = false;
        bool _selectionStepRunning = false;
        int _selectionType = 0;
        List<Point> _selectionPath = new List<Point>();
        Point _hoverPoint = new Point();

        bool _rotationIsRunning = false;
        bool _positionIsRunning = false;
        int _leftCount = 0;
        int _rightCount = 0;
        int _upCount = 0;
        int _downCount = 0;

        MCvScalar _regionSelectionColor = new MCvScalar(255, 0, 0);
        MCvScalar _lineSelectionColor = new MCvScalar(155, 155, 0);

        List<HekaRegion> _regionList = new List<HekaRegion>();
        List<HekaCaptureModel> _captureList = new List<HekaCaptureModel>();

        public frmHekaStudio()
        {
            InitializeComponent();
        }

        private void frmHekaStudio_Load(object sender, EventArgs e)
        {
            _cameraList = _deviceHelper.GetCameras();

            cmbCamera.DataSource = _cameraList;
            cmbCamera.SelectedIndex = -1;
            _cameraSelection = true;

            UpdateRecipeList();
        }

        HekaRegion _selectedRegion = null;
        private HekaRegion SelectedRegion {
            get
            {
                return _selectedRegion;
            }
            set
            {
                _selectedRegion = value;

                if (_selectedRegion == null)
                    prpGrid.SelectedObject = new HekaRegion();
                else
                {
                    prpGrid.SelectedObject = _selectedRegion;
                    prpGrid.Refresh();
                }

                if (_selectedRegion != null && SelectedCamera == null)
                {
                    if (_selectedRegion.CameraId > 0)
                    {
                        using (EyeBO bObj = new EyeBO())
                        {
                            var camData = bObj.GetCamera(_selectedRegion.CameraId);
                            SelectedCamera = camData;
                        }
                    }
                }
            } 
        }

        Recipe _selectedRecipe = null;
        public Recipe SelectedRecipe 
        {
            get
            {
                return _selectedRecipe;
            }
            set
            {
                _selectedRecipe = value;

                UpdateCameraList();
                //UpdateRegionList();
                UpdateModelList();

                if (_selectedRecipe != null)
                {
                    lblRecipe.Text = _selectedRecipe.RecipeCode;

                    //if (!string.IsNullOrEmpty(_selectedRecipe.CameraName))
                    //    cmbCamera.Text = _selectedRecipe.CameraName;
                }
                else
                    lblRecipe.Text = "-";

                if (_selectedRecipe == null)
                    prpGrid.SelectedObject = new Recipe();
                else
                    prpGrid.SelectedObject = _selectedRecipe;

                prpGrid.Refresh();
            }
        }

        Product _selectedModel = null;
        public Product SelectedModel 
        {
            get
            {
                return _selectedModel;
            }
            set
            {
                _selectedModel = value;

                if (_selectedModel == null)
                    prpGrid.SelectedObject = new Product();
                else
                    prpGrid.SelectedObject = _selectedModel;
            }
        }

        RecipeCamera _selectedCamera = null;
        public RecipeCamera SelectedCamera
        {
            get
            {
                return _selectedCamera;
            }
            set
            {
                _selectedCamera = value;

                if (_selectedCamera == null)
                    prpGrid.SelectedObject = new RecipeCamera();
                else
                {
                    tBarExposure.Value = _selectedCamera.Exposure ?? -7;
                    var actCam = _cameraList.FirstOrDefault(d => d.DevicePath == _selectedCamera.CameraName);
                    cmbCamera.SelectedIndex = _cameraList.ToList().IndexOf(actCam);

                    if (_selectedCamera.Exposure != null)
                    {
                        tBarExposure.Value = _selectedCamera.Exposure.Value;
                        if (_selectedCamera != null)
                        {
                            var relatedCapture = _captureList.FirstOrDefault(d => d.CameraName == _selectedCamera.CameraName);
                            if (relatedCapture != null && relatedCapture.Capture != null)
                            {
                                if (relatedCapture.AutoExposure == false)
                                {
                                    relatedCapture.Capture.Set(Emgu.CV.CvEnum.CapProp.AutoExposure, 1);
                                    relatedCapture.Capture.Set(Emgu.CV.CvEnum.CapProp.Exposure, tBarExposure.Value);
                                }
                                else
                                    relatedCapture.Capture.Set(Emgu.CV.CvEnum.CapProp.AutoExposure, 3);
                            }
                        }
                    }

                    UpdateRegionList();

                    prpGrid.SelectedObject = _selectedCamera;
                    prpGrid.Refresh();
                }
            }
        }

        private void UpdateRegionList()
        {
            flPanelRegions.Controls.Clear();

            if (SelectedRecipe != null && SelectedCamera != null)
            {
                using (EyeBO bObj = new EyeBO())
                {
                    var allRegions = bObj.GetRegionList(SelectedRecipe.Id, SelectedCamera.Id)
                        .Select(d => new HekaRegion { 
                            Id = d.Id,
                            Title = d.Title,
                            CameraId = d.CameraId ?? 0,
                        }).ToList();

                    List<HekaRegion> hekaRegions = new List<HekaRegion>();

                    foreach (var item in allRegions)
                    {
                        var dbRegion = bObj.GetRegion(item.Id);
                        if (dbRegion != null)
                        {
                            hekaRegions.Add(dbRegion);
                        }
                    }

                    _regionList = hekaRegions.ToList();

                    var _activeCapture = _captureList.FirstOrDefault(d => string.Equals(d.CameraName, SelectedCamera.CameraName));
                    if (_activeCapture != null)
                    {
                        _activeCapture.RegionList = _regionList;
                    }
                }

                foreach (var item in _regionList)
                {
                    Button btn = new Button();
                    btn.Tag = item;
                    btn.Text = item.Title;
                    btn.Width = flPanelRegions.Width - 10;
                    btn.Click += Btn_Click;

                    flPanelRegions.Controls.Add(btn);
                }

                SelectedRegion = null;
            }
        }

        private void UpdateRecipeList()
        {
            flPanelRecipes.Controls.Clear();

            using (EyeBO bObj = new EyeBO())
            {
                var rcpList = bObj.GetRecipeList();
                foreach (var item in rcpList)
                {
                    Button btnListRecipe = new Button();
                    btnListRecipe.Tag = item;
                    btnListRecipe.Text = item.RecipeCode;
                    btnListRecipe.Width = flPanelRecipes.Width - 10;
                    btnListRecipe.Click += BtnListRecipe_Click;

                    flPanelRecipes.Controls.Add(btnListRecipe);
                }

                SelectedRecipe = null;
            }
        }

        private void BtnListRecipe_Click(object sender, EventArgs e)
        {
            Recipe itemR = (sender as Button).Tag as Recipe;
            if (itemR != null)
            {
                SelectedRecipe = itemR;

                foreach (Control item in flPanelRecipes.Controls)
                {
                    if ((item.Tag as Recipe).Id != SelectedRecipe.Id)
                        item.BackColor = Color.Gray;
                    else
                        item.BackColor = Color.Lime;
                }

                tabTools.SelectedIndex = 0;
            }
        }

        private void UpdateModelList()
        {
            flPanelModels.Controls.Clear();

            if (SelectedRecipe != null)
            {
                using (EyeBO bObj = new EyeBO())
                {
                    var modelList = bObj.GetProductList().Where(d => d.RecipeId == SelectedRecipe.Id).ToArray();

                    foreach (var item in modelList)
                    {
                        Button btnListModel = new Button();
                        btnListModel.Tag = item;
                        btnListModel.Text = item.ProductCode;
                        btnListModel.Width = flPanelModels.Width - 10;
                        btnListModel.Click += BtnListModel_Click;

                        flPanelModels.Controls.Add(btnListModel);
                    }

                    SelectedModel = null;
                }
            }
        }

        bool _updatingCameras = false;
        private void UpdateCameraList()
        {
            if (_updatingCameras)
                return;

            _updatingCameras = true;

            flPanelCameras.Controls.Clear();
            flPanelCams.Controls.Clear();

            foreach (var capture in _captureList)
            {
                if (capture.Capture != null && capture.Capture.IsOpened)
                {
                    try
                    {
                        capture.CaptureRunning = false;
                        System.Threading.Thread.Sleep(100);
                        capture.Capture.Stop();
                        capture.Capture.Dispose();

                        //capture.CaptureTask.Dispose();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            _captureList.Clear();

            if (SelectedRecipe != null)
            {
                using (EyeBO bObj = new EyeBO())
                {
                    var modelList = bObj.GetCameraList(SelectedRecipe.Id);

                    if (modelList.Length == 0)
                        _updatingCameras = false;

                    foreach (var item in modelList)
                    {
                        // ADD BUTTON TO TAB PANEL
                        Button btnListCamera = new Button();
                        btnListCamera.Tag = item;
                        btnListCamera.Text = item.CameraName;
                        btnListCamera.Width = flPanelModels.Width - 10;
                        btnListCamera.Click += BtnListCamera_Click;
                        flPanelCameras.Controls.Add(btnListCamera);

                        // ADD IMAGEBOX TO FRAME CONTAINER
                        Emgu.CV.UI.ImageBox cvBox = new Emgu.CV.UI.ImageBox();
                        cvBox.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
                        cvBox.SizeMode = PictureBoxSizeMode.Zoom;
                        cvBox.Size = new Size(flPanelCams.Width / 2 - 50, (flPanelCams.Height / 2) - 5);
                        //cvBox.Width = flPanelCams.Width;
                        //cvBox.Height = flPanelCams.Height / 2;
                        cvBox.BorderStyle = BorderStyle.FixedSingle;
                        cvBox.MouseDown += imgBox_MouseDown;
                        cvBox.MouseMove += imgBox_MouseMove;
                        cvBox.MouseUp += imgBox_MouseUp;
                        flPanelCams.Controls.Add(cvBox);

                        var captureModel = new HekaCaptureModel
                        {
                            CameraName = item.CameraName,
                            CaptureRunning = true,
                            CameraId = item.Id,
                            ImageBox = cvBox,
                            AutoExposure = item.AutoExposure ?? false,
                            AutoFocus = item.AutoFocus ?? true,
                            Focus = item.Focus,
                            Exposure = item.Exposure,
                            SelectionRunning = false,
                            SelectionStepRunning = false,
                            RegionList = bObj.GetRegionList(SelectedRecipe.Id, item.Id)
                                .Select(d => new HekaRegion
                                {
                                    Id = d.Id,
                                }).ToList(),
                            SelectionType = 0,
                        };

                        _captureList.Add(captureModel);

                        List<HekaRegion> detailedRegions = new List<HekaRegion>();
                        foreach (var region in captureModel.RegionList)
                        {
                            var dbRegion = bObj.GetRegion(region.Id);
                            if (dbRegion != null)
                            {
                                detailedRegions.Add(dbRegion);
                            }
                        }

                        captureModel.RegionList = detailedRegions;
                    }

                    StopCapture();
                    Task.Run(StartCapture);

                    SelectedCamera = null;
                }
            }
            else
                _updatingCameras = false;
        }

        private void BtnListCamera_Click(object sender, EventArgs e)
        {
            RecipeCamera itemP = (sender as Button).Tag as RecipeCamera;
            if (itemP != null)
            {
                SelectedCamera = itemP;

                foreach (Control item in flPanelCameras.Controls)
                {
                    if ((item.Tag as RecipeCamera).Id != SelectedCamera.Id)
                        item.BackColor = Color.Gray;
                    else
                        item.BackColor = Color.Lime;
                }

                tabTools.SelectedIndex = 0;
            }
        }

        private void BtnListModel_Click(object sender, EventArgs e)
        {
            Product itemP = (sender as Button).Tag as Product;
            if (itemP != null)
            {
                SelectedModel = itemP;

                foreach (Control item in flPanelModels.Controls)
                {
                    if ((item.Tag as Product).Id != SelectedModel.Id)
                        item.BackColor = Color.Gray;
                    else
                        item.BackColor = Color.Lime;
                }

                tabTools.SelectedIndex = 0;
            }
        }

        private void CheckUndoEnabled()
        {
            if (SelectedCamera != null)
            {
                var relatedCamera = _captureList.FirstOrDefault(d => d.CameraName == SelectedCamera.CameraName);
                if (relatedCamera != null)
                {
                    btnUndo.Enabled = relatedCamera.SelectionPath.Any();
                }
                else
                    btnUndo.Enabled = false;
            }
            else
                btnUndo.Enabled = false;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            var tagItem = ((HekaRegion)(sender as Control).Tag);
            if (tagItem != null)
            {
                using (EyeBO bObj = new EyeBO())
                {
                    var activeCapture = _captureList.FirstOrDefault(d => d.RegionList.Any(m => m.Id == tagItem.Id));
                    if (activeCapture != null)
                    {
                        var activeRegion = activeCapture.RegionList.FirstOrDefault(d => d.Id == tagItem.Id);
                        if (activeRegion != null)
                        {
                            SelectedRegion = tagItem;
                            foreach (Control item in flPanelRegions.Controls)
                            {
                                if ((item.Tag as HekaRegion).Id != SelectedRegion.Id)
                                    item.BackColor = Color.Gray;
                                else
                                    item.BackColor = Color.Lime;
                            }
                            tabTools.SelectedIndex = 0;
                        }
                    }
                }
            }
        }

        private void StopCapture()
        {
            foreach (var capture in _captureList)
            {
                try
                {
                    capture.CaptureRunning = false;

                    if (capture.Capture != null)
                    {
                        capture.Capture.Stop();
                        capture.Capture.Dispose();
                    }

                    if (capture.CaptureTask != null)
                        capture.CaptureTask.Dispose();
                }
                catch (Exception)
                {

                }
            }
        }
        private void StartCapture()
        {
            this.BeginInvoke((Action)delegate
            {
                lblStatus.Visible = true;
            });

            foreach (var capture in _captureList)
            {
                try
                {
                    CameraModel capCam = _cameraList.FirstOrDefault(m => string.Equals(m.DevicePath,capture.CameraName));
                    if (capCam != null)
                    {
                        capture.CaptureRunning = true;
                        capture.CaptureTask = Task.Run(() => LoopCapture(capture.CameraName));
                    }
                }
                catch (Exception ex)
                {

                }
            }

            this.BeginInvoke((Action)delegate
            {
                lblStatus.Visible = false;
            });

            _updatingCameras = false;
        }
        
        private async Task LoopCapture(string cameraName)
        {
            var data = _captureList.FirstOrDefault(d => d.CameraName == cameraName);
            while (data != null && data.CaptureRunning)
            {
                //if (SelectedCamera == null || SelectedCamera.Id != data.CameraId)
                //{
                //    await Task.Delay(500);
                //    continue;
                //}

                if (data.DoQueryFrame == false)
                {
                    try
                    {
                        if (data.Capture != null)
                        {
                            data.Capture.Dispose();
                        }
                    }
                    catch (Exception)
                    {

                    }
                    data.Capture = null;
                    //continue;
                }

                CameraModel capCam = _cameraList.FirstOrDefault(m => string.Equals(m.DevicePath, data.CameraName));

                if (data.Capture == null && data.DoQueryFrame == true)
                {
                    this.BeginInvoke((Action)delegate
                    {
                        lblStatus.Visible = true;
                    });
                    data.Capture = new VideoCapture(capCam.DeviceIndex, VideoCapture.API.Msmf); // , VideoCapture.API.Msmf
                }

                if (data.Capture != null && data.DoQueryFrame == true)
                {
                    data.Exposure = Convert.ToInt32(data.Capture.Get(Emgu.CV.CvEnum.CapProp.Exposure));
                    if (data.AutoExposure)
                    {
                        data.Capture.Set(Emgu.CV.CvEnum.CapProp.AutoExposure, 3);
                        //tBarExposure.Enabled = false;
                    }
                    else
                    {
                        data.Capture.Set(Emgu.CV.CvEnum.CapProp.AutoExposure, 1);
                        //tBarExposure.Enabled = true;
                    }

                    //if (capture.AutoFocus)
                    //{
                    //    capture.Capture.Set(Emgu.CV.CvEnum.CapProp.Autofocus, 1);
                    //}
                    //else
                    //{
                    //    capture.Capture.Set(Emgu.CV.CvEnum.CapProp.Autofocus, 0);
                    //    capture.Capture.Set(Emgu.CV.CvEnum.CapProp.Focus, capture.Focus ?? 5);
                    //}

                    //capture.Capture.Set(Emgu.CV.CvEnum.CapProp.FrameWidth, 3840);
                    //capture.Capture.Set(Emgu.CV.CvEnum.CapProp.FrameHeight, 2160);

                    this.BeginInvoke((Action)delegate
                    {
                        lblStatus.Visible = false;
                    });
                }

                if (data != null && data.CaptureRunning)
                {
                    try
                    {
                        Mat frame = null;

                        if (data.DoQueryFrame == true)
                        {
                            data.DoQueryFrame = false;

                            if (data.Capture != null)
                            {
                                if (data.Capture.IsOpened == false)
                                {
                                    this.BeginInvoke((Action)delegate
                                    {
                                        MessageBox.Show("Kamera açılamadı: " + data.CameraName);
                                    });
                                }

                                // capture 20 frames to validate auto-exposure of the judged image
                                for (int i = 0; i < 30; i++)
                                {
                                    var tmpFrame = data.Capture.QueryFrame();
                                    tmpFrame.Dispose();
                                }

                                frame = data.Capture.QueryFrame();
                                int tryCount = 0;
                                while (frame == null)
                                {
                                    frame = data.Capture.QueryFrame();
                                    tryCount++;

                                    if (tryCount > 20)
                                        break;

                                    await Task.Delay(50);
                                }

                                if (frame != null)
                                    data.CurrentFrame = frame.Clone();
                            }
                        }
                        else if (data.CurrentFrame != null)
                            frame = data.CurrentFrame.Clone();

                        if (frame == null)
                            continue;

                        //frame.ConvertTo(frame, Emgu.CV.CvEnum.DepthType.Cv32F);
                        //CvInvoke.GaussianBlur(frame, frame, new Size(0, 0), 3);
                        //CvInvoke.AddWeighted(frame, 1.5, frame, -0.5, 0, frame);

                        var gray = new Mat(frame.Rows, frame.Cols, Emgu.CV.CvEnum.DepthType.Cv32F, 1);
                        var hsv = new Image<Hsv, Byte>(frame.Rows, frame.Cols);
                        CvInvoke.CvtColor(frame, gray, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);
                        CvInvoke.CvtColor(frame, hsv, Emgu.CV.CvEnum.ColorConversion.Bgr2Hsv);

                        #region DRAW ACTIVE SELECTION
                        if (data.SelectionRunning && data.SelectionPath.Count() > 0)
                        {
                            var pLeft = frame.Width / (data.ImageBox.Width * 1.0);
                            var newH = frame.Height * data.ImageBox.Width / (frame.Width * 1.0);
                            var hRate = frame.Height / (newH * 1.0);
                            var pTop = Convert.ToInt32((data.ImageBox.Height - newH) / 2.0);

                            int _selectionPathPointIndex = 0;
                            foreach (var pathPoint in data.SelectionPath)
                            {
                                if (data.SelectionPath.Count() - 1 > _selectionPathPointIndex)
                                {
                                    var nextPoint = data.SelectionPath[_selectionPathPointIndex + 1];

                                    var pntCurrent = new Point(
                                       Convert.ToInt32(pathPoint.X * pLeft),
                                       Convert.ToInt32(Convert.ToInt32(pathPoint.Y - pTop) * hRate));
                                    var pntNext = new Point(Convert.ToInt32(nextPoint.X * pLeft), Convert.ToInt32(Convert.ToInt32(nextPoint.Y - pTop) * hRate));

                                    CvInvoke.Line(frame, pntCurrent,
                                           pntNext,
                                           _selectionType == 1 ? _regionSelectionColor : _lineSelectionColor, 1, Emgu.CV.CvEnum.LineType.EightConnected);

                                    CvInvoke.Rectangle(frame, new Rectangle(pntCurrent.X - 2, pntCurrent.Y - 2, 5, 5),
                                        new MCvScalar(255, 50, 0), 2);
                                    CvInvoke.Rectangle(frame, new Rectangle(pntNext.X - 2, pntNext.Y - 2, 5, 5),
                                        new MCvScalar(255, 50, 0), 2);
                                }
                                else if (_hoverPoint != Point.Empty)
                                {
                                    var pntCurrent = new Point(
                                       Convert.ToInt32(pathPoint.X * pLeft),
                                      Convert.ToInt32(Convert.ToInt32(pathPoint.Y - pTop) * hRate));
                                    var pntNext = new Point(Convert.ToInt32(_hoverPoint.X * pLeft), Convert.ToInt32(Convert.ToInt32(_hoverPoint.Y - pTop) * hRate));

                                    CvInvoke.Line(frame, pntCurrent,
                                           pntNext,
                                           _selectionType == 1 ? _regionSelectionColor : _lineSelectionColor, 1, Emgu.CV.CvEnum.LineType.EightConnected);

                                    CvInvoke.Rectangle(frame, new Rectangle(pntCurrent.X - 2, pntCurrent.Y - 2, 5, 5),
                                        new MCvScalar(255, 50, 0), 2);
                                }

                                _selectionPathPointIndex++;
                            }
                        }
                        #endregion

                        #region DRAW & CHECK SAVED REGIONS
                        bool isOk = true;

                        foreach (var region in data.RegionList)
                        {
                            if (region.Path.Length == 0)
                                continue;

                            Mat maskedRegion = Mat.Zeros(gray.Rows, gray.Cols, Emgu.CV.CvEnum.DepthType.Cv8U, 1);
                            Rectangle regionRect = Rectangle.Empty;

                            var pLeft = frame.Width / (data.ImageBox.Width * 1.0);
                            var newH = frame.Height * data.ImageBox.Width / (frame.Width * 1.0);
                            var hRate = frame.Height / (newH * 1.0);
                            var pTop = Convert.ToInt32((data.ImageBox.Height - newH) / 2.0);

                            // CROP SELECTED ROI
                            if (region.RegionType == 1)
                            {
                                Mat maskZeros = Mat.Zeros(gray.Rows, gray.Cols, Emgu.CV.CvEnum.DepthType.Cv8U, 1);

                                List<Point> translatedPointsI = new List<Point>();
                                for (int i = 0; i < region.Path.Length; i++)
                                {
                                    var rPoint = region.Path[i];
                                    if (region.OffsetX != 0)
                                        rPoint.X += region.OffsetX;
                                    if (region.OffsetY != 0)
                                        rPoint.Y += region.OffsetY;

                                    if (_positionIsRunning)
                                    {
                                        if (SelectedRegion != null && SelectedRegion.Id == region.Id)
                                        {
                                            var realRight = _rightCount;
                                            var realLeft = _leftCount;
                                            region.OffsetX += (realRight - realLeft);
                                            _leftCount -= realLeft;
                                            _rightCount -= realRight;

                                            var realUp = _upCount;
                                            var realDown = _downCount;
                                            region.OffsetY += (realDown - realUp);
                                            _downCount -= realDown;
                                            _upCount -= realUp;

                                            SelectedRegion.OffsetX = region.OffsetX;
                                            SelectedRegion.OffsetY = region.OffsetY;
                                        }
                                    }
                                    else if (_rotationIsRunning)
                                    {
                                        if (SelectedRegion != null && SelectedRegion.Id == region.Id)
                                        {
                                            var realRight = _rightCount;
                                            var realLeft = _leftCount;

                                            if (realRight - realLeft != 0)
                                            {
                                                VectorOfPoint rawPath
                                                   = new VectorOfPoint(region.Path);
                                                var rectMoment = CvInvoke.MinAreaRect(rawPath);
                                                var cx = Convert.ToInt32(rectMoment.Center.X);
                                                var cy = Convert.ToInt32(rectMoment.Center.Y);

                                                List<Point> normPath = new List<Point>();
                                                for (int k = 0; k < region.Path.Length; k++)
                                                {
                                                    normPath.Add(new Point(region.Path[k].X - cx, region.Path[k].Y - cy));
                                                }

                                                List<Point> rotatedPath = new List<Point>();
                                                for (int k = 0; k < normPath.Count(); k++)
                                                {
                                                    var pPoint = normPath[k];

                                                    // CONVERT TO POLAR COORDINATES
                                                    var theta = Math.Atan2(pPoint.Y, pPoint.X);
                                                    var rho = Math.Sqrt(Math.Pow(pPoint.X, 2) + Math.Pow(pPoint.Y, 2));

                                                    // ADD ANGLE TO THETA
                                                    var deg = theta / (Math.PI / 180.0);
                                                    deg = (deg + (realRight - realLeft)) % 360;
                                                    theta = deg * (Math.PI / 180.0);

                                                    // CONVERT TO CARTESIAN COORDINATES BACK
                                                    rotatedPath.Add(new Point(
                                                            Convert.ToInt32(rho * Math.Cos(theta)) + cx,
                                                            Convert.ToInt32(rho * Math.Sin(theta)) + cy
                                                        ));
                                                }

                                                region.Path = rotatedPath.ToArray();
                                                SelectedRegion.Path = rotatedPath.ToArray();
                                            }

                                            _leftCount -= realLeft;
                                            _rightCount -= realRight;
                                        }
                                    }

                                    translatedPointsI.Add(new Point(Convert.ToInt32(rPoint.X * pLeft), Convert.ToInt32(Convert.ToInt32(rPoint.Y - pTop) * hRate)));
                                }

                                VectorOfVectorOfPoint contour
                                                   = new VectorOfVectorOfPoint(new VectorOfPoint(translatedPointsI.ToArray()));
                                CvInvoke.DrawContours(maskZeros, contour, 0, new MCvScalar(255), -1);
                                CvInvoke.BitwiseAnd(gray, maskZeros, maskedRegion);

                                CvInvoke.DrawContours(frame, contour, -1, new MCvScalar(255, 0, 0), 1);

                                regionRect = CvInvoke.BoundingRectangle(translatedPointsI.ToArray());

                                maskZeros.Dispose();
                                translatedPointsI.Clear();
                            }
                            else if (region.RegionType == 2)
                            {
                                Mat maskZeros = Mat.Zeros(gray.Rows, gray.Cols,Emgu.CV.CvEnum.DepthType.Cv8U, region.ConvertToHsv ? 3 : 1);

                                List<Point> translatedPointsI = new List<Point>();

                                // DRAW A SHAPE THAT CONTAINS ALL POINTS WITH HEIGHT 2 PX TOTAL
                                for (int i = 0; i < region.Path.Length; i++)
                                {
                                    var rPoint = region.Path[i];
                                    if (region.OffsetX != 0)
                                        rPoint.X += region.OffsetX;
                                    if (region.OffsetY != 0)
                                        rPoint.Y += region.OffsetY;

                                    translatedPointsI.Add(new Point(Convert.ToInt32(rPoint.X * pLeft), Convert.ToInt32(Convert.ToInt32(rPoint.Y - pTop -1) * hRate)));
                                }

                                for (int i = region.Path.Length - 1; i >= 0; i--)
                                {
                                    var rPoint = region.Path[i];
                                    translatedPointsI.Add(new Point(Convert.ToInt32(rPoint.X * pLeft), Convert.ToInt32(Convert.ToInt32(rPoint.Y - pTop + 1) * hRate)));
                                }

                                VectorOfVectorOfPoint contour
                                                   = new VectorOfVectorOfPoint(new VectorOfPoint(translatedPointsI.ToArray()));
                                CvInvoke.DrawContours(maskZeros, contour, 0, new MCvScalar(255), -1);
                                CvInvoke.BitwiseAnd(gray, maskZeros, maskedRegion);

                                CvInvoke.DrawContours(frame, contour, -1, new MCvScalar(255, 0, 0), 1);

                                //this.BeginInvoke((Action)delegate
                                //{
                                //    imgRegion.Image = maskedRegion;
                                //});

                                maskZeros.Dispose();
                                contour.Dispose();
                                translatedPointsI.Clear();
                            }

                            List<Point> translatedPoints = new List<Point>();

                            if (region.RegionType == 1)
                            {
                                foreach (var rPoint in region.Path)
                                {
                                    translatedPoints.Add(new Point(Convert.ToInt32(rPoint.X * pLeft), Convert.ToInt32(Convert.ToInt32(rPoint.Y - pTop) * hRate)));
                                }
                            }
                            else if (region.RegionType == 2)
                            {
                                foreach (var rPoint in region.Path)
                                {
                                    translatedPoints.Add(new Point(Convert.ToInt32(rPoint.X * pLeft), Convert.ToInt32(Convert.ToInt32(rPoint.Y - pTop - 1) * hRate)));
                                }
                                foreach (var rPoint in region.Path)
                                {
                                    translatedPoints.Add(new Point(Convert.ToInt32(rPoint.X * pLeft), Convert.ToInt32(Convert.ToInt32(rPoint.Y - pTop + 1) * hRate)));
                                }
                            }

                            // CALCULATE DELTA FRAME BY APPLYING MOVEMENT DETECTION
                            if (region.DetectMovement == true)
                            {
                                // BLUR WITH GAUSSIAN BEFORE CALCULATING DELTA
                                if (region.GaussianSize > 0)
                                    CvInvoke.GaussianBlur(gray, gray, new Size(region.GaussianSize.Value, region.GaussianSize.Value), 0);

                                // CROP OUT SELECTED REGIONS
                                Mat croppedRegion = new Mat(gray, regionRect);
                                Image<Hsv, Byte> croppedRegionHsv = new Mat(hsv.Mat, regionRect).ToImage<Hsv, Byte>();

                                if (region.FirstFrame == null)
                                {
                                    region.FirstFrame = croppedRegion.Clone();

                                    // CLEAR GARBAGE BEFORE CONTINUE
                                    croppedRegion.Dispose();
                                    croppedRegionHsv.Dispose();
                                    maskedRegion.Dispose();

                                    // MOVE TO NEXT FRAME
                                    continue;
                                }

                                Mat deltaThr = new Mat();
                                Mat deltaFrame = Mat.Zeros(croppedRegion.Rows, croppedRegion.Cols,
                                    Emgu.CV.CvEnum.DepthType.Cv8U, 1);
                                CvInvoke.AbsDiff(croppedRegion, region.FirstFrame, deltaFrame);
                                CvInvoke.Threshold(deltaFrame, deltaThr, 5, 255, Emgu.CV.CvEnum.ThresholdType.Binary);
                                CvInvoke.Dilate(deltaThr, deltaThr, null, new Point(-1, -1), 2,
                                    Emgu.CV.CvEnum.BorderType.Default, new MCvScalar(0));

                                Mat deltaThrClone = deltaThr.Clone();
                                VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
                                Mat hier = new Mat();
                                CvInvoke.FindContours(deltaThrClone, contours, hier,
                                    Emgu.CV.CvEnum.RetrType.External, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);

                                VectorOfPoint maxCnt = null;
                                double maxCntArea = 0;

                                if (contours.Length > 0)
                                {
                                    var pntArr = contours.ToArrayOfArray();

                                    for (int i = 0; i < pntArr.Length; i++)
                                    {
                                        var cnt = new VectorOfPoint(pntArr[i]);
                                        var cntArea = CvInvoke.ContourArea(cnt);
                                        if (maxCntArea < cntArea)
                                        {
                                            maxCnt = cnt;
                                            maxCntArea = cntArea;
                                        }
                                    }
                                }

                                Rectangle targetRect = Rectangle.Empty;

                                if (maxCnt != null && maxCntArea > (regionRect.Width * regionRect.Height) * 0.1)
                                {
                                    var contourRect = CvInvoke.BoundingRectangle(maxCnt);
                                    targetRect = new Rectangle(
                                        contourRect.X + Convert.ToInt32(contourRect.Width * 3 / 8.0),
                                        contourRect.Y + Convert.ToInt32(contourRect.Height * 3 / 8.0),
                                        contourRect.Width / 4,
                                        contourRect.Height / 4
                                        );
                                }
                                else
                                {
                                    targetRect = new Rectangle(
                                        0 + Convert.ToInt32(regionRect.Width * 6 / 16.0),
                                        0 + Convert.ToInt32(regionRect.Height * 6 / 16.0),
                                        regionRect.Width / 8,
                                        regionRect.Height / 8
                                        );
                                }

                                if (targetRect != Rectangle.Empty)
                                {
                                    // CALC EXACT POINTS OF RELATIVE TARGET
                                    Rectangle canvasTarget = new Rectangle(
                                            regionRect.X + targetRect.X,
                                            regionRect.Y + targetRect.Y,
                                            targetRect.Width,
                                            targetRect.Height
                                        );
                                    // DRAW TARGET
                                    CvInvoke.Rectangle(frame, canvasTarget, new MCvScalar(0, 255, 0), 2);

                                    // CHECK HSV RANGE
                                    if (region.CompareColor)
                                    {
                                        try
                                        {
                                            Image<Hsv, Byte> coloredTarget = new Mat(croppedRegionHsv.Mat, targetRect).ToImage<Hsv, Byte>();
                                                // .GetSubRect(targetRect);// new Mat(croppedRegionHsv, targetRect);
                                            
                                            Matrix<float> samples = new Matrix<float>(coloredTarget.Rows * coloredTarget.Cols, 1, 3);

                                            for (int y = 0; y < coloredTarget.Rows; y++)
                                            {
                                                for (int x = 0; x < coloredTarget.Cols; x++)
                                                {
                                                    var h = Convert.ToSingle(coloredTarget.Data[y, x, 0]);
                                                    var s = Convert.ToSingle(coloredTarget.Data[y, x, 1]);
                                                    var v = Convert.ToSingle(coloredTarget.Data[y, x, 2]);
                                                    samples.Data[y + x * coloredTarget.Rows, 0] = h;
                                                    samples.Data[y + x * coloredTarget.Rows, 1] = s;
                                                    samples.Data[y + x * coloredTarget.Rows, 2] = v;
                                                }
                                            }

                                            VectorOfInt bestLabels = new VectorOfInt();
                                            VectorOfFloat centers = new VectorOfFloat();
                                            var meanResult = CvInvoke.Kmeans(samples, 1, bestLabels, new MCvTermCriteria(10, 1.0),
                                                10, Emgu.CV.CvEnum.KMeansInitType.RandomCenters, centers);

                                            var hue = centers[0];
                                            var sat = centers[1];
                                            var val = centers[2];

                                            if (!string.IsNullOrEmpty(region.CmpHueRange))
                                            {
                                                float[] hueRange = region.CmpHueRange.Split(';').Select(d => Convert.ToSingle(d)).ToArray();
                                                float[] satRange = region.CmpSatRange.Split(';').Select(d => Convert.ToSingle(d)).ToArray();
                                                float[] valRange = region.CmpValRange.Split(';').Select(d => Convert.ToSingle(d)).ToArray();

                                                if (
                                                    (hueRange[0] <= hue && hue <= hueRange[1])
                                                    &&
                                                    (satRange[0] <= sat && sat <= satRange[1])
                                                    &&
                                                    (valRange[0] <= val && val <= valRange[1])
                                                    )
                                                {
                                                    isOk = false;
                                                }
                                            }

                                            this.BeginInvoke((Action)delegate
                                            {
                                                lblHsv.Text = string.Format("{0:000.00}", hue) + " | "
                                                    + string.Format("{0:000.00}", sat) + " | "
                                                    + string.Format("{0:000.00}", val);
                                            });
                                        }
                                        catch (Exception)
                                        {

                                        }
                                    }
                                }

                                // CHECK HISTORY FRAME THRESHOLD
                                region.FrameCounter++;
                                if (region.FrameCounter > (region.DetectHistoryFrame ?? 50))
                                {
                                    region.FirstFrame = croppedRegion.Clone();
                                    region.FrameCounter = 0;
                                }

                                // DISPOSE GARBAGE
                                deltaThr.Dispose();
                                deltaThrClone.Dispose();
                                deltaFrame.Dispose();
                                croppedRegion.Dispose();
                                croppedRegionHsv.Dispose();
                                maskedRegion.Dispose();

                                continue;
                            }

                            // FILTER & THRESHOLDING OPERATIONS
                            if (region.GaussianBlur == true)
                            {
                                CvInvoke.GaussianBlur(maskedRegion, maskedRegion, new Size(region.GaussianSize ?? 3, region.GaussianSize ?? 3),
                                    region.GaussianSigma ?? 0, region.GaussianSigma ?? 0, Emgu.CV.CvEnum.BorderType.Default);
                                //if (region.ConvertToHsv)
                                //{
                                //    CvInvoke.GaussianBlur(maskedRegionGray, maskedRegionGray, new Size(region.GaussianSize ?? 3, region.GaussianSize ?? 3),
                                //        region.GaussianSigma ?? 0, region.GaussianSigma ?? 0, Emgu.CV.CvEnum.BorderType.Default);
                                //}
                            }
                            if (region != null && region.ApplyCanny)
                            {
                                var tmpMaskedRegion = maskedRegion.Clone();
                                var cannyRegion = maskedRegion.Clone();
                                //CvInvoke.AddWeighted(cannyRegion, 100, cannyRegion, 0, 0, cannyRegion);
                                //CvInvoke.ConvertScaleAbs(cannyRegion, cannyRegion, 1, 0);
                                //CvInvoke.EqualizeHist(maskedRegion, maskedRegion);
                                CvInvoke.BilateralFilter(cannyRegion, tmpMaskedRegion, -1,
                                        8, 8);
                                //CvInvoke.AdaptiveThreshold(tmpMaskedRegion, tmpMaskedRegion, 255,
                                //    Emgu.CV.CvEnum.AdaptiveThresholdType.GaussianC,
                                //    Emgu.CV.CvEnum.ThresholdType.BinaryInv, 3, 25);
                                //CvInvoke.GaussianBlur(tmpMaskedRegion, tmpMaskedRegion, new Size(3, 3), 5);
                                CvInvoke.MedianBlur(tmpMaskedRegion, tmpMaskedRegion, 5);
                                //CvInvoke.ConvertScaleAbs(maskedRegion, maskedRegion, 1, 0);
                                //CvInvoke.AddWeighted(tmpMaskedRegion, 1.5, tmpMaskedRegion, 0, 0, tmpMaskedRegion);
                                //CvInvoke.InRange(tmpMaskedRegion,
                                //    new ScalarArray(new Emgu.CV.Structure.MCvScalar(195)),
                                //    new ScalarArray(new Emgu.CV.Structure.MCvScalar(250)),
                                //    tmpMaskedRegion);

                                //if (SelectedRegion != null && SelectedRegion.Id == region.Id)
                                //{
                                //    this.BeginInvoke((Action)delegate
                                //    {
                                //        imgMask.Image = tmpMaskedRegion.Clone();
                                //    });
                                //}

                                CvInvoke.Canny(tmpMaskedRegion, cannyRegion, region.CannyThreshold1, region.CannyThreshold2, 3);
                                Emgu.CV.Util.VectorOfVectorOfPoint contours = new Emgu.CV.Util.VectorOfVectorOfPoint();

                                var vectorOfSelection = new VectorOfPoint(translatedPoints.ToArray());
                                VectorOfVectorOfPoint selectedContours
                                                   = new VectorOfVectorOfPoint(vectorOfSelection);
                                Mat hier = new Mat();

                                CvInvoke.FindContours(cannyRegion, contours, hier,
                                    Emgu.CV.CvEnum.RetrType.Ccomp, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxNone);

                                CvInvoke.DrawContours(frame, contours, -1, new MCvScalar(0, 255, 0), 1);
                                CvInvoke.DrawContours(maskedRegion, contours, -1, new MCvScalar(10), 1);

                                VectorOfPoint maxApprox = null;
                                VectorOfPoint maxContour = null;
                                var selectedArea = CvInvoke.ContourArea(vectorOfSelection);

                                List<VectorOfPoint> biggestList = new List<VectorOfPoint>();

                                for (int i = 0; i < contours.Length; i++)
                                {
                                    try
                                    {
                                        //var approxArea = CvInvoke.ContourArea(contours[i]);

                                        //if ((selectedArea * 0.95) > approxArea && approxArea >= (selectedArea * region.MinShapeArea))
                                        //    if (maxApprox == null || CvInvoke.ContourArea(maxApprox) < approxArea)
                                        //        maxApprox = contours[i];

                                        var cnt = contours[i];
                                        var perimeter = CvInvoke.ArcLength(cnt, true);
                                        var epsilon = region.CannyEpsilon * perimeter;
                                        VectorOfPoint approx = new VectorOfPoint();
                                        CvInvoke.ApproxPolyDP(cnt, approx, epsilon, true);
                                        if (approx != null && approx.Length > 0)
                                        {
                                            //CvInvoke.DrawContours(frame, new VectorOfVectorOfPoint(approx), -1, new MCvScalar(255, 255, 0), 1);
                                            biggestList.Add(approx);
                                            var approxArea = CvInvoke.ContourArea(approx);
                                            if ((selectedArea * 0.95) > approxArea && approxArea >= (selectedArea * region.MinShapeArea))
                                                if (maxApprox == null || CvInvoke.ContourArea(maxApprox) < approxArea)
                                                {
                                                    maxApprox = approx;
                                                    maxContour = cnt;
                                                }
                                        }
                                    }
                                    catch (Exception)
                                    {

                                    }
                                }

                                //maxApprox = biggestList.OrderByDescending(d => CvInvoke.ContourArea(d))
                                //    .FirstOrDefault();


                                if (maxApprox != null)
                                {
                                    Mat maskZeros = Mat.Zeros(gray.Rows, gray.Cols, Emgu.CV.CvEnum.DepthType.Cv8U, 1);

                                    VectorOfVectorOfPoint contourBiggest
                                                   = new VectorOfVectorOfPoint(maxContour);

                                    CvInvoke.DrawContours(maskZeros, contourBiggest, 0, new MCvScalar(255), -1);
                                    CvInvoke.BitwiseAnd(maskedRegion, maskZeros, maskedRegion);

                                    CvInvoke.DrawContours(frame, contourBiggest, -1, new MCvScalar(0, 255, 0), 1);

                                    //if (SelectedRegion != null && SelectedRegion.Id == region.Id)
                                    //{
                                    //    this.BeginInvoke((Action)delegate
                                    //    {
                                    //        imgMask.Image = maskedRegion.Clone();
                                    //    });
                                    //}
                                }

                                hier.Dispose();
                                tmpMaskedRegion.Dispose();
                                cannyRegion.Dispose();
                                vectorOfSelection.Dispose();
                                selectedContours.Dispose();
                            }
                            if (region.BilateralFilter == true)
                            {
                                try
                                {
                                    var targetBilateral = maskedRegion.Clone();
                                    CvInvoke.BilateralFilter(maskedRegion, targetBilateral, region.BilateralD ?? 0,
                                        region.BilateralSigmaColor ?? 0, region.BilateralSigmaSpace ?? 0);

                                    maskedRegion = targetBilateral;

                                    //if (SelectedRegion != null && SelectedRegion.Id == region.Id)
                                    //{
                                    //    this.BeginInvoke((Action)delegate
                                    //    {
                                    //        imgMask.Image = targetBilateral;
                                    //    });
                                    //}
                                }
                                catch (Exception ex)
                                {

                                }
                            }
                            if (region != null)
                            {
                                //var dilElm = CvInvoke.GetStructuringElement(Emgu.CV.CvEnum.ElementShape.Rectangle, new Size(3, 3), new Point(-1, -1));
                                //CvInvoke.Erode(maskedRegion, maskedRegion, dilElm,
                                //    new Point(-1, -1), 1, Emgu.CV.CvEnum.BorderType.Default,
                                //    new MCvScalar(255));
                                //CvInvoke.Dilate(maskedRegion, maskedRegion, dilElm,
                                //    new Point(-1, -1), 1, Emgu.CV.CvEnum.BorderType.Default,
                                //    new MCvScalar(255));
                                //dilElm.Dispose();
                            }
                            if (region.Sharpen == true)
                            {
                                int[][] kernelVals = new int[][] {
                                    new int[]{ -1,-1,-1 },
                                    new int[]{ -1,9,-1 },
                                    new int[]{ -1,-1,-1 },
                                };
                                Mat kernel = new Mat(new int[] { kernelVals.Length, kernelVals[0].Length },
                                    Emgu.CV.CvEnum.DepthType.Cv8U, new VectorOfVectorOfInt(kernelVals));

                                CvInvoke.Filter2D(maskedRegion, maskedRegion, kernel, new System.Drawing.Point(-1, -1));

                                if (SelectedRegion != null && SelectedRegion.Id == region.Id)
                                {
                                    this.BeginInvoke((Action)delegate
                                    {
                                        imgMask.Image = maskedRegion;
                                    });
                                }
                            }
                            if (region.EqualizeHist)
                            {
                                CvInvoke.EqualizeHist(maskedRegion, maskedRegion);
                            }
                            if (region.Laplacian)
                            {
                                CvInvoke.Laplacian(maskedRegion, maskedRegion, Emgu.CV.CvEnum.DepthType.Cv8U, region.LaplaceSize);
                            }
                            if (region.ConvertToGray && region.ApplySobel == true)
                            {
                                Mat sobelRegion = Mat.Zeros(gray.Rows, gray.Cols, Emgu.CV.CvEnum.DepthType.Cv8U, region.ConvertToHsv ? 3 : 1);

                                CvInvoke.Sobel(maskedRegion, sobelRegion, Emgu.CV.CvEnum.DepthType.Cv32F, region.SobelDx ?? 0, region.SobelDy ?? 0,
                                    region.SobelKernel ?? 3);
                                CvInvoke.ConvertScaleAbs(sobelRegion, maskedRegion, 1, 0);

                                sobelRegion.Dispose();

                                //var dilElm = CvInvoke.GetStructuringElement(Emgu.CV.CvEnum.ElementShape.Rectangle, new Size(3, 3), new Point(-1, -1));
                                //CvInvoke.Dilate(maskedRegion, maskedRegion, dilElm,
                                //    new Point(-1, -1), 1, Emgu.CV.CvEnum.BorderType.Default,
                                //    new MCvScalar(255));
                                //dilElm.Dispose();

                                //this.BeginInvoke((Action)delegate
                                //{
                                //    imgMask.Image = maskedRegion;
                                //});
                            }

                            if (region.ConvertToGray &&
                                    region.ManualThr)
                            {
                                CvInvoke.InRange(maskedRegion, new ScalarArray(new MCvScalar(region.ManuelStart)),
                                     new ScalarArray(new MCvScalar(region.ManuelEnd)), maskedRegion);
                            }
                            if (region.ConvertToHsv && region.ManualThr)
                            {
                                var tmpMaskForHsv = Mat.Zeros(gray.Rows, gray.Cols, Emgu.CV.CvEnum.DepthType.Cv8U, 1);

                                CvInvoke.InRange(maskedRegion, new ScalarArray(new MCvScalar(region.HStart, region.SStart, region.VStart)),
                                    new ScalarArray(new MCvScalar(region.HEnd, region.SEnd, region.VEnd)), maskedRegion);

                                maskedRegion = tmpMaskForHsv;
                            }
                            
                            if (region.AdaptiveThr && region.ConvertToGray)
                            {
                                CvInvoke.AdaptiveThreshold(maskedRegion, maskedRegion, 255, Emgu.CV.CvEnum.AdaptiveThresholdType.MeanC,
                                    Emgu.CV.CvEnum.ThresholdType.BinaryInv, region.AdaptiveSize, region.AdaptiveParam);


                                try
                                {
                                    VectorOfVectorOfPoint contour
                                                   = new VectorOfVectorOfPoint(new VectorOfPoint(translatedPoints.ToArray()));

                                    CvInvoke.DrawContours(maskedRegion, contour, -1, new MCvScalar(0), region.AdaptiveBorder);

                                    contour.Dispose();
                                }
                                catch (Exception)
                                {

                                }
                            }

                            //if (SelectedRegion != null && SelectedRegion.Id == region.Id)
                            //{
                            //    this.BeginInvoke((Action)delegate
                            //    {
                            //        imgMask.Image = maskedRegion;
                            //    });
                            //}

                            // DECISION MAKING OK / NOK
                            if (region.NokThreshold > -1)
                            {
                                List<Point> translatedPointsI = new List<Point>();

                                if (region.RegionType == 1)
                                {
                                    foreach (var rPoint in region.Path)
                                    {
                                        translatedPointsI.Add(new Point(Convert.ToInt32(rPoint.X * pLeft), Convert.ToInt32(Convert.ToInt32(rPoint.Y - pTop) * hRate)));
                                    }
                                }
                                else if (region.RegionType == 2)
                                {
                                    foreach (var rPoint in region.Path)
                                    {
                                        translatedPointsI.Add(new Point(Convert.ToInt32(rPoint.X * pLeft), Convert.ToInt32(Convert.ToInt32(rPoint.Y - pTop - 1) * hRate)));
                                    }
                                    foreach (var rPoint in region.Path)
                                    {
                                        translatedPointsI.Add(new Point(Convert.ToInt32(rPoint.X * pLeft), Convert.ToInt32(Convert.ToInt32(rPoint.Y - pTop + 1) * hRate)));
                                    }
                                }

                                if (translatedPoints.Count() > 0)
                                {
                                    VectorOfVectorOfPoint contour
                                                   = new VectorOfVectorOfPoint(new VectorOfPoint(translatedPointsI.ToArray()));

                                    //if (SelectedRegion != null && SelectedRegion.Id == region.Id)
                                    //{
                                    //    this.BeginInvoke((Action)delegate
                                    //    {
                                    //        imgMask.Image = maskedRegion;
                                    //    });
                                    //}

                                    var regionArea = CvInvoke.ContourArea(contour[0]);
                                    var faultArea = CvInvoke.CountNonZero(maskedRegion);
                                    contour.Dispose();

                                    var nokRate = faultArea / regionArea * 100;

                                    if (SelectedRegion != null && SelectedRegion.Id == region.Id)
                                    {
                                        this.BeginInvoke((Action)delegate
                                        {
                                            lblNokRate.Text = string.Format("{0:N2}", nokRate);
                                        });
                                    }

                                    if (faultArea / regionArea * 100 > region.NokThreshold)
                                    {
                                        isOk = false;

                                        // DRAW FAULT POINTS
                                        VectorOfPoint faultPixels = new VectorOfPoint();
                                        CvInvoke.FindNonZero(maskedRegion, faultPixels);

                                        if (faultPixels.Length > 0)
                                        {
                                            var dilElm = CvInvoke.GetStructuringElement(Emgu.CV.CvEnum.ElementShape.Rectangle, new Size(3, 3), new Point(-1, -1));
                                            CvInvoke.Dilate(maskedRegion, maskedRegion, dilElm,
                                                new Point(-1, -1), 1, Emgu.CV.CvEnum.BorderType.Default,
                                                new MCvScalar(255));
                                            dilElm.Dispose();

                                            Mat[] channelsOfFrame = frame.Split();
                                            var redChannel = channelsOfFrame[2];
                                            CvInvoke.BitwiseOr(redChannel, maskedRegion, redChannel);
                                            CvInvoke.BitwiseXor(channelsOfFrame[0], maskedRegion, channelsOfFrame[0]);
                                            CvInvoke.BitwiseXor(channelsOfFrame[1], maskedRegion, channelsOfFrame[1]);

                                            var mergeData = new VectorOfMat(channelsOfFrame[0], channelsOfFrame[1], redChannel);
                                            CvInvoke.Merge(mergeData, frame);

                                            mergeData.Dispose();
                                            //VectorOfVectorOfPoint faultContour
                                            //        = new VectorOfVectorOfPoint(faultPixels);
                                            //CvInvoke.DrawContours(frame, faultContour, -1, new MCvScalar(0, 0, 255), 1);
                                            //faultContour.Dispose();
                                        }

                                        faultPixels.Dispose();
                                    }

                                    contour.Dispose();
                                }
                            }

                            translatedPoints.Clear();

                            // CLEAR ROI OBJECTS
                            maskedRegion.Dispose();
                        }

                        // SHOW RESULT COLOR
                        this.BeginInvoke((Action)delegate
                        {
                            if (isOk)
                                lblResult.BackColor = Color.LimeGreen;
                            else
                                lblResult.BackColor = Color.Red;
                        });
                        #endregion

                        this.BeginInvoke((Action)delegate
                        {
                            data.ImageBox.Image = frame;
                            frame.Dispose();
                            hsv.Dispose();
                            //cloneFrame.Dispose();
                            gray.Dispose();
                        });
                    }
                    catch (Exception ex)
                    {

                    }
                }
                else
                    break;

                await Task.Delay(200);
            }
        }

        #region WINFORM EVENTS
        private void cmbCamera_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_cameraSelection)
                return;

            //StartCapture();
        }

        private void frmHekaStudio_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopCapture();
        }

        private void tBarExposure_ValueChanged(object sender, EventArgs e)
        {
            if (SelectedCamera != null)
            {
                var relatedCapture = _captureList.FirstOrDefault(d => d.CameraName == _selectedCamera.CameraName);
                if (relatedCapture != null && relatedCapture.Capture != null)
                {
                    if (relatedCapture.AutoExposure == false)
                    {
                        relatedCapture.Capture.Set(Emgu.CV.CvEnum.CapProp.AutoExposure, 1);
                        relatedCapture.Capture.Set(Emgu.CV.CvEnum.CapProp.Exposure, tBarExposure.Value);
                    }
                }
            }

            //if (_activeCapture != null)
            //{
            //    _activeCapture.Set(Emgu.CV.CvEnum.CapProp.Exposure, tBarExposure.Value);
            //}
        }

        private void btnShape_Click(object sender, EventArgs e)
        {
            if (SelectedCamera != null)
            {
                var relatedCamera = _captureList.FirstOrDefault(d => d.CameraName == SelectedCamera.CameraName);
                if (relatedCamera != null)
                {
                    relatedCamera.SelectionRunning = !relatedCamera.SelectionRunning;
                    if (relatedCamera.SelectionRunning)
                    {
                        relatedCamera.SelectionPath.Clear();
                        btnShape.Text = "Bitir";
                        CheckUndoEnabled();
                    }
                    else
                    {
                        string newTitle = Prompt.ShowDialog("Bölge Adı", "Bilgi");
                        if (!string.IsNullOrEmpty(newTitle))
                        {
                            var region = new HekaRegion
                            {
                                Title = newTitle,
                                RegionType = 1,
                                Path = relatedCamera.SelectionPath.ToArray(),
                            };

                            using (EyeBO bObj = new EyeBO())
                            {
                                var bResult = bObj.SaveRegion(new Data.Region
                                {
                                    Enabled = true,
                                    CameraId = SelectedCamera.Id,
                                    RecipeId = SelectedRecipe.Id,
                                    Title = newTitle,
                                }, region);

                                if (bResult.Result)
                                    region.Id = bResult.RecordId;
                            }

                            _regionList.Add(region);
                            UpdateRegionList();
                            SelectedRegion = region;
                        }
                        btnShape.Text = "Bölge";

                        relatedCamera.SelectionPath.Clear();
                        CheckUndoEnabled();
                    }
                }
            }
        }

        private void btnLine_Click(object sender, EventArgs e)
        {
            if (SelectedCamera != null)
            {
                var relatedCamera = _captureList.FirstOrDefault(d => d.CameraName == SelectedCamera.CameraName);
                if (relatedCamera != null)
                {
                    relatedCamera.SelectionRunning = !relatedCamera.SelectionRunning;
                    if (relatedCamera.SelectionRunning)
                    {
                        relatedCamera.SelectionPath.Clear();
                        btnLine.Text = "Bitir";

                        CheckUndoEnabled();
                    }
                    else
                    {
                        string newTitle = Prompt.ShowDialog("Çizgi Adı", "Bilgi");
                        if (!string.IsNullOrEmpty(newTitle))
                        {
                            var region = new HekaRegion
                            {
                                Title = newTitle,
                                RegionType = 2,
                                Path = relatedCamera.SelectionPath.ToArray(),
                            };

                            using (EyeBO bObj = new EyeBO())
                            {
                                var bResult = bObj.SaveRegion(new Data.Region
                                {
                                    Enabled = true,
                                    CameraId = SelectedCamera.Id,
                                    RecipeId = SelectedRecipe.Id,
                                    Title = newTitle,
                                }, region);

                                if (bResult.Result)
                                    region.Id = bResult.RecordId;
                            }

                            _regionList.Add(region);
                            UpdateRegionList();
                            SelectedRegion = region;
                        }
                        btnLine.Text = "Çizgi";

                        relatedCamera.SelectionPath.Clear();
                        CheckUndoEnabled();
                    }
                }
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (SelectedCamera != null)
            {
                var relatedCamera = _captureList.FirstOrDefault(d => d.CameraName == SelectedCamera.CameraName);
                if (relatedCamera != null)
                {
                    if (relatedCamera.SelectionPath.Any())
                    {
                        _hoverPoint = Point.Empty;
                        relatedCamera.SelectionPath.RemoveAt(relatedCamera.SelectionPath.Count() - 1);

                        CheckUndoEnabled();
                    }
                }
            }
        }
        #endregion

        #region CAPTURE BOX MOUSE EVENTS
        private void imgBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (SelectedCamera != null)
            {
                var relatedCapture = _captureList.FirstOrDefault(d => d.CameraName == SelectedCamera.CameraName);
                if (relatedCapture != null)
                {
                    if (relatedCapture.SelectionRunning)
                    {
                        if (!relatedCapture.SelectionStepRunning)
                        {
                            relatedCapture.SelectionStepRunning = true;

                            if (relatedCapture.SelectionPath.Count() == 0)
                                relatedCapture.SelectionPath.Add(new Point(e.X, e.Y));
                            else
                            {
                                var pntDown = new Point(e.X, e.Y);
                                if (_hoverPoint == Point.Empty || _hoverPoint.X != _hoverPoint.X || _hoverPoint.Y != _hoverPoint.Y)
                                    _hoverPoint = pntDown;
                            }

                            CheckUndoEnabled();
                        }
                    }
                }
            }
        }

        private void imgBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (SelectedCamera != null)
            {
                var relatedCapture = _captureList.FirstOrDefault(d => d.CameraName == SelectedCamera.CameraName);
                if (relatedCapture != null)
                {
                    if (relatedCapture.SelectionRunning && relatedCapture.SelectionStepRunning)
                    {
                        _hoverPoint = new Point(e.X, e.Y);
                        lblX.Text = e.X.ToString();
                        lblY.Text = e.Y.ToString();
                    }
                }
            }
        }

        private void imgBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (SelectedCamera != null)
            {
                var relatedCapture = _captureList.FirstOrDefault(d => d.CameraName == SelectedCamera.CameraName);
                if (relatedCapture != null)
                {
                    if (relatedCapture.SelectionRunning && relatedCapture.SelectionStepRunning)
                    {
                        relatedCapture.SelectionStepRunning = false;

                        if (_hoverPoint != Point.Empty)
                            relatedCapture.SelectionPath.Add(_hoverPoint);

                        // CLOSE SHAPE
                        if (relatedCapture.SelectionType == 1 && relatedCapture.SelectionPath.Count() > 0)
                        {
                            var startPoint = relatedCapture.SelectionPath[0];
                            relatedCapture.SelectionPath.Add(new Point(startPoint.X, startPoint.Y));
                        }

                        _hoverPoint = Point.Empty;

                        CheckUndoEnabled();
                    }
                }
            }
        }

        #endregion

        private void btnRecipe_Click(object sender, EventArgs e)
        {
            string recipeName = Prompt.ShowDialog("Reçete Adı", "Bilgi");
            if (!string.IsNullOrEmpty(recipeName))
            {
                using (EyeBO bObj = new EyeBO())
                {
                    var nRecipe = new Recipe
                    {
                        CameraName = "",
                        Exposure = tBarExposure.Value,
                        RecipeCode = recipeName,
                        RecipeName = recipeName,
                    };
                    var bResult = bObj.SaveRecipe(nRecipe);

                    if (!bResult.Result)
                        MessageBox.Show(bResult.ErrorMessage, "Hata");
                    else
                    {
                        UpdateRecipeList();
                        nRecipe.Id = bResult.RecordId;
                        SelectedRecipe = nRecipe;
                    }
                }
            }
        }

        private void btnModel_Click(object sender, EventArgs e)
        {
            if (SelectedRecipe == null)
            {
                MessageBox.Show("Önce reçete seçmelisiniz.", "Uyarı");
                return;
            }

            string modelName = Prompt.ShowDialog("Model No", "Bilgi");

            if (!string.IsNullOrEmpty(modelName))
            {
                using (EyeBO bObj = new EyeBO())
                {
                    var bResult = bObj.SaveModel(new Product
                    {
                        IsActive = true,
                        ProductCode = modelName,
                        ProductName = modelName,
                        RecipeId = SelectedRecipe.Id,
                    });

                    if (!bResult.Result)
                        MessageBox.Show(bResult.ErrorMessage, "Hata");
                    else
                        UpdateModelList();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (prpGrid.SelectedObject != null &&
                MessageBox.Show("Silmek istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (prpGrid.SelectedObject.GetType() == typeof(HekaRegion))
                {
                    using (EyeBO bObj = new EyeBO())
                    {
                        var bResult = bObj.DeleteRegion((prpGrid.SelectedObject as HekaRegion).Id);
                        if (!bResult.Result)
                            MessageBox.Show(bResult.ErrorMessage, "Hata");
                        else
                            UpdateCameraList();
                    }
                }
                else if (prpGrid.SelectedObject.GetType() == typeof(Recipe))
                {
                    using (EyeBO bObj = new EyeBO())
                    {
                        var bResult = bObj.DeleteRecipe((prpGrid.SelectedObject as Recipe).Id);
                        if (!bResult.Result)
                            MessageBox.Show(bResult.ErrorMessage, "Hata");
                        else
                            UpdateRecipeList();
                    }
                }
                else if (prpGrid.SelectedObject != null)
                {
                    using (EyeBO bObj = new EyeBO())
                    {
                        var bResult = bObj.DeleteModel((prpGrid.SelectedObject as Product).Id);
                        if (!bResult.Result)
                            MessageBox.Show(bResult.ErrorMessage, "Hata");
                        else
                            UpdateModelList();
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            lblSaveResult.Text = "";

            if (prpGrid.SelectedObject != null)
            {
                if (prpGrid.SelectedObject.GetType() == typeof(HekaRegion))
                {
                    using (EyeBO bObj = new EyeBO())
                    {
                        var tagData = (prpGrid.SelectedObject as HekaRegion);
                        var bResult = bObj.SaveRegion(new Data.Region { 
                            Id = tagData.Id,
                            Title = tagData.Title,
                            RecipeId = SelectedRecipe.Id,
                            CameraId = SelectedCamera.Id,
                            Enabled = tagData.Enabled,
                        }, tagData);
                        if (!bResult.Result)
                            MessageBox.Show(bResult.ErrorMessage, "Hata");
                        else
                        {
                            UpdateRegionList();
                            //UpdateCameraList();
                            SelectedRegion = tagData;
                            lblSaveResult.Text = "Kayıt Başarılı";
                        }
                    }
                }
                else if (prpGrid.SelectedObject.GetType() == typeof(Recipe))
                {
                    using (EyeBO bObj = new EyeBO())
                    {
                        var tagData = (prpGrid.SelectedObject as Recipe);
                        tagData.Exposure = tBarExposure.Value;
                        //tagData.CameraName = cmbCamera.Text;

                        var bResult = bObj.SaveRecipe(tagData);
                        if (!bResult.Result)
                            MessageBox.Show(bResult.ErrorMessage, "Hata");
                        else
                        {
                            UpdateRecipeList();
                            SelectedRecipe = tagData;
                            lblSaveResult.Text = "Kayıt Başarılı";
                        }
                    }
                }
                else if (prpGrid.SelectedObject.GetType().Name.Contains("RecipeCamera"))
                {
                    using (EyeBO bObj = new EyeBO())
                    {
                        var tagData = (prpGrid.SelectedObject as RecipeCamera);
                        tagData.Exposure = tBarExposure.Value;
                        var actCam = _cameraList[cmbCamera.SelectedIndex];
                        tagData.CameraName = actCam.DevicePath;

                        var bResult = bObj.SaveCamera(tagData);
                        if (!bResult.Result)
                            MessageBox.Show(bResult.ErrorMessage, "Hata");
                        else
                        {
                            UpdateCameraList();
                            SelectedCamera = tagData;
                            lblSaveResult.Text = "Kayıt Başarılı";
                        }
                    }
                }
                else if (prpGrid.SelectedObject.GetType().Name.Contains("Product"))
                {
                    using (EyeBO bObj = new EyeBO())
                    {
                        var tagData = (prpGrid.SelectedObject as Product);
                        var bResult = bObj.SaveModel(tagData);
                        if (!bResult.Result)
                            MessageBox.Show(bResult.ErrorMessage, "Hata");
                        else
                        {
                            UpdateModelList();
                            SelectedModel = tagData;
                            lblSaveResult.Text = "Kayıt Başarılı";
                        }
                    }
                }
               
            }
        }

        private void btnStartTemplate_Click(object sender, EventArgs e)
        {
            _selectionRunning = !_selectionRunning;
            if (_selectionRunning)
            {
                _selectionPath.Clear();
                btnShape.Text = "Bitir";
                CheckUndoEnabled();
            }
            else
            {
                using (EyeBO bObj = new EyeBO())
                {
                    var bResult = bObj.SaveRecipeStartTemplate(SelectedRecipe.Id, null);
                }
                
                btnStartTemplate.Text = "Start Template";

                _selectionPath.Clear();
                CheckUndoEnabled();
            }
        }

        private void btnCamera_Click(object sender, EventArgs e)
        {
            if (cmbCamera.SelectedIndex < 0)
            {
                MessageBox.Show("Önce kamera seçmelisiniz.", "Uyarı");
                return;
            }

            if (SelectedRecipe == null || SelectedRecipe.Id <= 0)
            {
                MessageBox.Show("Önce reçete seçmelisiniz.", "Uyarı");
                return;
            }

            CameraModel camModel = _cameraList[cmbCamera.SelectedIndex];

            using (EyeBO bObj = new EyeBO())
            {
                var bResult = bObj.SaveCamera(new RecipeCamera
                {
                    Id = 0,
                    RecipeId = SelectedRecipe.Id,
                    CameraName = camModel.DevicePath,
                    Exposure = tBarExposure.Value,
                    IsActive = true,
                });

                if (!bResult.Result)
                    MessageBox.Show(bResult.ErrorMessage, "Hata");
                else
                    UpdateCameraList();
            }
        }

        private void flPanelCams_SizeChanged(object sender, EventArgs e)
        {
            UpdateCameraList();
        }

        private void btnSetOffsetOfRegions_Click(object sender, EventArgs e)
        {
            if (SelectedCamera != null && SelectedCamera.Id > 0)
            {
                try
                {
                    int ofsX = 0;
                    int ofsY = 0;

                    if (Int32.TryParse(txtOffsetX.Text, out ofsX) && 
                        Int32.TryParse(txtOffsetY.Text, out ofsY))
                    {
                        using (EyeBO bObj = new EyeBO())
                        {
                            var bResult = bObj.SetOffsetOfRegions(SelectedCamera.Id, ofsX, ofsY);
                            if (bResult.Result)
                            {
                                MessageBox.Show("Offset ayarlandı.");
                                UpdateCameraList();
                            }
                        }
                    }
                }
                catch (Exception)
                {

                }
            }
        }

        private void ClearArrowButtons()
        {
            _leftCount = 0;
            _rightCount = 0;
            _upCount = 0;
            _downCount = 0;
        }
        private void btnSetPosition_Click(object sender, EventArgs e)
        {
            _positionIsRunning = !_positionIsRunning;
            if (_positionIsRunning)
            {
                ClearArrowButtons();
                btnSetPosition.BackColor = Color.DodgerBlue;

                if (_rotationIsRunning)
                {
                    _rotationIsRunning = false;
                    btnSetRotation.BackColor = Color.Gainsboro;
                }
            }
            else
                btnSetPosition.BackColor = Color.Gainsboro;
        }

        private void btnSetRotation_Click(object sender, EventArgs e)
        {
            _rotationIsRunning = !_rotationIsRunning;
            if (_rotationIsRunning)
            {
                ClearArrowButtons();
                btnSetRotation.BackColor = Color.DodgerBlue;

                if (_positionIsRunning)
                {
                    _positionIsRunning = false;
                    btnSetPosition.BackColor = Color.Gainsboro;
                }
            }
            else
                btnSetRotation.BackColor = Color.Gainsboro;
        }

        private void btnUp_MouseDown(object sender, MouseEventArgs e)
        {
            if (_positionIsRunning)
                _upCount++;
        }

        private void btnRight_MouseDown(object sender, MouseEventArgs e)
        {
            if (_positionIsRunning || _rotationIsRunning)
                _rightCount++;
        }

        private void btnDown_MouseDown(object sender, MouseEventArgs e)
        {
            if (_positionIsRunning)
                _downCount++;
        }

        private void btnLeft_MouseDown(object sender, MouseEventArgs e)
        {
            if (_positionIsRunning || _rotationIsRunning)
                _leftCount++;
        }

        private void btnDoCapture_Click(object sender, EventArgs e)
        {
            if (SelectedCamera != null && SelectedCamera.Id > 0)
            {
                var relatedCap = _captureList.FirstOrDefault(d => d.CameraId == SelectedCamera.Id);
                if (relatedCap != null)
                {
                    relatedCap.DoQueryFrame = true;
                }
            }
            //foreach (var item in _captureList)
            //{
            //    item.DoQueryFrame = true;
            //}
        }
    }
}
