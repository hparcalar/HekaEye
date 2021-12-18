using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HekaEye.Models
{
    public class RoiModel
    {
        public string Title { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public float Rotation { get; set; }
        public bool ConvertToGray { get; set; } = false;
        public int GrayThresholdStart { get; set; }
        public int GrayThresholdEnd { get; set; }
        public bool EqualizeHist { get; set; } = false;
        public bool MedianBlur { get; set; }
        public int MedianSize { get; set; } = 3;
        public bool Laplacian { get; set; }
        public int LaplaceSize { get; set; } = 3;
        public bool FindBiggestShape { get; set; } = false;
        public double ApproxEpsilon { get; set; } = 0.1;
        public bool AdaptiveThreshold { get; set; } = false;
        public int AdaptiveBlockSize { get; set; } = 5;
        public double AdaptiveParam { get; set; } = 6;
        public int SelectionType { get; set; } = 1;
        public bool ShowFaults { get; set; } = false;

    }
}
