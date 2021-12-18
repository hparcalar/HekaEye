using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HekaEye.StudioModels
{
    public class HekaRegion
    {
        [Browsable(false)]
        public int Id { get; set; }

        [Category("Bölge Bilgisi")]
        public string Title { get; set; }
        [Category("Bölge Bilgisi")]
        public int OffsetX { get; set; }
        [Category("Bölge Bilgisi")]
        public int OffsetY { get; set; }
        [Category("Bölge Bilgisi")]
        public bool Enabled { get; set; } = true;

        [Browsable(false)]
        public Point[] Path { get; set; }

        [Browsable(false)]
        public int RegionType { get; set; } // 1: shape, 2: line

        [Category("Renk Çevrimi")]
        public bool ConvertToGray { get; set; } = false;
        [Category("Renk Çevrimi")]
        public bool ConvertToHsv { get; set; } = false;


        [Category("Filtre")]
        public bool Laplacian { get; set; } = false;
        [Category("Filtre")]
        public int LaplaceSize { get; set; } = 3;
        [Category("Filtre")]
        public bool EqualizeHist { get; set; } = false;
        [Category("Filtre")]
        public Nullable<bool> GaussianBlur { get; set; }
        [Category("Filtre")]
        public Nullable<int> GaussianSize { get; set; }
        [Category("Filtre")]
        public Nullable<double> GaussianSigma { get; set; }


        [Category("Eşik")]
        public bool AdaptiveThr { get; set; } = false;

        [Category("Eşik")]
        public int AdaptiveSize { get; set; } = 5;
        [Category("Eşik")]
        public double AdaptiveParam { get; set; } = 8;
        [Category("Eşik")]
        public int AdaptiveBorder { get; set; } = 1;

        [Category("Eşik")]
        public bool ManualThr { get; set; } = false;
        [Category("Eşik")]
        public int ManuelStart { get; set; } = 0;
        [Category("Eşik")]
        public int ManuelEnd { get; set; } = 0;

        [Category("Eşik")]
        public int HStart { get; set; } = 0;
        [Category("Eşik")]
        public int SStart { get; set; } = 0;
        [Category("Eşik")]
        public int VStart { get; set; } = 0;

        [Category("Eşik")]
        public int HEnd { get; set; } = 0;
        [Category("Eşik")]
        public int SEnd { get; set; } = 0;
        [Category("Eşik")]
        public int VEnd { get; set; } = 0;

        [Category("Karar")]
        public int NokThreshold { get; set; } = -1;

        [Browsable(false)]
        public int ErrorFrameCount { get; set; }
    }
}
