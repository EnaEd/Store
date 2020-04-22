using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.DataAccessLayer.Migrations
{
    public partial class deleteSeedRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5507121e-f665-401b-8c10-81d54833eb25"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7b659a02-572c-485c-94cf-a843bc89a273"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("56a04ad3-b0e1-4afd-960c-86c9920cc52a"));

            migrationBuilder.DeleteData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: new Guid("4f3407e6-e884-4dd4-9698-b6165c5e9cae"));

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "IsRemoved", "Name" },
                values: new object[] { new Guid("56e10cbd-0e4f-468c-b0bc-efe38a9f241a"), false, "TestAuthor" });

            migrationBuilder.InsertData(
                table: "PrintingEditions",
                columns: new[] { "Id", "Currency", "Description", "IsRemoved", "Price", "Status", "Title", "Type" },
                values: new object[] { new Guid("68982f15-1ca3-4a35-9954-2f9a16f7acdb"), "USD", "init desc", false, 1m, "Unpaid", "test Title", "Book" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("56e10cbd-0e4f-468c-b0bc-efe38a9f241a"));

            migrationBuilder.DeleteData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: new Guid("68982f15-1ca3-4a35-9954-2f9a16f7acdb"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("5507121e-f665-401b-8c10-81d54833eb25"), "0aa3949c-4d7b-4c6b-977b-fea2211b73fa", "Admin", "ADMIN" },
                    { new Guid("7b659a02-572c-485c-94cf-a843bc89a273"), "9bcc165f-5373-4222-a8a5-50942f0b4c0c", "Client", "CLIENT" }
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "IsRemoved", "Name" },
                values: new object[] { new Guid("56a04ad3-b0e1-4afd-960c-86c9920cc52a"), false, "TestAuthor" });

            migrationBuilder.InsertData(
                table: "PrintingEditions",
                columns: new[] { "Id", "Currency", "Description", "IsRemoved", "Price", "Status", "Title", "Type" },
                values: new object[] { new Guid("4f3407e6-e884-4dd4-9698-b6165c5e9cae"), "USD", "init desc", false, 1m, "Unpaid", "test Title", "Book" });
        }
    }
}
