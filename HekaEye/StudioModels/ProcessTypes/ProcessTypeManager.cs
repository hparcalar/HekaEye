using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HekaEye.StudioModels.ProcessTypes.Params;
using Newtonsoft.Json;

namespace HekaEye.StudioModels.ProcessTypes
{
    public class ProcessTypeManager
    {
        public static string SerializeParams(object prm)
        {
            try
            {
                return JsonConvert.SerializeObject(prm);
            }
            catch (Exception)
            {

            }

            return string.Empty;
        }

        public static object DeserializeParams(string prm, ProcessTypeList processType)
        {
            try
            {
                switch (processType)
                {
                    case ProcessTypeList.ConvertColor:
                        return JsonConvert.DeserializeObject<ProcPrmConvertColor>(prm);
                    case ProcessTypeList.Blur:
                        return JsonConvert.DeserializeObject<ProcPrmBlur>(prm);
                    case ProcessTypeList.Filter2D:
                        return JsonConvert.DeserializeObject<ProcPrmFilter2D>(prm);
                    case ProcessTypeList.AdaptiveThreshold:
                        return JsonConvert.DeserializeObject<ProcPrmAdaptiveThreshold>(prm);
                    case ProcessTypeList.Threshold:
                        return JsonConvert.DeserializeObject<ProcPrmThreshold>(prm);
                    case ProcessTypeList.InRange:
                        return JsonConvert.DeserializeObject<ProcPrmThreshold>(prm);
                    case ProcessTypeList.Sobel:
                        return JsonConvert.DeserializeObject<ProcPrmSobel>(prm);
                    case ProcessTypeList.FindContours:
                        return JsonConvert.DeserializeObject<ProcPrmFindContours>(prm);
                    case ProcessTypeList.Canny:
                        return JsonConvert.DeserializeObject<ProcPrmCanny>(prm);
                    case ProcessTypeList.FindBiggestShape:
                        return JsonConvert.DeserializeObject<ProcPrmFindBiggestShape>(prm);
                    case ProcessTypeList.MatchShapes:
                        return JsonConvert.DeserializeObject<ProcPrmFindBiggestShape>(prm);
                    case ProcessTypeList.ApproxShapes:
                        return JsonConvert.DeserializeObject<ProcPrmApproxShape>(prm);
                    case ProcessTypeList.Validation:
                        return JsonConvert.DeserializeObject<ProcPrmValidation>(prm);
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
