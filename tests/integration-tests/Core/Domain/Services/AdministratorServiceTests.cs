using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Motoca.Core.Domain.Entities;
using Motoca.Core.Domain.Utils;
using Motoca.Core.Infrastructure.IoC;

namespace Core.Domain.Services;

public class AdministratorServiceTests
{
    public AdministratorServiceTests()
    {
        DotEnvUtils.Load();
        
        var scope = Host.CreateDefaultBuilder()
            .ConfigureServices(p => p.AddDependencyInjection())
            .Build()
            .Services
            .CreateScope();

        // _service = scope.ServiceProvider.GetRequiredService<IAdministratorService>();
    }
    
    [Fact]
    public async Task Add()
    {
        var administrator = new Administrator
        {
            Name = "Heber",
            Email = "heber@admin.com",
        };

        // await Assert.ThrowsAnyAsync<Exception>(() => _service.Add(administrator));
    }
}