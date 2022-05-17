using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PollinatorPathway.Migrations.AppDb
{
    public partial class userimagedata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "UserProfiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DateJoined",
                table: "UserProfiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GPS",
                table: "UserProfiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image1",
                table: "UserProfiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image2",
                table: "UserProfiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image3",
                table: "UserProfiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrganizationEmail",
                table: "UserProfiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrganizationName",
                table: "UserProfiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrganizationType",
                table: "UserProfiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlantDesc",
                table: "UserProfiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlantName",
                table: "UserProfiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SocialMedia",
                table: "UserProfiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeamContact",
                table: "UserProfiles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WebsiteLink",
                table: "UserProfiles",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "DateJoined",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "GPS",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "Image1",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "Image2",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "Image3",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "OrganizationEmail",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "OrganizationName",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "OrganizationType",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "PlantDesc",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "PlantName",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "SocialMedia",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "TeamContact",
                table: "UserProfiles");

            migrationBuilder.DropColumn(
                name: "WebsiteLink",
                table: "UserProfiles");
        }
    }
}
