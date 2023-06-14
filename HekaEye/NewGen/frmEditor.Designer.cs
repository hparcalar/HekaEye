
namespace HekaEye.NewGen
{
    partial class frmEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditor));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.programToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsItemSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.gbProgramTools = new System.Windows.Forms.GroupBox();
            this.splitterRight = new System.Windows.Forms.SplitContainer();
            this.toolboxControlTools = new DevExpress.XtraToolbox.ToolboxControl();
            this.prpGrid = new DevExpress.XtraVerticalGrid.PropertyGridControl();
            this.btnRunMode = new DevExpress.XtraEditors.SimpleButton();
            this.btnEditMode = new DevExpress.XtraEditors.SimpleButton();
            this.lstOutput = new DevExpress.XtraEditors.ListBoxControl();
            this.label1 = new System.Windows.Forms.Label();
            this.tsItemNewProgram = new System.Windows.Forms.ToolStripMenuItem();
            this.tsItemChangeProgram = new System.Windows.Forms.ToolStripMenuItem();
            this.tsItemDeleteProgram = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsItemProgramProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSaveProgram = new DevExpress.XtraEditors.SimpleButton();
            this.pnlCamera = new System.Windows.Forms.Panel();
            this.toolboxGroup1 = new DevExpress.XtraToolbox.ToolboxGroup();
            this.toolboxGroup2 = new DevExpress.XtraToolbox.ToolboxGroup();
            this.toolboxGroup3 = new DevExpress.XtraToolbox.ToolboxGroup();
            this.toolboxGroup4 = new DevExpress.XtraToolbox.ToolboxGroup();
            this.toolGauss = new DevExpress.XtraToolbox.ToolboxItem();
            this.toolErode = new DevExpress.XtraToolbox.ToolboxItem();
            this.toolDilate = new DevExpress.XtraToolbox.ToolboxItem();
            this.toolMorhpOpen = new DevExpress.XtraToolbox.ToolboxItem();
            this.toolMorphClose = new DevExpress.XtraToolbox.ToolboxItem();
            this.toolRectangle = new DevExpress.XtraToolbox.ToolboxItem();
            this.toolPolygon = new DevExpress.XtraToolbox.ToolboxItem();
            this.toolThreshold = new DevExpress.XtraToolbox.ToolboxItem();
            this.toolPatternMatch = new DevExpress.XtraToolbox.ToolboxItem();
            this.toolCmpNumeric = new DevExpress.XtraToolbox.ToolboxItem();
            this.toolCmpBool = new DevExpress.XtraToolbox.ToolboxItem();
            this.toolOutTcpIp = new DevExpress.XtraToolbox.ToolboxItem();
            this.toolOutModbusTcp = new DevExpress.XtraToolbox.ToolboxItem();
            this.toolOutDigital = new DevExpress.XtraToolbox.ToolboxItem();
            this.toolOutHttp = new DevExpress.XtraToolbox.ToolboxItem();
            this.lblProgramTitle = new System.Windows.Forms.Label();
            this.flPanelTools = new System.Windows.Forms.FlowLayoutPanel();
            this.tsItemDeleteTool = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSelectCamera = new DevExpress.XtraEditors.SimpleButton();
            this.menuStrip1.SuspendLayout();
            this.gbProgramTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitterRight)).BeginInit();
            this.splitterRight.Panel1.SuspendLayout();
            this.splitterRight.Panel2.SuspendLayout();
            this.splitterRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prpGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstOutput)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programToolStripMenuItem,
            this.tsItemEdit,
            this.tsItemSettings});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1076, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // programToolStripMenuItem
            // 
            this.programToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsItemNewProgram,
            this.tsItemChangeProgram,
            this.tsItemDeleteProgram,
            this.toolStripSeparator1,
            this.tsItemProgramProperties});
            this.programToolStripMenuItem.Name = "programToolStripMenuItem";
            this.programToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.programToolStripMenuItem.Text = "Program";
            // 
            // tsItemEdit
            // 
            this.tsItemEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsItemDeleteTool});
            this.tsItemEdit.Name = "tsItemEdit";
            this.tsItemEdit.Size = new System.Drawing.Size(61, 20);
            this.tsItemEdit.Text = "Düzenle";
            // 
            // tsItemSettings
            // 
            this.tsItemSettings.Name = "tsItemSettings";
            this.tsItemSettings.Size = new System.Drawing.Size(56, 20);
            this.tsItemSettings.Text = "Ayarlar";
            // 
            // gbProgramTools
            // 
            this.gbProgramTools.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbProgramTools.Controls.Add(this.flPanelTools);
            this.gbProgramTools.Location = new System.Drawing.Point(12, 38);
            this.gbProgramTools.Name = "gbProgramTools";
            this.gbProgramTools.Size = new System.Drawing.Size(218, 547);
            this.gbProgramTools.TabIndex = 1;
            this.gbProgramTools.TabStop = false;
            this.gbProgramTools.Text = "Program Araçları";
            // 
            // splitterRight
            // 
            this.splitterRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitterRight.Location = new System.Drawing.Point(775, 38);
            this.splitterRight.Name = "splitterRight";
            this.splitterRight.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitterRight.Panel1
            // 
            this.splitterRight.Panel1.Controls.Add(this.toolboxControlTools);
            // 
            // splitterRight.Panel2
            // 
            this.splitterRight.Panel2.Controls.Add(this.prpGrid);
            this.splitterRight.Size = new System.Drawing.Size(289, 547);
            this.splitterRight.SplitterDistance = 273;
            this.splitterRight.TabIndex = 2;
            // 
            // toolboxControlTools
            // 
            this.toolboxControlTools.Caption = "";
            this.toolboxControlTools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolboxControlTools.Groups.Add(this.toolboxGroup1);
            this.toolboxControlTools.Groups.Add(this.toolboxGroup2);
            this.toolboxControlTools.Groups.Add(this.toolboxGroup3);
            this.toolboxControlTools.Groups.Add(this.toolboxGroup4);
            this.toolboxControlTools.Location = new System.Drawing.Point(0, 0);
            this.toolboxControlTools.Name = "toolboxControlTools";
            this.toolboxControlTools.Size = new System.Drawing.Size(289, 273);
            this.toolboxControlTools.TabIndex = 0;
            this.toolboxControlTools.ItemDoubleClick += new DevExpress.XtraToolbox.ToolboxItemDoubleClickEventHandler(this.toolboxControlTools_ItemDoubleClick);
            this.toolboxControlTools.DragItemDrop += new DevExpress.XtraToolbox.ToolboxDragItemDropEventHandler(this.toolboxControlTools_DragItemDrop);
            this.toolboxControlTools.DragItemStart += new DevExpress.XtraToolbox.ToolboxDragItemStartEventHandler(this.toolboxControlTools_DragItemStart);
            // 
            // prpGrid
            // 
            this.prpGrid.Cursor = System.Windows.Forms.Cursors.Default;
            this.prpGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prpGrid.Location = new System.Drawing.Point(0, 0);
            this.prpGrid.Name = "prpGrid";
            this.prpGrid.Size = new System.Drawing.Size(289, 270);
            this.prpGrid.TabIndex = 0;
            this.prpGrid.CellValueChanged += new DevExpress.XtraVerticalGrid.Events.CellValueChangedEventHandler(this.prpGrid_CellValueChanged);
            // 
            // btnRunMode
            // 
            this.btnRunMode.Appearance.Options.UseImage = true;
            this.btnRunMode.AutoSize = true;
            this.btnRunMode.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnRun.ImageOptions.Image")));
            this.btnRunMode.Location = new System.Drawing.Point(239, 38);
            this.btnRunMode.Name = "btnRunMode";
            this.btnRunMode.Size = new System.Drawing.Size(38, 36);
            this.btnRunMode.TabIndex = 3;
            this.btnRunMode.Click += new System.EventHandler(this.btnRunMode_Click);
            // 
            // btnEditMode
            // 
            this.btnEditMode.Appearance.Options.UseImage = true;
            this.btnEditMode.AutoSize = true;
            this.btnEditMode.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage")));
            this.btnEditMode.Location = new System.Drawing.Point(283, 38);
            this.btnEditMode.Name = "btnEditMode";
            this.btnEditMode.Size = new System.Drawing.Size(38, 36);
            this.btnEditMode.TabIndex = 4;
            this.btnEditMode.Click += new System.EventHandler(this.btnEditMode_Click);
            // 
            // lstOutput
            // 
            this.lstOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstOutput.Location = new System.Drawing.Point(236, 427);
            this.lstOutput.Name = "lstOutput";
            this.lstOutput.Size = new System.Drawing.Size(533, 158);
            this.lstOutput.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(233, 411);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Program Çıktıları";
            // 
            // tsItemNewProgram
            // 
            this.tsItemNewProgram.Name = "tsItemNewProgram";
            this.tsItemNewProgram.Size = new System.Drawing.Size(180, 22);
            this.tsItemNewProgram.Text = "Yeni Program";
            // 
            // tsItemChangeProgram
            // 
            this.tsItemChangeProgram.Name = "tsItemChangeProgram";
            this.tsItemChangeProgram.Size = new System.Drawing.Size(180, 22);
            this.tsItemChangeProgram.Text = "Program Değiştir";
            // 
            // tsItemDeleteProgram
            // 
            this.tsItemDeleteProgram.Name = "tsItemDeleteProgram";
            this.tsItemDeleteProgram.Size = new System.Drawing.Size(180, 22);
            this.tsItemDeleteProgram.Text = "Programı Sil";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // tsItemProgramProperties
            // 
            this.tsItemProgramProperties.Name = "tsItemProgramProperties";
            this.tsItemProgramProperties.Size = new System.Drawing.Size(180, 22);
            this.tsItemProgramProperties.Text = "Program Özellikleri";
            this.tsItemProgramProperties.Click += new System.EventHandler(this.tsItemProgramProperties_Click);
            // 
            // btnSaveProgram
            // 
            this.btnSaveProgram.Appearance.Options.UseImage = true;
            this.btnSaveProgram.AutoSize = true;
            this.btnSaveProgram.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton2.ImageOptions.SvgImage")));
            this.btnSaveProgram.Location = new System.Drawing.Point(327, 38);
            this.btnSaveProgram.Name = "btnSaveProgram";
            this.btnSaveProgram.Size = new System.Drawing.Size(38, 36);
            this.btnSaveProgram.TabIndex = 7;
            this.btnSaveProgram.Click += new System.EventHandler(this.btnSaveProgram_Click);
            // 
            // pnlCamera
            // 
            this.pnlCamera.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCamera.Location = new System.Drawing.Point(236, 92);
            this.pnlCamera.Name = "pnlCamera";
            this.pnlCamera.Size = new System.Drawing.Size(533, 301);
            this.pnlCamera.TabIndex = 8;
            // 
            // toolboxGroup1
            // 
            this.toolboxGroup1.Caption = "Filtre Araçları";
            this.toolboxGroup1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("toolboxGroup1.ImageOptions.SvgImage")));
            this.toolboxGroup1.Items.Add(this.toolGauss);
            this.toolboxGroup1.Items.Add(this.toolErode);
            this.toolboxGroup1.Items.Add(this.toolDilate);
            this.toolboxGroup1.Items.Add(this.toolMorhpOpen);
            this.toolboxGroup1.Items.Add(this.toolMorphClose);
            this.toolboxGroup1.Name = "toolboxGroup1";
            // 
            // toolboxGroup2
            // 
            this.toolboxGroup2.Caption = "Görüntü İşleme Araçları";
            this.toolboxGroup2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("toolboxGroup2.ImageOptions.SvgImage")));
            this.toolboxGroup2.Items.Add(this.toolRectangle);
            this.toolboxGroup2.Items.Add(this.toolPolygon);
            this.toolboxGroup2.Items.Add(this.toolThreshold);
            this.toolboxGroup2.Items.Add(this.toolPatternMatch);
            this.toolboxGroup2.Name = "toolboxGroup2";
            // 
            // toolboxGroup3
            // 
            this.toolboxGroup3.Caption = "Karşılaştırma Araçları";
            this.toolboxGroup3.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("toolboxGroup3.ImageOptions.SvgImage")));
            this.toolboxGroup3.Items.Add(this.toolCmpNumeric);
            this.toolboxGroup3.Items.Add(this.toolCmpBool);
            this.toolboxGroup3.Name = "toolboxGroup3";
            // 
            // toolboxGroup4
            // 
            this.toolboxGroup4.Caption = "Çıktı Araçları";
            this.toolboxGroup4.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("toolboxGroup4.ImageOptions.SvgImage")));
            this.toolboxGroup4.Items.Add(this.toolOutTcpIp);
            this.toolboxGroup4.Items.Add(this.toolOutModbusTcp);
            this.toolboxGroup4.Items.Add(this.toolOutDigital);
            this.toolboxGroup4.Items.Add(this.toolOutHttp);
            this.toolboxGroup4.Name = "toolboxGroup4";
            // 
            // toolGauss
            // 
            this.toolGauss.Caption = "Gauss";
            this.toolGauss.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("toolboxItem1.ImageOptions.Image")));
            this.toolGauss.Name = "toolGauss";
            this.toolGauss.Tag = "1";
            // 
            // toolErode
            // 
            this.toolErode.Caption = "Erode";
            this.toolErode.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("toolboxItem2.ImageOptions.Image")));
            this.toolErode.Name = "toolErode";
            this.toolErode.Tag = "2";
            // 
            // toolDilate
            // 
            this.toolDilate.Caption = "Dilate";
            this.toolDilate.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("toolboxItem3.ImageOptions.Image")));
            this.toolDilate.Name = "toolDilate";
            this.toolDilate.Tag = "3";
            // 
            // toolMorhpOpen
            // 
            this.toolMorhpOpen.Caption = "Morph Open";
            this.toolMorhpOpen.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("toolboxItem4.ImageOptions.Image")));
            this.toolMorhpOpen.Name = "toolMorhpOpen";
            this.toolMorhpOpen.Tag = "4";
            // 
            // toolMorphClose
            // 
            this.toolMorphClose.Caption = "Morph Close";
            this.toolMorphClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("toolboxItem5.ImageOptions.Image")));
            this.toolMorphClose.Name = "toolMorphClose";
            this.toolMorphClose.Tag = "5";
            // 
            // toolRectangle
            // 
            this.toolRectangle.Caption = "Rectangle";
            this.toolRectangle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("toolboxItem6.ImageOptions.Image")));
            this.toolRectangle.Name = "toolRectangle";
            this.toolRectangle.Tag = "6";
            // 
            // toolPolygon
            // 
            this.toolPolygon.Caption = "Polygon";
            this.toolPolygon.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("toolboxItem7.ImageOptions.SvgImage")));
            this.toolPolygon.Name = "toolPolygon";
            this.toolPolygon.Tag = "7";
            // 
            // toolThreshold
            // 
            this.toolThreshold.Caption = "Threshold";
            this.toolThreshold.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("toolboxItem8.ImageOptions.SvgImage")));
            this.toolThreshold.Name = "toolThreshold";
            this.toolThreshold.Tag = "8";
            // 
            // toolPatternMatch
            // 
            this.toolPatternMatch.Caption = "Pattern Match";
            this.toolPatternMatch.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("toolboxItem9.ImageOptions.SvgImage")));
            this.toolPatternMatch.Name = "toolPatternMatch";
            this.toolPatternMatch.Tag = "9";
            // 
            // toolCmpNumeric
            // 
            this.toolCmpNumeric.Caption = "Numeric Compare";
            this.toolCmpNumeric.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("toolboxItem10.ImageOptions.SvgImage")));
            this.toolCmpNumeric.Name = "toolCmpNumeric";
            this.toolCmpNumeric.Tag = "10";
            // 
            // toolCmpBool
            // 
            this.toolCmpBool.Caption = "Bool Compare";
            this.toolCmpBool.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("toolboxItem11.ImageOptions.SvgImage")));
            this.toolCmpBool.Name = "toolCmpBool";
            this.toolCmpBool.Tag = "11";
            // 
            // toolOutTcpIp
            // 
            this.toolOutTcpIp.Caption = "TCP/IP";
            this.toolOutTcpIp.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("toolboxItem12.ImageOptions.SvgImage")));
            this.toolOutTcpIp.Name = "toolOutTcpIp";
            this.toolOutTcpIp.Tag = "12";
            // 
            // toolOutModbusTcp
            // 
            this.toolOutModbusTcp.Caption = "Modbus TCP";
            this.toolOutModbusTcp.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("toolboxItem13.ImageOptions.SvgImage")));
            this.toolOutModbusTcp.Name = "toolOutModbusTcp";
            this.toolOutModbusTcp.Tag = "13";
            // 
            // toolOutDigital
            // 
            this.toolOutDigital.Caption = "Digital Output";
            this.toolOutDigital.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("toolboxItem14.ImageOptions.SvgImage")));
            this.toolOutDigital.Name = "toolOutDigital";
            this.toolOutDigital.Tag = "14";
            // 
            // toolOutHttp
            // 
            this.toolOutHttp.Caption = "HTTP";
            this.toolOutHttp.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("toolboxItem15.ImageOptions.SvgImage")));
            this.toolOutHttp.Name = "toolOutHttp";
            this.toolOutHttp.Tag = "15";
            // 
            // lblProgramTitle
            // 
            this.lblProgramTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblProgramTitle.Location = new System.Drawing.Point(419, 38);
            this.lblProgramTitle.Name = "lblProgramTitle";
            this.lblProgramTitle.Size = new System.Drawing.Size(350, 36);
            this.lblProgramTitle.TabIndex = 9;
            this.lblProgramTitle.Text = "Program 000";
            this.lblProgramTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flPanelTools
            // 
            this.flPanelTools.AllowDrop = true;
            this.flPanelTools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flPanelTools.Location = new System.Drawing.Point(3, 16);
            this.flPanelTools.Name = "flPanelTools";
            this.flPanelTools.Size = new System.Drawing.Size(212, 528);
            this.flPanelTools.TabIndex = 0;
            this.flPanelTools.DragDrop += new System.Windows.Forms.DragEventHandler(this.flPanelTools_DragDrop);
            this.flPanelTools.DragEnter += new System.Windows.Forms.DragEventHandler(this.flPanelTools_DragEnter);
            this.flPanelTools.DragOver += new System.Windows.Forms.DragEventHandler(this.flPanelTools_DragOver);
            // 
            // tsItemDeleteTool
            // 
            this.tsItemDeleteTool.Name = "tsItemDeleteTool";
            this.tsItemDeleteTool.Size = new System.Drawing.Size(180, 22);
            this.tsItemDeleteTool.Text = "Aracı Sil";
            this.tsItemDeleteTool.Click += new System.EventHandler(this.tsItemDeleteTool_Click);
            // 
            // btnSelectCamera
            // 
            this.btnSelectCamera.Appearance.Options.UseImage = true;
            this.btnSelectCamera.AutoSize = true;
            this.btnSelectCamera.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("simpleButton1.ImageOptions.SvgImage")));
            this.btnSelectCamera.Location = new System.Drawing.Point(371, 38);
            this.btnSelectCamera.Name = "btnSelectCamera";
            this.btnSelectCamera.Size = new System.Drawing.Size(38, 36);
            this.btnSelectCamera.TabIndex = 10;
            this.btnSelectCamera.Click += new System.EventHandler(this.btnSelectCamera_Click);
            // 
            // frmEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1076, 597);
            this.Controls.Add(this.btnSelectCamera);
            this.Controls.Add(this.lblProgramTitle);
            this.Controls.Add(this.pnlCamera);
            this.Controls.Add(this.btnSaveProgram);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstOutput);
            this.Controls.Add(this.btnEditMode);
            this.Controls.Add(this.btnRunMode);
            this.Controls.Add(this.splitterRight);
            this.Controls.Add(this.gbProgramTools);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Heka Vision";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmEditor_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gbProgramTools.ResumeLayout(false);
            this.splitterRight.Panel1.ResumeLayout(false);
            this.splitterRight.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitterRight)).EndInit();
            this.splitterRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.prpGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstOutput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem programToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsItemEdit;
        private System.Windows.Forms.ToolStripMenuItem tsItemSettings;
        private System.Windows.Forms.GroupBox gbProgramTools;
        private System.Windows.Forms.SplitContainer splitterRight;
        private DevExpress.XtraToolbox.ToolboxControl toolboxControlTools;
        private DevExpress.XtraVerticalGrid.PropertyGridControl prpGrid;
        private DevExpress.XtraEditors.SimpleButton btnRunMode;
        private DevExpress.XtraEditors.SimpleButton btnEditMode;
        private DevExpress.XtraEditors.ListBoxControl lstOutput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem tsItemNewProgram;
        private System.Windows.Forms.ToolStripMenuItem tsItemChangeProgram;
        private System.Windows.Forms.ToolStripMenuItem tsItemDeleteProgram;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsItemProgramProperties;
        private DevExpress.XtraEditors.SimpleButton btnSaveProgram;
        private System.Windows.Forms.Panel pnlCamera;
        private DevExpress.XtraToolbox.ToolboxGroup toolboxGroup1;
        private DevExpress.XtraToolbox.ToolboxGroup toolboxGroup2;
        private DevExpress.XtraToolbox.ToolboxGroup toolboxGroup3;
        private DevExpress.XtraToolbox.ToolboxGroup toolboxGroup4;
        private DevExpress.XtraToolbox.ToolboxItem toolGauss;
        private DevExpress.XtraToolbox.ToolboxItem toolErode;
        private DevExpress.XtraToolbox.ToolboxItem toolDilate;
        private DevExpress.XtraToolbox.ToolboxItem toolMorhpOpen;
        private DevExpress.XtraToolbox.ToolboxItem toolMorphClose;
        private DevExpress.XtraToolbox.ToolboxItem toolRectangle;
        private DevExpress.XtraToolbox.ToolboxItem toolPolygon;
        private DevExpress.XtraToolbox.ToolboxItem toolThreshold;
        private DevExpress.XtraToolbox.ToolboxItem toolPatternMatch;
        private DevExpress.XtraToolbox.ToolboxItem toolCmpNumeric;
        private DevExpress.XtraToolbox.ToolboxItem toolCmpBool;
        private DevExpress.XtraToolbox.ToolboxItem toolOutTcpIp;
        private DevExpress.XtraToolbox.ToolboxItem toolOutModbusTcp;
        private DevExpress.XtraToolbox.ToolboxItem toolOutDigital;
        private DevExpress.XtraToolbox.ToolboxItem toolOutHttp;
        private System.Windows.Forms.Label lblProgramTitle;
        private System.Windows.Forms.FlowLayoutPanel flPanelTools;
        private System.Windows.Forms.ToolStripMenuItem tsItemDeleteTool;
        private DevExpress.XtraEditors.SimpleButton btnSelectCamera;
    }
}