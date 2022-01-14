using HekaEye.StudioModels.ProcessTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HekaEye.UseCase.VisionProcess
{
    public class VisionProcessManager
    {
        public static IVisionProcess CreateProcess(ProcessTypeList processType)
        {
            try
            {
                switch (processType)
                {
                    case ProcessTypeList.ConvertColor:
                        return new ConvertColorProcess();
                    case ProcessTypeList.Blur:
                        return new BlurProcess();
                    case ProcessTypeList.Filter2D:
                        return new Filter2DProcess();
                    case ProcessTypeList.AdaptiveThreshold:
                        return new AdaptiveThresholdProcess();
                    case ProcessTypeList.Threshold:
                        return new ThresholdProcess();
                    case ProcessTypeList.InRange:
                        return new InRangeProcess();
                    case ProcessTypeList.Sobel:
                        return new SobelProcess();
                    case ProcessTypeList.FindContours:
                        return new FindContoursProcess();
                    case ProcessTypeList.Canny:
                        return new CannyProcess();
                    case ProcessTypeList.FindBiggestShape:
                        return new FindBiggestShapeProcess();
                    case ProcessTypeList.MatchShapes:
                        return null;
                    case ProcessTypeList.ApproxShapes:
                        return new ApproxShapesProcess();
                    case ProcessTypeList.Validation:
                        return new ValidationProcess();
                    default:
                        break;
                }
            }
            catch (Exception)
            {

            }

            return null;
        }
    }
}
