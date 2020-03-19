using System;
using System.Threading;
using System.Threading.Tasks;
using Messaging;
using DataContracts.Animals;
using DataContracts.Plants;

class Program
{
    private static readonly MessagingFactory messagingFactory = new MessagingFactory();

    /// <summary>
    /// This should create new animals and tell the world about it
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    public static void Main(string[] args)
    {
        Parallel.Invoke(
            () => StartCreatingMonkeys(),
            () => ListenForNewFlowers(),
            () => ListenForNewTrees()
        );

        Console.WriteLine("Exiting...");
    }

    private async static void StartCreatingMonkeys()
    {
        var producer = messagingFactory.CreateProducer<Monkey>();
        while (true)
        {
            var newMonkey = new Monkey();
            Console.WriteLine(newMonkey + " created.");
            producer.SendMessage("monkey-created", newMonkey);
            await Task.Delay(1500);
        }
    }

    private static void ListenForNewTrees()
    {
        var consumer = messagingFactory.CreateConsumer<Tree>("animals-service", "tree-created");
        while (true)
        {
            var newTree = consumer.WaitForMessage();

            Console.WriteLine(newTree + " created and recieved by Animals Service from the tree-created topic");
        }
    }

    private static void ListenForNewFlowers()
    {
        var consumer = messagingFactory.CreateConsumer<Flower>("animals-service", "flower-created");
        while (true)
        {
            var newFlower = consumer.WaitForMessage();

            Console.WriteLine(newFlower + " created and recieved by Animals Service from the flower-created topic");
        }
    }
}