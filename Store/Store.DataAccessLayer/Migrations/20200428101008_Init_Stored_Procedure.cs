using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Store.DataAccessLayer.Migrations
{
    public partial class Init_Stored_Procedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("5f1c1e55-1712-4272-ab11-921bad959e6e"));

            migrationBuilder.DeleteData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: new Guid("83d43989-14ca-46f8-a594-6fda1ed1887b"));

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "IsRemoved", "Name" },
                values: new object[] { new Guid("83bac4f0-e01f-4182-b9c3-ce01bec47bd6"), false, "TestAuthor" });

            migrationBuilder.InsertData(
                table: "PrintingEditions",
                columns: new[] { "Id", "Currency", "Description", "IsRemoved", "Price", "Status", "Title", "Type" },
                values: new object[] { new Guid("3079d13c-5f29-4967-8b47-be460bf1f59d"), "USD", "init desc", false, 1m, "Unpaid", "test Title", "Book" });

            var sp = @" CREATE PROCEDURE[dbo].[spGetFilteredUser]
                        @FirstName nvarchar(50),
                        @LastName nvarchar(50),
                        @Email nvarchar(50),
                        @LastActivity datetime2,
                        @LastOrderDate datetime2,
                        @ReigstrationDate datetime2,
                        @Role nvarchar(50)

                        AS
                        BEGIN
                        SET NOCOUNT ON;

                        SELECT
                            u.FirstName AS FirstName,
                            u.LastName AS LastName,
                            u.Email AS Email,
                            u.RegistrationDate AS RegistrationDate,
                            r.Name AS Role,
                            o.Date AS LastOrderDate,
                            o.Date AS LastActivity,
                            Count(o.IsCanceled) AS CanceledOrdersCount,
                            Count(o.Id) AS OrdersCount,
                            Sum(oi.Amount) AS OrdersSum
                        
                       FROM dbo.AspNetUsers AS u
                          left join dbo.AspNetUserRoles AS ur ON u.Id= ur.UserId
                          left join dbo.AspNetRoles AS r ON ur.RoleId= r.Id
                          left join dbo.Orders AS o ON u.Id= o.UserId
                          left join dbo.OrderItems AS oi ON o.Id= oi.OrderId
                       WHERE
                          (@Email IS NULL OR (u.Email LIKE '%'+ @Email +'%'))
                          AND
                          (@FirstName IS NULL OR (u.FirstName LIKE '%'+ @FirstName +'%'))
                          AND
                          (@LastName IS NULL OR (u.LastName LIKE '%'+  @LastName +'%'))
                          AND
                          (@LastActivity IS NULL OR(o.Date= @LastActivity))
                          AND
                          (@LastOrderDate IS NULL OR (o.Date= @LastOrderDate))
                          AND
                          (@ReigstrationDate IS NULL OR (u.RegistrationDate= @ReigstrationDate))
                          AND
                          (@Role IS NULL OR (r.Name LIKE '%'+ @Role +'%'))
                          
                       GROUP BY
                          u.FirstName,
                          u.LastName,
                          u.Email,
                          u.RegistrationDate,
                          r.Name ,
                          o.Date ,
                          o.Date
                        
                       END";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("83bac4f0-e01f-4182-b9c3-ce01bec47bd6"));

            migrationBuilder.DeleteData(
                table: "PrintingEditions",
                keyColumn: "Id",
                keyValue: new Guid("3079d13c-5f29-4967-8b47-be460bf1f59d"));

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "IsRemoved", "Name" },
                values: new object[] { new Guid("5f1c1e55-1712-4272-ab11-921bad959e6e"), false, "TestAuthor" });

            migrationBuilder.InsertData(
                table: "PrintingEditions",
                columns: new[] { "Id", "Currency", "Description", "IsRemoved", "Price", "Status", "Title", "Type" },
                values: new object[] { new Guid("83d43989-14ca-46f8-a594-6fda1ed1887b"), "USD", "init desc", false, 1m, "Unpaid", "test Title", "Book" });
        }
    }
}
