using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MaintenancePro2.Migrations
{
    public partial class FreshMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Motors",
                columns: table => new
                {
                    motorID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    year = table.Column<int>(nullable: false),
                    make = table.Column<string>(nullable: false),
                    model = table.Column<string>(nullable: false),
                    hours = table.Column<float>(nullable: false),
                    createdat = table.Column<DateTime>(nullable: false),
                    updatedat = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motors", x => x.motorID);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    itemID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    item = table.Column<string>(nullable: false),
                    note = table.Column<string>(nullable: true),
                    interval = table.Column<float>(nullable: false),
                    action = table.Column<string>(nullable: false),
                    MotorID = table.Column<int>(nullable: false),
                    createdat = table.Column<DateTime>(nullable: false),
                    updatedat = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.itemID);
                    table.ForeignKey(
                        name: "FK_Items_Motors_MotorID",
                        column: x => x.MotorID,
                        principalTable: "Motors",
                        principalColumn: "motorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PerformedItems",
                columns: table => new
                {
                    preformedID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    hpa = table.Column<float>(nullable: false),
                    dpa = table.Column<DateTime>(nullable: false),
                    ItemID = table.Column<int>(nullable: false),
                    MotorID = table.Column<int>(nullable: false),
                    createdat = table.Column<DateTime>(nullable: false),
                    updatedat = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PerformedItems", x => x.preformedID);
                    table.ForeignKey(
                        name: "FK_PerformedItems_Items_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Items",
                        principalColumn: "itemID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Items_MotorID",
                table: "Items",
                column: "MotorID");

            migrationBuilder.CreateIndex(
                name: "IX_PerformedItems_ItemID",
                table: "PerformedItems",
                column: "ItemID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PerformedItems");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Motors");
        }
    }
}
