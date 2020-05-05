using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.DataAccessLayer.Migrations
{
    public partial class Add_CascadeDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("3b6e5332-9b78-4165-bcd2-b1d2c00e889a"));

            migrationBuilder.DeleteData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: new Guid("f203c78e-2fc5-4480-885f-d8a8c68e9d9a"));

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "IsRemoved", "Name" },
                values: new object[] { new Guid("ff87056f-42fe-4bf0-b146-97e9ffcfad2e"), false, "TestAuthor" });

            migrationBuilder.InsertData(
                table: "PrintingEditions",
                columns: new[] { "Id", "Currency", "Description", "IsRemoved", "Price", "Status", "Title", "Type" },
                values: new object[] { new Guid("91de81d9-6193-42f6-9550-22f0cbd6bbe9"), "USD", "init desc", false, 1m, "Unpaid", "test Title", "Book" });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorInBooks_AuthorId",
                table: "AuthorInBooks",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorInBooks_PrintingEditionId",
                table: "AuthorInBooks",
                column: "PrintingEditionId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorInBooks_Authors_AuthorId",
                table: "AuthorInBooks",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AuthorInBooks_PrintingEditions_PrintingEditionId",
                table: "AuthorInBooks",
                column: "PrintingEditionId",
                principalTable: "PrintingEditions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuthorInBooks_Authors_AuthorId",
                table: "AuthorInBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_AuthorInBooks_PrintingEditions_PrintingEditionId",
                table: "AuthorInBooks");

            migrationBuilder.DropIndex(
                name: "IX_AuthorInBooks_AuthorId",
                table: "AuthorInBooks");

            migrationBuilder.DropIndex(
                name: "IX_AuthorInBooks_PrintingEditionId",
                table: "AuthorInBooks");

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("ff87056f-42fe-4bf0-b146-97e9ffcfad2e"));

            migrationBuilder.DeleteData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: new Guid("91de81d9-6193-42f6-9550-22f0cbd6bbe9"));

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "IsRemoved", "Name" },
                values: new object[] { new Guid("3b6e5332-9b78-4165-bcd2-b1d2c00e889a"), false, "TestAuthor" });

            migrationBuilder.InsertData(
                table: "PrintingEditions",
                columns: new[] { "Id", "Currency", "Description", "IsRemoved", "Price", "Status", "Title", "Type" },
                values: new object[] { new Guid("f203c78e-2fc5-4480-885f-d8a8c68e9d9a"), "USD", "init desc", false, 1m, "Unpaid", "test Title", "Book" });
        }
    }
}
