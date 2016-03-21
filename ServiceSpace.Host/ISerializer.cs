using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSpace.Host
{
    public interface ISerializer
    {
        byte[] Serialize(object value);

        T Deserialize<T>(byte[] value);

        object Deserialize(byte[] value);
    }
}
