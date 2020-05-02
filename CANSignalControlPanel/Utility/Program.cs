using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CANSignalControlPanel.Forms;
using LogService;
using System.Threading;
using CANSignalControlPanel.Service;

namespace CANSignalControlPanel {
    static class Program {
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            bool init = DriverManager.IsInitialized;
            Application.Run(new FrmMain());
        }
    }
}
