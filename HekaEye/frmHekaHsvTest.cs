using ComponentFactory.Krypton.Toolkit;
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
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HekaEye
{
    public partial class frmHekaHsvTest : Form
    {
        DeviceHelper _deviceHelper = new DeviceHelper();
        CameraModel[] _cameraList = new CameraModel[0];

        int _printSerialNo = 1;
        int _okCount = 0;
        int _nokCount = 0;
        int _testTotalFrame = 0;
        int _testNokFrame = 0;

        bool _cameraSelection = false;
        bool _captureRunning = false;
        bool _statsUpdateRunning = false;
        bool _testRunning = false;
        bool _testIsOk = false;

        // COMBINED SWITCH FLAGS
        string mainModelNo = "";
        bool returnToMainModel = false;

        List<Point> _selectionPath = new List<Point>();

        MCvScalar _regionSelectionColor = new MCvScalar(255, 0, 0);
        MCvScalar _lineSelectionColor = new MCvScalar(155, 155, 0);

        List<HekaCaptureModel> _captureList = new List<HekaCaptureModel>();
        List<ExternalTest> _externalTests = new List<ExternalTest>();

        public frmHekaHsvTest()
        {
            InitializeComponent();
        }

        private void frmHekaStudio_Load(object sender, EventArgs e)
        {
            _cameraList = _deviceHelper.GetCameras();
            _cameraSelection = true;

            lblErrCount.Text = "0";
            //lblOkCount.Text = "0";

            //UpdateModelList();
            //UpdateExternalTests();

            using (EyeBO bObj = new EyeBO())
            {
                SelectedRecipe = bObj.GetHsvRecipe();
            }
            UpdateCameraList();
            StartTest();

            Task.Run(LoopUpdateStats);
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

                //if (_selectedRecipe != null)
                //{
                //    if (!string.IsNullOrEmpty(_selectedRecipe.CameraName))
                //        cmbCamera.Text = _selectedRecipe.CameraName;

                //    if (_selectedRecipe.Exposure != null)
                //    {
                //        if (_activeCapture != null)
                //        {
                //            _activeCapture.Set(Emgu.CV.CvEnum.CapProp.Exposure, _selectedRecipe.Exposure.Value);
                //        }
                //    }
                //}

                UpdateRegionList();
            }
        }

        Product _combinedModel = null;
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

                UpdateCameraList();
            }
        }

        private void UpdateExternalTests()
        {
            //using (EyeBO bObj = new EyeBO())
            //{
            //    _externalTests = bObj.GetExternalTests().ToList();
            //}

            //flPanelExternalTests.Controls.Clear();
            //foreach (var item in _externalTests)
            //{
            //    KryptonCheckBox chkTest = new KryptonCheckBox();
            //    chkTest.Checked = false;
            //    chkTest.Text = item.TestName;
            //    chkTest.PaletteMode = PaletteMode.ProfessionalSystem;
            //    chkTest.StateCommon.ShortText.Font = new Font("Tahoma", 14, FontStyle.Bold);
            //    flPanelExternalTests.Controls.Add(chkTest);
            //}
        }
        bool _updatingCameras = false;
        private void UpdateCameraList()
        {
            if (_updatingCameras)
                return;

            _updatingCameras = true;

            //flPanelCams.Controls.Clear();
            //_captureList.Clear();

            if (SelectedRecipe != null)
            {
                using (EyeBO bObj = new EyeBO())
                {
                    var modelList = bObj.GetCameraList(SelectedRecipe.Id);

                    if (modelList.Length == 0)
                        _updatingCameras = false;

                    foreach (var item in modelList)
                    {
                        // ADD IMAGEBOX TO FRAME CONTAINER
                        if (!_captureList.Any(d => d.CameraName == item.CameraName))
                        {
                            Emgu.CV.UI.ImageBox cvBox = new Emgu.CV.UI.ImageBox();
                            cvBox.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
                            cvBox.SizeMode = PictureBoxSizeMode.Zoom;
                            cvBox.Size = new Size(536, flPanelCams.Height - 5);
                            cvBox.BorderStyle = BorderStyle.FixedSingle;
                            flPanelCams.Controls.Add(cvBox);

                            var captureModel = new HekaCaptureModel
                            {
                                CameraName = item.CameraName,
                                CaptureRunning = true,
                                ImageBox = cvBox,
                                AutoExposure = item.AutoExposure ?? false,
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
                        else
                        {
                            var captureModel = _captureList.FirstOrDefault(d => d.CameraName == item.CameraName);
                            if (captureModel != null)
                            {
                                List<HekaRegion> detailedRegions = new List<HekaRegion>();
                                var newRegions = bObj.GetRegionList(SelectedRecipe.Id, item.Id);
                                foreach (var region in newRegions)
                                {
                                    var dbRegion = bObj.GetRegion(region.Id);
                                    if (dbRegion != null)
                                    {
                                        detailedRegions.Add(dbRegion);
                                    }
                                }

                                captureModel.RegionList = detailedRegions;
                            }
                        }
                    }

                    if (_captureList.Any(d => d.Capture == null))
                    {
                        StopCapture();
                        StartCapture();
                    }
                }
            }
            else
                _updatingCameras = false;
        }
        private void UpdateRegionList()
        {
            if (SelectedRecipe != null)
            {
                //using (EyeBO bObj = new EyeBO())
                //{
                //    var allRegions = bObj.GetRegionList(SelectedRecipe.Id)
                //        .Select(d => new HekaRegion { 
                //            Id = d.Id,
                //            Title = d.Title,
                //        }).ToList();

                //    List<HekaRegion> hekaRegions = new List<HekaRegion>();

                //    foreach (var item in allRegions)
                //    {
                //        var dbRegion = bObj.GetRegion(item.Id);
                //        if (dbRegion != null)
                //        {
                //            hekaRegions.Add(dbRegion);
                //        }
                //    }

                //    _regionList = hekaRegions.ToList();
                //}
            }
        }

        private void UpdateModelList()
        {
            //using (EyeBO bObj = new EyeBO())
            //{
            //    var modelList = bObj.GetMainProductList().ToArray();
            //    cmbModels.Items.AddRange(modelList);

            //    SelectedModel = null;
            //}
        }

        private void StopCapture()
        {
            foreach (var capture in _captureList)
            {
                try
                {
                    capture.CaptureRunning = false;

                    if (capture.Capture != null)
                        capture.Capture.Stop();

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
            //lblStatus.Visible = true;

            foreach (var capture in _captureList)
            {
                try
                {
                    CameraModel capCam = _cameraList.FirstOrDefault(m => string.Equals(m.DevicePath, capture.CameraName));
                    if (capCam != null)
                    {
                        capture.Capture = new VideoCapture(capCam.DeviceIndex);
                        if (capture.Capture != null)
                        {
                            capture.Exposure = Convert.ToInt32(capture.Capture.Get(Emgu.CV.CvEnum.CapProp.Exposure));
                            if (capture.AutoExposure)
                            {
                                capture.Capture.Set(Emgu.CV.CvEnum.CapProp.AutoExposure, 3);
                            }
                            else
                            {
                                capture.Capture.Set(Emgu.CV.CvEnum.CapProp.AutoExposure, 1);
                                capture.Capture.Set(Emgu.CV.CvEnum.CapProp.Exposure, capture.Exposure ?? 0);
                            }
                        }
                        
                        capture.CaptureRunning = true;
                        capture.CaptureTask = Task.Run(() => LoopCapture(capture.CameraName));
                    }
                }
                catch (Exception)
                {

                }
            }

            _updatingCameras = false;
        }

        private async Task LoopUpdateStats()
        {
            while (_statsUpdateRunning)
            {
                try
                {
                    using (EyeBO bObj = new EyeBO())
                    {
                        var oldStats = bObj.MatchOnlyStats();

                        this.BeginInvoke((Action)delegate
                        {
                            gridStats.DataSource = oldStats;
                            gridStats.Invalidate();
                        });
                    }
                }
                catch (Exception)
                {

                }

                await Task.Delay(1000 * 60 * 10);
            }
        }
        private async Task LoopCapture(string cameraName)
        {
            while (true)
            {
                var data = _captureList.FirstOrDefault(d => d.CameraName == cameraName);
                if (data != null && data.CaptureRunning && data.Capture != null)
                {
                    try
                    {
                        var frame = data.Capture.QueryFrame();
                        if (frame == null)
                            continue;
                        //var cloneFrame = frame.Clone();

                        var gray = new Mat(frame.Rows, frame.Cols, Emgu.CV.CvEnum.DepthType.Cv32F, 1);
                        var hsv = new Image<Hsv, Byte>(frame.Rows, frame.Cols);
                        CvInvoke.CvtColor(frame, gray, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);
                        CvInvoke.CvtColor(frame, hsv, Emgu.CV.CvEnum.ColorConversion.Bgr2Hsv);

                        //this.BeginInvoke((Action)delegate
                        //{
                        //    lblStatus.Visible = false;
                        //});

                        if (_testRunning)
                        {
                            #region DRAW & CHECK SAVED REGIONS
                            bool isOk = true;

                            foreach (var region in data.RegionList)
                            {
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
                                    Mat maskZeros = Mat.Zeros(gray.Rows, gray.Cols, Emgu.CV.CvEnum.DepthType.Cv8U, region.ConvertToHsv ? 3 : 1);

                                    List<Point> translatedPointsI = new List<Point>();

                                    // DRAW A SHAPE THAT CONTAINS ALL POINTS WITH HEIGHT 2 PX TOTAL
                                    for (int i = 0; i < region.Path.Length; i++)
                                    {
                                        var rPoint = region.Path[i];
                                        if (region.OffsetX != 0)
                                            rPoint.X += region.OffsetX;
                                        if (region.OffsetY != 0)
                                            rPoint.Y += region.OffsetY;

                                        translatedPointsI.Add(new Point(Convert.ToInt32(rPoint.X * pLeft), Convert.ToInt32(Convert.ToInt32(rPoint.Y - pTop - 1) * hRate)));
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

                                                    this.BeginInvoke((Action)delegate
                                                    {
                                                        lblHsv.Text = string.Format("{0:000.00}", hue) + " | "
                                                            + string.Format("{0:000.00}", sat) + " | "
                                                            + string.Format("{0:000.00}", val);
                                                    });
                                                }
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
                                if (region != null && region.ApplyCanny)
                                {
                                    var tmpMaskedRegion = maskedRegion.Clone();
                                    var cannyRegion = maskedRegion.Clone();
                                    //CvInvoke.AddWeighted(cannyRegion, 100, cannyRegion, 0, 0, cannyRegion);
                                    //CvInvoke.ConvertScaleAbs(cannyRegion, cannyRegion, 1, 0);
                                    //CvInvoke.EqualizeHist(maskedRegion, maskedRegion);
                                    //CvInvoke.BilateralFilter(cannyRegion, tmpMaskedRegion, -1,
                                    //        14, 14);
                                    //CvInvoke.AdaptiveThreshold(tmpMaskedRegion, tmpMaskedRegion, 255,
                                    //    Emgu.CV.CvEnum.AdaptiveThresholdType.MeanC,
                                    //    Emgu.CV.CvEnum.ThresholdType.BinaryInv, 3, 5);
                                    //CvInvoke.ConvertScaleAbs(maskedRegion, maskedRegion, 1, 0);
                                    //CvInvoke.AddWeighted(maskedRegion, 1.5, maskedRegion, 0, 0, maskedRegion);
                                    //CvInvoke.InRange(maskedRegion,
                                    //    new ScalarArray(new Emgu.CV.Structure.MCvScalar(1)),
                                    //    new ScalarArray(new Emgu.CV.Structure.MCvScalar(140)),
                                    //    cannyRegion);

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

                                    //CvInvoke.DrawContours(frame, contours, -1, new MCvScalar(0, 255, 0), 1);

                                    VectorOfPoint maxApprox = null;
                                    var selectedArea = CvInvoke.ContourArea(vectorOfSelection);

                                    for (int i = 0; i < contours.Length; i++)
                                    {
                                        try
                                        {
                                            var approxArea = CvInvoke.ContourArea(contours[i]);
                                            if ((selectedArea * 0.92) > approxArea && approxArea >= (selectedArea * region.MinShapeArea))
                                                if (maxApprox == null || CvInvoke.ContourArea(maxApprox) < approxArea)
                                                    maxApprox = contours[i];

                                            //var cnt = contours[i];
                                            //var perimeter = CvInvoke.ArcLength(cnt, true);
                                            //var epsilon = region.CannyEpsilon * perimeter;
                                            //VectorOfPoint approx = new VectorOfPoint();
                                            //CvInvoke.ApproxPolyDP(cnt, approx, epsilon, true);
                                            //if (approx != null && approx.Length > 0)
                                            //{
                                            //    var approxArea = CvInvoke.ContourArea(approx);
                                            //    if ((selectedArea * 0.92) > approxArea && approxArea >= (selectedArea * region.MinShapeArea))
                                            //        if (maxApprox == null || CvInvoke.ContourArea(maxApprox) < approxArea)
                                            //            maxApprox = approx;
                                            //}
                                        }
                                        catch (Exception)
                                        {

                                        }
                                    }

                                    if (maxApprox != null)
                                    {
                                        Mat maskZeros = Mat.Zeros(gray.Rows, gray.Cols, Emgu.CV.CvEnum.DepthType.Cv8U, 1);

                                        VectorOfVectorOfPoint contourBiggest
                                                       = new VectorOfVectorOfPoint(maxApprox);
                                        CvInvoke.DrawContours(maskZeros, contourBiggest, 0, new MCvScalar(255), -1);
                                        CvInvoke.BitwiseAnd(maskedRegion, maskZeros, maskedRegion);

                                        CvInvoke.DrawContours(frame, contourBiggest, -1, new MCvScalar(0, 255, 0), 1);
                                    }

                                    tmpMaskedRegion.Dispose();
                                    cannyRegion.Dispose();
                                    vectorOfSelection.Dispose();
                                    selectedContours.Dispose();
                                }
                                if (region.GaussianBlur == true)
                                {
                                    CvInvoke.GaussianBlur(maskedRegion, maskedRegion, new Size(region.GaussianSize ?? 3, region.GaussianSize ?? 3),
                                        region.GaussianSigma ?? 0, region.GaussianSigma ?? 0, Emgu.CV.CvEnum.BorderType.Default);
                                }
                                if (region.BilateralFilter == true)
                                {
                                    try
                                    {
                                        var targetBilateral = maskedRegion.Clone();
                                        CvInvoke.BilateralFilter(maskedRegion, targetBilateral, region.BilateralD ?? 0,
                                            region.BilateralSigmaColor ?? 0, region.BilateralSigmaSpace ?? 0);

                                        maskedRegion = targetBilateral;
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }
                                if (region != null)
                                {
                                    var dilElm = CvInvoke.GetStructuringElement(Emgu.CV.CvEnum.ElementShape.Rectangle, new Size(3, 3), new Point(-1, -1));
                                    CvInvoke.Erode(maskedRegion, maskedRegion, dilElm,
                                        new Point(-1, -1), 1, Emgu.CV.CvEnum.BorderType.Default,
                                        new MCvScalar(255));
                                    CvInvoke.Dilate(maskedRegion, maskedRegion, dilElm,
                                        new Point(-1, -1), 1, Emgu.CV.CvEnum.BorderType.Default,
                                        new MCvScalar(255));
                                    dilElm.Dispose();
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
                                    Mat sobelRegion = Mat.Zeros(gray.Rows, gray.Cols, Emgu.CV.CvEnum.DepthType.Cv32F, region.ConvertToHsv ? 3 : 1);

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

                                // DECISION MAKING OK / NOK
                                if (region.NokThreshold > -1)
                                {
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

                                maskedRegion.Dispose();
                            }

                            // SHOW RESULT COLOR
                            this.BeginInvoke((Action)delegate
                            {
                                _testTotalFrame++;
                                if (!isOk)
                                    _testNokFrame++;

                                if (_testNokFrame / (_testTotalFrame * 1.0) * 100 > 60)
                                    isOk = false;

                                data.TestIsOk = isOk;
                                data.ImageBox.BackColor = isOk ? Color.LimeGreen : Color.Red;
                                _testIsOk = !_captureList.Any(d => d.TestIsOk == false);

                                //if (_testIsOk)
                                //{
                                //    lblResult.BackColor = Color.LimeGreen;
                                //    lblResult.Text = "OK";
                                //}
                                //else
                                //{
                                //    lblResult.BackColor = Color.Red;
                                //    lblResult.Text = "NOK";
                                //}
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
                            data.ImageBox.Image = frame; 
                            frame.Dispose();
                            //cloneFrame.Dispose();
                            gray.Dispose();
                        });
                    }
                    catch (Exception ex)
                    {

                    }
                }

                await Task.Delay(50);
            }
        }

        #region WINFORM EVENTS
        private void frmHekaStudio_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopCapture();
        }
        #endregion

        private void cmbModels_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmbModels.SelectedIndex > -1)
            //{
            //    Product model = cmbModels.SelectedItem as Product;
            //    if (model != null)
            //    {
            //        SelectedModel = model;
            //        using (EyeBO bObj = new EyeBO())
            //        {
            //            _combinedModel = bObj.GetCombinedProduct(model.Id);
            //        }

            //        if (_combinedModel != null)
            //            lblCombined.Text = "KOMBİN: " + _combinedModel.ProductCode;

            //        lblCombined.Visible = _combinedModel != null;
            //    }
            //}
            //else
            //    SelectedModel = null;
        }

        int _testSeconds = 0;
        Timer _tmrTest;

        private void StartTest()
        {
            if (!_testRunning)
            {
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
            }
        }

        int _maxTestDuration = 3;
        bool _lastTestResult = false;
        private void _tmrTest_Tick(object sender, EventArgs e)
        {
            _testSeconds++;
            if (_testSeconds >= _maxTestDuration)
            {
                //_tmrTest.Stop();
                //_tmrTest.Dispose();

                //_testRunning = false;
                _testTotalFrame = 0;
                _testNokFrame = 0;
                //btnTestStart.Text = "TESTİ BAŞLAT";

                if (_testIsOk)
                {
                    //PrinterBO bObj = new PrinterBO();
                    //bObj.PrintLabel(new ProductLabel
                    //{
                    //    ProductCode = SelectedModel.ProductCode,
                    //}, _printSerialNo);
                    //_printSerialNo++;

                    _okCount++;
                    _lastTestResult = true;
                }
                else
                {
                    _nokCount++;
                    if (_lastTestResult)
                    {
                        try
                        {
                            using (EyeBO bObj = new EyeBO())
                            {
                                bObj.SaveMatchOnly(false);
                            }
                        }
                        catch (Exception)
                        {

                        }
                    }
                    _lastTestResult = false;
                }

                //btnTestStart.Enabled = true;
                _testSeconds = 0;
                //_tmrTest.Start();

                try
                {
                    using (EyeBO bObj = new EyeBO())
                    {
                        var stats = bObj.MatchOnlyStats(DateTime.Now.Date);
                        if (stats != null && stats.Length > 0)
                        {
                            lblErrCount.Text = stats[0].NokCount.ToString();
                        }
                    }
                }
                catch (Exception)
                {

                }
            }
        }
    }
}
