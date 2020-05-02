namespace CANSignalControlPanel.Forms {
    partial class FrmSignalReceive {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSignalReceive));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnImportConfigure = new System.Windows.Forms.ToolStripButton();
            this.btnExportVspy = new System.Windows.Forms.ToolStripButton();
            this.btnExport = new System.Windows.Forms.ToolStripButton();
            this.btnClear = new System.Windows.Forms.ToolStripButton();
            this.btnFlowMode = new System.Windows.Forms.ToolStripButton();
            this.btnAnalysisMode = new System.Windows.Forms.ToolStripButton();
            this.btnAddCANData = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbAllCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbSpeed = new System.Windows.Forms.ToolStripStatusLabel();
            this.signalHost = new System.Windows.Forms.Integration.ElementHost();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnImportConfigure,
            this.btnExportVspy,
            this.btnExport,
            this.btnClear,
            this.btnFlowMode,
            this.btnAnalysisMode,
            this.btnAddCANData});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(555, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnImportConfigure
            // 
            this.btnImportConfigure.Image = ((System.Drawing.Image)(resources.GetObject("btnImportConfigure.Image")));
            this.btnImportConfigure.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImportConfigure.Name = "btnImportConfigure";
            this.btnImportConfigure.Size = new System.Drawing.Size(103, 22);
            this.btnImportConfigure.Text = "导入CAN解析器";
            this.btnImportConfigure.Click += new System.EventHandler(this.btnImportConfigure_Click);
            // 
            // btnExportVspy
            // 
            this.btnExportVspy.Image = ((System.Drawing.Image)(resources.GetObject("btnExportVspy.Image")));
            this.btnExportVspy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportVspy.Name = "btnExportVspy";
            this.btnExportVspy.Size = new System.Drawing.Size(103, 22);
            this.btnExportVspy.Text = "导出 VSYP CSV";
            this.btnExportVspy.Click += new System.EventHandler(this.btnExportVspy_Click);
            // 
            // btnExport
            // 
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(115, 22);
            this.btnExport.Text = "导出CAN报文记录";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnClear
            // 
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(49, 22);
            this.btnClear.Text = "清空";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnFlowMode
            // 
            this.btnFlowMode.Image = ((System.Drawing.Image)(resources.GetObject("btnFlowMode.Image")));
            this.btnFlowMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFlowMode.Name = "btnFlowMode";
            this.btnFlowMode.Size = new System.Drawing.Size(61, 22);
            this.btnFlowMode.Text = "流模式";
            this.btnFlowMode.Click += new System.EventHandler(this.btnFlowMode_Click);
            // 
            // btnAnalysisMode
            // 
            this.btnAnalysisMode.Image = ((System.Drawing.Image)(resources.GetObject("btnAnalysisMode.Image")));
            this.btnAnalysisMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAnalysisMode.Name = "btnAnalysisMode";
            this.btnAnalysisMode.Size = new System.Drawing.Size(73, 22);
            this.btnAnalysisMode.Text = "解析模式";
            this.btnAnalysisMode.Visible = false;
            this.btnAnalysisMode.Click += new System.EventHandler(this.btnAnalysisMode_Click);
            // 
            // btnAddCANData
            // 
            this.btnAddCANData.Image = ((System.Drawing.Image)(resources.GetObject("btnAddCANData.Image")));
            this.btnAddCANData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddCANData.Name = "btnAddCANData";
            this.btnAddCANData.Size = new System.Drawing.Size(127, 20);
            this.btnAddCANData.Text = "Add Test CAN Data";
            this.btnAddCANData.Visible = false;
            this.btnAddCANData.Click += new System.EventHandler(this.btnAddCANData_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbAllCount,
            this.lbSpeed});
            this.statusStrip1.Location = new System.Drawing.Point(0, 434);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(555, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lbAllCount
            // 
            this.lbAllCount.Name = "lbAllCount";
            this.lbAllCount.Size = new System.Drawing.Size(47, 17);
            this.lbAllCount.Text = "总条数:";
            // 
            // lbSpeed
            // 
            this.lbSpeed.Name = "lbSpeed";
            this.lbSpeed.Size = new System.Drawing.Size(65, 17);
            this.lbSpeed.Text = "传输速度：";
            // 
            // signalHost
            // 
            this.signalHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.signalHost.Location = new System.Drawing.Point(0, 25);
            this.signalHost.Name = "signalHost";
            this.signalHost.Size = new System.Drawing.Size(555, 409);
            this.signalHost.TabIndex = 3;
            this.signalHost.Child = null;
            // 
            // FrmSignalReceive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 456);
            this.Controls.Add(this.signalHost);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmSignalReceive";
            this.Text = "信号接受";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmSignalRX_FormClosing);
            this.Load += new System.EventHandler(this.FrmSignalRX_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnImportConfigure;
        private System.Windows.Forms.ToolStripButton btnClear;
        private System.Windows.Forms.ToolStripButton btnExport;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lbAllCount;
        private System.Windows.Forms.ToolStripStatusLabel lbSpeed;
        private System.Windows.Forms.Integration.ElementHost signalHost;
        private System.Windows.Forms.ToolStripButton btnAddCANData;
        private System.Windows.Forms.ToolStripButton btnFlowMode;
        private System.Windows.Forms.ToolStripButton btnAnalysisMode;
        private System.Windows.Forms.ToolStripButton btnExportVspy;
    }
}