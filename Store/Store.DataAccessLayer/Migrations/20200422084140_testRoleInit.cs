using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Store.DataAccessLayer.Migrations
{
    public partial class testRoleInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("09ba9855-825e-4411-a1f0-11f6a167d9f8"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a7473aed-3401-425a-aa18-a661eae7caf5"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("93982a8c-4200-4c3e-b664-8339aad40993"));

            migrationBuilder.DeleteData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: new Guid("d3bc5004-55a3-4b28-8cd5-0bb5f973d036"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("62e4780d-1882-4c27-af2f-5094d8d1ed61"), "0aa3949c-4d7b-4c6b-977b-fea2211b73fa", "Admin", "ADMIN" },
                    { new Guid("816bb7d2-6657-4b13-905e-720c92a95ded"), "9bcc165f-5373-4222-a8a5-50942f0b4c0c", "Client", "CLIENT" }
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("09ba9855-825e-4411-a1f0-11f6a167d9f8"), "1574612a-8c19-456b-a35d-c6b12959aa4f", "Admin", "ADMIN" },
                    { new Guid("a7473aed-3401-425a-aa18-a661eae7caf5"), "e995cb81-5d41-4e28-806b-b5c0411d9610", "Client", "CLIENT" }
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "IsRemoved", "Name" },
                values: new object[] { new Guid("93982a8c-4200-4c3e-b664-8339aad40993"), false, "TestAuthor" });

            migrationBuilder.InsertData(
                table: "PrintingEditions",
                columns: new[] { "Id", "Currency", "Description", "IsRemoved", "Price", "Status", "Title", "Type" },
                values: new object[] { new Guid("d3bc5004-55a3-4b28-8cd5-0bb5f973d036"), "USD", "init desc", false, 1m, "Unpaid", "test Title", "Book" });
        }
    }
}
