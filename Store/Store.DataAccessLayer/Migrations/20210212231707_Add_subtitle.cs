using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.DataAccessLayer.Migrations
{
    public partial class Add_subtitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("1f88bfe9-8b75-4802-ba12-883e0a3bcf56"));

            migrationBuilder.DeleteData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: new Guid("c7e6dab1-2486-4e9b-894e-b96ca13011f7"));

            migrationBuilder.AddColumn<string>(
                name: "SubTitleTitle",
                table: "PrintingEditions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "IsRemoved", "Name" },
                values: new object[] { new Guid("85a2deb4-fda3-4318-b461-981f4a80eed9"), false, "TestAuthor" });

            migrationBuilder.InsertData(
                table: "PrintingEditions",
                columns: new[] { "Id", "Currency", "Description", "IsRemoved", "Price", "Status", "SubTitleTitle", "Title", "Type" },
                values: new object[] { new Guid("9af25e1b-68df-414b-8147-1804e1a68316"), "USD", "init desc", false, 1m, "Unpaid", null, "test Title", "Book" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("85a2deb4-fda3-4318-b461-981f4a80eed9"));

            migrationBuilder.DeleteData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: new Guid("9af25e1b-68df-414b-8147-1804e1a68316"));

            migrationBuilder.DropColumn(
                name: "SubTitleTitle",
                table: "PrintingEditions");

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "IsRemoved", "Name" },
                values: new object[] { new Guid("1f88bfe9-8b75-4802-ba12-883e0a3bcf56"), false, "TestAuthor" });

            migrationBuilder.InsertData(
                table: "PrintingEditions",
                columns: new[] { "Id", "Currency", "Description", "IsRemoved", "Price", "Status", "Title", "Type" },
                values: new object[] { new Guid("c7e6dab1-2486-4e9b-894e-b96ca13011f7"), "USD", "init desc", false, 1m, "Unpaid", "test Title", "Book" });
        }
    }
}
