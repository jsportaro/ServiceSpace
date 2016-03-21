using ServiceSpace.Host.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceSpace.Host.Networking
{
    public class MulticastHeartbeatTransport : IHeartbeatTransport
    {
        private Guid hostId;

        private readonly IBroadcastTransport broadCastTransport;

        public event HeartbeatReceivedEventHandler HeartbeatReceived;

        public MulticastHeartbeatTransport(IBroadcastTransport broadCastTransport)
        {
            this.broadCastTransport = broadCastTransport;

            this.broadCastTransport.MessageReceived += ReceiveHeartbeat;
        }

        public void Start(Guid hostId)
        {
            this.hostId = hostId;

            Task.Run(() =>
            {
                SendHeartbeat();
            });
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        public void SendHeartbeat()
        {
            while (true)
            {
                broadCastTransport.Send(new Heartbeat()
                {
                    HostId = hostId,
                    IpAddresses = IPAddressUtility.LocalIpAddresses()
                });

                Thread.Sleep(1000);
            }
        }

        public void ReceiveHeartbeat(object sender, BroadcastReceivedEventArgs e)
        {
            var heartbeat = e.Message as Heartbeat;

            if (heartbeat == null)
                return;

            var from = heartbeat.HostId;

            if (from != hostId)
            {
                var h = HeartbeatReceived;

                if (h != null)
                {
                    h(this, new HeartbeatReceivedEventArgs(heartbeat));
                }
            }
        }
    }
}
