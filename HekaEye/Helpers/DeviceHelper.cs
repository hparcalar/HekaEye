using DirectShowLib;
using HekaEye.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HekaEye.Helpers
{
    public class DeviceHelper
    {
        public CameraModel[] GetCameras()
        {
            CameraModel[] data = new CameraModel[0];

            try
            {
                List<CameraModel> list = new List<CameraModel>();

                DsDevice[] captureDevices;

                captureDevices = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);

                for (int idx = 0; idx < captureDevices.Length; idx++)
                {
                    list.Add(new CameraModel
                    {
                        DeviceIndex = idx,
                        Name = captureDevices[idx].Name,
                        DevicePath = captureDevices[idx].DevicePath,
                    });
                }

                data = list.ToArray();
            }
            catch (Exception)
            {

            }

            return data;
        }
    }
}
