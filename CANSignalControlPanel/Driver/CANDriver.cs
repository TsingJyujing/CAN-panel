using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CANSignalControlPanel.Data;
using System.Threading;

namespace CANSignalControlPanel.Driver
{
    /// <summary>
    /// CAN Driver "Interface", implement it
    /// </summary>
    public abstract class CANDriver {
        /// <summary>
        /// Initialize device with attached args
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public abstract bool InitializeDevice(string[] args);
        public abstract bool FinalizeDevice();
        public abstract bool SendData(CANData data);

        /// <summary>
        /// Queue to save received data
        /// </summary>
        private Queue<CANData> RXQueue = new Queue<CANData>();
        public Queue<CANData> GetQueue() {
            return RXQueue;
        }

        /// <summary>
        /// Default filter function
        /// </summary>
        public Func<CANData, bool> FilterFunction = (CANData cd) => {
            return true;
        };

        /// <summary>
        /// Receive data and push it(them?) to Queue
        /// </summary>
        abstract protected void ReceiveData();
        CancellationTokenSource cts = null;
        public void StartRX() {
            cts = new CancellationTokenSource();
            new Task(ReceiveDataTask, cts.Token).Start();
        }
        public void StopRX() {
            cts.Cancel();
        }

        uint PushedCount = 0;
        
        protected void Push(CANData cd) {
            RXQueue.Enqueue(cd);
            PushedCount++;
        }
        protected CANData Pull() {
            return RXQueue.Dequeue();
        }
        private void ReceiveDataTask() {
            while (!cts.IsCancellationRequested) {
                PushedCount = 0;
                ReceiveData();
                if (PushedCount == 0) {
                    Thread.Sleep(1);
                }
            }
        }

    }
}
