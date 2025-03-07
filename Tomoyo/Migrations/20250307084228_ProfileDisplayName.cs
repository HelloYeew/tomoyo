using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tomoyo.Migrations
{
    /// <inheritdoc />
    public partial class ProfileDisplayName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "PhotographerProfiles",
                type: "TEXT",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "CosplayerProfiles",
                type: "TEXT",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "BaseProfiles",
                type: "TEXT",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "PhotographerProfiles");

            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "CosplayerProfiles");

            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "BaseProfiles");
        }
    }
}
