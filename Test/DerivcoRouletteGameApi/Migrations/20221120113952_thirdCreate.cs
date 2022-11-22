using Microsoft.EntityFrameworkCore.Migrations;

namespace RouletteGameApi.Migrations
{
    public partial class thirdCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TimestampUtc",
                table: "Spins",
                newName: "SpinDate");

            migrationBuilder.RenameColumn(
                name: "SpinResult",
                table: "Spins",
                newName: "Result");

            migrationBuilder.RenameColumn(
                name: "TotalPayout",
                table: "Payouts",
                newName: "TotalPayoutAmount");

            migrationBuilder.RenameColumn(
                name: "TimestampUtc",
                table: "Payouts",
                newName: "PayoutDate");

            migrationBuilder.RenameColumn(
                name: "BetOn",
                table: "BetInfos",
                newName: "BetChoice");

            migrationBuilder.AlterColumn<decimal>(
                name: "BetAmount",
                table: "BetInfos",
                type: "decimal(5, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(8, 2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SpinDate",
                table: "Spins",
                newName: "TimestampUtc");

            migrationBuilder.RenameColumn(
                name: "Result",
                table: "Spins",
                newName: "SpinResult");

            migrationBuilder.RenameColumn(
                name: "TotalPayoutAmount",
                table: "Payouts",
                newName: "TotalPayout");

            migrationBuilder.RenameColumn(
                name: "PayoutDate",
                table: "Payouts",
                newName: "TimestampUtc");

            migrationBuilder.RenameColumn(
                name: "BetChoice",
                table: "BetInfos",
                newName: "BetOn");

            migrationBuilder.AlterColumn<decimal>(
                name: "BetAmount",
                table: "BetInfos",
                type: "decimal(8, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5, 2)");
        }
    }
}
