using Motoca.Core.Infrastructure.Queue.Connections;

namespace Core.Infrastructure.Queue.Connections;

public class CoreQueueConnectionFactoryTests
{
    [Fact]
    public void GetConnectionTest()
    {
        var connection = CoreQueueConnectionFactory.GetConnection(
            "Hostname=localhost;VirtualHost=/;UserName=motoca;Password=grau;ClientProvidedName=platform");
        
        Assert.NotNull(connection);
    }
}