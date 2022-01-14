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
    public class ConvertColorProcess : IVisionProcess
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
                ProcPrmConvertColor prms = (ProcPrmConvertColor)ProcessTypeManager
                    .DeserializeParams(this.ProcParams, this.ProcessType);

                if (prms.ConversionType == 1) // bgr 2 gray
                {
                    Mat converted = new Mat(input.Rows, input.Cols, Emgu.CV.CvEnum.DepthType.Cv32F, 1);
                    CvInvoke.CvtColor(input, converted, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);

                    return converted;
                }
                else if (prms.ConversionType == 2) // bgr 2 hsv
                {
                    var converted = new Mat(input.Rows, input.Cols, input.Depth, 1);
                    CvInvoke.CvtColor(input, converted, Emgu.CV.CvEnum.ColorConversion.Bgr2Hsv);

                    return converted;
                }
            }
            catch (Exception)
            {

            }

            return null;
        }
    }
}
