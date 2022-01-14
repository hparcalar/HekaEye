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
    public class ApproxShapesProcess : IVisionProcess
    {
        public object InputData { get; set; }
        public string ProcParams { get; set; }
        public int ProcessId { get; set; }
        public ProcessTypeList ProcessType { get; set; }

        public object Make()
        {
            try
            {
                VectorOfVectorOfPoint input = (VectorOfVectorOfPoint)InputData;
                ProcPrmApproxShape prms = (ProcPrmApproxShape)ProcessTypeManager
                    .DeserializeParams(this.ProcParams, this.ProcessType);

                List<VectorOfPoint> approxList = new List<VectorOfPoint>();

                for (int i = 0; i < input.Length; i++)
                {
                    var cnt = input[i];
                    var perimeter = CvInvoke.ArcLength(cnt, true);
                    var epsilon = prms.Epsilon * perimeter;
                    VectorOfPoint approx = new VectorOfPoint();
                    CvInvoke.ApproxPolyDP(cnt, approx, epsilon, true);

                    if (approx != null && approx.Length > 0)
                        approxList.Add(approx);
                }

                return new VectorOfVectorOfPoint(approxList.ToArray());
            }
            catch (Exception)
            {

            }

            return null;
        }
    }
}
