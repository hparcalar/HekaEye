
namespace HekaEye
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnClasses = new System.Windows.Forms.Button();
            this.btnTakeSamples = new System.Windows.Forms.Button();
            this.btnLiveTest = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnEyeStudio = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnClasses
            // 
            this.btnClasses.BackColor = System.Drawing.Color.SkyBlue;
            this.btnClasses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClasses.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnClasses.Location = new System.Drawing.Point(72, 12);
            this.btnClasses.Name = "btnClasses";
            this.btnClasses.Size = new System.Drawing.Size(233, 99);
            this.btnClasses.TabIndex = 0;
            this.btnClasses.Text = "SINIFLAR";
            this.btnClasses.UseVisualStyleBackColor = false;
            this.btnClasses.Click += new System.EventHandler(this.btnClasses_Click);
            // 
            // btnTakeSamples
            // 
            this.btnTakeSamples.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTakeSamples.BackColor = System.Drawing.Color.SkyBlue;
            this.btnTakeSamples.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTakeSamples.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTakeSamples.Location = new System.Drawing.Point(798, 12);
            this.btnTakeSamples.Name = "btnTakeSamples";
            this.btnTakeSamples.Size = new System.Drawing.Size(233, 99);
            this.btnTakeSamples.TabIndex = 1;
            this.btnTakeSamples.Text = "ÖRNEK TOPLAMA";
            this.btnTakeSamples.UseVisualStyleBackColor = false;
            this.btnTakeSamples.Click += new System.EventHandler(this.btnTakeSamples_Click);
            // 
            // btnLiveTest
            // 
            this.btnLiveTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLiveTest.BackColor = System.Drawing.Color.SpringGreen;
            this.btnLiveTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLiveTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnLiveTest.Location = new System.Drawing.Point(72, 429);
            this.btnLiveTest.Name = "btnLiveTest";
            this.btnLiveTest.Size = new System.Drawing.Size(233, 91);
            this.btnLiveTest.TabIndex = 2;
            this.btnLiveTest.Text = "CANLI TEST";
            this.btnLiveTest.UseVisualStyleBackColor = false;
            this.btnLiveTest.Click += new System.EventHandler(this.btnLiveTest_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Tomato;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(798, 429);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(233, 91);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "KAPAT";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnEyeStudio
            // 
            this.btnEyeStudio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEyeStudio.BackColor = System.Drawing.Color.SkyBlue;
            this.btnEyeStudio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEyeStudio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnEyeStudio.Location = new System.Drawing.Point(559, 12);
            this.btnEyeStudio.Name = "btnEyeStudio";
            this.btnEyeStudio.Size = new System.Drawing.Size(233, 99);
            this.btnEyeStudio.TabIndex = 5;
            this.btnEyeStudio.Text = "EYE STUDIO";
            this.btnEyeStudio.UseVisualStyleBackColor = false;
            this.btnEyeStudio.Click += new System.EventHandler(this.btnEyeStudio_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1108, 550);
            this.Controls.Add(this.btnEyeStudio);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnLiveTest);
            this.Controls.Add(this.btnTakeSamples);
            this.Controls.Add(this.btnClasses);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Heka EYE";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClasses;
        private System.Windows.Forms.Button btnTakeSamples;
        private System.Windows.Forms.Button btnLiveTest;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnEyeStudio;
    }
}

