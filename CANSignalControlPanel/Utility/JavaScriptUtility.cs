using CANSignalControlPanel.Data;
using CANSignalControlPanel.Service;
using CANSignalControlPanel.UserWidget;
using LogService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CANSignalControlPanel.Utilities {
    public class JavaScriptUtility {
        public long currentTicks {
            get {
                return DateTime.Now.Ticks;
            }
        }
        public double currentmsTicks {
            get {
                return DateTime.Now.Ticks/10000.0;
            }
        }

        public static void alert(string queryInfo, string title) {
            MessageBox.Show(queryInfo, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void alert(string queryInfo) {
            alert(queryInfo, "JavaScript Utility");
        }
        public static bool confirm(string queryInfo, string title) {
            return MessageBox.Show(
                queryInfo, title,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question
                ) == DialogResult.Yes;
        }
        public static bool confirm(string queryInfo) {
            return confirm(queryInfo, "JavaScript Utility");
        }
        public static string get(string urlget) {
            return get(urlget, 10000);
        }
        public static string get(string urlget, int timeout) {
            try {
                HttpWebRequest request;
                request = (HttpWebRequest)WebRequest.Create(urlget);
                request.Timeout = timeout;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader myreader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                string responseText = myreader.ReadToEnd();
                myreader.Close();
                return responseText;
            } catch (Exception e) {
                Logger.logWarn("HTTP error:" + e.Message);
                return "HTTP GET Error:" + e.Message;
            }
        }
        public static string gbk2utf8(string strIn) {
            return Encoding.UTF8.GetString(Encoding.GetEncoding("GBK").GetBytes(strIn));
        }
        public static void loadJSFile(string filename) {
            JavaScriptEngine.runFile(filename);
        }
        public static void log(string text) {
            Logger.logUDF(text, "JSPRINT");
        }
        public static void print(object obj) {
            JavascriptIDE.add(obj.ToString());
            //Logger.logUDF(obj.ToString(), "JSPRINT");
        }
        public static void clear() {
            JavascriptIDE.clear();
        }
        public static void exit() {
            Environment.Exit(0);
        }
        public static void closeLog() {
            Logger.hide();
        }
        public static void openLog() {
            Logger.show();
        }

        public static void closeIDE() {
            JavascriptIDE.hide();
        }
        public static void openIDE() {
            JavascriptIDE.show();
        }
        public static void sleep(int mills) {
            /*
            DateTime targetTime = DateTime.Now + new TimeSpan(0, 0, 0, 0, mills);
            //休息10秒用于处理窗体消息
            while (DateTime.Now < targetTime) {
                Application.DoEvents();
            }*/
            Thread.Sleep(mills);
        }
        public static DateTime getServerTime(string urlget, int timeout) {
            try {
                HttpWebRequest request;
                request = (HttpWebRequest)WebRequest.Create(urlget);
                request.Timeout = timeout;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Logger.logDebug(response.Headers.Get("Date"));
                return DateTime.Parse(response.Headers.Get("Date"));
            } catch (Exception e) {
                Logger.logWarn("HTTP error:" + urlget + "  Reason:" + e.Message);
                return DateTime.Now;
            }
        }
        public static DateTime getServerTime(string urlget) {
            return getServerTime(urlget, 10 * 1000);
        }
        public static CANData getNewCANData(int ID, int[] Data) {
            return CANData.getNewJS(ID, Data);
        }
        public static void sendData(CANData cd) {
            print("Warning: 'sendData' is obsoleted.\nUse 'transmitData' instead.");
            transmitData(cd);
        }

        public static void transmitData(CANData cd) {
            try {
                DriverManager.SendData(cd);
            } catch (NullReferenceException nullex) {
                JavascriptIDE.add("可能尚未初始化CAN收发器，去初始化一下！");
                Logger.logError(nullex);
            } catch (Exception e) {
                JavascriptIDE.add(e);
                Logger.logError(e);
            }
        }
        public static void sendData(int ID, int[] Data) {
            print("Warning: 'sendData' is obsoleted.\nUse 'transmitData' instead.");
            transmitData(ID, Data);
        }
        public static void transmitData(int ID, int[] Data) {
            try {
                sendData(CANData.getNewJS(ID, Data));
            } catch (Exception e) {
                JavascriptIDE.add(e);
                Logger.logError(e);
            }
        }

        //timeout:ms
        public static CANData waitMessageID(int ID, int timeout) {
            CANData cdGet = null;
            //向驱动管理器注册一个回调函数
            Action<CANData> actFun = new Action<CANData>((CANData cd) => {
                if (cd.ID == ID) {
                    cdGet = cd;
                }
            });
            DriverManager.PushCANDataProcessor(actFun);
            long tickTimeout = DateTime.Now.Ticks + timeout * 10000;
            while (DateTime.Now.Ticks < tickTimeout) {
                if (cdGet != null) {
                    DriverManager.PopCANDataProcessor();
                    return cdGet;
                } else {
                    Application.DoEvents();
                    Thread.Sleep(1);
                }
            }
            DriverManager.PopCANDataProcessor();
            throw new TimeoutException("Waiting on CAN time out!");
        }
        public static CANData waitMessage(CANData msg, int timeout) {
            CANData cdGet = null;
            //向驱动管理器注册一个回调函数
            Action<CANData> actFun = new Action<CANData>(
                (CANData cd) => {
                    if (cd.Equals(msg)) {
                        cdGet = cd;
                    }
                }
            );
            DriverManager.PushCANDataProcessor(actFun);
            long tickTimeout = DateTime.Now.Ticks + timeout * 10000;
            while (DateTime.Now.Ticks < tickTimeout) {
                if (cdGet != null) {
                    DriverManager.PopCANDataProcessor();
                    return cdGet;
                } else {
                    Application.DoEvents();
                    Thread.Sleep(1);
                }
            }
            DriverManager.PopCANDataProcessor();
            throw new TimeoutException("Waiting on CAN time out!");
        }
        //警告：函数这个函数是尚未测试的！不要使用
        public static void waitMessageUDF(
            string callbackFunctionName,
            string tempCANDataVariableName,
            string exitFlagExpression,
            int timeout) {
            //向驱动管理器注册一个C#回调函数
            Action<CANData> actFun = new Action<CANData>((CANData cd) => {
                JavaScriptEngine.getContext().SetParameter(
                    tempCANDataVariableName, cd);
                JavaScriptEngine.runCmd(string.Format("{0}({1})",callbackFunctionName,tempCANDataVariableName));

            });
            DriverManager.PushCANDataProcessor(actFun);
            long tickTimeout = DateTime.Now.Ticks + timeout * 10000;
            while (DateTime.Now.Ticks < tickTimeout) {
                if ((bool)JavaScriptEngine.getContext().Run(exitFlagExpression)) {
                    DriverManager.PopCANDataProcessor();
                    return;
                } else {
                    Application.DoEvents();
                    Thread.Sleep(1);
                }
            }
            DriverManager.PopCANDataProcessor();
            throw new TimeoutException("Waiting on CAN time out!");
        }
        public static TransmitThread newSendThread(CANData cd, int cycleTime) {
            print("Warning: 'newSendThread' is obsoleted.\nUse 'newTransmitThread' instead.");
            return new TransmitThread(cd, cycleTime);
        }
        public static TransmitThread newTransmitThread(CANData cd, int cycleTime) {
            return new TransmitThread(cd, cycleTime);
        }
        public static string inputbox(string title, string initString) {
            return InputBox.ShowInputBox(title, initString);
        }
        public static string inputbox(string title) {
            return inputbox(title, string.Empty);
        }
        public static string inputbox() {
            return inputbox("Javascript InputBox");
        }
        public static void appendFile(string filename, string text) {
            FileUtility.AppendFileUTF8(filename, text);
        }
        public static void writeFile(string filename, string text) {
            FileUtility.WriteFileUTF8(filename, text);
        }
        public static string readFile(string filename) {
            return FileUtility.ReadFileUTF8(filename);
        }
        public static void printParameter(string param) {
            object o = JavaScriptEngine.getContext().GetParameter(param);
            print("Type:  " + o.GetType());
            print("Value: " + o.ToString());
        }
    }
}
