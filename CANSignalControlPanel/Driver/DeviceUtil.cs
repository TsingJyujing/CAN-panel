using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CANSignalControlPanel.Driver {
    static class DeviceUtil {
        /// <summary>
        /// Some device will have more than one channel
        /// You can use this function to let user select
        /// </summary>
        /// <param name="minVal"></param>
        /// <param name="maxVal"></param>
        /// <param name="comment"></param>
        /// <returns></returns>
        public static uint SelectSubDeviceByIndex(uint minVal, uint maxVal, string comment) {
            FrmDeviceSelect PopFrm = new FrmDeviceSelect();
            List<string> infoList = new List<string>();
            for (uint i = minVal; i <= maxVal; i++) {
                infoList.Add(comment + " No." + i.ToString());
            }
            PopFrm.LoadDeviceList(infoList);
            PopFrm.SetTitle("请选择" + comment);
            PopFrm.ShowDialog();
            uint returnValue = (uint)(PopFrm.selectedIndex + minVal);
            PopFrm.Dispose();
            return returnValue;
        }
    }
}
