using DevFreela.Core.Services;

using Microsoft.Extensions.Configuration;

using RabbitMQ.Client;

namespace DevFreela.Infrastructure.MessageBus
{
    public class MessageBusService : IMessageBusService
    {
        private readonly ConnectionFactory _connectionFactory;
        
        public MessageBusService()
        {
            _connectionFactory = new ConnectionFactory
            {
                HostName = "localhost"
            };
        }
        
        public void Publish(string queue, byte[] message)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    // Garantir que a fila esteja criada
                    channel.QueueDeclare(
                        queue: queue, 
                        durable: false, 
                        exclusive: false, 
                        autoDelete: false, 
                        arguments: null);
                    
                    // Publicar a mensagem
                    channel.BasicPublish(
                        exchange: "",
                        routingKey: queue,
                        basicProperties: null,
                        body: message);

                }
            }
        }
    }
}
