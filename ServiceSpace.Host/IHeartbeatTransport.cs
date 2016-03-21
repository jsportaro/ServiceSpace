using ServiceSpace.Host.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSpace.Host
{
    public interface IHeartbeatTransport
    {
        event HeartbeatReceivedEventHandler HeartbeatReceived;

        void Start(Guid hostId);

        void Stop();
    }
}
