using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryDB.Migrations
{
    public partial class LinksUpdateInfo4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BaseInfoObjects",
                columns: new[] { "Id", "TypeNode", "Description", "Name", "Number" },
                values: new object[,]
                {
                    { 1, 1, "Система магнитная", "СМТШ.684127.064", "СМТШ.684127.064" },
                    { 30, 2, "Полоса", "СМТШ.741171.042-041", "СМТШ.741171.042-041" },
                    { 29, 2, "Полоса", "СМТШ.741171.042-035", "СМТШ.741171.042-035" },
                    { 28, 2, "Полоса", "СМТШ.741171.042-030", "СМТШ.741171.042-030" },
                    { 27, 2, "Полоса", "СМТШ.741171.042-028", "СМТШ.741171.042-028" },
                    { 26, 2, "Полоса", "СМТШ.741171.042-026", "СМТШ.741171.042-026" },
                    { 25, 2, "Полоса", "СМТШ.741171.042-023", "СМТШ.741171.042-023" },
                    { 24, 2, "Полоса", "СМТШ.741171.042-020", "СМТШ.741171.042-020" },
                    { 23, 2, "Полоса", "СМТШ.741171.042-017", "СМТШ.741171.042-017" },
                    { 22, 2, "Полоса", "СМТШ.741171.042-016", "СМТШ.741171.042-016" },
                    { 21, 2, "Полоса", "СМТШ.741171.042-015", "СМТШ.741171.042-015" },
                    { 20, 2, "Полоса", "СМТШ.741171.042-013", "СМТШ.741171.042-013" },
                    { 19, 2, "Полоса", "СМТШ.741171.042-012", "СМТШ.741171.042-012" },
                    { 18, 2, "Полоса", "СМТШ.741171.042-011", "СМТШ.741171.042-011" },
                    { 17, 2, "Полоса", "СМТШ.741171.042-010", "СМТШ.741171.042-010" },
                    { 16, 2, "Полоса", "СМТШ.741171.042-007", "СМТШ.741171.042-007" },
                    { 15, 2, "Полоса", "СМТШ.741171.042-005", "СМТШ.741171.042-005" },
                    { 14, 2, "Полоса", "СМТШ.741171.042-004", "СМТШ.741171.042-004" },
                    { 13, 2, "Полоса", "СМТШ.741171.042-002", "СМТШ.741171.042-002" },
                    { 12, 2, "Полоса", "СМТШ.741171.042-001", "СМТШ.741171.042-001" },
                    { 11, 2, "Полоса", "СМТШ.741171.042", "СМТШ.741171.042" },
                    { 10, 2, "Стержень", "СМТШ.711111.069", "СМТШ.711111.069" },
                    { 9, 2, "Полоса прессующая", "СМТШ.741138.156", "СМТШ.741138.156" },
                    { 8, 2, "Планка", "СМТШ.741291.167", "СМТШ.741291.167" },
                    { 7, 2, "Полоса изоляционная", "СМТШ.741521.439", "СМТШ.741521.439" },
                    { 4, 2, "Кронштейн", "СМТШ.745226.006", "СМТШ.745226.006" },
                    { 3, 2, "Прокладка", "СМТШ.754152.133-001", "СМТШ.754152.133-001" },
                    { 2, 2, "Прокладка", "СМТШ.754152.133", "СМТШ.754152.133" },
                    { 6, 1, "Маслоканал", "СМТШ.686469.442", "СМТШ.686469.442" },
                    { 5, 1, "Полоса прессующая", "СМТШ.301714.081", "СМТШ.301714.081" },
                    { 31, 2, "Полоса", "СМТШ.741171.042-045", "СМТШ.741171.042-045" },
                    { 32, 2, "Полоса", "СМТШ.741171.042-052", "СМТШ.741171.042-052" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BaseInfoObjects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BaseInfoObjects",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "BaseInfoObjects",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "BaseInfoObjects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BaseInfoObjects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BaseInfoObjects",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BaseInfoObjects",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "BaseInfoObjects",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "BaseInfoObjects",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "BaseInfoObjects",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "BaseInfoObjects",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "BaseInfoObjects",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "BaseInfoObjects",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "BaseInfoObjects",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "BaseInfoObjects",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "BaseInfoObjects",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "BaseInfoObjects",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "BaseInfoObjects",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "BaseInfoObjects",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "BaseInfoObjects",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "BaseInfoObjects",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "BaseInfoObjects",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "BaseInfoObjects",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "BaseInfoObjects",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "BaseInfoObjects",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "BaseInfoObjects",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "BaseInfoObjects",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "BaseInfoObjects",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "BaseInfoObjects",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "BaseInfoObjects",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "BaseInfoObjects",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "BaseInfoObjects",
                keyColumn: "Id",
                keyValue: 32);
        }
    }
}
