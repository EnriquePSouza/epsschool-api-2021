using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EpsSchool.Infra.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Registration = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 120, nullable: false),
                    Surname = table.Column<string>(maxLength: 120, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 120, nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    Birthdate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Registration = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 120, nullable: false),
                    Surname = table.Column<string>(maxLength: 120, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 120, nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 120, nullable: false),
                    Workload = table.Column<int>(maxLength: 9999, nullable: false),
                    TeacherId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subjects_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoursesSubjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CourseId = table.Column<int>(nullable: false),
                    SubjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursesSubjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoursesSubjects_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoursesSubjects_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentsCoursesSubjects",
                columns: table => new
                {
                    CourseSubjectId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    Grade = table.Column<int>(maxLength: 9999, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsCoursesSubjects", x => new { x.StudentId, x.CourseSubjectId });
                    table.ForeignKey(
                        name: "FK_StudentsCoursesSubjects_CoursesSubjects_CourseSubjectId",
                        column: x => x.CourseSubjectId,
                        principalTable: "CoursesSubjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentsCoursesSubjects_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Informatica" },
                    { 2, "Manutenção de Micros" },
                    { 3, "Redes de Computadores" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Birthdate", "EndDate", "Name", "PhoneNumber", "Registration", "StartDate", "Status", "Surname" },
                values: new object[,]
                {
                    { 1, new DateTime(2005, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Joana", "33556699", 1, new DateTime(2021, 4, 3, 18, 30, 17, 821, DateTimeKind.Local).AddTicks(1314), true, "Alves" },
                    { 2, new DateTime(2005, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Fernanda", "33447789", 2, new DateTime(2021, 4, 3, 18, 30, 17, 821, DateTimeKind.Local).AddTicks(2525), true, "Silva" },
                    { 3, new DateTime(2005, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Vanessa", "99562341", 3, new DateTime(2021, 4, 3, 18, 30, 17, 821, DateTimeKind.Local).AddTicks(3054), true, "Lisboa" },
                    { 4, new DateTime(2005, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Maria", "99452417", 4, new DateTime(2021, 4, 3, 18, 30, 17, 821, DateTimeKind.Local).AddTicks(3491), true, "Madalena" },
                    { 5, new DateTime(2005, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "João", "98564712", 5, new DateTime(2021, 4, 3, 18, 30, 17, 821, DateTimeKind.Local).AddTicks(3994), true, "Paulo" },
                    { 6, new DateTime(2005, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ananias", "33589624", 6, new DateTime(2021, 4, 3, 18, 30, 17, 821, DateTimeKind.Local).AddTicks(4498), true, "Fernandes" },
                    { 7, new DateTime(2005, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "José", "98745122", 7, new DateTime(2021, 4, 3, 18, 30, 17, 821, DateTimeKind.Local).AddTicks(4939), true, "Arimatéia" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "EndDate", "Name", "PhoneNumber", "Registration", "StartDate", "Status", "Surname" },
                values: new object[,]
                {
                    { 1, null, "José", "44778899", 1, new DateTime(2021, 4, 3, 18, 30, 17, 816, DateTimeKind.Local).AddTicks(2761), true, "Roberto" },
                    { 2, null, "Carlos", "33568941", 2, new DateTime(2021, 4, 3, 18, 30, 17, 817, DateTimeKind.Local).AddTicks(4371), true, "Eduardo" },
                    { 3, null, "Manuel", "99587462", 3, new DateTime(2021, 4, 3, 18, 30, 17, 817, DateTimeKind.Local).AddTicks(4469), true, "Nobre" },
                    { 4, null, "João", "33506987", 4, new DateTime(2021, 4, 3, 18, 30, 17, 817, DateTimeKind.Local).AddTicks(4475), true, "Olavo" },
                    { 5, null, "Lucas", "33214896", 5, new DateTime(2021, 4, 3, 18, 30, 17, 817, DateTimeKind.Local).AddTicks(4478), true, "Ribas" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name", "TeacherId", "Workload" },
                values: new object[,]
                {
                    { 1, "Matemática", 1, 0 },
                    { 2, "Limpeza de Gabinete", 2, 0 },
                    { 3, "Português", 3, 0 },
                    { 4, "Arquitetura de Servidores", 4, 0 },
                    { 5, "Programação", 5, 0 }
                });

            migrationBuilder.InsertData(
                table: "CoursesSubjects",
                columns: new[] { "Id", "CourseId", "SubjectId" },
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
                table: "StudentsCoursesSubjects",
                columns: new[] { "StudentId", "CourseSubjectId", "EndDate", "Grade", "StartDate" },
                values: new object[,]
                {
                    { 1, 1, null, null, new DateTime(2021, 4, 3, 18, 30, 17, 822, DateTimeKind.Local).AddTicks(969) },
                    { 7, 7, null, null, new DateTime(2021, 4, 3, 18, 30, 17, 822, DateTimeKind.Local).AddTicks(2713) },
                    { 6, 7, null, null, new DateTime(2021, 4, 3, 18, 30, 17, 822, DateTimeKind.Local).AddTicks(2706) },
                    { 5, 7, null, null, new DateTime(2021, 4, 3, 18, 30, 17, 822, DateTimeKind.Local).AddTicks(2703) },
                    { 5, 5, null, null, new DateTime(2021, 4, 3, 18, 30, 17, 822, DateTimeKind.Local).AddTicks(2610) },
                    { 4, 5, null, null, new DateTime(2021, 4, 3, 18, 30, 17, 822, DateTimeKind.Local).AddTicks(2608) },
                    { 3, 2, null, null, new DateTime(2021, 4, 3, 18, 30, 17, 822, DateTimeKind.Local).AddTicks(2592) },
                    { 2, 2, null, null, new DateTime(2021, 4, 3, 18, 30, 17, 822, DateTimeKind.Local).AddTicks(2584) },
                    { 1, 2, null, null, new DateTime(2021, 4, 3, 18, 30, 17, 822, DateTimeKind.Local).AddTicks(2581) },
                    { 5, 4, null, null, new DateTime(2021, 4, 3, 18, 30, 17, 822, DateTimeKind.Local).AddTicks(2605) },
                    { 4, 4, null, null, new DateTime(2021, 4, 3, 18, 30, 17, 822, DateTimeKind.Local).AddTicks(2600) },
                    { 7, 6, null, null, new DateTime(2021, 4, 3, 18, 30, 17, 822, DateTimeKind.Local).AddTicks(2700) },
                    { 6, 6, null, null, new DateTime(2021, 4, 3, 18, 30, 17, 822, DateTimeKind.Local).AddTicks(2693) },
                    { 5, 6, null, null, new DateTime(2021, 4, 3, 18, 30, 17, 822, DateTimeKind.Local).AddTicks(2613) },
                    { 3, 1, null, null, new DateTime(2021, 4, 3, 18, 30, 17, 822, DateTimeKind.Local).AddTicks(2575) },
                    { 2, 1, null, null, new DateTime(2021, 4, 3, 18, 30, 17, 822, DateTimeKind.Local).AddTicks(2530) },
                    { 4, 3, null, null, new DateTime(2021, 4, 3, 18, 30, 17, 822, DateTimeKind.Local).AddTicks(2595) },
                    { 5, 3, null, null, new DateTime(2021, 4, 3, 18, 30, 17, 822, DateTimeKind.Local).AddTicks(2597) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoursesSubjects_CourseId",
                table: "CoursesSubjects",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursesSubjects_SubjectId",
                table: "CoursesSubjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsCoursesSubjects_CourseSubjectId",
                table: "StudentsCoursesSubjects",
                column: "CourseSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_TeacherId",
                table: "Subjects",
                column: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentsCoursesSubjects");

            migrationBuilder.DropTable(
                name: "CoursesSubjects");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
