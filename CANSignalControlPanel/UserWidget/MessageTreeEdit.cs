using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CANSignalControlPanel.Data;

namespace CANSignalControlPanel.UserWidget {
    public partial class MessageTreeEdit : UserControl{
        public void ExpandAll() {
            MessageTreeView.ExpandAll();
        }
        public void CollapseAll() {
            MessageTreeView.CollapseAll();
        }
        public bool modifyAlert = true;
        private static bool isModify(string text, bool modifyAlertInput) {
            if (modifyAlertInput) {
                return MessageBox.Show(text, "修改确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK;
            } else {
                return true;
            }
        }
        private bool isModify(string text) {
            return isModify(text, modifyAlert);
        }

        public void Clear() {
            configure = new ConfigureFile();
        }
        
        ConfigureFile config;
        public ConfigureFile configure {
            get {
                return config;
            }
            set{
                config = value;
                reloadDisplay();
            }
        }
        public MessageTreeEdit() {
            InitializeComponent();
            config = new ConfigureFile();
            //initConfigure();
            reloadDisplay();
            MessageTreeView.ContextMenuStrip = ctxmTreeView;
        }

        public void refreshDisplay() {
            foreach (TreeNode tnMessage in MessageTreeView.Nodes) {
                CANMessage msg = (CANMessage)tnMessage.Tag;
                tnMessage.Text = tnMessage.ToString();
                foreach (TreeNode tnSignal in tnMessage.Nodes) {
                    CANSignal signal = (CANSignal)tnSignal.Tag;
                    tnSignal.Text = signal.ToString();
                }
            }
        }

        public void reloadDisplay() {
            MessageTreeView.Nodes.Clear();
            List<CANMessage> msgList = config.GetMessage();
            foreach (CANMessage msg in msgList) {
                TreeNode tnMessage = new TreeNode() {
                    Text = msg.ToString(),
                    Tag = msg,
                    ContextMenuStrip = ctxmMessage,
                    ImageKey = "Message",
                    SelectedImageKey = "Message",
                };
                List<CANSignal> lstSignals = msg.GetSignalList();
                foreach (CANSignal signal in lstSignals) {
                    string imageKey;
                    switch (signal.sType) {
                    case SignalType.Continuous:
                        imageKey = "Signal";
                        break;
                    case SignalType.Discrete:
                        imageKey = "Discrete";
                        break;
                    case SignalType.DM1FaultCode:
                        imageKey = "DM1";
                        break;
                    case SignalType.Switch:
                        imageKey = "Switch";
                        break;
                    case SignalType.UserDefined:
                        imageKey = "UserDefined";
                        break;
                    default:
                        imageKey = "Signal";
                        break;
                    }
                    tnMessage.Nodes.Add(new TreeNode() {
                        Text = signal.ToString(),
                        Tag = signal,
                        ContextMenuStrip = ctxmSignal,
                        ImageKey = imageKey,
                        SelectedImageKey = imageKey
                    });

                }
                tnMessage.Expand();
                MessageTreeView.Nodes.Add(tnMessage);
            }
        }

        private void btnEditMessage_Click(object sender, EventArgs e) {
            try {
                TreeNode tnSelected = MessageTreeView.SelectedNode;
                if (typeof(CANMessage).Equals(tnSelected.Tag.GetType())) {
                    FrmEditMessage frme = new FrmEditMessage(
                        (CANMessage)tnSelected.Tag
                    );
                    frme.ShowDialog();
                    refreshDisplay();
                } else if (typeof(CANSignal).Equals(tnSelected.Tag.GetType())) {
                }
            } catch { }
        }

        private void btnDeleteMessage_Click(object sender, EventArgs e) {
            try {
                TreeNode tnSelected = MessageTreeView.SelectedNode;
                if (typeof(CANMessage).Equals(tnSelected.Tag.GetType())) {
                    if (isModify("是否删除报文？")) {
                        config.RemoveMessage((tnSelected.Tag as CANMessage).ID);
                        MessageTreeView.Nodes.Remove(tnSelected);
                    }
                }
            } catch { }
        }



        private void btnAddMessage_Click(object sender, EventArgs e) {
            try {
                CANMessage msgInsert = new CANMessage();
                FrmEditMessage frme = new FrmEditMessage(msgInsert);
                frme.ShowDialog();
                if (frme.modified) {
                    config.AppendMessage(msgInsert);
                    reloadDisplay();
                }
            }catch(Exception ex){
                MessageBox.Show("信号量增加出错：" + ex.Message, "错误提示",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearAll_Click(object sender, EventArgs e) {
            if (isModify("是否清空全部报文？")) {
                config.ClearAllMessage();
                reloadDisplay();
            }
        }

        private void btnDeleteSignal_Click(object sender, EventArgs e) {
            try {
                TreeNode tnSelected = MessageTreeView.SelectedNode;
                if (typeof(CANSignal).Equals(tnSelected.Tag.GetType())) {
                    TreeNode msgNode = tnSelected.Parent;
                    if (isModify("是否删除信号？")) {
                        int ID = (tnSelected.Parent.Tag as CANMessage).ID;
                        config.RemoveSignal(ID, (tnSelected.Tag as CANSignal));
                        msgNode.Nodes.Remove(tnSelected);
                    }
                }
            } catch { }
        }
        private void addSignal(SignalType st) {
            TreeNode tnSelected = MessageTreeView.SelectedNode;
            CANMessage cMsg;
            if (typeof(CANMessage).Equals(tnSelected.Tag.GetType())) {
                cMsg = tnSelected.Tag as CANMessage;
            } else if (typeof(CANSignal).Equals(tnSelected.Tag.GetType())) {
                cMsg = tnSelected.Parent.Tag as CANMessage;
            } else {
                throw new Exception("Invalid item.");
            }
            CANSignal newSignal = new CANSignal(st);
            FrmModifySignal fms = new FrmModifySignal(newSignal);
            fms.ShowDialog();
            if ((fms as Ensureable).isModified()) {
                cMsg.GetSignalList().Add(newSignal);
                reloadDisplay();
            }
        }
        private void btnAddSignalContinuous_Click(object sender, EventArgs e) {
            try {
                addSignal(SignalType.Continuous);
            } catch { }
        }

        private void btnEditSignal_Click(object sender, EventArgs e) {
            try {
                TreeNode tnSelected = MessageTreeView.SelectedNode;
                if (typeof(CANSignal).Equals(tnSelected.Tag.GetType())) {
                    FrmModifySignal fms = new FrmModifySignal(tnSelected.Tag as CANSignal);
                    fms.ShowDialog();
                }
            } catch { }
        }

        private void MessageTreeView_DoubleClick(object sender, EventArgs e) {
            btnEditSignal_Click(sender, e);
        }

        private void btnAddSignalDiscrete_Click(object sender, EventArgs e) {
            try {
                addSignal(SignalType.Discrete);
            } catch { }
        }

        private void btnAddSignalSwitch_Click(object sender, EventArgs e) {
            try {
                addSignal(SignalType.Switch);
            } catch { }
        }

        private void btnAddSignalDM1_Click(object sender, EventArgs e) {
            try {
                addSignal(SignalType.DM1FaultCode);
            } catch { }
        }

        private void btnAddSignalUserdefined_Click(object sender, EventArgs e) {
            try {
                addSignal(SignalType.UserDefined);
            } catch { }
        }

        public TransmitData getCurrentSelected(MaskType mt) {
            TransmitData sdRtn = new TransmitData();
            sdRtn.data = new CANData();
            TreeNode tnSelected = MessageTreeView.SelectedNode;
            CANMessage cMsg;
            if (typeof(CANMessage).Equals(tnSelected.Tag.GetType())) {
                cMsg = tnSelected.Tag as CANMessage;
                sdRtn.data.ID = cMsg.ID;
                sdRtn.data.SetData(cMsg.BuildMessage(mt));
                sdRtn.cycle = cMsg.TxPeriod;
            } else if (typeof(CANSignal).Equals(tnSelected.Tag.GetType())) {
                cMsg = tnSelected.Parent.Tag as CANMessage;
                CANSignal cSignal = tnSelected.Tag as CANSignal;
                sdRtn.data.ID = cMsg.ID;
                sdRtn.data.SetData(cSignal.encode(mt));
                sdRtn.cycle = cMsg.TxPeriod;
            } else {
                sdRtn = null;
            }
            return sdRtn;
        }
    }
}
