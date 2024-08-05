using Motoca.Core.Domain.Utils;
using RabbitMQ.Client;

namespace Motoca.Core.Infrastructure.Queue.Connections;

public abstract class CoreQueueConnectionFactory
{
    public static IConnection GetConnection(string connectionString)
    {
        var dict = ConnectionStringUtils.GetData(connectionString);
        
        var factory = new ConnectionFactory
        {
            HostName = dict.GetValueOrDefault("Hostname"),
            UserName = dict.GetValueOrDefault("UserName"),
            Password = dict.GetValueOrDefault("Password"),
            VirtualHost = dict.GetValueOrDefault("VirtualHost"),
            ClientProvidedName = dict.GetValueOrDefault("ClientProvidedName")
        };

        return factory.CreateConnection();
    }
}