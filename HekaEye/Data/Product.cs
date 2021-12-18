using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HekaEye.Data
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }

        [ForeignKey("Recipe")]
        public int RecipeId { get; set; }
        public Nullable<bool> IsActive { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}
