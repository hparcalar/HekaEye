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
    public partial class frmHekaTest : Form
    {
        DeviceHelper _deviceHelper = new DeviceHelper();
        CameraModel[] _cameraList = new CameraModel[0];

        VideoCapture _activeCapture = null;
        Task _tCapture = null;

        int _printSerialNo = 1;
        int _okCount = 0;
        int _nokCount = 0;
        int _testTotalFrame = 0;
        int _testNokFrame = 0;

        bool _cameraSelection = false;
        bool _captureRunning = false;
        bool _testRunning = false;
        bool _testIsOk = false;

        List<Point> _selectionPath = new List<Point>();

        MCvScalar _regionSelectionColor = new MCvScalar(255, 0, 0);
        MCvScalar _lineSelectionColor = new MCvScalar(155, 155, 0);

        List<HekaRegion> _regionList = new List<HekaRegion>();

        public frmHekaTest()
        {
            InitializeComponent();
        }

        private void frmHekaStudio_Load(object sender, EventArgs e)
        {
            _cameraList = _deviceHelper.GetCameras();

            cmbCamera.DataSource = _cameraList;
            cmbCamera.SelectedIndex = -1;
            _cameraSelection = true;

            lblErrCount.Text = "0";
            lblOkCount.Text = "0";

            UpdateModelList();
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

                if (_selectedRecipe != null)
                {
                    if (!string.IsNullOrEmpty(_selectedRecipe.CameraName))
                        cmbCamera.Text = _selectedRecipe.CameraName;

                    if (_selectedRecipe.Exposure != null)
                    {
                        if (_activeCapture != null)
                        {
                            _activeCapture.Set(Emgu.CV.CvEnum.CapProp.Exposure, _selectedRecipe.Exposure.Value);
                        }
                    }
                }

                UpdateRegionList();
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
                if (_selectedModel != null)
                {
                    using (EyeBO bObj = new EyeBO())
                    {
                        SelectedRecipe = bObj.GetRecipeList().FirstOrDefault(d => d.Id == _selectedModel.RecipeId);
                    }
                }
                else
                    SelectedRecipe = null;
            }
        }
        private void UpdateRegionList()
        {
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
            }
        }

        private void UpdateModelList()
        {
            using (EyeBO bObj = new EyeBO())
            {
                var modelList = bObj.GetProductList().ToArray();
                cmbModels.Items.AddRange(modelList);

                SelectedModel = null;
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

                _captureRunning = true;
                _tCapture = Task.Run(LoopCapture);
            }
            catch (Exception)
            {

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

                    var gray = new Mat(frame.Rows, frame.Cols, Emgu.CV.CvEnum.DepthType.Cv8U, 1);
                    var hsv = new Mat(frame.Rows, frame.Cols, frame.Depth, 1);
                    CvInvoke.CvtColor(cloneFrame, gray, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);
                    CvInvoke.CvtColor(cloneFrame, hsv, Emgu.CV.CvEnum.ColorConversion.Bgr2Hsv);

                    this.BeginInvoke((Action)delegate
                    {
                        lblStatus.Visible = false;
                    });

                    if (_testRunning)
                    {
                        #region DRAW & CHECK SAVED REGIONS
                        bool isOk = true;

                        foreach (var region in _regionList)
                        {
                            Mat maskedRegion = Mat.Zeros(gray.Rows, gray.Cols, region.ConvertToHsv ?
                                hsv.Depth : Emgu.CV.CvEnum.DepthType.Cv8U, region.ConvertToHsv ? 3 : 1);

                            var pLeft = Convert.ToInt32((imgBox.Width - frame.Width) / 2.0) - imgBox.Location.X - 165;
                            var pTop = Convert.ToInt32((imgBox.Height - frame.Height) / 2.0) - imgBox.Location.Y - 75;

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
                            }

                            // FILTER & THRESHOLDING OPERATIONS
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
                                                new Point(-1, -1), 1, Emgu.CV.CvEnum.BorderType.Constant,
                                                new MCvScalar(255));
                                            dilElm.Dispose();

                                            Mat[] channelsOfFrame = frame.Split();
                                            var redChannel = channelsOfFrame[2];
                                            CvInvoke.BitwiseOr(redChannel, maskedRegion, redChannel);
                                            CvInvoke.BitwiseXor(channelsOfFrame[0], maskedRegion, channelsOfFrame[0]);
                                            CvInvoke.BitwiseXor(channelsOfFrame[1], maskedRegion, channelsOfFrame[1]);
                                            CvInvoke.Merge(new VectorOfMat(channelsOfFrame[0], channelsOfFrame[1], redChannel), frame);

                                            //VectorOfVectorOfPoint faultContour
                                            //       = new VectorOfVectorOfPoint(faultPixels);
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
                            _testTotalFrame++;
                            if (!isOk)
                                _testNokFrame++;

                            if (_testNokFrame / (_testTotalFrame * 1.0) * 100 > 70)
                                isOk = false;

                            _testIsOk = isOk;

                            if (isOk)
                            {
                                lblResult.BackColor = Color.LimeGreen;
                                lblResult.Text = "OK";
                            }
                            else
                            {
                                lblResult.BackColor = Color.Red;
                                lblResult.Text = "NOK";
                            }
                        });
                        #endregion
                    }
                    //else
                    //{
                    //    this.BeginInvoke((Action)delegate
                    //    {
                    //        lblResult.BackColor = Color.WhiteSmoke;
                    //        lblResult.Text = "Test Bekleniyor";
                    //    });
                    //}

                    this.BeginInvoke((Action)delegate
                    {
                        imgBox.Image = frame;
                        frame.Dispose();
                        cloneFrame.Dispose();
                        gray.Dispose();
                        hsv.Dispose();
                    });
                } 
                catch(Exception)
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
        #endregion

        private void cmbModels_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbModels.SelectedIndex > -1)
            {
                Product model = cmbModels.SelectedItem as Product;
                if (model != null)
                {
                    SelectedModel = model;
                }
            }
            else
                SelectedModel = null;
        }

        int _testSeconds = 0;
        Timer _tmrTest;
        private void btnTestStart_Click(object sender, EventArgs e)
        {
            if (!_testRunning)
            {
                if (SelectedModel == null)
                {
                    MessageBox.Show("Testi başlatmak için model seçmelisiniz.","Uyarı");
                    return;
                }

                _testTotalFrame = 0;
                _testNokFrame = 0;
            }

            _testRunning = !_testRunning;

            if (_testRunning)
            {
                _tmrTest = new Timer();
                _tmrTest.Interval = 1000;
                _tmrTest.Tick += _tmrTest_Tick;
                _tmrTest.Start();

                btnTestStart.Text = "Testi Bitir";
                btnTestStart.BackColor = Color.WhiteSmoke;
                btnTestStart.ForeColor = Color.Black;
            }
            else
            {
                btnTestStart.Text = "Testi Başlat";
                btnTestStart.BackColor = Color.DodgerBlue;
                btnTestStart.ForeColor = Color.White;
            }
        }

        private void _tmrTest_Tick(object sender, EventArgs e)
        {
            _testSeconds++;
            if (_testSeconds >= 3)
            {
                _tmrTest.Stop();
                _tmrTest.Dispose();

                _testRunning = false;
                btnTestStart.Text = "Testi Başlat";
                btnTestStart.BackColor = Color.DodgerBlue;
                btnTestStart.ForeColor = Color.White;

                if (_testIsOk)
                {
                    PrinterBO bObj = new PrinterBO();
                    bObj.PrintLabel(new ProductLabel
                    {
                        ProductCode = SelectedModel.ProductCode,
                    }, _printSerialNo);
                    _printSerialNo++;

                    _okCount++;
                }
                else
                    _nokCount++;

                btnTestStart.Enabled = true;
                _testSeconds = 0;

                lblOkCount.Text = _okCount.ToString();
                lblErrCount.Text = _nokCount.ToString();
            }
            else
            {
                btnTestStart.Enabled = false;
                btnTestStart.Text = (3 - _testSeconds).ToString();
            }
        }
    }
}
