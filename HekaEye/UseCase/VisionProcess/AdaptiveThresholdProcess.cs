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
    public class AdaptiveThresholdProcess : IVisionProcess
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
                Mat output = input.Clone();
                ProcPrmAdaptiveThreshold prms = (ProcPrmAdaptiveThreshold)ProcessTypeManager
                    .DeserializeParams(this.ProcParams, this.ProcessType);

                CvInvoke.AdaptiveThreshold(input, output, 255, prms.AdaptiveType == 1 ? Emgu.CV.CvEnum.AdaptiveThresholdType.MeanC :
                    Emgu.CV.CvEnum.AdaptiveThresholdType.GaussianC,
                                   prms.ThresholdType == 1 ? Emgu.CV.CvEnum.ThresholdType.Binary :
                                   prms.ThresholdType == 2 ? Emgu.CV.CvEnum.ThresholdType.BinaryInv :
                                   prms.ThresholdType == 3 ? Emgu.CV.CvEnum.ThresholdType.Otsu : Emgu.CV.CvEnum.ThresholdType.Binary,
                                   prms.BlockSize, prms.AdaptiveParam);

                return output;
            }
            catch (Exception)
            {

            }

            return null;
        }
    }
}
