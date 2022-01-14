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
    public partial class frmSkyModel : Form
    {
        public frmSkyModel()
        {
            InitializeComponent();
        }

        public int RecordId { get; set; }
        public int RecipeId { get; set; }
        public bool IsSaved { get; set; }

        Data.Product[] otherProducts = new Data.Product[0];

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                using (EyeBO bObj = new EyeBO())
                {
                    var selectedProd = cmbCombine.SelectedIndex > -1 ?
                        otherProducts[cmbCombine.SelectedIndex] : null;

                    var result = bObj.SaveModel(new Data.Product
                    {
                        Id = this.RecordId,
                        RecipeId = this.RecipeId,
                        IsActive = true,
                        ProductCode = txtModelCode.Text,
                        ProductName = txtModelName.Text,
                        CombinedProductId = selectedProd != null ? selectedProd.Id : (int?)null,
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
            txtModelCode.Focus();
            BindModel();
        }

        private void BindModel()
        {
            using (EyeBO bObj = new EyeBO())
            {
                otherProducts = bObj.GetProductList().Where(d => d.Id != this.RecordId).ToArray();
                cmbCombine.DataSource = otherProducts;

                var dbObj = bObj.GetProduct(this.RecordId);
                if (dbObj != null)
                {
                    txtModelCode.Text = dbObj.ProductCode;
                    txtModelName.Text = dbObj.ProductName;

                    if (dbObj.CombinedProduct != null)
                    {
                        cmbCombine.Text = dbObj.CombinedProduct.ProductCode;
                    }
                    else
                        cmbCombine.SelectedIndex = -1;

                    this.RecipeId = dbObj.RecipeId;
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
