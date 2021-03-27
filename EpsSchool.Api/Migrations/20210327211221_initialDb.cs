using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EpsSchool.Api.Migrations
{
    public partial class initialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Matricula = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Sobrenome = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Registro = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Sobrenome = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false),
                    DisciplinaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Disciplinas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    CargaHoraria = table.Column<int>(nullable: false),
                    PrerequisitoId = table.Column<int>(nullable: true),
                    ProfessorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplinas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Disciplinas_PrerequisitoId",
                        column: x => x.PrerequisitoId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Professores_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CursosDisciplinas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CursoId = table.Column<int>(nullable: false),
                    DisciplinaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursosDisciplinas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CursosDisciplinas_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CursosDisciplinas_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlunosCursosDisciplinas",
                columns: table => new
                {
                    CursoDisciplinaId = table.Column<int>(nullable: false),
                    AlunoId = table.Column<int>(nullable: false),
                    DataInicio = table.Column<DateTime>(nullable: false),
                    DataFim = table.Column<DateTime>(nullable: true),
                    Nota = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosCursosDisciplinas", x => new { x.AlunoId, x.CursoDisciplinaId });
                    table.ForeignKey(
                        name: "FK_AlunosCursosDisciplinas_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosCursosDisciplinas_CursosDisciplinas_CursoDisciplinaId",
                        column: x => x.CursoDisciplinaId,
                        principalTable: "CursosDisciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataFim", "DataInicio", "DataNascimento", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[,]
                {
                    { 1, true, null, new DateTime(2021, 3, 27, 18, 12, 20, 569, DateTimeKind.Local).AddTicks(8430), new DateTime(2010, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Joana", "Alves", "33556699" },
                    { 2, true, null, new DateTime(2021, 3, 27, 18, 12, 20, 570, DateTimeKind.Local).AddTicks(925), new DateTime(2010, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Fernanda", "Silva", "33447789" },
                    { 3, true, null, new DateTime(2021, 3, 27, 18, 12, 20, 570, DateTimeKind.Local).AddTicks(1319), new DateTime(2010, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Vanessa", "Lisboa", "99562341" },
                    { 4, true, null, new DateTime(2021, 3, 27, 18, 12, 20, 570, DateTimeKind.Local).AddTicks(1686), new DateTime(2010, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Maria", "Madalena", "99452417" },
                    { 5, true, null, new DateTime(2021, 3, 27, 18, 12, 20, 570, DateTimeKind.Local).AddTicks(2044), new DateTime(2010, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "João", "Paulo", "98564712" },
                    { 6, true, null, new DateTime(2021, 3, 27, 18, 12, 20, 570, DateTimeKind.Local).AddTicks(2408), new DateTime(2010, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Ananias", "Fernandes", "33589624" },
                    { 7, true, null, new DateTime(2021, 3, 27, 18, 12, 20, 570, DateTimeKind.Local).AddTicks(2811), new DateTime(2010, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "José", "Arimatéia", "98745122" }
                });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Informatica" },
                    { 2, "Manutenção de Micros" },
                    { 3, "Redes de Computadores" }
                });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Ativo", "DataFim", "DataInicio", "DisciplinaId", "Nome", "Registro", "Sobrenome", "Telefone" },
                values: new object[,]
                {
                    { 1, true, null, new DateTime(2021, 3, 27, 18, 12, 20, 565, DateTimeKind.Local).AddTicks(9443), 0, "José", 1, "Roberto", null },
                    { 2, true, null, new DateTime(2021, 3, 27, 18, 12, 20, 566, DateTimeKind.Local).AddTicks(8327), 0, "Carlos", 2, "Eduardo", null },
                    { 3, true, null, new DateTime(2021, 3, 27, 18, 12, 20, 566, DateTimeKind.Local).AddTicks(8386), 0, "Manuel", 3, "Nobre", null },
                    { 4, true, null, new DateTime(2021, 3, 27, 18, 12, 20, 566, DateTimeKind.Local).AddTicks(8389), 0, "João", 4, "Olavo", null },
                    { 5, true, null, new DateTime(2021, 3, 27, 18, 12, 20, 566, DateTimeKind.Local).AddTicks(8391), 0, "Lucas", 5, "Ribas", null }
                });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "Nome", "PrerequisitoId", "ProfessorId" },
                values: new object[,]
                {
                    { 1, 0, "Matemática", null, 1 },
                    { 2, 0, "Limpeza de Gabinete", null, 2 },
                    { 3, 0, "Português", null, 3 },
                    { 4, 0, "Arquitetura de Servidores", null, 4 },
                    { 5, 0, "Programação", null, 5 }
                });

            migrationBuilder.InsertData(
                table: "CursosDisciplinas",
                columns: new[] { "Id", "CursoId", "DisciplinaId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 6, 3, 1 },
                    { 4, 2, 2 },
                    { 2, 1, 3 },
                    { 5, 2, 3 },
                    { 7, 3, 3 },
                    { 8, 3, 4 },
                    { 3, 1, 5 }
                });

            migrationBuilder.InsertData(
                table: "AlunosCursosDisciplinas",
                columns: new[] { "AlunoId", "CursoDisciplinaId", "DataFim", "DataInicio", "Nota" },
                values: new object[,]
                {
                    { 1, 1, null, new DateTime(2021, 3, 27, 18, 12, 20, 570, DateTimeKind.Local).AddTicks(6368), null },
                    { 7, 7, null, new DateTime(2021, 3, 27, 18, 12, 20, 570, DateTimeKind.Local).AddTicks(7137), null },
                    { 6, 7, null, new DateTime(2021, 3, 27, 18, 12, 20, 570, DateTimeKind.Local).AddTicks(7130), null },
                    { 7, 5, null, new DateTime(2021, 3, 27, 18, 12, 20, 570, DateTimeKind.Local).AddTicks(7131), null },
                    { 6, 5, null, new DateTime(2021, 3, 27, 18, 12, 20, 570, DateTimeKind.Local).AddTicks(7126), null },
                    { 5, 5, null, new DateTime(2021, 3, 27, 18, 12, 20, 570, DateTimeKind.Local).AddTicks(7124), null },
                    { 4, 5, null, new DateTime(2021, 3, 27, 18, 12, 20, 570, DateTimeKind.Local).AddTicks(7120), null },
                    { 3, 5, null, new DateTime(2021, 3, 27, 18, 12, 20, 570, DateTimeKind.Local).AddTicks(7094), null },
                    { 2, 2, null, new DateTime(2021, 3, 27, 18, 12, 20, 570, DateTimeKind.Local).AddTicks(7084), null },
                    { 1, 2, null, new DateTime(2021, 3, 27, 18, 12, 20, 570, DateTimeKind.Local).AddTicks(7051), null },
                    { 5, 4, null, new DateTime(2021, 3, 27, 18, 12, 20, 570, DateTimeKind.Local).AddTicks(7122), null },
                    { 4, 4, null, new DateTime(2021, 3, 27, 18, 12, 20, 570, DateTimeKind.Local).AddTicks(7116), null },
                    { 3, 4, null, new DateTime(2021, 3, 27, 18, 12, 20, 570, DateTimeKind.Local).AddTicks(7092), null },
                    { 7, 6, null, new DateTime(2021, 3, 27, 18, 12, 20, 570, DateTimeKind.Local).AddTicks(7133), null },
                    { 6, 6, null, new DateTime(2021, 3, 27, 18, 12, 20, 570, DateTimeKind.Local).AddTicks(7128), null },
                    { 2, 1, null, new DateTime(2021, 3, 27, 18, 12, 20, 570, DateTimeKind.Local).AddTicks(7082), null },
                    { 1, 3, null, new DateTime(2021, 3, 27, 18, 12, 20, 570, DateTimeKind.Local).AddTicks(7078), null },
                    { 2, 3, null, new DateTime(2021, 3, 27, 18, 12, 20, 570, DateTimeKind.Local).AddTicks(7090), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunosCursosDisciplinas_CursoDisciplinaId",
                table: "AlunosCursosDisciplinas",
                column: "CursoDisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_CursosDisciplinas_CursoId",
                table: "CursosDisciplinas",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_CursosDisciplinas_DisciplinaId",
                table: "CursosDisciplinas",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_PrerequisitoId",
                table: "Disciplinas",
                column: "PrerequisitoId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_ProfessorId",
                table: "Disciplinas",
                column: "ProfessorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunosCursosDisciplinas");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "CursosDisciplinas");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Disciplinas");

            migrationBuilder.DropTable(
                name: "Professores");
        }
    }
}
