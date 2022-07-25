using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoffeeShop.DAL.Migrations
{
    public partial class CoffeShopMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coffee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coffee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoffeePack",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nchar(30)", fixedLength: true, maxLength: 30, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoffeePack", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoffeeEntityCoffeePackEntity",
                columns: table => new
                {
                    CoffeePacksId = table.Column<int>(type: "int", nullable: false),
                    CoffeesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoffeeEntityCoffeePackEntity", x => new { x.CoffeePacksId, x.CoffeesId });
                    table.ForeignKey(
                        name: "FK_CoffeeEntityCoffeePackEntity_Coffee_CoffeesId",
                        column: x => x.CoffeesId,
                        principalTable: "Coffee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoffeeEntityCoffeePackEntity_CoffeePack_CoffeePacksId",
                        column: x => x.CoffeePacksId,
                        principalTable: "CoffeePack",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoffeeEntityCoffeePackEntity_CoffeesId",
                table: "CoffeeEntityCoffeePackEntity",
                column: "CoffeesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoffeeEntityCoffeePackEntity");

            migrationBuilder.DropTable(
                name: "Coffee");

            migrationBuilder.DropTable(
                name: "CoffeePack");
        }
    }
}
