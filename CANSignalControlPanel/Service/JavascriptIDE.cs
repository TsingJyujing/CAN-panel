using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CANSignalControlPanel.Forms;
using System.Threading;

namespace CANSignalControlPanel.Service {
    public class JavascriptIDE {
        static FrmJSIDE jsIDEFrm;
        public static FrmJSIDE IDEForm {
            get {
                return jsIDEFrm;
            }
        }
        static JavascriptIDE(){
            jsIDEFrm = new FrmJSIDE();
            jsIDEFrm.Show();
            jsIDEFrm.Hide();
        }
        public static void show() {
            jsIDEFrm.BeginInvoke(new Action(() => {
                jsIDEFrm.Show();
            }));
        }
        public static void hide() {
            jsIDEFrm.BeginInvoke(new Action(() => {
                jsIDEFrm.Hide();
            }));
        }
        public static void add(object obj) {
            jsIDEFrm.addDebugInfo(obj);
        }
        public static void clear() {
            jsIDEFrm.clearInfo();
        }
        public static void close() {
            jsIDEFrm.avoidClose = false;
            jsIDEFrm.Close();
        }
    }
}
