using ServiceSpace.Host.Common;
using ServiceSpace.Host.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSpace.Host
{
    public class Entry
    {
        private static Guid HostId;

        public static void Main()
        {
            HostId = Guid.NewGuid();

            var heartBeatTransport = new MulticastHeartbeatTransport(new MulticastBroadcastTransport(new JsonSerializer()));

            heartBeatTransport.HeartbeatReceived += HeartBeatTransport_HeartbeatReceived;
            heartBeatTransport.Start(HostId);
            Console.Read();
        }

        private static void HeartBeatTransport_HeartbeatReceived(object sender, HeartbeatReceivedEventArgs e)
        {
            Console.WriteLine($"Received heartbeat from {e.Heartbeat.HostId} @ {DateTime.Now.ToLongTimeString()} on {HostId}");

        }

        private static void BroadCaster_PotentiallyDeadHostDetected(object sender, PotentiallyDeadHostEventArgs e)
        {
            Console.WriteLine($"{e.HostGuid} is dead.");
        }
    }
}
