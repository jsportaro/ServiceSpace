using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSpace.Host
{
    public class SpaceState
    {
        public DateTime LastHeard { get; private set; }

        public Heartbeat LastHeartbeat { get; private set; }

        public SpaceState(Heartbeat heartbeat)
        {
            Update(heartbeat);
        }

        private void Update(Heartbeat heartbeat)
        {
            LastHeard = DateTime.Now;
            LastHeartbeat = heartbeat;
        }
    }
}
