using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HekaEye.StudioModels.ProcessTypes.Params
{
    public class ProcPrmAdaptiveThreshold
    {
        /// <summary>
        /// 1: Mean C
        /// 2: Gaussian C
        /// </summary>
        public int AdaptiveType { get; set; }

        /// <summary>
        /// 1: Binary
        /// 2: BinaryInverse
        /// 3: Otsu
        /// </summary>
        public int ThresholdType { get; set; }

        public int BlockSize { get; set; }
        public int AdaptiveParam { get; set; }
    }
}
