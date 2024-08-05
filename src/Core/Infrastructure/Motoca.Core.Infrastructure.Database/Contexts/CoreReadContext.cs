using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Motoca.Core.Infrastructure.Database.Contexts;

public class CoreReadContext : DbContext
{
    public CoreReadContext()
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    public CoreReadContext(DbContextOptions<CoreReadContext> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = Environment.GetEnvironmentVariable("POSTGRES_CORE_READ_DATABASE")
                                ?? "Host=localhost;Port=5434;Database=core;Username=postgres;Password=motoca";
            
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