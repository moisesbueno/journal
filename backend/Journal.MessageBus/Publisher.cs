﻿using Microsoft.Extensions.Configuration;
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
        public async Task SendMessageAsync(TEntity message, string queueName)
        {
            var factory = new ConnectionFactory()
            {
                Uri = new Uri(_configuration.GetSection("RabbitMQ").Value)
            };

            using var connection = factory.CreateConnection();

            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);

            await Task.Run(() =>
            {
                channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: null, body: body);
            });

        }
    }
}