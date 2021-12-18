using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HekaEye.Data
{
    public class RegionPath
    {
        public int Id { get; set; }

        [ForeignKey("Region")]
        public Nullable<int> RegionId { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int PointOrder { get; set; }

        public virtual Region Region { get; set; }
    }
}
