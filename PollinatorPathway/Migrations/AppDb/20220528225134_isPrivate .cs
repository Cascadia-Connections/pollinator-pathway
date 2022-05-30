using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PollinatorPathway.Migrations.AppDb
{
    public partial class isPrivate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IsPrivate",
                table: "UserProfiles",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPrivate",
                table: "UserProfiles");
        }
    }
}
