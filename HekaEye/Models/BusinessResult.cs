using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HekaEye.Models
{
    public class BusinessResult
    {
        public bool Result { get; set; }
        public string ErrorMessage { get; set; }
        public int RecordId { get; set; }
    }
}
