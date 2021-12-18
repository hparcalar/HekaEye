using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HekaEye.Data
{
    public class Inspection
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Nullable<bool> Enabled { get; set; }

        [ForeignKey("Region")]
        public Nullable<int> RegionId { get; set; }

        [ForeignKey("RegionProperties")]
        public Nullable<int> PropertyId { get; set; }

        public virtual Region Region { get; set; }
        public virtual RegionProperties RegionProperties { get; set; }
    }
}
