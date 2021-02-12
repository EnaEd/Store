using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Store.DataAccessLayer.Migrations
{
    public partial class remove_subtitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("1be2f781-c3f3-4848-8757-07fac95bae47"), false, "TestAuthor" });

            migrationBuilder.InsertData(
                table: "PrintingEditions",
                columns: new[] { "Id", "Currency", "Description", "IsRemoved", "Price", "Status", "Title", "Type" },
                values: new object[] { new Guid("b2b846d3-5752-4cae-aa18-db0a058f3608"), "USD", "init desc", false, 1m, "Unpaid", "test Title", "Book" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("1be2f781-c3f3-4848-8757-07fac95bae47"));

            migrationBuilder.DeleteData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: new Guid("b2b846d3-5752-4cae-aa18-db0a058f3608"));

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
    }
}
