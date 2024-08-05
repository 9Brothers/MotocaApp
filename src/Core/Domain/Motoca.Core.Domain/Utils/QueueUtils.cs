using RabbitMQ.Client;

namespace Motoca.Core.Domain.Utils;

public abstract class QueueUtils
{
    public static void Create(IModel channel, string queueName, string exchange, string type)
    {
        channel.ExchangeDeclare(
            exchange: exchange,
            type: type,
            durable: true,
            autoDelete: false);
        
        channel.QueueDeclare(
            queue: queueName,
            durable: false,
            exclusive: false,
            autoDelete: false);
        
        channel.QueueBind(
            queue: queueName, 
            exchange: exchange,
            routingKey: queueName);
    }
}