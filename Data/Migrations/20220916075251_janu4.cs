using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineSweetShop.Data.Migrations
{
    public partial class janu4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "paymentmode",
                table: "Order",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Offer_prodID",
                table: "Offer",
                column: "prodID");

            migrationBuilder.AddForeignKey(
                name: "FK_Offer_SweetProduct_prodID",
                table: "Offer",
                column: "prodID",
                principalTable: "SweetProduct",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offer_SweetProduct_prodID",
                table: "Offer");

            migrationBuilder.DropIndex(
                name: "IX_Offer_prodID",
                table: "Offer");

            migrationBuilder.DropColumn(
                name: "paymentmode",
                table: "Order");
        }
    }
}
