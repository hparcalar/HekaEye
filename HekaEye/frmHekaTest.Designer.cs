
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHekaTest));
            this.cmbCamera = new System.Windows.Forms.ComboBox();
            this.imgBox = new Emgu.CV.UI.ImageBox();
            this.lblStatus = new System.Windows.Forms.Panel();
            this.lblResult = new System.Windows.Forms.Label();
            this.cmbModels = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTestStart = new System.Windows.Forms.Button();
            this.lblErrCount = new System.Windows.Forms.Label();
            this.lblOkCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbCamera
            // 
            this.cmbCamera.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCamera.DisplayMember = "Name";
            this.cmbCamera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCamera.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbCamera.FormattingEnabled = true;
            this.cmbCamera.Location = new System.Drawing.Point(1184, 12);
            this.cmbCamera.Name = "cmbCamera";
            this.cmbCamera.Size = new System.Drawing.Size(56, 33);
            this.cmbCamera.TabIndex = 16;
            this.cmbCamera.ValueMember = "DeviceIndex";
            this.cmbCamera.Visible = false;
            this.cmbCamera.SelectedIndexChanged += new System.EventHandler(this.cmbCamera_SelectedIndexChanged);
            // 
            // imgBox
            // 
            this.imgBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imgBox.BackColor = System.Drawing.Color.Black;
            this.imgBox.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imgBox.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            this.imgBox.Location = new System.Drawing.Point(13, 12);
            this.imgBox.Name = "imgBox";
            this.imgBox.Size = new System.Drawing.Size(954, 561);
            this.imgBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgBox.TabIndex = 2;
            this.imgBox.TabStop = false;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("lblStatus.BackgroundImage")));
            this.lblStatus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.lblStatus.Location = new System.Drawing.Point(1056, 232);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(107, 79);
            this.lblStatus.TabIndex = 23;
            this.lblStatus.Visible = false;
            // 
            // lblResult
            // 
            this.lblResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblResult.Location = new System.Drawing.Point(973, 471);
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
            this.cmbModels.Location = new System.Drawing.Point(978, 78);
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
            this.label1.Location = new System.Drawing.Point(974, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 20);
            this.label1.TabIndex = 31;
            this.label1.Text = "Model Seçiniz";
            // 
            // btnTestStart
            // 
            this.btnTestStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTestStart.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnTestStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTestStart.ForeColor = System.Drawing.Color.White;
            this.btnTestStart.Location = new System.Drawing.Point(978, 149);
            this.btnTestStart.Name = "btnTestStart";
            this.btnTestStart.Size = new System.Drawing.Size(262, 77);
            this.btnTestStart.TabIndex = 32;
            this.btnTestStart.Text = "Testi Başlat";
            this.btnTestStart.UseVisualStyleBackColor = false;
            this.btnTestStart.Click += new System.EventHandler(this.btnTestStart_Click);
            // 
            // lblErrCount
            // 
            this.lblErrCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblErrCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblErrCount.ForeColor = System.Drawing.Color.Red;
            this.lblErrCount.Location = new System.Drawing.Point(973, 350);
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
            this.lblOkCount.Location = new System.Drawing.Point(1115, 350);
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
            this.label2.Location = new System.Drawing.Point(1158, 325);
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
            this.label3.Location = new System.Drawing.Point(1011, 325);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 25);
            this.label3.TabIndex = 36;
            this.label3.Text = "NOK";
            // 
            // frmHekaTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1255, 585);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblOkCount);
            this.Controls.Add(this.lblErrCount);
            this.Controls.Add(this.btnTestStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbModels);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.imgBox);
            this.Controls.Add(this.cmbCamera);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmHekaTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Heka Görsel Test";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmHekaStudio_FormClosing);
            this.Load += new System.EventHandler(this.frmHekaStudio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbCamera;
        private Emgu.CV.UI.ImageBox imgBox;
        private System.Windows.Forms.Panel lblStatus;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.ComboBox cmbModels;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTestStart;
        private System.Windows.Forms.Label lblErrCount;
        private System.Windows.Forms.Label lblOkCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}