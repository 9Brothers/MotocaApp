using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Motoca.Platform.Infrastructure.Database.Contexts;

public class PlatformWriteContext : DbContext
{
    public PlatformWriteContext()
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    public PlatformWriteContext(DbContextOptions<PlatformWriteContext> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = Environment.GetEnvironmentVariable("POSTGRES_PLATFORM_WRITE_DATABASE")
                                ?? "Host=localhost;Port=5433;Database=platform;Username=postgres;Password=motoca";
            
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