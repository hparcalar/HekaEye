
namespace HekaEye
{
    partial class frmHekaTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHekaTest));
            this.lblResult = new System.Windows.Forms.Label();
            this.cmbModels = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblErrCount = new System.Windows.Forms.Label();
            this.lblOkCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.flPanelCams = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTestStart = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lblCombined = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.flPanelExternalTests = new System.Windows.Forms.FlowLayoutPanel();
            this.lblCamStatus = new System.Windows.Forms.Panel();
            this.lblStatusText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblResult
            // 
            this.lblResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblResult.ForeColor = System.Drawing.Color.White;
            this.lblResult.Location = new System.Drawing.Point(920, 522);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(270, 102);
            this.lblResult.TabIndex = 28;
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbModels
            // 
            this.cmbModels.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbModels.DisplayMember = "ProductName";
            this.cmbModels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModels.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbModels.FormattingEnabled = true;
            this.cmbModels.Location = new System.Drawing.Point(925, 35);
            this.cmbModels.Name = "cmbModels";
            this.cmbModels.Size = new System.Drawing.Size(262, 37);
            this.cmbModels.TabIndex = 30;
            this.cmbModels.ValueMember = "Id";
            this.cmbModels.SelectedIndexChanged += new System.EventHandler(this.cmbModels_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(921, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 20);
            this.label1.TabIndex = 31;
            this.label1.Text = "Model Seçiniz";
            // 
            // lblErrCount
            // 
            this.lblErrCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblErrCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblErrCount.ForeColor = System.Drawing.Color.Red;
            this.lblErrCount.Location = new System.Drawing.Point(920, 401);
            this.lblErrCount.Name = "lblErrCount";
            this.lblErrCount.Size = new System.Drawing.Size(136, 90);
            this.lblErrCount.TabIndex = 33;
            this.lblErrCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOkCount
            // 
            this.lblOkCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOkCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblOkCount.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblOkCount.Location = new System.Drawing.Point(1062, 401);
            this.lblOkCount.Name = "lblOkCount";
            this.lblOkCount.Size = new System.Drawing.Size(136, 90);
            this.lblOkCount.TabIndex = 34;
            this.lblOkCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(1105, 376);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 25);
            this.label2.TabIndex = 35;
            this.label2.Text = "OK";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.Gainsboro;
            this.label3.Location = new System.Drawing.Point(958, 376);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 25);
            this.label3.TabIndex = 36;
            this.label3.Text = "NOK";
            // 
            // flPanelCams
            // 
            this.flPanelCams.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flPanelCams.AutoScroll = true;
            this.flPanelCams.BackColor = System.Drawing.Color.Black;
            this.flPanelCams.Location = new System.Drawing.Point(12, 51);
            this.flPanelCams.Name = "flPanelCams";
            this.flPanelCams.Size = new System.Drawing.Size(800, 573);
            this.flPanelCams.TabIndex = 38;
            // 
            // btnTestStart
            // 
            this.btnTestStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTestStart.Location = new System.Drawing.Point(925, 226);
            this.btnTestStart.Name = "btnTestStart";
            this.btnTestStart.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue;
            this.btnTestStart.Size = new System.Drawing.Size(262, 92);
            this.btnTestStart.StateCommon.Back.Color1 = System.Drawing.Color.Lime;
            this.btnTestStart.StateCommon.Back.Color2 = System.Drawing.Color.Black;
            this.btnTestStart.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.btnTestStart.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.Black;
            this.btnTestStart.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTestStart.StateCommon.Content.ShortText.MultiLine = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.btnTestStart.StateCommon.Content.ShortText.MultiLineH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnTestStart.StateCommon.Content.ShortText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Word;
            this.btnTestStart.TabIndex = 39;
            this.btnTestStart.Values.Text = "TESTİ BAŞLAT";
            this.btnTestStart.Click += new System.EventHandler(this.btnTestStart_Click);
            // 
            // lblCombined
            // 
            this.lblCombined.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCombined.AutoSize = false;
            this.lblCombined.Location = new System.Drawing.Point(928, 88);
            this.lblCombined.Name = "lblCombined";
            this.lblCombined.Size = new System.Drawing.Size(259, 25);
            this.lblCombined.StateCommon.ShortText.Color1 = System.Drawing.Color.Gainsboro;
            this.lblCombined.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblCombined.TabIndex = 40;
            this.lblCombined.Values.Text = "KOMBİN:";
            this.lblCombined.Visible = false;
            // 
            // flPanelExternalTests
            // 
            this.flPanelExternalTests.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flPanelExternalTests.ForeColor = System.Drawing.Color.White;
            this.flPanelExternalTests.Location = new System.Drawing.Point(925, 133);
            this.flPanelExternalTests.Name = "flPanelExternalTests";
            this.flPanelExternalTests.Size = new System.Drawing.Size(262, 78);
            this.flPanelExternalTests.TabIndex = 41;
            // 
            // lblCamStatus
            // 
            this.lblCamStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblCamStatus.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("lblCamStatus.BackgroundImage")));
            this.lblCamStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.lblCamStatus.Location = new System.Drawing.Point(12, 10);
            this.lblCamStatus.Name = "lblCamStatus";
            this.lblCamStatus.Size = new System.Drawing.Size(44, 33);
            this.lblCamStatus.TabIndex = 42;
            this.lblCamStatus.Visible = false;
            // 
            // lblStatusText
            // 
            this.lblStatusText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblStatusText.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblStatusText.Location = new System.Drawing.Point(62, 9);
            this.lblStatusText.Name = "lblStatusText";
            this.lblStatusText.Size = new System.Drawing.Size(345, 34);
            this.lblStatusText.TabIndex = 43;
            this.lblStatusText.Text = "KAMERA HAZIRLANIYOR";
            this.lblStatusText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmHekaTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(1255, 636);
            this.Controls.Add(this.lblStatusText);
            this.Controls.Add(this.lblCamStatus);
            this.Controls.Add(this.flPanelExternalTests);
            this.Controls.Add(this.lblCombined);
            this.Controls.Add(this.btnTestStart);
            this.Controls.Add(this.flPanelCams);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblOkCount);
            this.Controls.Add(this.lblErrCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbModels);
            this.Controls.Add(this.lblResult);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmHekaTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Heka Görsel Test";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmHekaStudio_FormClosing);
            this.Load += new System.EventHandler(this.frmHekaStudio_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.ComboBox cmbModels;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblErrCount;
        private System.Windows.Forms.Label lblOkCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel flPanelCams;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnTestStart;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblCombined;
        private System.Windows.Forms.FlowLayoutPanel flPanelExternalTests;
        private System.Windows.Forms.Panel lblCamStatus;
        private System.Windows.Forms.Label lblStatusText;
    }
}