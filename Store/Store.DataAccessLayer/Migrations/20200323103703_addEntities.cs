using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.DataAccessLayer.Migrations
{
    public partial class addEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid))
                .Annotation("SqlServer:Identity", "1, 1");
        }
    }
}
