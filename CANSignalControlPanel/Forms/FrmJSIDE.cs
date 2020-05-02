using CANSignalControlPanel.Data;
using CANSignalControlPanel.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using CANSignalControlPanel.UserWidget;
using CANSignalControlPanel.Service;
using LogService;
using System.IO;
using System.Text.RegularExpressions;
using Furty.Windows.Forms;

namespace CANSignalControlPanel.Forms {
    public partial class FrmJSIDE : Form {
        JavascriptEditor jsEditor;
        MultiLineList lstDebugInfo;
        bool saved = true;
        
        public FrmJSIDE() {
            Hide();
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            jsEditor = new JavascriptEditor();
            jsEditor.textEditor.TextChanged += codeText_Changed;
            jseHost.Child = jsEditor;
            lstDebugInfo = new MultiLineList();
            lstHost.Child = lstDebugInfo;
            setCurrentPath("");
            folderViewer.InitFolderTreeView();
            lstDebugInfo.KeyUp += wpfControlsPressed;
            jsEditor.KeyUp += wpfControlsPressed;
            folderViewer.DrillToFolder(Application.StartupPath);
            Show();
        }
        private void codeText_Changed(object sender, EventArgs e) {
            setSaved(false);
        }
        private void FrmDebug_Load(object sender, EventArgs e) {
            //pass
        }

