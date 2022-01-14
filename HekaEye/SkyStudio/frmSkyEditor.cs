using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using HekaEye.Data;
using HekaEye.Helpers;
using HekaEye.Models;
using HekaEye.StudioModels;
using HekaEye.UseCase;
using HekaEye.SkyStudio.Definitions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HekaEye.UseCase.VisionProcess;
using HekaEye.StudioModels.ProcessTypes;
using HekaEye.SkyStudio.PartialControls;
using ComponentFactory.Krypton.Toolkit;

namespace HekaEye.SkyStudio
{
    public partial class frmSkyEditor : Form
    {
        public frmSkyEditor()
        {
            InitializeComponent();
        }

        List<IVisionProcess> _activeProcessList = new List<IVisionProcess>();

        DeviceHelper _deviceHelper = new DeviceHelper();
        CameraModel[] _cameraList = new CameraModel[0];
        HekaCaptureModel _captureData = new HekaCaptureModel();

        // SELECTION VARIABLES
        MCvScalar _regionSelectionColor = new MCvScalar(255, 0, 0);
        MCvScalar _lineSelectionColor = new MCvScalar(155, 155, 0);
        Point _hoverPoint = new Point();

        private void frmSkyEditor_Load(object sender, EventArgs e)
        {
            _cameraList = _deviceHelper.GetCameras();

            BindRecipeTree();
        }

        private void BindRecipeTree()
        {
            treeRecipe.Nodes.Clear();

            using (EyeBO bObj = new EyeBO())
            {
                var recipes = bObj.GetRecipeList();
                foreach (var recipe in recipes)
                {
                    var recipeNode = new TreeNode(recipe.RecipeName);
                    recipeNode.Tag = recipe.Id;
                    recipeNode.Name = "REC_" + recipe.Id;

                    // FILL CAMERAS AND REGIONS
                    var cameras = bObj.GetCameraList(recipe.Id);
                    foreach (var camera in cameras)
                    {
                        var cameraNode = new TreeNode(camera.CameraAlias);
                        cameraNode.Name = "CAM_" + camera.Id;
                        cameraNode.Tag = camera.Id;

                        var regions = bObj.GetRegionList(recipe.Id, camera.Id);
                        foreach (var region in regions)
                        {
                            var regionNode = new TreeNode(region.Title);
                            regionNode.Tag = region.Id;
                            regionNode.Name = "REG_" + region.Id;

                            cameraNode.Nodes.Add(regionNode);
                        }

                        recipeNode.Nodes.Add(cameraNode);
                    }

                    // FILL MODELS
                    var models = bObj.GetProductList().Where(d => d.RecipeId == recipe.Id).ToArray();
                    var modelRootNode = new TreeNode("Modeller");
                    modelRootNode.Name = "VIR_" + recipe.Id;

                    foreach (var model in models)
                    {
                        var modelNode = new TreeNode(model.ProductCode);
                        modelNode.Tag = model.Id;
                        modelNode.Name = "MOD_" + model.Id;

                        modelRootNode.Nodes.Add(modelNode);
                    }

                    recipeNode.Nodes.Add(modelRootNode);
                    treeRecipe.Nodes.Add(recipeNode);
                }
            }
        }

        private void BindStepList()
        {
            var selectedNode = treeRecipe.SelectedNode;
            
            if (selectedNode != null && selectedNode.Name.StartsWith("REG_"))
            {
                _activeProcessList.Clear();
                var regionId = (int)selectedNode.Tag;

                using (EyeBO bObj = new EyeBO())
                {
                    var steps = bObj.GetStepList(regionId).ToList();

                    foreach (var item in steps)
                    {
                        var vProc = VisionProcessManager
                            .CreateProcess((ProcessTypeList)item.ProcessType);

                        vProc.ProcParams = item.ProcessParams;
                        vProc.ProcessType = (ProcessTypeList)item.ProcessType;
                        _activeProcessList.Add(vProc);
                    }
                }

                flPanelStreamTools.Controls.Clear();
                foreach (var item in _activeProcessList)
                {
                    StreamToolItem sTool = new StreamToolItem();
                    sTool.Tag = item;
                    sTool.OnToolItemClicked += STool_OnToolItemClicked;
                    sTool.OnToolItemDeleted += STool_OnToolItemDeleted;

                    flPanelStreamTools.Controls.Add(sTool);
                }
            }
        }

