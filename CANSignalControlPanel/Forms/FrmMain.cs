using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using CANSignalControlPanel.Data;
using CANSignalControlPanel.Driver;
using CANSignalControlPanel.Service;
using CANSignalControlPanel.Utilities;
using CANSignalControlPanel.UserWidget;
using LogService;


namespace CANSignalControlPanel.Forms {
    public partial class FrmMain : Form {
        static string strStartSendAllMessage = "发送全部报文";
        static string strStopSendAllMessage = "停止发送";
        static string strStartCheckout = "测试全部信号";
        static string strStopCheckout = "停止测试";
        static string strStartSendOneSignal = "循环发送单个信号";
        static string strStopSendOneSignal = "停止发送";
        static string strNoSignalIsSending = "无信号发送";
        string currentPath = "";
        void setCurrentPath(string path) {
            currentPath = path;
            Text = System.IO.Path.GetFileName(path) + "-测试台架";
            if (path == "") {
                Text = "测试台架 Version " + Application.ProductVersion;
            }
        }
        //编辑信号的窗口，动态加载
        MessageTreeEdit mteMain;

        public FrmMain() {
            InitializeComponent();
            CancellationTokenSource cts = new CancellationTokenSource();
            new Task(() => {
                FrmWaiting frmw = new FrmWaiting();
                frmw.setTitle("正在初始化主程序...");
                frmw.Show();
                while (!cts.Token.IsCancellationRequested) {
                    Application.DoEvents();
                    Thread.Sleep(50);
                }
                frmw.Close();
                Activate();
            }, cts.Token).Start();
            try {
                //Your code here
                CheckForIllegalCrossThreadCalls = false;
                mteMain = new UserWidget.MessageTreeEdit();
                mteMain.Dock = DockStyle.Fill;
                panelMessageEditor.Controls.Add(mteMain);
                frmRX = new FrmSignalReceive();
                Logger.logUDF("程序库已经成功的加载了", "Main");
                Thread.Sleep(5500);//等待静态类的加载
            } catch (Exception ex) {
                Logger.logError(ex);
            } finally {
                cts.Cancel();//不论如何最后关闭导入进度条
                
            }
        }
        int dHeight, dWidth;
        FrmSignalReceive frmRX;
        private void FrmMain_Load(object sender, EventArgs e) {
            dHeight = Height - mteMain.Height;
            dWidth = Width - mteMain.Width;
            Text = "CAN信号测试台架 Version " + Application.ProductVersion;
        }

