using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CANSignalControlPanel.Data;
using CANSignalControlPanel.Driver;
using CANSignalControlPanel.Forms;
using LogService;
namespace CANSignalControlPanel.Service {
    public enum ExistedDeviceType {
        Intrepidcs,
        Somebus,
        iTekAnalyst
    }
    public static class DriverManager {
        static CANDriver cdriver = null;
        static FrmSignalTransmit TxForm;
        static DriverManager(){
            //Init function
            TxForm = new FrmSignalTransmit();
        }
        public static FrmSignalTransmit MessageTXForm {
            get {
                return TxForm;
            }
        }
        //处理消息的队列
        static Queue<Action<CANData>> messageProcessorQueue = new Queue<Action<CANData>>();
        public static CANData GetData(){
            CANData cd = cdriver.GetQueue().Dequeue();
            foreach (Action<CANData> processor in messageProcessorQueue) {
                processor(cd);
            }
            return cd;
        }
        public static void PushCANDataProcessor(Action<CANData> CANDataProcessor) {
            messageProcessorQueue.Enqueue(CANDataProcessor);
        }
        public static Action<CANData> PopCANDataProcessor() {
            return messageProcessorQueue.Dequeue();
        }
        public static bool IsInitialized {
            get {
                return cdriver != null;
            }
        }
        public static CANDriver Driver {
            get {
                return cdriver;
            }
        }
        public static bool SendData(CANData cd) {
            cd.ActionTime = DateTime.Now;
            bool TxResult = Driver.SendData(cd);
            TxForm.appendData(cd);
            return TxResult;
        }
        public static void SetTXDecoder(ConfigureFile cf) {
            TxForm.LoadConfigure(cf);
        }
        public static bool FinializeDevice() {
            if (cdriver != null) {
                try {
                    cdriver.FinalizeDevice();
                    cdriver = null;
                    return true;
                } catch (Exception ex) {
                    Logger.logError(ex);
                    return false;
                }
            } else {
                return false;
            }
        }
        public static bool CANDriverFactory(ExistedDeviceType deviceEnum) {
            try {
                FinializeDevice();
                switch (deviceEnum) {
                case ExistedDeviceType.Intrepidcs:
                    cdriver = new IntrepidcsDriver();
                    break;
                case ExistedDeviceType.Somebus:
                    cdriver = new SomebusDriver();
                    break;
                case ExistedDeviceType.iTekAnalyst:
                    cdriver = new iTekAnalystDriver();
                    break;
                default:
                    break;
                }
                bool initResult = cdriver.InitializeDevice("0,0".Split(new char[] { ',' }));
                if (!initResult) {
                    cdriver = null;
                    return false;
                } else {
                    cdriver.StartRX();
                    return true;
                }
            } catch (Exception ex) {
                Logger.logError(ex);
                return false;
            }
        }
    }
}
