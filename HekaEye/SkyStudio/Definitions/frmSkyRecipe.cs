using HekaEye.UseCase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HekaEye.SkyStudio.Definitions
{
    public partial class frmSkyRecipe : Form
    {
        public frmSkyRecipe()
        {
            InitializeComponent();
        }

        public int RecordId { get; set; }
        public bool IsSaved { get; set; }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                using (EyeBO bObj = new EyeBO())
                {
                    var result = bObj.SaveRecipe(new Data.Recipe
                    {
                        Id = this.RecordId,
                        RecipeCode = txtRecipeName.Text,
                        RecipeName = txtRecipeName.Text,
                    });

                    this.IsSaved = result.Result;
                }
            }
            catch (Exception)
            {
                this.IsSaved = false;
            }

            this.Close();
        }

        private void frmSkyRecipe_Load(object sender, EventArgs e)
        {
            txtRecipeName.Focus();
            BindModel();
        }

        private void BindModel()
        {
            using (EyeBO bObj = new EyeBO())
            {
                var dbObj = bObj.GetRecipe(this.RecordId);
                if (dbObj != null)
                {
                    txtRecipeName.Text = dbObj.RecipeName;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.IsSaved = false;
            this.Close();
        }
    }
}
