using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tomoyo.Migrations
{
    /// <inheritdoc />
    public partial class AddPhotoThumbnailAndDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pictures_AspNetUsers_UploadUserId",
                table: "Pictures");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pictures",
                table: "Pictures");

            migrationBuilder.RenameTable(
                name: "Pictures",
                newName: "Photos");

            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "Photos",
                newName: "ThumbnailFileName");

            migrationBuilder.RenameIndex(
                name: "IX_Pictures_UploadUserId",
                table: "Photos",
                newName: "IX_Photos_UploadUserId");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Photos",
                type: "TEXT",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OriginalFileName",
                table: "Photos",
                type: "TEXT",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Photos",
                table: "Photos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_AspNetUsers_UploadUserId",
                table: "Photos",
                column: "UploadUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_AspNetUsers_UploadUserId",
                table: "Photos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Photos",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "OriginalFileName",
                table: "Photos");

            migrationBuilder.RenameTable(
                name: "Photos",
                newName: "Pictures");

            migrationBuilder.RenameColumn(
                name: "ThumbnailFileName",
                table: "Pictures",
                newName: "FileName");

            migrationBuilder.RenameIndex(
                name: "IX_Photos_UploadUserId",
                table: "Pictures",
                newName: "IX_Pictures_UploadUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pictures",
                table: "Pictures",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pictures_AspNetUsers_UploadUserId",
                table: "Pictures",
                column: "UploadUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
