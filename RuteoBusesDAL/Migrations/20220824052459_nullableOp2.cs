using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RuteoBusesDAL.Migrations
{
    public partial class nullableOp2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_buses_choferes_choferId",
                table: "buses");

            migrationBuilder.DropForeignKey(
                name: "FK_buses_rutas_rutaId",
                table: "buses");

            migrationBuilder.AlterColumn<int>(
                name: "rutaId",
                table: "buses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "choferId",
                table: "buses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_buses_choferes_choferId",
                table: "buses",
                column: "choferId",
                principalTable: "choferes",
                principalColumn: "choferId");

            migrationBuilder.AddForeignKey(
                name: "FK_buses_rutas_rutaId",
                table: "buses",
                column: "rutaId",
                principalTable: "rutas",
                principalColumn: "rutaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_buses_choferes_choferId",
                table: "buses");

            migrationBuilder.DropForeignKey(
                name: "FK_buses_rutas_rutaId",
                table: "buses");

            migrationBuilder.AlterColumn<int>(
                name: "rutaId",
                table: "buses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "choferId",
                table: "buses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_buses_choferes_choferId",
                table: "buses",
                column: "choferId",
                principalTable: "choferes",
                principalColumn: "choferId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_buses_rutas_rutaId",
                table: "buses",
                column: "rutaId",
                principalTable: "rutas",
                principalColumn: "rutaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
