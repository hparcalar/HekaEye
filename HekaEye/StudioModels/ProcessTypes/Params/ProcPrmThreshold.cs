using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HekaEye.StudioModels.ProcessTypes.Params
{
    public class ProcPrmThreshold
    {
        /// <summary>
        /// 1: Binary
        /// 2: BinaryInverse
        /// 3: Otsu
        /// 4: Triangle
        /// </summary>
        public int ThresholdType { get; set; }
        public double Threshold { get; set; }
        public double MaxValue { get; set; }
    }
}
