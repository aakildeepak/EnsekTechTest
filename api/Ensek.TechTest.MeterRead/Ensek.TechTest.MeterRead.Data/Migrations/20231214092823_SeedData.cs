using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ensek.TechTest.MeterRead.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserAccount",
                columns: new[] { "Id", "AccountId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, 2344, "Tommy", "Test" },
                    { 2, 2233, "Barry", "Test" },
                    { 3, 8766, "Sally", "Test" },
                    { 4, 2345, "Jerry", "Test" },
                    { 5, 2346, "Ollie", "Test" },
                    { 6, 2347, "Tara", "Test" },
                    { 7, 2348, "Tammy", "Test" },
                    { 8, 2349, "Simon", "Test" },
                    { 9, 2350, "Colin", "Test" },
                    { 10, 2351, "Gladys", "Test" },
                    { 11, 2352, "Greg", "Test" },
                    { 12, 2353, "Tony", "Test" },
                    { 13, 2355, "Arthur", "Test" },
                    { 14, 2356, "Craig", "Test" },
                    { 15, 6776, "Laura", "Test" },
                    { 16, 4534, "JOSH", "Test" },
                    { 17, 1234, "Freya", "Test" },
                    { 18, 1239, "Noddy", "Test" },
                    { 19, 1240, "Archie", "Test" },
                    { 20, 1241, "Lara", "Test" },
                    { 21, 1242, "Tim", "Test" },
                    { 22, 1243, "Graham", "Test" },
                    { 23, 1244, "Tony", "Test" },
                    { 24, 1245, "Neville", "Test" },
                    { 25, 1246, "Jo", "Test" },
                    { 26, 1247, "Jim", "Test" },
                    { 27, 1248, "Pam", "Test" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserAccount",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserAccount",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserAccount",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserAccount",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UserAccount",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "UserAccount",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "UserAccount",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "UserAccount",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "UserAccount",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "UserAccount",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "UserAccount",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "UserAccount",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "UserAccount",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "UserAccount",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "UserAccount",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "UserAccount",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "UserAccount",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "UserAccount",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "UserAccount",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "UserAccount",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "UserAccount",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "UserAccount",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "UserAccount",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "UserAccount",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "UserAccount",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "UserAccount",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "UserAccount",
                keyColumn: "Id",
                keyValue: 27);
        }
    }
}
