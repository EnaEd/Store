using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.DataAccessLayer.Migrations
{
    public partial class addOrderEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsRemoved = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    PaymentId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
