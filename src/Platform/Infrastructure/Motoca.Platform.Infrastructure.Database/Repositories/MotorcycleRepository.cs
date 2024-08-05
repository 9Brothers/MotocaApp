using System.Data;
using Dapper;
using Motoca.Platform.Domain.Entities;
using Motoca.Platform.Domain.Interfaces.Repositories;
using Motoca.Platform.Domain.Mediator.Commands.Responses;
using Npgsql;

namespace Motoca.Platform.Infrastructure.Database.Repositories;

public class MotorcycleRepository(IPlatformReaderConnection connection) : IMotorcycleRepository
{
    private NpgsqlConnection _connection = connection.GetConnection();
    
    public async Task<bool> Exists(string licensePlate)
    {
        var query = "select (case when count(1) > 0 then true else false end) as exists from motorcycles where \"LicensePlate\" = @licensePlate;";

        var result = await _connection.QueryFirstOrDefaultAsync(query, new {licensePlate}, commandType: CommandType.Text);
        
        return result?.exists;
    }

    public async Task<IEnumerable<MotorcycleResponse>> GetAllByLicensePlate(string licensePlate, int page = 0)
    {
        page *= 50;

        if (string.IsNullOrEmpty(licensePlate))
            licensePlate = string.Empty;

        var query = @"select
                            ""MotorcycleGuid"" as ""Guid"",
                            ""Year"",
                            ""Model"",
                            ""LicensePlate""
                        from motorcycles 
                        where ""LicensePlate"" ~ @licensePlate
                        limit 50
                        offset @page;";

        return await _connection.QueryAsync<MotorcycleResponse>(query, new {licensePlate, page}, commandType: CommandType.Text);
    }

    public async Task<Motorcycle> GetByLicensePlate(string licensePlate)
    {
        var query = "select \"MotorcycleId\" as \"Id\", \"MotorcycleGuid\" as \"Guid\", * from motorcycles where \"LicensePlate\" = @licensePlate";

        return await _connection.QueryFirstOrDefaultAsync<Motorcycle>(query, new {licensePlate},
            commandType: CommandType.Text);
    }

    public async Task<Motorcycle> FirstAvailable()
    {
        var query = "select \"MotorcycleId\" as \"Id\", \"MotorcycleGuid\" as \"Guid\", * from motorcycles where \"Available\" = true order by \"Year\" desc limit 1;";

        return await _connection.QueryFirstOrDefaultAsync<Motorcycle>(query, commandType: CommandType.Text);
    }

    public async Task<Motorcycle> GetById(long motorcycleId)
    {
        var query = "select \"MotorcycleId\" as \"Id\", \"MotorcycleGuid\" as \"Guid\", * from motorcycles where \"MotorcycleId\" = @motorcycleId;";

        return await _connection.QueryFirstOrDefaultAsync<Motorcycle>(query, new { motorcycleId }, commandType: CommandType.Text);
    }

    public async Task<Motorcycle> GetByGuid(Guid motorcycleGuid)
    {
        var query = "select \"MotorcycleId\" as \"Id\", \"MotorcycleGuid\" as \"Guid\", * from motorcycles where \"MotorcycleGuid\" = @motorcycleGuid;";

        return await _connection.QueryFirstOrDefaultAsync<Motorcycle>(query, new { motorcycleGuid }, commandType: CommandType.Text);
    }
}