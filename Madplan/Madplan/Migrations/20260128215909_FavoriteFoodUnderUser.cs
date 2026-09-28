using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Madplan.Migrations
{
    /// <inheritdoc />
    public partial class FavoriteFoodUnderUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AggregatedItem_ShoppingLists_ShoppingListId",
                table: "AggregatedItem");

            migrationBuilder.DropForeignKey(
                name: "FK_FamilyMembers_FamilyGroups_FamilyId",
                table: "FamilyMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodPlanFamilyGroupShares_FamilyGroups_FamilyGroupId",
                table: "FoodPlanFamilyGroupShares");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodPlanFamilyGroupShares_FoodPlans_FoodPlanId",
                table: "FoodPlanFamilyGroupShares");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodPlanShares_FoodPlans_FoodPlanId",
                table: "FoodPlanShares");

            migrationBuilder.DropForeignKey(
                name: "FK_IndividualPermissions_FoodPlanFamilyGroupShares_FoodPlanFamilyGroupShareId",
                table: "IndividualPermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientGroups_Recipes_RecipeId",
                table: "IngredientGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_IngredientGroups_IngredientGroupId",
                table: "Ingredients");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingLists_Users_UserId",
                table: "ShoppingLists");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSettings_Users_AppUserId",
                table: "UserSettings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSettings",
                table: "UserSettings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingLists",
                table: "ShoppingLists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingredients",
                table: "Ingredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientGroups",
                table: "IngredientGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IndividualPermissions",
                table: "IndividualPermissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodPlanShares",
                table: "FoodPlanShares");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodPlanFamilyGroupShares",
                table: "FoodPlanFamilyGroupShares");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FavoriteFoods",
                table: "FavoriteFoods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FamilyMembers",
                table: "FamilyMembers");

            migrationBuilder.RenameTable(
                name: "UserSettings",
                newName: "AppUserSettings");

            migrationBuilder.RenameTable(
                name: "ShoppingLists",
                newName: "ShoppingList");

            migrationBuilder.RenameTable(
                name: "Ingredients",
                newName: "Ingredient");

            migrationBuilder.RenameTable(
                name: "IngredientGroups",
                newName: "IngredientGroup");

            migrationBuilder.RenameTable(
                name: "IndividualPermissions",
                newName: "IndividualPermission");

            migrationBuilder.RenameTable(
                name: "FoodPlanShares",
                newName: "FoodPlanShare");

            migrationBuilder.RenameTable(
                name: "FoodPlanFamilyGroupShares",
                newName: "FoodPlanFamilyGroupShare");

            migrationBuilder.RenameTable(
                name: "FavoriteFoods",
                newName: "FavoriteFood");

            migrationBuilder.RenameTable(
                name: "FamilyMembers",
                newName: "FamilyMember");

            migrationBuilder.RenameIndex(
                name: "IX_UserSettings_AppUserId",
                table: "AppUserSettings",
                newName: "IX_AppUserSettings_AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingLists_UserId",
                table: "ShoppingList",
                newName: "IX_ShoppingList_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Ingredients_IngredientGroupId",
                table: "Ingredient",
                newName: "IX_Ingredient_IngredientGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientGroups_RecipeId",
                table: "IngredientGroup",
                newName: "IX_IngredientGroup_RecipeId");

            migrationBuilder.RenameIndex(
                name: "IX_IndividualPermissions_FoodPlanFamilyGroupShareId",
                table: "IndividualPermission",
                newName: "IX_IndividualPermission_FoodPlanFamilyGroupShareId");

            migrationBuilder.RenameIndex(
                name: "IX_FoodPlanShares_FoodPlanId",
                table: "FoodPlanShare",
                newName: "IX_FoodPlanShare_FoodPlanId");

            migrationBuilder.RenameIndex(
                name: "IX_FoodPlanFamilyGroupShares_FoodPlanId_FamilyGroupId",
                table: "FoodPlanFamilyGroupShare",
                newName: "IX_FoodPlanFamilyGroupShare_FoodPlanId_FamilyGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_FoodPlanFamilyGroupShares_FamilyGroupId",
                table: "FoodPlanFamilyGroupShare",
                newName: "IX_FoodPlanFamilyGroupShare_FamilyGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_FamilyMembers_FamilyId_Email",
                table: "FamilyMember",
                newName: "IX_FamilyMember_FamilyId_Email");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUserSettings",
                table: "AppUserSettings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingList",
                table: "ShoppingList",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingredient",
                table: "Ingredient",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientGroup",
                table: "IngredientGroup",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IndividualPermission",
                table: "IndividualPermission",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodPlanShare",
                table: "FoodPlanShare",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodPlanFamilyGroupShare",
                table: "FoodPlanFamilyGroupShare",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavoriteFood",
                table: "FavoriteFood",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FamilyMember",
                table: "FamilyMember",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteFood_UserId",
                table: "FavoriteFood",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AggregatedItem_ShoppingList_ShoppingListId",
                table: "AggregatedItem",
                column: "ShoppingListId",
                principalTable: "ShoppingList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserSettings_Users_AppUserId",
                table: "AppUserSettings",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyMember_FamilyGroups_FamilyId",
                table: "FamilyMember",
                column: "FamilyId",
                principalTable: "FamilyGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FavoriteFood_Users_UserId",
                table: "FavoriteFood",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodPlanFamilyGroupShare_FamilyGroups_FamilyGroupId",
                table: "FoodPlanFamilyGroupShare",
                column: "FamilyGroupId",
                principalTable: "FamilyGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodPlanFamilyGroupShare_FoodPlans_FoodPlanId",
                table: "FoodPlanFamilyGroupShare",
                column: "FoodPlanId",
                principalTable: "FoodPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodPlanShare_FoodPlans_FoodPlanId",
                table: "FoodPlanShare",
                column: "FoodPlanId",
                principalTable: "FoodPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IndividualPermission_FoodPlanFamilyGroupShare_FoodPlanFamilyGroupShareId",
                table: "IndividualPermission",
                column: "FoodPlanFamilyGroupShareId",
                principalTable: "FoodPlanFamilyGroupShare",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredient_IngredientGroup_IngredientGroupId",
                table: "Ingredient",
                column: "IngredientGroupId",
                principalTable: "IngredientGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientGroup_Recipes_RecipeId",
                table: "IngredientGroup",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingList_Users_UserId",
                table: "ShoppingList",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AggregatedItem_ShoppingList_ShoppingListId",
                table: "AggregatedItem");

            migrationBuilder.DropForeignKey(
                name: "FK_AppUserSettings_Users_AppUserId",
                table: "AppUserSettings");

            migrationBuilder.DropForeignKey(
                name: "FK_FamilyMember_FamilyGroups_FamilyId",
                table: "FamilyMember");

            migrationBuilder.DropForeignKey(
                name: "FK_FavoriteFood_Users_UserId",
                table: "FavoriteFood");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodPlanFamilyGroupShare_FamilyGroups_FamilyGroupId",
                table: "FoodPlanFamilyGroupShare");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodPlanFamilyGroupShare_FoodPlans_FoodPlanId",
                table: "FoodPlanFamilyGroupShare");

            migrationBuilder.DropForeignKey(
                name: "FK_FoodPlanShare_FoodPlans_FoodPlanId",
                table: "FoodPlanShare");

            migrationBuilder.DropForeignKey(
                name: "FK_IndividualPermission_FoodPlanFamilyGroupShare_FoodPlanFamilyGroupShareId",
                table: "IndividualPermission");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredient_IngredientGroup_IngredientGroupId",
                table: "Ingredient");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientGroup_Recipes_RecipeId",
                table: "IngredientGroup");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingList_Users_UserId",
                table: "ShoppingList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingList",
                table: "ShoppingList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientGroup",
                table: "IngredientGroup");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingredient",
                table: "Ingredient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IndividualPermission",
                table: "IndividualPermission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodPlanShare",
                table: "FoodPlanShare");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FoodPlanFamilyGroupShare",
                table: "FoodPlanFamilyGroupShare");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FavoriteFood",
                table: "FavoriteFood");

            migrationBuilder.DropIndex(
                name: "IX_FavoriteFood_UserId",
                table: "FavoriteFood");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FamilyMember",
                table: "FamilyMember");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUserSettings",
                table: "AppUserSettings");

            migrationBuilder.RenameTable(
                name: "ShoppingList",
                newName: "ShoppingLists");

            migrationBuilder.RenameTable(
                name: "IngredientGroup",
                newName: "IngredientGroups");

            migrationBuilder.RenameTable(
                name: "Ingredient",
                newName: "Ingredients");

            migrationBuilder.RenameTable(
                name: "IndividualPermission",
                newName: "IndividualPermissions");

            migrationBuilder.RenameTable(
                name: "FoodPlanShare",
                newName: "FoodPlanShares");

            migrationBuilder.RenameTable(
                name: "FoodPlanFamilyGroupShare",
                newName: "FoodPlanFamilyGroupShares");

            migrationBuilder.RenameTable(
                name: "FavoriteFood",
                newName: "FavoriteFoods");

            migrationBuilder.RenameTable(
                name: "FamilyMember",
                newName: "FamilyMembers");

            migrationBuilder.RenameTable(
                name: "AppUserSettings",
                newName: "UserSettings");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingList_UserId",
                table: "ShoppingLists",
                newName: "IX_ShoppingLists_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientGroup_RecipeId",
                table: "IngredientGroups",
                newName: "IX_IngredientGroups_RecipeId");

            migrationBuilder.RenameIndex(
                name: "IX_Ingredient_IngredientGroupId",
                table: "Ingredients",
                newName: "IX_Ingredients_IngredientGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_IndividualPermission_FoodPlanFamilyGroupShareId",
                table: "IndividualPermissions",
                newName: "IX_IndividualPermissions_FoodPlanFamilyGroupShareId");

            migrationBuilder.RenameIndex(
                name: "IX_FoodPlanShare_FoodPlanId",
                table: "FoodPlanShares",
                newName: "IX_FoodPlanShares_FoodPlanId");

            migrationBuilder.RenameIndex(
                name: "IX_FoodPlanFamilyGroupShare_FoodPlanId_FamilyGroupId",
                table: "FoodPlanFamilyGroupShares",
                newName: "IX_FoodPlanFamilyGroupShares_FoodPlanId_FamilyGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_FoodPlanFamilyGroupShare_FamilyGroupId",
                table: "FoodPlanFamilyGroupShares",
                newName: "IX_FoodPlanFamilyGroupShares_FamilyGroupId");

            migrationBuilder.RenameIndex(
                name: "IX_FamilyMember_FamilyId_Email",
                table: "FamilyMembers",
                newName: "IX_FamilyMembers_FamilyId_Email");

            migrationBuilder.RenameIndex(
                name: "IX_AppUserSettings_AppUserId",
                table: "UserSettings",
                newName: "IX_UserSettings_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingLists",
                table: "ShoppingLists",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientGroups",
                table: "IngredientGroups",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingredients",
                table: "Ingredients",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IndividualPermissions",
                table: "IndividualPermissions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodPlanShares",
                table: "FoodPlanShares",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FoodPlanFamilyGroupShares",
                table: "FoodPlanFamilyGroupShares",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FavoriteFoods",
                table: "FavoriteFoods",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FamilyMembers",
                table: "FamilyMembers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSettings",
                table: "UserSettings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AggregatedItem_ShoppingLists_ShoppingListId",
                table: "AggregatedItem",
                column: "ShoppingListId",
                principalTable: "ShoppingLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyMembers_FamilyGroups_FamilyId",
                table: "FamilyMembers",
                column: "FamilyId",
                principalTable: "FamilyGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodPlanFamilyGroupShares_FamilyGroups_FamilyGroupId",
                table: "FoodPlanFamilyGroupShares",
                column: "FamilyGroupId",
                principalTable: "FamilyGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodPlanFamilyGroupShares_FoodPlans_FoodPlanId",
                table: "FoodPlanFamilyGroupShares",
                column: "FoodPlanId",
                principalTable: "FoodPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FoodPlanShares_FoodPlans_FoodPlanId",
                table: "FoodPlanShares",
                column: "FoodPlanId",
                principalTable: "FoodPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IndividualPermissions_FoodPlanFamilyGroupShares_FoodPlanFamilyGroupShareId",
                table: "IndividualPermissions",
                column: "FoodPlanFamilyGroupShareId",
                principalTable: "FoodPlanFamilyGroupShares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientGroups_Recipes_RecipeId",
                table: "IngredientGroups",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_IngredientGroups_IngredientGroupId",
                table: "Ingredients",
                column: "IngredientGroupId",
                principalTable: "IngredientGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingLists_Users_UserId",
                table: "ShoppingLists",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserSettings_Users_AppUserId",
                table: "UserSettings",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
