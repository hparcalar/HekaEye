using Emgu.CV;
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
using System.IO;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace HekaEye
{
    public partial class frmEyeStudio : Form
    {
        public frmEyeStudio()
        {
            InitializeComponent();
        }

        DbHelper _db = new DbHelper();
        DeviceHelper _deviceHelper = new DeviceHelper();
        CameraModel[] _cameraList = new CameraModel[0];
        List<RoiModel> _selectionList = new List<RoiModel>();
        
        VideoCapture _activeCapture = null;
        Task _tCapture = null;

        bool _cameraSelection = false;
        bool _captureRunning = false;
        Point rectSelectionPoint = Point.Empty;
        Point lineEndSelectionPoint = Point.Empty;
        Rectangle rectSelection = Rectangle.Empty;

        RoiModel _selectedRoiModel = null;

        public RoiModel SelectedRoiModel {
            get
            {
                return _selectedRoiModel;
            }
            set
            {
                _selectedRoiModel = value;
                BindSelectedRoiModel();
            } 
        }

        private void BindSelectedRoiModel()
        {
            prpGrid.SelectedObject = SelectedRoiModel;
        }

        private void frmLiveTest_Load(object sender, EventArgs e)
        {
            _cameraList = _deviceHelper.GetCameras();

            cmbCamera.DataSource = _cameraList;
            _cameraSelection = true;
            UpdateSelectionListPanel();
        }

        private void UpdateSelectionListPanel()
        {
            flPanelSelections.Controls.Clear();

            foreach (var item in _selectionList)
            {
                Button btn = new Button();
                btn.Tag = item;
                btn.Text = item.Title;
                btn.Width = flPanelSelections.Width;
                btn.Click += Btn_Click;

                flPanelSelections.Controls.Add(btn);
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            SelectedRoiModel = ((RoiModel)(sender as Control).Tag);

            foreach (Control item in flPanelSelections.Controls)
            {
                if (item.Tag != SelectedRoiModel)
                    item.BackColor = Color.Gray;
                else
                    item.BackColor = Color.Green;
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
                    CvInvoke.CvtColor(cloneFrame, gray, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);

                    // DRAW ACTIVE NEW SELECTION RECTANGLE ON FRAME
                    if (rectSelection != Rectangle.Empty)
                    {
                        var pLeft = Convert.ToInt32((imgBox.Width - frame.Width) / 2.0) - 10;
                        var pTop = Convert.ToInt32((imgBox.Height - frame.Height) / 2.0) - 70;

                        Rectangle rectFrame = new Rectangle(rectSelection.X - pLeft, rectSelection.Y - pTop,
                            rectSelection.Width,
                            rectSelection.Height);

                        CvInvoke.Rectangle(frame, rectFrame, new MCvScalar(255, 0, 0));
                    }
                    
                    if (lineEndSelectionPoint != Point.Empty)
                    {
                        var pLeft = Convert.ToInt32((imgBox.Width - frame.Width) / 2.0) - 10;
                        var pTop = Convert.ToInt32((imgBox.Height - frame.Height) / 2.0) - 70;

                        CvInvoke.Line(frame, new Point(
                            Convert.ToInt32(rectSelectionPoint.X) - pLeft, 
                            Convert.ToInt32(rectSelectionPoint.Y) - pTop), 
                                new Point(Convert.ToInt32(lineEndSelectionPoint.X) - pLeft, Convert.ToInt32(lineEndSelectionPoint.Y) - pTop), 
                                new MCvScalar(0, 0, 255), 1, Emgu.CV.CvEnum.LineType.EightConnected);
                    }

                    // DRAW ALL SAVED SELECTION RECTANGLE ON FRAME
                    foreach (var selection in _selectionList)
                    {
                        if (selection.SelectionType == 1)
                        {
                            var pLeft = Convert.ToInt32((imgBox.Width - frame.Width) / 2.0) - 10;
                            var pTop = Convert.ToInt32((imgBox.Height - frame.Height) / 2.0) - 70;

                            Rectangle rectFrame = new Rectangle(Convert.ToInt32(selection.X) - pLeft, Convert.ToInt32(selection.Y) - pTop,
                                Convert.ToInt32(selection.Width),
                                Convert.ToInt32(selection.Height));

                            CvInvoke.Rectangle(frame, rectFrame, new MCvScalar(255, 0, 0));
                            CvInvoke.PutText(frame, selection.Title, new Point(Convert.ToInt32(selection.X) - pLeft, Convert.ToInt32(selection.Y) - pTop - 15),
                                Emgu.CV.CvEnum.FontFace.HersheyComplex,
                                0.5, new MCvScalar(255, 0, 0));

                            // SELECTION IN-PROCESS
                            var croppedZone = new Mat(selection.ConvertToGray ? gray : cloneFrame, rectFrame);
                            if (selection.EqualizeHist)
                                CvInvoke.EqualizeHist(croppedZone, croppedZone);

                            if (selection.MedianBlur)
                            {
                                CvInvoke.MedianBlur(croppedZone, croppedZone, selection.MedianSize);
                            }


                            if (selection.Laplacian)
                            {
                                CvInvoke.Laplacian(croppedZone, croppedZone, Emgu.CV.CvEnum.DepthType.Cv8U, selection.LaplaceSize);
                            }


                            if (selection.ConvertToGray &&
                                (selection.GrayThresholdStart > 0 || selection.GrayThresholdEnd > 0))
                            {
                                CvInvoke.InRange(croppedZone, new ScalarArray(new MCvScalar(selection.GrayThresholdStart)),
                                     new ScalarArray(new MCvScalar(selection.GrayThresholdEnd)), croppedZone);
                            }

                            if (!(selection.GrayThresholdStart > 0 || selection.GrayThresholdEnd > 0)
                                && selection.AdaptiveThreshold && selection.ConvertToGray)
                            {
                                CvInvoke.AdaptiveThreshold(croppedZone, croppedZone, 255, Emgu.CV.CvEnum.AdaptiveThresholdType.GaussianC,
                                    Emgu.CV.CvEnum.ThresholdType.Binary, selection.AdaptiveBlockSize, selection.AdaptiveParam);
                            }

                            Mat croppedZoneBgr = selection.ConvertToGray ?
                                new Mat(croppedZone.Rows, croppedZone.Cols, Emgu.CV.CvEnum.DepthType.Cv8U, 3) : croppedZone;

                            if (selection.ConvertToGray)
                                CvInvoke.CvtColor(croppedZone, croppedZoneBgr, Emgu.CV.CvEnum.ColorConversion.Gray2Bgr);

                            if (selection.ConvertToGray && selection.FindBiggestShape)
                            {
                                Emgu.CV.Util.VectorOfVectorOfPoint contours = new Emgu.CV.Util.VectorOfVectorOfPoint();
                                Mat hier = new Mat();

                                CvInvoke.FindContours(croppedZone, contours, hier,
                                    Emgu.CV.CvEnum.RetrType.Ccomp, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxNone);
                                if (contours.Length > 0)
                                {
                                    VectorOfPoint maxApprox = null;
                                    for (int i = 0; i < contours.Length; i++)
                                    {
                                        try
                                        {
                                            var cnt = contours[i];
                                            var perimeter = CvInvoke.ArcLength(cnt, true);
                                            var epsilon = selection.ApproxEpsilon * perimeter;
                                            VectorOfPoint approx = new VectorOfPoint();
                                            CvInvoke.ApproxPolyDP(cnt, approx, epsilon, true);
                                            if (approx != null && approx.Length > 0)
                                            {
                                                var approxArea = CvInvoke.ContourArea(approx);
                                                if ((croppedZone.Width * croppedZone.Height * 0.95) > approxArea)
                                                    if (maxApprox == null || CvInvoke.ContourArea(maxApprox) < approxArea)
                                                        maxApprox = approx;
                                            }
                                        }
                                        catch (Exception)
                                        {

                                        }
                                    }

                                    if (maxApprox != null)
                                    {
                                        try
                                        {
                                            Emgu.CV.Util.VectorOfVectorOfPoint biggestContour
                                                = new Emgu.CV.Util.VectorOfVectorOfPoint(new VectorOfPoint[] { maxApprox });
                                            CvInvoke.DrawContours(croppedZoneBgr, biggestContour, 0, new MCvScalar(0, 255, 0), 2);
                                        }
                                        catch (Exception)
                                        {

                                        }
                                    }

                                    //int maxContour = GetMaxAreaContourId(contours, Convert.ToInt32((croppedZone.Width) * (croppedZone.Height) * 0.7));

                                    //if (maxContour > -1)
                                    //{
                                    //    Emgu.CV.Util.VectorOfVectorOfPoint biggestContour 
                                    //        = new Emgu.CV.Util.VectorOfVectorOfPoint(new VectorOfPoint[] { contours[maxContour] });
                                    //    CvInvoke.DrawContours(croppedZoneBgr, biggestContour, 0, new MCvScalar(0, 255, 0), 2);
                                    //}
                                }
                            }

                            // SHOW FAULTS
                            if (croppedZone != null && selection.ShowFaults)
                            {
                                Emgu.CV.Util.VectorOfVectorOfPoint contours = new Emgu.CV.Util.VectorOfVectorOfPoint();
                                Mat hier = new Mat();

                                CvInvoke.FindContours(croppedZone, contours, hier,
                                    Emgu.CV.CvEnum.RetrType.Ccomp, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxNone);
                                if (contours.Length > 0)
                                {
                                    for (int i = 0; i < contours.Length; i++)
                                    {
                                        try
                                        {
                                            var cnt = contours[i];
                                            var perimeter = CvInvoke.ArcLength(cnt, true);
                                            var epsilon = selection.ApproxEpsilon * perimeter;
                                            VectorOfPoint approx = new VectorOfPoint();
                                            CvInvoke.ApproxPolyDP(cnt, approx, epsilon, true);
                                            if (approx != null && approx.Length > 0)
                                            {
                                                Emgu.CV.Util.VectorOfVectorOfPoint biggestContour
                                                    = new Emgu.CV.Util.VectorOfVectorOfPoint(new VectorOfPoint[] { approx });
                                                CvInvoke.DrawContours(croppedZoneBgr, biggestContour, 0, new MCvScalar(0, 0, 255), 2);
                                            }
                                        }
                                        catch (Exception)
                                        {

                                        }
                                    }
                                }
                            }

                            if (selection == SelectedRoiModel)
                            {
                                this.BeginInvoke((Action)delegate
                                {
                                    selectionBox.Image = croppedZoneBgr.ToBitmap();
                                    croppedZone.Dispose();
                                });
                            }
                        }
                        else if (selection.SelectionType == 2)
                        {
                            CvInvoke.Line(frame, new Point(Convert.ToInt32(selection.X), Convert.ToInt32(selection.Y)),
                                new Point(Convert.ToInt32(selection.Width), Convert.ToInt32(selection.Height)),
                                new MCvScalar(0, 0, 255), 1, Emgu.CV.CvEnum.LineType.Filled);
                        }
                    }

                    //if (_liveTestStarted)
                    //{

                    //    int capturedCount = 0;

                    //    Rectangle match = new Rectangle(maxLocations[0], _sample.LoadedImage.Size);
                    //    CvInvoke.Rectangle(frame, match, new MCvScalar(0, 0, 255), 2);
                    //    CvInvoke.PutText(frame, _class.Name, new Point(match.X, match.Y), Emgu.CV.CvEnum.FontFace.HersheyComplex,
                    //        0.8, new MCvScalar(255, 0, 0));
                    //}

                    this.BeginInvoke((Action)delegate
                    {
                        imgBox.Image = frame.ToBitmap();

                        gray.Dispose();
                        frame.Dispose();
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                await Task.Delay(50);
            }
        }

        private int GetMaxAreaContourId(Emgu.CV.Util.VectorOfVectorOfPoint contours, int maxThreshold)
        {
            double maxArea = 0;
            int maxAreaContourId = -1;
            for (int j = 0; j < contours.Length; j++)
            {
                try
                {
                    double newArea = CvInvoke.ContourArea(contours[j]);
                    if (newArea > maxArea && newArea < maxThreshold)
                    {
                        maxArea = newArea;
                        maxAreaContourId = j;
                    }
                }
                catch (Exception)
                {

                }
            }
            return maxAreaContourId;
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLiveTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopCapture();
        }

        private void cmbCamera_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!_cameraSelection)
                return;

            StartCapture();
        }

        private void btnTestStatus_Click(object sender, EventArgs e)
        {
           
        }

        bool _newSelectionActive = false;
        int _selectionType = 1;
        private void btnSelection_Click(object sender, EventArgs e)
        {
            _newSelectionActive = !_newSelectionActive;
            _selectionType = 1;
            if (_newSelectionActive)
            {
                btnSelection.BackColor = Color.Green;
                btnSelection.Text = "Seçimi Kaydet";
            }
            else
            {
                btnSelection.BackColor = Color.Gray;
                btnSelection.Text = "Bölge Seç";

                if (rectSelection != Rectangle.Empty)
                {
                    string newTitle = Prompt.ShowDialog("Bölge Adı", "Bilgi");
                    if (!string.IsNullOrEmpty(newTitle))
                    {
                        var newRoiModel = new RoiModel
                        {
                            Title = newTitle,
                            X = rectSelection.X,
                            Y = rectSelection.Y,
                            Width = rectSelection.Width,
                            Height = rectSelection.Height,
                            SelectionType = 1,
                        };
                        _selectionList.Add(newRoiModel);
                        SelectedRoiModel = newRoiModel;
                        rectSelection = Rectangle.Empty;

                        UpdateSelectionListPanel();
                    }
                }
            }
        }

        private void imgBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (rectSelectionPoint == Point.Empty)
                rectSelectionPoint = imgBox.PointToClient(new Point(e.X, e.Y));
        }

        private void imgBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (rectSelectionPoint != Point.Empty)
            {
                Point pntBR = imgBox.PointToClient(new Point(e.X, e.Y));

                if (_selectionType == 1)
                {
                    int smallestX = rectSelectionPoint.X;
                    if (pntBR.X < rectSelectionPoint.X)
                    {
                        smallestX = pntBR.X;
                    }

                    int smallestY = rectSelectionPoint.Y;
                    if (pntBR.Y < rectSelectionPoint.Y)
                    {
                        smallestY = pntBR.Y;
                    }

                    rectSelection.X = smallestX;
                    rectSelection.Y = smallestY;
                    rectSelection.Width = Math.Abs(pntBR.X - rectSelectionPoint.X);
                    rectSelection.Height = Math.Abs(pntBR.Y - rectSelectionPoint.Y);
                }
                else if (_selectionType == 2)
                {
                    lineEndSelectionPoint = pntBR;
                }
               
            }
        }

        private void imgBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (_selectionType == 1)
                rectSelectionPoint = Point.Empty;
        }

        private void tBarExposure_ValueChanged(object sender, EventArgs e)
        {
            if (_activeCapture != null)
            {
                _activeCapture.Set(Emgu.CV.CvEnum.CapProp.Exposure, tBarExposure.Value);
            }
        }

        private void btnDrawLine_Click(object sender, EventArgs e)
        {
            _selectionType = 2;
            _newSelectionActive = !_newSelectionActive;

            if (_newSelectionActive)
            {
                btnDrawLine.BackColor = Color.Green;
                btnDrawLine.Text = "Çizgiyi Kaydet";
            }
            else
            {
                btnDrawLine.BackColor = Color.Gray;
                btnDrawLine.Text = "Çizgi Çiz";

                if (lineEndSelectionPoint != Point.Empty)
                {
                    string newTitle = Prompt.ShowDialog("Bölge Adı", "Bilgi");
                    if (!string.IsNullOrEmpty(newTitle))
                    {
                        var newRoiModel = new RoiModel
                        {
                            Title = newTitle,
                            X = rectSelectionPoint.X,
                            Y = rectSelectionPoint.Y,
                            Width = lineEndSelectionPoint.X,
                            Height = lineEndSelectionPoint.Y,
                            SelectionType = 2,
                        };
                        _selectionList.Add(newRoiModel);
                        SelectedRoiModel = newRoiModel;
                        rectSelection = Rectangle.Empty;
                        lineEndSelectionPoint = Point.Empty;

                        UpdateSelectionListPanel();
                    }
                }
            }
        }
    }
} 
