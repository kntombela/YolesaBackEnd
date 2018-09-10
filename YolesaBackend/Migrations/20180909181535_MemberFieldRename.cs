using Microsoft.EntityFrameworkCore.Migrations;

namespace YolesaBackend.Migrations
{
    public partial class MemberFieldRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ChronicILLnessDetails",
                table: "Member",
                newName: "ChronicIllnessDetails");

            migrationBuilder.RenameColumn(
                name: "HasChroniclLLness",
                table: "Member",
                newName: "HasChronicIllness");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ChronicIllnessDetails",
                table: "Member",
                newName: "ChronicILLnessDetails");

            migrationBuilder.RenameColumn(
                name: "HasChronicIllness",
                table: "Member",
                newName: "HasChroniclLLness");
        }
    }
}
