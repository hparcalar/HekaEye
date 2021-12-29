
namespace HekaEye
{
    partial class frmStudioHome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStudioHome));
            this.btnTest = new System.Windows.Forms.Button();
            this.btnStudio = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnDefinitions = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTest
            // 
            this.btnTest.BackColor = System.Drawing.Color.Transparent;
            this.btnTest.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTest.BackgroundImage")));
            this.btnTest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTest.FlatAppearance.BorderSize = 0;
            this.btnTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTest.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btnTest.Location = new System.Drawing.Point(321, 184);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(165, 92);
            this.btnTest.TabIndex = 0;
            this.btnTest.Text = "TEST";
            this.btnTest.UseVisualStyleBackColor = false;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnStudio
            // 
            this.btnStudio.BackColor = System.Drawing.Color.Transparent;
            this.btnStudio.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnStudio.BackgroundImage")));
            this.btnStudio.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnStudio.FlatAppearance.BorderSize = 0;
            this.btnStudio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStudio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnStudio.ForeColor = System.Drawing.Color.White;
            this.btnStudio.Location = new System.Drawing.Point(12, 184);
            this.btnStudio.Name = "btnStudio";
            this.btnStudio.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnStudio.Size = new System.Drawing.Size(154, 92);
            this.btnStudio.TabIndex = 1;
            this.btnStudio.Text = "KAMERA YÖNETİMİ";
            this.btnStudio.UseVisualStyleBackColor = false;
            this.btnStudio.Click += new System.EventHandler(this.btnStudio_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 87);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btnDefinitions
            // 
            this.btnDefinitions.BackColor = System.Drawing.Color.Transparent;
            this.btnDefinitions.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDefinitions.BackgroundImage")));
            this.btnDefinitions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDefinitions.FlatAppearance.BorderSize = 0;
            this.btnDefinitions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDefinitions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDefinitions.ForeColor = System.Drawing.Color.Black;
            this.btnDefinitions.Location = new System.Drawing.Point(635, 184);
            this.btnDefinitions.Name = "btnDefinitions";
            this.btnDefinitions.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnDefinitions.Size = new System.Drawing.Size(154, 92);
            this.btnDefinitions.TabIndex = 3;
            this.btnDefinitions.Text = "SİSTEM";
            this.btnDefinitions.UseVisualStyleBackColor = false;
            this.btnDefinitions.Click += new System.EventHandler(this.btnDefinitions_Click);
            // 
            // frmStudioHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(801, 455);
            this.Controls.Add(this.btnDefinitions);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnStudio);
            this.Controls.Add(this.btnTest);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStudioHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Heka Studio";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnStudio;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnDefinitions;
    }
}