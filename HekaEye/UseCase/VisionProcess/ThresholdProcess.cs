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
    public class ThresholdProcess : IVisionProcess
    {
        public object InputData { get; set; }
        public string ProcParams { get; set; }
        public ProcessTypeList ProcessType { get; set; }

        public object Make()
        {
            try
            {
                Mat input = (Mat)InputData;
                Mat output = new Mat(input.Rows, input.Cols, Emgu.CV.CvEnum.DepthType.Cv8U, 1);
                ProcPrmThreshold prms = (ProcPrmThreshold)ProcessTypeManager
                    .DeserializeParams(this.ProcParams, this.ProcessType);

                CvInvoke.Threshold(input, output, prms.Threshold, prms.MaxValue, prms.ThresholdType == 1 ? Emgu.CV.CvEnum.ThresholdType.Binary :
                                   prms.ThresholdType == 2 ? Emgu.CV.CvEnum.ThresholdType.BinaryInv :
                                   prms.ThresholdType == 3 ? Emgu.CV.CvEnum.ThresholdType.Otsu : 
                                   prms.ThresholdType == 4 ? Emgu.CV.CvEnum.ThresholdType.Triangle :
                                   Emgu.CV.CvEnum.ThresholdType.Binary);

                return output;
            }
            catch (Exception)
            {

            }

            return null;
        }
    }
}
