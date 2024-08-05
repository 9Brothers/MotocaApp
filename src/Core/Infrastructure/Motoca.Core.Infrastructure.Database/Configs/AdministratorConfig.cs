using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Motoca.Core.Domain.Entities;

namespace Motoca.Core.Infrastructure.Database.Configs;

public class AdministratorConfig : IEntityTypeConfiguration<Administrator>
{
    public void Configure(EntityTypeBuilder<Administrator> builder)
    {
        builder.CommonFields("administrators");

        builder.Property(p => p.Name).IsRequired();
        builder.HasIndex(p => p.Email).IsUnique();
    }
}