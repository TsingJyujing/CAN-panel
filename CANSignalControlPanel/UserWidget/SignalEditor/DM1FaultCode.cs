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
    public partial class DM1FaultCode : UserControl, Modifiable {
        public DM1FaultCode(CANSignal csIn) {
            InitializeComponent();
            csObject = csIn;
            DM1Value newdm = csObject.DecodeCANMessage() as DM1Value;
            txtSPN.Text = newdm.SPN.ToString();
            txtFMI.Text = newdm.FMI.ToString();
        }
        CANSignal csObject;
        void Modifiable.ModifyObject() {
            csObject.DefaultValue = CANSignal.EncodeDM1(new DM1Value() {
                SPN = uint.Parse(txtSPN.Text),
                FMI = uint.Parse(txtFMI.Text)
            });
        }
    }
}
