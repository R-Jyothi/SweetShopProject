using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineSweetShop.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Offer",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    prodID = table.Column<int>(type: "int", nullable: false),
                    AmountType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    offer = table.Column<int>(type: "int", nullable: false),
                    sdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    edate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    orderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orderName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.orderId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Offer");

            migrationBuilder.DropTable(
                name: "Order");
        }
    }
}
