using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSpace.Host.Common
{
    public class JsonSerializer : ISerializer
    {
        public object Deserialize(byte[] value)
        {
            var serializedValue = Encoding.UTF8.GetString(value);

            return JsonConvert.DeserializeObject(serializedValue, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                NullValueHandling = NullValueHandling.Include
            });
        }

        public T Deserialize<T>(byte[] value)
        {
            var serializedValue = Encoding.UTF8.GetString(value);

            return JsonConvert.DeserializeObject<T>(serializedValue, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                NullValueHandling = NullValueHandling.Include
            });
        }

        public byte [] Serialize(object value)
        {
            var serializedValue = JsonConvert.SerializeObject(value, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                NullValueHandling = NullValueHandling.Include
            });

            return Encoding.UTF8.GetBytes(serializedValue);
        }
    }
}
