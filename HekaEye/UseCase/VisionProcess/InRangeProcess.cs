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
    public class InRangeProcess : IVisionProcess
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
                Mat output = new Mat(input.Rows, input.Cols, Emgu.CV.CvEnum.DepthType.Cv8U, 1);
                ProcPrmInRange prms = (ProcPrmInRange)ProcessTypeManager
                    .DeserializeParams(this.ProcParams, this.ProcessType);

                CvInvoke.InRange(input, new ScalarArray(new Emgu.CV.Structure.MCvScalar(prms.MinValue)), 
                    new ScalarArray(new Emgu.CV.Structure.MCvScalar(prms.MaxValue)), output);

                return output;
            }
            catch (Exception)
            {

            }

            return null;
        }
    }
}
