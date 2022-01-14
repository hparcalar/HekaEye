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
    public class FindContoursProcess : IVisionProcess
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
                ProcPrmFindContours prms = (ProcPrmFindContours)ProcessTypeManager
                    .DeserializeParams(this.ProcParams, this.ProcessType);

                VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
                Mat hier = new Mat();

                CvInvoke.FindContours(input, contours, hier,
                    Emgu.CV.CvEnum.RetrType.Ccomp, prms.Method == 1 ? 
                        Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxNone :
                        Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);

                return contours;
            }
            catch (Exception)
            {

            }

            return null;
        }
    }
}
