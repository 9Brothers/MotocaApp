using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Motoca.Core.Infrastructure.Database.Configs;
using Motoca.Platform.Domain.Entities;

namespace Motoca.Platform.Infrastructure.Database.Configs;

public class DeliverymanConfig : IEntityTypeConfiguration<Deliveryman>
{
    public void Configure(EntityTypeBuilder<Deliveryman> builder)
    {
        builder.CommonFields("delivery_men");

        builder.Property(p => p.Birthdate).IsRequired();
        builder.Property(p => p.Name).IsRequired();
        builder.HasIndex(p => p.Email).IsUnique();
        builder.HasIndex(p => p.CNPJ).IsUnique();
        builder.HasIndex(p => p.CNH).IsUnique();
        builder.Property(p => p.CnhType).IsRequired();
    }
}