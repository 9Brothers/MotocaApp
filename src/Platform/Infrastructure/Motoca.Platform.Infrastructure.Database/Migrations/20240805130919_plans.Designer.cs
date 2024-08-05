﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Motoca.Platform.Infrastructure.Database.Contexts;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Motoca.Platform.Infrastructure.Database.Migrations
{
    [DbContext(typeof(PlatformWriteContext))]
    [Migration("20240805130919_plans")]
    partial class plans
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Motoca.Platform.Domain.Entities.Motorcycle", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("MotorcycleId");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("(now())");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<bool>("Enabled")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<Guid>("Guid")
                        .HasColumnType("uuid")
                        .HasColumnName("MotorcycleGuid");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("(now())");

                    b.Property<long>("UpdatedBy")
                        .HasColumnType("bigint");

                    b.Property<short>("Year")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("Guid");

                    b.HasIndex("LicensePlate")
                        .IsUnique();

                    b.ToTable("motorcycles", (string)null);
                });

            modelBuilder.Entity("Motoca.Platform.Domain.Entities.Plan", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("PlanId");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<decimal>("CostPerDay")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("(now())");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<bool>("Enabled")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<Guid>("Guid")
                        .HasColumnType("uuid")
                        .HasColumnName("PlanGuid");

                    b.Property<int>("TotalDays")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("(now())");

                    b.Property<long>("UpdatedBy")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("Guid");

                    b.ToTable("plans", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CostPerDay = 30m,
                            CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = 0L,
                            Enabled = true,
                            Guid = new Guid("85ea2302-63d5-4333-9545-05a36a0e5820"),
                            TotalDays = 7,
                            UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedBy = 0L
                        },
                        new
                        {
                            Id = 2L,
                            CostPerDay = 28m,
                            CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = 0L,
                            Enabled = true,
                            Guid = new Guid("ef9329a6-ba6b-49bb-b318-b875ff667cce"),
                            TotalDays = 15,
                            UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedBy = 0L
                        },
                        new
                        {
                            Id = 3L,
                            CostPerDay = 22m,
                            CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = 0L,
                            Enabled = true,
                            Guid = new Guid("61ded59a-f540-4ee7-9d5c-709d03c57c0d"),
                            TotalDays = 30,
                            UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedBy = 0L
                        },
                        new
                        {
                            Id = 4L,
                            CostPerDay = 20m,
                            CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = 0L,
                            Enabled = true,
                            Guid = new Guid("e01d4816-eba2-459b-8541-42e2cc7a62e0"),
                            TotalDays = 45,
                            UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedBy = 0L
                        },
                        new
                        {
                            Id = 5L,
                            CostPerDay = 18m,
                            CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CreatedBy = 0L,
                            Enabled = true,
                            Guid = new Guid("66cf24fb-2ca5-45ef-920b-f163a0c5e4c4"),
                            TotalDays = 50,
                            UpdatedAt = new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UpdatedBy = 0L
                        });
                });

            modelBuilder.Entity("Motoca.Platform.Domain.Entities.PlatformEvent", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("PlatformEventId");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("(now())");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<bool>("Enabled")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<Guid>("Guid")
                        .HasColumnType("uuid")
                        .HasColumnName("PlatformEventGuid");

                    b.Property<string>("Log")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("Sequence")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("(now())");

                    b.Property<long>("UpdatedBy")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("Guid");

                    b.ToTable("events", (string)null);
                });

            modelBuilder.Entity("Motoca.Platform.Domain.Entities.Rental", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("RentalId");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("(now())");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<bool>("Enabled")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<DateTime?>("End")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("ExpectedEnd")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("Guid")
                        .HasColumnType("uuid")
                        .HasColumnName("RentalGuid");

                    b.Property<DateTime>("Start")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("(now())");

                    b.Property<long>("UpdatedBy")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("Guid");

                    b.ToTable("rentals", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
