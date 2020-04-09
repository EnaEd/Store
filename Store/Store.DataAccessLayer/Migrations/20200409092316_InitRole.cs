using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.DataAccessLayer.Migrations
{
    public partial class InitRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("ac5112d5-83ec-4fe6-91b7-340f349f5e50"));

            migrationBuilder.DeleteData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: new Guid("e37004ab-6180-4bc6-ae6c-41bb6256be09"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("ddc55bd5-c882-479f-b00a-55a844762ce7"), "0d389497-e3c7-453a-b2f2-2a3a6ef6ce06", "Admin", "ADMIN" },
                    { new Guid("c4a192bc-ef6f-41a9-876e-5dd56ac33147"), "58079b3b-62b4-45a7-8918-762ea08a4d72", "Client", "CLIENT" }
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "IsRemoved", "Name" },
                values: new object[] { new Guid("664cc439-7c25-4dd6-a392-86334c0801bb"), false, "TestAuthor" });

            migrationBuilder.InsertData(
                table: "PrintingEditions",
                columns: new[] { "Id", "Currency", "Description", "IsRemoved", "Price", "Status", "Title", "Type" },
                values: new object[] { new Guid("ba198e1f-d81c-42d5-9b2f-4eb706449481"), "USD", "init desc", false, 1m, "Unpaid", "test Title", "Book" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c4a192bc-ef6f-41a9-876e-5dd56ac33147"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ddc55bd5-c882-479f-b00a-55a844762ce7"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("664cc439-7c25-4dd6-a392-86334c0801bb"));

            migrationBuilder.DeleteData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: new Guid("ba198e1f-d81c-42d5-9b2f-4eb706449481"));

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "IsRemoved", "Name" },
                values: new object[] { new Guid("ac5112d5-83ec-4fe6-91b7-340f349f5e50"), false, "TestAuthor" });

            migrationBuilder.InsertData(
                table: "PrintingEditions",
                columns: new[] { "Id", "Currency", "Description", "IsRemoved", "Price", "Status", "Title", "Type" },
                values: new object[] { new Guid("e37004ab-6180-4bc6-ae6c-41bb6256be09"), "USD", "init desc", false, 1m, "Unpaid", "test Title", "Book" });
        }
    }
}
