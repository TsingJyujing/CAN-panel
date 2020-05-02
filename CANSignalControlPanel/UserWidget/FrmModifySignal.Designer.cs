namespace CANSignalControlPanel.UserWidget {
    partial class FrmModifySignal {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmModifySignal));
            this.toolSureCancel = new System.Windows.Forms.ToolStrip();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnModify = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tabSignal = new System.Windows.Forms.TabPage();
            this.panelSignalBasicInfo = new System.Windows.Forms.Panel();
            this.lb1 = new System.Windows.Forms.Label();
            this.txtSignalName = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtBitLen = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtStartBit = new System.Windows.Forms.TextBox();
            this.txtStartByte = new System.Windows.Forms.TextBox();
            this.panelModifyType = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.toolSureCancel.SuspendLayout();
            this.tabSignal.SuspendLayout();
            this.panelSignalBasicInfo.SuspendLayout();
            this.tabControl1.SuspendLayout();
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
            this.toolSureCancel.Location = new System.Drawing.Point(0, 302);
            this.toolSureCancel.Name = "toolSureCancel";
            this.toolSureCancel.Size = new System.Drawing.Size(471, 25);
            this.toolSureCancel.TabIndex = 1;
            this.toolSureCancel.Text = "toolStrip1";
            // 
            // btnCancel
            // 
            this.btnCancel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(52, 22);
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
            this.btnModify.Size = new System.Drawing.Size(52, 22);
            this.btnModify.Text = "  确认  ";
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tabSignal
            // 
            this.tabSignal.Controls.Add(this.panelModifyType);
            this.tabSignal.Controls.Add(this.panelSignalBasicInfo);
            this.tabSignal.Location = new System.Drawing.Point(4, 22);
            this.tabSignal.Name = "tabSignal";
            this.tabSignal.Padding = new System.Windows.Forms.Padding(3);
            this.tabSignal.Size = new System.Drawing.Size(463, 276);
            this.tabSignal.TabIndex = 0;
            this.tabSignal.Text = "信号量编辑";
            this.tabSignal.UseVisualStyleBackColor = true;
            // 
            // panelSignalBasicInfo
            // 
            this.panelSignalBasicInfo.Controls.Add(this.txtStartByte);
            this.panelSignalBasicInfo.Controls.Add(this.txtStartBit);
            this.panelSignalBasicInfo.Controls.Add(this.label13);
            this.panelSignalBasicInfo.Controls.Add(this.txtBitLen);
            this.panelSignalBasicInfo.Controls.Add(this.label12);
            this.panelSignalBasicInfo.Controls.Add(this.label14);
            this.panelSignalBasicInfo.Controls.Add(this.txtSignalName);
            this.panelSignalBasicInfo.Controls.Add(this.lb1);
            this.panelSignalBasicInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSignalBasicInfo.Location = new System.Drawing.Point(3, 3);
            this.panelSignalBasicInfo.Name = "panelSignalBasicInfo";
            this.panelSignalBasicInfo.Size = new System.Drawing.Size(457, 64);
            this.panelSignalBasicInfo.TabIndex = 1;
            // 
            // lb1
            // 
            this.lb1.AutoSize = true;
            this.lb1.Location = new System.Drawing.Point(5, 10);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(53, 12);
            this.lb1.TabIndex = 0;
            this.lb1.Text = "信号名称";
            // 
            // txtSignalName
            // 
            this.txtSignalName.Location = new System.Drawing.Point(61, 9);
            this.txtSignalName.Name = "txtSignalName";
            this.txtSignalName.Size = new System.Drawing.Size(100, 21);
            this.txtSignalName.TabIndex = 1;
            this.txtSignalName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(172, 12);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(95, 12);
            this.label14.TabIndex = 38;
            this.label14.Text = "信号长度（Bit）";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 36);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 36;
            this.label12.Text = "起始字节";
            // 
            // txtBitLen
            // 
            this.txtBitLen.Location = new System.Drawing.Point(273, 7);
            this.txtBitLen.Name = "txtBitLen";
            this.txtBitLen.Size = new System.Drawing.Size(100, 21);
            this.txtBitLen.TabIndex = 41;
            this.txtBitLen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(203, 36);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 12);
            this.label13.TabIndex = 37;
            this.label13.Text = "起始位";
            // 
            // txtStartBit
            // 
            this.txtStartBit.Location = new System.Drawing.Point(273, 33);
            this.txtStartBit.Name = "txtStartBit";
            this.txtStartBit.Size = new System.Drawing.Size(100, 21);
            this.txtStartBit.TabIndex = 40;
            this.txtStartBit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtStartByte
            // 
            this.txtStartByte.Location = new System.Drawing.Point(61, 33);
            this.txtStartByte.Name = "txtStartByte";
            this.txtStartByte.Size = new System.Drawing.Size(100, 21);
            this.txtStartByte.TabIndex = 39;
            this.txtStartByte.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panelModifyType
            // 
            this.panelModifyType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelModifyType.Location = new System.Drawing.Point(3, 67);
            this.panelModifyType.Name = "panelModifyType";
            this.panelModifyType.Size = new System.Drawing.Size(457, 206);
            this.panelModifyType.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabSignal);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(471, 302);
            this.tabControl1.TabIndex = 2;
            // 
            // FrmModifySignal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 327);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolSureCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmModifySignal";
            this.Text = "信号量编辑器";
            this.Load += new System.EventHandler(this.FrmModifySignal_Load);
            this.toolSureCancel.ResumeLayout(false);
            this.toolSureCancel.PerformLayout();
            this.tabSignal.ResumeLayout(false);
            this.panelSignalBasicInfo.ResumeLayout(false);
            this.panelSignalBasicInfo.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolSureCancel;
        private System.Windows.Forms.ToolStripButton btnModify;
        private System.Windows.Forms.ToolStripButton btnCancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.TabPage tabSignal;
        private System.Windows.Forms.Panel panelModifyType;
        private System.Windows.Forms.Panel panelSignalBasicInfo;
        private System.Windows.Forms.TextBox txtStartByte;
        private System.Windows.Forms.TextBox txtStartBit;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtBitLen;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtSignalName;
        private System.Windows.Forms.Label lb1;
        private System.Windows.Forms.TabControl tabControl1;
    }
}