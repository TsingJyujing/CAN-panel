using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using CANSignalControlPanel.Utilities;
using CANSignalControlPanel.Service;
using System.IO;

namespace CANSignalControlPanel.Data {
    /// <summary>
    /// Signal type, now support:
    ///     Continuous: Describe a real number
    ///     Discreate: Give a explain for each value
    ///     DM1 Fault Code: As is explains
    ///     Switch: 4 status switch in CAN protocal
    ///     UserDefined: Defined by some Javascript function
    /// </summary>
    public enum SignalType {
        Continuous = 0x00,
        Discrete = 0x01,
        DM1FaultCode = 0x02,
        Switch = 0x03,
        UserDefined = 0x04,
    }
    /// <summary>
    /// Enum the mask type (how to fill empty bytes)
    /// </summary>
    public enum MaskType {
        Mask0 = 0x00,
        Mask1 = 0x01//Default
    }

     /// <summary>
     /// The Class to Describe CAN BUS Data
     /// Also used to generate CANData class
     /// </summary>
    [DataContract]
    public class CANMessage {
        /// <summary>
        /// Message name
        /// </summary>
        [DataMember]
        public string Name = "DefaultMessageName";

        /// <summary>
        /// Message ID
        /// </summary>
        [DataMember]
        public int ID = 0x00;

        /// <summary>
        /// Message send period time
        /// </summary>
        [DataMember]
        public int TxPeriod = 1000;//送信周期

        /// <summary>
        /// The signal contains in this CAN Type
        /// </summary>
        [DataMember]
        List<CANSignal> SignalList = new List<CANSignal>();//信号列表

        public List<CANSignal> GetSignalList() {
            return SignalList;
        }
        public override string ToString() {
            return string.Format("ID=0x{1:X8} ({0}) T={2}ms", Name, ID, TxPeriod);
        }
        /// <summary>
        /// Contribute the CAN Message
        /// </summary>
        /// <param name="MessageMaskType">Mask 0 or 1</param>
        /// <returns></returns>
        public byte[] BuildMessage(MaskType MessageMaskType) {
            ulong CANLongData = 0;
            if (MessageMaskType == MaskType.Mask0) {
                foreach (CANSignal singal in SignalList) {
                    CANLongData |= singal.encodeLong(MaskType.Mask0);
                }
            } else {
                CANLongData = ulong.MaxValue;
                foreach (CANSignal singal in SignalList) {
                    CANLongData &= singal.encodeLong(MaskType.Mask1);
                }
            }
            return ByteUtility.UInt64ToByte(CANLongData);
        }

    }

    /// <summary>
    /// The class to describe the CAN signal
    /// </summary>
    [DataContract]
    public class CANSignal {
        #region static
        /// <summary>
        /// Encode DM1 fault code object
        /// </summary>
        /// <param name="DM1FaultCode"></param>
        /// <returns></returns>
        public static ulong EncodeDM1(DM1Value DM1FaultCode) {
            uint b5 = DM1FaultCode.SPN >> 16;
            b5 = (b5 << 5) | DM1FaultCode.FMI;
            return (DM1FaultCode.SPN & 0xffff) | (b5 << 16);
        }
        /// <summary>
        /// Get offset by startByte and bit
        /// </summary>
        /// <param name="StartByte"></param>
        /// <param name="StartBit"></param>
        /// <returns></returns>
        public static int GetBitOffset(int StartByte, int StartBit) {
            return StartByte * 8 + StartBit;
        }


        public static Tuple<int, int> GetBitConfigure(int Offset) {
            int ByteOffset = Offset / 8;
            int BitOffset = Offset - ByteOffset * 8;
            return new Tuple<int, int>(ByteOffset, BitOffset);
        }
        /// <summary>
        /// Four status of switch type
        /// </summary>
        public static string[] SwitchMap = new string[] { "Off", "On", "Error", "Disabled" };
        public static void BitSizeOffsetValidCheck(int BitOffset, int BitSize) {
            if (BitSize <= 0) {
                throw new Exception("Bit size is too small(<=0).");
            } else if (BitSize > 64) {
                throw new Exception("Bit size is too large(>64).");
            } else if (BitOffset < 0) {
                throw new Exception("Bit Offset is too small(<0).");
            } else if (BitOffset >= 64) {
                throw new Exception("Bit Offset is too large(>=64).");
            } else if ((BitOffset + BitSize) > 64) {
                throw new Exception("Signal overflow ((BitOffset+BitOffset)>=64).");
            }
        }
        #endregion
        #region variables
        [DataMember]
        public string Name = "DefaultName";
        [DataMember]
        public SignalType sType = SignalType.Continuous;
        //Setting
        [DataMember]
        public int BitOffset = 0;
        [DataMember]
        public int BitSize = 64;
        public ulong MinValue{
            get{
                return 0;
            }
        }
        public ulong MaxValue{
            get {
                return (ulong)(Math.Pow(2, BitSize) - 1);
            }
        }
        [DataMember]
        ulong DefaultCANValue;
        //属性默认值的get和set方法
        public ulong DefaultValue {
            get {
                return DefaultCANValue;
            }
            set {
                ulong maxValue = (ulong)(Math.Pow(2, BitSize) - 1);
                if (value < 0) {
                    DefaultCANValue = 0;
                } else if (value > maxValue) {
                    DefaultCANValue = maxValue;
                } else {
                    DefaultCANValue = value;
                }
            }
        }
        /// <summary>
        /// Continues scale and offset value
        /// </summary>
        [DataMember]
        public double cOffset = 0;
        [DataMember]
        public double cRatio = 1;


