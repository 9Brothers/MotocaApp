using RabbitMQ.Client;

namespace Motoca.Core.Infrastructure.Queue.Connections;

public abstract class CoreQueueConnectionFactory
{
    public static IConnection GetConnection(string connectionString)
    {
        var values = connectionString
            .Split(";")
            .Select(p =>
            {
                var items = p.Split("=");

                return new KeyValuePair<string, string>(items[0], items[1]);
            })
            .ToDictionary(p => p.Key);
        
        var factory = new ConnectionFactory
        {
            HostName = values.GetValueOrDefault("Hostname").Value,
            UserName = values.GetValueOrDefault("UserName").Value,
            Password = values.GetValueOrDefault("Password").Value,
            VirtualHost = values.GetValueOrDefault("VirtualHost").Value,
            ClientProvidedName = values.GetValueOrDefault("ClientProvidedName").Value
        };

        return factory.CreateConnection();
    }
}