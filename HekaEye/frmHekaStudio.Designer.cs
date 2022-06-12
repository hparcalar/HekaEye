
namespace HekaEye
{
    partial class frmHekaStudio
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHekaStudio));
            this.cmbCamera = new System.Windows.Forms.ComboBox();
            this.prpGrid = new System.Windows.Forms.PropertyGrid();
            this.tabTools = new System.Windows.Forms.TabControl();
            this.tabPageProperties = new System.Windows.Forms.TabPage();
            this.tabPageRecipes = new System.Windows.Forms.TabPage();
            this.flPanelRecipes = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPageCamera = new System.Windows.Forms.TabPage();
            this.flPanelCameras = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPageRegions = new System.Windows.Forms.TabPage();
            this.flPanelRegions = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPageModels = new System.Windows.Forms.TabPage();
            this.flPanelModels = new System.Windows.Forms.FlowLayoutPanel();
            this.btnShape = new System.Windows.Forms.Button();
            this.tBarExposure = new System.Windows.Forms.TrackBar();
            this.lblStatus = new System.Windows.Forms.Panel();
            this.btnLine = new System.Windows.Forms.Button();
            this.lblExposure = new System.Windows.Forms.Label();
            this.btnUndo = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.lblRecipe = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRecipe = new System.Windows.Forms.Button();
            this.btnModel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblSaveResult = new System.Windows.Forms.Label();
            this.imgMask = new Emgu.CV.UI.ImageBox();
            this.btnStartTemplate = new System.Windows.Forms.Button();
            this.flPanelCams = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCamera = new System.Windows.Forms.Button();
            this.lblX = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.lblNokRate = new System.Windows.Forms.Label();
            this.txtOffsetX = new System.Windows.Forms.TextBox();
            this.txtOffsetY = new System.Windows.Forms.TextBox();
            this.btnSetOffsetOfRegions = new System.Windows.Forms.Button();
            this.btnSetPosition = new System.Windows.Forms.Button();
            this.btnSetRotation = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnLeft = new System.Windows.Forms.Button();
            this.btnRight = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.lblHsv = new System.Windows.Forms.Label();
            this.btnDoCapture = new System.Windows.Forms.Button();
            this.tabTools.SuspendLayout();
            this.tabPageProperties.SuspendLayout();
            this.tabPageRecipes.SuspendLayout();
            this.tabPageCamera.SuspendLayout();
            this.tabPageRegions.SuspendLayout();
            this.tabPageModels.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tBarExposure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgMask)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbCamera
            // 
            this.cmbCamera.DisplayMember = "Name";
            this.cmbCamera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCamera.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbCamera.FormattingEnabled = true;
            this.cmbCamera.Location = new System.Drawing.Point(137, 12);
            this.cmbCamera.Name = "cmbCamera";
            this.cmbCamera.Size = new System.Drawing.Size(192, 33);
            this.cmbCamera.TabIndex = 16;
            this.cmbCamera.ValueMember = "DeviceIndex";
            this.cmbCamera.SelectedIndexChanged += new System.EventHandler(this.cmbCamera_SelectedIndexChanged);
            // 
            // prpGrid
            // 
            this.prpGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prpGrid.Location = new System.Drawing.Point(3, 3);
            this.prpGrid.Name = "prpGrid";
            this.prpGrid.Size = new System.Drawing.Size(316, 418);
            this.prpGrid.TabIndex = 19;
            // 
            // tabTools
            // 
            this.tabTools.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabTools.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabTools.Controls.Add(this.tabPageProperties);
            this.tabTools.Controls.Add(this.tabPageRecipes);
            this.tabTools.Controls.Add(this.tabPageCamera);
            this.tabTools.Controls.Add(this.tabPageRegions);
            this.tabTools.Controls.Add(this.tabPageModels);
            this.tabTools.Location = new System.Drawing.Point(999, 51);
            this.tabTools.Name = "tabTools";
            this.tabTools.SelectedIndex = 0;
            this.tabTools.Size = new System.Drawing.Size(330, 453);
            this.tabTools.TabIndex = 20;
            // 
            // tabPageProperties
            // 
            this.tabPageProperties.Controls.Add(this.prpGrid);
            this.tabPageProperties.Location = new System.Drawing.Point(4, 4);
            this.tabPageProperties.Name = "tabPageProperties";
            this.tabPageProperties.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProperties.Size = new System.Drawing.Size(322, 424);
            this.tabPageProperties.TabIndex = 0;
            this.tabPageProperties.Text = "Özellikler";
            this.tabPageProperties.UseVisualStyleBackColor = true;
            // 
            // tabPageRecipes
            // 
            this.tabPageRecipes.Controls.Add(this.flPanelRecipes);
            this.tabPageRecipes.Location = new System.Drawing.Point(4, 4);
            this.tabPageRecipes.Name = "tabPageRecipes";
            this.tabPageRecipes.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRecipes.Size = new System.Drawing.Size(322, 424);
            this.tabPageRecipes.TabIndex = 2;
            this.tabPageRecipes.Text = "Reçete";
            this.tabPageRecipes.UseVisualStyleBackColor = true;
            // 
            // flPanelRecipes
            // 
            this.flPanelRecipes.AutoScroll = true;
            this.flPanelRecipes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flPanelRecipes.Location = new System.Drawing.Point(3, 3);
            this.flPanelRecipes.Name = "flPanelRecipes";
            this.flPanelRecipes.Size = new System.Drawing.Size(316, 418);
            this.flPanelRecipes.TabIndex = 1;
            // 
            // tabPageCamera
            // 
            this.tabPageCamera.Controls.Add(this.flPanelCameras);
            this.tabPageCamera.Location = new System.Drawing.Point(4, 4);
            this.tabPageCamera.Name = "tabPageCamera";
            this.tabPageCamera.Size = new System.Drawing.Size(322, 424);
            this.tabPageCamera.TabIndex = 4;
            this.tabPageCamera.Text = "Kamera";
            this.tabPageCamera.UseVisualStyleBackColor = true;
            // 
            // flPanelCameras
            // 
            this.flPanelCameras.AutoScroll = true;
            this.flPanelCameras.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flPanelCameras.Location = new System.Drawing.Point(0, 0);
            this.flPanelCameras.Name = "flPanelCameras";
            this.flPanelCameras.Size = new System.Drawing.Size(322, 424);
            this.flPanelCameras.TabIndex = 2;
            // 
            // tabPageRegions
            // 
            this.tabPageRegions.Controls.Add(this.flPanelRegions);
            this.tabPageRegions.Location = new System.Drawing.Point(4, 4);
            this.tabPageRegions.Name = "tabPageRegions";
            this.tabPageRegions.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRegions.Size = new System.Drawing.Size(322, 424);
            this.tabPageRegions.TabIndex = 1;
            this.tabPageRegions.Text = "Bölge";
            this.tabPageRegions.UseVisualStyleBackColor = true;
            // 
            // flPanelRegions
            // 
            this.flPanelRegions.AutoScroll = true;
            this.flPanelRegions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flPanelRegions.Location = new System.Drawing.Point(3, 3);
            this.flPanelRegions.Name = "flPanelRegions";
            this.flPanelRegions.Size = new System.Drawing.Size(316, 418);
            this.flPanelRegions.TabIndex = 0;
            // 
            // tabPageModels
            // 
            this.tabPageModels.Controls.Add(this.flPanelModels);
            this.tabPageModels.Location = new System.Drawing.Point(4, 4);
            this.tabPageModels.Name = "tabPageModels";
            this.tabPageModels.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageModels.Size = new System.Drawing.Size(322, 424);
            this.tabPageModels.TabIndex = 3;
            this.tabPageModels.Text = "Model";
            this.tabPageModels.UseVisualStyleBackColor = true;
            // 
            // flPanelModels
            // 
            this.flPanelModels.AutoScroll = true;
            this.flPanelModels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flPanelModels.Location = new System.Drawing.Point(3, 3);
            this.flPanelModels.Name = "flPanelModels";
            this.flPanelModels.Size = new System.Drawing.Size(316, 418);
            this.flPanelModels.TabIndex = 1;
            // 
            // btnShape
            // 
            this.btnShape.BackColor = System.Drawing.Color.Transparent;
            this.btnShape.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnShape.BackgroundImage")));
            this.btnShape.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnShape.FlatAppearance.BorderSize = 0;
            this.btnShape.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShape.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnShape.ForeColor = System.Drawing.Color.White;
            this.btnShape.Location = new System.Drawing.Point(12, 477);
            this.btnShape.Name = "btnShape";
            this.btnShape.Size = new System.Drawing.Size(119, 44);
            this.btnShape.TabIndex = 21;
            this.btnShape.Text = "Bölge";
            this.btnShape.UseVisualStyleBackColor = false;
            this.btnShape.Click += new System.EventHandler(this.btnShape_Click);
            // 
            // tBarExposure
            // 
            this.tBarExposure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tBarExposure.AutoSize = false;
            this.tBarExposure.Location = new System.Drawing.Point(1054, 6);
            this.tBarExposure.Maximum = 0;
            this.tBarExposure.Minimum = -13;
            this.tBarExposure.Name = "tBarExposure";
            this.tBarExposure.Size = new System.Drawing.Size(275, 39);
            this.tBarExposure.TabIndex = 22;
            this.tBarExposure.ValueChanged += new System.EventHandler(this.tBarExposure_ValueChanged);
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("lblStatus.BackgroundImage")));
            this.lblStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.lblStatus.Location = new System.Drawing.Point(335, 12);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(44, 33);
            this.lblStatus.TabIndex = 23;
            this.lblStatus.Visible = false;
            // 
            // btnLine
            // 
            this.btnLine.BackColor = System.Drawing.Color.Transparent;
            this.btnLine.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLine.BackgroundImage")));
            this.btnLine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLine.FlatAppearance.BorderSize = 0;
            this.btnLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnLine.ForeColor = System.Drawing.Color.White;
            this.btnLine.Location = new System.Drawing.Point(12, 524);
            this.btnLine.Name = "btnLine";
            this.btnLine.Size = new System.Drawing.Size(119, 44);
            this.btnLine.TabIndex = 24;
            this.btnLine.Text = "Çizgi";
            this.btnLine.UseVisualStyleBackColor = false;
            this.btnLine.Click += new System.EventHandler(this.btnLine_Click);
            // 
            // lblExposure
            // 
            this.lblExposure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExposure.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblExposure.Location = new System.Drawing.Point(930, 15);
            this.lblExposure.Name = "lblExposure";
            this.lblExposure.Size = new System.Drawing.Size(118, 23);
            this.lblExposure.TabIndex = 25;
            this.lblExposure.Text = "Exposure";
            this.lblExposure.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnUndo
            // 
            this.btnUndo.BackColor = System.Drawing.Color.Transparent;
            this.btnUndo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUndo.BackgroundImage")));
            this.btnUndo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnUndo.Location = new System.Drawing.Point(427, 11);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(37, 33);
            this.btnUndo.TabIndex = 26;
            this.btnUndo.UseVisualStyleBackColor = false;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // lblResult
            // 
            this.lblResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblResult.Location = new System.Drawing.Point(886, 16);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(38, 23);
            this.lblResult.TabIndex = 28;
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRecipe
            // 
            this.lblRecipe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRecipe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblRecipe.Location = new System.Drawing.Point(725, 16);
            this.lblRecipe.Name = "lblRecipe";
            this.lblRecipe.Size = new System.Drawing.Size(155, 23);
            this.lblRecipe.TabIndex = 29;
            this.lblRecipe.Text = "-";
            this.lblRecipe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDelete.BackgroundImage")));
            this.btnDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDelete.Location = new System.Drawing.Point(470, 11);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(37, 34);
            this.btnDelete.TabIndex = 30;
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRecipe
            // 
            this.btnRecipe.BackColor = System.Drawing.Color.Transparent;
            this.btnRecipe.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRecipe.BackgroundImage")));
            this.btnRecipe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRecipe.FlatAppearance.BorderSize = 0;
            this.btnRecipe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecipe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRecipe.ForeColor = System.Drawing.Color.White;
            this.btnRecipe.Location = new System.Drawing.Point(12, 51);
            this.btnRecipe.Name = "btnRecipe";
            this.btnRecipe.Size = new System.Drawing.Size(119, 44);
            this.btnRecipe.TabIndex = 31;
            this.btnRecipe.Text = "Reçete";
            this.btnRecipe.UseVisualStyleBackColor = false;
            this.btnRecipe.Click += new System.EventHandler(this.btnRecipe_Click);
            // 
            // btnModel
            // 
            this.btnModel.BackColor = System.Drawing.Color.Transparent;
            this.btnModel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnModel.BackgroundImage")));
            this.btnModel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnModel.FlatAppearance.BorderSize = 0;
            this.btnModel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnModel.ForeColor = System.Drawing.Color.White;
            this.btnModel.Location = new System.Drawing.Point(12, 151);
            this.btnModel.Name = "btnModel";
            this.btnModel.Size = new System.Drawing.Size(119, 44);
            this.btnModel.TabIndex = 32;
            this.btnModel.Text = "Model";
            this.btnModel.UseVisualStyleBackColor = false;
            this.btnModel.Click += new System.EventHandler(this.btnModel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSave.BackgroundImage")));
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSave.Location = new System.Drawing.Point(513, 11);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(37, 34);
            this.btnSave.TabIndex = 33;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblSaveResult
            // 
            this.lblSaveResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSaveResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSaveResult.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblSaveResult.Location = new System.Drawing.Point(7, 703);
            this.lblSaveResult.Name = "lblSaveResult";
            this.lblSaveResult.Size = new System.Drawing.Size(118, 23);
            this.lblSaveResult.TabIndex = 34;
            this.lblSaveResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // imgMask
            // 
            this.imgMask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.imgMask.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            this.imgMask.Location = new System.Drawing.Point(999, 510);
            this.imgMask.Name = "imgMask";
            this.imgMask.Size = new System.Drawing.Size(330, 216);
            this.imgMask.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgMask.TabIndex = 35;
            this.imgMask.TabStop = false;
            // 
            // btnStartTemplate
            // 
            this.btnStartTemplate.BackColor = System.Drawing.Color.Transparent;
            this.btnStartTemplate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnStartTemplate.BackgroundImage")));
            this.btnStartTemplate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStartTemplate.FlatAppearance.BorderSize = 0;
            this.btnStartTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnStartTemplate.ForeColor = System.Drawing.Color.White;
            this.btnStartTemplate.Location = new System.Drawing.Point(12, 569);
            this.btnStartTemplate.Name = "btnStartTemplate";
            this.btnStartTemplate.Size = new System.Drawing.Size(119, 54);
            this.btnStartTemplate.TabIndex = 36;
            this.btnStartTemplate.Text = "Başlama Deseni";
            this.btnStartTemplate.UseVisualStyleBackColor = false;
            this.btnStartTemplate.Click += new System.EventHandler(this.btnStartTemplate_Click);
            // 
            // flPanelCams
            // 
            this.flPanelCams.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flPanelCams.AutoScroll = true;
            this.flPanelCams.Location = new System.Drawing.Point(137, 51);
            this.flPanelCams.Name = "flPanelCams";
            this.flPanelCams.Size = new System.Drawing.Size(856, 675);
            this.flPanelCams.TabIndex = 37;
            this.flPanelCams.SizeChanged += new System.EventHandler(this.flPanelCams_SizeChanged);
            // 
            // btnCamera
            // 
            this.btnCamera.BackColor = System.Drawing.Color.Transparent;
            this.btnCamera.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCamera.BackgroundImage")));
            this.btnCamera.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCamera.FlatAppearance.BorderSize = 0;
            this.btnCamera.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCamera.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCamera.ForeColor = System.Drawing.Color.White;
            this.btnCamera.Location = new System.Drawing.Point(12, 101);
            this.btnCamera.Name = "btnCamera";
            this.btnCamera.Size = new System.Drawing.Size(119, 44);
            this.btnCamera.TabIndex = 38;
            this.btnCamera.Text = "Kamera";
            this.btnCamera.UseVisualStyleBackColor = false;
            this.btnCamera.Click += new System.EventHandler(this.btnCamera_Click);
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(56, 627);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(18, 17);
            this.lblX.TabIndex = 39;
            this.lblX.Text = "--";
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(56, 646);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(18, 17);
            this.lblY.TabIndex = 40;
            this.lblY.Text = "--";
            // 
            // lblNokRate
            // 
            this.lblNokRate.AutoSize = true;
            this.lblNokRate.Location = new System.Drawing.Point(56, 659);
            this.lblNokRate.Name = "lblNokRate";
            this.lblNokRate.Size = new System.Drawing.Size(18, 17);
            this.lblNokRate.TabIndex = 41;
            this.lblNokRate.Text = "--";
            // 
            // txtOffsetX
            // 
            this.txtOffsetX.Location = new System.Drawing.Point(12, 209);
            this.txtOffsetX.Name = "txtOffsetX";
            this.txtOffsetX.Size = new System.Drawing.Size(51, 22);
            this.txtOffsetX.TabIndex = 42;
            // 
            // txtOffsetY
            // 
            this.txtOffsetY.Location = new System.Drawing.Point(69, 209);
            this.txtOffsetY.Name = "txtOffsetY";
            this.txtOffsetY.Size = new System.Drawing.Size(56, 22);
            this.txtOffsetY.TabIndex = 43;
            // 
            // btnSetOffsetOfRegions
            // 
            this.btnSetOffsetOfRegions.Location = new System.Drawing.Point(12, 237);
            this.btnSetOffsetOfRegions.Name = "btnSetOffsetOfRegions";
            this.btnSetOffsetOfRegions.Size = new System.Drawing.Size(113, 32);
            this.btnSetOffsetOfRegions.TabIndex = 44;
            this.btnSetOffsetOfRegions.Text = "Offset Ayarla";
            this.btnSetOffsetOfRegions.UseVisualStyleBackColor = true;
            this.btnSetOffsetOfRegions.Click += new System.EventHandler(this.btnSetOffsetOfRegions_Click);
            // 
            // btnSetPosition
            // 
            this.btnSetPosition.BackColor = System.Drawing.Color.Gainsboro;
            this.btnSetPosition.Location = new System.Drawing.Point(12, 293);
            this.btnSetPosition.Name = "btnSetPosition";
            this.btnSetPosition.Size = new System.Drawing.Size(51, 39);
            this.btnSetPosition.TabIndex = 45;
            this.btnSetPosition.Text = "POS";
            this.btnSetPosition.UseVisualStyleBackColor = false;
            this.btnSetPosition.Click += new System.EventHandler(this.btnSetPosition_Click);
            // 
            // btnSetRotation
            // 
            this.btnSetRotation.BackColor = System.Drawing.Color.Gainsboro;
            this.btnSetRotation.Location = new System.Drawing.Point(74, 293);
            this.btnSetRotation.Name = "btnSetRotation";
            this.btnSetRotation.Size = new System.Drawing.Size(51, 39);
            this.btnSetRotation.TabIndex = 46;
            this.btnSetRotation.Text = "ROT";
            this.btnSetRotation.UseVisualStyleBackColor = false;
            this.btnSetRotation.Click += new System.EventHandler(this.btnSetRotation_Click);
            // 
            // btnUp
            // 
            this.btnUp.BackColor = System.Drawing.Color.LimeGreen;
            this.btnUp.Location = new System.Drawing.Point(42, 338);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(51, 39);
            this.btnUp.TabIndex = 47;
            this.btnUp.Text = "U";
            this.btnUp.UseVisualStyleBackColor = false;
            this.btnUp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnUp_MouseDown);
            // 
            // btnLeft
            // 
            this.btnLeft.BackColor = System.Drawing.Color.LimeGreen;
            this.btnLeft.Location = new System.Drawing.Point(12, 383);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(51, 39);
            this.btnLeft.TabIndex = 48;
            this.btnLeft.Text = "L";
            this.btnLeft.UseVisualStyleBackColor = false;
            this.btnLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnLeft_MouseDown);
            // 
            // btnRight
            // 
            this.btnRight.BackColor = System.Drawing.Color.LimeGreen;
            this.btnRight.Location = new System.Drawing.Point(74, 383);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(51, 39);
            this.btnRight.TabIndex = 49;
            this.btnRight.Text = "R";
            this.btnRight.UseVisualStyleBackColor = false;
            this.btnRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnRight_MouseDown);
            // 
            // btnDown
            // 
            this.btnDown.BackColor = System.Drawing.Color.LimeGreen;
            this.btnDown.Location = new System.Drawing.Point(42, 428);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(51, 39);
            this.btnDown.TabIndex = 50;
            this.btnDown.Text = "D";
            this.btnDown.UseVisualStyleBackColor = false;
            this.btnDown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnDown_MouseDown);
            // 
            // lblHsv
            // 
            this.lblHsv.Location = new System.Drawing.Point(12, 675);
            this.lblHsv.Name = "lblHsv";
            this.lblHsv.Size = new System.Drawing.Size(119, 52);
            this.lblHsv.TabIndex = 51;
            this.lblHsv.Text = "--";
            // 
            // btnDoCapture
            // 
            this.btnDoCapture.BackColor = System.Drawing.Color.Transparent;
            this.btnDoCapture.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDoCapture.BackgroundImage")));
            this.btnDoCapture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDoCapture.Location = new System.Drawing.Point(385, 11);
            this.btnDoCapture.Name = "btnDoCapture";
            this.btnDoCapture.Size = new System.Drawing.Size(37, 34);
            this.btnDoCapture.TabIndex = 52;
            this.btnDoCapture.UseVisualStyleBackColor = false;
            this.btnDoCapture.Click += new System.EventHandler(this.btnDoCapture_Click);
            // 
            // frmHekaStudio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1341, 738);
            this.Controls.Add(this.btnDoCapture);
            this.Controls.Add(this.lblHsv);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnSetRotation);
            this.Controls.Add(this.btnSetPosition);
            this.Controls.Add(this.btnSetOffsetOfRegions);
            this.Controls.Add(this.txtOffsetY);
            this.Controls.Add(this.txtOffsetX);
            this.Controls.Add(this.lblNokRate);
            this.Controls.Add(this.lblY);
            this.Controls.Add(this.lblX);
            this.Controls.Add(this.btnCamera);
            this.Controls.Add(this.flPanelCams);
            this.Controls.Add(this.btnStartTemplate);
            this.Controls.Add(this.imgMask);
            this.Controls.Add(this.lblSaveResult);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnModel);
            this.Controls.Add(this.btnRecipe);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblRecipe);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.lblExposure);
            this.Controls.Add(this.btnLine);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.tBarExposure);
            this.Controls.Add(this.btnShape);
            this.Controls.Add(this.tabTools);
            this.Controls.Add(this.cmbCamera);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmHekaStudio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Heka Studio";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmHekaStudio_FormClosing);
            this.Load += new System.EventHandler(this.frmHekaStudio_Load);
            this.tabTools.ResumeLayout(false);
            this.tabPageProperties.ResumeLayout(false);
            this.tabPageRecipes.ResumeLayout(false);
            this.tabPageCamera.ResumeLayout(false);
            this.tabPageRegions.ResumeLayout(false);
            this.tabPageModels.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tBarExposure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgMask)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbCamera;
        private System.Windows.Forms.PropertyGrid prpGrid;
        private System.Windows.Forms.TabControl tabTools;
        private System.Windows.Forms.TabPage tabPageProperties;
        private System.Windows.Forms.TabPage tabPageRegions;
        private System.Windows.Forms.Button btnShape;
        private System.Windows.Forms.TrackBar tBarExposure;
        private System.Windows.Forms.Panel lblStatus;
        private System.Windows.Forms.Button btnLine;
        private System.Windows.Forms.FlowLayoutPanel flPanelRegions;
        private System.Windows.Forms.Label lblExposure;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.TabPage tabPageRecipes;
        private System.Windows.Forms.Label lblRecipe;
        private System.Windows.Forms.FlowLayoutPanel flPanelRecipes;
        private System.Windows.Forms.TabPage tabPageModels;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRecipe;
        private System.Windows.Forms.Button btnModel;
        private System.Windows.Forms.FlowLayoutPanel flPanelModels;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblSaveResult;
        private Emgu.CV.UI.ImageBox imgMask;
        private System.Windows.Forms.Button btnStartTemplate;
        private System.Windows.Forms.FlowLayoutPanel flPanelCams;
        private System.Windows.Forms.Button btnCamera;
        private System.Windows.Forms.TabPage tabPageCamera;
        private System.Windows.Forms.FlowLayoutPanel flPanelCameras;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label lblNokRate;
        private System.Windows.Forms.TextBox txtOffsetX;
        private System.Windows.Forms.TextBox txtOffsetY;
        private System.Windows.Forms.Button btnSetOffsetOfRegions;
        private System.Windows.Forms.Button btnSetPosition;
        private System.Windows.Forms.Button btnSetRotation;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnLeft;
        private System.Windows.Forms.Button btnRight;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Label lblHsv;
        private System.Windows.Forms.Button btnDoCapture;
    }
}