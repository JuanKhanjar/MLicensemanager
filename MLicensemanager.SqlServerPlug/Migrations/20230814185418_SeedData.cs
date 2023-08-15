using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MLicensemanager.SqlServerPlug.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerID", "Adress", "Email", "Title" },
                values: new object[,]
                {
                    { 1, "Agade 12", "a@gmail.com", "Aarhus Kommune" },
                    { 2, "Vgade 12", "v@gmail.com", "Vejle Kommune" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "GroupID", "EAN" },
                values: new object[,]
                {
                    { 1, "19781" },
                    { 2, "19782" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Miralix Desktop 330", 10.99m },
                    { 2, "Miralix Go 12", 20.50m }
                });

            migrationBuilder.InsertData(
                table: "CustomerGroups",
                columns: new[] { "Id", "CustomerID", "GroupID" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "GroupProducts",
                columns: new[] { "Id", "GroupID", "ProductID" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 2, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "GroupProducts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "GroupProducts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "GroupProducts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "GroupID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "GroupID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 2);
        }
    }
}
