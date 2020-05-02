using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CANSignalControlPanel.Forms {
    public partial class FrmWaiting : Form {
        public FrmWaiting() {
            InitializeComponent();
            lbVersion.Text = "Shinonome Version " + Application.ProductVersion;
        }
        private void FrmWaiting_Load(object sender, EventArgs e) {
            pgbarRun.Style = ProgressBarStyle.Marquee;
            pgbarRun.MarqueeAnimationSpeed = 100;
        }
        public void setTitle(string title){
            lbTitle.Text = title;
            Text = title;
        }
        public bool avoidClose = true;
        private void FrmWaiting_FormClosing(object sender, FormClosingEventArgs e) {
            if (avoidClose) {
                e.Cancel = true;
                Hide();
            }
        }
    }
}
