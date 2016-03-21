using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSpace.Host.Networking
{
    public delegate void PotentiallyDeadHostEventHandler(object sender, PotentiallyDeadHostEventArgs e);
}
