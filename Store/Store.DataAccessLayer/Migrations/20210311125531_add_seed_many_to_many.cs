using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.DataAccessLayer.Migrations
{
    public partial class add_seed_many_to_many : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("6d5f6f1c-f8bc-4c3f-bd7d-13f3e3d31c18"));

            migrationBuilder.DeleteData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: new Guid("b779e755-3b0f-4188-9cb7-c498bb03804e"));

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "IsRemoved", "Name" },
                values: new object[] { new Guid("77a95f07-c2bd-46be-ab30-a67bd4ed7b5f"), false, "TestAuthor" });

            migrationBuilder.InsertData(
                table: "PrintingEditions",
                columns: new[] { "Id", "Currency", "Description", "IsRemoved", "Price", "Status", "Title", "Type" },
                values: new object[] { new Guid("b68096e2-8144-4c0d-a050-413fbffd163a"), "USD", "init desc", false, 1m, "Unpaid", "test Title", "Book" });

            migrationBuilder.InsertData(
                table: "AuthorPrintingEdition",
                columns: new[] { "AuthorsId", "PrintingEditionsId" },
                values: new object[] { new Guid("77a95f07-c2bd-46be-ab30-a67bd4ed7b5f"), new Guid("b68096e2-8144-4c0d-a050-413fbffd163a") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuthorPrintingEdition",
                keyColumns: new[] { "AuthorsId", "PrintingEditionsId" },
                keyValues: new object[] { new Guid("77a95f07-c2bd-46be-ab30-a67bd4ed7b5f"), new Guid("b68096e2-8144-4c0d-a050-413fbffd163a") });

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("77a95f07-c2bd-46be-ab30-a67bd4ed7b5f"));

            migrationBuilder.DeleteData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: new Guid("b68096e2-8144-4c0d-a050-413fbffd163a"));

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "IsRemoved", "Name" },
                values: new object[] { new Guid("6d5f6f1c-f8bc-4c3f-bd7d-13f3e3d31c18"), false, "TestAuthor" });

            migrationBuilder.InsertData(
                table: "PrintingEditions",
                columns: new[] { "Id", "Currency", "Description", "IsRemoved", "Price", "Status", "Title", "Type" },
                values: new object[] { new Guid("b779e755-3b0f-4188-9cb7-c498bb03804e"), "USD", "init desc", false, 1m, "Unpaid", "test Title", "Book" });
        }
    }
}
