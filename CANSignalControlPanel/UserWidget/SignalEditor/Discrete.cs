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
    
    public partial class Discrete : UserControl, Modifiable {
        Dictionary<ulong, string> mappingDict;
        Dictionary<ulong, string> sourceDict;
        CANSignal csObject;
        public Discrete(CANSignal csInput) {
            InitializeComponent();
            csObject = csInput;
            mappingDict = new Dictionary<ulong, string>();
            sourceDict = csObject.GetDecodeTable();
            foreach (ulong key in sourceDict.Keys) {
                mappingDict.Add(key, sourceDict[key]);
            }
            txtDefaultValue.Text = csObject.DefaultValue.ToString();
            refreshList();
        }
        void refreshList() {
            lstDecoder.Items.Clear();
            foreach (ulong key in mappingDict.Keys) {
                lstDecoder.Items.Add(
                    new ListItem() {
                        Text = string.Format("{0}-->{1}", key, mappingDict[key]),
                        Tag = key,
                    }
                );
            }
        }
        void Modifiable.ModifyObject() {
            sourceDict.Clear();
            foreach (ulong key in mappingDict.Keys) {
                sourceDict.Add(key, mappingDict[key]);
            }
            csObject.DefaultValue = ulong.Parse(txtDefaultValue.Text);
        }

        private void btnRemove_Click(object sender, EventArgs e) {
            try {
                ulong key = (ulong)((lstDecoder.SelectedItem as ListViewItem).Tag);
                mappingDict.Remove(key);
                refreshList();
            } catch { }
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            mappingDict[ulong.Parse(txtKey.Text)] = txtValue.Text;
            txtKey.Text = "";
            txtValue.Text = "";
            refreshList();
        }

        private void lstDecoder_MouseDoubleClick(object sender, MouseEventArgs e) {
            int si = lstDecoder.SelectedIndex;
            if (si >= 0) {
                ulong key = (ulong)((lstDecoder.SelectedItem as ListItem).Tag);
                txtKey.Text = key.ToString();
                txtValue.Text = mappingDict[key];
            }
        }
    }

    class ListItem {
        public string Text;
        public object Tag;
        public override string ToString() {
            return Text;
        }
    }
}