        private void logMessage(string message) {
            Logger.logDebug(message);
        }
        private void errorReport(string message) {
            Logger.logError(message);
            MessageBox.Show(message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        //快捷键接口
        private void FrmMain_KeyPress(object sender, KeyPressEventArgs e) {//Ctrl+B
            switch (e.KeyChar) {
                case ((char)2): //CTRL+B
                    Logger.show();
                    break;
                case ((char)4): //CTRL+D
                    //menuDeleteSignal_Click(sender, e);
                    JavascriptIDE.show();
                    break;
                case ((char)15)://CTRL+O
                    menuLoadConfigure_Click(sender, e);
                    break;
                case((char)19)://CTRL+S
                    menuSaveConfigure_Click(sender, e);
                    break;
                default:
                    //pass;
                    logMessage(((int)(e.KeyChar)).ToString() + "pressed but no action.");
                    break;
            }
        }

        
        //退出行为，注销设备，同时停止发送操作
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e) {
            bool isExit = true;
            if (e.CloseReason != CloseReason.ApplicationExitCall) {
                isExit = Utility.MsgBoxQuery("是否要退出？", "防止误操作");
            }
            e.Cancel = !isExit;
            if (isExit) {
                frmRX.Hide();
                Logger.hide();
                JavascriptIDE.hide();
                this.Hide();
                if (transmitStarted) {
                    stopTransmit();
                }
                if (DriverManager.Driver != null) {
                    DriverManager.FinializeDevice();
                }
                Logger.close();
                JavascriptIDE.close();
            }
        }
        //向列表中追加配置
        private void appendConfigures(ConfigureFile configs) {
            foreach (CANMessage config in configs.GetMessage()) {
                try {
                    mteMain.configure.AppendMessage(config);
                } catch { }
            }
            mteMain.reloadDisplay();
        }
        private void loadConfigures(ConfigureFile configs) {
            mteMain.configure = configs;
        }
        //从当前的ListBox中获取配置
        private ConfigureFile getConfigures() {
            return mteMain.configure;
        }
        void restartTxIfStarted() {
            if (
                transmitStarted
            ) {
                stopTransmit();
                startTransmit();
            }
        }
        
        //消息发送进程相关的内容
        Task sendThread;
        CancellationTokenSource cancelSendThread;
        TransmitData[] msgs;
        bool transmitStarted = false;
        //开始发送消息
        void startTransmit() {
            transmitStarted = true;
            menuCANDeviceSelect.Enabled = false;
            tbProgress.Style = ProgressBarStyle.Marquee;
            tbProgress.MarqueeAnimationSpeed = 200;
            MaskType paddingMode = FrmOptions.getPaddingType();
            List<TransmitData> lstSendData = new List<TransmitData>();
            foreach (CANMessage msg in mteMain.configure.GetMessage()) {
                lstSendData.Add(new TransmitData() {
                    data = new CANData(msg.ID,msg.BuildMessage(paddingMode)),
                    cycle = msg.TxPeriod,
                    lastTickms = 0,
                });
            }
            msgs = lstSendData.ToArray();
            cancelSendThread = new CancellationTokenSource();
            sendThread = new Task(sendDataThread, cancelSendThread.Token);
            setFPSProgressbar(calcTheoreticalFPS(msgs));
            sendThread.Start();
            logMessage("消息送信线程已经启动");
            lbSendStatus.Text = "正在发送全部信号";
        }
        double calcTheoreticalFPS(IEnumerable<TransmitData> TxMessageList) {
            double frameps = 0;
            foreach (TransmitData msg in TxMessageList) {
                frameps += (1000.0 / msg.cycle);
            }
            return frameps;
        }
        void setFPSProgressbar(double frameps) {
            //计算理论通信速率
            logMessage("送信理论帧速率:" + Math.Round(frameps).ToString() + "FPS");
            //一些便宜的设备无法达到100%的速率，最多50%，大约就是1000fps就不行了
            if (frameps > 1000.0) {
                MessageBox.Show(
                    "理论帧速率:" + frameps.ToString() + "FPS，可能超过一些设备的承受上限！",
                    "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Logger.logWarn("理论帧速率:" + frameps.ToString() + "FPS，可能超过一些设备的承受上限！");
            }
            tbProgress.MarqueeAnimationSpeed = (int)(20000.0 / frameps);
        }
        void startTransmitMinValue() {
            menuCANDeviceSelect.Enabled = false;
            tbProgress.Style = ProgressBarStyle.Marquee;
            tbProgress.MarqueeAnimationSpeed = 200;
            MaskType paddingMode = FrmOptions.getPaddingType();
            List<TransmitData> lstSendData = new List<TransmitData>();
            foreach (CANMessage msg in mteMain.configure.GetMessage()) {
                lstSendData.Add(new TransmitData() {
                    data = new CANData(msg.ID, msg.BuildMessage(paddingMode)),
                    cycle = msg.TxPeriod,
                    lastTickms = 0,
                });
            }

            msgs = lstSendData.ToArray();
            cancelSendThread = new CancellationTokenSource();
            sendThread = new Task(sendDataThread, cancelSendThread.Token);
            //计算理论通信速率
            setFPSProgressbar(calcTheoreticalFPS(msgs));
            sendThread.Start();
            logMessage("最小值消息送信线程已经启动");
        }

        //中止消息发送
        void stopTransmit() {
            transmitStarted = false;
            menuCANDeviceSelect.Enabled = true;
            cancelSendThread.Cancel();
            tbProgress.MarqueeAnimationSpeed = 0;
            tbProgress.Style = ProgressBarStyle.Continuous;
            tbProgress.Value = 0;
            tbProgress.Maximum = 100;
            tbProgress.Minimum = 0;
            logMessage("发送消息中止");
            lbSendStatus.Text = strNoSignalIsSending;
        }
        //消息发送的进程
        void sendDataThread() {
            DriverManager.SetTXDecoder(mteMain.configure);
            int msglen = msgs.Length;
            logMessage("正在发送消息...");
            while (!cancelSendThread.Token.IsCancellationRequested) {
                long thisTickms = DateTime.Now.Ticks / 10000;
                foreach (TransmitData msg in msgs) {
                    if (msg.isSend(thisTickms)) {
                        msg.lastTickms = thisTickms;
                        DriverManager.SendData(msg.data);
                    }
                }
                Thread.Sleep(1); //消耗一些CPU以保证实时性
                //Application.DoEvents();
            }
            logMessage("发送线程退出，发送结束。");
        }
        bool IDELoaded = false;
        private void menuDebugWin_Click(object sender, EventArgs e) {
            if (!IDELoaded) {
                loadIDEAndShow();
                IDELoaded = true;
            } else {
                JavascriptIDE.IDEForm.Show();
            }
        }

        private void loadIDEAndShow() {
            CancellationTokenSource cts = new CancellationTokenSource();
            new Task(() => {
                FrmWaiting frmw = new FrmWaiting();
                frmw.setTitle("正在初始化Javascript IDE ......");
                frmw.Show();
                while (!cts.Token.IsCancellationRequested) {
                    Application.DoEvents();
                    Thread.Sleep(50);
                }
                frmw.Close();
            }, cts.Token).Start();
            try {
                JavascriptIDE.IDEForm.Show();
            } catch (Exception ex) {
                errorReport("初始化IDE错误");
                Logger.logError(ex);
            } finally {
                cts.Cancel();//不论如何最后关闭导入进度条
            }
        }
        private void menuBugReport_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("https://github.com/TsingJyujing/CAN-panel/issues/new");
        }
        private void menuAbout_Click(object sender, EventArgs e) {
            new FrmAbout().ShowDialog();
        }
        private void menuDoc_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("https://github.com/TsingJyujing/CAN-panel/blob/master/README.md");
        }
        private void menuExit_Click(object sender, EventArgs e) {
            Close();
        }
     
