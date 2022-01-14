using HekaEye.StudioModels.ProcessTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HekaEye.UseCase.VisionProcess
{
    public interface IVisionProcess
    {
        int ProcessId { get; set; }
        object InputData { get; set; }
        string ProcParams { get; set; }
        ProcessTypeList ProcessType { get; set; }
        object Make();
    }
}
