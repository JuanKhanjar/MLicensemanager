using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MLicensemanager.SqlServerPlug.Migrations
{
    /// <inheritdoc />
    public partial class ModifyGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GroupName",
                table: "Groups",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "CustomerGroups",
                keyColumn: "Id",
                keyValue: 3,
                column: "CustomerID",
                value: 1);

            migrationBuilder.InsertData(
                table: "CustomerGroups",
                columns: new[] { "Id", "CustomerID", "GroupID" },
                values: new object[] { 4, 2, 2 });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "GroupID",
                keyValue: 1,
                column: "GroupName",
                value: "Sundhed");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "GroupID",
                keyValue: 2,
                column: "GroupName",
                value: "Borgerservice");

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "GroupID", "EAN", "GroupName" },
                values: new object[] { 3, "19783", "Radhus" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CustomerGroups",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "GroupID",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "GroupName",
                table: "Groups");

            migrationBuilder.UpdateData(
                table: "CustomerGroups",
                keyColumn: "Id",
                keyValue: 3,
                column: "CustomerID",
                value: 2);
        }
    }
}
