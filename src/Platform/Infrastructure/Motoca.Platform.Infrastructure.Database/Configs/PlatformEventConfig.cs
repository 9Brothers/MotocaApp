using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Motoca.Core.Infrastructure.Database.Configs;
using Motoca.Platform.Domain.Entities;

namespace Motoca.Platform.Infrastructure.Database.Configs;

public class PlatformEventConfig : IEntityTypeConfiguration<PlatformEvent>
{
    public void Configure(EntityTypeBuilder<PlatformEvent> builder)
    {
        builder.CommonFields("events");
    }
}