using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Motoca.Core.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class reallocated_deliveryman : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "delivery_men");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "delivery_men",
                columns: table => new
                {
                    DeliverymanId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Birthdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CNH = table.Column<string>(type: "text", nullable: false),
                    CNPJ = table.Column<string>(type: "text", nullable: false),
                    CnhType = table.Column<string>(type: "text", nullable: false),
                    CnhUrl = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "(now())"),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Enabled = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeliverymanGuid = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "(now())"),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_delivery_men", x => x.DeliverymanId);
                });

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
        }
    }
}
