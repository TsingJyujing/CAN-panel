using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CANSignalControlPanel.Driver {
    public partial class FrmDeviceSelect : Form {
        List<string> devices;
        public int selectedIndex = -1;
        public string selectedText = "";
        public FrmDeviceSelect() {
            InitializeComponent();
        }
        
        private void lstDevice_DoubleClick(object sender, EventArgs e) {
            int si = lstDevice.SelectedIndex;
            if (si >= 0 && si < devices.Count) {
                selectedIndex = si;
                selectedText = devices[si];
                Close();
            }
        }
        public void SetTitle(string titleText) {
            Text = titleText;
        }

        public void LoadDeviceList(List<string> ListIn) {
            devices = ListIn;
            lstDevice.Items.Clear();
            foreach (string device in ListIn) {
                lstDevice.Items.Add(device);
            }
        }
    }
}
