using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RouletteGameApi.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Spins",
                columns: table => new
                {
                    SpinId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SpinResult = table.Column<long>(type: "INTEGER", nullable: true),
                    TimestampUtc = table.Column<DateTime>(type: "TEXT", nullable: false),
                    BetId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spins", x => x.SpinId);
                });

            migrationBuilder.CreateTable(
                name: "BetInfos",
                columns: table => new
                {
                    BetId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BetOn = table.Column<string>(type: "TEXT", nullable: false),
                    BetDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    BetAmount = table.Column<decimal>(type: "decimal(8, 2)", nullable: false),
                    SpinId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BetInfos", x => x.BetId);
                    table.ForeignKey(
                        name: "FK_BetInfos_Spins_SpinId",
                        column: x => x.SpinId,
                        principalTable: "Spins",
                        principalColumn: "SpinId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payouts",
                columns: table => new
                {
                    PayoutId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TimestampUtc = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TotalPayout = table.Column<decimal>(type: "TEXT", nullable: false),
                    BetId = table.Column<int>(type: "INTEGER", nullable: true),
                    SpinId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payouts", x => x.PayoutId);
                    table.ForeignKey(
                        name: "FK_Payouts_BetInfos_BetId",
                        column: x => x.BetId,
                        principalTable: "BetInfos",
                        principalColumn: "BetId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payouts_Spins_SpinId",
                        column: x => x.SpinId,
                        principalTable: "Spins",
                        principalColumn: "SpinId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BetInfos_SpinId",
                table: "BetInfos",
                column: "SpinId");

            migrationBuilder.CreateIndex(
                name: "IX_Payouts_BetId",
                table: "Payouts",
                column: "BetId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payouts_SpinId",
                table: "Payouts",
                column: "SpinId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payouts");

            migrationBuilder.DropTable(
                name: "BetInfos");

            migrationBuilder.DropTable(
                name: "Spins");
        }
    }
}
