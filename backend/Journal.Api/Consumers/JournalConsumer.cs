using AutoMapper;
using Journal.Api.Repositories;
using Journal.Data.Interfaces;
using Journal.MessageBus;
using Journal.MessageBus.Messages;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Threading.Channels;

namespace Journal.Api.Consumers
{
    public class JournalConsumer : BackgroundService
    {
        private readonly IConnection _connection;
        private readonly IModel _modelChannel;
        private readonly ILogger<JournalConsumer> _logger;
        private readonly IServiceProvider _serviceProvider;
       

        public JournalConsumer(IConfiguration _configuration, IServiceProvider serviceProvider, IMapper mapper)
        {
            var factory = new ConnectionFactory()
            {
                Uri = new Uri(_configuration.GetSection("RabbitMQ").Value)
            };

            _connection = factory.CreateConnection();
            _modelChannel = _connection.CreateModel();
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await Consuming(QueuesName.JournalQueue, stoppingToken);
        }

        private async Task Consuming(string queueName, CancellationToken stoppingToken)
        {
            _modelChannel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(_modelChannel);

            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                await ProcessMessageAsync(message, stoppingToken);

                _modelChannel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);

            };

            _modelChannel.BasicConsume(queue: queueName, autoAck: false, consumer: consumer);

            await Task.CompletedTask;
        }

        private async Task ProcessMessageAsync(string message, CancellationToken stoppingToken)
        {

            using var scope = _serviceProvider.CreateScope();
            var journalRepository = scope.ServiceProvider.GetRequiredService<IJournalRepository>();
            var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

            var journalMessage = JsonConvert.DeserializeObject<JournalMessage>(message);

            var qualisId = _qualisDict.First(c => c.Value == journalMessage.Qualis2019)
                                     .Key;

            var journal = new Data.Models.Journal()
            {
                Issn = journalMessage.Issn,
                Name = journalMessage.Name,
                Id = journalMessage.Id,
                Qualisid = qualisId
            };

            await journalRepository.AddAsync(journal);

            await unitOfWork.SaveChangesAsync();
        }

        public override void Dispose()
        {
            _connection.Close();
            _modelChannel.Close();
            base.Dispose();
        }

        readonly Dictionary<int, string> _qualisDict = new()
        {
            { 1, "A1" },
            { 2, "A2" },
            { 3, "A3" },
            { 4, "A4" },
            { 5, "B1" },
            { 6, "B2" },
            { 7, "B3" },
            { 8, "B4" },
            { 9, "C" },
            { 10, "ESTRATO" },
            { 11, "NP" }
        };
    }
}
