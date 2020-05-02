using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CANSignalControlPanel.Forms {
    public partial class FrmAbout : Form {
        public FrmAbout() {
            InitializeComponent();
        }

        private void openSHINONOME() {
            System.Diagnostics.Process.Start("http://www.shinonome-lab.com/");
        }

        private void btnVisitOfficialSite_Click(object sender, EventArgs e) {
            openSHINONOME();
        }
    }
}
