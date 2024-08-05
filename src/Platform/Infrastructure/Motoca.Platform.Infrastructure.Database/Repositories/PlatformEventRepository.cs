using System.Data;
using Dapper;
using Motoca.Platform.Domain.Interfaces.Repositories;
using Npgsql;

namespace Motoca.Platform.Infrastructure.Database.Repositories;

public class PlatformEventRepository(IPlatformReaderConnection connection) : IPlatformEventRepository
{
    private readonly NpgsqlConnection _connection = connection.GetConnection();
    
    public async Task<uint> LastSequence(Guid guid)
    {
        var query = $"select \"Sequence\" from events where \"PlatformEventGuid\" = @guid order by \"Sequence\" desc limit 1;";

        var result = await _connection.QueryFirstOrDefaultAsync(query, new { guid }, commandType: CommandType.Text);

        return result?.Sequence ?? 0u;
    }
}