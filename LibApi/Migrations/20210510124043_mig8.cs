using Microsoft.EntityFrameworkCore.Migrations;

namespace LibApi.Migrations
{
    public partial class mig8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Borrows_Users_UserId",
                table: "Borrows");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Borrows");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Borrows",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Borrows_Users_UserId",
                table: "Borrows",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Borrows_Users_UserId",
                table: "Borrows");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Borrows",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Borrows",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Borrows_Users_UserId",
                table: "Borrows",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
