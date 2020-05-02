using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CANSignalControlPanel.Data;

namespace CANSignalControlPanel.UserWidget {
    public partial class FrmModifySignal : Form, Ensureable {
        CANSignal csObject;
        UserControl ucEdit;
        bool isModify = false;
        public FrmModifySignal(CANSignal csObjectInit) {
            InitializeComponent();
            csObject = csObjectInit;
            //加载基础信息
            txtSignalName.Text = csObject.Name;
            txtBitLen.Text = csObject.BitSize.ToString();
            Tuple<int, int> offsetInfo = CANSignal.GetBitConfigure(csObject.BitOffset);
            txtStartByte.Text = offsetInfo.Item1.ToString();
            txtStartBit.Text = offsetInfo.Item2.ToString();
            //加载分类控件
            switch(csObject.sType){
            case SignalType.Continuous:
                ucEdit = new SignalEditor.Continuous(csObjectInit);
                break;
            case SignalType.Discrete:
                
                ucEdit = new SignalEditor.Discrete(csObjectInit);
                break;
            case SignalType.DM1FaultCode:
                txtBitLen.Text = "24";
                csObject.BitSize = 24;
                txtBitLen.Enabled = false;
                ucEdit = new SignalEditor.DM1FaultCode(csObjectInit);
                break;
            case SignalType.Switch:
                txtBitLen.Text = "2";
                csObject.BitSize = 2;
                txtBitLen.Enabled = false;
                ucEdit = new SignalEditor.Switch(csObjectInit);
                break;
            case SignalType.UserDefined:
                ucEdit = new SignalEditor.Userdefined(csObjectInit);
                break;
            default:
                Close();
                return;
            }
            panelModifyType.Controls.Add(ucEdit);
            ucEdit.Dock = DockStyle.Fill;
        }

        private void FrmModifySignal_Load(object sender, EventArgs e) {

        }

        bool Ensureable.isModified() {
            return isModify;
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            Close();
        }

        private void btnModify_Click(object sender, EventArgs e) {
            isModify = true;
            (ucEdit as Modifiable).ModifyObject();
            //修改信号基础信息
            csObject.Name = txtSignalName.Text;
            csObject.BitSize = int.Parse(txtBitLen.Text);
            csObject.BitOffset = CANSignal.GetBitOffset(
                int.Parse(txtStartByte.Text), 
                int.Parse(txtStartBit.Text));
            Close();
        }
    }
}
