using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSpace.Host.Networking
{
    public class PotentiallyDeadHostEventArgs : EventArgs
    {
        public Guid HostGuid { get; private set; }

        public PotentiallyDeadHostEventArgs(Guid hostGuid)
        {
            HostGuid = hostGuid;
        }
    }
}
