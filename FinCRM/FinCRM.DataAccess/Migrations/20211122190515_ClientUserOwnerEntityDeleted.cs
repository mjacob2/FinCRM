using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinCRM.DataAccess.Migrations
{
    public partial class ClientUserOwnerEntityDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserOwner",
                table: "Clients");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserOwner",
                table: "Clients",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
