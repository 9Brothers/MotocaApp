using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Motoca.Core.Domain.Entities;

namespace Motoca.Core.Infrastructure.Database.Configs;

public class CoreEventConfig : IEntityTypeConfiguration<CoreEvent>
{
    public void Configure(EntityTypeBuilder<CoreEvent> builder)
    {
        builder.CommonFields("events");
    }
}