using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HekaEye.NewGen.Tools
{
    public class Filter_Gauss : Base_Tool
    {
        public string Input { get; set; }
        public int KSize { get; set; }
        public double SigmaX { get; set; }
        public double SigmaY { get; set; }
    }
}
