using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryDB.Migrations
{
    public partial class LinksUpdateInfo2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DetailNode_Description",
                table: "BaseInfoObjects");

            migrationBuilder.DropColumn(
                name: "DetailNode_Name",
                table: "BaseInfoObjects");

            migrationBuilder.DropColumn(
                name: "DetailNode_Number",
                table: "BaseInfoObjects");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DetailNode_Description",
                table: "BaseInfoObjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DetailNode_Name",
                table: "BaseInfoObjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DetailNode_Number",
                table: "BaseInfoObjects",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