        private void STool_OnToolItemDeleted(int processStepId)
        {
            
        }

        private void STool_OnToolItemClicked(object sender)
        {
            
        }

        #region TREE & MENU ACTIONS
        private void treeRecipe_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeRecipe.SelectedNode != null &&
                treeRecipe.SelectedNode.Name.StartsWith("REG_"))
            {
                BindStepList();
            }
        }

        private void tsItemRun_Click(object sender, EventArgs e)
        {
            StopCapture();
            StartCapture();
        }

        private void cmsTreeRecipe_Opening(object sender, CancelEventArgs e)
        {
            var selectedNode = treeRecipe.SelectedNode;
            if (selectedNode != null)
            {
                tsItemRepaintRegion.Visible = selectedNode.Name.StartsWith("REG_");
                tsItemRun.Visible = selectedNode.Name.StartsWith("CAM_");
            }
        }

        private void tsItemRepaintRegion_Click(object sender, EventArgs e)
        {
            if (treeRecipe.SelectedNode != null
                && treeRecipe.SelectedNode.Name.StartsWith("REG_") && _captureData != null)
            {
                _captureData.SelectionRunning = !_captureData.SelectionRunning;
                if (_captureData.SelectionRunning)
                {
                    _captureData.SelectionPath.Clear();
                    tsItemRepaintRegion.Text = "Çizimi Bitir";
                }
                else
                {
                    try
                    {
                        using (EyeBO bObj = new EyeBO())
                        {
                            var bResult = bObj.SaveRegionPath((int)treeRecipe.SelectedNode.Tag,
                                _captureData.SelectionPath.ToArray());
                        }
                    }
                    catch (Exception)
                    {

                    }
                    

                    UpdateRegionsToCapture(_captureData.CameraId);
                    tsItemRepaintRegion.Text = "Bölgeyi Çiz";

                    _captureData.SelectionPath.Clear();
                }
            }
        }

        private void tsItemNewRecipe_Click(object sender, EventArgs e)
        {
            frmSkyRecipe frm = new frmSkyRecipe();
            frm.RecordId = 0;
            frm.ShowDialog(this);

            if (frm.IsSaved)
            {
                BindRecipeTree();
            }
        }

        private void tsItemCam_Click(object sender, EventArgs e)
        {
            if (treeRecipe.SelectedNode != null
                && treeRecipe.SelectedNode.Name.StartsWith("REC_"))
            {
                frmSkyCamera frm = new frmSkyCamera();
                frm.RecordId = 0;
                frm.RecipeId = (int)treeRecipe.SelectedNode.Tag;
                frm.ShowDialog(this);

                if (frm.IsSaved)
                {
                    BindRecipeTree();
                }
            }
        }

        private void tsItemNewRegion_Click(object sender, EventArgs e)
        {
            if (treeRecipe.SelectedNode != null 
                && treeRecipe.SelectedNode.Name.StartsWith("CAM_"))
            {
                frmSkyRegion frm = new frmSkyRegion();
                frm.RecordId = 0;
                frm.CameraId = (int)treeRecipe.SelectedNode.Tag;
                frm.ShowDialog(this);

                if (frm.IsSaved)
                {
                    UpdateRegionsToCapture((int)treeRecipe.SelectedNode.Tag);
                    BindRecipeTree();
                }
            }
        }

        private void tsItemNewModel_Click(object sender, EventArgs e)
        {
            if (treeRecipe.SelectedNode != null
                && treeRecipe.SelectedNode.Name.StartsWith("REC_"))
            {
                frmSkyModel frm = new frmSkyModel();
                frm.RecordId = 0;
                frm.RecipeId = (int)treeRecipe.SelectedNode.Tag;
                frm.ShowDialog(this);

                if (frm.IsSaved)
                {
                    BindRecipeTree();
                }
            }
        }
        private void tsItemEdit_Click(object sender, EventArgs e)
        {
            var sNode = treeRecipe.SelectedNode;
            if (sNode != null)
            {
                if (sNode.Name.StartsWith("REC_"))
                {
                    frmSkyRecipe frm = new frmSkyRecipe();
                    frm.RecordId = (int)treeRecipe.SelectedNode.Tag;
                    frm.ShowDialog(this);

                    if (frm.IsSaved)
                        BindRecipeTree();
                }
                else if (sNode.Name.StartsWith("CAM_"))
                {
                    frmSkyCamera frm = new frmSkyCamera();
                    frm.RecordId = (int)treeRecipe.SelectedNode.Tag;
                    frm.ShowDialog(this);

                    if (frm.IsSaved)
                    {
                        // IF EDITING CAMERA IS THE SAME AS CURRENTLY STREAMING ONE
                        if (_captureData != null && _captureData.CameraId == (int)treeRecipe.SelectedNode.Tag)
                        {
                            StopCapture();
                            StartCapture();
                        }

                        BindRecipeTree();
                    }
                }
                else if (sNode.Name.StartsWith("REG_"))
                {
                    frmSkyRegion frm = new frmSkyRegion();
                    frm.RecordId = (int)treeRecipe.SelectedNode.Tag;
                    frm.ShowDialog(this);

                    if (frm.IsSaved)
                    {
                        UpdateRegionsToCapture(_captureData.CameraId);
                        BindRecipeTree();
                    }
                }
                else if (sNode.Name.StartsWith("MOD_"))
                {
                    frmSkyModel frm = new frmSkyModel();
                    frm.RecordId = (int)treeRecipe.SelectedNode.Tag;
                    frm.ShowDialog(this);

                    if (frm.IsSaved)
                        BindRecipeTree();
                }
            }
        }
        #endregion

        #region DATA METHODS
        private void UpdateRegionsToCapture(int cameraId)
        {
            try
            {
                using (EyeBO bObj = new EyeBO())
                {
                    RecipeCamera dbCam = bObj.GetCamera(cameraId);

                    _captureData.CameraId = dbCam.Id;
                    _captureData.RecipeId = dbCam.RecipeId;
                    _captureData.CameraName = dbCam.CameraName;
                    _captureData.Exposure = dbCam.Exposure;

                    List<HekaRegion> regions = new List<HekaRegion>();
                    var dbRegions = bObj.GetRegionList(dbCam.RecipeId, dbCam.Id);
                    foreach (var item in dbRegions)
                    {
                        var hRegion = bObj.GetRegion(item.Id);
                        regions.Add(hRegion);
                    }

                    _captureData.RegionList = regions;
                }
            }
            catch (Exception)
            {

            }
        }
        #endregion

        #region CAPTURE METHOD & EVENTS

        private void StartCapture()
        {
            try
            {
                var camId = (int)treeRecipe.SelectedNode.Tag;
                UpdateRegionsToCapture(camId);

                CameraModel capCam = _cameraList.FirstOrDefault(m => string.Equals(m.DevicePath, _captureData.CameraName));
                if (capCam != null)
                {
                    _captureData.Capture = new VideoCapture(capCam.DeviceIndex);
                    _captureData.Capture.Set(Emgu.CV.CvEnum.CapProp.Exposure, _captureData.Exposure ?? 0);
                    //_captureData.Exposure = Convert.ToInt32(_captureData.Capture.Get(Emgu.CV.CvEnum.CapProp.Exposure));
                    _captureData.CaptureRunning = true;
                    _captureData.CaptureTask = Task.Run(() => LoopCapture());
                }
            }
            catch (Exception)
            {

            }
        }

        private void StopCapture()
        {
            if (_captureData != null && _captureData.CaptureRunning 
                && _captureData.CaptureTask != null)
            {
                try
                {
                    _captureData.CaptureRunning = false;
                    _captureData.Capture.Stop();
                    _captureData.Capture.Dispose();
                    _captureData.CaptureTask.Dispose();
                }
                catch (Exception ex)
                {

                }
            }
        }

        private async Task LoopCapture()
        {
            while (true)
            {
                if (_captureData.CaptureRunning)
                {
                    try
                    {
                        var data = _captureData;
                        var frame = data.Capture.QueryFrame();
                        var cloneFrame = frame.Clone();

                        var gray = new Mat(frame.Rows, frame.Cols, Emgu.CV.CvEnum.DepthType.Cv32F, 1);
                        CvInvoke.CvtColor(cloneFrame, gray, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);

                        #region DRAW ACTIVE SELECTION
                        if (data.SelectionRunning && data.SelectionPath.Count() > 0)
                        {
                            var pLeft = Convert.ToInt32((imgActiveCapture.Width - frame.Width) / 2.0);
                            var pTop = Convert.ToInt32((imgActiveCapture.Height - frame.Height) / 2.0);

                            int _selectionPathPointIndex = 0;
                            foreach (var pathPoint in data.SelectionPath)
                            {
                                if (data.SelectionPath.Count() - 1 > _selectionPathPointIndex)
                                {
                                    var nextPoint = data.SelectionPath[_selectionPathPointIndex + 1];

                                    var pntCurrent = new Point(
                                       Convert.ToInt32(pathPoint.X) - pLeft,
                                       Convert.ToInt32(pathPoint.Y) - pTop);
                                    var pntNext = new Point(Convert.ToInt32(nextPoint.X) - pLeft, Convert.ToInt32(nextPoint.Y) - pTop);

                                    CvInvoke.Line(frame, pntCurrent,
                                           pntNext,
                                           _regionSelectionColor, 1, Emgu.CV.CvEnum.LineType.EightConnected);

                                    CvInvoke.Rectangle(frame, new Rectangle(pntCurrent.X - 2, pntCurrent.Y - 2, 5, 5),
                                        new MCvScalar(255, 50, 0), 2);
                                    CvInvoke.Rectangle(frame, new Rectangle(pntNext.X - 2, pntNext.Y - 2, 5, 5),
                                        new MCvScalar(255, 50, 0), 2);
                                }
                                else if (_hoverPoint != Point.Empty)
                                {
                                    var pntCurrent = new Point(
                                       Convert.ToInt32(pathPoint.X) - pLeft,
                                       Convert.ToInt32(pathPoint.Y) - pTop);
                                    var pntNext = new Point(Convert.ToInt32(_hoverPoint.X) - pLeft, Convert.ToInt32(_hoverPoint.Y) - pTop);

                                    CvInvoke.Line(frame, pntCurrent,
                                           pntNext,
                                          _regionSelectionColor, 1, Emgu.CV.CvEnum.LineType.EightConnected);

                                    CvInvoke.Rectangle(frame, new Rectangle(pntCurrent.X - 2, pntCurrent.Y - 2, 5, 5),
                                        new MCvScalar(255, 50, 0), 2);
                                }

                                _selectionPathPointIndex++;
                            }
                        }
                        #endregion

                        #region DRAW & CHECK SAVED REGIONS
                        foreach (var region in data.RegionList)
                        {
                            Mat maskedRegion = Mat.Zeros(gray.Rows, gray.Cols, Emgu.CV.CvEnum.DepthType.Cv8U, region.ConvertToHsv ? 3 : 1);

                            var pLeft = Convert.ToInt32((imgActiveCapture.Width - frame.Width) / 2.0);
                            var pTop = Convert.ToInt32((imgActiveCapture.Height - frame.Height) / 2.0);

                            // CROP SELECTED ROI
                            if (region.RegionType == 1)
                            {
                                Mat maskZeros = Mat.Zeros(gray.Rows, gray.Cols, Emgu.CV.CvEnum.DepthType.Cv8U, region.ConvertToHsv ? 3 : 1);

                                List<Point> translatedPointsI = new List<Point>();
                                for (int i = 0; i < region.Path.Length; i++)
                                {
                                    var rPoint = region.Path[i];
                                    if (region.OffsetX != 0)
                                        rPoint.X += region.OffsetX;
                                    if (region.OffsetY != 0)
                                        rPoint.Y += region.OffsetY;

                                    translatedPointsI.Add(new Point(rPoint.X - pLeft, rPoint.Y - pTop));
                                }

                                if (translatedPointsI.Count() > 0)
                                {
                                    VectorOfVectorOfPoint contour
                                                  = new VectorOfVectorOfPoint(new VectorOfPoint(translatedPointsI.ToArray()));
                                    CvInvoke.DrawContours(maskZeros, contour, 0, new MCvScalar(255), -1);
                                    CvInvoke.BitwiseAnd(gray, maskZeros, maskedRegion);

                                    CvInvoke.DrawContours(frame, contour, -1, new MCvScalar(255, 0, 0), 1);

                                    maskZeros.Dispose();
                                    translatedPointsI.Clear();
                                }
                                else
                                    maskedRegion.Dispose();
                            }

                        }

                        #endregion

                        this.BeginInvoke((Action)delegate
                        {
                            imgActiveCapture.Image = frame;
                            frame.Dispose();
                            cloneFrame.Dispose();
                            gray.Dispose();
                        });
                    }
                    catch (Exception ex)
                    {

                    }


                }
                else
                    break;

                await Task.Delay(50);
            }
        }

        #endregion

        #region CAPTURE BOX MOUSE EVENTS
        private void imgBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (_captureData != null 
                && _captureData.SelectionRunning 
                && !_captureData.SelectionStepRunning)
            {
                _captureData.SelectionStepRunning = true;

                if (_captureData.SelectionPath.Count() == 0)
                    _captureData.SelectionPath.Add(new Point(e.X, e.Y));
                else
                {
                    var pntDown = new Point(e.X, e.Y);
                    if (_hoverPoint == Point.Empty || _hoverPoint.X != _hoverPoint.X || _hoverPoint.Y != _hoverPoint.Y)
                        _hoverPoint = pntDown;
                }
            }
        }

        private void imgBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (_captureData != null)
            {
                if (_captureData.SelectionRunning && _captureData.SelectionStepRunning)
                {
                    _hoverPoint = new Point(e.X, e.Y);
                    //lblX.Text = e.X.ToString();
                    //lblY.Text = e.Y.ToString();
                }
            }
        }

        private void imgBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (_captureData != null
                && _captureData.SelectionRunning && _captureData.SelectionStepRunning)
            {
                _captureData.SelectionStepRunning = false;

                if (_hoverPoint != Point.Empty)
                    _captureData.SelectionPath.Add(_hoverPoint);

                // CLOSE SHAPE
                if (_captureData.SelectionType == 1 && _captureData.SelectionPath.Count() > 0)
                {
                    var startPoint = _captureData.SelectionPath[0];
                    _captureData.SelectionPath.Add(new Point(startPoint.X, startPoint.Y));
                }

                _hoverPoint = Point.Empty;
            }
        }

        #endregion

        private void frmSkyEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopCapture();
        }

        private void btnCvTools_Click(object sender, EventArgs e)
        {
            if (treeRecipe.SelectedNode != null &&
                treeRecipe.SelectedNode.Name.StartsWith("REG_"))
            {
                try
                {
                    using (EyeBO bObj = new EyeBO())
                    {
                        var cStepList = bObj.GetStepList((int)treeRecipe.SelectedNode.Tag);
                        int maxOrder = cStepList.Any() ?
                            cStepList.Max(d => d.OrderNo) : 0;

                        var res = bObj.SaveStep(new ProcessStep
                        {
                            RegionId = (int)treeRecipe.SelectedNode.Tag,
                            ProcessType = Convert.ToInt32((sender as KryptonButton).Tag),
                            OrderNo = maxOrder++,
                        });

                        if (!res.Result)
                            throw new Exception(res.ErrorMessage);
                    }

                    BindStepList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
