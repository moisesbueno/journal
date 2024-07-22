using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Journal.MessageBus
{
    public class Publisher<TEntity> : IPublisher<TEntity>
    {
        private readonly IConfiguration _configuration;

        public Publisher(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendMessageAsync(TEntity message)
        {
            var factory = new ConnectionFactory()
            {
                Uri = new Uri(_configuration.GetSection("RabbitMQ").Value)
            };

            var connection = factory.CreateConnection();

            using var channel = connection.CreateModel();

            var queueName = GetQueueName(message);

            channel.QueueDeclare(queue: queueName,
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);

            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(exchange: "",
                                    routingKey: queueName,
                                    basicProperties: null,
                                    body: body);
            await Task.CompletedTask;
        }

        private string GetQueueName(TEntity message)
        {
            var queueName = message.GetType()
                                .CustomAttributes
                                .First(a => a.AttributeType == typeof(QueueNameAttribute))
                                .ConstructorArguments[0].Value.ToString();

            return queueName;
        }
    }
}
