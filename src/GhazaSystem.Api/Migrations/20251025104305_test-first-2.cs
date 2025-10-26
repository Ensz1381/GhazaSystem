using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GhazaSystem.Api.Migrations
{
    /// <inheritdoc />
    public partial class testfirst2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Daily_Food_Food_foodId",
                table: "Daily_Food");

            migrationBuilder.DropForeignKey(
                name: "FK_Daily_Food_User_UserId",
                table: "Daily_Food");

            migrationBuilder.DropForeignKey(
                name: "FK_Food_Change_Daily_Food_Food_ChangedId",
                table: "Food_Change");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Daily_Food",
                table: "Daily_Food");

            migrationBuilder.RenameTable(
                name: "Daily_Food",
                newName: "Daily_Foods");

            migrationBuilder.RenameIndex(
                name: "IX_Daily_Food_UserId",
                table: "Daily_Foods",
                newName: "IX_Daily_Foods_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Daily_Food_foodId",
                table: "Daily_Foods",
                newName: "IX_Daily_Foods_foodId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Daily_Foods",
                table: "Daily_Foods",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Daily_Foods_Food_foodId",
                table: "Daily_Foods",
                column: "foodId",
                principalTable: "Food",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Daily_Foods_User_UserId",
                table: "Daily_Foods",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Food_Change_Daily_Foods_Food_ChangedId",
                table: "Food_Change",
                column: "Food_ChangedId",
                principalTable: "Daily_Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Daily_Foods_Food_foodId",
                table: "Daily_Foods");

            migrationBuilder.DropForeignKey(
                name: "FK_Daily_Foods_User_UserId",
                table: "Daily_Foods");

            migrationBuilder.DropForeignKey(
                name: "FK_Food_Change_Daily_Foods_Food_ChangedId",
                table: "Food_Change");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Daily_Foods",
                table: "Daily_Foods");

            migrationBuilder.RenameTable(
                name: "Daily_Foods",
                newName: "Daily_Food");

            migrationBuilder.RenameIndex(
                name: "IX_Daily_Foods_UserId",
                table: "Daily_Food",
                newName: "IX_Daily_Food_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Daily_Foods_foodId",
                table: "Daily_Food",
                newName: "IX_Daily_Food_foodId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Daily_Food",
                table: "Daily_Food",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Daily_Food_Food_foodId",
                table: "Daily_Food",
                column: "foodId",
                principalTable: "Food",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Daily_Food_User_UserId",
                table: "Daily_Food",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Food_Change_Daily_Food_Food_ChangedId",
                table: "Food_Change",
                column: "Food_ChangedId",
                principalTable: "Daily_Food",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
