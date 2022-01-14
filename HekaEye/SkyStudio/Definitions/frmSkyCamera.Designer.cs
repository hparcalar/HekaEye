
namespace HekaEye.SkyStudio.Definitions
{
    partial class frmSkyCamera
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSkyCamera));
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnOk = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnCancel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.cmbCamera = new ComponentFactory.Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.txtExposure = new ComponentFactory.Krypton.Toolkit.KryptonTrackBar();
            this.txtCameraAlias = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel3 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            ((System.ComponentModel.ISupportInitialize)(this.cmbCamera)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(12, 12);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(48, 24);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Cihaz";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(274, 159);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(118, 41);
            this.btnOk.TabIndex = 2;
            this.btnOk.Values.Text = "KAYDET";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(150, 159);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.ProfessionalSystem;
            this.btnCancel.Size = new System.Drawing.Size(118, 41);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Values.Text = "VAZGEÇ";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cmbCamera
            // 
            this.cmbCamera.DisplayMember = "Name";
            this.cmbCamera.DropDownWidth = 266;
            this.cmbCamera.IntegralHeight = false;
            this.cmbCamera.Location = new System.Drawing.Point(126, 11);
            this.cmbCamera.Name = "cmbCamera";
            this.cmbCamera.Size = new System.Drawing.Size(266, 25);
            this.cmbCamera.StateCommon.ComboBox.Content.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.cmbCamera.TabIndex = 4;
            this.cmbCamera.ValueMember = "DeviceIndex";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(12, 60);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(73, 24);
            this.kryptonLabel2.TabIndex = 5;
            this.kryptonLabel2.Values.Text = "Exposure";
            // 
            // txtExposure
            // 
            this.txtExposure.DrawBackground = true;
            this.txtExposure.Location = new System.Drawing.Point(126, 57);
            this.txtExposure.Maximum = 0;
            this.txtExposure.Minimum = -13;
            this.txtExposure.Name = "txtExposure";
            this.txtExposure.Size = new System.Drawing.Size(266, 27);
            this.txtExposure.TabIndex = 6;
            // 
            // txtCameraAlias
            // 
            this.txtCameraAlias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCameraAlias.Location = new System.Drawing.Point(126, 103);
            this.txtCameraAlias.Name = "txtCameraAlias";
            this.txtCameraAlias.Size = new System.Drawing.Size(266, 27);
            this.txtCameraAlias.TabIndex = 8;
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(12, 106);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(34, 24);
            this.kryptonLabel3.TabIndex = 7;
            this.kryptonLabel3.Values.Text = "Adı";
            // 
            // frmSkyCamera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 212);
            this.Controls.Add(this.txtCameraAlias);
            this.Controls.Add(this.kryptonLabel3);
            this.Controls.Add(this.txtExposure);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.cmbCamera);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.kryptonLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSkyCamera";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kamera";
            this.Load += new System.EventHandler(this.frmSkyRecipe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbCamera)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnOk;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCancel;
        private ComponentFactory.Krypton.Toolkit.KryptonComboBox cmbCamera;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonTrackBar txtExposure;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox txtCameraAlias;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel3;
    }
}