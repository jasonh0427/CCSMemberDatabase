using Microsoft.EntityFrameworkCore.Migrations;

namespace MemberDatabase.Migrations
{
    public partial class SpouseMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Spouse",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Spouse",
                table: "AspNetUsers");
        }
    }
}
