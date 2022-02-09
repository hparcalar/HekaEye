using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HekaEye.StudioModels
{
    public class MatchReportModel
    {
        public DateTime? MatchDate { get; set; }
        public int NokCount { get; set; }
        public int OkCount { get; set; }
    }
}