        private void wpfControlsPressed(object sender, System.Windows.Input.KeyEventArgs e) {
            if (e.Key == System.Windows.Input.Key.F5) {
                btnRun_Click(sender, null);//Run
                return;
            }
            char pressedChar = e.Key.ToString().ToCharArray(0,1)[0];
            pressedChar -= 'A';
            pressedChar += (char)1;
            bool isCtrl = (System.Windows.Input.Keyboard.Modifiers & System.Windows.Input.ModifierKeys.Control) == System.Windows.Input.ModifierKeys.Control;
            if (isCtrl) {
                KeyPressEventArgs eKey = new KeyPressEventArgs(pressedChar);
                FrmDebug_KeyPress(sender, eKey);
            }
        }
        public void addDebugInfo(object info) {
            lstDebugInfo.addItem(info);
        }
        public void clearInfo() {
            lstDebugInfo.clear();
        }
        public bool avoidClose = true;
        private void FrmDebug_FormClosing(object sender, FormClosingEventArgs e) {
            Hide();
            e.Cancel = avoidClose;
        }
        private void FrmDebug_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 19) {//^S
                btnSave_Click(sender, e);
            } else if (e.KeyChar == 15) {//^O
                btnOpen_Click(sender, e);
            }
        }

        object jsReturn;
        string jsCode;
        Thread threadJS;
        void runJs() {
            try {
                jsReturn = JavaScriptEngine.runCmd(jsCode);
                if (jsReturn != null) {
                    string printInfo = "JSResult>\n" + jsReturn.ToString();
                    BeginInvoke(
                        new Action(
                            () => {addDebugInfo(printInfo);}
                        )
                    );
                }
            }catch(Exception e){
                Logger.logError(e);
                lstDebugInfo.addItem(
                    "Error while executing JS code:"
                    + "\n  Error Message:\n" + e.Message
                    + "\n   Error Source:\n" + e.Source
                    + "\n    Stack Trace:\n" + e.StackTrace);
            }
        }
        
        private void btnRun_Click(object sender, EventArgs e) {
            try {
                jsReturn = null;
                jsCode = jsEditor.code;
                //addDebugInfo(">>> " + jsCode);
                threadJS = new Thread(runJs);
                threadJS.IsBackground = true;
                threadJS.Start();
            } catch (Exception ex) {
                addDebugInfo("Javascript Engine error:" + ex.Message);
            }
        }
        public void btnClear_Click(object sender, EventArgs e) {
            lstDebugInfo.clear();
        }
        string currentPath = "";
        void setCurrentPath(string path) {
            currentPath = path;
            updateTitle();
        }
        void setSaved(bool savedIn) {
            bool isUpdateTitle = saved != savedIn;
            saved = savedIn;
            if (isUpdateTitle) {
                updateTitle();
            }
        }
        void updateTitle() {
            string disp = "";
            if (currentPath != "") {
                disp = currentPath;
            } else {
                disp = "New File";
            }
            if (!saved) {
                disp = "*" + disp;
            }
            Text = "Javascript CAN IDE - " + disp;
        }

        private void btnOpen_Click(object sender, EventArgs e) {
            OpenFileDialog fDlg = new OpenFileDialog();
            fDlg.Filter = "CAN控制脚本(*.js)|*.js";
            fDlg.Title = "打开脚本文件";
            fDlg.ShowDialog();
            if (fDlg.FileName != "") {
                setCurrentPath(fDlg.FileName);
                jsEditor.code = FileUtility.ReadFileUTF8(fDlg.FileName);
                setSaved(true);
            }
        }

        private void btnSave_Click(object sender, EventArgs e) {
            if (currentPath != "") {
                FileUtility.WriteFileUTF8(currentPath, jsEditor.code);
                setSaved(true);
            } else {
                btnSaveAs_Click(sender, e);
            }
        }

        private void btnStop_Click(object sender, EventArgs e) {
            try {
                JavaScriptEngine.getContext().TerminateExecution();
                threadJS.Abort();
                btnRun.Visible = true;
                btnStop.Visible = false;
                addDebugInfo("Javascript program terminated.");
            } catch (Exception ex) {
                addDebugInfo("Javascript Engine error:" + ex.Message);
            }
        }

        private void btnSaveAs_Click(object sender, EventArgs e) {
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.Filter = "CAN控制脚本(*.js)|*.js";
            saveDlg.Title = "保存脚本文件";
            saveDlg.FileName = folderViewer.GetSelectedNodePath();
            saveDlg.ShowDialog();
            if (saveDlg.FileName != "") {
                setCurrentPath(saveDlg.FileName);
                FileUtility.WriteFileUTF8(saveDlg.FileName, jsEditor.code);
                setSaved(true);
            }
        }

        private void FrmDebug_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e) {
            //Logger.logInfo("Pressed:" + e.KeyCode.ToString());
        }

        private void btnNewScript_Click(object sender, EventArgs e) {
            if (!saved) {
                DialogResult querySave;
                querySave = MessageBox.Show(
                    "文件尚未保存，是否保存文件？", "保存",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (querySave == DialogResult.Cancel) {
                    return;
                } else if (querySave == DialogResult.Yes) {
                    btnSave_Click(sender, e);
                }
            }
            jsEditor.code = "";
            setSaved(true);
            setCurrentPath("");
        }
        private void folderViewer_AfterSelect(object sender, TreeViewEventArgs e) {
            try {
                string folderPath = folderViewer.GetSelectedNodePath();
                //列出所有的Javascript脚本
                string[] files = Directory.GetFiles(folderPath, "*.js");
                lstFiles.Items.Clear();
                foreach (string file in files) {
                    lstFiles.Items.Add(System.IO.Path.GetFileName(file));
                }
            } catch {
                lstFiles.Items.Clear();
                Logger.logWarn("所选路径不合法");
            }
        }

        private void lstFiles_DoubleClick(object sender, EventArgs e) {
            int selectIndex = lstFiles.SelectedIndex;
            if (selectIndex>=0 && selectIndex<lstFiles.Items.Count){
                string filename = folderViewer.GetSelectedNodePath() 
                    + "\\" + lstFiles.Items[selectIndex];
                if (saved) {
                    jsEditor.code = FileUtility.ReadFileUTF8(filename);
                    setSaved(true);
                    setCurrentPath(filename);
                } else {
                    //问一下是不是保存？
                    DialogResult querySave;
                    querySave = MessageBox.Show(
                        "文件尚未保存，是否保存文件？", "保存",
                        MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (querySave == DialogResult.Cancel) {
                        return;
                    } else if (querySave == DialogResult.Yes) {
                        btnSave_Click(sender, e);
                    } else {
                        jsEditor.code = FileUtility.ReadFileUTF8(filename);
                        setSaved(true);
                        setCurrentPath(filename);
                    }
                }
            }
        }
        private void txtImdyt_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 13) {
                try {
                    string code = txtImdyt.Text;
                    addDebugInfo(">>> " + code);
                    jsReturn = JavaScriptEngine.runCmd(code);
                    if (jsReturn != null) {
                        addDebugInfo("JSResult>\n" + jsReturn.ToString());
                    }
                } catch (Exception ex) {
                    addDebugInfo("Javascript Engine error:" + ex.Message);
                }
            }
        }
    }
}
