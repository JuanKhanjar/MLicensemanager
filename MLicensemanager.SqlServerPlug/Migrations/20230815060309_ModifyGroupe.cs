using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MLicensemanager.SqlServerPlug.Migrations
{
    /// <inheritdoc />
    public partial class ModifyGroupe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CustomerGroups",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CustomerGroups",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CustomerGroups",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "CustomerGroups",
                columns: new[] { "Id", "CustomerID", "GroupID" },
                values: new object[,]
                {
                    { 5, 1, 1 },
                    { 6, 1, 2 },
                    { 7, 1, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CustomerGroups",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CustomerGroups",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "CustomerGroups",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.InsertData(
                table: "CustomerGroups",
                columns: new[] { "Id", "CustomerID", "GroupID" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 1, 2 }
                });
        }
    }
}
