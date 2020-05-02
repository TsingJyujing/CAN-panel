using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
/*
 * CANData.cs 用于容纳CAN的收发的数据容器
 */
namespace CANSignalControlPanel.Data {

    /*
     * @Author: Yuanyifan
     * @Create: 2017-5-6
     * 
     * Send data by cycle manage unit
     */
    public class TransmitData {
        public CANData data;
        public long cycle;//发送周期（单位ms）
        public long lastTickms;//上次发送的时间（单位ms）
        public bool isSend(long nowTickms) {
            return (nowTickms - lastTickms) >= cycle;
        }
        public TransmitData() {
        }
        public TransmitData(CANData cd, int cycleMills) {
            this.data = cd;
            this.cycle = (long)cycleMills;
        }
    }

    /*
     * @Author: Yuanyifan
     * @Create: 2017-5-6
     * 
     * Storage CAN data on vehicle
     * Default not remote frame but data frame
     * Default extend frame
     * Default arbitration ID 29 bit
     */
    public class CANData {
        #region Variables
        public int ID { get; set; }
        public DateTime ActionTime { get; set; }
        byte[] Data;
        #endregion

        #region RawAPIs
        /*
         * @author yuanyifan
         * @create 2017-5-6
         * print can data as string format
         */
        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.Append(ActionTime.ToString("yyyy-MM-dd HH:mm:ss:") + ActionTime.Millisecond.ToString("D3"));
            sb.Append(string.Format(" 0x{0:X8} ", ID));
            if (Data.Length > 0) {
                sb.Append(string.Format("{0:X2}", Data[0]));
                for (int i = 1; i < Data.Length; i++) {
                    sb.Append(string.Format(",{0:X2}", Data[i]));
                }
            }
            return sb.ToString();
        }

        public string ToCSV() {
            StringBuilder sb = new StringBuilder();
            sb.Append(ActionTime.ToString("yyyy-MM-dd HH:mm:ss:") + ActionTime.Millisecond.ToString("D3"));
            sb.Append(string.Format(",0x{0:X8},", ID));
            if (Data.Length > 0) {
                sb.Append(string.Format("{0:X2}", Data[0]));
                for (int i = 1; i < Data.Length; i++) {
                    sb.Append(string.Format(",{0:X2}", Data[i]));
                }
            }
            return sb.ToString();
        }
        //Get size of data
        public int getDataLen() {
            return Data.Length;
        }
        //Init can without data
        public CANData() {
            ID = 0x00;
            Data = new byte[8];
            ActionTime = DateTime.Now;
        }
        //Init can with data
        public CANData(int inID, byte[] inData) {
            ID = inID;
            SetData(inData);
            ActionTime = DateTime.Now;
        }

        //Set can data by input byte array
        public void SetData(byte[] inData) {
            int sizeOfData = (UInt16)inData.Length;
            Data = new Byte[sizeOfData];
            for (int i = 0; i < sizeOfData; ++i) {
                Data[i] = inData[i];
            }
        }
        public void SetData(int index, byte inData) {
            if (index >= 0 && index < Data.Length) {
                Data[index] = inData;
            } else {
                throw new Exception("Set CAN data index out of range.");
            }
        }
        //create a new byte array to return value
        public byte[] GetData() {
            int sizeOfData = getDataLen();
            byte[] outData = new Byte[sizeOfData];
            for (int i = 0; i < sizeOfData; ++i) {
                outData[i] = Data[i];
            }
            return outData;
        }

        //get data position
        public byte GetData(int i) {
            if (i >= 0 && i < Data.Length) {
                return Data[i];
            } else {
                throw new Exception("Get CAN data index out of range.");
            }
        }

        // Operate OR on each data
        public static CANData operator |(CANData d1, CANData d2) {
            int dlen = d1.getDataLen();
            if (dlen != d2.getDataLen() && d1.ID != d2.ID) {
                throw new Exception("Can't make OR operation in two byte array in different size or ID.");
            } else {
                byte[] src = new byte[dlen];
                byte[] s1 = d1.GetData();
                byte[] s2 = d2.GetData();
                CANData cdrtn = new CANData();
                cdrtn.ID = d1.ID;
                for (int i = 0; i < dlen; i++) {
                    src[i] = (byte)(s1[i] | s2[i]);
                }
                cdrtn.SetData(src);
                return cdrtn;
            }
        }
        // Operate AND on each data
        public static CANData operator &(CANData d1, CANData d2) {
            int dlen = d1.getDataLen();
            if (dlen != d2.getDataLen() && d1.ID != d2.ID) {
                throw new Exception("Can't make OR operation in two byte array in different size or ID.");
            } else {
                byte[] src = new byte[dlen];
                byte[] s1 = d1.GetData();
                byte[] s2 = d2.GetData();
                CANData cdrtn = new CANData();
                cdrtn.ID = d1.ID;
                for (int i = 0; i < dlen; i++) {
                    src[i] = (byte)(s1[i] & s2[i]);
                }
                cdrtn.SetData(src);
                return cdrtn;
            }
        }
        // Operate NOT on each data
        public static CANData operator ~(CANData cd) {
            CANData cdrtn = new CANData(cd.ID, cd.Data);
            int invSize = cdrtn.getDataLen();
            for (int i = 0; i < invSize; i++) {
                cdrtn.SetData(i, (byte)~cdrtn.GetData(i));
            }
            return cdrtn;
        }
        // Operate NOT on each data
        public override bool Equals(object obj) {
            if (!this.GetType().Equals(obj.GetType())) {
                return false;
            }
            CANData cdobj = (CANData)obj;
            if (this.ID != cdobj.ID) {
                return false;
            }
            if (this.getDataLen() != cdobj.getDataLen()) {
                return false;
            }
            int cmpSize = this.getDataLen();
            for (int i = 0; i < cmpSize; i++) {
                if (this.GetData(i) != cdobj.GetData(i)) {
                    return false;
                }
            }
            return true;
        }
        public override int GetHashCode() {
            return (int)ID;
        }

        #endregion

        #region JSAPIs
        /*
         * Functions below are prepared for javascript call only
         * done call this function in C# and use more safty code instead
         */
        public void SetDataJS(int index, int inData) {
            if (!(inData >= 0 && inData <= 255)) {
                throw new Exception("Data not in range.");
            }
            if (!(index >= 0 && index < Data.Length)) {
                throw new IndexOutOfRangeException("Set CAN data index out of range.");
            }
            Data[index] = (byte)inData;
        }
        public void SetDataJS(int[] inData) {
            int sizeOfData = (UInt16)inData.Length;
            Data = new Byte[sizeOfData];
            for (int i = 0; i < sizeOfData; ++i) {
                Data[i] = (byte)inData[i];
            }
        }
        //For js us only
        public static CANData getNewJS(int initID, int[] initData) {
            CANData cd = new CANData();
            cd.ID = initID;
            cd.SetDataJS(initData);
            return cd;
        }
        #endregion
    }
}
