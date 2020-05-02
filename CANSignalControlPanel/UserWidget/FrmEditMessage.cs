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
    public partial class FrmEditMessage : Form {
        public bool modified = false;
        CANMessage currentMessage;
        public FrmEditMessage(CANMessage msg) {
            InitializeComponent();
            currentMessage = msg;
            txtMessageID.Text = string.Format("{0:X}", currentMessage.ID);
            txtMessageName.Text = currentMessage.Name;
            txtMessageTxPeriod.Text = currentMessage.TxPeriod.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            Close();
        }

        private void btnModify_Click(object sender, EventArgs e) {
            currentMessage.Name = txtMessageName.Text;
            currentMessage.TxPeriod = int.Parse(txtMessageTxPeriod.Text);
            currentMessage.ID = (int)System.Convert.ToInt32(txtMessageID.Text, 16);
            modified = true;
            Close();
        }
    }
}
