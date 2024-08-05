using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Motoca.Core.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "administrators",
                columns: table => new
                {
                    AdministratorId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AdministratorGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "(now())"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "(now())"),
                    Enabled = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_administrators", x => x.AdministratorId);
                });

            migrationBuilder.CreateTable(
                name: "delivery_men",
                columns: table => new
                {
                    DeliverymanId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Birthdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CNPJ = table.Column<string>(type: "text", nullable: false),
                    CNH = table.Column<string>(type: "text", nullable: false),
                    CnhType = table.Column<string>(type: "text", nullable: false),
                    CnhUrl = table.Column<string>(type: "text", nullable: true),
                    DeliverymanGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "(now())"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "(now())"),
                    Enabled = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_delivery_men", x => x.DeliverymanId);
                });

            migrationBuilder.CreateTable(
                name: "events",
                columns: table => new
                {
                    CoreEventId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CoreEventGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "(now())"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "(now())"),
                    Enabled = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: false),
                    Log = table.Column<string>(type: "text", nullable: false),
                    Sequence = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_events", x => x.CoreEventId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_administrators_AdministratorGuid",
                table: "administrators",
                column: "AdministratorGuid");

            migrationBuilder.CreateIndex(
                name: "IX_administrators_Email",
                table: "administrators",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_delivery_men_CNH",
                table: "delivery_men",
                column: "CNH",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_delivery_men_CNPJ",
                table: "delivery_men",
                column: "CNPJ",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_delivery_men_DeliverymanGuid",
                table: "delivery_men",
                column: "DeliverymanGuid");

            migrationBuilder.CreateIndex(
                name: "IX_delivery_men_Email",
                table: "delivery_men",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_events_CoreEventGuid",
                table: "events",
                column: "CoreEventGuid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "administrators");

            migrationBuilder.DropTable(
                name: "delivery_men");

            migrationBuilder.DropTable(
                name: "events");
        }
    }
}
