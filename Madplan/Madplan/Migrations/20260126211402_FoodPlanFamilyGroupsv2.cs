using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Madplan.Migrations
{
    /// <inheritdoc />
    public partial class FoodPlanFamilyGroupsv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUserSettings_Users_AppUserId",
                table: "AppUserSettings");

            migrationBuilder.DropForeignKey(
                name: "FK_FamilyGroups_FoodPlans_FoodPlanId",
                table: "FamilyGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_FamilyMember_FamilyGroups_FamilyId",
                table: "FamilyMember");

            migrationBuilder.DropIndex(
                name: "IX_FamilyGroups_FoodPlanId",
                table: "FamilyGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FamilyMember",
                table: "FamilyMember");

            migrationBuilder.DropIndex(
                name: "IX_FamilyMember_FamilyId_Email_Permission",
                table: "FamilyMember");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUserSettings",
                table: "AppUserSettings");

            migrationBuilder.DropColumn(
                name: "FoodPlanId",
                table: "FamilyGroups");

            migrationBuilder.DropColumn(
                name: "Permission",
                table: "FamilyMember");

            migrationBuilder.RenameTable(
                name: "FamilyMember",
                newName: "FamilyMembers");

            migrationBuilder.RenameTable(
                name: "AppUserSettings",
                newName: "UserSettings");

            migrationBuilder.RenameIndex(
                name: "IX_AppUserSettings_AppUserId",
                table: "UserSettings",
                newName: "IX_UserSettings_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FamilyMembers",
                table: "FamilyMembers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSettings",
                table: "UserSettings",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "FoodPlanFamilyGroupShares",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FoodPlanId = table.Column<Guid>(type: "TEXT", nullable: false),
                    FamilyGroupId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Permission = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodPlanFamilyGroupShares", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodPlanFamilyGroupShares_FamilyGroups_FamilyGroupId",
                        column: x => x.FamilyGroupId,
                        principalTable: "FamilyGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FoodPlanFamilyGroupShares_FoodPlans_FoodPlanId",
                        column: x => x.FoodPlanId,
                        principalTable: "FoodPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMembers_FamilyId_Email",
                table: "FamilyMembers",
                columns: new[] { "FamilyId", "Email" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FoodPlanFamilyGroupShares_FamilyGroupId",
                table: "FoodPlanFamilyGroupShares",
                column: "FamilyGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodPlanFamilyGroupShares_FoodPlanId_FamilyGroupId",
                table: "FoodPlanFamilyGroupShares",
                columns: new[] { "FoodPlanId", "FamilyGroupId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyMembers_FamilyGroups_FamilyId",
                table: "FamilyMembers",
                column: "FamilyId",
                principalTable: "FamilyGroups",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FamilyMembers_FamilyGroups_FamilyId",
                table: "FamilyMembers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserSettings_Users_AppUserId",
                table: "UserSettings");

            migrationBuilder.DropTable(
                name: "FoodPlanFamilyGroupShares");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSettings",
                table: "UserSettings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FamilyMembers",
                table: "FamilyMembers");

            migrationBuilder.DropIndex(
                name: "IX_FamilyMembers_FamilyId_Email",
                table: "FamilyMembers");

            migrationBuilder.RenameTable(
                name: "UserSettings",
                newName: "AppUserSettings");

            migrationBuilder.RenameTable(
                name: "FamilyMembers",
                newName: "FamilyMember");

            migrationBuilder.RenameIndex(
                name: "IX_UserSettings_AppUserId",
                table: "AppUserSettings",
                newName: "IX_AppUserSettings_AppUserId");

            migrationBuilder.AddColumn<Guid>(
                name: "FoodPlanId",
                table: "FamilyGroups",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Permission",
                table: "FamilyMember",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUserSettings",
                table: "AppUserSettings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FamilyMember",
                table: "FamilyMember",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyGroups_FoodPlanId",
                table: "FamilyGroups",
                column: "FoodPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMember_FamilyId_Email_Permission",
                table: "FamilyMember",
                columns: new[] { "FamilyId", "Email", "Permission" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserSettings_Users_AppUserId",
                table: "AppUserSettings",
                column: "AppUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyGroups_FoodPlans_FoodPlanId",
                table: "FamilyGroups",
                column: "FoodPlanId",
                principalTable: "FoodPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FamilyMember_FamilyGroups_FamilyId",
                table: "FamilyMember",
                column: "FamilyId",
                principalTable: "FamilyGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
