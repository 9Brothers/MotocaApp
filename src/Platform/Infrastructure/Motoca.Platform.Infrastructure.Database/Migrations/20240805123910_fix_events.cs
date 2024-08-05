using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Motoca.Platform.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class fix_events : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CoreEventGuid",
                table: "events",
                newName: "PlatformEventGuid");

            migrationBuilder.RenameColumn(
                name: "CoreEventId",
                table: "events",
                newName: "PlatformEventId");

            migrationBuilder.RenameIndex(
                name: "IX_events_CoreEventGuid",
                table: "events",
                newName: "IX_events_PlatformEventGuid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PlatformEventGuid",
                table: "events",
                newName: "CoreEventGuid");

            migrationBuilder.RenameColumn(
                name: "PlatformEventId",
                table: "events",
                newName: "CoreEventId");

            migrationBuilder.RenameIndex(
                name: "IX_events_PlatformEventGuid",
                table: "events",
                newName: "IX_events_CoreEventGuid");
        }
    }
}
