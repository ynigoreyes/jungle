namespace Messaging.Actors
{
    public interface IMessageConsumer<T>
    {
        T WaitForMessage();
    }
}