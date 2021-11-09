using Microsoft.EntityFrameworkCore.Migrations;

namespace FinCRM.DataAccess.Migrations
{
    public partial class DecimalsLimitsInApplicationEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "LoanAmount",
                table: "Applications",
                type: "decimal(11,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(15,6)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CommissionAmount",
                table: "Applications",
                type: "decimal(11,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(15,6)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "LoanAmount",
                table: "Applications",
                type: "decimal(15,6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(11,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CommissionAmount",
                table: "Applications",
                type: "decimal(15,6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(11,2)");
        }
    }
}
