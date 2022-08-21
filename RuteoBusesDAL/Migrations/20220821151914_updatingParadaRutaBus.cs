using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RuteoBusesDAL.Migrations
{
    public partial class updatingParadaRutaBus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_buses_rutaAsignadas_rutaAsignadaId",
                table: "buses");

            migrationBuilder.DropForeignKey(
                name: "FK_paradarutas_rutas_rutaId",
                table: "paradarutas");

            migrationBuilder.DropTable(
                name: "paradaRutasAsignadas");

            migrationBuilder.DropTable(
                name: "rutaAsignadas");

            migrationBuilder.RenameColumn(
                name: "rutaAsignadaId",
                table: "buses",
                newName: "rutaId");

            migrationBuilder.RenameIndex(
                name: "IX_buses_rutaAsignadaId",
                table: "buses",
                newName: "IX_buses_rutaId");

            migrationBuilder.AddColumn<int>(
                name: "cantidadDeParadas",
                table: "rutas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "montoEstimado",
                table: "rutas",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "montoRecibido",
                table: "rutas",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<int>(
                name: "rutaId",
                table: "paradarutas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "busId",
                table: "paradarutas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_paradarutas_busId",
                table: "paradarutas",
                column: "busId");

            migrationBuilder.AddForeignKey(
                name: "FK_buses_rutas_rutaId",
                table: "buses",
                column: "rutaId",
                principalTable: "rutas",
                principalColumn: "rutaId",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_buses_rutas_rutaId",
                table: "buses");

            migrationBuilder.DropForeignKey(
                name: "FK_paradarutas_buses_busId",
                table: "paradarutas");

            migrationBuilder.DropForeignKey(
                name: "FK_paradarutas_rutas_rutaId",
                table: "paradarutas");

            migrationBuilder.DropIndex(
                name: "IX_paradarutas_busId",
                table: "paradarutas");

            migrationBuilder.DropColumn(
                name: "cantidadDeParadas",
                table: "rutas");

            migrationBuilder.DropColumn(
                name: "montoEstimado",
                table: "rutas");

            migrationBuilder.DropColumn(
                name: "montoRecibido",
                table: "rutas");

            migrationBuilder.DropColumn(
                name: "busId",
                table: "paradarutas");

            migrationBuilder.RenameColumn(
                name: "rutaId",
                table: "buses",
                newName: "rutaAsignadaId");

            migrationBuilder.RenameIndex(
                name: "IX_buses_rutaId",
                table: "buses",
                newName: "IX_buses_rutaAsignadaId");

            migrationBuilder.AlterColumn<int>(
                name: "rutaId",
                table: "paradarutas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "rutaAsignadas",
                columns: table => new
                {
                    rutaAsignadaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rutaId = table.Column<int>(type: "int", nullable: false),
                    montoEstimado = table.Column<double>(type: "float", nullable: false),
                    montoRecibido = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rutaAsignadas", x => x.rutaAsignadaId);
                    table.ForeignKey(
                        name: "FK_rutaAsignadas_rutas_rutaId",
                        column: x => x.rutaId,
                        principalTable: "rutas",
                        principalColumn: "rutaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "paradaRutasAsignadas",
                columns: table => new
                {
                    paradaRutaAsignadaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    rutaAsignadaId = table.Column<int>(type: "int", nullable: false),
                    nombreParadaRutaAsignada = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paradaRutasAsignadas", x => x.paradaRutaAsignadaId);
                    table.ForeignKey(
                        name: "FK_paradaRutasAsignadas_rutaAsignadas_rutaAsignadaId",
                        column: x => x.rutaAsignadaId,
                        principalTable: "rutaAsignadas",
                        principalColumn: "rutaAsignadaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_paradaRutasAsignadas_rutaAsignadaId",
                table: "paradaRutasAsignadas",
                column: "rutaAsignadaId");

            migrationBuilder.CreateIndex(
                name: "IX_rutaAsignadas_rutaId",
                table: "rutaAsignadas",
                column: "rutaId");

            migrationBuilder.AddForeignKey(
                name: "FK_buses_rutaAsignadas_rutaAsignadaId",
                table: "buses",
                column: "rutaAsignadaId",
                principalTable: "rutaAsignadas",
                principalColumn: "rutaAsignadaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_paradarutas_rutas_rutaId",
                table: "paradarutas",
                column: "rutaId",
                principalTable: "rutas",
                principalColumn: "rutaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
