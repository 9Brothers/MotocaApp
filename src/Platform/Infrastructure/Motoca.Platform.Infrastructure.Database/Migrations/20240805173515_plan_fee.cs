using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Motoca.Platform.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class plan_fee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "plans",
                keyColumn: "PlanId",
                keyValue: 1L,
                column: "Fee",
                value: 1.2m);

            migrationBuilder.UpdateData(
                table: "plans",
                keyColumn: "PlanId",
                keyValue: 2L,
                column: "Fee",
                value: 1.4m);

            migrationBuilder.UpdateData(
                table: "plans",
                keyColumn: "PlanId",
                keyValue: 3L,
                column: "Fee",
                value: 1m);

            migrationBuilder.UpdateData(
                table: "plans",
                keyColumn: "PlanId",
                keyValue: 4L,
                column: "Fee",
                value: 1m);

            migrationBuilder.UpdateData(
                table: "plans",
                keyColumn: "PlanId",
                keyValue: 5L,
                column: "Fee",
                value: 1m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
