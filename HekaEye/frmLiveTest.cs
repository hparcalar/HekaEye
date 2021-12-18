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

namespace HekaEye
{
    public partial class frmLiveTest : Form
    {
        public frmLiveTest()
        {
            InitializeComponent();
        }

        DbHelper _db = new DbHelper();
        DeviceHelper _deviceHelper = new DeviceHelper();
        CameraModel[] _cameraList = new CameraModel[0];
        CaptureClassModel[] _classList = new CaptureClassModel[0];
        ClassSampleModel[] _sampleList = new ClassSampleModel[0];
        VideoCapture _activeCapture = null;
        Task _tCapture = null;

        bool _captureRunning = false;
        bool _liveTestStarted = false;

        private void frmLiveTest_Load(object sender, EventArgs e)
        {
            _cameraList = _deviceHelper.GetCameras();
            _classList = _db.GetClassList();

            string samplePath = System.AppDomain.CurrentDomain.BaseDirectory + "Samples";
            List<ClassSampleModel> tmpSamples = new List<ClassSampleModel>();
            foreach (var _class in _classList)
            {
                var _classSamples = _db.GetSamples(_class.Id);
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
            }
            _sampleList = tmpSamples.ToArray();

            cmbCamera.DataSource = _cameraList;
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

                    this.BeginInvoke((Action)delegate
                    {
                        lblStatus.Visible = false;
                    });

                    if (_liveTestStarted)
                    {
                        var gray = new Mat(frame.Rows, frame.Cols, Emgu.CV.CvEnum.DepthType.Cv8U, 1);
                        CvInvoke.CvtColor(frame, gray, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);
                        int capturedCount = 0;

                        foreach (var _class in _classList)
                        {
                            var classThresh = _class.Threshold * 1.0;
                            if (classThresh == 0)
                                classThresh = 0.6;
                            else
                                classThresh = classThresh / 100.0;

                            var _classSamples = _sampleList.Where(d => d.ClassId == _class.Id);
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

                                        if (maxValues[0] > classThresh)
                                        {
                                            Rectangle match = new Rectangle(maxLocations[0], _sample.LoadedImage.Size);
                                            CvInvoke.Rectangle(frame, match, new MCvScalar(0, 0, 255), 2);
                                            CvInvoke.PutText(frame, _class.Name, new Point(match.X, match.Y), Emgu.CV.CvEnum.FontFace.HersheyComplex,
                                                0.8, new MCvScalar(255, 0, 0));

                                            capturedCount++;
                                        }
                                    }
                                }
                            }
                        }

                        if (capturedCount > 0)
                        {
                            this.BeginInvoke((Action)delegate
                            {
                                lblError.BackColor = Color.Red;
                                lblError.Text = "HATALI MALZEME";
                                lblError.Visible = true;
                            });
                        }
                        else
                            this.BeginInvoke((Action)delegate
                            {
                                lblError.BackColor = Color.Green;
                                lblError.Text = "OK";
                                lblError.Visible = true;
                            });
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
            StartCapture();
        }

        private void btnTestStatus_Click(object sender, EventArgs e)
        {
            _liveTestStarted = !_liveTestStarted;
            
            if (!_liveTestStarted)
            {
                lblError.Visible = false;
                btnTestStatus.Text = "BAŞLAT";
            }
            else
            {
                btnTestStatus.Text = "BİTİR";
            }
        }
    }
}
