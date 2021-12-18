using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HekaEye.Data
{
    public class MatchHistory
    {
        public int Id { get; set; }

        [ForeignKey("Product")]
        public Nullable<int> ProductId { get; set; }

        [ForeignKey("Inspection")]
        public Nullable<int> InspectionId { get; set; }
        public Nullable<bool> Result { get; set; }
        public Nullable<DateTime> MatchDate { get; set; }
        public Nullable<int> PrintStatus { get; set; }
        public string FaultImagePath { get; set; }

        public virtual Product Product { get; set; }
        public virtual Inspection Inspection { get; set; }
    }
}
