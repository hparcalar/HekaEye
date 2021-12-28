using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HekaEye.Data
{
    public class Recipe
    {
        [Browsable(false)]
        public int Id { get; set; }

        [Category("Reçete Bilgileri")]
        public string RecipeCode { get; set; }

        [Category("Reçete Bilgileri")]
        public string RecipeName { get; set; }

        [Category("Reçete Bilgileri")]
        public Nullable<int> RW { get; set; }

        [Category("Reçete Bilgileri")]
        public Nullable<int> RH { get; set; }

        [Browsable(false)]
        public Nullable<int> Exposure { get; set; }

        [Browsable(false)]
        public string CameraName { get; set; }
        [Browsable(false)]
        public string StartTemplate { get; set; }
    }
}
