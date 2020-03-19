using Messaging.Actors;
using Confluent.Kafka;

namespace Messaging
{
    public class MessagingFactory
    {
        private static readonly string kafkaEndpoint = "kafka.default.svc.cluster.local:9092";

        public IMessageConsumer<T> CreateConsumer<T>(string groupId, string topicToSubscribeTo)
        {
            var conf = new ConsumerConfig
            {
                GroupId = groupId,
                BootstrapServers = kafkaEndpoint,
                AutoOffsetReset = AutoOffsetReset.Earliest,
            };

            // Need to use custom deserializer because Kafka can only automatically
            // deserialize primative types
            var c = new ConsumerBuilder<Ignore, T>(conf)
                .SetValueDeserializer(new MessageDeserializer<T>())
                .Build();
            c.Subscribe(topicToSubscribeTo);

            IMessageConsumer<T> messageConsumer = new MessageConsumer<T>(c);
            return messageConsumer;
        }

        public IMessageProducer<T1> CreateProducer<T1>()
        {
            var config = new ProducerConfig { BootstrapServers = kafkaEndpoint };

            // Need to use a custom serializer for the same reason ^^^
            var p = new ProducerBuilder<Null, T1>(config)
                .SetValueSerializer(new MessageSerializer<T1>())
                .Build();

            IMessageProducer<T1> messageProducer = new MessageProducer<T1>(p);
            return messageProducer;
        }
    }
}