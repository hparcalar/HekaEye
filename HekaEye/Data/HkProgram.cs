using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HekaEye.Data
{
    public class HkProgram
    {
        public int Id { get; set; }
        public string ProgramName { get; set; }
        public int TriggerMode { get; set; }
        public int? AutoTriggerInterval { get; set; }
        public string CameraName { get; set; }
        public int RunningStatus { get; set; }
    }
}
