using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CANSignalControlPanel.Data;

namespace CANSignalControlPanel.UserWidget.SignalEditor {
    public partial class Switch : UserControl, Modifiable {
        CANSignal csObject;
        public Switch(CANSignal csObjectInput) {
            InitializeComponent();
            csObject = csObjectInput;
            switch (csObject.DefaultValue) {
            case 0:
                radOff.Select();
                break;
            case 1:
                radOn.Select();
                break;
            case 2:
                radError.Select();
                break;
            case 3:
                radUnavailable.Select();
                break;
            default:
                throw new Exception("Error while decoding CANSignal:" + csObject.Name + " as a switch.");
            }
            Tuple<int,int> BitConfig = CANSignal.GetBitConfigure(csObject.BitOffset);
        }


        void Modifiable.ModifyObject() {
            ulong value = 0;
            if (radOff.Checked) {
                value = 0;
            } else if (radOn.Checked) {
                value = 1;
            } else if (radError.Checked) {
                value = 2;
            } else {
                value = 3;
            }
            csObject.DefaultValue = value;
        }

        private void Switch_Load(object sender, EventArgs e) {

        }
    }
}
