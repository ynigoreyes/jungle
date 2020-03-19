using System;
namespace Messaging.Actors
{
    public interface IMessageProducer<T>
    {
        void SendMessage(string topic, T data);
    }
}
