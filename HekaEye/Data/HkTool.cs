using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HekaEye.Data
{
    public class HkTool
    {
        public int Id { get; set; }
        public int? ToolType { get; set; }
        public string ToolName { get; set; }

        [ForeignKey("HkProgram")]
        public int? ProgramId { get; set; }
        public int? ToolOrder { get; set; }
        public string ToolSettings { get; set; }

        public virtual HkProgram HkProgram { get; set; }

    }
}
