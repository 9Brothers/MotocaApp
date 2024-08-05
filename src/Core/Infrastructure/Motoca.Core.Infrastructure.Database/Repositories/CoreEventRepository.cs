using System.Data;
using Dapper;
using Motoca.Core.Domain.Interfaces.Repositories;
using Npgsql;

namespace Motoca.Core.Infrastructure.Database.Repositories;

public class CoreEventRepository(ICoreReaderConnection connection) : ICoreEventRepository
{
    private readonly NpgsqlConnection _connection = connection.GetConnection();
    
    public async Task<uint> LastSequence(Guid guid)
    {
        var query = $"select \"Sequence\" from events where \"CoreEventGuid\" = @guid order by \"Sequence\" desc limit 1;";

        var result = await _connection.QueryFirstOrDefaultAsync(query, new { guid }, commandType: CommandType.Text);

        return result?.Sequence ?? 0u;
    }
}