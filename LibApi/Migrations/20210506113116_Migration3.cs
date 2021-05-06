using Microsoft.EntityFrameworkCore.Migrations;

namespace LibApi.Migrations
{
    public partial class Migration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Borrows_Customers_CustomerId",
                table: "Borrows");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Borrows");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Borrows",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Borrows_Customers_CustomerId",
                table: "Borrows",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Borrows_Customers_CustomerId",
                table: "Borrows");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Borrows",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Borrows",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Borrows_Customers_CustomerId",
                table: "Borrows",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
