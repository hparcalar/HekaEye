using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HekaEye.NewGen.Tools
{
    public class Imp_Threshold : Base_Tool
    {
        public string Input { get; set; }
        public int Low { get; set; }
        public int High { get; set; }

        /// <summary>
        /// 1: Binary
        /// 2: Binary Inverse
        /// 3: Trunc
        /// 4: ToZero
        /// 5: ToZero Inverse
        /// </summary>
        public int ThreshMode { get; set; }
    }
}
