using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryDB.Migrations
{
    public partial class LinksUpdateInfo1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "BaseInfoObjects");

            migrationBuilder.AddColumn<int>(
                name: "TypeNode",
                table: "BaseInfoObjects",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeNode",
                table: "BaseInfoObjects");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "BaseInfoObjects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
