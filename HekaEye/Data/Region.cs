using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HekaEye.Data
{
    public class Region
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Nullable<bool> Enabled { get; set; }

        [ForeignKey("Recipe")]
        public Nullable<int> RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}