        private void menuSaveAs_Click(object sender, EventArgs e) {
            cdlgSave.ShowDialog();
            if (cdlgSave.FileName != "") {
                try {
                    new JSONConfigIO().WriteConfigure(getConfigures(), cdlgSave.FileName);
                    setCurrentPath(cdlgSave.FileName);
                    logMessage("保存文件：" + currentPath + "成功");
                } catch (Exception ex) {
                    errorReport("写入文件的时候发生错误！");
                    Logger.logError(ex);
                }
            }
        }

        private void menuSaveConfigure_Click(object sender, EventArgs e) {
            if (currentPath != "") {
                try {
                    new JSONConfigIO().WriteConfigure(getConfigures(), currentPath);
                    logMessage("保存JSON文件成功");
                    return;
                } catch (Exception ex) {
                    errorReport("写入JSON文件的时候发生错误！");
                    Logger.logError(ex);
                }
            } else {
                menuSaveAs_Click(sender, e);
            }
        }

        private void menuSendSignal_Click(object sender, EventArgs e) {
            if (menuSendSignal.Text == strStopSendAllMessage) {
                menuSendSignal.Text = strStartSendAllMessage;

                menuSingleSignalSend.Enabled = true;
                stopTransmit();
                logMessage("发送全部报文已经中止");
            } else {
                if (DriverManager.Driver == null) {
                    errorReport("尚未初始化设备");
                } else if (mteMain.configure.GetMessage().Count<=0){
                    errorReport("没有可供发送的信号！");
                } else {
                    menuSendSignal.Text = strStopSendAllMessage;
                    startTransmit();
                    menuSingleSignalSend.Enabled = false;
                }
            }
        }

        private void menuClearList_Click(object sender, EventArgs e) {
            if (Utility.MsgBoxQuery("是否要清空整个列表？", "防止误删！")) {
                mteMain.configure = new ConfigureFile();
            }
        }
        private void menuSomebusCAN_Click(object sender, EventArgs e) {
            if (DriverManager.CANDriverFactory(ExistedDeviceType.Somebus)) {
                lbDeviceStatus.Text = "设备状态-Somebus已连接";
                logMessage("成功初始化Somebus设备!");
                frmRX.Show();
            } else {
                lbDeviceStatus.Text = "设备状态-无设备连接";
                errorReport("初始化Somebus设备失败!");
            }
        }

        private void menuiTekCAN_Click(object sender, EventArgs e) {
            if (DriverManager.CANDriverFactory(ExistedDeviceType.iTekAnalyst)) {
                lbDeviceStatus.Text = "设备状态-iTek已连接";
                logMessage("成功初始化iTek(CANPRO)设备!");
                frmRX.Show();
            } else {
                lbDeviceStatus.Text = "设备状态-无设备连接";
                logMessage("初始化iTek(CANPRO)设备失败!");
            }
        }

