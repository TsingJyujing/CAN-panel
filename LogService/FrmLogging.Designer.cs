namespace LogService {
    partial class FrmLogging {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogging));
            this.lstHost = new System.Windows.Forms.Integration.ElementHost();
            this.SuspendLayout();
            // 
            // lstHost
            // 
            this.lstHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstHost.Location = new System.Drawing.Point(0, 0);
            this.lstHost.Name = "lstHost";
            this.lstHost.Size = new System.Drawing.Size(704, 232);
            this.lstHost.TabIndex = 0;
            this.lstHost.Child = null;
            // 
            // FrmLogging
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 232);
            this.Controls.Add(this.lstHost);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmLogging";
            this.Text = "日誌";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmLogging_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Integration.ElementHost lstHost;

    }
}