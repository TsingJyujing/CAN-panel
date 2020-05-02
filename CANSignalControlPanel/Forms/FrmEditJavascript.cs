using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CANSignalControlPanel.UserWidget;
namespace CANSignalControlPanel.Forms {
    public partial class FrmEditJavascript : Form {
        public string code;
        JavascriptEditor jse;
        public FrmEditJavascript(string initCode) {
            InitializeComponent();
            code = initCode;
            jse = new JavascriptEditor();
            codeHost.Child = jse;
            jse.code = initCode;
        }

        private void btnModify_Click(object sender, EventArgs e) {
            code = jse.code;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            Close();
        }
    }
}
