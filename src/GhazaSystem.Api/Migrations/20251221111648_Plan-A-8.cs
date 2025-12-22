using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GhazaSystem.Api.Migrations
{
    /// <inheritdoc />
    public partial class PlanA8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool[]>(
                name: "Access",
                table: "User",
                type: "boolean[]",
                nullable: false,
                defaultValue: new bool[0]);

            migrationBuilder.AddColumn<Guid>(
                name: "C_UserId",
                table: "User",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    C_Code = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_C_UserId",
                table: "User",
                column: "C_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Companies_C_UserId",
                table: "User",
                column: "C_UserId",
                principalTable: "Companies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Companies_C_UserId",
                table: "User");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_User_C_UserId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Access",
                table: "User");

            migrationBuilder.DropColumn(
                name: "C_UserId",
                table: "User");
        }
    }
}
