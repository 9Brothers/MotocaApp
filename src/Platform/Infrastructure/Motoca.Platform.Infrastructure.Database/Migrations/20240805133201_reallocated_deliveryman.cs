using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Motoca.Platform.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class reallocated_deliveryman : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "DeliverymanId",
                table: "rentals",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "MotorcycleId",
                table: "rentals",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

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

            migrationBuilder.CreateIndex(
                name: "IX_rentals_DeliverymanId",
                table: "rentals",
                column: "DeliverymanId");

            migrationBuilder.CreateIndex(
                name: "IX_rentals_MotorcycleId",
                table: "rentals",
                column: "MotorcycleId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_rentals_delivery_men_DeliverymanId",
                table: "rentals",
                column: "DeliverymanId",
                principalTable: "delivery_men",
                principalColumn: "DeliverymanId");

            migrationBuilder.AddForeignKey(
                name: "FK_rentals_motorcycles_MotorcycleId",
                table: "rentals",
                column: "MotorcycleId",
                principalTable: "motorcycles",
                principalColumn: "MotorcycleId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rentals_delivery_men_DeliverymanId",
                table: "rentals");

            migrationBuilder.DropForeignKey(
                name: "FK_rentals_motorcycles_MotorcycleId",
                table: "rentals");

            migrationBuilder.DropTable(
                name: "delivery_men");

            migrationBuilder.DropIndex(
                name: "IX_rentals_DeliverymanId",
                table: "rentals");

            migrationBuilder.DropIndex(
                name: "IX_rentals_MotorcycleId",
                table: "rentals");

            migrationBuilder.DropColumn(
                name: "DeliverymanId",
                table: "rentals");

            migrationBuilder.DropColumn(
                name: "MotorcycleId",
                table: "rentals");
        }
    }
}
