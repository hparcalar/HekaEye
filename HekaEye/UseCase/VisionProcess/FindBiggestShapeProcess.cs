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
    public class FindBiggestShapeProcess : IVisionProcess
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
                ProcPrmFindBiggestShape prms = (ProcPrmFindBiggestShape)ProcessTypeManager
                    .DeserializeParams(this.ProcParams, this.ProcessType);

                var resultArr =
                    input.ToArrayOfArray()
                    .OrderByDescending(d => CvInvoke.ContourArea(new VectorOfPoint(d)))
                    .Select(d => new VectorOfPoint(d))
                    .ToArray();

                if (resultArr.Length > prms.BiggestIndex)
                    return resultArr[prms.BiggestIndex];
            }
            catch (Exception)
            {

            }

            return null;
        }
    }
}
