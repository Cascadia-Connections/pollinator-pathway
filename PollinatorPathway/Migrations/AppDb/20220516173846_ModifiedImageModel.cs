using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PollinatorPathway.Migrations.AppDb
{
    public partial class ModifiedImageModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UploaderId",
                table: "UploadedImages",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_UploadedImages_UploaderId",
                table: "UploadedImages",
                column: "UploaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_UploadedImages_UserProfiles_UploaderId",
                table: "UploadedImages",
                column: "UploaderId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UploadedImages_UserProfiles_UploaderId",
                table: "UploadedImages");

            migrationBuilder.DropIndex(
                name: "IX_UploadedImages_UploaderId",
                table: "UploadedImages");

            migrationBuilder.DropColumn(
                name: "UploaderId",
                table: "UploadedImages");
        }
    }
}
