using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace HekaEye.Data
{
    public class CamResult
    {
        public int Id { get; set; }
        public string ProductNo { get; set; }
        public string SerialNo { get; set; }
        public string Explanation { get; set; }
        public string FaultExplanation { get; set; }

        [ForeignKey("ExternalTest")]
        public Nullable<int> ExternalTestId { get; set; }
        public bool IsOk { get; set; }
        public byte[] FaultImage { get; set; }
        public DateTime ResultDate { get; set; }

        [ForeignKey("WorkingShift")]
        public Nullable<int> ShiftId { get; set; }

        public virtual WorkingShift WorkingShift { get; set; }
        public virtual ExternalTest ExternalTest { get; set; }
    }
}
