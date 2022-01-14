
namespace HekaEye.SkyStudio
{
    partial class frmSkyEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSkyEditor));
            this.gbProps = new System.Windows.Forms.GroupBox();
            this.prpGrid = new System.Windows.Forms.PropertyGrid();
            this.gbStream = new System.Windows.Forms.GroupBox();
            this.treeRecipe = new System.Windows.Forms.TreeView();
            this.cmsTreeRecipe = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsItemNew = new System.Windows.Forms.ToolStripMenuItem();
            this.tsItemNewRecipe = new System.Windows.Forms.ToolStripMenuItem();
            this.tsItemNewRegion = new System.Windows.Forms.ToolStripMenuItem();
            this.tsItemNewModel = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.imgActiveCapture = new Emgu.CV.UI.ImageBox();
            this.gBoxResultList = new System.Windows.Forms.GroupBox();
            this.flPanelStreamResults = new System.Windows.Forms.FlowLayoutPanel();
            this.tsItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsItemRun = new System.Windows.Forms.ToolStripMenuItem();
            this.tsItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsItemRepaintRegion = new System.Windows.Forms.ToolStripMenuItem();
            this.tsItemCam = new System.Windows.Forms.ToolStripMenuItem();
            this.gbCvTools = new System.Windows.Forms.GroupBox();
            this.flPanelCvTools = new System.Windows.Forms.FlowLayoutPanel();
            this.btnCvtColor = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnBlur = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnFilter2D = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnAdpThr = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnThr = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnInRange = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnSobel = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnFindCtr = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnCanny = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnBiggest = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnApprox = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.btnValidate = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.flPanelStreamTools = new System.Windows.Forms.FlowLayoutPanel();
            this.gbProps.SuspendLayout();
            this.gbStream.SuspendLayout();
            this.cmsTreeRecipe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgActiveCapture)).BeginInit();
            this.gBoxResultList.SuspendLayout();
            this.gbCvTools.SuspendLayout();
            this.flPanelCvTools.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbProps
            // 
            this.gbProps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbProps.Controls.Add(this.prpGrid);
            this.gbProps.Location = new System.Drawing.Point(12, 414);
            this.gbProps.Name = "gbProps";
            this.gbProps.Size = new System.Drawing.Size(259, 270);
            this.gbProps.TabIndex = 0;
            this.gbProps.TabStop = false;
            this.gbProps.Text = "Özellikler";
            // 
            // prpGrid
            // 
            this.prpGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prpGrid.Location = new System.Drawing.Point(3, 18);
            this.prpGrid.Name = "prpGrid";
            this.prpGrid.Size = new System.Drawing.Size(253, 249);
            this.prpGrid.TabIndex = 0;
            // 
            // gbStream
            // 
            this.gbStream.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbStream.Controls.Add(this.flPanelStreamTools);
            this.gbStream.Location = new System.Drawing.Point(592, 414);
            this.gbStream.Name = "gbStream";
            this.gbStream.Size = new System.Drawing.Size(671, 270);
            this.gbStream.TabIndex = 1;
            this.gbStream.TabStop = false;
            this.gbStream.Text = "Süreç Akışı";
            // 
            // treeRecipe
            // 
            this.treeRecipe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeRecipe.ContextMenuStrip = this.cmsTreeRecipe;
            this.treeRecipe.Location = new System.Drawing.Point(12, 12);
            this.treeRecipe.Name = "treeRecipe";
            this.treeRecipe.Size = new System.Drawing.Size(259, 396);
            this.treeRecipe.TabIndex = 2;
            this.treeRecipe.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeRecipe_AfterSelect);
            // 
            // cmsTreeRecipe
            // 
            this.cmsTreeRecipe.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmsTreeRecipe.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsTreeRecipe.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsItemNew,
            this.tsItemRepaintRegion,
            this.tsItemEdit,
            this.toolStripSeparator1,
            this.tsItemSave,
            this.tsItemDelete,
            this.toolStripSeparator2,
            this.tsItemRun});
            this.cmsTreeRecipe.Name = "cmsTreeRecipe";
            this.cmsTreeRecipe.Size = new System.Drawing.Size(153, 160);
            this.cmsTreeRecipe.Opening += new System.ComponentModel.CancelEventHandler(this.cmsTreeRecipe_Opening);
            // 
            // tsItemNew
            // 
            this.tsItemNew.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsItemNewRecipe,
            this.tsItemCam,
            this.tsItemNewRegion,
            this.tsItemNewModel});
            this.tsItemNew.Name = "tsItemNew";
            this.tsItemNew.Size = new System.Drawing.Size(152, 24);
            this.tsItemNew.Text = "Yeni";
            // 
            // tsItemNewRecipe
            // 
            this.tsItemNewRecipe.Name = "tsItemNewRecipe";
            this.tsItemNewRecipe.Size = new System.Drawing.Size(224, 26);
            this.tsItemNewRecipe.Text = "Reçete";
            this.tsItemNewRecipe.Click += new System.EventHandler(this.tsItemNewRecipe_Click);
            // 
            // tsItemNewRegion
            // 
            this.tsItemNewRegion.Name = "tsItemNewRegion";
            this.tsItemNewRegion.Size = new System.Drawing.Size(224, 26);
            this.tsItemNewRegion.Text = "Bölge";
            this.tsItemNewRegion.Click += new System.EventHandler(this.tsItemNewRegion_Click);
            // 
            // tsItemNewModel
            // 
            this.tsItemNewModel.Name = "tsItemNewModel";
            this.tsItemNewModel.Size = new System.Drawing.Size(224, 26);
            this.tsItemNewModel.Text = "Model";
            this.tsItemNewModel.Click += new System.EventHandler(this.tsItemNewModel_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // tsItemDelete
            // 
            this.tsItemDelete.Name = "tsItemDelete";
            this.tsItemDelete.Size = new System.Drawing.Size(152, 24);
            this.tsItemDelete.Text = "Sil";
            // 
            // imgActiveCapture
            // 
            this.imgActiveCapture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imgActiveCapture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imgActiveCapture.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imgActiveCapture.Location = new System.Drawing.Point(277, 12);
            this.imgActiveCapture.Name = "imgActiveCapture";
            this.imgActiveCapture.Size = new System.Drawing.Size(485, 396);
            this.imgActiveCapture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgActiveCapture.TabIndex = 2;
            this.imgActiveCapture.TabStop = false;
            this.imgActiveCapture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imgBox_MouseDown);
            this.imgActiveCapture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imgBox_MouseMove);
            this.imgActiveCapture.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imgBox_MouseUp);
            // 
            // gBoxResultList
            // 
            this.gBoxResultList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gBoxResultList.Controls.Add(this.flPanelStreamResults);
            this.gBoxResultList.Location = new System.Drawing.Point(768, 12);
            this.gBoxResultList.Name = "gBoxResultList";
            this.gBoxResultList.Size = new System.Drawing.Size(495, 396);
            this.gBoxResultList.TabIndex = 3;
            this.gBoxResultList.TabStop = false;
            this.gBoxResultList.Text = "Akış Görünümleri";
            // 
            // flPanelStreamResults
            // 
            this.flPanelStreamResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flPanelStreamResults.Location = new System.Drawing.Point(3, 18);
            this.flPanelStreamResults.Name = "flPanelStreamResults";
            this.flPanelStreamResults.Size = new System.Drawing.Size(489, 375);
            this.flPanelStreamResults.TabIndex = 0;
            // 
            // tsItemSave
            // 
            this.tsItemSave.Name = "tsItemSave";
            this.tsItemSave.Size = new System.Drawing.Size(152, 24);
            this.tsItemSave.Text = "Kaydet";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // tsItemRun
            // 
            this.tsItemRun.Name = "tsItemRun";
            this.tsItemRun.Size = new System.Drawing.Size(152, 24);
            this.tsItemRun.Text = "Çalıştır";
            this.tsItemRun.Visible = false;
            this.tsItemRun.Click += new System.EventHandler(this.tsItemRun_Click);
            // 
            // tsItemEdit
            // 
            this.tsItemEdit.Name = "tsItemEdit";
            this.tsItemEdit.Size = new System.Drawing.Size(152, 24);
            this.tsItemEdit.Text = "Düzenle";
            this.tsItemEdit.Click += new System.EventHandler(this.tsItemEdit_Click);
            // 
            // tsItemRepaintRegion
            // 
            this.tsItemRepaintRegion.Name = "tsItemRepaintRegion";
            this.tsItemRepaintRegion.Size = new System.Drawing.Size(152, 24);
            this.tsItemRepaintRegion.Text = "Bölgeyi Çiz";
            this.tsItemRepaintRegion.Visible = false;
            this.tsItemRepaintRegion.Click += new System.EventHandler(this.tsItemRepaintRegion_Click);
            // 
            // tsItemCam
            // 
            this.tsItemCam.Name = "tsItemCam";
            this.tsItemCam.Size = new System.Drawing.Size(224, 26);
            this.tsItemCam.Text = "Kamera";
            this.tsItemCam.Click += new System.EventHandler(this.tsItemCam_Click);
            // 
            // gbCvTools
            // 
            this.gbCvTools.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbCvTools.Controls.Add(this.flPanelCvTools);
            this.gbCvTools.Location = new System.Drawing.Point(277, 414);
            this.gbCvTools.Name = "gbCvTools";
            this.gbCvTools.Size = new System.Drawing.Size(309, 270);
            this.gbCvTools.TabIndex = 4;
            this.gbCvTools.TabStop = false;
            this.gbCvTools.Text = "Görsel İşlemler";
            // 
            // flPanelCvTools
            // 
            this.flPanelCvTools.Controls.Add(this.btnCvtColor);
            this.flPanelCvTools.Controls.Add(this.btnBlur);
            this.flPanelCvTools.Controls.Add(this.btnFilter2D);
            this.flPanelCvTools.Controls.Add(this.btnAdpThr);
            this.flPanelCvTools.Controls.Add(this.btnThr);
            this.flPanelCvTools.Controls.Add(this.btnInRange);
            this.flPanelCvTools.Controls.Add(this.btnSobel);
            this.flPanelCvTools.Controls.Add(this.btnFindCtr);
            this.flPanelCvTools.Controls.Add(this.btnCanny);
            this.flPanelCvTools.Controls.Add(this.btnBiggest);
            this.flPanelCvTools.Controls.Add(this.btnApprox);
            this.flPanelCvTools.Controls.Add(this.btnValidate);
            this.flPanelCvTools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flPanelCvTools.Location = new System.Drawing.Point(3, 18);
            this.flPanelCvTools.Name = "flPanelCvTools";
            this.flPanelCvTools.Size = new System.Drawing.Size(303, 249);
            this.flPanelCvTools.TabIndex = 0;
            // 
            // btnCvtColor
            // 
            this.btnCvtColor.Location = new System.Drawing.Point(3, 3);
            this.btnCvtColor.Name = "btnCvtColor";
            this.btnCvtColor.Size = new System.Drawing.Size(94, 47);
            this.btnCvtColor.TabIndex = 0;
            this.btnCvtColor.Tag = "1";
            this.btnCvtColor.Values.Text = "CvtColor";
            this.btnCvtColor.Click += new System.EventHandler(this.btnCvTools_Click);
            // 
            // btnBlur
            // 
            this.btnBlur.Location = new System.Drawing.Point(103, 3);
            this.btnBlur.Name = "btnBlur";
            this.btnBlur.Size = new System.Drawing.Size(94, 47);
            this.btnBlur.TabIndex = 1;
            this.btnBlur.Tag = "2";
            this.btnBlur.Values.Text = "Blur";
            this.btnBlur.Click += new System.EventHandler(this.btnCvTools_Click);
            // 
            // btnFilter2D
            // 
            this.btnFilter2D.Location = new System.Drawing.Point(203, 3);
            this.btnFilter2D.Name = "btnFilter2D";
            this.btnFilter2D.Size = new System.Drawing.Size(94, 47);
            this.btnFilter2D.TabIndex = 2;
            this.btnFilter2D.Tag = "3";
            this.btnFilter2D.Values.Text = "Filter2D";
            this.btnFilter2D.Click += new System.EventHandler(this.btnCvTools_Click);
            // 
            // btnAdpThr
            // 
            this.btnAdpThr.Location = new System.Drawing.Point(3, 56);
            this.btnAdpThr.Name = "btnAdpThr";
            this.btnAdpThr.Size = new System.Drawing.Size(94, 47);
            this.btnAdpThr.TabIndex = 3;
            this.btnAdpThr.Tag = "4";
            this.btnAdpThr.Values.Text = "Adp Thr";
            this.btnAdpThr.Click += new System.EventHandler(this.btnCvTools_Click);
            // 
            // btnThr
            // 
            this.btnThr.Location = new System.Drawing.Point(103, 56);
            this.btnThr.Name = "btnThr";
            this.btnThr.Size = new System.Drawing.Size(94, 47);
            this.btnThr.TabIndex = 4;
            this.btnThr.Tag = "5";
            this.btnThr.Values.Text = "Thr";
            this.btnThr.Click += new System.EventHandler(this.btnCvTools_Click);
            // 
            // btnInRange
            // 
            this.btnInRange.Location = new System.Drawing.Point(203, 56);
            this.btnInRange.Name = "btnInRange";
            this.btnInRange.Size = new System.Drawing.Size(94, 47);
            this.btnInRange.TabIndex = 5;
            this.btnInRange.Tag = "6";
            this.btnInRange.Values.Text = "InRange";
            this.btnInRange.Click += new System.EventHandler(this.btnCvTools_Click);
            // 
            // btnSobel
            // 
            this.btnSobel.Location = new System.Drawing.Point(3, 109);
            this.btnSobel.Name = "btnSobel";
            this.btnSobel.Size = new System.Drawing.Size(94, 47);
            this.btnSobel.TabIndex = 6;
            this.btnSobel.Tag = "7";
            this.btnSobel.Values.Text = "Sobel";
            this.btnSobel.Click += new System.EventHandler(this.btnCvTools_Click);
            // 
            // btnFindCtr
            // 
            this.btnFindCtr.Location = new System.Drawing.Point(103, 109);
            this.btnFindCtr.Name = "btnFindCtr";
            this.btnFindCtr.Size = new System.Drawing.Size(94, 47);
            this.btnFindCtr.TabIndex = 7;
            this.btnFindCtr.Tag = "8";
            this.btnFindCtr.Values.Text = "FindCtr";
            this.btnFindCtr.Click += new System.EventHandler(this.btnCvTools_Click);
            // 
            // btnCanny
            // 
            this.btnCanny.Location = new System.Drawing.Point(203, 109);
            this.btnCanny.Name = "btnCanny";
            this.btnCanny.Size = new System.Drawing.Size(94, 47);
            this.btnCanny.TabIndex = 8;
            this.btnCanny.Tag = "9";
            this.btnCanny.Values.Text = "Canny";
            this.btnCanny.Click += new System.EventHandler(this.btnCvTools_Click);
            // 
            // btnBiggest
            // 
            this.btnBiggest.Location = new System.Drawing.Point(3, 162);
            this.btnBiggest.Name = "btnBiggest";
            this.btnBiggest.Size = new System.Drawing.Size(94, 47);
            this.btnBiggest.TabIndex = 9;
            this.btnBiggest.Tag = "10";
            this.btnBiggest.Values.Text = "Biggest";
            this.btnBiggest.Click += new System.EventHandler(this.btnCvTools_Click);
            // 
            // btnApprox
            // 
            this.btnApprox.Location = new System.Drawing.Point(103, 162);
            this.btnApprox.Name = "btnApprox";
            this.btnApprox.Size = new System.Drawing.Size(94, 47);
            this.btnApprox.TabIndex = 10;
            this.btnApprox.Tag = "12";
            this.btnApprox.Values.Text = "Approx";
            this.btnApprox.Click += new System.EventHandler(this.btnCvTools_Click);
            // 
            // btnValidate
            // 
            this.btnValidate.Location = new System.Drawing.Point(203, 162);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.Office365Black;
            this.btnValidate.Size = new System.Drawing.Size(94, 47);
            this.btnValidate.TabIndex = 11;
            this.btnValidate.Tag = "13";
            this.btnValidate.Values.Text = "Validate";
            this.btnValidate.Click += new System.EventHandler(this.btnCvTools_Click);
            // 
            // flPanelStreamTools
            // 
            this.flPanelStreamTools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flPanelStreamTools.Location = new System.Drawing.Point(3, 18);
            this.flPanelStreamTools.Name = "flPanelStreamTools";
            this.flPanelStreamTools.Size = new System.Drawing.Size(665, 249);
            this.flPanelStreamTools.TabIndex = 0;
            // 
            // frmSkyEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1275, 690);
            this.Controls.Add(this.gbCvTools);
            this.Controls.Add(this.gBoxResultList);
            this.Controls.Add(this.imgActiveCapture);
            this.Controls.Add(this.treeRecipe);
            this.Controls.Add(this.gbStream);
            this.Controls.Add(this.gbProps);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSkyEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Heka Eye | EDITOR";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSkyEditor_FormClosing);
            this.Load += new System.EventHandler(this.frmSkyEditor_Load);
            this.gbProps.ResumeLayout(false);
            this.gbStream.ResumeLayout(false);
            this.cmsTreeRecipe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgActiveCapture)).EndInit();
            this.gBoxResultList.ResumeLayout(false);
            this.gbCvTools.ResumeLayout(false);
            this.flPanelCvTools.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbProps;
        private System.Windows.Forms.GroupBox gbStream;
        private System.Windows.Forms.TreeView treeRecipe;
        private System.Windows.Forms.ContextMenuStrip cmsTreeRecipe;
        private Emgu.CV.UI.ImageBox imgActiveCapture;
        private System.Windows.Forms.PropertyGrid prpGrid;
        private System.Windows.Forms.ToolStripMenuItem tsItemNew;
        private System.Windows.Forms.ToolStripMenuItem tsItemNewRecipe;
        private System.Windows.Forms.ToolStripMenuItem tsItemNewRegion;
        private System.Windows.Forms.ToolStripMenuItem tsItemNewModel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsItemDelete;
        private System.Windows.Forms.GroupBox gBoxResultList;
        private System.Windows.Forms.FlowLayoutPanel flPanelStreamResults;
        private System.Windows.Forms.ToolStripMenuItem tsItemSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsItemRun;
        private System.Windows.Forms.ToolStripMenuItem tsItemEdit;
        private System.Windows.Forms.ToolStripMenuItem tsItemRepaintRegion;
        private System.Windows.Forms.ToolStripMenuItem tsItemCam;
        private System.Windows.Forms.GroupBox gbCvTools;
        private System.Windows.Forms.FlowLayoutPanel flPanelCvTools;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCvtColor;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnBlur;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnFilter2D;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnAdpThr;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnThr;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnInRange;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnSobel;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnFindCtr;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnCanny;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnBiggest;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnApprox;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnValidate;
        private System.Windows.Forms.FlowLayoutPanel flPanelStreamTools;
    }
}