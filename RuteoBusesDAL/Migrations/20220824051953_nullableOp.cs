using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RuteoBusesDAL.Migrations
{
    public partial class nullableOp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_buses_estados_estadoId",
                table: "buses");

            migrationBuilder.DropForeignKey(
                name: "FK_paradarutas_buses_busId",
                table: "paradarutas");

            migrationBuilder.DropForeignKey(
                name: "FK_paradarutas_rutas_rutaId",
                table: "paradarutas");

            migrationBuilder.AddColumn<string>(
                name: "clave",
                table: "usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "nombreRuta",
                table: "rutas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "rutaId",
                table: "paradarutas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "nombreParadaRuta",
                table: "paradarutas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "busId",
                table: "paradarutas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "estadoId",
                table: "buses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_buses_estados_estadoId",
                table: "buses",
                column: "estadoId",
                principalTable: "estados",
                principalColumn: "EstadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_paradarutas_buses_busId",
                table: "paradarutas",
                column: "busId",
                principalTable: "buses",
                principalColumn: "busId");

            migrationBuilder.AddForeignKey(
                name: "FK_paradarutas_rutas_rutaId",
                table: "paradarutas",
                column: "rutaId",
                principalTable: "rutas",
                principalColumn: "rutaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_buses_estados_estadoId",
                table: "buses");

            migrationBuilder.DropForeignKey(
                name: "FK_paradarutas_buses_busId",
                table: "paradarutas");

            migrationBuilder.DropForeignKey(
                name: "FK_paradarutas_rutas_rutaId",
                table: "paradarutas");

            migrationBuilder.DropColumn(
                name: "clave",
                table: "usuarios");

            migrationBuilder.AlterColumn<string>(
                name: "nombreRuta",
                table: "rutas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "rutaId",
                table: "paradarutas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "nombreParadaRuta",
                table: "paradarutas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "busId",
                table: "paradarutas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "estadoId",
                table: "buses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_buses_estados_estadoId",
                table: "buses",
                column: "estadoId",
                principalTable: "estados",
                principalColumn: "EstadoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_paradarutas_buses_busId",
                table: "paradarutas",
                column: "busId",
                principalTable: "buses",
                principalColumn: "busId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_paradarutas_rutas_rutaId",
                table: "paradarutas",
                column: "rutaId",
                principalTable: "rutas",
                principalColumn: "rutaId");
        }
    }
}
