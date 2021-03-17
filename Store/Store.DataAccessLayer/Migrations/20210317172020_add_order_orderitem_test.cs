using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.DataAccessLayer.Migrations
{
    public partial class add_order_orderitem_test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuthorPrintingEdition",
                keyColumns: new[] { "AuthorsId", "PrintingEditionsId" },
                keyValues: new object[] { new Guid("6b275709-571b-46e3-ac4b-b691b7e92806"), new Guid("091b9af0-623d-4049-9cf6-90b4e75daf9f") });

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("6b275709-571b-46e3-ac4b-b691b7e92806"));

            migrationBuilder.DeleteData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: new Guid("091b9af0-623d-4049-9cf6-90b4e75daf9f"));

            migrationBuilder.AddColumn<string>(
                name: "Test",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "IsRemoved", "Name" },
                values: new object[] { new Guid("b3f6b745-4ac8-40a9-840f-b4b04c883e26"), false, "TestAuthor" });

            migrationBuilder.InsertData(
                table: "PrintingEditions",
                columns: new[] { "Id", "Currency", "Description", "IsRemoved", "Price", "Status", "Title", "Type" },
                values: new object[] { new Guid("227c18ee-14c6-4f14-ac54-e9b899bbde66"), "USD", "init desc", false, 1m, "Unpaid", "test Title", "Book" });

            migrationBuilder.InsertData(
                table: "AuthorPrintingEdition",
                columns: new[] { "AuthorsId", "PrintingEditionsId" },
                values: new object[] { new Guid("b3f6b745-4ac8-40a9-840f-b4b04c883e26"), new Guid("227c18ee-14c6-4f14-ac54-e9b899bbde66") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuthorPrintingEdition",
                keyColumns: new[] { "AuthorsId", "PrintingEditionsId" },
                keyValues: new object[] { new Guid("b3f6b745-4ac8-40a9-840f-b4b04c883e26"), new Guid("227c18ee-14c6-4f14-ac54-e9b899bbde66") });

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("b3f6b745-4ac8-40a9-840f-b4b04c883e26"));

            migrationBuilder.DeleteData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: new Guid("227c18ee-14c6-4f14-ac54-e9b899bbde66"));

            migrationBuilder.DropColumn(
                name: "Test",
                table: "Orders");

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "IsRemoved", "Name" },
                values: new object[] { new Guid("6b275709-571b-46e3-ac4b-b691b7e92806"), false, "TestAuthor" });

            migrationBuilder.InsertData(
                table: "PrintingEditions",
                columns: new[] { "Id", "Currency", "Description", "IsRemoved", "Price", "Status", "Title", "Type" },
                values: new object[] { new Guid("091b9af0-623d-4049-9cf6-90b4e75daf9f"), "USD", "init desc", false, 1m, "Unpaid", "test Title", "Book" });

            migrationBuilder.InsertData(
                table: "AuthorPrintingEdition",
                columns: new[] { "AuthorsId", "PrintingEditionsId" },
                values: new object[] { new Guid("6b275709-571b-46e3-ac4b-b691b7e92806"), new Guid("091b9af0-623d-4049-9cf6-90b4e75daf9f") });
        }
    }
}
