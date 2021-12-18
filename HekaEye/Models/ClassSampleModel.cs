using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HekaEye.Models
{
    public class ClassSampleModel
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public string ImgFileName { get; set; }
        public Mat LoadedImage { get; set; }
    }
}
