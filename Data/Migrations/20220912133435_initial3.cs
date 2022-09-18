using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineSweetShop.Data.Migrations
{
    public partial class initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SweetProduct_SweetCategory_categoryid",
                table: "SweetProduct");

            migrationBuilder.DropIndex(
                name: "IX_SweetProduct_categoryid",
                table: "SweetProduct");

            migrationBuilder.DropColumn(
                name: "categoryid",
                table: "SweetProduct");

            migrationBuilder.AddColumn<float>(
                name: "price",
                table: "SweetProduct",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Registration",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    confirmpassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registration", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SweetProduct_categID",
                table: "SweetProduct",
                column: "categID");

            migrationBuilder.AddForeignKey(
                name: "FK_SweetProduct_SweetCategory_categID",
                table: "SweetProduct",
                column: "categID",
                principalTable: "SweetCategory",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SweetProduct_SweetCategory_categID",
                table: "SweetProduct");

            migrationBuilder.DropTable(
                name: "Login");

            migrationBuilder.DropTable(
                name: "Registration");

            migrationBuilder.DropIndex(
                name: "IX_SweetProduct_categID",
                table: "SweetProduct");

            migrationBuilder.DropColumn(
                name: "price",
                table: "SweetProduct");

            migrationBuilder.AddColumn<int>(
                name: "categoryid",
                table: "SweetProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SweetProduct_categoryid",
                table: "SweetProduct",
                column: "categoryid");

            migrationBuilder.AddForeignKey(
                name: "FK_SweetProduct_SweetCategory_categoryid",
                table: "SweetProduct",
                column: "categoryid",
                principalTable: "SweetCategory",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
