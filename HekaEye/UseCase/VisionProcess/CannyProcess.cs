using Emgu.CV;
using HekaEye.StudioModels.ProcessTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HekaEye.StudioModels.ProcessTypes.Params;

namespace HekaEye.UseCase.VisionProcess
{
    public class CannyProcess : IVisionProcess
    {
        public object InputData { get; set; }
        public string ProcParams { get; set; }
        public int ProcessId { get; set; }
        public ProcessTypeList ProcessType { get; set; }

        public object Make()
        {
            try
            {
                Mat input = (Mat)InputData;
                ProcPrmCanny prms = (ProcPrmCanny)ProcessTypeManager
                    .DeserializeParams(this.ProcParams, this.ProcessType);

                Mat output = input.Clone();

                CvInvoke.Canny(input, output, prms.Threshold1, prms.Threshold2, prms.ApertureSize);

                return output;
            }
            catch (Exception)
            {

            }

            return null;
        }
    }
}
