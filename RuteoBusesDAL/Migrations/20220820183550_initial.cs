using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RuteoBusesDAL.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "choferes",
                columns: table => new
                {
                    choferId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cedula = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_choferes", x => x.choferId);
                });

            migrationBuilder.CreateTable(
                name: "estados",
                columns: table => new
                {
                    EstadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estados", x => x.EstadoId);
                });

            migrationBuilder.CreateTable(
                name: "rutas",
                columns: table => new
                {
                    rutaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreRuta = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rutas", x => x.rutaId);
                });

            migrationBuilder.CreateTable(
                name: "paradarutas",
                columns: table => new
                {
                    paradaRutaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreParadaRuta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rutaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paradarutas", x => x.paradaRutaId);
                    table.ForeignKey(
                        name: "FK_paradarutas_rutas_rutaId",
                        column: x => x.rutaId,
                        principalTable: "rutas",
                        principalColumn: "rutaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "rutaAsignadas",
                columns: table => new
                {
                    rutaAsignadaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    montoEstimado = table.Column<double>(type: "float", nullable: false),
                    montoRecibido = table.Column<double>(type: "float", nullable: false),
                    rutaId = table.Column<int>(type: "int", nullable: false)
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
                name: "buses",
                columns: table => new
                {
                    busId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    estadoId = table.Column<int>(type: "int", nullable: false),
                    rutaAsignadaId = table.Column<int>(type: "int", nullable: false),
                    choferId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_buses", x => x.busId);
                    table.ForeignKey(
                        name: "FK_buses_choferes_choferId",
                        column: x => x.choferId,
                        principalTable: "choferes",
                        principalColumn: "choferId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_buses_estados_estadoId",
                        column: x => x.estadoId,
                        principalTable: "estados",
                        principalColumn: "EstadoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_buses_rutaAsignadas_rutaAsignadaId",
                        column: x => x.rutaAsignadaId,
                        principalTable: "rutaAsignadas",
                        principalColumn: "rutaAsignadaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "paradaRutasAsignadas",
                columns: table => new
                {
                    paradaRutaAsignadaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombreParadaRutaAsignada = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rutaAsignadaId = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_buses_choferId",
                table: "buses",
                column: "choferId");

            migrationBuilder.CreateIndex(
                name: "IX_buses_estadoId",
                table: "buses",
                column: "estadoId");

            migrationBuilder.CreateIndex(
                name: "IX_buses_rutaAsignadaId",
                table: "buses",
                column: "rutaAsignadaId");

            migrationBuilder.CreateIndex(
                name: "IX_paradarutas_rutaId",
                table: "paradarutas",
                column: "rutaId");

            migrationBuilder.CreateIndex(
                name: "IX_paradaRutasAsignadas_rutaAsignadaId",
                table: "paradaRutasAsignadas",
                column: "rutaAsignadaId");

            migrationBuilder.CreateIndex(
                name: "IX_rutaAsignadas_rutaId",
                table: "rutaAsignadas",
                column: "rutaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "buses");

            migrationBuilder.DropTable(
                name: "paradarutas");

            migrationBuilder.DropTable(
                name: "paradaRutasAsignadas");

            migrationBuilder.DropTable(
                name: "choferes");

            migrationBuilder.DropTable(
                name: "estados");

            migrationBuilder.DropTable(
                name: "rutaAsignadas");

            migrationBuilder.DropTable(
                name: "rutas");
        }
    }
}
