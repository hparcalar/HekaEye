using Emgu.CV;
using HekaEye.StudioModels.ProcessTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HekaEye.StudioModels.ProcessTypes.Params;
using Emgu.CV.Util;
using System.Drawing;
using Emgu.CV.Structure;
using HekaEye.StudioModels.ProcessTypes.Results;

namespace HekaEye.UseCase.VisionProcess
{
    public class ValidationProcess : IVisionProcess
    {
        public object InputData { get; set; }
        public VectorOfVectorOfPoint RegionContour { get; set; }
        public Mat OriginalFrame { get; set; }
        public string ProcParams { get; set; }
        public int ProcessId { get; set; }
        public ProcessTypeList ProcessType { get; set; }

        public object Make()
        {
            ValidationProcessResult validationResult = new ValidationProcessResult();

            try
            {
                Mat input = (Mat)InputData;
                ProcPrmValidation prms = (ProcPrmValidation)ProcessTypeManager
                    .DeserializeParams(this.ProcParams, this.ProcessType);

                var clonedFrame = this.OriginalFrame.Clone();

                double regionArea = CvInvoke.ContourArea(this.RegionContour);
                double faultArea = CvInvoke.CountNonZero(input);

                var nokRate = faultArea / regionArea * 100;

                validationResult.NokRate = nokRate;
                validationResult.IsOk = nokRate < prms.OnesRate;
                validationResult.ResultFrame = clonedFrame;

                if (nokRate >= prms.OnesRate)
                {
                    // DRAW FAULT POINTS
                    VectorOfPoint faultPixels = new VectorOfPoint();
                    CvInvoke.FindNonZero(input, faultPixels);

                    if (faultPixels.Length > 0)
                    {
                        var dilElm = CvInvoke.GetStructuringElement(Emgu.CV.CvEnum.ElementShape.Rectangle, new Size(3, 3), new Point(-1, -1));
                        CvInvoke.Dilate(input, input, dilElm,
                            new Point(-1, -1), 1, Emgu.CV.CvEnum.BorderType.Default,
                            new MCvScalar(255));
                        dilElm.Dispose();

                        Mat[] channelsOfFrame = clonedFrame.Split();
                        var redChannel = channelsOfFrame[2];
                        CvInvoke.BitwiseOr(redChannel, input, redChannel);
                        CvInvoke.BitwiseXor(channelsOfFrame[0], input, channelsOfFrame[0]);
                        CvInvoke.BitwiseXor(channelsOfFrame[1], input, channelsOfFrame[1]);

                        var mergeData = new VectorOfMat(channelsOfFrame[0], channelsOfFrame[1], redChannel);
                        CvInvoke.Merge(mergeData, clonedFrame);

                        validationResult.ResultFrame = clonedFrame;

                        mergeData.Dispose();
                    }

                    faultPixels.Dispose();
                }
            }
            catch (Exception)
            {

            }

            return validationResult;
        }
    }
}
