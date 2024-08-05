using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Motoca.Platform.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class rentals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PlanId",
                table: "rentals",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<decimal>(
                name: "Fee",
                table: "plans",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "plans",
                keyColumn: "PlanId",
                keyValue: 1L,
                column: "Fee",
                value: 0.2m);

            migrationBuilder.UpdateData(
                table: "plans",
                keyColumn: "PlanId",
                keyValue: 2L,
                column: "Fee",
                value: 0.4m);

            migrationBuilder.UpdateData(
                table: "plans",
                keyColumn: "PlanId",
                keyValue: 3L,
                column: "Fee",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "plans",
                keyColumn: "PlanId",
                keyValue: 4L,
                column: "Fee",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "plans",
                keyColumn: "PlanId",
                keyValue: 5L,
                column: "Fee",
                value: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_rentals_PlanId",
                table: "rentals",
                column: "PlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_rentals_plans_PlanId",
                table: "rentals",
                column: "PlanId",
                principalTable: "plans",
                principalColumn: "PlanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_rentals_plans_PlanId",
                table: "rentals");

            migrationBuilder.DropIndex(
                name: "IX_rentals_PlanId",
                table: "rentals");

            migrationBuilder.DropColumn(
                name: "PlanId",
                table: "rentals");

            migrationBuilder.DropColumn(
                name: "Fee",
                table: "plans");
        }
    }
}
