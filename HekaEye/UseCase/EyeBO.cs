using HekaEye.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HekaEye.Models;
using HekaEye.StudioModels;

namespace HekaEye.UseCase
{
    public class EyeBO : IDisposable
    {
        public BusinessResult SaveRecipe(Recipe recipe)
        {
            BusinessResult result = new BusinessResult();

            try
            {
                using (EyeContext db = new EyeContext())
                {
                    if (db.Recipe.Any(d => d.RecipeCode == recipe.RecipeCode && d.Id != recipe.Id))
                    {
                        throw new Exception("Aynı isimde bir reçete mevcut. Lütfen başka bir isim girin.");
                    }

                    var dbRecipe = db.Recipe.FirstOrDefault(d => d.Id == recipe.Id);
                    if (dbRecipe == null)
                    {
                        dbRecipe = new Recipe();
                        db.Recipe.Add(dbRecipe);
                    }

                    dbRecipe.RecipeCode = recipe.RecipeCode;
                    dbRecipe.RecipeName = recipe.RecipeName;
                    dbRecipe.CameraName = recipe.CameraName;
                    dbRecipe.Exposure = recipe.Exposure;
                    dbRecipe.RW = recipe.RW;
                    dbRecipe.RH = recipe.RH;
                    db.SaveChanges();

                    result.RecordId = dbRecipe.Id;
                }

                result.Result = true;
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public BusinessResult SaveRecipeStartTemplate(int recipeId, System.Drawing.Image imgTemplate)
        {
            BusinessResult result = new BusinessResult();

            try
            {
                using (EyeContext db = new EyeContext())
                {
                    var dbRecipe = db.Recipe.FirstOrDefault(d => d.Id == recipeId);
                    if (dbRecipe != null)
                    {
                        var imgPath =
                            System.AppDomain.CurrentDomain.BaseDirectory + "StartTemplates\\ST_" + recipeId.ToString() + ".png";

                        imgTemplate.Save(imgPath);
                    }
                }

                result.Result = true;
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }
        public BusinessResult SaveModel(Product model)
        {
            BusinessResult result = new BusinessResult();

            try
            {
                using (EyeContext db = new EyeContext())
                {
                    if (db.Product.Any(d => d.ProductCode == model.ProductCode && d.Id != model.Id))
                    {
                        throw new Exception("Aynı isimde bir model mevcut. Lütfen başka bir isim girin.");
                    }

                    var dbModel = db.Product.FirstOrDefault(d => d.Id == model.Id);
                    if (dbModel == null)
                    {
                        dbModel = new Product();
                        db.Product.Add(dbModel);
                    }

                    dbModel.ProductCode = model.ProductCode;
                    dbModel.ProductName = model.ProductName;
                    dbModel.IsActive = model.IsActive;
                    dbModel.RecipeId = model.RecipeId;
                    db.SaveChanges();

                    result.RecordId = dbModel.Id;
                }

                result.Result = true;
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public BusinessResult SaveRegion(Region model, HekaRegion regionProps)
        {
            BusinessResult result = new BusinessResult();
            
            try
            {
                using (EyeContext db = new EyeContext())
                {
                    if (db.Region.Any(d => d.Title == model.Title && d.RecipeId == model.RecipeId && d.Id != model.Id))
                    {
                        throw new Exception("Bu reçetede aynı isimde bir bölge mevcut. Lütfen başka bir isim girin.");
                    }

                    Inspection dbInspec = null;
                    var dbModel = db.Region.FirstOrDefault(d => d.Id == model.Id);
                    if (dbModel == null)
                    {
                        dbModel = new Region();
                        db.Region.Add(dbModel);

                        dbInspec = new Inspection();
                        dbInspec.Title = model.Title;
                        dbInspec.Region = dbModel;
                        db.Inspection.Add(dbInspec);

                        var dbProps = new RegionProperties();
                        dbInspec.RegionProperties = dbProps;
                        db.RegionProperties.Add(dbProps);
                    }

                    dbModel.Title = model.Title;
                    dbModel.RecipeId = model.RecipeId;
                    dbModel.Enabled = model.Enabled;

                    // SAVE PATH
                    var exPath = db.RegionPath.Where(d => d.RegionId == dbModel.Id).ToArray();
                    foreach (var item in exPath)
                    {
                        db.RegionPath.Remove(item);
                    }

                    int pathIndex = 0;
                    foreach (var item in regionProps.Path)
                    {
                        db.RegionPath.Add(new RegionPath
                        {
                            Region = dbModel,
                            X = item.X,
                            Y = item.Y,
                            PointOrder = pathIndex,
                        });

                        pathIndex++;
                    }

                    // SAVE INSPECTIONS & PROPERTIES
                    if (dbInspec == null)
                    {
                        dbInspec = db.Inspection.FirstOrDefault(d => d.RegionId == dbModel.Id);
                    }
                    if (dbInspec != null)
                    {
                        dbInspec.Title = model.Title;
                        dbInspec.RegionProperties.AdaptiveParam = Convert.ToSingle(regionProps.AdaptiveParam);
                        dbInspec.RegionProperties.AdaptiveSize = regionProps.AdaptiveSize;
                        dbInspec.RegionProperties.AdaptiveThr = regionProps.AdaptiveThr;
                        dbInspec.RegionProperties.ConvertToGray = regionProps.ConvertToGray;
                        dbInspec.RegionProperties.ConvertToHsv = regionProps.ConvertToHsv;
                        dbInspec.RegionProperties.Enabled = regionProps.Enabled;
                        dbInspec.RegionProperties.EqualizeHist = regionProps.EqualizeHist;
                        dbInspec.RegionProperties.LaplaceSize = false;
                        dbInspec.RegionProperties.Laplacian = regionProps.Laplacian;
                        dbInspec.RegionProperties.ManualEnd = regionProps.ManuelEnd;
                        dbInspec.RegionProperties.ManualStart = regionProps.ManuelStart;
                        dbInspec.RegionProperties.ManualThr = regionProps.ManualThr;
                        dbInspec.RegionProperties.NokThreshold = regionProps.NokThreshold;
                        dbInspec.RegionProperties.OffsetX = regionProps.OffsetX;
                        dbInspec.RegionProperties.OffsetY = regionProps.OffsetY;
                        dbInspec.RegionProperties.RegionType = regionProps.RegionType;
                        dbInspec.RegionProperties.Title = regionProps.Title;
                        dbInspec.RegionProperties.GaussianBlur = regionProps.GaussianBlur;
                        dbInspec.RegionProperties.GaussianSize = regionProps.GaussianSize;
                        dbInspec.RegionProperties.GaussianSigma = regionProps.GaussianSigma;
                        dbInspec.RegionProperties.AdaptiveBorder = regionProps.AdaptiveBorder;
                        dbInspec.RegionProperties.ApplyCanny = regionProps.ApplyCanny;
                        dbInspec.RegionProperties.CannyEpsilon = regionProps.CannyEpsilon;
                        dbInspec.RegionProperties.MinShapeArea = regionProps.MinShapeArea;
                    }

                    db.SaveChanges();

                    result.RecordId = dbModel.Id;
                }

                result.Result = true;
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public Recipe[] GetRecipeList()
        {
            Recipe[] data = new Recipe[0];

            using (EyeContext db = new EyeContext())
            {
                data = db.Recipe.ToArray();
            }

            return data;
        }

        public Product[] GetProductList()
        {
            Product[] data = new Product[0];

            using (EyeContext db = new EyeContext())
            {
                data = db.Product.ToArray();
            }

            return data;
        }

        public Region[] GetRegionList(int recipeId, int cameraId)
        {
            Region[] data = new Region[0];

            using (EyeContext db = new EyeContext())
            {
                data = db.Region.Where(d => d.RecipeId == recipeId && d.CameraId == cameraId).ToArray();
            }

            return data;
        }

        public HekaRegion GetRegion(int regionId)
        {
            HekaRegion model = new HekaRegion();

            using (EyeContext db = new EyeContext())
            {
                var dbRegion = db.Region.FirstOrDefault(d => d.Id == regionId);
                if (dbRegion != null)
                {
                    model.Id = dbRegion.Id;
                    model.CameraId = dbRegion.CameraId ?? 0;
                    
                    var dbInspec = db.Inspection.FirstOrDefault(d => d.RegionId == regionId);
                    if (dbInspec != null && dbInspec.RegionProperties != null)
                    {
                        model.AdaptiveParam = dbInspec.RegionProperties.AdaptiveParam ?? 0;
                        model.AdaptiveSize = dbInspec.RegionProperties.AdaptiveSize ?? 0;
                        model.AdaptiveThr = dbInspec.RegionProperties.AdaptiveThr ?? false;
                        model.ConvertToGray = dbInspec.RegionProperties.ConvertToGray ?? false;
                        model.ConvertToHsv = dbInspec.RegionProperties.ConvertToHsv ?? false;
                        model.Enabled = dbInspec.RegionProperties.Enabled ?? false;
                        model.EqualizeHist = dbInspec.RegionProperties.EqualizeHist ?? false;
                        model.LaplaceSize = 3;
                        model.Laplacian = dbInspec.RegionProperties.Laplacian ?? false;
                        model.ManualThr = dbInspec.RegionProperties.ManualThr ?? false;
                        model.ManuelEnd = dbInspec.RegionProperties.ManualEnd ?? 0;
                        model.ManuelStart = dbInspec.RegionProperties.ManualStart ?? 0;
                        model.NokThreshold = dbInspec.RegionProperties.NokThreshold ?? -1;
                        model.OffsetX = dbInspec.RegionProperties.OffsetX ?? 0;
                        model.OffsetY = dbInspec.RegionProperties.OffsetY ?? 0;
                        model.RegionType = dbInspec.RegionProperties.RegionType ?? 1;
                        model.Title = dbInspec.RegionProperties.Title;
                        model.GaussianBlur = dbInspec.RegionProperties.GaussianBlur ?? false;
                        model.GaussianSigma = dbInspec.RegionProperties.GaussianSigma ?? 0;
                        model.GaussianSize = dbInspec.RegionProperties.GaussianSize ?? 3;
                        model.AdaptiveBorder = dbInspec.RegionProperties.AdaptiveBorder ?? 1;
                        model.ApplyCanny = dbInspec.RegionProperties.ApplyCanny ?? false;
                        model.CannyEpsilon = dbInspec.RegionProperties.CannyEpsilon ?? 0.01;
                        model.MinShapeArea = dbInspec.RegionProperties.MinShapeArea ?? 0.6;

                        var pathList = db.RegionPath.Where(d => d.RegionId == regionId)
                            .OrderBy(d => d.PointOrder).ToList();
                        List<System.Drawing.Point> pointList = new List<System.Drawing.Point>();
                        foreach (var item in pathList)
                        {
                            pointList.Add(new System.Drawing.Point(item.X, item.Y));
                        }

                        model.Path = pointList.ToArray();
                    }
                }
            }

            return model;
        }

        public BusinessResult DeleteRegion(int regionId)
        {
            BusinessResult result = new BusinessResult();

            try
            {
                using (EyeContext db =new EyeContext())
                {
                    var dbRegion = db.Region.FirstOrDefault(d => d.Id == regionId);
                    if (dbRegion != null)
                    {
                        var dbInspect = db.Inspection.FirstOrDefault(d => d.RegionId == regionId);
                        if (dbInspect != null)
                        {
                            var regPropId = dbInspect.PropertyId;
                            db.Inspection.Remove(dbInspect);

                            var dbRegProp = db.RegionProperties.FirstOrDefault(d => d.Id == regPropId);
                            if (dbRegProp != null)
                            {
                                db.RegionProperties.Remove(dbRegProp);
                            }
                        }

                        var paths = db.RegionPath.Where(d => d.RegionId == regionId).ToArray();
                        foreach (var item in paths)
                        {
                            db.RegionPath.Remove(item);
                        }

                        db.Region.Remove(dbRegion);
                    }

                    db.SaveChanges();
                }

                result.Result = true;
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public BusinessResult DeleteModel(int modelId)
        {
            BusinessResult result = new BusinessResult();

            try
            {
                using (EyeContext db = new EyeContext())
                {
                    var dbModel = db.Product.FirstOrDefault(d => d.Id == modelId);
                    if (dbModel != null)
                    {
                        db.Product.Remove(dbModel);
                    }

                    db.SaveChanges();
                }

                result.Result = true;
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public BusinessResult DeleteRecipe(int recipeId)
        {
            BusinessResult result = new BusinessResult();

            try
            {
                using (EyeContext db = new EyeContext())
                {
                    var dbRecipe = db.Recipe.FirstOrDefault(d => d.Id == recipeId);
                    if (dbRecipe != null)
                    {
                        var regionList = db.Region.Where(d => d.RecipeId == recipeId).ToArray();
                        foreach (var item in regionList)
                        {
                            DeleteRegion(item.Id);
                        }

                        var models = db.Product.Where(d => d.RecipeId == recipeId).ToArray();
                        foreach (var item in models)
                        {
                            DeleteModel(item.Id);
                        }

                        db.Recipe.Remove(dbRecipe);

                        db.SaveChanges();
                    }
                }

                result.Result = true;
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public BusinessResult SaveCamera(RecipeCamera model)
        {
            BusinessResult result = new BusinessResult();

            try
            {
                using (EyeContext db = new EyeContext())
                {
                    var dbModel = db.RecipeCamera.FirstOrDefault(d => d.Id == model.Id);
                    if (dbModel == null)
                    {
                        dbModel = new RecipeCamera
                        {
                            CameraName = model.CameraName,
                            IsActive = model.IsActive,
                            RecipeId = model.RecipeId,
                        };
                        db.RecipeCamera.Add(dbModel);
                    }

                    dbModel.Exposure = model.Exposure;
                    dbModel.CameraName = model.CameraName;
                    dbModel.IsActive = model.IsActive;
                    dbModel.RecipeId = model.RecipeId;

                    db.SaveChanges();

                    result.RecordId = dbModel.Id;
                }

                result.Result = true;
            }
            catch (Exception ex)
            {
                result.Result = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public RecipeCamera[] GetCameraList(int recipeId)
        {
            RecipeCamera[] data = new RecipeCamera[0];

            try
            {
                using (EyeContext db = new EyeContext())
                {
                    data = db.RecipeCamera.Where(d => d.RecipeId == recipeId)
                        .ToArray();
                }
            }
            catch (Exception)
            {

            }

            return data;
        }

        public RecipeCamera GetCamera(int cameraId)
        {
            RecipeCamera cam = new RecipeCamera();

            try
            {
                using (EyeContext db = new EyeContext())
                {
                    cam = db.RecipeCamera.FirstOrDefault(d => d.Id == cameraId);
                }
            }
            catch (Exception)
            {

            }

            return cam;
        }

        public void Dispose()
        {
            
        }
    }
}
