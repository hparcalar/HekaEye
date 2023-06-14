using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace HekaEye.Models
{
    public class HkProgramModel
    {
        [Browsable(false)]
        public int Id { get; set; }
        public string ProgramName { get; set; }
        public int TriggerMode { get; set; }
        public int? AutoTriggerInterval { get; set; }
        public string CameraName { get; set; }
        [Browsable(false)]
        public int RunningStatus { get; set; }

        [Browsable(false)]
        public IList<HkToolModel> Tools { get; set; }
    }
}
