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

        MCvScalar _regionSelectionColor = new MCvScalar(255, 0, 0);
        MCvScalar _lineSelectionColor = new MCvScalar(155, 155, 0);

        List<HekaRegion> _regionList = new List<HekaRegion>();

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
                    prpGrid.SelectedObject = _selectedRegion;
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
                
                UpdateRegionList();
                UpdateModelList();

                if (_selectedRecipe != null)
                {
                    lblRecipe.Text = _selectedRecipe.RecipeCode;

                    if (!string.IsNullOrEmpty(_selectedRecipe.CameraName))
                        cmbCamera.Text = _selectedRecipe.CameraName;

                    if (_selectedRecipe.Exposure != null)
                    {
                        tBarExposure.Value = _selectedRecipe.Exposure.Value;
                        if (_activeCapture != null)
                        {
                            _activeCapture.Set(Emgu.CV.CvEnum.CapProp.Exposure, tBarExposure.Value);
                        }
                    }
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
        private void UpdateRegionList()
        {
            flPanelRegions.Controls.Clear();

            if (SelectedRecipe != null)
            {
                using (EyeBO bObj = new EyeBO())
                {
                    var allRegions = bObj.GetRegionList(SelectedRecipe.Id)
                        .Select(d => new HekaRegion { 
                            Id = d.Id,
                            Title = d.Title,
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
            btnUndo.Visible = _selectionPath.Any();
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            var tagItem = ((HekaRegion)(sender as Control).Tag);
            if (tagItem != null)
            {
                using (EyeBO bObj = new EyeBO())
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

        private void StopCapture()
        {
            _captureRunning = false;

            try
            {
                if (_tCapture != null)
                    _tCapture.Dispose();
            }
            catch (Exception)
            {

            }

            if (_activeCapture != null)
            {
                _activeCapture.Stop();
                _activeCapture.Dispose();
            }
        }
        private void StartCapture()
        {
            if (cmbCamera.SelectedIndex < 0)
                return;

            lblStatus.Visible = true;

            try
            {
                CameraModel selectedCamera = _cameraList[cmbCamera.SelectedIndex];

                StopCapture();

                _activeCapture = new VideoCapture(selectedCamera.DeviceIndex);
                var currentExposure = _activeCapture.Get(Emgu.CV.CvEnum.CapProp.Exposure);
                tBarExposure.Value = Convert.ToInt32(currentExposure);

                _captureRunning = true;
                _tCapture = Task.Run(LoopCapture);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Uyarı");
            }
        }

        private async Task LoopCapture()
        {
            while (_captureRunning)
            {
                try
                {
                    var frame = _activeCapture.QueryFrame();
                    var cloneFrame = frame.Clone();

                    this.BeginInvoke((Action)delegate
                    {
                        lblStatus.Visible = false;
                    });

                    var gray = new Mat(frame.Rows, frame.Cols, Emgu.CV.CvEnum.DepthType.Cv8U, 1);
                    var hsv = new Mat(frame.Rows, frame.Cols, frame.Depth, 1);
                    CvInvoke.CvtColor(cloneFrame, gray, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);
                    CvInvoke.CvtColor(cloneFrame, hsv, Emgu.CV.CvEnum.ColorConversion.Bgr2Hsv);

                    #region DRAW ACTIVE SELECTION
                    if (_selectionRunning && _selectionPath.Count() > 0)
                    {
                        var pLeft = Convert.ToInt32((imgBox.Width - frame.Width) / 2.0) - imgBox.Location.X - 2;
                        var pTop = Convert.ToInt32((imgBox.Height - frame.Height) / 2.0) - imgBox.Location.Y - 28;

                        int _selectionPathPointIndex = 0;
                        foreach (var pathPoint in _selectionPath)
                        {
                            if (_selectionPath.Count() - 1 > _selectionPathPointIndex)
                            {
                                var nextPoint = _selectionPath[_selectionPathPointIndex + 1];

                                var pntCurrent = new Point(
                                   Convert.ToInt32(pathPoint.X) - pLeft,
                                   Convert.ToInt32(pathPoint.Y) - pTop);
                                var pntNext = new Point(Convert.ToInt32(nextPoint.X) - pLeft, Convert.ToInt32(nextPoint.Y) - pTop);

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
                                   Convert.ToInt32(pathPoint.X) - pLeft,
                                   Convert.ToInt32(pathPoint.Y) - pTop);
                                var pntNext = new Point(Convert.ToInt32(_hoverPoint.X) - pLeft, Convert.ToInt32(_hoverPoint.Y) - pTop);

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

                    foreach (var region in _regionList)
                    {
                        Mat maskedRegion = Mat.Zeros(gray.Rows, gray.Cols, region.ConvertToHsv ?
                            hsv.Depth : Emgu.CV.CvEnum.DepthType.Cv8U, region.ConvertToHsv ? 3 : 1);

                        var pLeft = Convert.ToInt32((imgBox.Width - frame.Width) / 2.0) - imgBox.Location.X - 2;
                        var pTop = Convert.ToInt32((imgBox.Height - frame.Height) / 2.0) - imgBox.Location.Y - 28;

                        // CROP SELECTED ROI
                        if (region.RegionType == 1)
                        {
                            Mat maskZeros = Mat.Zeros(gray.Rows, gray.Cols, region.ConvertToHsv ?
                                hsv.Depth : Emgu.CV.CvEnum.DepthType.Cv8U, region.ConvertToHsv ? 3 : 1);

                            List<Point> translatedPoints = new List<Point>();
                            for (int i = 0; i < region.Path.Length; i++)
                            {
                                var rPoint = region.Path[i];
                                if (region.OffsetX != 0)
                                    rPoint.X += region.OffsetX;
                                if (region.OffsetY != 0)
                                    rPoint.Y += region.OffsetY;

                                translatedPoints.Add(new Point(rPoint.X - pLeft, rPoint.Y - pTop));
                            }

                            VectorOfVectorOfPoint contour
                                               = new VectorOfVectorOfPoint(new VectorOfPoint(translatedPoints.ToArray()));
                            CvInvoke.DrawContours(maskZeros, contour, 0, new MCvScalar(255), -1);
                            CvInvoke.BitwiseAnd(region.ConvertToHsv ? hsv : gray, maskZeros, maskedRegion);

                            CvInvoke.DrawContours(frame, contour, -1, new MCvScalar(255, 0, 0), 1);
                        }
                        else if (region.RegionType == 2)
                        {
                            Mat maskZeros = Mat.Zeros(gray.Rows, gray.Cols, region.ConvertToHsv ?
                                hsv.Depth : Emgu.CV.CvEnum.DepthType.Cv8U, region.ConvertToHsv ? 3 : 1);

                            List<Point> translatedPoints = new List<Point>();

                            // DRAW A SHAPE THAT CONTAINS ALL POINTS WITH HEIGHT 2 PX TOTAL
                            for (int i = 0; i < region.Path.Length; i++)
                            {
                                var rPoint = region.Path[i];
                                if (region.OffsetX != 0)
                                    rPoint.X += region.OffsetX;
                                if (region.OffsetY != 0)
                                    rPoint.Y += region.OffsetY;

                                translatedPoints.Add(new Point(rPoint.X - pLeft, rPoint.Y - pTop - 1));
                            }

                            for (int i = region.Path.Length - 1; i >= 0; i--)
                            {
                                var rPoint = region.Path[i];
                                translatedPoints.Add(new Point(rPoint.X - pLeft, rPoint.Y - pTop + 1));
                            }

                            VectorOfVectorOfPoint contour
                                               = new VectorOfVectorOfPoint(new VectorOfPoint(translatedPoints.ToArray()));
                            CvInvoke.DrawContours(maskZeros, contour, 0, new MCvScalar(255), -1);
                            CvInvoke.BitwiseAnd(region.ConvertToHsv ? hsv : gray, maskZeros, maskedRegion);

                            CvInvoke.DrawContours(frame, contour, -1, new MCvScalar(255, 0, 0), 1);

                            //this.BeginInvoke((Action)delegate
                            //{
                            //    imgRegion.Image = maskedRegion;
                            //});
                        }

                        // FILTER & THRESHOLDING OPERATIONS
                        if (region.GaussianBlur == true)
                        {
                            CvInvoke.GaussianBlur(maskedRegion, maskedRegion, new Size(region.GaussianSize ?? 3, region.GaussianSize ?? 3),
                                region.GaussianSigma ?? 0, region.GaussianSigma ?? 0, Emgu.CV.CvEnum.BorderType.Default);
                        }
                        if (region.EqualizeHist)
                        {
                            CvInvoke.EqualizeHist(maskedRegion, maskedRegion);
                        }
                        if (region.Laplacian)
                        {
                            CvInvoke.Laplacian(maskedRegion, maskedRegion, region.ConvertToHsv ?
                                hsv.Depth : Emgu.CV.CvEnum.DepthType.Cv8U, region.LaplaceSize);
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
                                List<Point> translatedPoints = new List<Point>();

                                if (region.RegionType == 1)
                                {
                                    foreach (var rPoint in region.Path)
                                    {
                                        translatedPoints.Add(new Point(rPoint.X - pLeft, rPoint.Y - pTop));
                                    }
                                }
                                else if (region.RegionType == 2)
                                {
                                    foreach (var rPoint in region.Path)
                                    {
                                        translatedPoints.Add(new Point(rPoint.X - pLeft, rPoint.Y - pTop - 1));
                                    }
                                    foreach (var rPoint in region.Path)
                                    {
                                        translatedPoints.Add(new Point(rPoint.X - pLeft, rPoint.Y - pTop + 1));
                                    }
                                }

                                VectorOfVectorOfPoint contour
                                               = new VectorOfVectorOfPoint(new VectorOfPoint(translatedPoints.ToArray()));

                                CvInvoke.DrawContours(maskedRegion, contour, -1, new MCvScalar(0), region.AdaptiveBorder);
                            }
                            catch (Exception)
                            {

                            }
                        }

                        if (SelectedRegion != null && SelectedRegion.Id == region.Id)
                        {
                            this.BeginInvoke((Action)delegate
                            {
                                imgMask.Image = maskedRegion;
                            });
                        }

                        // DECISION MAKING OK / NOK
                        if (region.NokThreshold > -1)
                        {
                            List<Point> translatedPoints = new List<Point>();

                            if (region.RegionType == 1)
                            {
                                foreach (var rPoint in region.Path)
                                {
                                    translatedPoints.Add(new Point(rPoint.X - pLeft, rPoint.Y - pTop));
                                }
                            }
                            else if (region.RegionType == 2)
                            {
                                foreach (var rPoint in region.Path)
                                {
                                    translatedPoints.Add(new Point(rPoint.X - pLeft, rPoint.Y - pTop - 1));
                                }
                                foreach (var rPoint in region.Path)
                                {
                                    translatedPoints.Add(new Point(rPoint.X - pLeft, rPoint.Y - pTop + 1));
                                }
                            }

                            if (translatedPoints.Count() > 0)
                            {
                                VectorOfVectorOfPoint contour
                                               = new VectorOfVectorOfPoint(new VectorOfPoint(translatedPoints.ToArray()));

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
                                        CvInvoke.Merge(new VectorOfMat(channelsOfFrame[0], channelsOfFrame[1], redChannel), frame);

                                        //VectorOfVectorOfPoint faultContour
                                        //        = new VectorOfVectorOfPoint(faultPixels);
                                        //CvInvoke.DrawContours(frame, faultContour, -1, new MCvScalar(0, 0, 255), 1);
                                        //faultContour.Dispose();
                                    }
                                }
                                
                            }
                        }
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
                        imgBox.Image = frame;
                        frame.Dispose();
                        cloneFrame.Dispose();
                        gray.Dispose();
                        hsv.Dispose();
                    });
                } 
                catch(Exception ex)
                {

                }

                await Task.Delay(50);
            }
        }

        #region WINFORM EVENTS
        private void cmbCamera_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_cameraSelection)
                return;

            StartCapture();
        }

        private void frmHekaStudio_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopCapture();
        }

        private void tBarExposure_ValueChanged(object sender, EventArgs e)
        {
            if (_activeCapture != null)
            {
                _activeCapture.Set(Emgu.CV.CvEnum.CapProp.Exposure, tBarExposure.Value);
            }
        }

        private void btnShape_Click(object sender, EventArgs e)
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
                string newTitle = Prompt.ShowDialog("Bölge Adı", "Bilgi");
                if (!string.IsNullOrEmpty(newTitle))
                {
                    var region = new HekaRegion
                    {
                        Title = newTitle,
                        RegionType = 1,
                        Path = _selectionPath.ToArray(),
                    };

                    using (EyeBO bObj = new EyeBO())
                    {
                        var bResult = bObj.SaveRegion(new Data.Region
                        {
                            Enabled = true,
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

                _selectionPath.Clear();
                CheckUndoEnabled();
            }
        }

        private void btnLine_Click(object sender, EventArgs e)
        {
            _selectionRunning = !_selectionRunning;
            if (_selectionRunning)
            {
                _selectionPath.Clear();
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
                        Path = _selectionPath.ToArray(),
                    };

                    using (EyeBO bObj = new EyeBO())
                    {
                        var bResult = bObj.SaveRegion(new Data.Region
                        {
                            Enabled = true,
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

                _selectionPath.Clear();
                CheckUndoEnabled();
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (_selectionPath.Any())
            {
                _hoverPoint = Point.Empty;
                _selectionPath.RemoveAt(_selectionPath.Count() - 1);

                CheckUndoEnabled();
            }
        }
        #endregion

        #region CAPTURE BOX MOUSE EVENTS
        private void imgBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (_selectionRunning)
            {
                if (!_selectionStepRunning)
                {
                    _selectionStepRunning = true;

                    if (_selectionPath.Count() == 0)
                        _selectionPath.Add(imgBox.PointToClient(new Point(e.X, e.Y)));
                    else
                    {
                        var pntDown = imgBox.PointToClient(new Point(e.X, e.Y));
                        if (_hoverPoint == Point.Empty || _hoverPoint.X != _hoverPoint.X || _hoverPoint.Y != _hoverPoint.Y)
                            _hoverPoint = pntDown;
                    }

                    CheckUndoEnabled();
                }
            }
        }

        private void imgBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (_selectionRunning && _selectionStepRunning)
            {
                _hoverPoint = imgBox.PointToClient(new Point(e.X, e.Y));
            }
        }

        private void imgBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (_selectionRunning && _selectionStepRunning)
            {
                _selectionStepRunning = false;

                if (_hoverPoint != Point.Empty)
                    _selectionPath.Add(_hoverPoint);

                // CLOSE SHAPE
                if (_selectionType == 1 && _selectionPath.Count() > 0)
                {
                    var startPoint = _selectionPath[0];
                    _selectionPath.Add(new Point(startPoint.X, startPoint.Y));
                }

                _hoverPoint = Point.Empty;

                CheckUndoEnabled();
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
                        CameraName = cmbCamera.Text,
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
                            UpdateRegionList();
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
                            Enabled = tagData.Enabled,
                        }, tagData);
                        if (!bResult.Result)
                            MessageBox.Show(bResult.ErrorMessage, "Hata");
                        else
                        {
                            UpdateRegionList();
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
                        tagData.CameraName = cmbCamera.Text;

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
                else if (prpGrid.SelectedObject != null)
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
    }
}
