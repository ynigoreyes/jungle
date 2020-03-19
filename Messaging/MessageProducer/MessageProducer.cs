using Confluent.Kafka;
using System;
using System.Diagnostics;

namespace Messaging.Actors
{
    public class MessageProducer<T> : IMessageProducer<T>
    {
        private readonly IProducer<Null, T> producer;

        public MessageProducer(IProducer<Null, T> producer)
        {
            this.producer = producer;    
        }

        public void SendMessage(string topic, T data)
        {
            try
            {
                producer.Produce(topic, new Message<Null, T> { Value = data });
            } catch (Exception e)
            {
                Debug.Fail(e.ToString());
            }
        }
    }
}