using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

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
                name: "Condutas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProntuarioId = table.Column<int>(type: "integer", nullable: false),
                    PacienteId = table.Column<int>(type: "integer", nullable: false),
                    Medicacao = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                    Posologia = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Evolucao = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                    Recomendacoes = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condutas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Cpf = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    CartaoSus = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Rg = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    DataNascimento = table.Column<string>(type: "text", nullable: false),
                    Sexo = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    NomeMae = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    NomePai = table.Column<string>(type: "text", nullable: true),
                    Telefone = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    Endereco = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Observacoes = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prontuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PacienteId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Urgencia = table.Column<int>(type: "integer", nullable: false),
                    Peso = table.Column<string>(type: "text", nullable: false),
                    Altura = table.Column<string>(type: "text", nullable: false),
                    PressaoArterial = table.Column<string>(type: "text", nullable: false),
                    Temperatura = table.Column<string>(type: "text", nullable: false),
                    Saturacao = table.Column<string>(type: "text", nullable: false),
                    FrequenciaCardiaca = table.Column<string>(type: "text", nullable: false),
                    QueixaPrincipal = table.Column<string>(type: "text", nullable: false),
                    DataAtendimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prontuarios", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Condutas");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Prontuarios");
        }
    }
}
