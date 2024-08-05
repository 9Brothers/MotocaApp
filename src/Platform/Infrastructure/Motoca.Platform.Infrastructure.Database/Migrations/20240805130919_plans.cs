using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Motoca.Platform.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class plans : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "plans",
                columns: table => new
                {
                    PlanId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TotalDays = table.Column<int>(type: "integer", nullable: false),
                    CostPerDay = table.Column<decimal>(type: "numeric", nullable: false),
                    PlanGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "(now())"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "(now())"),
                    Enabled = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plans", x => x.PlanId);
                });

            migrationBuilder.CreateTable(
                name: "rentals",
                columns: table => new
                {
                    RentalId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Start = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ExpectedEnd = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    End = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    RentalGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "(now())"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "(now())"),
                    Enabled = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rentals", x => x.RentalId);
                });

            migrationBuilder.InsertData(
                table: "plans",
                columns: new[] { "PlanId", "CostPerDay", "CreatedAt", "CreatedBy", "Enabled", "PlanGuid", "TotalDays", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1L, 30m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0L, true, new Guid("85ea2302-63d5-4333-9545-05a36a0e5820"), 7, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0L },
                    { 2L, 28m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0L, true, new Guid("ef9329a6-ba6b-49bb-b318-b875ff667cce"), 15, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0L },
                    { 3L, 22m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0L, true, new Guid("61ded59a-f540-4ee7-9d5c-709d03c57c0d"), 30, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0L },
                    { 4L, 20m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0L, true, new Guid("e01d4816-eba2-459b-8541-42e2cc7a62e0"), 45, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0L },
                    { 5L, 18m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0L, true, new Guid("66cf24fb-2ca5-45ef-920b-f163a0c5e4c4"), 50, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_plans_PlanGuid",
                table: "plans",
                column: "PlanGuid");

            migrationBuilder.CreateIndex(
                name: "IX_rentals_RentalGuid",
                table: "rentals",
                column: "RentalGuid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "plans");

            migrationBuilder.DropTable(
                name: "rentals");
        }
    }
}