        private void menuVehicleSpy_Click(object sender, EventArgs e) {
            //VehicleSpy
            if (DriverManager.CANDriverFactory(ExistedDeviceType.Intrepidcs)) {
                lbDeviceStatus.Text = "设备状态-VSPY已连接";
                logMessage("成功初始化Vehicle Spy");
                frmRX.Show();
            } else {
                lbDeviceStatus.Text = "设备状态-无设备连接";
                errorReport("初始化Vehicle Spy失败");
            }
        }
        private void menuReleaseDevice_Click(object sender, EventArgs e) {
            DriverManager.FinializeDevice();
            lbDeviceStatus.Text = "设备状态-无设备连接";
        }

        private void menuOptions_Click(object sender, EventArgs e) {
            new FrmOptions().ShowDialog();
            mteMain.refreshDisplay();
        }

        private void FrmMain_Resize(object sender, EventArgs e) {
            Height = Height < 320 ? 320 : Height;
            Width = Width < 480 ? 480 : Width;
            mteMain.Height = Height - dHeight;
            mteMain.Width = Width - dWidth;
        }

        private void menuAppendSettings_Click(object sender, EventArgs e) {
            cdlgOpenJson.ShowDialog();
            if (cdlgOpenJson.FileName != "") {
                try {
                    appendConfigures(new JSONConfigIO().ReadConfigure(cdlgOpenJson.FileName));
                    logMessage("成功追加导入文件：" + cdlgOpenJson.FileName);
                    setCurrentPath(cdlgOpenJson.FileName);
                } catch (Exception ex) {
                    errorReport("读取追加导入文件的时候发生错误！");
                    Logger.logError(ex);
                }
            }
        }

        private void menuLoadConfigure_Click(object sender, EventArgs e) {
            cdlgOpenJson.ShowDialog();
            if (cdlgOpenJson.FileName != "") {
                try {
                    loadConfigures(new JSONConfigIO().ReadConfigure(cdlgOpenJson.FileName));
                    logMessage("成功导入文件：" + cdlgOpenJson.FileName);
                    setCurrentPath(cdlgOpenJson.FileName);
                } catch (Exception ex) {
                    errorReport("读取导入文件的时候发生错误！");
                    Logger.logError(ex);
                }
            }
        }

        private void menuSingleSignalSend_Click(object sender, EventArgs e) {
            if (DriverManager.Driver == null) {
                errorReport("请先初始化设备！");
                return;
            }
            if (mteMain.getCurrentSelected(MaskType.Mask1)==null) {
                errorReport("您未选择任何发送项！");
                return;
            }
            if (menuSingleSignalSend.Text == strStartSendOneSignal) {
                menuSingleSignalSend.Text = strStopSendOneSignal;
                menuSendSignal.Enabled = false;
                msgs = new TransmitData[] { mteMain.getCurrentSelected(MaskType.Mask1) };
                cancelSendThread = new CancellationTokenSource();
                sendThread = new Task(sendDataThread, cancelSendThread.Token);
                //计算理论通信速率
                setFPSProgressbar(calcTheoreticalFPS(msgs));
                sendThread.Start();
                logMessage("单信号送信开始");
                lbSendStatus.Text = "正在循环发送单个信号/报文";
            } else {
                menuSingleSignalSend.Text = strStartSendOneSignal;
                menuSendSignal.Enabled = true;
                stopTransmit();
                logMessage("单信号送信中止");
                lbSendStatus.Text = strNoSignalIsSending;
            }
        }

        private void menuSingleMessageSend_Click(object sender, EventArgs e) {
            if (DriverManager.Driver == null) {
                errorReport("请先初始化设备！");
                return;
            }
            TransmitData sd = mteMain.getCurrentSelected(MaskType.Mask1);
            DriverManager.SetTXDecoder(mteMain.configure);
            if (sd == null) {
                errorReport("您未选择任何发送项！");
                return;
            }
            if (DriverManager.SendData(sd.data)) {
                logMessage("发送成功" + sd.data.ToString());
            } else {
                logMessage("发送失败" + sd.data.ToString());
            }
        }

        private void btnOpen_Click(object sender, EventArgs e) {
            menuLoadConfigure_Click(sender, e);
        }

        private void btnSave_Click(object sender, EventArgs e) {
            menuSaveConfigure_Click(sender, e);
        }

        private void btnClear_Click(object sender, EventArgs e) {
            menuClearList_Click(sender, e);
        }

