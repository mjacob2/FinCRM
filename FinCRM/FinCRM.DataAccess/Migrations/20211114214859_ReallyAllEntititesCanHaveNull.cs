using Microsoft.EntityFrameworkCore.Migrations;

namespace FinCRM.DataAccess.Migrations
{
    public partial class ReallyAllEntititesCanHaveNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Applications");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Applications",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
