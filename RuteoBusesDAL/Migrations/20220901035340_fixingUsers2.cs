using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RuteoBusesDAL.Migrations
{
    public partial class fixingUsers2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_usuarios_roles_rolId",
                table: "usuarios");

            migrationBuilder.AlterColumn<int>(
                name: "rolId",
                table: "usuarios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_usuarios_roles_rolId",
                table: "usuarios",
                column: "rolId",
                principalTable: "roles",
                principalColumn: "rolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_usuarios_roles_rolId",
                table: "usuarios");

            migrationBuilder.AlterColumn<int>(
                name: "rolId",
                table: "usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_usuarios_roles_rolId",
                table: "usuarios",
                column: "rolId",
                principalTable: "roles",
                principalColumn: "rolId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
