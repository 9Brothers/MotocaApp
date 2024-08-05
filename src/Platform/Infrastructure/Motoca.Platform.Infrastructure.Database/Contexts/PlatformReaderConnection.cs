using Motoca.Core.Domain.Utils;
using Motoca.Platform.Domain.Interfaces.Repositories;
using Npgsql;

namespace Motoca.Platform.Infrastructure.Database.Contexts;

public class PlatformReaderConnection : IPlatformReaderConnection
{
    public NpgsqlConnection GetConnection()
    {
        var connectionString = EnvironmentUtils.TryGetEnvironmentVariable("POSTGRES_PLATFORM_READ_DATABASE");

        return new NpgsqlConnection(connectionString);
    }
}