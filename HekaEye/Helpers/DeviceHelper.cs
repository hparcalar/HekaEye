using DirectShowLib;
using HekaEye.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Hompus.VideoInputDevices;

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

                //DsDevice[] captureDevices;

                //captureDevices = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);

                using (var sde = new SystemDeviceEnumerator())
                {
                    var devices = sde.ListVideoInputDevice();
                    foreach (var dev in devices)
                    {
                        list.Add(new CameraModel
                        {
                            DeviceIndex = dev.Key,
                            Name = dev.Value + "-" + dev.Key.ToString(),
                            DevicePath = dev.Value + "-" + dev.Key.ToString(),
                        });
                    }
                }

                //for (int idx = 0; idx < captureDevices.Length; idx++)
                //{
                //    list.Add(new CameraModel
                //    {
                //        DeviceIndex = idx,
                //        Name = captureDevices[idx].Name,
                //        DevicePath = captureDevices[idx].DevicePath,
                //    });
                //}

                data = list.ToArray();
            }
            catch (Exception)
            {

            }

            return data;
        }
    }

    [ComImport]
    [Guid("29840822-5B84-11D0-BD3B-00A0C911CE86")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    internal interface ICreateDevEnum
    {
        [PreserveSig]
        int CreateClassEnumerator(
            [In] ref Guid deviceClass,
            [Out] out IEnumMoniker enumMoniker,
            [In] int flags
        );
    }
}
