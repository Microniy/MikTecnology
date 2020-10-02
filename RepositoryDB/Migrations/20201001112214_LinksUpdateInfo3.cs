using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryDB.Migrations
{
    public partial class LinksUpdateInfo3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LinkParentId",
                table: "Links",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Links_LinkParentId",
                table: "Links",
                column: "LinkParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Links_Links_LinkParentId",
                table: "Links",
                column: "LinkParentId",
                principalTable: "Links",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Links_Links_LinkParentId",
                table: "Links");

            migrationBuilder.DropIndex(
                name: "IX_Links_LinkParentId",
                table: "Links");

            migrationBuilder.DropColumn(
                name: "LinkParentId",
                table: "Links");
        }
    }
}
