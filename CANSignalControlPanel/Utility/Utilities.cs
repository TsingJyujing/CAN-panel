using CANSignalControlPanel.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CANSignalControlPanel.Forms;

namespace CANSignalControlPanel.Utilities {
    public class ByteUtility {
        public static byte[] UInt64ToByte(UInt64 data) {
            byte[] src = new byte[8];
            for (int i = 0; i < 8; i++) {
                src[i] = (byte)((data >> (int)(i * 8)) & 0xFF);
            }
            return src;
        }
        public static UInt64 getUInt64Segment(UInt64 data, int startBit, int endBit) {
            int bitLength = endBit - startBit;
            UInt64 mask = ((UInt64)Math.Pow(2, bitLength) - 1) << startBit;
            data &= mask;
            data >>= startBit;
            return data;
        }
        public static UInt64 ByteToUInt64(byte[] data) {
            UInt64 returnValue = 0x0;
            int dataLen = Math.Min(data.Length, 8);
            for (int i = 0; i < dataLen; i++) {
                returnValue |= ((ulong)data[i]) << (8 * i);
            }
            return returnValue;
        }
        public static string bytes2string(byte[] arr) {
            string[] strs = new string[arr.Length];
            for (int i = 0; i < arr.Length; i++) {
                strs[i] = arr[i].ToString();
            }
            return string.Join(",",strs);
        }
        public static byte[] string2bytes(string bytes) {
            string[] strs = bytes.Split(",".ToArray());
            byte[] rtn = new byte[strs.Length];
            for (int i = 0; i < strs.Length; i++) {
                rtn[i] = byte.Parse(strs[i]);
            }
            return rtn;
        }
    }
    public class Utility
    {
        public static bool MsgBoxQuery(string queryInfo, string title) {
            return MessageBox.Show(queryInfo, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes;
        }
        public static void MsgBox(string queryInfo, string title) {
            MessageBox.Show(queryInfo, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void MsgBox(string queryInfo) {
            MsgBox(queryInfo,"");
        }
        public static string removeLineChange(string strIn) {
            return strIn.Replace("\r", "").Replace("\n", "");
        }
    }
    
    
}
