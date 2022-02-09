
namespace HekaEye
{
    partial class frmHekaHsvTest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHekaHsvTest));
            this.lblErrCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.flPanelCams = new System.Windows.Forms.FlowLayoutPanel();
            this.lblHsv = new System.Windows.Forms.Label();
            this.gridStats = new ComponentFactory.Krypton.Toolkit.KryptonDataGridView();
            this.MatchDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NokCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridStats)).BeginInit();
            this.SuspendLayout();
            // 
            // lblErrCount
            // 
            this.lblErrCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblErrCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblErrCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblErrCount.ForeColor = System.Drawing.Color.Red;
            this.lblErrCount.Location = new System.Drawing.Point(848, 433);
            this.lblErrCount.Name = "lblErrCount";
            this.lblErrCount.Size = new System.Drawing.Size(395, 90);
            this.lblErrCount.TabIndex = 33;
            this.lblErrCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(1001, 388);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 25);
            this.label3.TabIndex = 36;
            this.label3.Text = "BUGÜN";
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
            // lblHsv
            // 
            this.lblHsv.AutoSize = true;
            this.lblHsv.ForeColor = System.Drawing.Color.White;
            this.lblHsv.Location = new System.Drawing.Point(14, 14);
            this.lblHsv.Name = "lblHsv";
            this.lblHsv.Size = new System.Drawing.Size(0, 17);
            this.lblHsv.TabIndex = 39;
            // 
            // gridStats
            // 
            this.gridStats.AllowUserToAddRows = false;
            this.gridStats.AllowUserToDeleteRows = false;
            this.gridStats.AllowUserToResizeRows = false;
            this.gridStats.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gridStats.ColumnHeadersHeight = 36;
            this.gridStats.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MatchDate,
            this.NokCount});
            this.gridStats.GridStyles.Style = ComponentFactory.Krypton.Toolkit.DataGridViewStyle.Mixed;
            this.gridStats.GridStyles.StyleColumn = ComponentFactory.Krypton.Toolkit.GridStyle.Sheet;
            this.gridStats.Location = new System.Drawing.Point(848, 51);
            this.gridStats.MultiSelect = false;
            this.gridStats.Name = "gridStats";
            this.gridStats.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleOrange;
            this.gridStats.ReadOnly = true;
            this.gridStats.RowHeadersVisible = false;
            this.gridStats.RowHeadersWidth = 51;
            this.gridStats.RowTemplate.Height = 24;
            this.gridStats.Size = new System.Drawing.Size(395, 303);
            this.gridStats.TabIndex = 40;
            // 
            // MatchDate
            // 
            this.MatchDate.HeaderText = "Tarih";
            this.MatchDate.MinimumWidth = 6;
            this.MatchDate.Name = "MatchDate";
            this.MatchDate.ReadOnly = true;
            this.MatchDate.Width = 165;
            // 
            // NokCount
            // 
            this.NokCount.HeaderText = "Hata Adedi";
            this.NokCount.MinimumWidth = 6;
            this.NokCount.Name = "NokCount";
            this.NokCount.ReadOnly = true;
            this.NokCount.Width = 140;
            // 
            // frmHekaHsvTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1255, 636);
            this.Controls.Add(this.gridStats);
            this.Controls.Add(this.lblHsv);
            this.Controls.Add(this.flPanelCams);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblErrCount);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmHekaHsvTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Heka Görsel Test";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmHekaStudio_FormClosing);
            this.Load += new System.EventHandler(this.frmHekaStudio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridStats)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblErrCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel flPanelCams;
        private System.Windows.Forms.Label lblHsv;
        private ComponentFactory.Krypton.Toolkit.KryptonDataGridView gridStats;
        private System.Windows.Forms.DataGridViewTextBoxColumn MatchDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn NokCount;
    }
}