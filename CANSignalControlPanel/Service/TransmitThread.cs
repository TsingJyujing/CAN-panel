using CANSignalControlPanel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CANSignalControlPanel.Service {
    public class TransmitThread {
        CancellationTokenSource cts;
        TransmitData sd = new TransmitData();
        public TransmitThread(CANData cd, int cycleTime) {
            sd.data = cd;
            sd.cycle = cycleTime;
        }
        public void start() {
            cts = new CancellationTokenSource();
            new Task(new Action(() => {
                while (!cts.IsCancellationRequested) {
                    if (DriverManager.IsInitialized) {
                        long nowTicks = DateTime.Now.Ticks;
                        if (sd.isSend(nowTicks)) {
                            DriverManager.Driver.SendData(sd.data);
                            sd.lastTickms = nowTicks;
                        }
                    }
                    Thread.Sleep(1);
                }
            }), cts.Token).Start();
        }

        public void stop() {
            cts.Cancel();
        }
    }
}
