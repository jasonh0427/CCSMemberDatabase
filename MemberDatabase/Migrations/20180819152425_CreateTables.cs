using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MemberDatabase.Migrations
{
    public partial class CreateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Child1",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Child2",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Child3",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Child4",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Parent1",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Parent2",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MemberRelationship",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SourceUser = table.Column<string>(nullable: true),
                    TargetUser = table.Column<string>(nullable: true),
                    Relationship = table.Column<int>(nullable: false),
                    Result = table.Column<int>(nullable: true),
                    ApplyingTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberRelationship", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MemberRelationship");

            migrationBuilder.DropColumn(
                name: "Child1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Child2",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Child3",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Child4",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Parent1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Parent2",
                table: "AspNetUsers");
        }
    }
}
