using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Store.DataAccessLayer.Migrations
{
    public partial class AddRefreshToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

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
    }
}
