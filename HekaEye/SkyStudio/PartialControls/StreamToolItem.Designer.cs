
namespace HekaEye.SkyStudio.PartialControls
{
    partial class StreamToolItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblProcName = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.btnDeleteTool = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.SuspendLayout();
            // 
            // lblProcName
            // 
            this.lblProcName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProcName.AutoSize = false;
            this.lblProcName.Location = new System.Drawing.Point(3, 3);
            this.lblProcName.Name = "lblProcName";
            this.lblProcName.Size = new System.Drawing.Size(135, 25);
            this.lblProcName.StateCommon.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.lblProcName.TabIndex = 0;
            this.lblProcName.Values.Text = "-";
            // 
            // btnDeleteTool
            // 
            this.btnDeleteTool.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteTool.Location = new System.Drawing.Point(107, 57);
            this.btnDeleteTool.Name = "btnDeleteTool";
            this.btnDeleteTool.Size = new System.Drawing.Size(31, 25);
            this.btnDeleteTool.TabIndex = 1;
            this.btnDeleteTool.Values.Text = "X";
            this.btnDeleteTool.Click += new System.EventHandler(this.btnDeleteTool_Click);
            // 
            // StreamToolItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnDeleteTool);
            this.Controls.Add(this.lblProcName);
            this.Name = "StreamToolItem";
            this.Size = new System.Drawing.Size(141, 85);
            this.Load += new System.EventHandler(this.StreamToolItem_Load);
            this.Click += new System.EventHandler(this.StreamToolItem_Click);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblProcName;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnDeleteTool;
    }
}
