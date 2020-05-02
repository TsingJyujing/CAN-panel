namespace CANSignalControlPanel.Forms
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.cdlgOpenXLS = new System.Windows.Forms.OpenFileDialog();
            this.cdlgSave = new System.Windows.Forms.SaveFileDialog();
            this.cdlgOpenJson = new System.Windows.Forms.OpenFileDialog();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.btnNewConfigure = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLoadConfigure = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAppendSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuSaveConfigure = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSetValue = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSetMin = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSetMax = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSetDefault = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRandomValue = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSetUserDefined = new System.Windows.Forms.ToolStripMenuItem();
            this.menuClear = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCANDeviceSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSomeBUSCAN = new System.Windows.Forms.ToolStripMenuItem();
            this.menuiTekCAN = new System.Windows.Forms.ToolStripMenuItem();
            this.menuVehicleSpy = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReleaseDevice = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.menuShowText = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTest = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSendSignal = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSingleSignalSend = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSingleMessageSend = new System.Windows.Forms.ToolStripMenuItem();
            this.menuWindows = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDebugWin = new System.Windows.Forms.ToolStripMenuItem();
            this.btnRXForm = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFrmTx = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDebugWindowOut = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuBugReport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStripMain = new System.Windows.Forms.StatusStrip();
            this.lbDeviceStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbSendStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tbProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.toolbarUseful = new System.Windows.Forms.ToolStrip();
            this.btnOpen = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClear = new System.Windows.Forms.ToolStripButton();
            this.tss1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSendOnce = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExpandAll = new System.Windows.Forms.ToolStripButton();
            this.btnCollapseAll = new System.Windows.Forms.ToolStripButton();
            this.btnEditUserCode = new System.Windows.Forms.ToolStripButton();
            this.tsbGenKey = new System.Windows.Forms.ToolStripButton();
            this.panelMessageEditor = new System.Windows.Forms.Panel();
            this.menuStripMain.SuspendLayout();
            this.statusStripMain.SuspendLayout();
            this.toolbarUseful.SuspendLayout();
            this.SuspendLayout();
            // 
            // cdlgOpenXLS
            // 
            this.cdlgOpenXLS.Filter = "Excel(*.xlsx)|*.xlsx|Excel(*.xls)|*.xls";
            this.cdlgOpenXLS.Title = "导入Excel格式的配置文件";
            // 
            // cdlgSave
            // 
            this.cdlgSave.Filter = "JSON配置文件(*.json)|*.json";
            this.cdlgSave.Title = "保存JSON格式的配置文件";
            // 
            // cdlgOpenJson
            // 
            this.cdlgOpenJson.Filter = "JSON配置文件(*.json)|*.json";
            this.cdlgOpenJson.Title = "打开JSON格式的配置文件";
            // 
            // menuStripMain
            // 
            this.menuStripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuEdit,
            this.menuSetting,
            this.menuTest,
            this.menuWindows,
            this.menuHelp});
            this.menuStripMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(779, 25);
            this.menuStripMain.TabIndex = 21;
            this.menuStripMain.Text = "menuMain";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNewConfigure,
            this.menuLoadConfigure,
            this.menuAppendSettings,
            this.toolStripSeparator1,
            this.menuSaveConfigure,
            this.menuSaveAs,
            this.toolStripSeparator2,
            this.menuExit});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(58, 21);
            this.menuFile.Text = "文件(&F)";
            // 
            // btnNewConfigure
            // 
            this.btnNewConfigure.Image = ((System.Drawing.Image)(resources.GetObject("btnNewConfigure.Image")));
            this.btnNewConfigure.Name = "btnNewConfigure";
            this.btnNewConfigure.Size = new System.Drawing.Size(166, 22);
            this.btnNewConfigure.Text = "新建配置文件(&N)";
            this.btnNewConfigure.Click += new System.EventHandler(this.btnNewConfigure_Click);
            // 
            // menuLoadConfigure
            // 
            this.menuLoadConfigure.Image = ((System.Drawing.Image)(resources.GetObject("menuLoadConfigure.Image")));
            this.menuLoadConfigure.Name = "menuLoadConfigure";
            this.menuLoadConfigure.Size = new System.Drawing.Size(166, 22);
            this.menuLoadConfigure.Text = "加载配置(&L)";
            this.menuLoadConfigure.Click += new System.EventHandler(this.menuLoadConfigure_Click);
            // 
            // menuAppendSettings
            // 
            this.menuAppendSettings.Image = ((System.Drawing.Image)(resources.GetObject("menuAppendSettings.Image")));
            this.menuAppendSettings.Name = "menuAppendSettings";
            this.menuAppendSettings.Size = new System.Drawing.Size(166, 22);
            this.menuAppendSettings.Text = "追加配置(&P)";
            this.menuAppendSettings.Click += new System.EventHandler(this.menuAppendSettings_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(163, 6);
            // 
            // menuSaveConfigure
            // 
            this.menuSaveConfigure.Image = ((System.Drawing.Image)(resources.GetObject("menuSaveConfigure.Image")));
            this.menuSaveConfigure.Name = "menuSaveConfigure";
            this.menuSaveConfigure.Size = new System.Drawing.Size(166, 22);
            this.menuSaveConfigure.Text = "保存配置(&S)";
            this.menuSaveConfigure.Click += new System.EventHandler(this.menuSaveConfigure_Click);
            // 
            // menuSaveAs
            // 
            this.menuSaveAs.Image = ((System.Drawing.Image)(resources.GetObject("menuSaveAs.Image")));
            this.menuSaveAs.Name = "menuSaveAs";
            this.menuSaveAs.Size = new System.Drawing.Size(166, 22);
            this.menuSaveAs.Text = "另存为...(&A)";
            this.menuSaveAs.Click += new System.EventHandler(this.menuSaveAs_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(163, 6);
            // 
            // menuExit
            // 
            this.menuExit.Image = ((System.Drawing.Image)(resources.GetObject("menuExit.Image")));
            this.menuExit.Name = "menuExit";
            this.menuExit.Size = new System.Drawing.Size(166, 22);
            this.menuExit.Text = "退出(&E)";
            this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
            // 
            // menuEdit
            // 
            this.menuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSetValue,
            this.menuClear});
            this.menuEdit.Name = "menuEdit";
            this.menuEdit.Size = new System.Drawing.Size(59, 21);
            this.menuEdit.Text = "编辑(&E)";
            // 
            // btnSetValue
            // 
            this.btnSetValue.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSetMin,
            this.btnSetMax,
            this.btnSetDefault,
            this.btnRandomValue,
            this.btnSetUserDefined});
            this.btnSetValue.Image = ((System.Drawing.Image)(resources.GetObject("btnSetValue.Image")));
            this.btnSetValue.Name = "btnSetValue";
            this.btnSetValue.Size = new System.Drawing.Size(124, 22);
            this.btnSetValue.Text = "设置数值";
            // 
            // btnSetMin
            // 
            this.btnSetMin.Name = "btnSetMin";
            this.btnSetMin.Size = new System.Drawing.Size(160, 22);
            this.btnSetMin.Text = "全部设为最小值";
            this.btnSetMin.Click += new System.EventHandler(this.btnSetMin_Click);
            // 
            // btnSetMax
            // 
            this.btnSetMax.Name = "btnSetMax";
            this.btnSetMax.Size = new System.Drawing.Size(160, 22);
            this.btnSetMax.Text = "全部设为最大值";
            this.btnSetMax.Click += new System.EventHandler(this.btnSetMax_Click);
            // 
            // btnSetDefault
            // 
            this.btnSetDefault.Name = "btnSetDefault";
            this.btnSetDefault.Size = new System.Drawing.Size(160, 22);
            this.btnSetDefault.Text = "全部设置中间值";
            this.btnSetDefault.Click += new System.EventHandler(this.btnSetDefault_Click);
            // 
            // btnRandomValue
            // 
            this.btnRandomValue.Name = "btnRandomValue";
            this.btnRandomValue.Size = new System.Drawing.Size(160, 22);
            this.btnRandomValue.Text = "随机打乱数值";
            this.btnRandomValue.Click += new System.EventHandler(this.btnRandomValue_Click);
            // 
            // btnSetUserDefined
            // 
            this.btnSetUserDefined.Name = "btnSetUserDefined";
            this.btnSetUserDefined.Size = new System.Drawing.Size(160, 22);
            this.btnSetUserDefined.Text = "自定义比例";
            this.btnSetUserDefined.Click += new System.EventHandler(this.btnSetUserDefined_Click);
            // 
            // menuClear
            // 
            this.menuClear.Image = ((System.Drawing.Image)(resources.GetObject("menuClear.Image")));
            this.menuClear.Name = "menuClear";
            this.menuClear.Size = new System.Drawing.Size(124, 22);
            this.menuClear.Text = "清空列表";
            // 
            // menuSetting
            // 
            this.menuSetting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCANDeviceSelect,
            this.menuOptions,
            this.menuShowText});
            this.menuSetting.Name = "menuSetting";
            this.menuSetting.Size = new System.Drawing.Size(59, 21);
            this.menuSetting.Text = "设置(&S)";
            // 
            // menuCANDeviceSelect
            // 
            this.menuCANDeviceSelect.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSomeBUSCAN,
            this.menuiTekCAN,
            this.menuVehicleSpy,
            this.menuReleaseDevice});
            this.menuCANDeviceSelect.Image = ((System.Drawing.Image)(resources.GetObject("menuCANDeviceSelect.Image")));
            this.menuCANDeviceSelect.Name = "menuCANDeviceSelect";
            this.menuCANDeviceSelect.Size = new System.Drawing.Size(167, 22);
            this.menuCANDeviceSelect.Text = "CAN设备选择(&D)";
            // 
            // menuSomeBUSCAN
            // 
            this.menuSomeBUSCAN.Name = "menuSomeBUSCAN";
            this.menuSomeBUSCAN.Size = new System.Drawing.Size(298, 22);
            this.menuSomeBUSCAN.Text = "&Somebus USB-CAN";
            this.menuSomeBUSCAN.Click += new System.EventHandler(this.menuSomebusCAN_Click);
            // 
            // menuiTekCAN
            // 
            this.menuiTekCAN.Name = "menuiTekCAN";
            this.menuiTekCAN.Size = new System.Drawing.Size(298, 22);
            this.menuiTekCAN.Text = "&iTek CAN Analyst（兼容CANPRO驱动）";
            this.menuiTekCAN.Click += new System.EventHandler(this.menuiTekCAN_Click);
            // 
            // menuVehicleSpy
            // 
            this.menuVehicleSpy.Name = "menuVehicleSpy";
            this.menuVehicleSpy.Size = new System.Drawing.Size(298, 22);
            this.menuVehicleSpy.Text = "&Vehicle Spy";
            this.menuVehicleSpy.Click += new System.EventHandler(this.menuVehicleSpy_Click);
            // 
            // menuReleaseDevice
            // 
            this.menuReleaseDevice.Name = "menuReleaseDevice";
            this.menuReleaseDevice.Size = new System.Drawing.Size(298, 22);
            this.menuReleaseDevice.Text = "释放设备(&R)";
            this.menuReleaseDevice.Click += new System.EventHandler(this.menuReleaseDevice_Click);
            // 
            // menuOptions
            // 
            this.menuOptions.Image = ((System.Drawing.Image)(resources.GetObject("menuOptions.Image")));
            this.menuOptions.Name = "menuOptions";
            this.menuOptions.Size = new System.Drawing.Size(167, 22);
            this.menuOptions.Text = "选项(&O)";
            this.menuOptions.Click += new System.EventHandler(this.menuOptions_Click);
            // 
            // menuShowText
            // 
            this.menuShowText.Checked = true;
            this.menuShowText.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuShowText.Name = "menuShowText";
            this.menuShowText.Size = new System.Drawing.Size(167, 22);
            this.menuShowText.Text = "显示工具栏文字";
            this.menuShowText.Click += new System.EventHandler(this.menuShowText_Click);
            // 
            // menuTest
            // 
            this.menuTest.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSendSignal,
            this.menuSingleSignalSend,
            this.menuSingleMessageSend});
            this.menuTest.Name = "menuTest";
            this.menuTest.Size = new System.Drawing.Size(59, 21);
            this.menuTest.Text = "工具(&T)";
            // 
            // menuSendSignal
            // 
            this.menuSendSignal.Name = "menuSendSignal";
            this.menuSendSignal.Size = new System.Drawing.Size(172, 22);
            this.menuSendSignal.Text = "发送全部报文";
            this.menuSendSignal.Click += new System.EventHandler(this.menuSendSignal_Click);
            // 
            // menuSingleSignalSend
            // 
            this.menuSingleSignalSend.Name = "menuSingleSignalSend";
            this.menuSingleSignalSend.Size = new System.Drawing.Size(172, 22);
            this.menuSingleSignalSend.Text = "循环发送单个信号";
            this.menuSingleSignalSend.Click += new System.EventHandler(this.menuSingleSignalSend_Click);
            // 
            // menuSingleMessageSend
            // 
            this.menuSingleMessageSend.Name = "menuSingleMessageSend";
            this.menuSingleMessageSend.Size = new System.Drawing.Size(172, 22);
            this.menuSingleMessageSend.Text = "单个信号单次发送";
            this.menuSingleMessageSend.Click += new System.EventHandler(this.menuSingleMessageSend_Click);
            // 
            // menuWindows
            // 
            this.menuWindows.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuDebugWin,
            this.btnRXForm,
            this.btnFrmTx,
            this.btnDebugWindowOut});
            this.menuWindows.Name = "menuWindows";
            this.menuWindows.Size = new System.Drawing.Size(64, 21);
            this.menuWindows.Text = "窗口(&W)";
            // 
            // menuDebugWin
            // 
            this.menuDebugWin.Image = ((System.Drawing.Image)(resources.GetObject("menuDebugWin.Image")));
            this.menuDebugWin.Name = "menuDebugWin";
            this.menuDebugWin.Size = new System.Drawing.Size(170, 22);
            this.menuDebugWin.Text = "Javascript IDE(&J)";
            this.menuDebugWin.Click += new System.EventHandler(this.menuDebugWin_Click);
            // 
            // btnRXForm
            // 
            this.btnRXForm.Image = ((System.Drawing.Image)(resources.GetObject("btnRXForm.Image")));
            this.btnRXForm.Name = "btnRXForm";
            this.btnRXForm.Size = new System.Drawing.Size(170, 22);
            this.btnRXForm.Text = "收信窗口(&R)";
            this.btnRXForm.Click += new System.EventHandler(this.btnRXForm_Click);
            // 
            // btnFrmTx
            // 
            this.btnFrmTx.Image = ((System.Drawing.Image)(resources.GetObject("btnFrmTx.Image")));
            this.btnFrmTx.Name = "btnFrmTx";
            this.btnFrmTx.Size = new System.Drawing.Size(170, 22);
            this.btnFrmTx.Text = "送信窗口";
            this.btnFrmTx.Click += new System.EventHandler(this.btnFrmTx_Click);
            // 
            // btnDebugWindowOut
            // 
            this.btnDebugWindowOut.Image = ((System.Drawing.Image)(resources.GetObject("btnDebugWindowOut.Image")));
            this.btnDebugWindowOut.Name = "btnDebugWindowOut";
            this.btnDebugWindowOut.Size = new System.Drawing.Size(170, 22);
            this.btnDebugWindowOut.Text = "调试输出(&D)";
            this.btnDebugWindowOut.Click += new System.EventHandler(this.btnDebugWindowOut_Click);
            // 
            // menuHelp
            // 
            this.menuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuBugReport,
            this.menuDoc,
            this.menuAbout});
            this.menuHelp.Name = "menuHelp";
            this.menuHelp.Size = new System.Drawing.Size(61, 21);
            this.menuHelp.Text = "帮助(&H)";
            // 
            // menuBugReport
            // 
            this.menuBugReport.Image = ((System.Drawing.Image)(resources.GetObject("menuBugReport.Image")));
            this.menuBugReport.Name = "menuBugReport";
            this.menuBugReport.Size = new System.Drawing.Size(144, 22);
            this.menuBugReport.Text = "故障报告(&B)";
            this.menuBugReport.Click += new System.EventHandler(this.menuBugReport_Click);
            // 
            // menuDoc
            // 
            this.menuDoc.Image = ((System.Drawing.Image)(resources.GetObject("menuDoc.Image")));
            this.menuDoc.Name = "menuDoc";
            this.menuDoc.Size = new System.Drawing.Size(144, 22);
            this.menuDoc.Text = "使用手册(&M)";
            this.menuDoc.Click += new System.EventHandler(this.menuDoc_Click);
            // 
            // menuAbout
            // 
            this.menuAbout.Image = ((System.Drawing.Image)(resources.GetObject("menuAbout.Image")));
            this.menuAbout.Name = "menuAbout";
            this.menuAbout.Size = new System.Drawing.Size(144, 22);
            this.menuAbout.Text = "关于(&A)";
            this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
            // 
            // statusStripMain
            // 
            this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbDeviceStatus,
            this.toolStripStatusLabel1,
            this.lbSendStatus,
            this.tbProgress});
            this.statusStripMain.Location = new System.Drawing.Point(0, 508);
            this.statusStripMain.Name = "statusStripMain";
            this.statusStripMain.Size = new System.Drawing.Size(779, 22);
            this.statusStripMain.TabIndex = 22;
            this.statusStripMain.Text = "statusStrip1";
            // 
            // lbDeviceStatus
            // 
            this.lbDeviceStatus.Name = "lbDeviceStatus";
            this.lbDeviceStatus.Size = new System.Drawing.Size(121, 17);
            this.lbDeviceStatus.Text = "设备状态-无设备连接";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(110, 17);
            this.toolStripStatusLabel1.Text = "       CAN收发状态";
            // 
            // lbSendStatus
            // 
            this.lbSendStatus.Name = "lbSendStatus";
            this.lbSendStatus.Size = new System.Drawing.Size(68, 17);
            this.lbSendStatus.Text = "无信号发送";
            // 
            // tbProgress
            // 
            this.tbProgress.MarqueeAnimationSpeed = 0;
            this.tbProgress.Name = "tbProgress";
            this.tbProgress.Size = new System.Drawing.Size(150, 16);
            this.tbProgress.Step = 1;
            this.tbProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // toolbarUseful
            // 
            this.toolbarUseful.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolbarUseful.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpen,
            this.btnSave,
            this.toolStripSeparator4,
            this.btnClear,
            this.tss1,
            this.btnSendOnce,
            this.toolStripSeparator3,
            this.btnExpandAll,
            this.btnCollapseAll,
            this.btnEditUserCode,
            this.tsbGenKey});
            this.toolbarUseful.Location = new System.Drawing.Point(0, 25);
            this.toolbarUseful.Name = "toolbarUseful";
            this.toolbarUseful.Size = new System.Drawing.Size(779, 27);
            this.toolbarUseful.TabIndex = 23;
            // 
            // btnOpen
            // 
            this.btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnOpen.Image")));
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(56, 24);
            this.btnOpen.Text = "打开";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(56, 24);
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 27);
            // 
            // btnClear
            // 
            this.btnClear.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.Image")));
            this.btnClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(80, 24);
            this.btnClear.Text = "清空列表";
            // 
            // tss1
            // 
            this.tss1.Name = "tss1";
            this.tss1.Size = new System.Drawing.Size(6, 27);
            // 
            // btnSendOnce
            // 
            this.btnSendOnce.Image = ((System.Drawing.Image)(resources.GetObject("btnSendOnce.Image")));
            this.btnSendOnce.Name = "btnSendOnce";
            this.btnSendOnce.Size = new System.Drawing.Size(80, 24);
            this.btnSendOnce.Text = "单条送信";
            this.btnSendOnce.Click += new System.EventHandler(this.btnSendOnce_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // btnExpandAll
            // 
            this.btnExpandAll.Image = ((System.Drawing.Image)(resources.GetObject("btnExpandAll.Image")));
            this.btnExpandAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExpandAll.Name = "btnExpandAll";
            this.btnExpandAll.Size = new System.Drawing.Size(80, 24);
            this.btnExpandAll.Text = "展开所有";
            this.btnExpandAll.Click += new System.EventHandler(this.btnExpandAll_Click);
            // 
            // btnCollapseAll
            // 
            this.btnCollapseAll.Image = ((System.Drawing.Image)(resources.GetObject("btnCollapseAll.Image")));
            this.btnCollapseAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCollapseAll.Name = "btnCollapseAll";
            this.btnCollapseAll.Size = new System.Drawing.Size(80, 24);
            this.btnCollapseAll.Text = "折叠所有";
            this.btnCollapseAll.Click += new System.EventHandler(this.btnCollapseAll_Click);
            // 
            // btnEditUserCode
            // 
            this.btnEditUserCode.Image = ((System.Drawing.Image)(resources.GetObject("btnEditUserCode.Image")));
            this.btnEditUserCode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditUserCode.Name = "btnEditUserCode";
            this.btnEditUserCode.Size = new System.Drawing.Size(104, 24);
            this.btnEditUserCode.Text = "编辑用户函数";
            this.btnEditUserCode.Click += new System.EventHandler(this.btnEditUserCode_Click);
            // 
            // tsbGenKey
            // 
            this.tsbGenKey.Image = ((System.Drawing.Image)(resources.GetObject("tsbGenKey.Image")));
            this.tsbGenKey.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGenKey.Name = "tsbGenKey";
            this.tsbGenKey.Size = new System.Drawing.Size(132, 24);
            this.tsbGenKey.Text = "GenerateAuthKey";
            this.tsbGenKey.Visible = false;
            this.tsbGenKey.Click += new System.EventHandler(this.tsbGenKey_Click);
            // 
            // panelMessageEditor
            // 
            this.panelMessageEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMessageEditor.Location = new System.Drawing.Point(0, 52);
            this.panelMessageEditor.Name = "panelMessageEditor";
            this.panelMessageEditor.Size = new System.Drawing.Size(779, 456);
            this.panelMessageEditor.TabIndex = 24;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 530);
            this.Controls.Add(this.panelMessageEditor);
            this.Controls.Add(this.toolbarUseful);
            this.Controls.Add(this.statusStripMain);
            this.Controls.Add(this.menuStripMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "信号测试台架";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmMain_KeyPress);
            this.Resize += new System.EventHandler(this.FrmMain_Resize);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.statusStripMain.ResumeLayout(false);
            this.statusStripMain.PerformLayout();
            this.toolbarUseful.ResumeLayout(false);
            this.toolbarUseful.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog cdlgOpenXLS;
        private System.Windows.Forms.SaveFileDialog cdlgSave;
        private System.Windows.Forms.OpenFileDialog cdlgOpenJson;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuLoadConfigure;
        private System.Windows.Forms.ToolStripMenuItem menuSaveConfigure;
        private System.Windows.Forms.ToolStripMenuItem menuSaveAs;
        private System.Windows.Forms.ToolStripMenuItem menuEdit;
        private System.Windows.Forms.ToolStripMenuItem menuSetting;
        private System.Windows.Forms.ToolStripMenuItem menuCANDeviceSelect;
        private System.Windows.Forms.ToolStripMenuItem menuTest;
        private System.Windows.Forms.ToolStripMenuItem menuSendSignal;
        private System.Windows.Forms.ToolStripMenuItem menuHelp;
        private System.Windows.Forms.ToolStripMenuItem menuBugReport;
        private System.Windows.Forms.ToolStripMenuItem menuDoc;
        private System.Windows.Forms.ToolStripMenuItem menuAbout;
        private System.Windows.Forms.StatusStrip statusStripMain;
        private System.Windows.Forms.ToolStripStatusLabel lbDeviceStatus;
        private System.Windows.Forms.ToolStripMenuItem menuExit;
        private System.Windows.Forms.ToolStripMenuItem menuOptions;
        private System.Windows.Forms.ToolStripMenuItem menuSomeBUSCAN;
        private System.Windows.Forms.ToolStripMenuItem menuiTekCAN;
        private System.Windows.Forms.ToolStripMenuItem menuReleaseDevice;
        private System.Windows.Forms.ToolStripMenuItem menuWindows;
        private System.Windows.Forms.ToolStripMenuItem menuDebugWin;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem menuAppendSettings;
        private System.Windows.Forms.ToolStripProgressBar tbProgress;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem menuSingleSignalSend;
        private System.Windows.Forms.ToolStripMenuItem menuSingleMessageSend;
        private System.Windows.Forms.ToolStrip toolbarUseful;
        private System.Windows.Forms.ToolStripSeparator tss1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem menuVehicleSpy;
        private System.Windows.Forms.ToolStripMenuItem btnRXForm;
        private System.Windows.Forms.ToolStripButton btnOpen;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnSendOnce;
        private System.Windows.Forms.ToolStripMenuItem btnSetValue;
        private System.Windows.Forms.ToolStripMenuItem btnSetMin;
        private System.Windows.Forms.ToolStripMenuItem btnSetMax;
        private System.Windows.Forms.ToolStripMenuItem btnSetDefault;
        private System.Windows.Forms.ToolStripMenuItem btnSetUserDefined;
        private System.Windows.Forms.ToolStripMenuItem btnDebugWindowOut;
        private System.Windows.Forms.ToolStripMenuItem btnRandomValue;
        private System.Windows.Forms.ToolStripMenuItem btnNewConfigure;
        private System.Windows.Forms.ToolStripStatusLabel lbSendStatus;
        private System.Windows.Forms.Panel panelMessageEditor;
        private System.Windows.Forms.ToolStripMenuItem menuClear;
        private System.Windows.Forms.ToolStripButton btnClear;
        private System.Windows.Forms.ToolStripButton btnExpandAll;
        private System.Windows.Forms.ToolStripButton btnCollapseAll;
        private System.Windows.Forms.ToolStripButton btnEditUserCode;
        private System.Windows.Forms.ToolStripMenuItem btnFrmTx;
        private System.Windows.Forms.ToolStripButton tsbGenKey;
        private System.Windows.Forms.ToolStripMenuItem menuShowText;
        //private UserWidget.MessageTreeEdit mteMain;
    }
}

