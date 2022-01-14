
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnStudio = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnTest = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnDefinitions = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
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
            // btnStudio
            // 
            this.btnStudio.Location = new System.Drawing.Point(12, 184);
            this.btnStudio.Name = "btnStudio";
            this.btnStudio.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue;
            this.btnStudio.Size = new System.Drawing.Size(281, 92);
            this.btnStudio.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnStudio.StateCommon.Content.ShortText.MultiLine = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.btnStudio.StateCommon.Content.ShortText.MultiLineH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnStudio.StateCommon.Content.ShortText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Word;
            this.btnStudio.TabIndex = 4;
            this.btnStudio.Values.Text = "KAMERA YÖNETİMİ";
            this.btnStudio.Click += new System.EventHandler(this.btnStudio_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(247, 331);
            this.btnTest.Name = "btnTest";
            this.btnTest.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue;
            this.btnTest.Size = new System.Drawing.Size(281, 92);
            this.btnTest.StateCommon.Back.Color1 = System.Drawing.Color.Lime;
            this.btnTest.StateCommon.Back.Color2 = System.Drawing.Color.Black;
            this.btnTest.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.btnTest.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.Black;
            this.btnTest.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTest.StateCommon.Content.ShortText.MultiLine = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.btnTest.StateCommon.Content.ShortText.MultiLineH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnTest.StateCommon.Content.ShortText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Word;
            this.btnTest.TabIndex = 5;
            this.btnTest.Values.Text = "TESTE BAŞLA";
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnDefinitions
            // 
            this.btnDefinitions.Location = new System.Drawing.Point(508, 184);
            this.btnDefinitions.Name = "btnDefinitions";
            this.btnDefinitions.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleBlue;
            this.btnDefinitions.Size = new System.Drawing.Size(281, 92);
            this.btnDefinitions.StateCommon.Back.Color1 = System.Drawing.Color.DeepSkyBlue;
            this.btnDefinitions.StateCommon.Back.Color2 = System.Drawing.Color.Black;
            this.btnDefinitions.StateCommon.Content.ShortText.Color1 = System.Drawing.Color.Black;
            this.btnDefinitions.StateCommon.Content.ShortText.Color2 = System.Drawing.Color.Black;
            this.btnDefinitions.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDefinitions.StateCommon.Content.ShortText.MultiLine = ComponentFactory.Krypton.Toolkit.InheritBool.True;
            this.btnDefinitions.StateCommon.Content.ShortText.MultiLineH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.btnDefinitions.StateCommon.Content.ShortText.Trim = ComponentFactory.Krypton.Toolkit.PaletteTextTrim.Word;
            this.btnDefinitions.TabIndex = 6;
            this.btnDefinitions.Values.Text = "SİSTEM";
            this.btnDefinitions.Click += new System.EventHandler(this.btnDefinitions_Click);
            // 
            // frmStudioHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(98)))), ((int)(((byte)(149)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(801, 455);
            this.Controls.Add(this.btnDefinitions);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnStudio);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStudioHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Heka Eye";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnStudio;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnTest;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnDefinitions;
    }
}