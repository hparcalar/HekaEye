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
    public class SobelProcess : IVisionProcess
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
                ProcPrmSobel prms = (ProcPrmSobel)ProcessTypeManager
                    .DeserializeParams(this.ProcParams, this.ProcessType);

                Mat output = Mat.Zeros(input.Rows, input.Cols, input.Depth, 1);

                CvInvoke.Sobel(input, output, Emgu.CV.CvEnum.DepthType.Cv32F, prms.Dx, prms.Dy,
                    prms.Kernel);
                CvInvoke.ConvertScaleAbs(output, output, 1, 0);

                return output;
            }
            catch (Exception)
            {

            }

            return null;
        }
    }
}
