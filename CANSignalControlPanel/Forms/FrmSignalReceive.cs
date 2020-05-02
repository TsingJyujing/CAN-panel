using CANSignalControlPanel.Data;
using CANSignalControlPanel.Service;
using CANSignalControlPanel.UserWidget;
using CANSignalControlPanel.Utilities;
using LogService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CANSignalControlPanel.Forms {
    public partial class FrmSignalReceive : Form {
        public FrmSignalReceive() {
            InitializeComponent();
        }

        private void btnImportConfigure_Click(object sender, EventArgs e) {
            OpenFileDialog cdlgOpenJson = new OpenFileDialog();
            cdlgOpenJson.Filter = "JSON配置文件(*.json)|*.json";
            cdlgOpenJson.ShowDialog();
            if (cdlgOpenJson.FileName != "") {
                try {
                    ConfigureFile cfgs = new JSONConfigIO().ReadConfigure(cdlgOpenJson.FileName);
                    ctvr.loadConfigure(cfgs);
                    JavaScriptEngine.runCmd(cfgs.UserDefinedScript);
                } catch (Exception ex) {
                    Logger.logError(ex);
                }
            }
        }

        private void FrmSignalRX_FormClosing(object sender, FormClosingEventArgs e) {
            e.Cancel = true;
            Hide();
        }
        public void appendRX(CANData cd) {
            ctvr.appendData(cd);
        }
        CANTreeViewer ctvr;
        MultiLineList mlt;
        private void FrmSignalRX_Load(object sender, EventArgs e) {
            ctvr = new CANTreeViewer();
            mlt = new MultiLineList();
            signalHost.Child = ctvr;
            new Task(rxThread).Start();
        }

        Queue<DateTime> rxTime = new Queue<DateTime>();
        void rxThread() {
            while (true) {
                if (DriverManager.IsInitialized) {
                    int dataSize = DriverManager.Driver.GetQueue().Count;
                    if (dataSize > 0) {
                        try {
                            for (int i = 0; i < dataSize; i++) {
                                CANData cd = DriverManager.GetData();
                                ctvr.Dispatcher.Invoke(new Action(() => {
                                    ctvr.appendData(cd);
                                }));
                                mlt.Dispatcher.Invoke(new Action(() => {
                                    mlt.addItem(cd.ToString());
                                }));
                                rxTime.Enqueue(cd.ActionTime);
                            }
                        } catch {
                            return;
                        }
                    }
                }
                DateTime histLimit = DateTime.Now - new TimeSpan(0,0,3);
                while (rxTime.Count>0){
                    if(rxTime.Dequeue()>=histLimit){
                        break;
                    }
                }
                if (rxTime.Count > 0) {
                    long dt = rxTime.Last().Ticks - rxTime.First().Ticks;
                    double dtms = dt/10000.0/1000.0;
                    if (dt==0){
                        lbSpeed.Text = "传输速度：- fps";
                    }else{
                        lbSpeed.Text = string.Format("传输速度：{0} fps", (long)(rxTime.Count / dtms));
                    }
                } else {
                    lbSpeed.Text = "传输速度：0 fps";
                }
                lbAllCount.Text = string.Format("总数量：{0}条 ",ctvr.Data.Count);
                Thread.Sleep(50);//20Hz刷新率
            }
        }
        private void btnClear_Click(object sender, EventArgs e) {
            ctvr.clearData();
            mlt.clear();
        }

        private void btnExport_Click(object sender, EventArgs e) {
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.Filter = "CAN收信记录(*.csv)|*.csv";
            saveDlg.ShowDialog();
            if (saveDlg.FileName != "") {
                try {
                    List<CANData> dataList = ctvr.Data.ToList();
                    StringBuilder sb = new StringBuilder();
                    foreach (CANData data in dataList) {
                        sb.Append(data.ToCSV() + "\n");
                    }
                    FileUtility.WriteFileUTF8(saveDlg.FileName, sb.ToString());
                } catch (Exception ex) {
                    Logger.logError(ex);
                }
            }
        }

        static Random rnd = new Random();
        private void btnAddCANData_Click(object sender, EventArgs e) {
            for (int i = 0; i < 100; i++) {
                int CANIDTest = (int)(rnd.NextDouble() * 15 + 0x10);
                byte[] data = new byte[8];
                rnd.NextBytes(data);
                ctvr.appendData(new CANData(CANIDTest, data));
                Thread.Sleep((int)(rnd.NextDouble() * 10));
            }
        }

        private void btnFlowMode_Click(object sender, EventArgs e) {
            signalHost.Child = mlt;
            btnFlowMode.Visible = false;
            btnAnalysisMode.Visible = true;
        }

        private void btnAnalysisMode_Click(object sender, EventArgs e) {
            signalHost.Child = ctvr;
            btnFlowMode.Visible = true;
            btnAnalysisMode.Visible = false;
        }

        private void btnExportVspy_Click(object sender, EventArgs e) {
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.Filter = "Vehicle Spy Logs(*.csv)|*.csv";
            saveDlg.ShowDialog();
            if (saveDlg.FileName != "") {
                try {
                    List<CANData> dataList = ctvr.Data.ToList();
                    StringBuilder sb = new StringBuilder();
                    DateTime saveTick = DateTime.Now;
                    DateTime startTick = dataList[0].ActionTime;
                    sb.Append("Vehicle Spy 3 Bus Traffic File\r\n");
                    sb.Append(string.Format("Save Date,{0}\r\n", saveTick.ToString("M/d/yyyy")));
                    sb.Append(string.Format("Save Time,{0}\r\n", saveTick.ToString("h:mm:ss tt")));
                    sb.Append(string.Format("Start Date,{0}\r\n", startTick.ToString("M/d/yyyy")));
                    sb.Append(string.Format("Start Time,{0}\r\n", startTick.ToString("h:mm:ss tt")));
                    sb.Append("System Time,160000000\r\nNotes,\r\n\r\n");
                    sb.Append("Network Description,Hardware,Network,Protocol,Baud Rate\r\nHS CAN,Default,HS CAN,CAN,250000,");
                    sb.Append("\r\n\r\n\r\n\r\n");
                    sb.Append("Line,Abs Time(Sec),Rel Time (Sec),Status,Er,Tx,Description,Network,Node,ID,Cycle,Ch,B1-256,Dyn,Symbol Type,Strt-PPI-NULL-Sync-Res,H-CRC,CRC,Tframe,Tss Length,Value,Trigger,Signals\r\n");
                    sb.Append("Line,Abs Time(Sec),Rel Time (Sec),Status,Er,Tx,Description,Network,Node,Arb ID,Remote/EDL-BRS-ESI,Xtd,B1,B2,B3,B4,B5,B6,B7,B8,Value,Trigger,Signals\r\n");
                    sb.Append("Line,Abs Time(Sec),Rel Time (Sec),Status,Er,Tx,Description,Network,Node,PT,Trgt,Src,B1,B2,B3,B4,B5,B6,B7,B8,Value,Trigger,Signals\r\n");
                    uint index = 0;
                    double startSec = startTick.Ticks / 10000000.0;
                    foreach (CANData data in dataList) {
                        index++;
                        double currentSecond = data.ActionTime.Ticks / 10000000.0;
                        currentSecond -= startSec;
                        sb.Append(string.Format(
                            "{0},{1},{1},67371012,F,F,HS CAN ${2:X},HS CAN,,{2:X},F,T,",
                            index, currentSecond,data.ID));
                        byte[] b = data.GetData();
                        for (int i = 0; i < 10; i++) {
                            if (i < b.Length) {
                                sb.Append(string.Format("{0:X},", b[i]));
                            } else {
                                sb.Append(",");
                            }
                        }
                        sb.Append("\r\n");
                    }
                    FileUtility.WriteFileUTF8(saveDlg.FileName, sb.ToString());
                } catch (Exception ex) {
                    Logger.logError(ex);
                    Logger.logError(ex.StackTrace);
                }
            }
        }
    }
}
