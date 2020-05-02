using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using CANSignalControlPanel.Data;
using LogService;
using CANSignalControlPanel.Driver.Somebus;

namespace CANSignalControlPanel.Driver {
    
    public class SomebusDriver : CANDriver {

        static Dictionary<uint, string> errExplain = new Dictionary<uint, string>(){
            {0x0100,"设备已经打开"},
            {0x0200,"打开设备错误"},
            {0x0400,"设备没有打开"},
            {0x0800,"缓冲区溢出"},
            {0x1000,"此设备不存在"},
            {0x2000,"装载动态库失败"},
            {0x4000,"表示为执行命令失败错误"},
            {0x8000,"内存不足"},
            {0x0001,"CAN控制器内部FIFO溢出"},
            {0x0002,"CAN控制器错误报警"},
            {0x0004,"CAN控制器消极错误"},
            {0x0008,"CAN控制器仲裁丢失"},
            {0x0010,"CAN控制器总线错误"},
            {0x0020,"CAN接收寄存器满"},
            {0x0040,"CAN接收寄存器溢出"},
            {0x0080,"CAN控制器主动错误"}
        };

        uint useDeviceIndex = 0;
        uint useCANIndex = 0;
        static uint deviceType = 1;
        public override bool InitializeDevice(string[] args) {
            useDeviceIndex = 0;
            useCANIndex = DeviceUtil.SelectSubDeviceByIndex(0,1,"CAN端口");
            if (ECANDLL.OpenDevice(deviceType, useDeviceIndex, 0)
                != ECANStatus.STATUS_OK) {
                GetErrorInfo();
                return false;
            }
            INIT_CONFIG InitialConfig = new INIT_CONFIG();
            InitialConfig.AccCode = 0;
            InitialConfig.AccMask = 0xffffff;
            InitialConfig.Filter = 0;
            InitialConfig.Mode = 0;

            List<string> SelectBaudRate = new List<string>() { 
                "250kbps","500kbps"
            };
            FrmDeviceSelect FrmSelectBaudRate = new FrmDeviceSelect();
            FrmSelectBaudRate.LoadDeviceList(SelectBaudRate);
            FrmSelectBaudRate.SetTitle("请选择合适的波特率");
            FrmSelectBaudRate.ShowDialog();
            if (FrmSelectBaudRate.selectedText == "250kbps") {
                //250kbps
                InitialConfig.Timing0 = 0x01;
                InitialConfig.Timing1 = 0x1c;
            } else if (FrmSelectBaudRate.selectedText == "500kbps") {
                //250kbps
                InitialConfig.Timing0 = 0x00;
                InitialConfig.Timing1 = 0x1c;
            } else {
                // TODO add more baud rate setting here
                return false;
            }
            if (ECANDLL.InitCAN(deviceType, useDeviceIndex, useCANIndex, ref InitialConfig) != ECANStatus.STATUS_OK) {
                ECANDLL.CloseDevice(deviceType, useDeviceIndex);
                GetErrorInfo();
                return false;
            }
            //uint bRel = ECANDLL.ClearBuffer(deviceType, useDeviceIndex, useCANIndex);
            //Logger.logDebug("Clean Buffer结果(1 成功,0 失败)：" + bRel.ToString());
            //之所以发送这么一个毫无意义的东西是驱动的锅, 砍死开发驱动的
            SendData(new CANData(0x1, new byte[] { 1, 2, 4, 8, 16, 32, 64, 128 }));
            return true;
        }

        public override bool FinalizeDevice() {
            StopRX();
            ECANDLL.CloseDevice(deviceType, useDeviceIndex);
            return true;
        }
        public override bool SendData(CANData cdin) {
            CAN_OBJ co = new CAN_OBJ();
            co.data = cdin.GetData();
            co.ID = (uint)cdin.ID;
            co.DataLen = (byte)cdin.getDataLen();
            co.SendType = 1;
            co.ExternFlag = 0x01;
            co.RemoteFlag = 0x00;
            lock (this) {
                return ECANDLL.Transmit(deviceType, useDeviceIndex, useCANIndex, ref co, 1) == ECANStatus.STATUS_OK;
            }
        }
        public long GetReceivedCount() {
            return ECANDLL.GetReceiveNum(deviceType, useDeviceIndex, useCANIndex);
        }
        protected override void ReceiveData() {
            if (GetReceivedCount() <= 0) {
                return;
            }
            CAN_OBJ buffer = new CAN_OBJ();

            ECANStatus getStatus = ECANDLL.Receive(
                deviceType, useDeviceIndex, useCANIndex, ref buffer, 1, 20);
            if (getStatus == ECANStatus.STATUS_OK) {
                Push(new CANData((int)buffer.ID, buffer.data));
            }
            // Or else you can get error info as you want
        }
        
        void GetErrorInfo() {
            CAN_ERR_INFO errorInfo = new CAN_ERR_INFO();
            ECANStatus readErrResult = ECANDLL.ReadErrInfo(deviceType, useCANIndex, useCANIndex, out errorInfo);
            if (readErrResult != ECANStatus.STATUS_OK) {
                Logger.logError("无法读取CAN错误！");
                return;
            }
            if (errorInfo.ErrCode == 0) {
                Logger.logError("存在未知CAN错误！");
            } else {
                Logger.logError("存在以下CAN错误:");
                Logger.print("------------ECAN错误开始------------");
                foreach (uint errKey in errExplain.Keys) {
                    if ((errKey & errorInfo.ErrCode) > 0) {
                        Logger.print(errExplain[errKey]);
                    }
                }
                Logger.print("------------ECAN错误结束------------");
            }
        }
    }
    
}