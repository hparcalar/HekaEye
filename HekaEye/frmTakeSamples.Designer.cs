
namespace HekaEye
{
    partial class frmTakeSamples
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTakeSamples));
            this.btnTakeSample = new System.Windows.Forms.Button();
            this.cmbCamera = new System.Windows.Forms.ComboBox();
            this.imgBox = new System.Windows.Forms.PictureBox();
            this.btnMainMenu = new System.Windows.Forms.Button();
            this.btnSamples = new System.Windows.Forms.Button();
            this.cmbClassList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnTestStatus = new System.Windows.Forms.Button();
            this.trackBarThresh = new System.Windows.Forms.TrackBar();
            this.lblThresh = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarThresh)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTakeSample
            // 
            this.btnTakeSample.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTakeSample.BackColor = System.Drawing.Color.LightBlue;
            this.btnTakeSample.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTakeSample.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTakeSample.ForeColor = System.Drawing.Color.Black;
            this.btnTakeSample.Location = new System.Drawing.Point(1057, 8);
            this.btnTakeSample.Name = "btnTakeSample";
            this.btnTakeSample.Size = new System.Drawing.Size(156, 76);
            this.btnTakeSample.TabIndex = 3;
            this.btnTakeSample.Text = "Seçimi Başlat";
            this.btnTakeSample.UseVisualStyleBackColor = false;
            this.btnTakeSample.Click += new System.EventHandler(this.btnTakeSample_Click);
            // 
            // cmbCamera
            // 
            this.cmbCamera.DisplayMember = "Name";
            this.cmbCamera.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbCamera.FormattingEnabled = true;
            this.cmbCamera.Location = new System.Drawing.Point(136, 12);
            this.cmbCamera.Name = "cmbCamera";
            this.cmbCamera.Size = new System.Drawing.Size(268, 33);
            this.cmbCamera.TabIndex = 4;
            this.cmbCamera.ValueMember = "DeviceIndex";
            this.cmbCamera.SelectedIndexChanged += new System.EventHandler(this.cmbCamera_SelectedIndexChanged);
            // 
            // imgBox
            // 
            this.imgBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imgBox.Location = new System.Drawing.Point(13, 90);
            this.imgBox.Name = "imgBox";
            this.imgBox.Size = new System.Drawing.Size(1200, 438);
            this.imgBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imgBox.TabIndex = 5;
            this.imgBox.TabStop = false;
            this.imgBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imgBox_MouseDown);
            this.imgBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imgBox_MouseMove);
            this.imgBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imgBox_MouseUp);
            // 
            // btnMainMenu
            // 
            this.btnMainMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMainMenu.BackColor = System.Drawing.Color.SpringGreen;
            this.btnMainMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMainMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMainMenu.Location = new System.Drawing.Point(1038, 437);
            this.btnMainMenu.Name = "btnMainMenu";
            this.btnMainMenu.Size = new System.Drawing.Size(175, 91);
            this.btnMainMenu.TabIndex = 7;
            this.btnMainMenu.Text = "ANA MENÜ";
            this.btnMainMenu.UseVisualStyleBackColor = false;
            this.btnMainMenu.Click += new System.EventHandler(this.btnMainMenu_Click);
            // 
            // btnSamples
            // 
            this.btnSamples.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSamples.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnSamples.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSamples.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSamples.ForeColor = System.Drawing.Color.Black;
            this.btnSamples.Location = new System.Drawing.Point(927, 8);
            this.btnSamples.Name = "btnSamples";
            this.btnSamples.Size = new System.Drawing.Size(124, 76);
            this.btnSamples.TabIndex = 8;
            this.btnSamples.Text = "Örnekler";
            this.btnSamples.UseVisualStyleBackColor = false;
            this.btnSamples.Click += new System.EventHandler(this.btnSamples_Click);
            // 
            // cmbClassList
            // 
            this.cmbClassList.DisplayMember = "Name";
            this.cmbClassList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbClassList.FormattingEnabled = true;
            this.cmbClassList.Location = new System.Drawing.Point(136, 51);
            this.cmbClassList.Name = "cmbClassList";
            this.cmbClassList.Size = new System.Drawing.Size(268, 33);
            this.cmbClassList.TabIndex = 9;
            this.cmbClassList.ValueMember = "Id";
            this.cmbClassList.SelectedIndexChanged += new System.EventHandler(this.cmbClassList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 23);
            this.label1.TabIndex = 10;
            this.label1.Text = "KAMERA";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 25);
            this.label2.TabIndex = 11;
            this.label2.Text = "SINIF";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.LemonChiffon;
            this.lblStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblStatus.Location = new System.Drawing.Point(414, 12);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(144, 72);
            this.lblStatus.TabIndex = 12;
            this.lblStatus.Text = "KAMERA AÇILIYOR";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStatus.Visible = false;
            // 
            // btnTestStatus
            // 
            this.btnTestStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTestStatus.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnTestStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTestStatus.ForeColor = System.Drawing.Color.Black;
            this.btnTestStatus.Location = new System.Drawing.Point(771, 8);
            this.btnTestStatus.Name = "btnTestStatus";
            this.btnTestStatus.Size = new System.Drawing.Size(150, 76);
            this.btnTestStatus.TabIndex = 13;
            this.btnTestStatus.Text = "Testi Başlat";
            this.btnTestStatus.UseVisualStyleBackColor = false;
            this.btnTestStatus.Click += new System.EventHandler(this.btnTestStatus_Click);
            // 
            // trackBarThresh
            // 
            this.trackBarThresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarThresh.AutoSize = false;
            this.trackBarThresh.LargeChange = 10;
            this.trackBarThresh.Location = new System.Drawing.Point(596, 41);
            this.trackBarThresh.Maximum = 100;
            this.trackBarThresh.Name = "trackBarThresh";
            this.trackBarThresh.Size = new System.Drawing.Size(166, 43);
            this.trackBarThresh.SmallChange = 5;
            this.trackBarThresh.TabIndex = 14;
            this.trackBarThresh.ValueChanged += new System.EventHandler(this.trackBarThresh_ValueChanged);
            // 
            // lblThresh
            // 
            this.lblThresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblThresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblThresh.Location = new System.Drawing.Point(596, 8);
            this.lblThresh.Name = "lblThresh";
            this.lblThresh.Size = new System.Drawing.Size(166, 23);
            this.lblThresh.TabIndex = 15;
            this.lblThresh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmTakeSamples
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1225, 540);
            this.Controls.Add(this.lblThresh);
            this.Controls.Add(this.trackBarThresh);
            this.Controls.Add(this.btnTestStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbClassList);
            this.Controls.Add(this.btnSamples);
            this.Controls.Add(this.btnMainMenu);
            this.Controls.Add(this.imgBox);
            this.Controls.Add(this.cmbCamera);
            this.Controls.Add(this.btnTakeSample);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTakeSamples";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Örnek Toplama";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTakeSamples_FormClosing);
            this.Load += new System.EventHandler(this.frmTakeSamples_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarThresh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnTakeSample;
        private System.Windows.Forms.ComboBox cmbCamera;
        private System.Windows.Forms.PictureBox imgBox;
        private System.Windows.Forms.Button btnMainMenu;
        private System.Windows.Forms.Button btnSamples;
        private System.Windows.Forms.ComboBox cmbClassList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnTestStatus;
        private System.Windows.Forms.TrackBar trackBarThresh;
        private System.Windows.Forms.Label lblThresh;
    }
}