using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace HekaEye.Data
{
    public class ProcessStep
    {
        public int Id { get; set; }

        [ForeignKey("Region")]
        public int RegionId { get; set; }
        public virtual Region Region { get; set; }

        public int ProcessType { get; set; }
        public string ProcessParams { get; set; }
        public int OrderNo { get; set; }
    }
}
