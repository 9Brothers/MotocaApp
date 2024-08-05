using System.Data;
using Dapper;
using Motoca.Platform.Domain.Entities;
using Motoca.Platform.Domain.Interfaces.Repositories;
using Npgsql;

namespace Motoca.Platform.Infrastructure.Database.Repositories;

public class DeliverymanRepository : IDeliverymanRepository
{
    private NpgsqlConnection _connection;

    public DeliverymanRepository(IPlatformReaderConnection readerConnection)
    {
        _connection = readerConnection.GetConnection();
    }
    
    public async Task<bool> ExistsCNPJ(string cnpj)
    {
        var query = "select (case when count(1) > 0 then true else false end) as exists from delivery_men where \"CNPJ\" = @cnpj;";

        var result = await _connection.QueryFirstOrDefaultAsync(query, new {cnpj}, commandType: CommandType.Text);
        
        return result?.exists;
    }

    public async Task<Deliveryman> FindByCNPJ(string cnpj)
    {
        var query = "select \"DeliverymanId\" as \"Id\", \"DeliverymanGuid\" as \"Guid\", * from delivery_men where \"CNPJ\" = @cnpj";

        return await _connection.QueryFirstOrDefaultAsync<Deliveryman>(query, new {cnpj}, commandType: CommandType.Text);
    }

    public async Task<Deliveryman> FindById(long deliverymanId)
    {
        var query = "select \"DeliverymanId\" as \"Id\", \"DeliverymanGuid\" as \"Guid\", * from delivery_men where \"DeliverymanId\" = @deliverymanId";

        return await _connection.QueryFirstOrDefaultAsync<Deliveryman>(query, new {deliverymanId}, commandType: CommandType.Text);
    }
}