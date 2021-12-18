
namespace HekaEye
{
    partial class frmEyeStudio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEyeStudio));
            this.imgBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCamera = new System.Windows.Forms.ComboBox();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.groupBoxTools = new System.Windows.Forms.GroupBox();
            this.btnSelection = new System.Windows.Forms.Button();
            this.groupBoxSelections = new System.Windows.Forms.GroupBox();
            this.flPanelSelections = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBoxProperties = new System.Windows.Forms.GroupBox();
            this.prpGrid = new System.Windows.Forms.PropertyGrid();
            this.groupBoxThresholds = new System.Windows.Forms.GroupBox();
            this.tBarExposure = new System.Windows.Forms.TrackBar();
            this.selectionBox = new System.Windows.Forms.PictureBox();
            this.btnDrawLine = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox)).BeginInit();
            this.groupBoxTools.SuspendLayout();
            this.groupBoxSelections.SuspendLayout();
            this.groupBoxProperties.SuspendLayout();
            this.groupBoxThresholds.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tBarExposure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectionBox)).BeginInit();
            this.SuspendLayout();
            // 
            // imgBox
            // 
            this.imgBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imgBox.Location = new System.Drawing.Point(12, 51);
            this.imgBox.Name = "imgBox";
            this.imgBox.Size = new System.Drawing.Size(644, 142);
            this.imgBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgBox.TabIndex = 6;
            this.imgBox.TabStop = false;
            this.imgBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imgBox_MouseDown);
            this.imgBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imgBox_MouseMove);
            this.imgBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imgBox_MouseUp);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 23);
            this.label1.TabIndex = 12;
            this.label1.Text = "KAMERA";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbCamera
            // 
            this.cmbCamera.DisplayMember = "Name";
            this.cmbCamera.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbCamera.FormattingEnabled = true;
            this.cmbCamera.Location = new System.Drawing.Point(136, 12);
            this.cmbCamera.Name = "cmbCamera";
            this.cmbCamera.Size = new System.Drawing.Size(268, 33);
            this.cmbCamera.TabIndex = 11;
            this.cmbCamera.ValueMember = "DeviceIndex";
            this.cmbCamera.SelectedIndexChanged += new System.EventHandler(this.cmbCamera_SelectedIndexChanged);
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMainMenu.BackColor = System.Drawing.Color.SpringGreen;
            this.btnMainMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMainMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMainMenu.Location = new System.Drawing.Point(977, 466);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(278, 91);
            this.btnMainMenu.TabIndex = 14;
            this.btnMainMenu.Text = "ANA MENÜ";
            this.btnMainMenu.UseVisualStyleBackColor = false;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.LemonChiffon;
            this.lblStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblStatus.Location = new System.Drawing.Point(422, 12);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(234, 33);
            this.lblStatus.TabIndex = 15;
            this.lblStatus.Text = "KAMERA AÇILIYOR";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStatus.Visible = false;
            // 
            // groupBoxTools
            // 
            this.groupBoxTools.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxTools.Controls.Add(this.btnDrawLine);
            this.groupBoxTools.Controls.Add(this.btnSelection);
            this.groupBoxTools.Location = new System.Drawing.Point(662, 12);
            this.groupBoxTools.Name = "groupBoxTools";
            this.groupBoxTools.Size = new System.Drawing.Size(306, 141);
            this.groupBoxTools.TabIndex = 16;
            this.groupBoxTools.TabStop = false;
            this.groupBoxTools.Text = "Araç Kutusu";
            // 
            // btnSelection
            // 
            this.btnSelection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelection.BackColor = System.Drawing.Color.Gray;
            this.btnSelection.Location = new System.Drawing.Point(6, 21);
            this.btnSelection.Name = "btnSelection";
            this.btnSelection.Size = new System.Drawing.Size(294, 32);
            this.btnSelection.TabIndex = 0;
            this.btnSelection.Text = "Bölge Seç";
            this.btnSelection.UseVisualStyleBackColor = false;
            this.btnSelection.Click += new System.EventHandler(this.btnSelection_Click);
            // 
            // groupBoxSelections
            // 
            this.groupBoxSelections.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSelections.Controls.Add(this.flPanelSelections);
            this.groupBoxSelections.Location = new System.Drawing.Point(662, 357);
            this.groupBoxSelections.Name = "groupBoxSelections";
            this.groupBoxSelections.Size = new System.Drawing.Size(306, 200);
            this.groupBoxSelections.TabIndex = 17;
            this.groupBoxSelections.TabStop = false;
            this.groupBoxSelections.Text = "Seçimler";
            // 
            // flPanelSelections
            // 
            this.flPanelSelections.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flPanelSelections.Location = new System.Drawing.Point(3, 18);
            this.flPanelSelections.Name = "flPanelSelections";
            this.flPanelSelections.Size = new System.Drawing.Size(300, 179);
            this.flPanelSelections.TabIndex = 0;
            // 
            // groupBoxProperties
            // 
            this.groupBoxProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxProperties.Controls.Add(this.prpGrid);
            this.groupBoxProperties.Location = new System.Drawing.Point(974, 12);
            this.groupBoxProperties.Name = "groupBoxProperties";
            this.groupBoxProperties.Size = new System.Drawing.Size(281, 448);
            this.groupBoxProperties.TabIndex = 18;
            this.groupBoxProperties.TabStop = false;
            this.groupBoxProperties.Text = "Özellikler";
            // 
            // prpGrid
            // 
            this.prpGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prpGrid.Location = new System.Drawing.Point(3, 18);
            this.prpGrid.Name = "prpGrid";
            this.prpGrid.Size = new System.Drawing.Size(275, 427);
            this.prpGrid.TabIndex = 0;
            // 
            // groupBoxThresholds
            // 
            this.groupBoxThresholds.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxThresholds.Controls.Add(this.tBarExposure);
            this.groupBoxThresholds.Location = new System.Drawing.Point(662, 159);
            this.groupBoxThresholds.Name = "groupBoxThresholds";
            this.groupBoxThresholds.Size = new System.Drawing.Size(306, 192);
            this.groupBoxThresholds.TabIndex = 19;
            this.groupBoxThresholds.TabStop = false;
            this.groupBoxThresholds.Text = "Exposure";
            // 
            // tBarExposure
            // 
            this.tBarExposure.AutoSize = false;
            this.tBarExposure.Location = new System.Drawing.Point(6, 32);
            this.tBarExposure.Maximum = 0;
            this.tBarExposure.Minimum = -13;
            this.tBarExposure.Name = "tBarExposure";
            this.tBarExposure.Size = new System.Drawing.Size(294, 39);
            this.tBarExposure.TabIndex = 0;
            this.tBarExposure.ValueChanged += new System.EventHandler(this.tBarExposure_ValueChanged);
            // 
            // selectionBox
            // 
            this.selectionBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.selectionBox.Location = new System.Drawing.Point(12, 199);
            this.selectionBox.Name = "selectionBox";
            this.selectionBox.Size = new System.Drawing.Size(644, 358);
            this.selectionBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.selectionBox.TabIndex = 20;
            this.selectionBox.TabStop = false;
            // 
            // btnDrawLine
            // 
            this.btnDrawLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDrawLine.BackColor = System.Drawing.Color.Gray;
            this.btnDrawLine.Location = new System.Drawing.Point(6, 54);
            this.btnDrawLine.Name = "btnDrawLine";
            this.btnDrawLine.Size = new System.Drawing.Size(294, 32);
            this.btnDrawLine.TabIndex = 1;
            this.btnDrawLine.Text = "Çizgi Çiz";
            this.btnDrawLine.UseVisualStyleBackColor = false;
            this.btnDrawLine.Click += new System.EventHandler(this.btnDrawLine_Click);
            // 
            // frmEyeStudio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1267, 569);
            this.Controls.Add(this.selectionBox);
            this.Controls.Add(this.groupBoxThresholds);
            this.Controls.Add(this.groupBoxProperties);
            this.Controls.Add(this.groupBoxSelections);
            this.Controls.Add(this.groupBoxTools);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnMainMenu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbCamera);
            this.Controls.Add(this.imgBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEyeStudio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Eye Studio";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLiveTest_FormClosing);
            this.Load += new System.EventHandler(this.frmLiveTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgBox)).EndInit();
            this.groupBoxTools.ResumeLayout(false);
            this.groupBoxSelections.ResumeLayout(false);
            this.groupBoxProperties.ResumeLayout(false);
            this.groupBoxThresholds.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tBarExposure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectionBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imgBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCamera;
        private System.Windows.Forms.Button btnMainMenu;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.GroupBox groupBoxTools;
        private System.Windows.Forms.GroupBox groupBoxSelections;
        private System.Windows.Forms.GroupBox groupBoxProperties;
        private System.Windows.Forms.Button btnSelection;
        private System.Windows.Forms.PropertyGrid prpGrid;
        private System.Windows.Forms.GroupBox groupBoxThresholds;
        private System.Windows.Forms.TrackBar tBarExposure;
        private System.Windows.Forms.FlowLayoutPanel flPanelSelections;
        private System.Windows.Forms.PictureBox selectionBox;
        private System.Windows.Forms.Button btnDrawLine;
    }
}