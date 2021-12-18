
namespace HekaEye
{
    partial class frmLiveTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLiveTest));
            this.imgBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCamera = new System.Windows.Forms.ComboBox();
            this.btnTestStatus = new System.Windows.Forms.Button();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox)).BeginInit();
            this.SuspendLayout();
            // 
            // imgBox
            // 
            this.imgBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imgBox.Location = new System.Drawing.Point(12, 80);
            this.imgBox.Name = "imgBox";
            this.imgBox.Size = new System.Drawing.Size(1243, 419);
            this.imgBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgBox.TabIndex = 6;
            this.imgBox.TabStop = false;
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
            // btnTestStatus
            // 
            this.btnTestStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTestStatus.BackColor = System.Drawing.Color.LightBlue;
            this.btnTestStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTestStatus.ForeColor = System.Drawing.Color.Black;
            this.btnTestStatus.Location = new System.Drawing.Point(1072, 12);
            this.btnTestStatus.Name = "btnTestStatus";
            this.btnTestStatus.Size = new System.Drawing.Size(183, 62);
            this.btnTestStatus.TabIndex = 13;
            this.btnTestStatus.Text = "BAŞLAT";
            this.btnTestStatus.UseVisualStyleBackColor = false;
            this.btnTestStatus.Click += new System.EventHandler(this.btnTestStatus_Click);
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMainMenu.BackColor = System.Drawing.Color.SpringGreen;
            this.btnMainMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMainMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMainMenu.Location = new System.Drawing.Point(1072, 408);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(183, 91);
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
            this.lblStatus.Size = new System.Drawing.Size(295, 33);
            this.lblStatus.TabIndex = 15;
            this.lblStatus.Text = "KAMERA AÇILIYOR";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStatus.Visible = false;
            // 
            // lblError
            // 
            this.lblError.BackColor = System.Drawing.Color.Red;
            this.lblError.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblError.Location = new System.Drawing.Point(720, 12);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(295, 33);
            this.lblError.TabIndex = 16;
            this.lblError.Text = "HATALI MALZEME";
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblError.Visible = false;
            // 
            // frmLiveTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1267, 511);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnMainMenu);
            this.Controls.Add(this.btnTestStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbCamera);
            this.Controls.Add(this.imgBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLiveTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Canlı Test";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLiveTest_FormClosing);
            this.Load += new System.EventHandler(this.frmLiveTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imgBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCamera;
        private System.Windows.Forms.Button btnTestStatus;
        private System.Windows.Forms.Button btnMainMenu;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblError;
    }
}