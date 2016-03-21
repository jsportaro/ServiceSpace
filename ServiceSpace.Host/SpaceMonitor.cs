using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSpace.Host
{
    public class SpaceMonitor
    {
        private readonly IHeartbeatTransport heartbeatTransport;
        private readonly Dictionary<Guid, SpaceState> spaceStates = new Dictionary<Guid, SpaceState>();

        public SpaceMonitor(IHeartbeatTransport heartbeatTransport)
        {
            this.heartbeatTransport = heartbeatTransport;

            this.heartbeatTransport.HeartbeatReceived += HeartbeatTransport_HeartbeatReceived;
        }

        private void HeartbeatTransport_HeartbeatReceived(object sender, HeartbeatReceivedEventArgs e)
        {
            spaceStates[e.Heartbeat.HostId] = new SpaceState(e.Heartbeat);
        }
    }
}
