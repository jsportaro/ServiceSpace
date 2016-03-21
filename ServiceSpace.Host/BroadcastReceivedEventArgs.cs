using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSpace.Host
{
    public class BroadcastReceivedEventArgs
    {
        public object Message { get; private set; }

        public BroadcastReceivedEventArgs(object message)
        {
            Message = message;
        }
    }
}
