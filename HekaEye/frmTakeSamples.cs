using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.UI;
using Emgu.CV.Structure;
using System.Drawing;
using System.Windows.Forms;
using HekaEye.Helpers;
using HekaEye.Models;
using System.IO;

namespace HekaEye
{
    public partial class frmTakeSamples : Form
    {
        public frmTakeSamples()
        {
            InitializeComponent();
        }

        DeviceHelper _deviceHelper = new DeviceHelper();
        CameraModel[] _cameraList = new CameraModel[0];
        CaptureClassModel[] _classList = new CaptureClassModel[0];
        ClassSampleModel[] _sampleList = new ClassSampleModel[0];
        bool _captureSelectable = false;
        bool _captureStopped = false;
        bool _sampleSelectable = false;
        bool _captureRunning = false;
        bool _classTestRunning = false;
        VideoCapture _activeCapture = null;
        Task _tCapture = null;
        Mat _activeFrame = null;

        DbHelper _db = new DbHelper();

        Point rectPoint = Point.Empty;
        Rectangle rectActive = Rectangle.Empty;

        private void frmTakeSamples_Load(object sender, EventArgs e)
        {
            _cameraList = _deviceHelper.GetCameras();
            _classList = _db.GetClassList();

            _captureSelectable = false;
            cmbCamera.DataSource = _cameraList;
            cmbCamera.SelectedIndex = -1;
            _captureSelectable = true;

            cmbClassList.DataSource = _classList;
            if (cmbClassList.SelectedIndex > -1)
                PrepareSelectedClass();
        }
        
        private void cmbCamera_SelectedIndexChanged(object sender, EventArgs e)
        {
            StartCapture();
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
                _captureStopped = true;
                _activeCapture.Stop();
                _activeCapture.Dispose();
            }
        }
        private void StartCapture()
        {
            if (cmbCamera.SelectedIndex < 0 || !_captureSelectable)
                return;

            lblStatus.Visible = true;

            try
            {
                CameraModel selectedCamera = _cameraList[cmbCamera.SelectedIndex];

                StopCapture();

                _captureStopped = false;
                _activeCapture = new VideoCapture(selectedCamera.DeviceIndex);

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
                    //if (_captureStopped)
                    //    continue;

                    var frame = _activeCapture.QueryFrame();
                    _activeFrame = frame.Clone();

                    this.BeginInvoke((Action)delegate
                    {
                        lblStatus.Visible = false;
                    });

                    // DRAW ACTIVE RECTANGLE ON FRAME
                    if (_captureStopped == false && rectActive != Rectangle.Empty)
                    {
                        var pLeft = Convert.ToInt32((imgBox.Width - frame.Width) / 2.0) - 10;
                        var pTop = Convert.ToInt32((imgBox.Height - frame.Height) / 2.0) - 96;

                        Rectangle rectFrame = new Rectangle(rectActive.X - pLeft, rectActive.Y - pTop,
                            rectActive.Width,
                            rectActive.Height);

                        CvInvoke.Rectangle(frame, rectFrame, new MCvScalar(255, 0, 0));
                    }

                    // RUN TEST ON CLASS
                    if (_classTestRunning)
                    {
                        var gray = new Mat(_activeFrame.Rows, _activeFrame.Cols, Emgu.CV.CvEnum.DepthType.Cv8U, 1);
                        CvInvoke.CvtColor(_activeFrame, gray, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);
                        var relatedClass = _classList[cmbClassList.SelectedIndex];

                        var _classSamples = _sampleList;
                        foreach (var _sample in _classSamples)
                        {
                            if (_sample.LoadedImage != null)
                            {
                                using (var matchResult = gray.ToImage<Gray, float>().MatchTemplate(_sample.LoadedImage.ToImage<Gray, float>(),
                                    Emgu.CV.CvEnum.TemplateMatchingType.CcoeffNormed))
                                {
                                    double[] minValues, maxValues;
                                    Point[] minLocations, maxLocations;
                                    matchResult.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);

                                    if (maxValues[0] > (trackBarThresh.Value / 100.0))
                                    {
                                        Rectangle match = new Rectangle(maxLocations[0], _sample.LoadedImage.Size);
                                        CvInvoke.Rectangle(frame, match, new MCvScalar(0, 0, 255), 2);
                                        CvInvoke.PutText(frame, relatedClass.Name, new Point(match.X, match.Y),
                                            Emgu.CV.CvEnum.FontFace.HersheyComplex,
                                            0.8, new MCvScalar(255, 0, 0));
                                    }
                                }
                            }
                        }
                    }

                    this.BeginInvoke((Action)delegate
                    {
                        imgBox.Image = frame.ToBitmap();
                    });
                }
                catch (Exception)
                {

                }

