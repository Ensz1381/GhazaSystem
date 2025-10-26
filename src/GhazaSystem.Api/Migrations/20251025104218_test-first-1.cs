using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GhazaSystem.Api.Migrations
{
    /// <inheritdoc />
    public partial class testfirst1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Food_ChangedId",
                table: "Food_Change",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Daily_Food",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    foodId = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Daily_Food", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Daily_Food_Food_foodId",
                        column: x => x.foodId,
                        principalTable: "Food",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Daily_Food_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Food_Change_Food_ChangedId",
                table: "Food_Change",
                column: "Food_ChangedId");

            migrationBuilder.CreateIndex(
                name: "IX_Daily_Food_foodId",
                table: "Daily_Food",
                column: "foodId");

            migrationBuilder.CreateIndex(
                name: "IX_Daily_Food_UserId",
                table: "Daily_Food",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Food_Change_Daily_Food_Food_ChangedId",
                table: "Food_Change",
                column: "Food_ChangedId",
                principalTable: "Daily_Food",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Food_Change_Daily_Food_Food_ChangedId",
                table: "Food_Change");

            migrationBuilder.DropTable(
                name: "Daily_Food");

            migrationBuilder.DropIndex(
                name: "IX_Food_Change_Food_ChangedId",
                table: "Food_Change");

            migrationBuilder.DropColumn(
                name: "Food_ChangedId",
                table: "Food_Change");
        }
    }
}
