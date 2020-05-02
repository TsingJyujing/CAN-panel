namespace CANSignalControlPanel.UserWidget {
    partial class MessageTreeEdit {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessageTreeEdit));
            this.MessageTreeView = new System.Windows.Forms.TreeView();
            this.iconSet = new System.Windows.Forms.ImageList(this.components);
            this.ctxmMessage = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnEditMessage = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDeleteMessage = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddSignal = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddSignalContinuous = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddSignalDiscrete = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddSignalSwitch = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddSignalDM1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddSignalUserdefined = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxmSignal = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnEditSignal = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDeleteSignal = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxmTreeView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnAddMessage = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClearAll = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxmMessage.SuspendLayout();
            this.ctxmSignal.SuspendLayout();
            this.ctxmTreeView.SuspendLayout();
            this.SuspendLayout();
            // 
            // MessageTreeView
            // 
            this.MessageTreeView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(43)))), ((int)(((byte)(54)))));
            this.MessageTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MessageTreeView.Font = new System.Drawing.Font("Consolas", 10F);
            this.MessageTreeView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(148)))), ((int)(((byte)(150)))));
            this.MessageTreeView.ImageIndex = 0;
            this.MessageTreeView.ImageList = this.iconSet;
            this.MessageTreeView.Location = new System.Drawing.Point(0, 0);
            this.MessageTreeView.Name = "MessageTreeView";
            this.MessageTreeView.SelectedImageIndex = 0;
            this.MessageTreeView.Size = new System.Drawing.Size(492, 336);
            this.MessageTreeView.TabIndex = 0;
            this.MessageTreeView.DoubleClick += new System.EventHandler(this.MessageTreeView_DoubleClick);
            // 
            // iconSet
            // 
            this.iconSet.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iconSet.ImageStream")));
            this.iconSet.TransparentColor = System.Drawing.Color.Transparent;
            this.iconSet.Images.SetKeyName(0, "Message");
            this.iconSet.Images.SetKeyName(1, "Signal");
            this.iconSet.Images.SetKeyName(2, "Discrete");
            this.iconSet.Images.SetKeyName(3, "DM1");
            this.iconSet.Images.SetKeyName(4, "Switch");
            this.iconSet.Images.SetKeyName(5, "UserDefined");
            // 
            // ctxmMessage
            // 
            this.ctxmMessage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnEditMessage,
            this.btnDeleteMessage,
            this.btnAddSignal});
            this.ctxmMessage.Name = "ctxmMessage";
            this.ctxmMessage.Size = new System.Drawing.Size(119, 70);
            // 
            // btnEditMessage
            // 
            this.btnEditMessage.Name = "btnEditMessage";
            this.btnEditMessage.Size = new System.Drawing.Size(118, 22);
            this.btnEditMessage.Text = "编辑";
            this.btnEditMessage.Click += new System.EventHandler(this.btnEditMessage_Click);
            // 
            // btnDeleteMessage
            // 
            this.btnDeleteMessage.Name = "btnDeleteMessage";
            this.btnDeleteMessage.Size = new System.Drawing.Size(118, 22);
            this.btnDeleteMessage.Text = "删除";
            this.btnDeleteMessage.Click += new System.EventHandler(this.btnDeleteMessage_Click);
            // 
            // btnAddSignal
            // 
            this.btnAddSignal.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddSignalContinuous,
            this.btnAddSignalDiscrete,
            this.btnAddSignalSwitch,
            this.btnAddSignalDM1,
            this.btnAddSignalUserdefined});
            this.btnAddSignal.Name = "btnAddSignal";
            this.btnAddSignal.Size = new System.Drawing.Size(118, 22);
            this.btnAddSignal.Text = "增加信号";
            // 
            // btnAddSignalContinuous
            // 
            this.btnAddSignalContinuous.Name = "btnAddSignalContinuous";
            this.btnAddSignalContinuous.Size = new System.Drawing.Size(130, 22);
            this.btnAddSignalContinuous.Text = "连续量";
            this.btnAddSignalContinuous.Click += new System.EventHandler(this.btnAddSignalContinuous_Click);
            // 
            // btnAddSignalDiscrete
            // 
            this.btnAddSignalDiscrete.Name = "btnAddSignalDiscrete";
            this.btnAddSignalDiscrete.Size = new System.Drawing.Size(130, 22);
            this.btnAddSignalDiscrete.Text = "离散量";
            this.btnAddSignalDiscrete.Click += new System.EventHandler(this.btnAddSignalDiscrete_Click);
            // 
            // btnAddSignalSwitch
            // 
            this.btnAddSignalSwitch.Name = "btnAddSignalSwitch";
            this.btnAddSignalSwitch.Size = new System.Drawing.Size(130, 22);
            this.btnAddSignalSwitch.Text = "开关量";
            this.btnAddSignalSwitch.Click += new System.EventHandler(this.btnAddSignalSwitch_Click);
            // 
            // btnAddSignalDM1
            // 
            this.btnAddSignalDM1.Name = "btnAddSignalDM1";
            this.btnAddSignalDM1.Size = new System.Drawing.Size(130, 22);
            this.btnAddSignalDM1.Text = "DM1故障码";
            this.btnAddSignalDM1.Click += new System.EventHandler(this.btnAddSignalDM1_Click);
            // 
            // btnAddSignalUserdefined
            // 
            this.btnAddSignalUserdefined.Name = "btnAddSignalUserdefined";
            this.btnAddSignalUserdefined.Size = new System.Drawing.Size(130, 22);
            this.btnAddSignalUserdefined.Text = "用户自定义";
            this.btnAddSignalUserdefined.Click += new System.EventHandler(this.btnAddSignalUserdefined_Click);
            // 
            // ctxmSignal
            // 
            this.ctxmSignal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnEditSignal,
            this.btnDeleteSignal});
            this.ctxmSignal.Name = "ctxmSignal";
            this.ctxmSignal.Size = new System.Drawing.Size(95, 48);
            // 
            // btnEditSignal
            // 
            this.btnEditSignal.Name = "btnEditSignal";
            this.btnEditSignal.Size = new System.Drawing.Size(94, 22);
            this.btnEditSignal.Text = "编辑";
            this.btnEditSignal.Click += new System.EventHandler(this.btnEditSignal_Click);
            // 
            // btnDeleteSignal
            // 
            this.btnDeleteSignal.Name = "btnDeleteSignal";
            this.btnDeleteSignal.Size = new System.Drawing.Size(94, 22);
            this.btnDeleteSignal.Text = "删除";
            this.btnDeleteSignal.Click += new System.EventHandler(this.btnDeleteSignal_Click);
            // 
            // ctxmTreeView
            // 
            this.ctxmTreeView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddMessage,
            this.btnClearAll});
            this.ctxmTreeView.Name = "ctxmTreeView";
            this.ctxmTreeView.Size = new System.Drawing.Size(119, 48);
            // 
            // btnAddMessage
            // 
            this.btnAddMessage.Name = "btnAddMessage";
            this.btnAddMessage.Size = new System.Drawing.Size(118, 22);
            this.btnAddMessage.Text = "增加报文";
            this.btnAddMessage.Click += new System.EventHandler(this.btnAddMessage_Click);
            // 
            // btnClearAll
            // 
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(118, 22);
            this.btnClearAll.Text = "清空列表";
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // MessageTreeEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MessageTreeView);
            this.Name = "MessageTreeEdit";
            this.Size = new System.Drawing.Size(492, 336);
            this.ctxmMessage.ResumeLayout(false);
            this.ctxmSignal.ResumeLayout(false);
            this.ctxmTreeView.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView MessageTreeView;
        private System.Windows.Forms.ContextMenuStrip ctxmMessage;
        private System.Windows.Forms.ToolStripMenuItem btnEditMessage;
        private System.Windows.Forms.ToolStripMenuItem btnDeleteMessage;

        private System.Windows.Forms.ContextMenuStrip ctxmSignal;
        private System.Windows.Forms.ToolStripMenuItem btnEditSignal;
        private System.Windows.Forms.ToolStripMenuItem btnDeleteSignal;

        private System.Windows.Forms.ContextMenuStrip ctxmTreeView;
        private System.Windows.Forms.ToolStripMenuItem btnClearAll;

        
        
        
        private System.Windows.Forms.ToolStripMenuItem btnAddMessage;
        
        private System.Windows.Forms.ToolStripMenuItem btnAddSignal;
        private System.Windows.Forms.ToolStripMenuItem btnAddSignalContinuous;
        private System.Windows.Forms.ToolStripMenuItem btnAddSignalSwitch;
        private System.Windows.Forms.ToolStripMenuItem btnAddSignalDM1;
        private System.Windows.Forms.ToolStripMenuItem btnAddSignalDiscrete;
        private System.Windows.Forms.ToolStripMenuItem btnAddSignalUserdefined;
        private System.Windows.Forms.ImageList iconSet;
    }
}
