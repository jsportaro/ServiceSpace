using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSpace.Host.Networking
{
    public class MulticastBroadcastTransport : IBroadcastTransport
    {
        private readonly IPAddress groupAddress = IPAddress.Parse("224.0.0.1");

        private readonly UdpClient sendClient;
        private readonly UdpClient receiveClient;
        private readonly ISerializer serializer;

        public event BroadcastReceivedEventHandler MessageReceived;

        public MulticastBroadcastTransport(ISerializer serializer)
        {
            sendClient = new UdpClient(10102);
            sendClient.MulticastLoopback = true;
            sendClient.JoinMulticastGroup(groupAddress);

            receiveClient = new UdpClient(10101);
            receiveClient.JoinMulticastGroup(groupAddress);

            this.serializer = serializer;

            Task.Run(() =>
            {
                ReceiveBroadcast();
            });
        }

        private void ReceiveBroadcast()
        {
            var endpoint = new IPEndPoint(IPAddress.Any, 10101);

            while (true)
            {
                var message = serializer.Deserialize(receiveClient.Receive(ref endpoint));
                if (MessageReceived != null)
                {
                    var mr = MessageReceived;

                    mr(this, new BroadcastReceivedEventArgs(message));
                }
            }
        }

        public void Send(object message)
        {
            var m = serializer.Serialize(message);
            var ep = new IPEndPoint(groupAddress, 10101);

            sendClient.Send(m, m.Length, ep);
        }
    }
}
