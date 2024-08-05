using Motoca.Core.Domain.Utils;

namespace Core.Utils;

public class ConnectionStringUtilsTests
{
    [Fact]
    public void GetData()
    {
        var connectionString =
            "Hostname=localhost;VirtualHost=/;UserName=motoca;Password=grau;ClientProvidedName=platform";
        var dict = ConnectionStringUtils.GetData(connectionString);
        
        Assert.NotNull(dict);
        Assert.Equal("localhost", dict.GetValueOrDefault("Hostname"));
        Assert.Equal("/", dict.GetValueOrDefault("VirtualHost"));
        Assert.Equal("motoca", dict.GetValueOrDefault("UserName"));
        Assert.Equal("grau", dict.GetValueOrDefault("Password"));
        Assert.Equal("platform", dict.GetValueOrDefault("ClientProvidedName"));
    }
}