using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HekaEye.StudioModels.ProcessTypes.Params
{
    public class ProcPrmBlur
    {
        /// <summary>
        /// 1: gaussian
        /// 2: median
        /// 3: bilateral
        /// 4: custom
        /// </summary>
        public int BlurType { get; set; }

        // MEDIAN & GAUSSIAN & CUSTOM PARAMS
        public int KSize { get; set; }
        public int SigmaX { get; set; }

        // BILATERAL SPECIFIC PARAMS
        public int Bilateral_D { get; set; }
        
        public double Bilateral_SigmaColor { get; set; }
        public double Bilateral_SigmaSpace { get; set; }
    }
}
