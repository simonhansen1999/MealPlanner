using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Madplan.Migrations
{
    /// <inheritdoc />
    public partial class AddDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientGroup_Recipes_RecipeId",
                table: "IngredientGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_IngredientGroup_Id",
                table: "Ingredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientGroup",
                table: "IngredientGroup");

            migrationBuilder.RenameTable(
                name: "IngredientGroup",
                newName: "IngredientGroups");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientGroup_RecipeId",
                table: "IngredientGroups",
                newName: "IX_IngredientGroups_RecipeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientGroups",
                table: "IngredientGroups",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientGroups_Recipes_RecipeId",
                table: "IngredientGroups",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_IngredientGroups_Id",
                table: "Ingredients",
                column: "Id",
                principalTable: "IngredientGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientGroups_Recipes_RecipeId",
                table: "IngredientGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_IngredientGroups_Id",
                table: "Ingredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientGroups",
                table: "IngredientGroups");

            migrationBuilder.RenameTable(
                name: "IngredientGroups",
                newName: "IngredientGroup");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientGroups_RecipeId",
                table: "IngredientGroup",
                newName: "IX_IngredientGroup_RecipeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientGroup",
                table: "IngredientGroup",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientGroup_Recipes_RecipeId",
                table: "IngredientGroup",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_IngredientGroup_Id",
                table: "Ingredients",
                column: "Id",
                principalTable: "IngredientGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
