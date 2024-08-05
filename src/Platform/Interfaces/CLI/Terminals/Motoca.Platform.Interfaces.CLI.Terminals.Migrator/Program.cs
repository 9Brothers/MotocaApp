using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Motoca.Core.Domain.Utils;
using Motoca.Core.Infrastructure.Database.Contexts;
using Motoca.Platform.Infrastructure.Database.Contexts;

DotEnvUtils.Load();

var services = Host.CreateDefaultBuilder()
    .ConfigureServices(services =>
    {
        services.AddDbContext<CoreWriteContext>();
        services.AddDbContext<PlatformWriteContext>();
    })
    .Build()
    .Services
    .CreateScope()
    .ServiceProvider;

var logger = services.GetRequiredService<ILogger<Program>>();
var coreContext = services.GetRequiredService<CoreWriteContext>();
var platformContext = services.GetRequiredService<PlatformWriteContext>();

logger.LogInformation("Efetuando migrações");

coreContext.Database.EnsureCreated();
platformContext.Database.EnsureCreated();

logger.LogInformation("Migrações efetuadas");