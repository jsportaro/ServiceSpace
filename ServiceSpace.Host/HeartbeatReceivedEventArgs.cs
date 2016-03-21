using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSpace.Host
{
    public class HeartbeatReceivedEventArgs : EventArgs
    {
        public Heartbeat Heartbeat { get; set; }

        public HeartbeatReceivedEventArgs(Heartbeat heartbeat)
        {
            Heartbeat = heartbeat;
        }
    }
}
