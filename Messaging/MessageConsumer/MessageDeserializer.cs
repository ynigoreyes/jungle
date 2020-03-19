using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Confluent.Kafka;

namespace Messaging.Actors
{
    public class MessageDeserializer<T> : IDeserializer<T>
    {
        public T Deserialize(ReadOnlySpan<byte> data, bool isNull, SerializationContext context)
        {
            if (!isNull)
            {
                MemoryStream memoryStream = new MemoryStream(data.ToArray());
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                memoryStream.Position = 0;
                T message = (T)binaryFormatter.Deserialize(memoryStream);
                return message;
            }

            return default;
        }
    }
}
