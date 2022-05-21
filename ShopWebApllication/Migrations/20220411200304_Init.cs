using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopWebApllication.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Furnitures",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<double>(type: "float", nullable: false),
                    inStock = table.Column<bool>(type: "bit", nullable: false),
                    categoryid = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    img = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Furnitures", x => x.id);
                    table.ForeignKey(
                        name: "FK_Furnitures_Category_categoryid",
                        column: x => x.categoryid,
                        principalTable: "Category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FurniturePurchase",
                columns: table => new
                {
                    furnituresid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    purchasesid = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FurniturePurchase", x => new { x.furnituresid, x.purchasesid });
                    table.ForeignKey(
                        name: "FK_FurniturePurchase_Furnitures_furnituresid",
                        column: x => x.furnituresid,
                        principalTable: "Furnitures",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FurniturePurchase_Purchases_purchasesid",
                        column: x => x.purchasesid,
                        principalTable: "Purchases",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FurniturePurchase_purchasesid",
                table: "FurniturePurchase",
                column: "purchasesid");

            migrationBuilder.CreateIndex(
                name: "IX_Furnitures_categoryid",
                table: "Furnitures",
                column: "categoryid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FurniturePurchase");

            migrationBuilder.DropTable(
                name: "Furnitures");

            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
