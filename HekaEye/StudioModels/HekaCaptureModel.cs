using Emgu.CV;
using Emgu.CV.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HekaEye.StudioModels
{
    public class HekaCaptureModel
    {
        public int RecipeId { get; set; }
        public int CameraId { get; set; }
        public VideoCapture Capture { get; set; }
        public string CameraName { get; set; }
        public Task CaptureTask { get; set; }
        public int SelectionType { get; set; } = 0;
        public ImageBox ImageBox { get; set; }
        public List<Point> SelectionPath { get; set; } = new List<Point>();
        public int? Exposure { get; set; }
        public bool CaptureRunning { get; set; } = false;
        public bool SelectionRunning { get; set; } = false;
        public bool SelectionStepRunning { get; set; } = false;
        public List<HekaRegion> RegionList { get; set; } = new List<HekaRegion>();
    }
}
