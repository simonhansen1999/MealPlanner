using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Madplan.Migrations
{
    /// <inheritdoc />
    public partial class AddIndividualPermissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Permission",
                table: "FoodPlanFamilyGroupShares");

            migrationBuilder.CreateTable(
                name: "IndividualPermission",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    FoodPlanFamilyGroupShare = table.Column<Guid>(type: "TEXT", nullable: false),
                    SharePermission = table.Column<int>(type: "INTEGER", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualPermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IndividualPermission_FoodPlanFamilyGroupShares_FoodPlanFamilyGroupShare",
                        column: x => x.FoodPlanFamilyGroupShare,
                        principalTable: "FoodPlanFamilyGroupShares",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IndividualPermission_FoodPlanFamilyGroupShare",
                table: "IndividualPermission",
                column: "FoodPlanFamilyGroupShare");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IndividualPermission");

            migrationBuilder.AddColumn<int>(
                name: "Permission",
                table: "FoodPlanFamilyGroupShares",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
