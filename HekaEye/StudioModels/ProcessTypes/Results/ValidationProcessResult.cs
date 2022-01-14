using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HekaEye.StudioModels.ProcessTypes.Results
{
    public class ValidationProcessResult
    {
        public bool IsOk { get; set; }
        public double NokRate { get; set; }
        public Mat ResultFrame { get; set; }
    }
}
