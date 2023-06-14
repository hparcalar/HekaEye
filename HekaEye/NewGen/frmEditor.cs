using DevExpress.XtraEditors;
using HekaEye.Models;
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
using HekaEye.NewGen.Map;
using HekaEye.Helpers;

namespace HekaEye.NewGen
{
    public partial class frmEditor : Form
    {
        public frmEditor()
        {
            InitializeComponent();
        }

        // data flags
        private NewGenBO _businessObject = new NewGenBO();
        private int _programId = 0;
        private HkProgramModel _programModel;
        private object _prpObject;
        private int _programMode = 0; // 0: edit mode, 1: run mode

        // drag & drop flags
        private bool _isToolMouseDown = false;
        private bool _dragBetweenToolsStarted = false;

        private void frmEditor_Load(object sender, EventArgs e)
        {
            this.LoadProgram();
        }

        private void LoadProgram()
        {
            this._programModel = _businessObject.GetProgram(_programId);

            if (this._programModel != null)
            {
                lblProgramTitle.Text = this._programModel.ProgramName;
                foreach (var item in this._programModel.Tools)
                {
                    item.ToolObject = HkToolTypes.GetToolObject(item.ToolSettings, item.ToolType ?? 0);
                    item.ToolObject.ToolName = item.ToolName;
                }
            }
            else
            {
                lblProgramTitle.Text = "Program 000";
            }

            this.CheckProgramMode();
            this.PlaceTools();
        }

        private void SaveProgram()
        {
            _businessObject.SaveProgram(this._programModel);
        }

        private void PlaceTools()
        {
            this.flPanelTools.Controls.Clear();
            if (this._programModel != null && this._programModel.Tools != null)
            {
                var orderedTools = this._programModel.Tools.OrderBy(d => d.ToolOrder).ToArray();
                foreach (var item in orderedTools)
                {
                    SimpleButton btnTool = new SimpleButton();
                    btnTool.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.True;
                    btnTool.Text = "<b>"+ item.ToolOrder +" - </b><i>" + HkToolTypes.GetToolTypeText(item.ToolType ?? 0) + "</i>" + "<b> " + item.ToolName + "</b>";
                    btnTool.Width = flPanelTools.Width - 10;
                    btnTool.Height = 50;
                    btnTool.MouseDown += BtnTool_MouseDown;
                    btnTool.MouseMove += BtnTool_MouseMove;
                    btnTool.MouseUp += BtnTool_MouseUp;
                    btnTool.Click += BtnTool_Click;
                    btnTool.DragEnter += BtnTool_DragEnter;
                    btnTool.DragDrop += BtnTool_DragDrop;
                    btnTool.Tag = item;
                    btnTool.AllowDrop = true;
                    flPanelTools.Controls.Add(btnTool);
                }
            }
        }

        private void CheckProgramMode()
        {
            if (this._programMode == 0)
            {
                btnRunMode.Enabled = true;
                btnEditMode.Enabled = false;
            }
            else
            {
                btnRunMode.Enabled = false;
                btnEditMode.Enabled = true;
            }
        }

        private void UpdateToolsView()
        {
            var controls = this.flPanelTools.Controls;
            foreach (Control item in controls)
            {
                var data = (item as SimpleButton).Tag as HkToolModel;
                (item as SimpleButton).Text = "<b>" + data.ToolOrder + " - </b><i>" + HkToolTypes.GetToolTypeText(data.ToolType ?? 0) + "</i>" + "<b> " + data.ToolName + "</b>";
                if (item.Tag.GetHashCode() == this._prpObject.GetHashCode())
                {
                    (item as SimpleButton).Appearance.BackColor = Color.DodgerBlue;
                    (item as SimpleButton).Appearance.Options.UseBackColor = true;
                }
                else
                {
                    (item as SimpleButton).Appearance.BackColor = Color.Empty;
                    (item as SimpleButton).Appearance.Options.UseBackColor = false;
                    (item as SimpleButton).Refresh();
                }
            }
        }


        #region TOOL DRAG & DROP EVENTS
        private void BtnTool_Click(object sender, EventArgs e)
        {
            this._prpObject = (sender as SimpleButton).Tag;
            this.prpGrid.SelectedObject = (this._prpObject as HkToolModel).ToolObject;
            this.UpdateToolsView();
        }

        private void BtnTool_MouseMove(object sender, MouseEventArgs e)
        {
            SimpleButton actorTool = sender as SimpleButton;
            if (this._isToolMouseDown && !this._dragBetweenToolsStarted)
            {
                this._dragBetweenToolsStarted = true;
                actorTool.DoDragDrop(actorTool.Tag, DragDropEffects.Move);
            }
        }

        private void BtnTool_MouseDown(object sender, MouseEventArgs e)
        {
            this._isToolMouseDown = true;
        }

        private void BtnTool_MouseUp(object sender, MouseEventArgs e)
        {
            this._isToolMouseDown = false;
        }

