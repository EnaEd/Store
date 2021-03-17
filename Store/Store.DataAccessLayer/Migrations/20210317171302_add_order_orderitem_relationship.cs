using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.DataAccessLayer.Migrations
{
    public partial class add_order_orderitem_relationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AuthorPrintingEdition",
                keyColumns: new[] { "AuthorsId", "PrintingEditionsId" },
                keyValues: new object[] { new Guid("a8ccea31-4544-4c61-a4cf-c94044a41fb0"), new Guid("ef6c2cc1-64e2-4196-9065-9cd59759f0be") });

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("a8ccea31-4544-4c61-a4cf-c94044a41fb0"));

            migrationBuilder.DeleteData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: new Guid("ef6c2cc1-64e2-4196-9065-9cd59759f0be"));

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

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems");

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
                values: new object[] { new Guid("a8ccea31-4544-4c61-a4cf-c94044a41fb0"), false, "TestAuthor" });

            migrationBuilder.InsertData(
                table: "PrintingEditions",
                columns: new[] { "Id", "Currency", "Description", "IsRemoved", "Price", "Status", "Title", "Type" },
                values: new object[] { new Guid("ef6c2cc1-64e2-4196-9065-9cd59759f0be"), "USD", "init desc", false, 1m, "Unpaid", "test Title", "Book" });

            migrationBuilder.InsertData(
                table: "AuthorPrintingEdition",
                columns: new[] { "AuthorsId", "PrintingEditionsId" },
                values: new object[] { new Guid("a8ccea31-4544-4c61-a4cf-c94044a41fb0"), new Guid("ef6c2cc1-64e2-4196-9065-9cd59759f0be") });
        }
    }
}
