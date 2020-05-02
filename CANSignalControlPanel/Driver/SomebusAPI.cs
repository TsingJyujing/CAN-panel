using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace CANSignalControlPanel.Driver.Somebus {

    [Flags]
    public enum ECANStatus : uint {
        /// <summary>
        ///  error
        /// </summary>
        STATUS_ERR = 0x00000,
        /// <summary>
        /// No error
        /// </summary>
        STATUS_OK = 0x00001,
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CAN_OBJ {
        public uint ID;
        public uint TimeStamp;
        public byte TimeFlag;
        public byte SendType;
        public byte RemoteFlag;
        public byte ExternFlag;
        public byte DataLen;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] data;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] Reserved;
    }

    public struct CAN_ERR_INFO {
        public uint ErrCode;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] Passive_ErrData;
        public byte ArLost_ErrData;

    }


    /*
 

    public struct CAN_OBJ
    {


        public uint ID;
      
        public uint TimeStamp;
        public byte TimeFlag;
        public byte RemoteFlag;
        public byte ExternFlag; 


        public byte DataLen;
 
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] data;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] Reserved;
    

    }
    */

    public struct INIT_CONFIG {

        public uint AccCode;
        public uint AccMask;
        public uint Reserved;
        public byte Filter;
        public byte Timing0;
        public byte Timing1;
        public byte Mode;



    }


    public static class ECANDLL {

        [DllImport("ECANVCI.dll", EntryPoint = "OpenDevice")]
        public static extern ECANStatus OpenDevice(
            UInt32 DeviceType,
            UInt32 DeviceInd,
            UInt32 Reserved);

        [DllImport("ECANVCI.dll", EntryPoint = "CloseDevice")]
        public static extern ECANStatus CloseDevice(
            UInt32 DeviceType,
            UInt32 DeviceInd);


        [DllImport("ECANVCI.dll", EntryPoint = "InitCAN")]
        public static extern ECANStatus InitCAN(
            UInt32 DeviceType,
            UInt32 DeviceInd,
            UInt32 CANInd,
            ref INIT_CONFIG InitConfig);


        [DllImport("ECANVCI.dll", EntryPoint = "StartCAN")]
        public static extern ECANStatus StartCAN(
            UInt32 DeviceType,
            UInt32 DeviceInd,
            UInt32 CANInd);


        [DllImport("ECANVCI.dll", EntryPoint = "ResetCAN")]
        public static extern ECANStatus ResetCAN(
            UInt32 DeviceType,
            UInt32 DeviceInd,
            UInt32 CANInd);


        [DllImport("ECANVCI.dll", EntryPoint = "Transmit")]
        public static extern ECANStatus Transmit(
            UInt32 DeviceType,
            UInt32 DeviceInd,
            UInt32 CANInd,
            ref CAN_OBJ Send,
            UInt16 length);

        [DllImport("ECANVCI.dll", EntryPoint = "ClearBuffer")]
        public static extern uint ClearBuffer(
            UInt32 DeviceType,
            UInt32 DeviceInd,
            UInt32 Reserved);

        [DllImport("ECANVCI.dll", EntryPoint = "GetReceiveNum")]
        public static extern long GetReceiveNum(
            UInt32 DeviceType,
            UInt32 DeviceInd,
            UInt32 Reserved);

        [DllImport("ECANVCI.dll", EntryPoint = "Receive")]
        public static extern ECANStatus Receive(
            UInt32 DeviceType,
            UInt32 DeviceInd,
            UInt32 CANInd,
            ref CAN_OBJ Receive,
            UInt32 length,
            UInt32 WaitTime);

        [DllImport("ECANVCI.dll", EntryPoint = "ReadErrInfo")]
        public static extern ECANStatus ReadErrInfo(
            UInt32 DeviceType,
            UInt32 DeviceInd,
            UInt32 CANInd,
            out CAN_ERR_INFO ReadErrInfo);
    }
}
