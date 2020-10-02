using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryDB.Migrations
{
    public partial class LinksUpdateInfo0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InfoId",
                table: "Links",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BaseInfoObjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Discriminator = table.Column<string>(nullable: false),
                    Number = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    DetailNode_Name = table.Column<string>(nullable: true),
                    DetailNode_Number = table.Column<string>(nullable: true),
                    DetailNode_Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseInfoObjects", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Links_InfoId",
                table: "Links",
                column: "InfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Links_BaseInfoObjects_InfoId",
                table: "Links",
                column: "InfoId",
                principalTable: "BaseInfoObjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Links_BaseInfoObjects_InfoId",
                table: "Links");

            migrationBuilder.DropTable(
                name: "BaseInfoObjects");

            migrationBuilder.DropIndex(
                name: "IX_Links_InfoId",
                table: "Links");

            migrationBuilder.DropColumn(
                name: "InfoId",
                table: "Links");
        }
    }
}
