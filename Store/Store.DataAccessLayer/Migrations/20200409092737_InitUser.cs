using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.DataAccessLayer.Migrations
{
    public partial class InitUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("975cf8b7-7cfd-42b9-849c-459ca94c9206"), "614fd98d-2b57-4c47-9c82-0261d56b47d3", "Admin", "ADMIN" },
                    { new Guid("dfb2b634-6848-43b9-9f65-0361aaa1f3d3"), "6f745cb6-3ec2-45e4-9be7-e8513d4d27a1", "Client", "CLIENT" }
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "IsRemoved", "Name" },
                values: new object[] { new Guid("d89855df-bdbe-4761-baa8-587bc097f6a3"), false, "TestAuthor" });

            migrationBuilder.InsertData(
                table: "PrintingEditions",
                columns: new[] { "Id", "Currency", "Description", "IsRemoved", "Price", "Status", "Title", "Type" },
                values: new object[] { new Guid("7f3ed78d-8e9a-4eee-a8b9-7018d7d67464"), "USD", "init desc", false, 1m, "Unpaid", "test Title", "Book" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("975cf8b7-7cfd-42b9-849c-459ca94c9206"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("dfb2b634-6848-43b9-9f65-0361aaa1f3d3"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("d89855df-bdbe-4761-baa8-587bc097f6a3"));

            migrationBuilder.DeleteData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: new Guid("7f3ed78d-8e9a-4eee-a8b9-7018d7d67464"));

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
    }
}
