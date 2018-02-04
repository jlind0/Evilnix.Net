using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Evilnix.Net
{
    public interface ISerializer
    {
        byte[] Serialize<T>(T data);
        T Deserialize<T>(byte[] data);
    }
    public class BinarySerializer : ISerializer
    {
        public T Deserialize<T>(byte[] data)
        {
            using (var ms = new MemoryStream(data))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                return (T)formatter.Deserialize(ms);
            }
        }

        public byte[] Serialize<T>(T data)
        {
            using (var ms = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(ms, data);
                return ms.ToArray();
            }
        }
    }
}
