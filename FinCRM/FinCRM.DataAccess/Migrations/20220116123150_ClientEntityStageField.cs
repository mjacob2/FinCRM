using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinCRM.DataAccess.Migrations
{
    public partial class ClientEntityStageField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Stage",
                table: "Clients",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stage",
                table: "Clients");
        }
    }
}
