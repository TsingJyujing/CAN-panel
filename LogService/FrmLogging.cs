using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LogService {
    public partial class FrmLogging : Form {
        MultiLineLogList lstLogging;
        public FrmLogging() {
            InitializeComponent();
            lstLogging = new MultiLineLogList();
            lstHost.Child = lstLogging;
        }
        public void listClear() {
            lstLogging.clear();
        }
        public void listAddItem(object listItem) {
            lstLogging.addAndMoveLast(listItem);
        }
        public void setTitle(string titleText) {
            Text = titleText;
        }
        public bool avoidClose = true;
        private void FrmLogging_FormClosing(object sender, FormClosingEventArgs e) {
            if (avoidClose) {
                e.Cancel = true;
                Hide();
            }
        }
    }
}
