using System.Data;
using Dapper;
using Motoca.Core.Domain.Entities;
using Motoca.Core.Domain.Interfaces.Repositories;
using Npgsql;

namespace Motoca.Core.Infrastructure.Database.Repositories;

public class AdministratorRepository(ICoreReaderConnection readerConnection) : IAdministratorRepository
{
    private NpgsqlConnection _connection = readerConnection.GetConnection();

    public async Task<bool> Exists(string email)
    {
        var query = "select (case when count(1) > 0 then true else false end) as exists from administrators where \"Email\" = @email;";

        var result = await _connection.QueryFirstOrDefaultAsync(query, new {email}, commandType: CommandType.Text);
        
        return result?.exists;
    }

    public async Task<Administrator> FindByEmail(string email)
    {
        var query = "select \"AdministratorId\" as \"Id\", \"AdministratorGuid\" as \"Guid\", * from administrators where \"Email\" = @email";

        return await _connection.QueryFirstOrDefaultAsync<Administrator>(query, new {email}, commandType: CommandType.Text);
    }
}