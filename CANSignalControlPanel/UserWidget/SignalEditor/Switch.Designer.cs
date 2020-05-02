namespace CANSignalControlPanel.UserWidget.SignalEditor {
    partial class Switch {
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
            this.valueGroup = new System.Windows.Forms.GroupBox();
            this.radUnavailable = new System.Windows.Forms.RadioButton();
            this.radError = new System.Windows.Forms.RadioButton();
            this.radOn = new System.Windows.Forms.RadioButton();
            this.radOff = new System.Windows.Forms.RadioButton();
            this.valueGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // valueGroup
            // 
            this.valueGroup.Controls.Add(this.radUnavailable);
            this.valueGroup.Controls.Add(this.radError);
            this.valueGroup.Controls.Add(this.radOn);
            this.valueGroup.Controls.Add(this.radOff);
            this.valueGroup.Location = new System.Drawing.Point(19, 15);
            this.valueGroup.Name = "valueGroup";
            this.valueGroup.Size = new System.Drawing.Size(136, 61);
            this.valueGroup.TabIndex = 25;
            this.valueGroup.TabStop = false;
            this.valueGroup.Text = "开关量取值";
            // 
            // radUnavailable
            // 
            this.radUnavailable.AutoSize = true;
            this.radUnavailable.Location = new System.Drawing.Point(72, 38);
            this.radUnavailable.Name = "radUnavailable";
            this.radUnavailable.Size = new System.Drawing.Size(47, 16);
            this.radUnavailable.TabIndex = 44;
            this.radUnavailable.Text = "无效";
            this.radUnavailable.UseVisualStyleBackColor = true;
            // 
            // radError
            // 
            this.radError.AutoSize = true;
            this.radError.Location = new System.Drawing.Point(72, 16);
            this.radError.Name = "radError";
            this.radError.Size = new System.Drawing.Size(47, 16);
            this.radError.TabIndex = 43;
            this.radError.Text = "错误";
            this.radError.UseVisualStyleBackColor = true;
            // 
            // radOn
            // 
            this.radOn.AutoSize = true;
            this.radOn.Checked = true;
            this.radOn.Location = new System.Drawing.Point(16, 16);
            this.radOn.Name = "radOn";
            this.radOn.Size = new System.Drawing.Size(35, 16);
            this.radOn.TabIndex = 42;
            this.radOn.TabStop = true;
            this.radOn.Text = "开";
            this.radOn.UseVisualStyleBackColor = true;
            // 
            // radOff
            // 
            this.radOff.AutoSize = true;
            this.radOff.Location = new System.Drawing.Point(16, 38);
            this.radOff.Name = "radOff";
            this.radOff.Size = new System.Drawing.Size(35, 16);
            this.radOff.TabIndex = 41;
            this.radOff.Text = "关";
            this.radOff.UseVisualStyleBackColor = true;
            // 
            // Switch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.valueGroup);
            this.Name = "Switch";
            this.Size = new System.Drawing.Size(457, 206);
            this.Load += new System.EventHandler(this.Switch_Load);
            this.valueGroup.ResumeLayout(false);
            this.valueGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox valueGroup;
        private System.Windows.Forms.RadioButton radUnavailable;
        private System.Windows.Forms.RadioButton radError;
        private System.Windows.Forms.RadioButton radOn;
        private System.Windows.Forms.RadioButton radOff;
    }
}
