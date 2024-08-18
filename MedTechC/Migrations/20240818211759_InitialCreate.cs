using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedTechC.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    CartaoSus = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Rg = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    DataNascimento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NomeMae = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NomePai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Observacoes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prontuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PacienteId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Peso = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Altura = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    PressaoArterial = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Temperatura = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Saturacao = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    FrequenciaCardiaca = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    QueixaPrincipal = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    dataAtendimento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prontuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prontuarios_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prontuarios_PacienteId",
                table: "Prontuarios",
                column: "PacienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prontuarios");

            migrationBuilder.DropTable(
                name: "Pacientes");
        }
    }
}
