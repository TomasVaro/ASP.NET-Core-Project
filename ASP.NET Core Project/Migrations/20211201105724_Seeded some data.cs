using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP.NET_Core_Project.Migrations
{
    public partial class Seededsomedata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonId", "City", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "Stockholm", "Pelle", "123-456 78 90" },
                    { 2, "Umeå", "Lisa", "098-765 43 21" },
                    { 3, "Göteborg", "Gustav", "023-987 43 25" },
                    { 4, "Göteborg", "Åke", "023-543 78 35" },
                    { 5, "Umeå", "Nicklas", "070-992 12 84" },
                    { 6, "Stockholm", "Åsa", "072-375 16 92" },
                    { 7, "Uppsala", "Per", "023-530 32 39" },
                    { 8, "Stockholm", "Lotta", "123-937 33 94" },
                    { 9, "Göteborg", "Mona", "131-729 38 66" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "PersonId",
                keyValue: 9);
        }
    }
}
