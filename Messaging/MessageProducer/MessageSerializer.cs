using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Confluent.Kafka;

namespace Messaging.Actors
{
    public class MessageSerializer<T> : ISerializer<T>
    {
        public byte[] Serialize(T data, SerializationContext context)
        {
            BinaryFormatter bf = new BinaryFormatter();
            var ms = new MemoryStream();
            bf.Serialize(ms, data);
            return ms.ToArray();
        }
    }
}
