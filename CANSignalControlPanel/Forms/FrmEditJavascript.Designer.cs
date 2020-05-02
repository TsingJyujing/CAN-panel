namespace CANSignalControlPanel.Forms {
    partial class FrmEditJavascript {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditJavascript));
            this.toolSureCancel = new System.Windows.Forms.ToolStrip();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnModify = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.codeHost = new System.Windows.Forms.Integration.ElementHost();
            this.toolSureCancel.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolSureCancel
            // 
            this.toolSureCancel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolSureCancel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCancel,
            this.toolStripSeparator1,
            this.btnModify,
            this.toolStripSeparator2});
            this.toolSureCancel.Location = new System.Drawing.Point(0, 208);
            this.toolSureCancel.Name = "toolSureCancel";
            this.toolSureCancel.Size = new System.Drawing.Size(500, 25);
            this.toolSureCancel.TabIndex = 2;
            this.toolSureCancel.Text = "toolStrip1";
            // 
            // btnCancel
            // 
            this.btnCancel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(57, 22);
            this.btnCancel.Text = "  取消  ";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnModify
            // 
            this.btnModify.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnModify.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnModify.Image = ((System.Drawing.Image)(resources.GetObject("btnModify.Image")));
            this.btnModify.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(57, 22);
            this.btnModify.Text = "  确认  ";
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // codeHost
            // 
            this.codeHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codeHost.Location = new System.Drawing.Point(0, 0);
            this.codeHost.Name = "codeHost";
            this.codeHost.Size = new System.Drawing.Size(500, 208);
            this.codeHost.TabIndex = 3;
            this.codeHost.Child = null;
            // 
            // FrmEditUserDefinedDecodeFunctions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 233);
            this.Controls.Add(this.codeHost);
            this.Controls.Add(this.toolSureCancel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmEditUserDefinedDecodeFunctions";
            this.Text = "用户自定义解析函数";
            this.toolSureCancel.ResumeLayout(false);
            this.toolSureCancel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolSureCancel;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnModify;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Integration.ElementHost codeHost;
    }
}