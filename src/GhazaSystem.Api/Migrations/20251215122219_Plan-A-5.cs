using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GhazaSystem.Api.Migrations
{
    /// <inheritdoc />
    public partial class PlanA5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Daily_Foods_User_UserId",
                table: "Daily_Foods");

            migrationBuilder.DropIndex(
                name: "IX_Daily_Foods_UserId",
                table: "Daily_Foods");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Daily_Foods");

            migrationBuilder.CreateTable(
                name: "Daily_FoodUser",
                columns: table => new
                {
                    Daily_FoodsId = table.Column<Guid>(type: "uuid", nullable: false),
                    usersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Daily_FoodUser", x => new { x.Daily_FoodsId, x.usersId });
                    table.ForeignKey(
                        name: "FK_Daily_FoodUser_Daily_Foods_Daily_FoodsId",
                        column: x => x.Daily_FoodsId,
                        principalTable: "Daily_Foods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Daily_FoodUser_User_usersId",
                        column: x => x.usersId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Daily_FoodUser_usersId",
                table: "Daily_FoodUser",
                column: "usersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Daily_FoodUser");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Daily_Foods",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Daily_Foods_UserId",
                table: "Daily_Foods",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Daily_Foods_User_UserId",
                table: "Daily_Foods",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
