using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HekaEye.Data
{
    public class RegionProperties
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Nullable<int> OffsetX { get; set; }
        public Nullable<int> OffsetY { get; set; }
        public Nullable<bool> Enabled { get; set; }
        public Nullable<int> RegionType { get; set; }
        public Nullable<bool> ConvertToGray { get; set; }
        public Nullable<bool> ConvertToHsv { get; set; }
        public Nullable<bool> Laplacian { get; set; }
        public Nullable<bool> LaplaceSize { get; set; }
        public Nullable<bool> EqualizeHist { get; set; }
        public Nullable<bool> AdaptiveThr { get; set; }
        public Nullable<int> AdaptiveSize { get; set; }
        public Nullable<float> AdaptiveParam { get; set; }
        public Nullable<int> AdaptiveBorder { get; set; }
        public Nullable<bool> ManualThr { get; set; }
        public Nullable<int> ManualStart { get; set; }
        public Nullable<int> ManualEnd { get; set; }
        public Nullable<double> NokThreshold { get; set; }
        public Nullable<bool> GaussianBlur { get; set; }
        public Nullable<int> GaussianSize { get; set; }
        public Nullable<double> GaussianSigma { get; set; }
        public Nullable<bool> ApplyCanny { get; set; }
        public Nullable<double> CannyEpsilon { get; set; }
        public Nullable<double> MinShapeArea { get; set; }
        public Nullable<bool> ApplySobel { get; set; }
        public Nullable<int> SobelDx { get; set; }
        public Nullable<int> SobelDy { get; set; }
        public Nullable<int> SobelKernel { get; set; }

    }
}
