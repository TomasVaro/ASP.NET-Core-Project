using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP.NET_Core_Project.Migrations
{
    public partial class SeededLanguages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Language",
                columns: new[] { "LanguageId", "Language" },
                values: new object[,]
                {
                    { 1, "Swedish" },
                    { 2, "Danish" },
                    { 3, "Norvegian" },
                    { 4, "English" },
                    { 5, "German" },
                    { 6, "French" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Language",
                keyColumn: "LanguageId",
                keyValue: 6);
        }
    }
}