                await Task.Delay(50);
            }
        }

        private void imgBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (!_sampleSelectable)
                return;

            if (rectPoint == Point.Empty)
                rectPoint = imgBox.PointToClient(new Point(e.X, e.Y));
        }

        private void imgBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (rectPoint != Point.Empty)
            {
                Point pntBR = imgBox.PointToClient(new Point(e.X, e.Y));

                int smallestX = rectPoint.X;
                if (pntBR.X < rectPoint.X)
                {
                    smallestX = pntBR.X;
                }

                int smallestY = rectPoint.Y;
                if (pntBR.Y < rectPoint.Y)
                {
                    smallestY = pntBR.Y;
                }

                rectActive.X = smallestX;
                rectActive.Y = smallestY;
                rectActive.Width = Math.Abs(pntBR.X - rectPoint.X);
                rectActive.Height = Math.Abs(pntBR.Y - rectPoint.Y);
            }
        }

        private void imgBox_MouseUp(object sender, MouseEventArgs e)
        {
            rectPoint = Point.Empty;
        }

        private void frmTakeSamples_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopCapture();
        }

        private void btnTakeSample_Click(object sender, EventArgs e)
        {
            if (cmbClassList.SelectedIndex < 0)
            {
                MessageBox.Show("Seçimi başlatmak için bir sınıf seçmelisiniz.");
                return;
            }

            _sampleSelectable = !_sampleSelectable;
            if (!_sampleSelectable)
            {
                if (rectActive != Rectangle.Empty)
                {
                    var pLeft = Convert.ToInt32((imgBox.Width - _activeFrame.Width) / 2.0) - 10;
                    var pTop = Convert.ToInt32((imgBox.Height - _activeFrame.Height) / 2.0) - 96;

                    Rectangle rectSelection = new Rectangle(rectActive.X - pLeft, rectActive.Y - pTop,
                        rectActive.Width,
                        rectActive.Height);
                    var croppedZone = new Mat(_activeFrame, rectSelection);
                    var croppedImage = croppedZone.ToBitmap();
                    var croppedFileName = Guid.NewGuid().ToString();
                    croppedImage.Save(System.AppDomain.CurrentDomain.BaseDirectory + "Samples\\" 
                        + croppedFileName + ".png");

                    var relatedClass = _classList[cmbClassList.SelectedIndex];
                    var qResult =
                        _db.ExecuteSql("INSERT INTO ClassSample(ClassId, ImgFileName) VALUES(" + relatedClass.Id + ", '" + croppedFileName + ".png')");
                    if (qResult)
                        MessageBox.Show("Örnek başarıyla kaydedildi.");
                    else
                        MessageBox.Show("Bir hata meydana geldi. Lütfen tekrar deneyiniz.");
                }

                rectPoint = Point.Empty;
                rectActive = Rectangle.Empty;

                btnTakeSample.BackColor = Color.LightBlue;
            }
            else
            {
                btnTakeSample.BackColor = Color.SpringGreen;
            }

            btnTakeSample.Text = _sampleSelectable ? "Seçimi Kaydet" : "Seçimi Başlat";
        }

        private void btnMainMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSamples_Click(object sender, EventArgs e)
        {
            if (cmbClassList.SelectedIndex < 0)
            {
                MessageBox.Show("Örnekleri listelenecek olan sınıfı seçiniz.");
                return;
            }

            var relatedClass = _classList[cmbClassList.SelectedIndex];
            frmSamples frm = new frmSamples();
            frm.ClassId = relatedClass.Id;
            frm.ShowDialog(this);
        }

        private void btnTestStatus_Click(object sender, EventArgs e)
        {
            if (cmbClassList.SelectedIndex < 0)
            {
                MessageBox.Show("Önce bir sınıf seçmelisiniz.");
                return;
            }

            _classTestRunning = !_classTestRunning;
            if (!_classTestRunning)
            {
                if (cmbClassList.SelectedIndex > -1)
                {
                    var relatedClass = _classList[cmbClassList.SelectedIndex];
                    relatedClass.Threshold = trackBarThresh.Value;

                    var qResult =
                        _db.ExecuteSql("UPDATE CaptureClass SET Threshold = " + relatedClass.Threshold + " WHERE Id=" + relatedClass.Id);

                    if (!qResult)
                        MessageBox.Show("HATA: Eşik değeri veritabanına kaydedilemedi.");
                }

                btnTestStatus.Text = "Testi Başlat";
            }
            else
            {
                PrepareSelectedClass();

                btnTestStatus.Text = "Testi Bitir";
            }
        }

        private void PrepareSelectedClass()
        {
            var relatedClass = _classList[cmbClassList.SelectedIndex];
            if (relatedClass.Threshold > 0)
                trackBarThresh.Value = relatedClass.Threshold;
            else
                trackBarThresh.Value = 60;

            string samplePath = System.AppDomain.CurrentDomain.BaseDirectory + "Samples";
            List<ClassSampleModel> tmpSamples = new List<ClassSampleModel>();
            var _classSamples = _db.GetSamples(relatedClass.Id);
            if (_classSamples.Length > 0)
            {
                foreach (var _sample in _classSamples)
                {
                    if (File.Exists(samplePath + "\\" + _sample.ImgFileName))
                    {
                        var orgSample = CvInvoke.Imread(samplePath + "\\" + _sample.ImgFileName);
                        var graySample = new Mat(orgSample.Rows, orgSample.Cols, Emgu.CV.CvEnum.DepthType.Cv8U, 1);
                        CvInvoke.CvtColor(orgSample, graySample, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);
                        _sample.LoadedImage = graySample;

                        orgSample.Dispose();
                    }
                }

                tmpSamples.AddRange(_classSamples);
            }
            _sampleList = tmpSamples.ToArray();
        }

        private void cmbClassList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbClassList.SelectedIndex > -1)
            {
                PrepareSelectedClass();
            }
            else
                trackBarThresh.Value = 0;
        }

        private void trackBarThresh_ValueChanged(object sender, EventArgs e)
        {
            lblThresh.Text = string.Format("{0} %", trackBarThresh.Value);
        }
    }
}
