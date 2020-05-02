using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using CANSignalControlPanel.Utilities;
using System.Text.RegularExpressions;
using CANSignalControlPanel.Forms;
using LogService;

namespace CANSignalControlPanel.Data {
    /// <summary>
    /// 导入配置文件的接口
    /// </summary>
    public interface IConfigureFileIO {
        ConfigureFile ReadConfigure(string filename);
        void WriteConfigure(ConfigureFile data, string filename);
    }
    /// <summary>
    /// 用于导入本程序的配置文件
    /// </summary>
    public class JSONConfigIO : IConfigureFileIO {
        public ConfigureFile ReadConfigure(string filename) {
            ConfigureFile rtn = new ConfigureFile();
            // TODO: Add code to read json file
            using (var ms = new FileStream(filename, FileMode.Open, FileAccess.Read)) {
                DataContractJsonSerializer deseralizer = new DataContractJsonSerializer(typeof(ConfigureFile));
                rtn = (ConfigureFile)deseralizer.ReadObject(ms);// 反序列化ReadObject
            }
            return rtn;
        }
        public void WriteConfigure(ConfigureFile data, string filename) {
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(ConfigureFile));
            FileStream msObj = new FileStream(filename, FileMode.Create);
            //将序列化之后的Json格式数据写入流中
            js.WriteObject(msObj, data);
            msObj.Close();
        }
    }

    // Implement your own format here
}