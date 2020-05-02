using CANSignalControlPanel.Data;
using CANSignalControlPanel.Forms;
using CANSignalControlPanel.Utilities;
using LogService;
using Noesis.Javascript;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CANSignalControlPanel.Service {
    public class JavaScriptEngine {
        static JavascriptContext ctx;
       
        static JavaScriptEngine() {
            try {
                Logger.logInfo("正在为首次使用JavaScript引擎做初始化...");
                ctx = new JavascriptContext();
                //导入函数的js文件
                ctx.SetParameter("$", new JavaScriptUtility());
                runFile("js/init.js");
                Logger.logInfo("成功初始化JavaScript引擎");
            } catch (Exception e) {
                Logger.logError(e);
            }
        }

        public static object runFile(string filename) {
            return runCmd(FileUtility.ReadFileUTF8(filename));
        }

        public static object runCmd(string cmd) {
            return ctx.Run(cmd);
        }
        public static JavascriptContext getContext() {
            return ctx;
        }
        public static List<string> getFunctionList() {
            object[] jos;
            jos = (object[])runCmd("getFunctionNameList()");
            List<string> rtn = new List<string>();
            foreach (object jo in jos) {
                rtn.Add((string)jo);
            }
            return rtn;
        }
        
    }
}
