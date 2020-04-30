using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Store.DataAccessLayer.Migrations
{
    public partial class Init_spGetFilteredPrintingEdition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("83bac4f0-e01f-4182-b9c3-ce01bec47bd6"));

            migrationBuilder.DeleteData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: new Guid("3079d13c-5f29-4967-8b47-be460bf1f59d"));

            migrationBuilder.CreateTable(
                name: "UserProfileEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    LastActivity = table.Column<DateTime>(nullable: true),
                    RegistrationDate = table.Column<DateTime>(nullable: true),
                    CanceledOrdersCount = table.Column<int>(nullable: false),
                    OrdersCount = table.Column<int>(nullable: false),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "IsRemoved", "Name" },
                values: new object[] { new Guid("3b6e5332-9b78-4165-bcd2-b1d2c00e889a"), false, "TestAuthor" });

            migrationBuilder.InsertData(
                table: "PrintingEditions",
                columns: new[] { "Id", "Currency", "Description", "IsRemoved", "Price", "Status", "Title", "Type" },
                values: new object[] { new Guid("f203c78e-2fc5-4480-885f-d8a8c68e9d9a"), "USD", "init desc", false, 1m, "Unpaid", "test Title", "Book" });

            var sp = @"CREATE PROCEDURE[dbo].[spGetFilteredPrintingEdition]
   
                     @Currency nvarchar(50),
                     @Description nvarchar(450),
                     @Status nvarchar(50),
                     @Title nvarchar(450),
                     @Type nvarchar(50),
                     @MinPrice decimal(18,2),
                     @MaxPrice decimal(18,2),
                     @Author nvarchar(450)
                     
                     AS
                     BEGIN
                     SET NOCOUNT ON;
                     
                     SELECT  *
                     
                     
                     FROM 
                     dbo.PrintingEditions AS PE
                     LEFT JOIN dbo.AuthorInBooks AS AIB ON PE.Id=AIB.PrintingEditionId
                     LEFT JOIN dbo.Authors AS A ON AIB.AuthorId=A.Id
                     WHERE
                     (@Currency IS NULL OR (PE.Currency LIKE '%'+@Currency+'%'))
                     AND
                     (@Description IS NULL OR (PE.Description LIKE '%'+@Description+'%'))
                     AND
                     (@Status IS NULL OR (PE.Status LIKE '%'+@Status+'%'))
                     AND
                     (@Title IS NULL OR (PE.Title LIKE '%'+@Title+'%'))
                     AND
                     ( @MinPrice IS NULL OR (PE.Price>= @MinPrice))
                     AND
                     (@MaxPrice IS NULL OR (PE.Price<=@MaxPrice))
                     AND
                     (@Author IS NULL OR (A.Name LIKE '%'+@Author+'%'))
                     END   ";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserProfileEntity");

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
                values: new object[] { new Guid("83bac4f0-e01f-4182-b9c3-ce01bec47bd6"), false, "TestAuthor" });

            migrationBuilder.InsertData(
                table: "PrintingEditions",
                columns: new[] { "Id", "Currency", "Description", "IsRemoved", "Price", "Status", "Title", "Type" },
                values: new object[] { new Guid("3079d13c-5f29-4967-8b47-be460bf1f59d"), "USD", "init desc", false, 1m, "Unpaid", "test Title", "Book" });


        }
    }
}
