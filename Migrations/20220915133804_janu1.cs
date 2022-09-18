using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineSweetShop.Migrations
{
    public partial class janu1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Productid",
                table: "Offers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Review = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_SweetProducts_Productid",
                table: "Offers");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropIndex(
                name: "IX_Offers_Productid",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "Productid",
                table: "Offers");
        }
    }
}
