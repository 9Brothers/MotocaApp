using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Motoca.Core.Infrastructure.Database.Configs;
using Motoca.Platform.Domain.Entities;

namespace Motoca.Platform.Infrastructure.Database.Configs;

public class RentalConfig : IEntityTypeConfiguration<Rental>
{
    public void Configure(EntityTypeBuilder<Rental> builder)
    {
        builder.CommonFields("rentals");

        builder.HasOne(p => p.Deliveryman)
            .WithMany(p => p.Rentals)
            .HasForeignKey(p => p.DeliverymanId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(p => p.Plan)
            .WithMany(p => p.Rentals)
            .HasForeignKey(p => p.PlanId)
            .IsRequired()
            .OnDelete(DeleteBehavior.NoAction);
    }
}