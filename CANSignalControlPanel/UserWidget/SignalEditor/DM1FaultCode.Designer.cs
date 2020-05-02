namespace CANSignalControlPanel.UserWidget.SignalEditor {
    partial class DM1FaultCode {
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
            this.txtFMI = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSPN = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtFMI
            // 
            this.txtFMI.Location = new System.Drawing.Point(185, 13);
            this.txtFMI.Name = "txtFMI";
            this.txtFMI.Size = new System.Drawing.Size(70, 21);
            this.txtFMI.TabIndex = 18;
            this.txtFMI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(150, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 12);
            this.label9.TabIndex = 17;
            this.label9.Text = "FMI";
            // 
            // txtSPN
            // 
            this.txtSPN.Location = new System.Drawing.Point(46, 13);
            this.txtSPN.Name = "txtSPN";
            this.txtSPN.Size = new System.Drawing.Size(70, 21);
            this.txtSPN.TabIndex = 16;
            this.txtSPN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "SPN";
            // 
            // DM1FaultCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtFMI);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtSPN);
            this.Controls.Add(this.label2);
            this.Name = "DM1FaultCode";
            this.Size = new System.Drawing.Size(457, 206);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFMI;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSPN;
        private System.Windows.Forms.Label label2;
    }
}
