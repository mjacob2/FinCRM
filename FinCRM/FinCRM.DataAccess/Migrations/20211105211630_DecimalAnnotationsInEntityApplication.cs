using Microsoft.EntityFrameworkCore.Migrations;

namespace FinCRM.DataAccess.Migrations
{
    public partial class DecimalAnnotationsInEntityApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "LoanAmount",
                table: "Applications",
                type: "decimal(15,6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CommissionAmount",
                table: "Applications",
                type: "decimal(15,6)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "LoanAmount",
                table: "Applications",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(15,6)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CommissionAmount",
                table: "Applications",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(15,6)");
        }
    }
}
