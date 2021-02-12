using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.DataAccessLayer.Migrations
{
    public partial class change_prop_for_many_to_many : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("1be2f781-c3f3-4848-8757-07fac95bae47"));

            migrationBuilder.DeleteData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: new Guid("b2b846d3-5752-4cae-aa18-db0a058f3608"));

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "IsRemoved", "Name" },
                values: new object[] { new Guid("b5bce4b6-15d1-4c7f-88eb-cf60733f8ff5"), false, "TestAuthor" });

            migrationBuilder.InsertData(
                table: "PrintingEditions",
                columns: new[] { "Id", "Currency", "Description", "IsRemoved", "Price", "Status", "Title", "Type" },
                values: new object[] { new Guid("6c172b46-dd45-4fd8-9027-ea6d6604b50a"), "USD", "init desc", false, 1m, "Unpaid", "test Title", "Book" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("b5bce4b6-15d1-4c7f-88eb-cf60733f8ff5"));

            migrationBuilder.DeleteData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: new Guid("6c172b46-dd45-4fd8-9027-ea6d6604b50a"));

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "IsRemoved", "Name" },
                values: new object[] { new Guid("1be2f781-c3f3-4848-8757-07fac95bae47"), false, "TestAuthor" });

            migrationBuilder.InsertData(
                table: "PrintingEditions",
                columns: new[] { "Id", "Currency", "Description", "IsRemoved", "Price", "Status", "Title", "Type" },
                values: new object[] { new Guid("b2b846d3-5752-4cae-aa18-db0a058f3608"), "USD", "init desc", false, 1m, "Unpaid", "test Title", "Book" });
        }
    }
}
