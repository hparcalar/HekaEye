
namespace HekaEye
{
    partial class frmDefinitions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDefinitions));
            this.tabDef = new System.Windows.Forms.TabControl();
            this.tpShift = new System.Windows.Forms.TabPage();
            this.txtShiftEnd = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtShiftStart = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnShiftDelete = new System.Windows.Forms.Button();
            this.btnShiftSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.chkShiftActive = new System.Windows.Forms.CheckBox();
            this.txtShiftName = new System.Windows.Forms.TextBox();
            this.txtShiftCode = new System.Windows.Forms.TextBox();
            this.lstShifts = new System.Windows.Forms.ListBox();
            this.tpTest = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnTestDelete = new System.Windows.Forms.Button();
            this.btnTestSave = new System.Windows.Forms.Button();
            this.chkTestActive = new System.Windows.Forms.CheckBox();
            this.txtTestName = new System.Windows.Forms.TextBox();
            this.txtTestCode = new System.Windows.Forms.TextBox();
            this.lstTests = new System.Windows.Forms.ListBox();
            this.tPageFaultProducts = new System.Windows.Forms.TabPage();
            this.tPageReport = new System.Windows.Forms.TabPage();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnNewShift = new System.Windows.Forms.Button();
            this.btnNewExternalTest = new System.Windows.Forms.Button();
            this.tabDef.SuspendLayout();
            this.tpShift.SuspendLayout();
            this.tpTest.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabDef
            // 
            this.tabDef.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabDef.Controls.Add(this.tpShift);
            this.tabDef.Controls.Add(this.tpTest);
            this.tabDef.Controls.Add(this.tPageFaultProducts);
            this.tabDef.Controls.Add(this.tPageReport);
            this.tabDef.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tabDef.Location = new System.Drawing.Point(12, 12);
            this.tabDef.Name = "tabDef";
            this.tabDef.Padding = new System.Drawing.Point(50, 20);
            this.tabDef.SelectedIndex = 0;
            this.tabDef.Size = new System.Drawing.Size(1231, 458);
            this.tabDef.TabIndex = 0;
            // 
            // tpShift
            // 
            this.tpShift.Controls.Add(this.btnNewShift);
            this.tpShift.Controls.Add(this.txtShiftEnd);
            this.tpShift.Controls.Add(this.label5);
            this.tpShift.Controls.Add(this.txtShiftStart);
            this.tpShift.Controls.Add(this.label2);
            this.tpShift.Controls.Add(this.btnShiftDelete);
            this.tpShift.Controls.Add(this.btnShiftSave);
            this.tpShift.Controls.Add(this.label1);
            this.tpShift.Controls.Add(this.chkShiftActive);
            this.tpShift.Controls.Add(this.txtShiftName);
            this.tpShift.Controls.Add(this.txtShiftCode);
            this.tpShift.Controls.Add(this.lstShifts);
            this.tpShift.Location = new System.Drawing.Point(4, 72);
            this.tpShift.Name = "tpShift";
            this.tpShift.Padding = new System.Windows.Forms.Padding(3);
            this.tpShift.Size = new System.Drawing.Size(1223, 382);
            this.tpShift.TabIndex = 0;
            this.tpShift.Text = "VARDİYA";
            this.tpShift.UseVisualStyleBackColor = true;
            // 
            // txtShiftEnd
            // 
            this.txtShiftEnd.Location = new System.Drawing.Point(554, 95);
            this.txtShiftEnd.Name = "txtShiftEnd";
            this.txtShiftEnd.Size = new System.Drawing.Size(110, 34);
            this.txtShiftEnd.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(264, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 31);
            this.label5.TabIndex = 10;
            this.label5.Text = "Saat";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtShiftStart
            // 
            this.txtShiftStart.Location = new System.Drawing.Point(438, 95);
            this.txtShiftStart.Name = "txtShiftStart";
            this.txtShiftStart.Size = new System.Drawing.Size(110, 34);
            this.txtShiftStart.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(264, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 31);
            this.label2.TabIndex = 8;
            this.label2.Text = "Vardiya Adı";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnShiftDelete
            // 
            this.btnShiftDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnShiftDelete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnShiftDelete.BackgroundImage")));
            this.btnShiftDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnShiftDelete.FlatAppearance.BorderSize = 0;
            this.btnShiftDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShiftDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnShiftDelete.ForeColor = System.Drawing.Color.Black;
            this.btnShiftDelete.Location = new System.Drawing.Point(584, 227);
            this.btnShiftDelete.Name = "btnShiftDelete";
            this.btnShiftDelete.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnShiftDelete.Size = new System.Drawing.Size(139, 65);
            this.btnShiftDelete.TabIndex = 7;
            this.btnShiftDelete.Text = "SİL";
            this.btnShiftDelete.UseVisualStyleBackColor = false;
            this.btnShiftDelete.Click += new System.EventHandler(this.btnShiftDelete_Click);
            // 
            // btnShiftSave
            // 
            this.btnShiftSave.BackColor = System.Drawing.Color.Transparent;
            this.btnShiftSave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnShiftSave.BackgroundImage")));
            this.btnShiftSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnShiftSave.FlatAppearance.BorderSize = 0;
            this.btnShiftSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShiftSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnShiftSave.ForeColor = System.Drawing.Color.Black;
            this.btnShiftSave.Location = new System.Drawing.Point(438, 227);
            this.btnShiftSave.Name = "btnShiftSave";
            this.btnShiftSave.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnShiftSave.Size = new System.Drawing.Size(140, 65);
            this.btnShiftSave.TabIndex = 6;
            this.btnShiftSave.Text = "KAYDET";
            this.btnShiftSave.UseVisualStyleBackColor = false;
            this.btnShiftSave.Click += new System.EventHandler(this.btnShiftSave_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(264, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 31);
            this.label1.TabIndex = 4;
            this.label1.Text = "Vardiya Kodu";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkShiftActive
            // 
            this.chkShiftActive.AutoSize = true;
            this.chkShiftActive.Location = new System.Drawing.Point(438, 167);
            this.chkShiftActive.Name = "chkShiftActive";
            this.chkShiftActive.Size = new System.Drawing.Size(85, 33);
            this.chkShiftActive.TabIndex = 3;
            this.chkShiftActive.Text = "Aktif";
            this.chkShiftActive.UseVisualStyleBackColor = true;
            // 
            // txtShiftName
            // 
            this.txtShiftName.Location = new System.Drawing.Point(438, 55);
            this.txtShiftName.Name = "txtShiftName";
            this.txtShiftName.Size = new System.Drawing.Size(226, 34);
            this.txtShiftName.TabIndex = 2;
            // 
            // txtShiftCode
            // 
            this.txtShiftCode.Location = new System.Drawing.Point(438, 15);
            this.txtShiftCode.Name = "txtShiftCode";
            this.txtShiftCode.Size = new System.Drawing.Size(226, 34);
            this.txtShiftCode.TabIndex = 1;
            // 
            // lstShifts
            // 
            this.lstShifts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstShifts.DisplayMember = "ShiftCode";
            this.lstShifts.FormattingEnabled = true;
            this.lstShifts.ItemHeight = 29;
            this.lstShifts.Location = new System.Drawing.Point(6, 15);
            this.lstShifts.Name = "lstShifts";
            this.lstShifts.Size = new System.Drawing.Size(200, 352);
            this.lstShifts.TabIndex = 0;
            this.lstShifts.ValueMember = "Id";
            this.lstShifts.SelectedIndexChanged += new System.EventHandler(this.lstShifts_SelectedIndexChanged);
            // 
            // tpTest
            // 
            this.tpTest.Controls.Add(this.btnNewExternalTest);
            this.tpTest.Controls.Add(this.label4);
            this.tpTest.Controls.Add(this.label3);
            this.tpTest.Controls.Add(this.btnTestDelete);
            this.tpTest.Controls.Add(this.btnTestSave);
            this.tpTest.Controls.Add(this.chkTestActive);
            this.tpTest.Controls.Add(this.txtTestName);
            this.tpTest.Controls.Add(this.txtTestCode);
            this.tpTest.Controls.Add(this.lstTests);
            this.tpTest.Location = new System.Drawing.Point(4, 72);
            this.tpTest.Name = "tpTest";
            this.tpTest.Padding = new System.Windows.Forms.Padding(3);
            this.tpTest.Size = new System.Drawing.Size(1223, 382);
            this.tpTest.TabIndex = 1;
            this.tpTest.Text = "HARİCİ TESTLER";
            this.tpTest.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(264, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 31);
            this.label4.TabIndex = 16;
            this.label4.Text = "Test Adı";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(264, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 31);
            this.label3.TabIndex = 15;
            this.label3.Text = "Test Kodu";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnTestDelete
            // 
            this.btnTestDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnTestDelete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTestDelete.BackgroundImage")));
            this.btnTestDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTestDelete.FlatAppearance.BorderSize = 0;
            this.btnTestDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTestDelete.ForeColor = System.Drawing.Color.Black;
            this.btnTestDelete.Location = new System.Drawing.Point(584, 155);
            this.btnTestDelete.Name = "btnTestDelete";
            this.btnTestDelete.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnTestDelete.Size = new System.Drawing.Size(136, 65);
            this.btnTestDelete.TabIndex = 14;
            this.btnTestDelete.Text = "SİL";
            this.btnTestDelete.UseVisualStyleBackColor = false;
            this.btnTestDelete.Click += new System.EventHandler(this.btnTestDelete_Click);
            // 
            // btnTestSave
            // 
            this.btnTestSave.BackColor = System.Drawing.Color.Transparent;
            this.btnTestSave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnTestSave.BackgroundImage")));
            this.btnTestSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTestSave.FlatAppearance.BorderSize = 0;
            this.btnTestSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTestSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTestSave.ForeColor = System.Drawing.Color.Black;
            this.btnTestSave.Location = new System.Drawing.Point(438, 155);
            this.btnTestSave.Name = "btnTestSave";
            this.btnTestSave.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.btnTestSave.Size = new System.Drawing.Size(140, 65);
            this.btnTestSave.TabIndex = 13;
            this.btnTestSave.Text = "KAYDET";
            this.btnTestSave.UseVisualStyleBackColor = false;
            this.btnTestSave.Click += new System.EventHandler(this.btnTestSave_Click);
            // 
            // chkTestActive
            // 
            this.chkTestActive.AutoSize = true;
            this.chkTestActive.Location = new System.Drawing.Point(438, 95);
            this.chkTestActive.Name = "chkTestActive";
            this.chkTestActive.Size = new System.Drawing.Size(85, 33);
            this.chkTestActive.TabIndex = 10;
            this.chkTestActive.Text = "Aktif";
            this.chkTestActive.UseVisualStyleBackColor = true;
            // 
            // txtTestName
            // 
            this.txtTestName.Location = new System.Drawing.Point(438, 55);
            this.txtTestName.Name = "txtTestName";
            this.txtTestName.Size = new System.Drawing.Size(226, 34);
            this.txtTestName.TabIndex = 9;
            // 
            // txtTestCode
            // 
            this.txtTestCode.Location = new System.Drawing.Point(438, 15);
            this.txtTestCode.Name = "txtTestCode";
            this.txtTestCode.Size = new System.Drawing.Size(226, 34);
            this.txtTestCode.TabIndex = 8;
            // 
            // lstTests
            // 
            this.lstTests.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstTests.DisplayMember = "TestCode";
            this.lstTests.FormattingEnabled = true;
            this.lstTests.ItemHeight = 29;
            this.lstTests.Location = new System.Drawing.Point(6, 15);
            this.lstTests.Name = "lstTests";
            this.lstTests.Size = new System.Drawing.Size(200, 352);
            this.lstTests.TabIndex = 7;
            this.lstTests.ValueMember = "Id";
            this.lstTests.SelectedIndexChanged += new System.EventHandler(this.lstTests_SelectedIndexChanged);
            // 
            // tPageFaultProducts
            // 
            this.tPageFaultProducts.Location = new System.Drawing.Point(4, 72);
            this.tPageFaultProducts.Name = "tPageFaultProducts";
            this.tPageFaultProducts.Size = new System.Drawing.Size(1223, 382);
            this.tPageFaultProducts.TabIndex = 2;
            this.tPageFaultProducts.Text = "HATALI ÜRÜNLER";
            this.tPageFaultProducts.UseVisualStyleBackColor = true;
            // 
            // tPageReport
            // 
            this.tPageReport.Location = new System.Drawing.Point(4, 72);
            this.tPageReport.Name = "tPageReport";
            this.tPageReport.Size = new System.Drawing.Size(1223, 382);
            this.tPageReport.TabIndex = 3;
            this.tPageReport.Text = "RAPOR";
            this.tPageReport.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnClose.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btnClose.Location = new System.Drawing.Point(1074, 481);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(165, 92);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "KAPAT";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnNewShift
            // 
            this.btnNewShift.BackColor = System.Drawing.Color.Transparent;
            this.btnNewShift.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNewShift.BackgroundImage")));
            this.btnNewShift.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNewShift.FlatAppearance.BorderSize = 0;
            this.btnNewShift.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewShift.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnNewShift.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btnNewShift.Location = new System.Drawing.Point(302, 227);
            this.btnNewShift.Name = "btnNewShift";
            this.btnNewShift.Size = new System.Drawing.Size(130, 65);
            this.btnNewShift.TabIndex = 12;
            this.btnNewShift.Text = "YENİ";
            this.btnNewShift.UseVisualStyleBackColor = false;
            this.btnNewShift.Click += new System.EventHandler(this.btnNewShift_Click);
            // 
            // btnNewExternalTest
            // 
            this.btnNewExternalTest.BackColor = System.Drawing.Color.Transparent;
            this.btnNewExternalTest.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNewExternalTest.BackgroundImage")));
            this.btnNewExternalTest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNewExternalTest.FlatAppearance.BorderSize = 0;
            this.btnNewExternalTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewExternalTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnNewExternalTest.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.btnNewExternalTest.Location = new System.Drawing.Point(302, 155);
            this.btnNewExternalTest.Name = "btnNewExternalTest";
            this.btnNewExternalTest.Size = new System.Drawing.Size(130, 65);
            this.btnNewExternalTest.TabIndex = 17;
            this.btnNewExternalTest.Text = "YENİ";
            this.btnNewExternalTest.UseVisualStyleBackColor = false;
            this.btnNewExternalTest.Click += new System.EventHandler(this.btnNewExternalTest_Click);
            // 
            // frmDefinitions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1255, 585);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tabDef);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDefinitions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tanımlar";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmHekaStudio_FormClosing);
            this.Load += new System.EventHandler(this.frmHekaStudio_Load);
            this.tabDef.ResumeLayout(false);
            this.tpShift.ResumeLayout(false);
            this.tpShift.PerformLayout();
            this.tpTest.ResumeLayout(false);
            this.tpTest.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabDef;
        private System.Windows.Forms.TabPage tpShift;
        private System.Windows.Forms.TabPage tpTest;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TabPage tPageFaultProducts;
        private System.Windows.Forms.TabPage tPageReport;
        private System.Windows.Forms.ListBox lstShifts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkShiftActive;
        private System.Windows.Forms.TextBox txtShiftName;
        private System.Windows.Forms.TextBox txtShiftCode;
        private System.Windows.Forms.Button btnShiftSave;
        private System.Windows.Forms.Button btnTestSave;
        private System.Windows.Forms.CheckBox chkTestActive;
        private System.Windows.Forms.TextBox txtTestName;
        private System.Windows.Forms.TextBox txtTestCode;
        private System.Windows.Forms.ListBox lstTests;
        private System.Windows.Forms.Button btnShiftDelete;
        private System.Windows.Forms.Button btnTestDelete;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtShiftEnd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtShiftStart;
        private System.Windows.Forms.Button btnNewShift;
        private System.Windows.Forms.Button btnNewExternalTest;
    }
}