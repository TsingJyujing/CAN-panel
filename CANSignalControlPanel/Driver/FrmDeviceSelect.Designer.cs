namespace CANSignalControlPanel.Driver {
    partial class FrmDeviceSelect {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDeviceSelect));
            this.lstDevice = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstDevice
            // 
            this.lstDevice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstDevice.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lstDevice.FormattingEnabled = true;
            this.lstDevice.ItemHeight = 21;
            this.lstDevice.Location = new System.Drawing.Point(0, 0);
            this.lstDevice.Name = "lstDevice";
            this.lstDevice.Size = new System.Drawing.Size(432, 147);
            this.lstDevice.TabIndex = 0;
            this.lstDevice.DoubleClick += new System.EventHandler(this.lstDevice_DoubleClick);
            // 
            // FrmDeviceSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 147);
            this.Controls.Add(this.lstDevice);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDeviceSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设备选择";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstDevice;
    }
}