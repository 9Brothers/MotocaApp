using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Motoca.Core.Domain.Utils;
using Motoca.Core.Infrastructure.IoC;
using Motoca.Platform.Domain.Entities;

namespace Core.Domain.Services;

public class DeliverymanServiceTests
{
    public DeliverymanServiceTests()
    {
        DotEnvUtils.Load();
        
        var scope = Host.CreateDefaultBuilder()
            .ConfigureServices(p => p.AddDependencyInjection())
            .Build()
            .Services
            .CreateScope();

        // _service = scope.ServiceProvider.GetRequiredService<IDeliverymanService>();
    }
    
    [Fact]
    public async Task Add()
    {
        var deliveryman = new Deliveryman
        {
            Name = "Heber",
            Email = "heber@email.com",
            Birthdate = new DateTime(1991, 1, 1),
            CNH = "123456789",
            CnhType = "B",
            CNPJ = "00111333000144"
        };

        // await Assert.ThrowsAnyAsync<Exception>(() => _service.Add(deliveryman));
    }
}