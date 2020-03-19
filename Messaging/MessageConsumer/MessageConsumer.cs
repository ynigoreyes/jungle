using System;
using System.Diagnostics;
using Confluent.Kafka;

namespace Messaging.Actors
{
    public class MessageConsumer<T> : IMessageConsumer<T>
    {
        private readonly IConsumer<Ignore, T> consumer;

        public MessageConsumer(IConsumer<Ignore, T> consumer) 
        {
            this.consumer = consumer;
        }

        public T WaitForMessage()
        {
            try
            {
                var results = this.consumer.Consume();
                return results.Message.Value;
            } catch (Exception e)
            {
                Debug.Fail(e.ToString());
                throw e;
            }
        }
    }
}