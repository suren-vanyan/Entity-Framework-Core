using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreApp.Migrations
{
    public partial class AddedMailingAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MailingAddress",
                table: "Resorts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MailingAddress",
                table: "Resorts");
        }
    }
}
