using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Madplan.Migrations
{
    /// <inheritdoc />
    public partial class RemoveFamilyGroupFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodPlanFamilyGroupShares_FamilyGroups_FamilyGroupId",
                table: "FoodPlanFamilyGroupShares");

            migrationBuilder.DropForeignKey(
                name: "FK_IndividualPermissions_FoodPlanFamilyGroupShares_FoodPlanFamilyGroupShare",
                table: "IndividualPermissions");

            migrationBuilder.RenameColumn(
                name: "FoodPlanFamilyGroupShare",
                table: "IndividualPermissions",
                newName: "FoodPlanFamilyGroupShareId");

            migrationBuilder.RenameIndex(
                name: "IX_IndividualPermissions_FoodPlanFamilyGroupShare",
                table: "IndividualPermissions",
                newName: "IX_IndividualPermissions_FoodPlanFamilyGroupShareId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodPlanFamilyGroupShares_FamilyGroups_FamilyGroupId",
                table: "FoodPlanFamilyGroupShares",
                column: "FamilyGroupId",
                principalTable: "FamilyGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IndividualPermissions_FoodPlanFamilyGroupShares_FoodPlanFamilyGroupShareId",
                table: "IndividualPermissions",
                column: "FoodPlanFamilyGroupShareId",
                principalTable: "FoodPlanFamilyGroupShares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodPlanFamilyGroupShares_FamilyGroups_FamilyGroupId",
                table: "FoodPlanFamilyGroupShares");

            migrationBuilder.DropForeignKey(
                name: "FK_IndividualPermissions_FoodPlanFamilyGroupShares_FoodPlanFamilyGroupShareId",
                table: "IndividualPermissions");

            migrationBuilder.RenameColumn(
                name: "FoodPlanFamilyGroupShareId",
                table: "IndividualPermissions",
                newName: "FoodPlanFamilyGroupShare");

            migrationBuilder.RenameIndex(
                name: "IX_IndividualPermissions_FoodPlanFamilyGroupShareId",
                table: "IndividualPermissions",
                newName: "IX_IndividualPermissions_FoodPlanFamilyGroupShare");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodPlanFamilyGroupShares_FamilyGroups_FamilyGroupId",
                table: "FoodPlanFamilyGroupShares",
                column: "FamilyGroupId",
                principalTable: "FamilyGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_IndividualPermissions_FoodPlanFamilyGroupShares_FoodPlanFamilyGroupShare",
                table: "IndividualPermissions",
                column: "FoodPlanFamilyGroupShare",
                principalTable: "FoodPlanFamilyGroupShares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
