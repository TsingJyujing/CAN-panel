using LogService;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CANSignalControlPanel.Utilities {
    public class FileUtility {
        public static void AppendFileUTF8(string FileName, string Text) {
            FileStream fs;
            fs = File.OpenWrite(FileName);
            try {
                //设定书写的开始位置为文件的末尾  
                fs.Position = fs.Length;
                byte[] bytes = Encoding.UTF8.GetBytes(Text);
                //将待写入内容追加到文件末尾  
                fs.Write(bytes, 0, bytes.Length);
            } catch (Exception ex) {
                Logger.logError(ex);
            } finally {
                fs.Close();
            }
        }
        public static bool WriteFileUTF8(string FileName, string Text) {
            try {
                byte[] myByte = Encoding.UTF8.GetBytes(Text);
                using (FileStream fsWrite = new FileStream(FileName, FileMode.Create)) {
                    fsWrite.Write(myByte, 0, myByte.Length);
                };
                return true;
            } catch (Exception e) {
                Logger.logError("writting(utf-8) " + FileName + " Msg:" + e.Message);
                return false;
            }
        }
        public static bool WriteFileDefault(string FileName, string Text) {
            try {
                byte[] myByte = Encoding.Default.GetBytes(Text);
                using (FileStream fsWrite = new FileStream(FileName, FileMode.Create)) {
                    fsWrite.Write(myByte, 0, myByte.Length);
                };
                return true;
            } catch (Exception e) {
                Logger.logError("reading(ansi) " + FileName + " Msg:" + e.Message);
                return false;
            }
        }
        public static string ReadFileDefault(string FileName) {
            try {
                using (FileStream fsRead = new FileStream(FileName, FileMode.Open, FileAccess.Read)) {
                    int fileSize = (int)fsRead.Length;
                    byte[] dataArray = new byte[fileSize];
                    fsRead.Read(dataArray, 0, fileSize);
                    return System.Text.Encoding.Default.GetString(dataArray);
                };
            } catch (Exception e) {
                Logger.logError("reading(ansi) " + FileName + " Msg:" + e.Message);
                return "";
            }
        }
        public static string ReadFileUTF8(string FileName) {
            try {
                using (FileStream fsRead = new FileStream(FileName, FileMode.Open, FileAccess.Read)) {
                    int fileSize = (int)fsRead.Length;
                    byte[] dataArray = new byte[fileSize];
                    fsRead.Read(dataArray, 0, fileSize);
                    return System.Text.Encoding.UTF8.GetString(dataArray);
                };
            } catch (Exception e) {
                Logger.logError("reading(utf-8) " + FileName + " Msg:" + e.Message);
                return "";
            }
        }
        /*
        注：
        section：要读取的段落名
        key: 要读取的键
        defVal: 读取异常的情况下的缺省值
        retVal: key所对应的值，如果该key不存在则返回空值
        size: 值允许的大小
        filePath: INI文件的完整路径和文件名
         */
        [DllImport("kernel32")]
        public static extern int GetPrivateProfileString(
            string section, string key, string defVal,
            StringBuilder retVal, int size, string filePath);
        /*
        注：
        section: 要写入的段落名
        key: 要写入的键，如果该key存在则覆盖写入
        val: key所对应的值
        filePath: INI文件的完整路径和文件名
        */
        [DllImport("kernel32")]
        public static extern long WritePrivateProfileString(
            string section, string key, string val, string filePath);
        public static string GetPrivateProfileString(string section, string key, string defaultValue, string filePath) {
            StringBuilder sb = new StringBuilder(2048);
            GetPrivateProfileString(
            section, key, defaultValue, sb, 2048, filePath);
            return sb.ToString();
        }
    }
}