        private void btnSendOnce_Click(object sender, EventArgs e) {
            menuSingleMessageSend_Click(sender, e);
        }
        private void tsbGenKey_Click(object sender, EventArgs e) {
            
        }

        private void btnRXForm_Click(object sender, EventArgs e) {
            frmRX.Show();
        }
        //对列表中的每一项进行处理
        void processList(Action<CANSignal> processConfig) {
            foreach (CANMessage cMsg in mteMain.configure.GetMessage()) {
                foreach (CANSignal cSignal in cMsg.GetSignalList()) {
                    processConfig(cSignal);
                }
            }
            //如果已经启动发送就重启
            restartTxIfStarted();
        }
        //将所有的数值设置为最小值
        private void btnSetMin_Click(object sender, EventArgs e) {
            processList(new Action<CANSignal>((CANSignal cs) => {
                if (cs.sType == SignalType.Continuous) {
                    cs.DefaultValue = cs.MinValue;
                } else if (cs.sType == SignalType.Switch) {
                    cs.DefaultValue = cs.MinValue;
                }
            }));
        }
        //将所有的数值设置为最大值
        private void btnSetMax_Click(object sender, EventArgs e) {
            processList(new Action<CANSignal>((CANSignal cs) => {
                if (cs.sType == SignalType.Continuous) {
                    cs.DefaultValue = cs.MaxValue;
                } else if (cs.sType == SignalType.Switch) {
                    cs.DefaultValue = 1;
                }
            }));
        }
        //将所有的数值设置为中间值
        private void btnSetDefault_Click(object sender, EventArgs e) {
            processList(new Action<CANSignal>((CANSignal cs) => {
                if (cs.sType == SignalType.Continuous) {
                    cs.DefaultValue = (cs.MaxValue+1)/2;
                }
            }));
        }
        //用户定义比率
        private void btnSetUserDefined_Click(object sender, EventArgs e) {
            double ratio = double.Parse(InputBox.ShowInputBox("自定义比率", string.Empty));
            if (ratio < 0 || ratio > 1) {
                MessageBox.Show(
                    "比率不符合要求，需要在0~1之间！", "输入错误", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error
                    );
                return;
            }
            processList(new Action<CANSignal>((CANSignal cs) => {
                if (cs.sType == SignalType.Continuous) {
                    cs.DefaultValue = (ulong)(ratio * cs.MaxValue);
                }
            }));
        }
        //显示调试（Log）窗口
        private void btnDebugWindowOut_Click(object sender, EventArgs e) {
            Logger.show();
        }
        //随机设置所有的数值
        private void btnRandomValue_Click(object sender, EventArgs e) {
            Random rnd = new Random();
            processList(new Action<CANSignal>((CANSignal cs) => {
                double ratio = rnd.NextDouble();
                cs.DefaultValue = (ulong)Math.Round(ratio * cs.MaxValue);
            }));
        }
        //新建配置文件
        private void btnNewConfigure_Click(object sender, EventArgs e) {
            if (mteMain.configure.GetMessage().Count > 0) {
                if (!Utility.MsgBoxQuery("列表不为空，即将清空，是否继续？", "警告")) {
                    return;
                }
            }
            setCurrentPath("");
            btnClear_Click(sender, e);
        }
        //展开所有项
        private void btnExpandAll_Click(object sender, EventArgs e) {
            mteMain.ExpandAll();
        }
        //折叠所有项
        private void btnCollapseAll_Click(object sender, EventArgs e) {
            mteMain.CollapseAll();
        }
        //编辑用户的脚本
        private void btnEditUserCode_Click(object sender, EventArgs e) {
            FrmEditJavascript fuddf 
                = new FrmEditJavascript(mteMain.configure.UserDefinedScript);
            fuddf.ShowDialog();
            mteMain.configure.UserDefinedScript = fuddf.code;
        }

        private void btnFrmTx_Click(object sender, EventArgs e) {
            DriverManager.MessageTXForm.Show();
        }

        private void menuShowText_Click(object sender, EventArgs e) {
            menuShowText.Checked = !menuShowText.Checked;
            if (menuShowText.Checked) {
                foreach (ToolStripItem tsi in toolbarUseful.Items) {
                    tsi.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                }
            } else {
                foreach (ToolStripItem tsi in toolbarUseful.Items) {
                    tsi.DisplayStyle = ToolStripItemDisplayStyle.Image;
                }
            }
        }
    }
}
