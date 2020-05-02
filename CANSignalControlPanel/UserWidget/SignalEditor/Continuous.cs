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
    public partial class Continuous : UserControl, Modifiable {
        CANSignal csObject;
        public Continuous(CANSignal csObjectInput) {
            InitializeComponent();
            csObject = csObjectInput;
            txtScale.Text = csObject.cRatio.ToString();
            txtOffset.Text = csObject.cOffset.ToString();
            double value = (csObject.DefaultValue - csObject.cOffset) * csObject.cRatio;
            txtValue.Text = value.ToString();
        }
        //按照用户输入修改数据
        void Modifiable.ModifyObject() {
            csObject.cOffset = double.Parse(txtOffset.Text);
            csObject.cRatio = double.Parse(txtScale.Text);
            double value = double.Parse(txtValue.Text);
            csObject.DefaultValue = (ulong)((value + csObject.cOffset) / csObject.cRatio);
        }
        
    }
}
