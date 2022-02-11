using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HekaEye.StudioModels.DeviceModels
{
    public class DigitalIOResult
    {
        public int slot { get; set; }
        public DigitalIOArray io { get; set; }
    }
}
