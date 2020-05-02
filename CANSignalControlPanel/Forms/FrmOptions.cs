using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CANSignalControlPanel.Utilities;
using CANSignalControlPanel.Data;

namespace CANSignalControlPanel.Forms {
    public partial class FrmOptions : Form {

        private static string FilePath 
            = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase 
            + "settings.ini";
        private static string Section = "settings.ini";
        private HashSet<string> terminal_id_list = new HashSet<string>();
        private void writeINI(string key, string value){
            FileUtility.WritePrivateProfileString(Section, key, value, FilePath);
        }

        public static string readINI(string key, string default_value) {
            return FileUtility.GetPrivateProfileString(Section, key, default_value, FilePath);
        }
        public static MaskType getPaddingType() {
            if(int.Parse(readINI("padding_mode", "1")) == 1){
                return MaskType.Mask1;
            }else{
                return MaskType.Mask0;
            }
        }
        public FrmOptions() {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e) {
            writeINI("sleep_time", numSleepTime.Value.ToString());
            writeINI("padding_mode", radPad0.Checked ? "0" : "1");
            Close();
        }

        public void loadFile() {
            string padding_mode = readINI("padding_mode", "1");
            if (padding_mode == "0") {
                radPad1.Checked = false;
                radPad0.Checked = true;
            } else {
                radPad0.Checked = false;
                radPad1.Checked = true;
            }
            numSleepTime.Value = decimal.Parse(readINI("sleep_time", "10"));
        }

        private void FrmOptions_Load(object sender, EventArgs e) {
            loadFile();
        }
    }
}
