namespace CANSignalControlPanel.Forms
{
    partial class FrmJSIDE
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmJSIDE));
            this.toolbarHead = new System.Windows.Forms.ToolStrip();
            this.btnNewScript = new System.Windows.Forms.ToolStripButton();
            this.btnOpen = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnSaveAs = new System.Windows.Forms.ToolStripButton();
            this.btnRun = new System.Windows.Forms.ToolStripButton();
            this.btnStop = new System.Windows.Forms.ToolStripButton();
            this.btnClear = new System.Windows.Forms.ToolStripButton();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.lstFiles = new System.Windows.Forms.ListBox();
            this.scSubEditShow = new System.Windows.Forms.SplitContainer();
            this.jseHost = new System.Windows.Forms.Integration.ElementHost();
            this.txtImdyt = new System.Windows.Forms.TextBox();
            this.lstHost = new System.Windows.Forms.Integration.ElementHost();
            this.folderViewer = new Furty.Windows.Forms.FolderTreeView();
            this.toolbarHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scSubEditShow)).BeginInit();
            this.scSubEditShow.Panel1.SuspendLayout();
            this.scSubEditShow.Panel2.SuspendLayout();
            this.scSubEditShow.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolbarHead
            // 
            this.toolbarHead.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNewScript,
            this.btnOpen,
            this.btnSave,
            this.btnSaveAs,
            this.btnRun,
            this.btnStop,
            this.btnClear});
            this.toolbarHead.Location = new System.Drawing.Point(0, 0);
            this.toolbarHead.Name = "toolbarHead";
            this.toolbarHead.Size = new System.Drawing.Size(709, 25);
            this.toolbarHead.TabIndex = 5;
            this.toolbarHead.Text = "toolStrip1";
            // 
            // btnNewScript
            // 
            this.btnNewScript.Image = ((System.Drawing.Image)(resources.GetObject("btnNewScript.Image")));
            this.btnNewScript.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNewScript.Name = "btnNewScript";
            this.btnNewScript.Size = new System.Drawing.Size(73, 22);
            this.btnNewScript.Text = "新建脚本";
            this.btnNewScript.Click += new System.EventHandler(this.btnNewScript_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnOpen.Image")));
            this.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(73, 22);
            this.btnOpen.Text = "打开脚本";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(73, 22);
            this.btnSave.Text = "保存脚本";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveAs.Image")));
            this.btnSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(61, 22);
            this.btnSaveAs.Text = "另存为";
            this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // btnRun
            // 
            this.btnRun.Image = ((System.Drawing.Image)(resources.GetObject("btnRun.Image")));
            this.btnRun.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(49, 22);
            this.btnRun.Text = "运行";
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnStop
            // 
            this.btnStop.Image = ((System.Drawing.Image)(resources.GetObject("btnStop.Image")));
            this.btnStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(49, 22);
            this.btnStop.Text = "停止";
            this.btnStop.Visible = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
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
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.Location = new System.Drawing.Point(0, 25);
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.splitContainer1);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.scSubEditShow);
            this.scMain.Size = new System.Drawing.Size(709, 493);
            this.scMain.SplitterDistance = 224;
            this.scMain.TabIndex = 7;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.folderViewer);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lstFiles);
            this.splitContainer1.Size = new System.Drawing.Size(224, 493);
            this.splitContainer1.SplitterDistance = 291;
            this.splitContainer1.TabIndex = 1;
            // 
            // lstFiles
            // 
            this.lstFiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(54)))));
            this.lstFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstFiles.Font = new System.Drawing.Font("Consolas", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstFiles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(148)))), ((int)(((byte)(150)))));
            this.lstFiles.FormattingEnabled = true;
            this.lstFiles.ItemHeight = 17;
            this.lstFiles.Location = new System.Drawing.Point(0, 0);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(224, 198);
            this.lstFiles.TabIndex = 0;
            this.lstFiles.DoubleClick += new System.EventHandler(this.lstFiles_DoubleClick);
            // 
            // scSubEditShow
            // 
            this.scSubEditShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scSubEditShow.Location = new System.Drawing.Point(0, 0);
            this.scSubEditShow.Name = "scSubEditShow";
            this.scSubEditShow.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scSubEditShow.Panel1
            // 
            this.scSubEditShow.Panel1.Controls.Add(this.jseHost);
            // 
            // scSubEditShow.Panel2
            // 
            this.scSubEditShow.Panel2.Controls.Add(this.lstHost);
            this.scSubEditShow.Panel2.Controls.Add(this.txtImdyt);
            this.scSubEditShow.Size = new System.Drawing.Size(481, 493);
            this.scSubEditShow.SplitterDistance = 292;
            this.scSubEditShow.TabIndex = 0;
            // 
            // jseHost
            // 
            this.jseHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.jseHost.Location = new System.Drawing.Point(0, 0);
            this.jseHost.Name = "jseHost";
            this.jseHost.Size = new System.Drawing.Size(481, 292);
            this.jseHost.TabIndex = 5;
            this.jseHost.Child = null;
            // 
            // txtImdyt
            // 
            this.txtImdyt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(54)))));
            this.txtImdyt.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtImdyt.Font = new System.Drawing.Font("Consolas", 10F);
            this.txtImdyt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(148)))), ((int)(((byte)(150)))));
            this.txtImdyt.Location = new System.Drawing.Point(0, 174);
            this.txtImdyt.Name = "txtImdyt";
            this.txtImdyt.Size = new System.Drawing.Size(481, 23);
            this.txtImdyt.TabIndex = 8;
            this.txtImdyt.Text = "$.alert(1+\"1\");";
            this.txtImdyt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImdyt_KeyPress);
            // 
            // lstHost
            // 
            this.lstHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstHost.Location = new System.Drawing.Point(0, 0);
            this.lstHost.Name = "lstHost";
            this.lstHost.Size = new System.Drawing.Size(481, 174);
            this.lstHost.TabIndex = 9;
            this.lstHost.Text = "elementHost1";
            this.lstHost.Child = null;
            // 
            // folderViewer
            // 
            this.folderViewer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(54)))));
            this.folderViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.folderViewer.Font = new System.Drawing.Font("Consolas", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.folderViewer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(148)))), ((int)(((byte)(150)))));
            this.folderViewer.Location = new System.Drawing.Point(0, 0);
            this.folderViewer.Name = "folderViewer";
            this.folderViewer.PathSeparator = "/";
            this.folderViewer.Size = new System.Drawing.Size(224, 291);
            this.folderViewer.TabIndex = 2;
            this.folderViewer.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.folderViewer_AfterSelect);
            // 
            // FrmJSIDE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 518);
            this.Controls.Add(this.scMain);
            this.Controls.Add(this.toolbarHead);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FrmJSIDE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Javascript CAN IDE";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmDebug_FormClosing);
            this.Load += new System.EventHandler(this.FrmDebug_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmDebug_KeyPress);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.FrmDebug_PreviewKeyDown);
            this.toolbarHead.ResumeLayout(false);
            this.toolbarHead.PerformLayout();
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.scSubEditShow.Panel1.ResumeLayout(false);
            this.scSubEditShow.Panel2.ResumeLayout(false);
            this.scSubEditShow.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scSubEditShow)).EndInit();
            this.scSubEditShow.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolbarHead;
        private System.Windows.Forms.ToolStripButton btnRun;
        private System.Windows.Forms.ToolStripButton btnClear;
        private System.Windows.Forms.ToolStripButton btnOpen;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnStop;
        private System.Windows.Forms.ToolStripButton btnSaveAs;
        private System.Windows.Forms.ToolStripButton btnNewScript;
        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.SplitContainer scSubEditShow;
        private System.Windows.Forms.Integration.ElementHost jseHost;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListBox lstFiles;
        private Furty.Windows.Forms.FolderTreeView folderViewer;
        private System.Windows.Forms.Integration.ElementHost lstHost;
        private System.Windows.Forms.TextBox txtImdyt;

    }
}