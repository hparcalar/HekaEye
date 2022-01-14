using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace HekaEye.Data
{
    public partial class RecipeCamera
    {
        [Browsable(false)]
        public int Id { get; set; }

        [Browsable(false)]
        [ForeignKey("Recipe")]
        public int RecipeId { get; set; }
        public string CameraName { get; set; }
        public string CameraAlias { get; set; }
        public bool IsActive { get; set; }
        public Nullable<int> Exposure { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
