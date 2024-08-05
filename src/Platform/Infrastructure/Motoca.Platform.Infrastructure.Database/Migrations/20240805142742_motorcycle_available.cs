using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Motoca.Platform.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class motorcycle_available : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Available",
                table: "motorcycles",
                type: "boolean",
                nullable: false,
                defaultValue: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Available",
                table: "motorcycles");
        }
    }
}
