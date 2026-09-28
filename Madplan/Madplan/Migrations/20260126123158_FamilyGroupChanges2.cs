using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Madplan.Migrations
{
    /// <inheritdoc />
    public partial class FamilyGroupChanges2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FamilyMember_FamilyId",
                table: "FamilyMember");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMember_FamilyId_Email",
                table: "FamilyMember",
                columns: new[] { "FamilyId", "Email" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_FamilyMember_FamilyId_Email",
                table: "FamilyMember");

            migrationBuilder.CreateIndex(
                name: "IX_FamilyMember_FamilyId",
                table: "FamilyMember",
                column: "FamilyId");
        }
    }
}
