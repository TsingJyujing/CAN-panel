namespace CANSignalControlPanel.UserWidget.SignalEditor {
    partial class Userdefined {
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
            this.txtUserDefinedFunctionName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtUserDefinedFunctionName
            // 
            this.txtUserDefinedFunctionName.Location = new System.Drawing.Point(118, 12);
            this.txtUserDefinedFunctionName.Name = "txtUserDefinedFunctionName";
            this.txtUserDefinedFunctionName.Size = new System.Drawing.Size(108, 21);
            this.txtUserDefinedFunctionName.TabIndex = 43;
            this.txtUserDefinedFunctionName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 42;
            this.label1.Text = "自定义函数名称";
            // 
            // Userdefined
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtUserDefinedFunctionName);
            this.Controls.Add(this.label1);
            this.Name = "Userdefined";
            this.Size = new System.Drawing.Size(457, 206);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUserDefinedFunctionName;
        private System.Windows.Forms.Label label1;
    }
}
