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
    public partial class Userdefined : UserControl, Modifiable {
        CANSignal csObject;
        public Userdefined(CANSignal CSIn) {
            InitializeComponent();
            csObject = CSIn;
            txtUserDefinedFunctionName.Text = csObject.UDFName;
        }
        void Modifiable.ModifyObject() {
            csObject.UDFName = txtUserDefinedFunctionName.Text;
        }
    }
}
