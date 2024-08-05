using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Motoca.Platform.Infrastructure.Database.Contexts;

public class PlatformReadContext : DbContext
{
    public PlatformReadContext()
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    public PlatformReadContext(DbContextOptions<PlatformReadContext> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = Environment.GetEnvironmentVariable("POSTGRES_PLATFORM_READ_DATABASE")
                                ?? "Host=localhost;Port=5434;Database=platform;Username=postgres;Password=motoca";
            
        optionsBuilder
            .UseNpgsql(new NpgsqlConnection(connectionString),
                o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery))
            .EnableSensitiveDataLogging();
    }
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
         modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}