        private void BtnTool_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data != null && this._dragBetweenToolsStarted)
            {
                e.Effect = DragDropEffects.None;
                this._dragBetweenToolsStarted = false;
                this._isToolMouseDown = false;
                var currentData = (sender as SimpleButton).Tag as HkToolModel;

                if (e.Data.GetDataPresent(typeof(HkToolModel)))
                {
                    var dropData = e.Data.GetData(typeof(HkToolModel)) as HkToolModel;

                    bool increase = false;
                    if (dropData.ToolOrder > currentData.ToolOrder)
                        increase = true;

                    dropData.ToolOrder = currentData.ToolOrder;

                    if (increase)
                        currentData.ToolOrder++;
                    else
                        currentData.ToolOrder--;

                    var afterList = _programModel.Tools.Where(d => d.ToolOrder > dropData.ToolOrder && d != currentData);
                    foreach (var item in afterList)
                    {
                        item.ToolOrder++;
                    }

                    int newOrder = 1;
                    var orderedList = _programModel.Tools.OrderBy(d => d.ToolOrder);
                    foreach (var item in orderedList)
                    {
                        item.ToolOrder = newOrder;
                        newOrder++;
                    }

                    this.PlaceTools();
                }
                else if (e.Data.GetDataPresent(typeof(string)))
                {

                }
            }
        }

        private void BtnTool_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void flPanelTools_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data != null && !_dragBetweenToolsStarted)
            {
                if (e.Data.GetDataPresent(typeof(string)))
                {
                    var newTool = new HkToolModel
                    {
                        ToolType = Convert.ToInt32(e.Data.GetData(typeof(string))),
                        ToolOrder = (this._programModel.Tools.Max(d => d.ToolOrder) ?? 0) + 1,
                        ToolName = HkToolTypes.GetToolTypeText(Convert.ToInt32(e.Data.GetData(typeof(string)))) + "_" + ((_programModel.Tools.Where(d => d.ToolType == Convert.ToInt32(e.Data.GetData(typeof(string)))).Max(d => d.ToolOrder) ?? 0) + 1).ToString(),
                        ToolObject = HkToolTypes.GetToolObject("", Convert.ToInt32(e.Data.GetData(typeof(string)))),
                    };
                    newTool.ToolObject.ToolName = newTool.ToolName;
                    this._programModel.Tools.Add(newTool);
                    this.PlaceTools();
                    this._prpObject = newTool;
                    this.prpGrid.SelectedObject = (this._prpObject as HkToolModel).ToolObject;
                    this.UpdateToolsView();

                    //int cIndex = toolboxControlTools.SelectedGroupIndex;
                    toolboxControlTools.SelectedGroupIndex = -1;
                    //toolboxControlTools.SelectedGroupIndex = cIndex;
                }
                else if (e.Data.GetDataPresent(typeof(HkToolModel)))
                {

                }
            }
        }

        private void flPanelTools_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void flPanelTools_DragOver(object sender, DragEventArgs e)
        {
            
        }

        private void toolboxControlTools_ItemDoubleClick(object sender, DevExpress.XtraToolbox.ToolboxItemDoubleClickEventArgs e)
        {
            var newTool = new HkToolModel
            {
                ToolType = Convert.ToInt32(e.Item.Tag.ToString()),
                ToolOrder = (this._programModel.Tools.Max(d => d.ToolOrder) ?? 0) + 1,
                ToolName = HkToolTypes.GetToolTypeText(Convert.ToInt32(e.Item.Tag.ToString())) + "_" + ((_programModel.Tools.Where(d => d.ToolType == Convert.ToInt32(e.Item.Tag.ToString())).Max(d => d.ToolOrder) ?? 0) + 1).ToString(),
                ToolObject = HkToolTypes.GetToolObject("", Convert.ToInt32(e.Item.Tag.ToString())),
            };
            newTool.ToolObject.ToolName = newTool.ToolName;
            this._programModel.Tools.Add(newTool);
            this.PlaceTools();
            this._prpObject = newTool;
            this.prpGrid.SelectedObject = (this._prpObject as HkToolModel).ToolObject;
            this.UpdateToolsView();
        }

        private void toolboxControlTools_DragItemStart(object sender, DevExpress.XtraToolbox.ToolboxDragItemStartEventArgs e)
        {
            (sender as DevExpress.XtraToolbox.ToolboxControl).DoDragDrop(e.Item.Tag, DragDropEffects.Move);
        }

        private void toolboxControlTools_DragItemDrop(object sender, DevExpress.XtraToolbox.ToolboxDragItemDropEventArgs e)
        {
            
        }

        private void prpGrid_CellValueChanged(object sender, DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs e)
        {
            (this._prpObject as HkToolModel).ToolSettings = HkToolTypes.SerializeToolSpecs(prpGrid.SelectedObject);
            (this._prpObject as HkToolModel).ToolName = (this._prpObject as HkToolModel).ToolObject.ToolName;
            this.UpdateToolsView();
        }

        #endregion

        private void btnSaveProgram_Click(object sender, EventArgs e)
        {
            this.SaveProgram();
        }

        private void tsItemDeleteTool_Click(object sender, EventArgs e)
        {
            if (this._prpObject != null && this._prpObject.GetType() == typeof(HkToolModel) 
                && MessageBox.Show("Bu aracı silmek istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this._programModel.Tools = this._programModel.Tools.Where(d => d != this._prpObject).ToArray();

                int newOrder = 1;
                var orderedList = _programModel.Tools.OrderBy(d => d.ToolOrder);
                foreach (var item in orderedList)
                {
                    item.ToolOrder = newOrder;
                    newOrder++;
                }

                this.PlaceTools();
            }
        }

        private void tsItemProgramProperties_Click(object sender, EventArgs e)
        {
            this._prpObject = null;
            this.prpGrid.SelectedObject = this._programModel;
        }

        private void btnSelectCamera_Click(object sender, EventArgs e)
        {
            frmCameraList frm = new frmCameraList();
            frm.ShowDialog(this);

            if (frm.SelectedCamera != null)
            {
                this._programModel.CameraName = frm.SelectedCamera.DevicePath;
                if (prpGrid.SelectedObject == this._programModel)
                {
                    prpGrid.SelectedObject = null;
                    prpGrid.SelectedObject = this._programModel;
                }
            }
        }

        private void btnRunMode_Click(object sender, EventArgs e)
        {
            this._programMode = 1;
            this.CheckProgramMode();
        }

        private void btnEditMode_Click(object sender, EventArgs e)
        {
            this._programMode = 0;
            this.CheckProgramMode();
        }
    }
}
