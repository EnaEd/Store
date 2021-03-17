using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.DataAccessLayer.Migrations
{
    public partial class add_order_orderitem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuthorPrintingEdition",
                keyColumns: new[] { "AuthorsId", "PrintingEditionsId" },
                keyValues: new object[] { new Guid("d60182dc-353b-4650-b0ae-97d689874355"), new Guid("7c325872-ade8-4d05-b899-6353368b10c2") });

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("d60182dc-353b-4650-b0ae-97d689874355"));

            migrationBuilder.DeleteData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: new Guid("7c325872-ade8-4d05-b899-6353368b10c2"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "IsRemoved", "Name" },
                values: new object[] { new Guid("d60182dc-353b-4650-b0ae-97d689874355"), false, "TestAuthor" });

            migrationBuilder.InsertData(
                table: "PrintingEditions",
                columns: new[] { "Id", "Currency", "Description", "IsRemoved", "Price", "Status", "Title", "Type" },
                values: new object[] { new Guid("7c325872-ade8-4d05-b899-6353368b10c2"), "USD", "init desc", false, 1m, "Unpaid", "test Title", "Book" });

            migrationBuilder.InsertData(
                table: "AuthorPrintingEdition",
                columns: new[] { "AuthorsId", "PrintingEditionsId" },
                values: new object[] { new Guid("d60182dc-353b-4650-b0ae-97d689874355"), new Guid("7c325872-ade8-4d05-b899-6353368b10c2") });
        }
    }
}
