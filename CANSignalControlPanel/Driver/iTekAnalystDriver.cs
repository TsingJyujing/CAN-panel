using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using CANSignalControlPanel.Data;
using CANSignalControlPanel.Utilities;
using LogService;
using CANSignalControlPanel.Driver.iTek;

namespace CANSignalControlPanel.Driver {

    public class iTekAnalystDriver : CANDriver {
        uint useDeviceIndex = 0;
        uint useCANIndex = 0;
        static uint devideType = 4;
        public override bool InitializeDevice(string[] args) {
            useDeviceIndex = 0;
            useCANIndex = useCANIndex = DeviceUtil.SelectSubDeviceByIndex(0, 1, "CAN端口");
            uint openResult = iTekAnalyst2API.VCI_OpenDevice(devideType, useDeviceIndex, 0);
            if (openResult == 0) {
                Logger.logError("iTek(CANPRO)打开失败！原因：" + openResult.ToString());
                return false;
            }
            VCI_INIT_CONFIG config = new VCI_INIT_CONFIG();
            config.AccCode = 0;
            config.AccMask = 0xffffff;
            List<string> selectBaudRate = new List<string>() { 
                "250kbps","500kbps"
            };
            FrmDeviceSelect frmSelectBaudRate = new FrmDeviceSelect();
            frmSelectBaudRate.LoadDeviceList(selectBaudRate);
            frmSelectBaudRate.SetTitle("请选择合适的波特率");
            frmSelectBaudRate.ShowDialog();
            if (frmSelectBaudRate.selectedText == "250kbps") {
                //250kbps
                config.Timing0 = 0x01;
                config.Timing1 = 0x1c;
            } else if (frmSelectBaudRate.selectedText == "500kbps") {
                //250kbps
                config.Timing0 = 0x00;
                config.Timing1 = 0x1c;
            } else {
                return false;
            }
            frmSelectBaudRate.Dispose();
            config.Filter = 0;
            config.Mode = 0;
            uint initResult = iTekAnalyst2API.VCI_InitCAN(devideType, useDeviceIndex, useCANIndex, ref config);
            Logger.logInfo("iTek(CANPRO)初始化结果:" + initResult.ToString());
            uint startResult = iTekAnalyst2API.VCI_StartCAN(devideType, useDeviceIndex, useCANIndex);
            Logger.logInfo("iTek(CANPRO)启动结果:" + startResult.ToString());
            return true;
        }

        protected override void ReceiveData() {
            try {
                uint bufferSize = iTekAnalyst2API.VCI_GetReceiveNum(
                    devideType, useDeviceIndex, useCANIndex);
                if (bufferSize <= 0) {
                    return;
                }
                VCI_CAN_OBJ vcos = new VCI_CAN_OBJ();
                uint realSize;
                for (int i = 0; i < bufferSize; i++) {
                    realSize = iTekAnalyst2API.VCI_Receive(
                    devideType, useDeviceIndex, useCANIndex,
                    ref vcos, 1, 100);
                    if (realSize != 0xFFFFFFFF && realSize > 0) {
                        Push(new CANData((int)vcos.ID, vcos.Data));
                    } else {
                        break;
                    }
                }
            }catch (Exception ex) {
                Logger.logError(ex);
            }
            
        }
        public override bool FinalizeDevice() {
            uint closeResult = iTekAnalyst2API.VCI_CloseDevice(devideType, useDeviceIndex);
            Logger.logInfo("iTek(CANPRO)释放结果：" + closeResult.ToString());
            return true;
        }

        public override bool SendData(CANData data) {
            VCI_CAN_OBJ co = new VCI_CAN_OBJ();
            co.Data = data.GetData();
            co.ID = (uint)data.ID;
            co.DataLen = (byte)data.getDataLen();
            co.SendType = 1;
            co.ExternFlag = 0x01;
            co.RemoteFlag = 0x00;
            lock (this) {
                uint sendResult 
                    = iTekAnalyst2API.VCI_Transmit(devideType, useDeviceIndex, useCANIndex, ref co, 1);
                return sendResult != 0;
            }
        }
    }

    
}
