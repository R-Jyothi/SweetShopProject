using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineSweetShop.Migrations
{
    public partial class janu3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_SweetProducts_Productid",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_Productid",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "Productid",
                table: "Offers");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_prodID",
                table: "Offers",
                column: "prodID");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_SweetProducts_prodID",
                table: "Offers",
                column: "prodID",
                principalTable: "SweetProducts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_SweetProducts_prodID",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_prodID",
                table: "Offers");

            migrationBuilder.AddColumn<int>(
                name: "Productid",
                table: "Offers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Offers_Productid",
                table: "Offers",
                column: "Productid");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_SweetProducts_Productid",
                table: "Offers",
                column: "Productid",
                principalTable: "SweetProducts",
                principalColumn: "id");
        }
    }
}
