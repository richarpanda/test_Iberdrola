using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Manticora.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class migrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Defenders",
                columns: table => new
                {
                    DefenderId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CharacterId = table.Column<int>(type: "INTEGER", nullable: false),
                    Gold = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Defenders", x => x.DefenderId);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AttackingNation = table.Column<string>(type: "TEXT", nullable: false),
                    CityHealth = table.Column<int>(type: "INTEGER", nullable: false),
                    ManticoraHealth = table.Column<int>(type: "INTEGER", nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.GameId);
                });

            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    WeaponId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Cost = table.Column<int>(type: "INTEGER", nullable: false),
                    Range = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.WeaponId);
                });

            migrationBuilder.CreateTable(
                name: "Attacks",
                columns: table => new
                {
                    AttackId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GameId = table.Column<int>(type: "INTEGER", nullable: false),
                    DefenderId = table.Column<int>(type: "INTEGER", nullable: false),
                    WeaponId = table.Column<int>(type: "INTEGER", nullable: false),
                    Distance = table.Column<int>(type: "INTEGER", nullable: false),
                    ManticoraDamage = table.Column<int>(type: "INTEGER", nullable: false),
                    CityDamage = table.Column<int>(type: "INTEGER", nullable: false),
                    Round = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attacks", x => x.AttackId);
                    table.ForeignKey(
                        name: "FK_Attacks_Defenders_DefenderId",
                        column: x => x.DefenderId,
                        principalTable: "Defenders",
                        principalColumn: "DefenderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attacks_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "GameId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attacks_Weapons_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Weapons",
                        principalColumn: "WeaponId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    InventoryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DefenderId = table.Column<int>(type: "INTEGER", nullable: false),
                    WeaponId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.InventoryId);
                    table.ForeignKey(
                        name: "FK_Inventories_Defenders_DefenderId",
                        column: x => x.DefenderId,
                        principalTable: "Defenders",
                        principalColumn: "DefenderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventories_Weapons_WeaponId",
                        column: x => x.WeaponId,
                        principalTable: "Weapons",
                        principalColumn: "WeaponId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Weapons",
                columns: new[] { "WeaponId", "Cost", "Name", "Range" },
                values: new object[,]
                {
                    { 1, 80, "Gran cañón", 50 },
                    { 2, 60, "Metralla", 40 },
                    { 3, 50, "Mosquete", 30 },
                    { 4, 30, "Pistola", 20 },
                    { 5, 10, "Granada", 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attacks_DefenderId",
                table: "Attacks",
                column: "DefenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Attacks_GameId",
                table: "Attacks",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Attacks_WeaponId",
                table: "Attacks",
                column: "WeaponId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_DefenderId",
                table: "Inventories",
                column: "DefenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_WeaponId",
                table: "Inventories",
                column: "WeaponId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attacks");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Defenders");

            migrationBuilder.DropTable(
                name: "Weapons");
        }
    }
}
