using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SitioWebCoreMVCCRUDEF.Migrations
{
    /// <inheritdoc />
    public partial class final : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    IdArea = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.IdArea);
                });

            migrationBuilder.CreateTable(
                name: "Cargo",
                columns: table => new
                {
                    IdCargo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameCargo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargo", x => x.IdCargo);
                });

            migrationBuilder.CreateTable(
                name: "Contrato",
                columns: table => new
                {
                    IdContrato = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameContrato = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contrato", x => x.IdContrato);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    IdEmpresa = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Responsable = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.IdEmpresa);
                });

            migrationBuilder.CreateTable(
                name: "Periferico",
                columns: table => new
                {
                    IdPeriferico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PerifericoName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Serial = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Periferico", x => x.IdPeriferico);
                });

            migrationBuilder.CreateTable(
                name: "Software",
                columns: table => new
                {
                    IdSoftware = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoftwareName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Softwarelicencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoftwareVersion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Software", x => x.IdSoftware);
                });

            migrationBuilder.CreateTable(
                name: "Operacion",
                columns: table => new
                {
                    IdOperacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperacionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AreaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operacion", x => x.IdOperacion);
                    table.ForeignKey(
                        name: "FK_Operacion_Area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Area",
                        principalColumn: "IdArea",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipo",
                columns: table => new
                {
                    IdEquipo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreMaquina = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Serial = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Procesador = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ram = table.Column<int>(type: "int", nullable: true),
                    Referencia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Disco = table.Column<int>(type: "int", nullable: true),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContratoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipo", x => x.IdEquipo);
                    table.ForeignKey(
                        name: "FK_Equipo_Contrato_ContratoId",
                        column: x => x.ContratoId,
                        principalTable: "Contrato",
                        principalColumn: "IdContrato",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sede",
                columns: table => new
                {
                    IdSede = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ciudad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponsableTI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contacto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pa = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrdenInt = table.Column<int>(type: "int", nullable: true),
                    Cuenta = table.Column<int>(type: "int", nullable: true),
                    EmpresaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sede", x => x.IdSede);
                    table.ForeignKey(
                        name: "FK_Sede_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "IdEmpresa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cedula = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    celular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    extenseion = table.Column<int>(type: "int", nullable: true),
                    OperacionId = table.Column<int>(type: "int", nullable: false),
                    SedeId = table.Column<int>(type: "int", nullable: false),
                    CargoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_Usuario_Cargo_CargoId",
                        column: x => x.CargoId,
                        principalTable: "Cargo",
                        principalColumn: "IdCargo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuario_Operacion_OperacionId",
                        column: x => x.OperacionId,
                        principalTable: "Operacion",
                        principalColumn: "IdOperacion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuario_Sede_SedeId",
                        column: x => x.SedeId,
                        principalTable: "Sede",
                        principalColumn: "IdSede",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Leasing",
                columns: table => new
                {
                    IdLeasing = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Analista = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFinal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Propiedad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: true),
                    UsuarioRed = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    EquipoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leasing", x => x.IdLeasing);
                    table.ForeignKey(
                        name: "FK_Leasing_Equipo_EquipoId",
                        column: x => x.EquipoId,
                        principalTable: "Equipo",
                        principalColumn: "IdEquipo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Leasing_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeasingPerifericos",
                columns: table => new
                {
                    IdLeasingPerifericos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PerifericoId = table.Column<int>(type: "int", nullable: false),
                    LeasingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeasingPerifericos", x => x.IdLeasingPerifericos);
                    table.ForeignKey(
                        name: "FK_LeasingPerifericos_Leasing_LeasingId",
                        column: x => x.LeasingId,
                        principalTable: "Leasing",
                        principalColumn: "IdLeasing",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeasingPerifericos_Periferico_PerifericoId",
                        column: x => x.PerifericoId,
                        principalTable: "Periferico",
                        principalColumn: "IdPeriferico",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeasingSoftware",
                columns: table => new
                {
                    IdLeasingSoftware = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoftwareId = table.Column<int>(type: "int", nullable: false),
                    LeasingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeasingSoftware", x => x.IdLeasingSoftware);
                    table.ForeignKey(
                        name: "FK_LeasingSoftware_Leasing_LeasingId",
                        column: x => x.LeasingId,
                        principalTable: "Leasing",
                        principalColumn: "IdLeasing",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeasingSoftware_Software_SoftwareId",
                        column: x => x.SoftwareId,
                        principalTable: "Software",
                        principalColumn: "IdSoftware",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipo_ContratoId",
                table: "Equipo",
                column: "ContratoId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipo_Serial",
                table: "Equipo",
                column: "Serial",
                unique: true,
                filter: "[Serial] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Leasing_EquipoId",
                table: "Leasing",
                column: "EquipoId");

            migrationBuilder.CreateIndex(
                name: "IX_Leasing_UsuarioId",
                table: "Leasing",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_LeasingPerifericos_LeasingId",
                table: "LeasingPerifericos",
                column: "LeasingId");

            migrationBuilder.CreateIndex(
                name: "IX_LeasingPerifericos_PerifericoId",
                table: "LeasingPerifericos",
                column: "PerifericoId");

            migrationBuilder.CreateIndex(
                name: "IX_LeasingSoftware_LeasingId",
                table: "LeasingSoftware",
                column: "LeasingId");

            migrationBuilder.CreateIndex(
                name: "IX_LeasingSoftware_SoftwareId",
                table: "LeasingSoftware",
                column: "SoftwareId");

            migrationBuilder.CreateIndex(
                name: "IX_Operacion_AreaId",
                table: "Operacion",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Sede_EmpresaId",
                table: "Sede",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_CargoId",
                table: "Usuario",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Cedula",
                table: "Usuario",
                column: "Cedula",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_OperacionId",
                table: "Usuario",
                column: "OperacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_SedeId",
                table: "Usuario",
                column: "SedeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeasingPerifericos");

            migrationBuilder.DropTable(
                name: "LeasingSoftware");

            migrationBuilder.DropTable(
                name: "Periferico");

            migrationBuilder.DropTable(
                name: "Leasing");

            migrationBuilder.DropTable(
                name: "Software");

            migrationBuilder.DropTable(
                name: "Equipo");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Contrato");

            migrationBuilder.DropTable(
                name: "Cargo");

            migrationBuilder.DropTable(
                name: "Operacion");

            migrationBuilder.DropTable(
                name: "Sede");

            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropTable(
                name: "Empresa");
        }
    }
}
