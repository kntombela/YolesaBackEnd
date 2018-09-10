using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YolesaBackend.Migrations
{
    public partial class NewModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Lead",
                newName: "LeadID");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "Group",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Group",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Group",
                newName: "GroupID");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Lead",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Lead",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Group",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateModified",
                table: "Group",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Industry",
                table: "Group",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PolicyNumber",
                table: "Group",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    MemberID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<int>(nullable: false),
                    FullNames = table.Column<string>(nullable: false),
                    Surname = table.Column<string>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    IDNumber = table.Column<string>(maxLength: 13, nullable: true),
                    PassportNumber = table.Column<string>(nullable: true),
                    IsSACitizen = table.Column<bool>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    IsEmployed = table.Column<bool>(nullable: false),
                    Employer = table.Column<string>(nullable: true),
                    EmployerContactNumber = table.Column<string>(nullable: true),
                    ContactNumber = table.Column<string>(nullable: false),
                    TelephoneHome = table.Column<string>(nullable: true),
                    OtherContactNumber = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    HasChroniclLLness = table.Column<bool>(nullable: false),
                    ChronicILLnessDetails = table.Column<string>(nullable: true),
                    IsUnderDebtReview = table.Column<bool>(nullable: false),
                    DebtDetails = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    GroupID = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.MemberID);
                    table.ForeignKey(
                        name: "FK_Member_Group_GroupID",
                        column: x => x.GroupID,
                        principalTable: "Group",
                        principalColumn: "GroupID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Beneficiary",
                columns: table => new
                {
                    BeneficiaryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<int>(nullable: false),
                    FullNames = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    IsSACitizen = table.Column<bool>(nullable: false),
                    IDNumber = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    PassportNumber = table.Column<string>(nullable: true),
                    Relationship = table.Column<string>(nullable: true),
                    MemberID = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beneficiary", x => x.BeneficiaryID);
                    table.ForeignKey(
                        name: "FK_Beneficiary_Member_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Member",
                        principalColumn: "MemberID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiary_MemberID",
                table: "Beneficiary",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_Member_GroupID",
                table: "Member",
                column: "GroupID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Beneficiary");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Lead");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Lead");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Group");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Group");

            migrationBuilder.DropColumn(
                name: "Industry",
                table: "Group");

            migrationBuilder.DropColumn(
                name: "PolicyNumber",
                table: "Group");

            migrationBuilder.RenameColumn(
                name: "LeadID",
                table: "Lead",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Group",
                newName: "type");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Group",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "GroupID",
                table: "Group",
                newName: "id");
        }
    }
}
