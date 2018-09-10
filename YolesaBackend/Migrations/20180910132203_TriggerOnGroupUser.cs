using Microsoft.EntityFrameworkCore.Migrations;

namespace YolesaBackend.Migrations
{
    public partial class TriggerOnGroupUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE TRIGGER tr_groupUser ON GroupUser AFTER UPDATE AS UPDATE GroupUser SET DateModified = GetDate() FROM GroupUser INNER JOIN inserted ON GroupUser.GroupUserID = inserted.GroupUserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER tr_groupUser");
        }
    }
}
