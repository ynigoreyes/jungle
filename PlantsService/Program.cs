using System;
using System.Threading;
using System.Threading.Tasks;
using Messaging;
using DataContracts.Plants;
using DataContracts.Animals;

class Program
{
    private static readonly MessagingFactory messagingFactory = new MessagingFactory();

    /// <summary>
    /// This should create new plants and tell the world about it
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    public static void Main(string[] args)
    {
        Parallel.Invoke(
            () => StartCreatingTrees(),
            () => StartCreatingFlowers(),
            () => ListenForNewMonkeys()
        );

        Console.WriteLine("Exiting...");
    }

    private async static void StartCreatingTrees()
    {
        var producer = messagingFactory.CreateProducer<Tree>();
        Random random = new Random();
        while (true)
        {
            var newTree = new Tree();
            Console.WriteLine(newTree + " created.");
            producer.SendMessage("tree-created", newTree);
            await Task.Delay(random.Next(1500, 5000));
        }
    }

    private async static void StartCreatingFlowers()
    {
        var producer = messagingFactory.CreateProducer<Flower>();
        Random random = new Random();
        while (true)
        {
            var newFlower = new Flower();
            Console.WriteLine(newFlower + " created.");
            producer.SendMessage("flower-created", newFlower);
            await Task.Delay(random.Next(1500, 5000));
        }
    }

    private static void ListenForNewMonkeys()
    {
        var consumer = messagingFactory.CreateConsumer<Monkey>("plants-service", "monkey-created");
        while (true)
        {
            var newMonkey = consumer.WaitForMessage();

            Console.WriteLine(newMonkey + " created and recieved by Plants Service");
        }
    }
}