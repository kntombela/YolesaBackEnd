using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace YolesaBackend.Migrations
{
    public partial class TableTriggers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE TRIGGER tr_lead ON Lead AFTER UPDATE AS UPDATE Lead SET DateModified = GetDate() FROM Lead INNER JOIN inserted ON Lead.LeadID = inserted.LeadID");

            migrationBuilder.Sql("CREATE TRIGGER tr_group ON [Group] AFTER UPDATE AS UPDATE [Group] SET DateModified = GetDate() FROM [Group] INNER JOIN inserted ON [Group].GroupID = inserted.GroupID");

            migrationBuilder.Sql("CREATE TRIGGER tr_member ON Member AFTER UPDATE AS UPDATE Member SET DateModified = GetDate() FROM Member INNER JOIN inserted ON Member.MemberID = inserted.MemberID");

            migrationBuilder.Sql("CREATE TRIGGER tr_beneficiary ON Beneficiary AFTER UPDATE AS UPDATE Beneficiary SET DateModified = GetDate() FROM Beneficiary INNER JOIN inserted ON Beneficiary.BeneficiaryID = inserted.BeneficiaryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER tr_lead");

            migrationBuilder.Sql("DROP TRIGGER tr_group");

            migrationBuilder.Sql("DROP TRIGGER tr_member");

            migrationBuilder.Sql("DROP TRIGGER tr_beneficiary");
        }
    }
}
