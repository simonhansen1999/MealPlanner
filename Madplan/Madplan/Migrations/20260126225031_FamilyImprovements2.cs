using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Madplan.Migrations
{
    /// <inheritdoc />
    public partial class FamilyImprovements2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_FoodPlanFamilyGroupShares_FamilyGroupId",
                table: "FoodPlanFamilyGroupShares",
                column: "FamilyGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodPlanFamilyGroupShares_FamilyGroups_FamilyGroupId",
                table: "FoodPlanFamilyGroupShares",
                column: "FamilyGroupId",
                principalTable: "FamilyGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodPlanFamilyGroupShares_FamilyGroups_FamilyGroupId",
                table: "FoodPlanFamilyGroupShares");

            migrationBuilder.DropIndex(
                name: "IX_FoodPlanFamilyGroupShares_FamilyGroupId",
                table: "FoodPlanFamilyGroupShares");
        }
    }
}
