using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineSweetShop.Data.Migrations
{
    public partial class create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SweetCategory",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    photopath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SweetCategory", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SweetProduct",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    categID = table.Column<int>(type: "int", nullable: false),
                    categoryid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SweetProduct", x => x.id);
                    table.ForeignKey(
                        name: "FK_SweetProduct_SweetCategory_categoryid",
                        column: x => x.categoryid,
                        principalTable: "SweetCategory",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SweetProduct_categoryid",
                table: "SweetProduct",
                column: "categoryid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SweetProduct");

            migrationBuilder.DropTable(
                name: "SweetCategory");
        }
    }
}
