using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Motoca.Core.Infrastructure.Database.Configs;
using Motoca.Platform.Domain.Entities;

namespace Motoca.Platform.Infrastructure.Database.Configs;

public class MotorcycleConfig : IEntityTypeConfiguration<Motorcycle>
{
    public void Configure(EntityTypeBuilder<Motorcycle> builder)
    {
        builder.CommonFields("motorcycles");

        builder.Property(p => p.Year).IsRequired();
        builder.Property(p => p.Model).IsRequired();
        builder.Property(p => p.Available).HasDefaultValue(true);
        builder.HasIndex(p => p.LicensePlate).IsUnique();
        
    }
}