using Microsoft.EntityFrameworkCore.Migrations;

namespace LibApi.Migrations
{
    public partial class mig5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookTypes_BookTypeId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "BookTypes");

            migrationBuilder.DropIndex(
                name: "IX_Books_BookTypeId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BookTypeId",
                table: "Books");

            migrationBuilder.AddColumn<string>(
                name: "BookType",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookType",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "BookTypeId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BookTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookTypeId",
                table: "Books",
                column: "BookTypeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookTypes_BookTypeId",
                table: "Books",
                column: "BookTypeId",
                principalTable: "BookTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
