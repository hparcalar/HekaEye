using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HekaEye.NewGen.Tools;
using Newtonsoft.Json;

namespace HekaEye.NewGen.Map
{
    public class HkToolTypes
    {
        // filters
        public static readonly int Filter_Gauss = 1;
        public static readonly int Filter_Erode = 2;
        public static readonly int Filter_Dilate = 3;
        public static readonly int Filter_MorphOpen = 4;
        public static readonly int Filter_MorphClose = 5;

        // image processing
        public static readonly int Imp_Rectangle = 6;
        public static readonly int Imp_Polygon = 7;
        public static readonly int Imp_Threshold = 8;
        public static readonly int Imp_PatternMatch = 9;

        // comparison
        public static readonly int Cmp_Numeric = 10;
        public static readonly int Cmp_Bool = 11;

        // output
        public static readonly int Out_TcpIp = 12;
        public static readonly int Out_ModbusTcp = 13;
        public static readonly int Out_DigitalOutput = 14;
        public static readonly int Out_Http = 15;

        public static string GetToolTypeText(int toolType)
        {
            string tType = "";
            switch (toolType)
            {
                case 1:
                    tType = "Gauss";
                    break;
                case 2:
                    tType = "Erode";
                    break;
                case 3:
                    tType = "Dilate";
                    break;
                case 4:
                    tType = "Morph Open";
                    break;
                case 5:
                    tType = "Morph Close";
                    break;
                case 6:
                    tType = "Rectangle";
                    break;
                case 7:
                    tType = "Polygon";
                    break;
                case 8:
                    tType = "Threshold";
                    break;
                case 9:
                    tType = "Pattern Match";
                    break;
                case 10:
                    tType = "Numeric Compare";
                    break;
                case 11:
                    tType = "Boolean Compare";
                    break;
                case 12:
                    tType = "Output Tcp/Ip";
                    break;
                case 13:
                    tType = "Output Modbus/Tcp";
                    break;
                case 14:
                    tType = "Output Digital";
                    break;
                case 15:
                    tType = "Output Http";
                    break;
                default:
                    break;
            }

            return tType;
        }

        public static Base_Tool GetToolObject(string toolData, int toolType)
        {
            if (toolType == HkToolTypes.Filter_Gauss)
            {
                return JsonConvert.DeserializeObject<Filter_Gauss>(toolData) ?? new Tools.Filter_Gauss();
            }
            else if (toolType == HkToolTypes.Filter_Erode)
            {
                return JsonConvert.DeserializeObject<Filter_Erode>(toolData) ?? new Tools.Filter_Erode();
            }
            else if (toolType == HkToolTypes.Filter_Dilate)
            {
                return JsonConvert.DeserializeObject<Filter_Dilate>(toolData) ?? new Tools.Filter_Dilate();
            }
            else if (toolType == HkToolTypes.Filter_MorphOpen)
            {
                return JsonConvert.DeserializeObject<Filter_MorphOpen>(toolData) ?? new Tools.Filter_MorphOpen();
            }
            else if (toolType == HkToolTypes.Filter_MorphClose)
            {
                return JsonConvert.DeserializeObject<Filter_MorphClose>(toolData) ?? new Tools.Filter_MorphClose();
            }
            else if (toolType == HkToolTypes.Imp_Rectangle)
            {
                return JsonConvert.DeserializeObject<Imp_Rectangle>(toolData) ?? new Tools.Imp_Rectangle();
            }
            else if (toolType == HkToolTypes.Imp_Polygon)
            {
                return JsonConvert.DeserializeObject<Imp_Polygon>(toolData) ?? new Tools.Imp_Polygon();
            }
            else if (toolType == HkToolTypes.Imp_Threshold)
            {
                return JsonConvert.DeserializeObject<Imp_Threshold>(toolData) ?? new Tools.Imp_Threshold();
            }
            else if (toolType == HkToolTypes.Imp_PatternMatch)
            {
                return JsonConvert.DeserializeObject<Imp_PatternMatch>(toolData) ?? new Tools.Imp_PatternMatch();
            }
            else if (toolType == HkToolTypes.Cmp_Numeric)
            {
                return JsonConvert.DeserializeObject<Cmp_Numeric>(toolData) ?? new Tools.Cmp_Numeric();
            }
            else if (toolType == HkToolTypes.Cmp_Bool)
            {
                return JsonConvert.DeserializeObject<Cmp_Bool>(toolData) ?? new Tools.Cmp_Bool();
            }
            else if (toolType == HkToolTypes.Out_TcpIp)
            {
                return JsonConvert.DeserializeObject<Out_TcpIp>(toolData) ?? new Tools.Out_TcpIp();
            }
            else if (toolType == HkToolTypes.Out_ModbusTcp)
            {
                return JsonConvert.DeserializeObject<Out_ModbusTcp>(toolData) ?? new Tools.Out_ModbusTcp();
            }
            else if (toolType == HkToolTypes.Out_DigitalOutput)
            {
                return JsonConvert.DeserializeObject<Out_DigitalOutput>(toolData) ?? new Tools.Out_DigitalOutput();
            }
            else if (toolType == HkToolTypes.Out_Http)
            {
                return JsonConvert.DeserializeObject<Out_Http>(toolData) ?? new Tools.Out_Http();
            }

            return null;
        }

        public static string SerializeToolSpecs<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
