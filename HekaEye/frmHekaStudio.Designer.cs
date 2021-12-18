
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCamera = new System.Windows.Forms.ComboBox();
            this.imgBox = new Emgu.CV.UI.ImageBox();
            this.prpGrid = new System.Windows.Forms.PropertyGrid();
            this.tabTools = new System.Windows.Forms.TabControl();
            this.tabPageProperties = new System.Windows.Forms.TabPage();
            this.tabPageRecipes = new System.Windows.Forms.TabPage();
            this.flPanelRecipes = new System.Windows.Forms.FlowLayoutPanel();
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
            ((System.ComponentModel.ISupportInitialize)(this.imgBox)).BeginInit();
            this.tabTools.SuspendLayout();
            this.tabPageProperties.SuspendLayout();
            this.tabPageRecipes.SuspendLayout();
            this.tabPageRegions.SuspendLayout();
            this.tabPageModels.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tBarExposure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgMask)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 23);
            this.label1.TabIndex = 17;
            this.label1.Text = "KAMERA";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // imgBox
            // 
            this.imgBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imgBox.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imgBox.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            this.imgBox.Location = new System.Drawing.Point(137, 51);
            this.imgBox.Name = "imgBox";
            this.imgBox.Size = new System.Drawing.Size(770, 466);
            this.imgBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgBox.TabIndex = 2;
            this.imgBox.TabStop = false;
            this.imgBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imgBox_MouseDown);
            this.imgBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imgBox_MouseMove);
            this.imgBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imgBox_MouseUp);
            // 
            // prpGrid
            // 
            this.prpGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prpGrid.Location = new System.Drawing.Point(3, 3);
            this.prpGrid.Name = "prpGrid";
            this.prpGrid.Size = new System.Drawing.Size(316, 272);
            this.prpGrid.TabIndex = 19;
            // 
            // tabTools
            // 
            this.tabTools.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabTools.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tabTools.Controls.Add(this.tabPageProperties);
            this.tabTools.Controls.Add(this.tabPageRecipes);
            this.tabTools.Controls.Add(this.tabPageRegions);
            this.tabTools.Controls.Add(this.tabPageModels);
            this.tabTools.Location = new System.Drawing.Point(913, 51);
            this.tabTools.Name = "tabTools";
            this.tabTools.SelectedIndex = 0;
            this.tabTools.Size = new System.Drawing.Size(330, 307);
            this.tabTools.TabIndex = 20;
            // 
            // tabPageProperties
            // 
            this.tabPageProperties.Controls.Add(this.prpGrid);
            this.tabPageProperties.Location = new System.Drawing.Point(4, 4);
            this.tabPageProperties.Name = "tabPageProperties";
            this.tabPageProperties.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProperties.Size = new System.Drawing.Size(322, 278);
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
            this.tabPageRecipes.Size = new System.Drawing.Size(267, 437);
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
            this.flPanelRecipes.Size = new System.Drawing.Size(261, 431);
            this.flPanelRecipes.TabIndex = 1;
            // 
            // tabPageRegions
            // 
            this.tabPageRegions.Controls.Add(this.flPanelRegions);
            this.tabPageRegions.Location = new System.Drawing.Point(4, 4);
            this.tabPageRegions.Name = "tabPageRegions";
            this.tabPageRegions.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRegions.Size = new System.Drawing.Size(267, 437);
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
            this.flPanelRegions.Size = new System.Drawing.Size(261, 431);
            this.flPanelRegions.TabIndex = 0;
            // 
            // tabPageModels
            // 
            this.tabPageModels.Controls.Add(this.flPanelModels);
            this.tabPageModels.Location = new System.Drawing.Point(4, 4);
            this.tabPageModels.Name = "tabPageModels";
            this.tabPageModels.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageModels.Size = new System.Drawing.Size(267, 437);
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
            this.flPanelModels.Size = new System.Drawing.Size(261, 431);
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
            this.btnShape.Location = new System.Drawing.Point(12, 187);
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
            this.tBarExposure.Location = new System.Drawing.Point(968, 6);
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
            this.btnLine.Location = new System.Drawing.Point(12, 237);
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
            this.lblExposure.Location = new System.Drawing.Point(844, 15);
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
            this.btnUndo.Location = new System.Drawing.Point(385, 12);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(37, 33);
            this.btnUndo.TabIndex = 26;
            this.btnUndo.UseVisualStyleBackColor = false;
            this.btnUndo.Visible = false;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // lblResult
            // 
            this.lblResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblResult.Location = new System.Drawing.Point(800, 16);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(38, 23);
            this.lblResult.TabIndex = 28;
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRecipe
            // 
            this.lblRecipe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRecipe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblRecipe.Location = new System.Drawing.Point(639, 16);
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
            this.btnDelete.Location = new System.Drawing.Point(428, 12);
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
            this.btnModel.Location = new System.Drawing.Point(12, 101);
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
            this.btnSave.Location = new System.Drawing.Point(471, 12);
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
            this.lblSaveResult.Location = new System.Drawing.Point(7, 494);
            this.lblSaveResult.Name = "lblSaveResult";
            this.lblSaveResult.Size = new System.Drawing.Size(118, 23);
            this.lblSaveResult.TabIndex = 34;
            this.lblSaveResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // imgMask
            // 
            this.imgMask.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imgMask.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            this.imgMask.Location = new System.Drawing.Point(913, 364);
            this.imgMask.Name = "imgMask";
            this.imgMask.Size = new System.Drawing.Size(330, 153);
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
            this.btnStartTemplate.Location = new System.Drawing.Point(12, 286);
            this.btnStartTemplate.Name = "btnStartTemplate";
            this.btnStartTemplate.Size = new System.Drawing.Size(119, 54);
            this.btnStartTemplate.TabIndex = 36;
            this.btnStartTemplate.Text = "Start Template";
            this.btnStartTemplate.UseVisualStyleBackColor = false;
            this.btnStartTemplate.Click += new System.EventHandler(this.btnStartTemplate_Click);
            // 
            // frmHekaStudio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1255, 529);
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
            this.Controls.Add(this.imgBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbCamera);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmHekaStudio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Heka Studio";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmHekaStudio_FormClosing);
            this.Load += new System.EventHandler(this.frmHekaStudio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgBox)).EndInit();
            this.tabTools.ResumeLayout(false);
            this.tabPageProperties.ResumeLayout(false);
            this.tabPageRecipes.ResumeLayout(false);
            this.tabPageRegions.ResumeLayout(false);
            this.tabPageModels.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tBarExposure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgMask)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCamera;
        private Emgu.CV.UI.ImageBox imgBox;
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
    }
}