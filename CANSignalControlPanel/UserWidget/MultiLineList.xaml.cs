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

namespace CANSignalControlPanel.UserWidget {
    /// <summary>
    /// MultiLineList.xaml 的交互逻辑
    /// </summary>
    public partial class MultiLineList : UserControl {
        public MultiLineList() {
            InitializeComponent();
            lstMain.MouseDoubleClick += lstDoubleClick;
        }
        private void lstDoubleClick(object sender, MouseButtonEventArgs e) {
            if (lstMain.SelectedIndex >= 0) {
                Clipboard.SetDataObject(lstMain.SelectedItem);
            }
        }
        public void clear() {
            lstMain.Dispatcher.BeginInvoke(new Action(() => {
                lstMain.Items.Clear();
            }));
        }
        public int SelectedIndex {
            get {
                return lstMain.SelectedIndex;
            }
            set {
                lstMain.SelectedIndex = value;
            }
        }
        public void BeginInvoke(Action callbackFun) {
            lstMain.Dispatcher.BeginInvoke(callbackFun);
        }
        public void gotoLast() {
            lstMain.ScrollIntoView(lstMain.Items[lstMain.Items.Count - 1]);
        }
        public void addItem(object item) {
            lstMain.Dispatcher.BeginInvoke(new Action(() => {
                lstMain.Items.Add(item);
                lstMain.ScrollIntoView(lstMain.Items[lstMain.Items.Count - 1]);
            }));
        }
    }
}
