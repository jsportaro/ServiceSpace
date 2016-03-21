using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSpace.Host
{
    public class Heartbeat
    {
        public IPAddress [] IpAddresses { get; set; }

        public Guid HostId { get; set; }
    }
}
