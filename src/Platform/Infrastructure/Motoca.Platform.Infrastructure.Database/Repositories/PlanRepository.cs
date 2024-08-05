using System.Data;
using Dapper;
using Motoca.Platform.Domain.Entities;
using Motoca.Platform.Domain.Interfaces.Repositories;
using Npgsql;

namespace Motoca.Platform.Infrastructure.Database.Repositories;

public class PlanRepository(IPlatformReaderConnection connection) : IPlanRepository
{
    private readonly NpgsqlConnection _connection = connection.GetConnection();
    public async Task<IEnumerable<Plan>> GetAll()
    {
        var query = $"select \"PlanId\" as \"Id\", \"PlanGuid\" as \"Guid\", * from plans;";

        return await _connection.QueryAsync<Plan>(query, commandType: CommandType.Text);
    }

    public async Task<Plan> GetByGuid(Guid planGuid)
    {
        var query = $"select \"PlanId\" as \"Id\", \"PlanGuid\" as \"Guid\", * from plans where \"PlanGuid\" = @planGuid;";

        return await _connection.QueryFirstOrDefaultAsync<Plan>(query, new {planGuid}, commandType: CommandType.Text);
    }

    public async Task<Plan> GetById(long planId)
    {
        var query = $"select \"PlanId\" as \"Id\", \"PlanGuid\" as \"Guid\", * from plans where \"PlanId\" = @planId;";

        return await _connection.QueryFirstOrDefaultAsync<Plan>(query, new {planId}, commandType: CommandType.Text);
    }
}