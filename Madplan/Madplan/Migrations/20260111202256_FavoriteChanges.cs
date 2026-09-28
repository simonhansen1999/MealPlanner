using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Madplan.Migrations
{
    /// <inheritdoc />
    public partial class FavoriteChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteFood_Users_UserId",
                table: "FavoriteFood");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FavoriteFood",
                table: "FavoriteFood");

            migrationBuilder.DropIndex(
                name: "IX_FavoriteFood_UserId",
                table: "FavoriteFood");

            migrationBuilder.RenameTable(
                name: "FavoriteFood",
                newName: "FavoriteFoods");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavoriteFoods",
                table: "FavoriteFoods",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FavoriteFoods",
                table: "FavoriteFoods");

            migrationBuilder.RenameTable(
                name: "FavoriteFoods",
                newName: "FavoriteFood");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavoriteFood",
                table: "FavoriteFood",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteFood_UserId",
                table: "FavoriteFood",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteFood_Users_UserId",
                table: "FavoriteFood",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
