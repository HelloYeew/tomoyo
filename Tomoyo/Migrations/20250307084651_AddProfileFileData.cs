using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tomoyo.Migrations
{
    /// <inheritdoc />
    public partial class AddProfileFileData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "PhotographerProfiles",
                type: "TEXT",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 30);

            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "PhotographerProfiles",
                type: "TEXT",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cover",
                table: "PhotographerProfiles",
                type: "TEXT",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "CosplayerProfiles",
                type: "TEXT",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 30);

            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "CosplayerProfiles",
                type: "TEXT",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cover",
                table: "CosplayerProfiles",
                type: "TEXT",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "BaseProfiles",
                type: "TEXT",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 30);

            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "BaseProfiles",
                type: "TEXT",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Cover",
                table: "BaseProfiles",
                type: "TEXT",
                maxLength: 500,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "PhotographerProfiles");

            migrationBuilder.DropColumn(
                name: "Cover",
                table: "PhotographerProfiles");

            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "CosplayerProfiles");

            migrationBuilder.DropColumn(
                name: "Cover",
                table: "CosplayerProfiles");

            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "BaseProfiles");

            migrationBuilder.DropColumn(
                name: "Cover",
                table: "BaseProfiles");

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "PhotographerProfiles",
                type: "TEXT",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "CosplayerProfiles",
                type: "TEXT",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "BaseProfiles",
                type: "TEXT",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 30,
                oldNullable: true);
        }
    }
}
