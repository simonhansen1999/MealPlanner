using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Madplan.Migrations
{
    /// <inheritdoc />
    public partial class FoodPlanFamilyGroups : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FamilyMember_FamilyId_Email",
                table: "FamilyMember");

            migrationBuilder.AddColumn<int>(
                name: "Permission",
                table: "FamilyMember",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "FoodPlanId",
                table: "FamilyGroups",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMember_FamilyId_Email_Permission",
                table: "FamilyMember",
                columns: new[] { "FamilyId", "Email", "Permission" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FamilyGroups_FoodPlanId",
                table: "FamilyGroups",
                column: "FoodPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyGroups_FoodPlans_FoodPlanId",
                table: "FamilyGroups",
                column: "FoodPlanId",
                principalTable: "FoodPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FamilyGroups_FoodPlans_FoodPlanId",
                table: "FamilyGroups");

            migrationBuilder.DropIndex(
                name: "IX_FamilyMember_FamilyId_Email_Permission",
                table: "FamilyMember");

            migrationBuilder.DropIndex(
                name: "IX_FamilyGroups_FoodPlanId",
                table: "FamilyGroups");

            migrationBuilder.DropColumn(
                name: "Permission",
                table: "FamilyMember");

            migrationBuilder.DropColumn(
                name: "FoodPlanId",
                table: "FamilyGroups");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMember_FamilyId_Email",
                table: "FamilyMember",
                columns: new[] { "FamilyId", "Email" },
                unique: true);
        }
    }
}
