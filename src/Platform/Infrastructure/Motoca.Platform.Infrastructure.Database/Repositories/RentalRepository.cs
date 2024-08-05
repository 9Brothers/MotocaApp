using System.Data;
using Dapper;
using Motoca.Platform.Domain.Entities;
using Motoca.Platform.Domain.Interfaces.Repositories;
using Npgsql;

namespace Motoca.Platform.Infrastructure.Database.Repositories;

public class RentalRepository(IPlatformReaderConnection connection) : IRentalRepository
{
    private readonly NpgsqlConnection _connection = connection.GetConnection();
    public async Task<bool> ExistsOpenByDeliverymanId(long? deliverymanId)
    {
        var query = "select (case when count(1) > 0 then true else false end) as exists from rentals where \"DeliverymanId\" = @deliverymanId and \"End\" is null;";

        var result = await _connection.QueryFirstOrDefaultAsync(query, new {deliverymanId}, commandType: CommandType.Text);
        
        return result?.exists;
    }

    public async Task<Rental> OpenByDeliverymanId(long deliverymanId)
    {
        var query = "select \"RentalId\" as \"Id\", \"RentalGuid\" as \"Guid\", * from rentals where \"DeliverymanId\" = @deliverymanId and \"End\" is null limit 1;";

        return await _connection.QueryFirstOrDefaultAsync<Rental>(query, new {deliverymanId}, commandType: CommandType.Text);
    }

    public async Task<bool> ExistsByMotorcycleId(long motorcycleId)
    {
        var query = "select (case when count(1) > 0 then true else false end) as exists from rentals where \"MotorcycleId\" = @motorcycleId;";

        var result = await _connection.QueryFirstOrDefaultAsync(query, new {motorcycleId}, commandType: CommandType.Text);
        
        return result?.exists;
    }
}