using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Motoca.Core.Infrastructure.Database.Configs;
using Motoca.Platform.Domain.Entities;

namespace Motoca.Platform.Infrastructure.Database.Configs;

public class PlanConfig : IEntityTypeConfiguration<Plan>
{
    public void Configure(EntityTypeBuilder<Plan> builder)
    {
        builder.CommonFields("plans");

        builder.HasData(new List<Plan>
        {
            new ()
            {
                Id = 1,
                Guid = Guid.Parse("85ea2302-63d5-4333-9545-05a36a0e5820"),
                TotalDays = 7,
                CostPerDay = 30m,
                Fee = 1 + (20m / 100m),
                CreatedAt = new DateTime(2024, 1, 1),
                UpdatedAt = new DateTime(2024, 1, 1),
                Enabled = true
            },
            new ()
            {
                Id = 2,
                Guid = Guid.Parse("ef9329a6-ba6b-49bb-b318-b875ff667cce"),
                TotalDays = 15,
                CostPerDay = 28m,
                Fee = 1 + (40m / 100m),
                CreatedAt = new DateTime(2024, 1, 1),
                UpdatedAt = new DateTime(2024, 1, 1),
                Enabled = true
            },
            new ()
            {
                Id = 3,
                Guid = Guid.Parse("61ded59a-f540-4ee7-9d5c-709d03c57c0d"),
                TotalDays = 30,
                CostPerDay = 22m,
                Fee = 1,
                CreatedAt = new DateTime(2024, 1, 1),
                UpdatedAt = new DateTime(2024, 1, 1),
                Enabled = true
            },
            new ()
            {
                Id = 4,
                Guid = Guid.Parse("e01d4816-eba2-459b-8541-42e2cc7a62e0"),
                TotalDays = 45,
                CostPerDay = 20m,
                Fee = 1,
                CreatedAt = new DateTime(2024, 1, 1),
                UpdatedAt = new DateTime(2024, 1, 1),
                Enabled = true
            },
            new ()
            {
                Id = 5,
                Guid = Guid.Parse("66cf24fb-2ca5-45ef-920b-f163a0c5e4c4"),
                TotalDays = 50,
                CostPerDay = 18m,
                Fee = 1,
                CreatedAt = new DateTime(2024, 1, 1),
                UpdatedAt = new DateTime(2024, 1, 1),
                Enabled = true
            }
        });
    }
}