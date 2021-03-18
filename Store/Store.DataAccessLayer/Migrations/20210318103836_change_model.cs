using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.DataAccessLayer.Migrations
{
    public partial class change_model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "TransactionId",
                table: "Payments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<int>(
                name: "PayStatus",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "IsRemoved", "Name" },
                values: new object[] { new Guid("8298108c-2d1d-4490-b6e3-7a0c0353c741"), false, "TestAuthor" });

            migrationBuilder.InsertData(
                table: "PrintingEditions",
                columns: new[] { "Id", "Currency", "Description", "IsRemoved", "Price", "Status", "Title", "Type" },
                values: new object[] { new Guid("b19f99cc-6add-4955-a7fc-f9b741258dba"), "USD", "init desc", false, 1m, "Unpaid", "test Title", "Book" });

            migrationBuilder.InsertData(
                table: "AuthorPrintingEdition",
                columns: new[] { "AuthorsId", "PrintingEditionsId" },
                values: new object[] { new Guid("8298108c-2d1d-4490-b6e3-7a0c0353c741"), new Guid("b19f99cc-6add-4955-a7fc-f9b741258dba") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuthorPrintingEdition",
                keyColumns: new[] { "AuthorsId", "PrintingEditionsId" },
                keyValues: new object[] { new Guid("8298108c-2d1d-4490-b6e3-7a0c0353c741"), new Guid("b19f99cc-6add-4955-a7fc-f9b741258dba") });

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("8298108c-2d1d-4490-b6e3-7a0c0353c741"));

            migrationBuilder.DeleteData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: new Guid("b19f99cc-6add-4955-a7fc-f9b741258dba"));

            migrationBuilder.DropColumn(
                name: "PayStatus",
                table: "Orders");

            migrationBuilder.AlterColumn<Guid>(
                name: "TransactionId",
                table: "Payments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
    }
}
