using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace HekaEye.NewGen.Tools
{
    public class Imp_PatternMatch : Base_Tool
    {
        public string Input { get; set; }
        public byte[] LearnedPattern { get; set; }

        [Browsable(false)]
        public int Out_X { get; set; }

        [Browsable(false)]
        public int Out_Y { get; set; }

        [Browsable(false)]
        public int Out_W { get; set; }

        [Browsable(false)]
        public int Out_H { get; set; }
    }
}
