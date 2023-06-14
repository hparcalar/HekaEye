using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using HekaEye.NewGen.Tools;

namespace HekaEye.Models
{
    public class HkToolModel
    {
        [Browsable(false)]
        public int Id { get; set; }
        [Browsable(false)]
        public int? ToolType { get; set; }
        public string ToolName { get; set; }
        [Browsable(false)]
        public int? ProgramId { get; set; }
        [Browsable(false)]
        public int? ToolOrder { get; set; }
        [Browsable(false)]
        public string ToolSettings { get; set; }

        public Base_Tool ToolObject { get; set; }
    }
}
