using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CANSignalControlPanel.Data;

namespace CANSignalControlPanel.UserWidget {
    /// <summary>
    /// CANTreeViewer.xaml 的交互逻辑
    /// </summary>
    public partial class CANTreeViewer : UserControl {
        public CANTreeViewer() {
            InitializeComponent();
        }
        static string NOT_ADDED = "NOT ADDED";
        Dictionary<int, Dictionary<CANSignal, TreeViewItem>> CANDecoder
            = new Dictionary<int, Dictionary<CANSignal, TreeViewItem>>();
        Dictionary<int,TreeViewItem> treeData = new Dictionary<int,TreeViewItem>();
        Dictionary<int, long> lastTick = new Dictionary<int,long>();
        Queue<CANData> dataQueue = new Queue<CANData>();
        public Queue<CANData> Data {
            get {
                return dataQueue;
            }
        }
        public void loadConfigure (ConfigureFile cfIn){
            canView.Dispatcher.BeginInvoke(new Action(() => {
                foreach (TreeViewItem tvi in canView.Items) {
                    tvi.Items.Clear();
                }
                CANDecoder = new Dictionary<int, Dictionary<CANSignal, TreeViewItem>>();
                foreach (CANMessage cMsg in cfIn.GetMessage()) {
                    CANDecoder.Add(cMsg.ID, new Dictionary<CANSignal, TreeViewItem>());
                    foreach (CANSignal cs in cMsg.GetSignalList()) {
                        CANDecoder[cMsg.ID].Add(cs, new TreeViewItem() { Header = NOT_ADDED });
                    }
                }
            }));
        }
        public void clearData() {
            try {
                canView.Items.Clear();
                treeData.Clear();
                dataQueue.Clear();
                lastTick.Clear();
                Dictionary<int, Dictionary<CANSignal, TreeViewItem>> CANDecoderNewObject
            = new Dictionary<int, Dictionary<CANSignal, TreeViewItem>>();
                foreach (int ID in CANDecoder.Keys) {
                    CANDecoderNewObject.Add(ID,new Dictionary<CANSignal,TreeViewItem>());
                    foreach (CANSignal cs in CANDecoder[ID].Keys) {
                        CANDecoderNewObject[ID].Add(cs, new TreeViewItem() { Header = NOT_ADDED });
                    }
                }
                CANDecoder = CANDecoderNewObject;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        public void appendData(CANData cd) {
            dataQueue.Enqueue(cd);
            if (treeData.ContainsKey(cd.ID)) {
                //刷新内容
                treeData[cd.ID].Header = cd.ToString();
            } else {
                //新增节点
                treeData.Add(cd.ID, new TreeViewItem() {
                    Foreground = canView.Foreground
                });
                treeData[cd.ID].Header = cd.ToString();
                canView.Items.Add(treeData[cd.ID]);
            }
            string appendText;
            if (lastTick.ContainsKey(cd.ID)) {
                appendText = string.Format("  Dt:{0}ms", (cd.ActionTime.Ticks - lastTick[cd.ID]) / 10000.0);
                lastTick[cd.ID] = cd.ActionTime.Ticks;
            } else {
                appendText = "  Dt:--ms";
                lastTick.Add(cd.ID, cd.ActionTime.Ticks);
            }
            treeData[cd.ID].Header += appendText;
            treeData[cd.ID].Tag = cd;

            if (CANDecoder.ContainsKey(cd.ID)) {//可以解析
                bool isExpand = false;
                foreach (CANSignal cSignal in CANDecoder[cd.ID].Keys) {
                    TreeViewItem tn = CANDecoder[cd.ID][cSignal];
                    if (NOT_ADDED.Equals(tn.Header.ToString())) {
                        treeData[cd.ID].Items.Add(tn);
                        isExpand = true;
                    }
                    tn.Header = string.Format("{0}:{1}-->{2}",
                        cSignal.Name, cSignal.BytesToInt(cd.GetData()), cSignal.DecodeCANMessage(cd.GetData()).ToString());
                    tn.Foreground = canView.Foreground;
                }
                if (isExpand) {
                    treeData[cd.ID].ExpandSubtree();
                }
            }
        }
    }
}
