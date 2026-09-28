using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Madplan.Migrations
{
    /// <inheritdoc />
    public partial class AddIndividualPermissionsDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IndividualPermission_FoodPlanFamilyGroupShares_FoodPlanFamilyGroupShare",
                table: "IndividualPermission");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IndividualPermission",
                table: "IndividualPermission");

            migrationBuilder.RenameTable(
                name: "IndividualPermission",
                newName: "IndividualPermissions");

            migrationBuilder.RenameIndex(
                name: "IX_IndividualPermission_FoodPlanFamilyGroupShare",
                table: "IndividualPermissions",
                newName: "IX_IndividualPermissions_FoodPlanFamilyGroupShare");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IndividualPermissions",
                table: "IndividualPermissions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IndividualPermissions_FoodPlanFamilyGroupShares_FoodPlanFamilyGroupShare",
                table: "IndividualPermissions",
                column: "FoodPlanFamilyGroupShare",
                principalTable: "FoodPlanFamilyGroupShares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IndividualPermissions_FoodPlanFamilyGroupShares_FoodPlanFamilyGroupShare",
                table: "IndividualPermissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IndividualPermissions",
                table: "IndividualPermissions");

            migrationBuilder.RenameTable(
                name: "IndividualPermissions",
                newName: "IndividualPermission");

            migrationBuilder.RenameIndex(
                name: "IX_IndividualPermissions_FoodPlanFamilyGroupShare",
                table: "IndividualPermission",
                newName: "IX_IndividualPermission_FoodPlanFamilyGroupShare");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IndividualPermission",
                table: "IndividualPermission",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_IndividualPermission_FoodPlanFamilyGroupShares_FoodPlanFamilyGroupShare",
                table: "IndividualPermission",
                column: "FoodPlanFamilyGroupShare",
                principalTable: "FoodPlanFamilyGroupShares",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
