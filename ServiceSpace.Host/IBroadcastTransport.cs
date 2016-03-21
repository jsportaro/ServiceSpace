using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSpace.Host
{
    public interface IBroadcastTransport
    {
        event BroadcastReceivedEventHandler MessageReceived;

        void Send(object message);
    }
}
