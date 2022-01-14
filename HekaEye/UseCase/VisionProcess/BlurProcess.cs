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
    public class BlurProcess : IVisionProcess
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
                ProcPrmBlur prms = (ProcPrmBlur)ProcessTypeManager
                    .DeserializeParams(this.ProcParams, this.ProcessType);

                Mat output = input.Clone();

                if (prms.BlurType == 1) // gaussian
                {
                    CvInvoke.GaussianBlur(input, output,
                        new System.Drawing.Size(prms.KSize, prms.KSize), prms.SigmaX);
                }
                else if (prms.BlurType == 2) // median
                {
                    CvInvoke.MedianBlur(input, output, prms.KSize);
                }
                else if (prms.BlurType == 3) // bilateral
                {
                    CvInvoke.BilateralFilter(input, output, prms.Bilateral_D, prms.Bilateral_SigmaColor, prms.Bilateral_SigmaSpace);
                }
                else if (prms.BlurType == 4) // custom
                {
                    CvInvoke.Blur(input, output, new System.Drawing.Size(prms.KSize, prms.KSize),
                        new System.Drawing.Point(-1, -1));
                }

                return output;
            }
            catch (Exception)
            {

            }

            return null;
        }
    }
}
