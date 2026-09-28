using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Madplan.Migrations
{
    /// <inheritdoc />
    public partial class TryFix2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_IngredientGroups_RecipeId",
                table: "Ingredients");

            migrationBuilder.RenameColumn(
                name: "RecipeId",
                table: "Ingredients",
                newName: "IngredientGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_Ingredients_RecipeId",
                table: "Ingredients",
                newName: "IX_Ingredients_IngredientGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_IngredientGroups_IngredientGroupId",
                table: "Ingredients",
                column: "IngredientGroupId",
                principalTable: "IngredientGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_IngredientGroups_IngredientGroupId",
                table: "Ingredients");

            migrationBuilder.RenameColumn(
                name: "IngredientGroupId",
                table: "Ingredients",
                newName: "RecipeId");

            migrationBuilder.RenameIndex(
                name: "IX_Ingredients_IngredientGroupId",
                table: "Ingredients",
                newName: "IX_Ingredients_RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_IngredientGroups_RecipeId",
                table: "Ingredients",
                column: "RecipeId",
                principalTable: "IngredientGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
