using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP.NET_Core_Project.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(maxLength: 50, nullable: false),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_City_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Phone = table.Column<string>(maxLength: 50, nullable: false),
                    CityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_People_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "CountryId", "Country" },
                values: new object[] { 1, "Sweden" });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "CountryId", "Country" },
                values: new object[] { 2, "Denmark" });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "CountryId", "Country" },
                values: new object[] { 3, "Norway" });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityId", "City", "CountryId" },
                values: new object[,]
                {
                    { 1, "Gothenburg", 1 },
                    { 2, "Stockholm", 1 },
                    { 3, "Uppsala", 1 },
                    { 5, "Copenhagen", 2 },
                    { 7, "Skagen", 2 },
                    { 4, "Oslo", 3 },
                    { 6, "Trondheim", 3 }
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "PersonId", "CityId", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, 1, "Pelle", "123-456 78 90" },
                    { 2, 1, "Lisa", "098-765 43 21" },
                    { 6, 1, "Åsa", "072-375 16 92" },
                    { 3, 2, "Gustav", "023-987 43 25" },
                    { 7, 2, "Per", "023-530 32 39" },
                    { 4, 3, "Åke", "023-543 78 35" },
                    { 5, 4, "Nicklas", "070-992 12 84" },
                    { 9, 4, "Mona", "131-729 38 66" },
                    { 8, 6, "Lotta", "123-937 33 94" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_City_CountryId",
                table: "City",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_People_CityId",
                table: "People",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
