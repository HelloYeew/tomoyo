using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tomoyo.Migrations
{
    /// <inheritdoc />
    public partial class InitialPicture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    FileName = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    UploadUserId = table.Column<string>(type: "TEXT", maxLength: 36, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pictures_AspNetUsers_UploadUserId",
                        column: x => x.UploadUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_UploadUserId",
                table: "Pictures",
                column: "UploadUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pictures");
        }
    }
}
