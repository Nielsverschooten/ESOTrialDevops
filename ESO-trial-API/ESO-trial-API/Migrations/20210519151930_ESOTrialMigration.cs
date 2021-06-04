using Microsoft.EntityFrameworkCore.Migrations;

namespace ESO_trial_API.Migrations
{
    public partial class ESOTrialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enchantments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    effect = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enchantments", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    characterName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    level = table.Column<int>(type: "int", nullable: false),
                    cp = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Rarities",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rarities", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Sets",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sets", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Traits",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    effect = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Traits", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    value = table.Column<int>(type: "int", nullable: false),
                    traitid = table.Column<int>(type: "int", nullable: false),
                    rarityid = table.Column<int>(type: "int", nullable: false),
                    setid = table.Column<int>(type: "int", nullable: false),
                    enchantmentid = table.Column<int>(type: "int", nullable: false),
                    item_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    armorRating = table.Column<int>(type: "int", nullable: true),
                    durability = table.Column<int>(type: "int", nullable: true),
                    armortype = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    damage = table.Column<int>(type: "int", nullable: true),
                    charge = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.id);
                    table.ForeignKey(
                        name: "FK_Items_Enchantments_enchantmentid",
                        column: x => x.enchantmentid,
                        principalTable: "Enchantments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_Rarities_rarityid",
                        column: x => x.rarityid,
                        principalTable: "Rarities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_Sets_setid",
                        column: x => x.setid,
                        principalTable: "Sets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_Traits_traitid",
                        column: x => x.traitid,
                        principalTable: "Traits",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerItems",
                columns: table => new
                {
                    itemid = table.Column<int>(type: "int", nullable: false),
                    playerid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerItems", x => new { x.itemid, x.playerid });
                    table.ForeignKey(
                        name: "FK_PlayerItems_Items_itemid",
                        column: x => x.itemid,
                        principalTable: "Items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerItems_Players_playerid",
                        column: x => x.playerid,
                        principalTable: "Players",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_enchantmentid",
                table: "Items",
                column: "enchantmentid");

            migrationBuilder.CreateIndex(
                name: "IX_Items_rarityid",
                table: "Items",
                column: "rarityid");

            migrationBuilder.CreateIndex(
                name: "IX_Items_setid",
                table: "Items",
                column: "setid");

            migrationBuilder.CreateIndex(
                name: "IX_Items_traitid",
                table: "Items",
                column: "traitid");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerItems_playerid",
                table: "PlayerItems",
                column: "playerid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerItems");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Enchantments");

            migrationBuilder.DropTable(
                name: "Rarities");

            migrationBuilder.DropTable(
                name: "Sets");

            migrationBuilder.DropTable(
                name: "Traits");
        }
    }
}
