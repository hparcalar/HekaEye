using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HekaEye.StudioModels.ProcessTypes.Params
{
    public class ProcPrmFindContours
    {
        /// <summary>
        /// 1: ChainApproxNone
        /// 2: ChainApproxSimple
        /// </summary>
        public int Method { get; set; }
    }
}
