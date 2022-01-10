using Emgu.CV;
using HekaEye.StudioModels.ProcessTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HekaEye.StudioModels.ProcessTypes.Params;
using Emgu.CV.Util;

namespace HekaEye.UseCase.VisionProcess
{
    public class Filter2DProcess : IVisionProcess
    {
        public object InputData { get; set; }
        public string ProcParams { get; set; }
        public ProcessTypeList ProcessType { get; set; }

        public object Make()
        {
            try
            {
                Mat input = (Mat)InputData;
                Mat output = input.Clone();
                ProcPrmFilter2D prms = (ProcPrmFilter2D)ProcessTypeManager
                    .DeserializeParams(this.ProcParams, this.ProcessType);

                Mat kernel = new Mat(new int[] { prms.Kernel.Length, prms.Kernel[0].Length }, 
                    Emgu.CV.CvEnum.DepthType.Cv32F, new VectorOfVectorOfInt(prms.Kernel));

                CvInvoke.Filter2D(input, output, kernel, new System.Drawing.Point(-1, -1));

                return output;
            }
            catch (Exception)
            {

            }

            return null;
        }
    }
}
