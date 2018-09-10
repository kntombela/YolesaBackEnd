using Microsoft.EntityFrameworkCore.Migrations;

namespace YolesaBackend.Migrations
{
    public partial class ModelIdRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MemberID",
                table: "Member",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "LeadID",
                table: "Lead",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "GroupUserID",
                table: "GroupUser",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "GroupID",
                table: "Group",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "BeneficiaryID",
                table: "Beneficiary",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Member",
                newName: "MemberID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Lead",
                newName: "LeadID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "GroupUser",
                newName: "GroupUserID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Group",
                newName: "GroupID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Beneficiary",
                newName: "BeneficiaryID");
        }
    }
}
