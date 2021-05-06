using Microsoft.EntityFrameworkCore.Migrations;

namespace LibApi.Migrations
{
    public partial class Migration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Books");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
