using Microsoft.EntityFrameworkCore.Migrations;

namespace RouletteGameApi.Migrations
{
    public partial class FourthCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Payouts_BetId",
                table: "Payouts");

            migrationBuilder.CreateIndex(
                name: "IX_Payouts_BetId",
                table: "Payouts",
                column: "BetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Payouts_BetId",
                table: "Payouts");

            migrationBuilder.CreateIndex(
                name: "IX_Payouts_BetId",
                table: "Payouts",
                column: "BetId",
                unique: true);
        }
    }
}