        /// <summary>
        /// Discrete table
        /// </summary>
        [DataMember]
        Dictionary<ulong, string> DiscreteDecodeTable = new Dictionary<ulong, string>();
            
        public Dictionary<ulong, string> GetDecodeTable() {
            return DiscreteDecodeTable;
        }
        /// <summary>
        /// User-defined function name
        /// </summary>
        [DataMember]
        public string UDFName = "";

        #endregion

        #region initialize
        /// <summary>
        /// 新建一个指定量
        /// </summary>
        /// <param name="st"></param>
        public CANSignal(SignalType st) {
            sType = st;
            BitSize = 64;
            BitOffset = 0;
            switch (st) {
            case SignalType.Continuous:
                break;
            case SignalType.Discrete:
                break;
            case SignalType.DM1FaultCode:
                BitSize = 24;
                BitOffset = 16;
                break;
            case SignalType.Switch:
                BitSize = 2;
                break;
            case SignalType.UserDefined:
                UDFName = "returnRaw";
                break;
            default:
                return;
            }
        }

        /// <summary>
        /// 新建一个连续量
        /// </summary>
        /// <param name="signame"></param>
        /// <param name="bitoffset"></param>
        /// <param name="bitsize"></param>
        /// <param name="ratio"></param>
        /// <param name="offset"></param>
        public CANSignal(string signame, int bitoffset, int bitsize, double ratio, double offset) {
            BitSizeOffsetValidCheck(bitoffset, bitsize);
            sType = SignalType.Continuous;
            BitOffset = bitoffset;
            BitSize = bitsize;
            cRatio = ratio;
            cOffset = offset;
            Name = signame;
        }
        /// <summary>
        /// 新建一个离散量
        /// </summary>
        /// <param name="signame"></param>
        /// <param name="bitoffset"></param>
        /// <param name="bitsize"></param>
        /// <param name="dict"></param>
        public CANSignal(string signame, int bitoffset, int bitsize, Dictionary<ulong, string> dict) {
            BitSizeOffsetValidCheck(bitoffset, bitsize);
            sType = SignalType.Discrete;
            BitOffset = bitoffset;
            BitSize = bitsize;
            foreach (ulong key in dict.Keys) {
                DiscreteDecodeTable[key] = dict[key];
            }
            Name = signame;
        }
        /// <summary>
        /// 新建一个开关量
        /// </summary>
        /// <param name="signame"></param>
        /// <param name="bitoffset"></param>
        public CANSignal(string signame, int bitoffset) {
            BitSizeOffsetValidCheck(bitoffset, 2);
            sType = SignalType.Switch;
            BitOffset = bitoffset;
            BitSize = 2;
            Name = signame;
        }
        /// <summary>
        /// 新建一个DM1故障码
        /// </summary>
        /// <param name="signame"></param>
        public CANSignal(string signame) {
            sType = SignalType.DM1FaultCode;
            BitOffset = 16;
            BitSize = 24;
            Name = signame;
        }
        #endregion
        #region functions
        //解码CAN信号
        public object DecodeCANMessage(byte[] Data) {
            return DecodeCANMessage(BytesToInt(Data));
        }
        public ulong BytesToInt(byte[] Data) {
            return ByteUtility.getUInt64Segment(
                ByteUtility.ByteToUInt64(Data),
                (int)(BitOffset), (int)(BitOffset + BitSize)
            );
        }
        public object DecodeCANMessage() {
            return DecodeCANMessage(DefaultValue);
        }
        public object DecodeCANMessage(ulong signalValue) {
            switch (sType) {
            //连续值解析
            case SignalType.Continuous:
                double value = signalValue;
                value *= cRatio;
                value += cOffset;
                return value;
            //离散值解析
            case SignalType.Discrete:
                return DiscreteDecodeTable.ContainsKey(signalValue) ? DiscreteDecodeTable[signalValue] : string.Format("Undef:{0}", signalValue);
            //开关量解析
            case SignalType.Switch:
                return SwitchMap[signalValue];
            //DM1故障码
            case SignalType.DM1FaultCode:
                DM1Value dm1Obj = new DM1Value() {
                    FMI = (uint)(signalValue >> 16 & 0x1F),
                    SPN = (uint)(signalValue >> 21 & 7 << 16 | (signalValue & 0xFFFF))
                };
                return dm1Obj;
            case SignalType.UserDefined:
                //用匿名函数的形式描述解析器（少用）
                //JS: function(var_ulong_value){...}
                return JavaScriptEngine.runCmd(string.Format("{0}({1})", UDFName, signalValue));
            default:
                throw new Exception("Undefined signal type, please check your code:" + sType.ToString());
            }
        }
        /// <summary>
        /// 将CAN信号编码成_uint64，使用输入的数值
        /// </summary>
        /// <param name="value"></param>
        /// <param name="maskMode"></param>
        /// <returns></returns>
        public ulong encodeLong(ulong value, MaskType maskMode) {
            if (maskMode == MaskType.Mask0) {
                return (value << BitOffset) & generateMask();
            } else {
                return (value << BitOffset) | (~generateMask());
            }
        }
        /// <summary>
        /// 将CAN信号编码成_uint64，使用默认的数值
        /// </summary>
        /// <param name="maskMode"></param>
        /// <returns></returns>
        public ulong encodeLong(MaskType maskMode) {
            if (maskMode == MaskType.Mask0) {
                return (DefaultValue << BitOffset) & generateMask();
            } else {
                return (DefaultValue << BitOffset) | (~generateMask());
            }
        }
        /// <summary>
        /// 将CAN信号编码成byte[8]，使用输入的数值
        /// </summary>
        /// <param name="value"></param>
        /// <param name="maskMode"></param>
        /// <returns></returns>
        public byte[] encode(ulong value, MaskType maskMode) {
            return ByteUtility.UInt64ToByte(encodeLong(value, maskMode));
        }
        /// <summary>
        /// 将CAN信号编码成byte[8]，使用默认的数值
        /// </summary>
        /// <param name="maskMode"></param>
        /// <returns></returns>
        public byte[] encode(MaskType maskMode) {
            return ByteUtility.UInt64ToByte(encodeLong(maskMode));
        }
        /// <summary>
        /// 生成对应Bit的Mask
        /// </summary>
        /// <returns></returns>
        private ulong generateMask() {
            ulong ones = (ulong)Math.Pow(2, BitSize) - 1;
            ones <<= BitOffset;
            return ones;
        }
        /// <summary>
        /// 输出信号的配置信息
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            return string.Format("{0} Offset={1} Size={2} Type={3}", Name, BitOffset, BitSize,sType.ToString());
        }
        #endregion
    }

    /// <summary>
    /// DM1 Fault Code
    /// </summary>
    [DataContract]
    public class DM1Value {
        [DataMember]
        public uint SPN { get; set; }
        [DataMember]
        public uint FMI { get; set; }

        public override string ToString() {
            return string.Format("SPN:{0} FMI:{1}", SPN, FMI);
        }
    }

    [DataContract]
    public class ConfigureFile {
        [DataMember]
        Dictionary<int, CANMessage> CANMessageDictionary
            = new Dictionary<int, CANMessage>();
        public List<CANMessage> GetMessage() {
            return CANMessageDictionary.Values.ToList();
        }
        [DataMember]
        public string UserDefinedScript = "function returnRaw(data){return data;};";// 用户定义的脚本
        public void ClearAllMessage() {
            CANMessageDictionary.Clear();
        }
        public void AppendMessage(CANMessage msg) {
            if (CANMessageDictionary.ContainsKey(msg.ID)) {
                throw new Exception("This message existed in list.");
            } else {
                CANMessageDictionary[msg.ID] = msg;
            }
        }
        public void RemoveMessage(int CANID) {
            if (CANMessageDictionary.ContainsKey(CANID)) {
                CANMessageDictionary.Remove(CANID);
            } else {
                throw new Exception("This message hasn't appended to list.");
            }
        }

        public void AppendSignal(int CANID, CANSignal cs) {
            if (!CANMessageDictionary.ContainsKey(CANID)) {
                CANMessageDictionary[CANID] = new CANMessage() {
                    ID = CANID
                };
            }
            CANMessageDictionary[CANID].GetSignalList().Add(cs);
        }
        public void RemoveSignal(int CANID, CANSignal cs) {
            CANMessageDictionary[CANID].GetSignalList().Remove(cs);
        }
        public string ToJSON() {
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(ConfigureFile));
            MemoryStream msObj = new MemoryStream();
            //将序列化之后的Json格式数据写入流中
            js.WriteObject(msObj, this);
            msObj.Position = 0;
            //从0这个位置开始读取流中的数据
            StreamReader sr = new StreamReader(msObj, Encoding.UTF8);
            string json = sr.ReadToEnd();
            sr.Close();
            msObj.Close();
            return json;
        }

        public static ConfigureFile FromJSON(string jsonObj) {
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(jsonObj))) {
                DataContractJsonSerializer deseralizer =
                    new DataContractJsonSerializer(
                        typeof(ConfigureFile));
                ConfigureFile model = (ConfigureFile)deseralizer.ReadObject(ms);// 反序列化ReadObject
                return model;
            }
        }
    }
}
