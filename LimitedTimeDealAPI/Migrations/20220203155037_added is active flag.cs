using Microsoft.EntityFrameworkCore.Migrations;

namespace LimitedTimeDealAPI.Migrations
{
    public partial class addedisactiveflag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Deals",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Deals");
        }
    }
}
