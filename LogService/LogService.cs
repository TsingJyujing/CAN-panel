using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LogService {
    public enum logLevel {
        All = 0x00,
        None = 0xFF,
        Trace = 0x10,
        Debug = 0x11,
        Infomation = 0x12,
        Warning = 0x13,
        Error = 0x14,
        Fatal = 0x15,
    }
    public class Logger {
        private static FrmLogging wndDebug;
        public static logLevel levelControl = logLevel.All;
        private static FileStream fs;
        static Logger() {
            fs = File.OpenWrite("debug.log");
            //设定书写的开始位置为文件的末尾  
            fs.Position = fs.Length;
            wndDebug = new FrmLogging();
            wndDebug.Show();
            wndDebug.Hide();
        }
        public static void show() {
            wndDebug.BeginInvoke(new Action(() => {
                wndDebug.Show();
            }));
        }
        public static void hide() {
            wndDebug.BeginInvoke(new Action(() => {
                wndDebug.Hide();
            }));
        }
        public static void clear() {
            wndDebug.listClear();
        }
        public static void print(string info) {
            wndDebug.listAddItem(info);
        }
        public static void close() {
            wndDebug.avoidClose = false;
            wndDebug.Close();
        }
        public static void logUDF(string message, string userDefineInfo) {
            string printInfo = "[" + DateTime.Now.ToString() + "]\t["
                + userDefineInfo + "]\t" + message;
            print(printInfo);
            //Append to debug.log
            AppendFileUTF8(printInfo + "\r\n");
        }
        private static void AppendFileUTF8(string Text) {
            byte[] bytes = Encoding.UTF8.GetBytes(Text);
            try {
                //将待写入内容追加到文件末尾  
                fs.Write(bytes, 0, bytes.Length);
                fs.Flush();
            } catch (Exception ex) {
                print("Error while saving log file:" + ex.Message);
            }
        }
        public static void logError(string info) {
            if (levelControl <= logLevel.Error) {
                logUDF(info, "ERROR");
            }
        }
        public static void logError(Exception ex) {
            logError(getDetailMessage(ex));
        }
        public static void logWarn(string info) {
            if (levelControl <= logLevel.Warning) {
                logUDF(info, "WARN");
            }
        }
        public static void logWarn(Exception ex) {
            logWarn(getDetailMessage(ex));
        }
        public static void logInfo(string info) {
            if (levelControl <= logLevel.Infomation) {
                logUDF(info, "INFO");
            }
        }
        public static void logInfo(Exception ex) {
            logInfo(getDetailMessage(ex));
        }
        public static void logDebug(string info) {
            if (levelControl <= logLevel.Debug) {
                logUDF(info, "DEBUG");
            }
        }
        public static void logDebug(Exception ex) {
            logDebug(getDetailMessage(ex));
        }
        public static void logTrace(string info) {
            if (levelControl <= logLevel.Trace) {
                logUDF(info, "TRACE");
            }
        }
        public static void logTrace(Exception ex) {
            logTrace(getDetailMessage(ex));
        }
        public static void logFatal(string info) {
            if (levelControl <= logLevel.Trace) {
                logUDF(info, "FATAL");
            }
            MessageBox.Show(info, "FATAL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //Exit
        }
        public static void logFatal(Exception ex) {
            logFatal(getDetailMessage(ex));
        }
        private static string getDetailMessage(Exception ex) {
            StringBuilder sb = new StringBuilder();
            sb.Append("\nMessag:");
            sb.Append(ex.Message);
            sb.Append(" ");
            sb.Append("\nSource:");
            sb.Append(ex.Source);
            sb.Append(" ");
            sb.Append("\nException Type:");
            sb.Append(ex.GetType());
            sb.Append(" ");
            sb.Append("\nStack Trace:");
            sb.Append(ex.StackTrace);
            return sb.ToString();
        }
    }
}
