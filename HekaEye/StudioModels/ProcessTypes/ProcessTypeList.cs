using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HekaEye.StudioModels.ProcessTypes
{
    public enum ProcessTypeList
    {
        ConvertColor=1,
        Blur=2,
        Filter2D=3,
        AdaptiveThreshold=4,
        Threshold=5,
        InRange=6,
        Sobel=7,
        FindContours=8,
        Canny=9,
        FindBiggestShape=10,
        MatchShapes=11,
        ApproxShapes=12,
        Validation=13,
    }
}
