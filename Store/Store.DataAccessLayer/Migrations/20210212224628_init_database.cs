using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.DataAccessLayer.Migrations
{
    public partial class init_database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorInBooks");

            migrationBuilder.DropTable(
                name: "UserProfileEntity");

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("ff87056f-42fe-4bf0-b146-97e9ffcfad2e"));

            migrationBuilder.DeleteData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: new Guid("91de81d9-6193-42f6-9550-22f0cbd6bbe9"));

            migrationBuilder.CreateTable(
                name: "AuthorPrintingEdition",
                columns: table => new
                {
                    AuthorsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrintingEditionsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorPrintingEdition", x => new { x.AuthorsId, x.PrintingEditionsId });
                    table.ForeignKey(
                        name: "FK_AuthorPrintingEdition_Authors_AuthorsId",
                        column: x => x.AuthorsId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorPrintingEdition_PrintingEditions_PrintingEditionsId",
                        column: x => x.PrintingEditionsId,
                        principalTable: "PrintingEditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "IsRemoved", "Name" },
                values: new object[] { new Guid("1f88bfe9-8b75-4802-ba12-883e0a3bcf56"), false, "TestAuthor" });

            migrationBuilder.InsertData(
                table: "PrintingEditions",
                columns: new[] { "Id", "Currency", "Description", "IsRemoved", "Price", "Status", "Title", "Type" },
                values: new object[] { new Guid("c7e6dab1-2486-4e9b-894e-b96ca13011f7"), "USD", "init desc", false, 1m, "Unpaid", "test Title", "Book" });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorPrintingEdition_PrintingEditionsId",
                table: "AuthorPrintingEdition",
                column: "PrintingEditionsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthorPrintingEdition");

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("1f88bfe9-8b75-4802-ba12-883e0a3bcf56"));

            migrationBuilder.DeleteData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: new Guid("c7e6dab1-2486-4e9b-894e-b96ca13011f7"));

            migrationBuilder.CreateTable(
                name: "AuthorInBooks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRemoved = table.Column<bool>(type: "bit", nullable: false),
                    PrintingEditionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorInBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuthorInBooks_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorInBooks_PrintingEditions_PrintingEditionId",
                        column: x => x.PrintingEditionId,
                        principalTable: "PrintingEditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserProfileEntity",
                columns: table => new
                {
                    CanceledOrdersCount = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastActivity = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrdersCount = table.Column<int>(type: "int", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

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
        }
    }
}
