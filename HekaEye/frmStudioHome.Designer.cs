
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
            this.SuspendLayout();
            // 
            // btnTest
            // 
            this.btnTest.BackColor = System.Drawing.Color.Lime;
            this.btnTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTest.Location = new System.Drawing.Point(453, 346);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(165, 92);
            this.btnTest.TabIndex = 0;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = false;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnStudio
            // 
            this.btnStudio.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnStudio.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnStudio.ForeColor = System.Drawing.Color.White;
            this.btnStudio.Location = new System.Drawing.Point(182, 346);
            this.btnStudio.Name = "btnStudio";
            this.btnStudio.Size = new System.Drawing.Size(154, 92);
            this.btnStudio.TabIndex = 1;
            this.btnStudio.Text = "Studio";
            this.btnStudio.UseVisualStyleBackColor = false;
            this.btnStudio.Click += new System.EventHandler(this.btnStudio_Click);
            // 
            // frmStudioHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(801, 455);
            this.Controls.Add(this.btnStudio);
            this.Controls.Add(this.btnTest);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStudioHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Heka Studio";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnStudio;
    }
}