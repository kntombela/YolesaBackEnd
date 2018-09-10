using Microsoft.EntityFrameworkCore.Migrations;

namespace YolesaBackend.Migrations
{
    public partial class GroupNameNotNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Group",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Group",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
