using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Motoca.Platform.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class rentals_fee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Fee",
                table: "rentals",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fee",
                table: "rentals");
        }
    }
}
