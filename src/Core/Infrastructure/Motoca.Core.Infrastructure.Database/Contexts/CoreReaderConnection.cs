using Motoca.Core.Domain.Interfaces.Repositories;
using Motoca.Core.Domain.Utils;
using Npgsql;

namespace Motoca.Core.Infrastructure.Database.Contexts;

public class CoreReaderConnection : ICoreReaderConnection
{
    public NpgsqlConnection GetConnection()
    {
        var connectionString = EnvironmentUtils.TryGetEnvironmentVariable("POSTGRES_CORE_READ_DATABASE");

        return new NpgsqlConnection(connectionString);
    }
}