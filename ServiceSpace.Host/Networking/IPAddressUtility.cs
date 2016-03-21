using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSpace.Host.Extensions
{
    public static class IPAddressUtility
    {
        public static IPAddress [] LocalIpAddresses(AddressFamily addressFamily = AddressFamily.InterNetwork)
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());

            return host.AddressList;
        }
    }
}
