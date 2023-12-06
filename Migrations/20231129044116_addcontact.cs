using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryMgmtCFA.Migrations
{
    public partial class addcontact : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "contact",
                table: "Registration",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "contact",
                table: "Registration");
        }
    }
}
