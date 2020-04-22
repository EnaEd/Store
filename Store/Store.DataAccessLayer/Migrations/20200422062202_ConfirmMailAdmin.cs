using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.DataAccessLayer.Migrations
{
    public partial class ConfirmMailAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("62e4780d-1882-4c27-af2f-5094d8d1ed61"), "1ca021fa-515b-41dc-84ff-ce18e0052557", "Admin", "ADMIN" },
                    { new Guid("816bb7d2-6657-4b13-905e-720c92a95ded"), "13827d02-b4d2-42f7-b07a-94d90efbaa18", "Client", "CLIENT" }
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "IsRemoved", "Name" },
                values: new object[] { new Guid("8d3298f8-f176-47bb-9a77-d792f1eebef5"), false, "TestAuthor" });

            migrationBuilder.InsertData(
                table: "PrintingEditions",
                columns: new[] { "Id", "Currency", "Description", "IsRemoved", "Price", "Status", "Title", "Type" },
                values: new object[] { new Guid("dd7e7d29-029b-41d4-961d-088717afc0fc"), "USD", "init desc", false, 1m, "Unpaid", "test Title", "Book" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("62e4780d-1882-4c27-af2f-5094d8d1ed61"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("816bb7d2-6657-4b13-905e-720c92a95ded"));

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("8d3298f8-f176-47bb-9a77-d792f1eebef5"));

            migrationBuilder.DeleteData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: new Guid("dd7e7d29-029b-41d4-961d-088717afc0fc"));

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
    }
}
