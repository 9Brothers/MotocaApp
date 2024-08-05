using Npgsql;

namespace Motoca.Core.Domain.Interfaces.Repositories;

public interface IReaderContext
{
    NpgsqlConnection GetConnection();
}