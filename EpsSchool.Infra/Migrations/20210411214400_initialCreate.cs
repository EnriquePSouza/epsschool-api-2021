using System;
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
                    Id = table.Column<Guid>(nullable: false),
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
                    Id = table.Column<Guid>(nullable: false),
                    Enrollment = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 120, nullable: false),
                    LastName = table.Column<string>(maxLength: 120, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 120, nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoursesSubjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CourseId = table.Column<Guid>(nullable: false),
                    SubjectId = table.Column<Guid>(nullable: false)
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
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Enrollment = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 120, nullable: false),
                    LastName = table.Column<string>(maxLength: 120, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 120, nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    SubjectId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teachers_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentsCoursesSubjects",
                columns: table => new
                {
                    CourseSubjectId = table.Column<Guid>(nullable: false),
                    StudentId = table.Column<Guid>(nullable: false),
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
                    { new Guid("a3a7f33f-7937-4622-a679-0420ac41f233"), "Informatica" },
                    { new Guid("e4313f4d-485b-4bab-94f8-c0b8e455198d"), "Manutenção de Micros" },
                    { new Guid("f523f8b7-7a68-4dc9-a256-fbca293f329b"), "Redes de Computadores" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "BirthDate", "EndDate", "Enrollment", "FirstName", "LastName", "PhoneNumber", "StartDate", "Status" },
                values: new object[,]
                {
                    { new Guid("256c8f1d-38dd-4f47-ac39-3386f77a3d08"), new DateTime(2005, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "211151467", "Diogenes", "Finético", "22665588", new DateTime(2021, 4, 11, 18, 44, 0, 261, DateTimeKind.Local).AddTicks(9989), true },
                    { new Guid("58efa297-6a8c-402d-af72-f982d667ad7c"), new DateTime(2005, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "211151426", "Carlos", "Gaiado", "44558896", new DateTime(2021, 4, 11, 18, 44, 0, 261, DateTimeKind.Local).AddTicks(9975), true },
                    { new Guid("1a84b1bc-6d60-4371-84e7-3383476602fc"), new DateTime(2005, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "211165040", "José", "Arimatéia", "98745122", new DateTime(2021, 4, 11, 18, 44, 0, 261, DateTimeKind.Local).AddTicks(9954), true },
                    { new Guid("545c8ff3-1f53-4d1c-bfc9-7a0a40db6deb"), new DateTime(2005, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "211151128", "João", "Paulo", "98564712", new DateTime(2021, 4, 11, 18, 44, 0, 261, DateTimeKind.Local).AddTicks(9929), true },
                    { new Guid("6c6e86c2-d6d0-47b6-bcdd-75cd3dbca562"), new DateTime(2005, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "211151207", "Ananias", "Fernandes", "33589624", new DateTime(2021, 4, 11, 18, 44, 0, 261, DateTimeKind.Local).AddTicks(9942), true },
                    { new Guid("cf077561-bb0b-4a88-8dfa-de65f35438ca"), new DateTime(2005, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "211171154", "Vanessa", "Lisboa", "99562341", new DateTime(2021, 4, 11, 18, 44, 0, 261, DateTimeKind.Local).AddTicks(9899), true },
                    { new Guid("3ff827a4-5d2b-4169-a93b-828c93d8fe98"), new DateTime(2006, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "211117939", "Joana", "Alves", "33447789", new DateTime(2021, 4, 11, 18, 44, 0, 261, DateTimeKind.Local).AddTicks(9869), true },
                    { new Guid("730b5f0f-96ec-42dd-8c1f-2915788ff391"), new DateTime(2005, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "211151125", "Joana", "Alves", "33556699", new DateTime(2021, 4, 11, 18, 44, 0, 261, DateTimeKind.Local).AddTicks(9419), true },
                    { new Guid("db9021d2-63a2-4d20-8460-d27a5b646c45"), new DateTime(2005, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "211151145", "Maria", "Madalena", "99452417", new DateTime(2021, 4, 11, 18, 44, 0, 261, DateTimeKind.Local).AddTicks(9916), true }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0c0e2723-96c2-4983-982e-64f319e44e8d"), "Arquitetura de Servidores" },
                    { new Guid("f765469e-fe01-4d1b-9e43-6224604ac922"), "Matemática" },
                    { new Guid("80827df4-a4be-48db-a445-cba857321da7"), "Limpeza de Gabinete" },
                    { new Guid("7f912da8-d20d-44f1-9c00-80b9b74eae73"), "Português" },
                    { new Guid("8abeeae2-ca9f-4934-8509-8ae96c81a71c"), "Programação" }
                });

            migrationBuilder.InsertData(
                table: "CoursesSubjects",
                columns: new[] { "Id", "CourseId", "SubjectId" },
                values: new object[,]
                {
                    { new Guid("f1f8f10d-2822-44df-a173-9bf891452e80"), new Guid("a3a7f33f-7937-4622-a679-0420ac41f233"), new Guid("f765469e-fe01-4d1b-9e43-6224604ac922") },
                    { new Guid("bd7b773d-e950-477f-96f3-278a82a084af"), new Guid("f523f8b7-7a68-4dc9-a256-fbca293f329b"), new Guid("f765469e-fe01-4d1b-9e43-6224604ac922") },
                    { new Guid("7a03be26-2cca-4b92-8e01-001f2122e20a"), new Guid("e4313f4d-485b-4bab-94f8-c0b8e455198d"), new Guid("80827df4-a4be-48db-a445-cba857321da7") },
                    { new Guid("1d04be58-530b-4505-926d-edf5587c9e9e"), new Guid("a3a7f33f-7937-4622-a679-0420ac41f233"), new Guid("7f912da8-d20d-44f1-9c00-80b9b74eae73") },
                    { new Guid("a926bd0d-2202-4533-92b2-a5c76bd6a50e"), new Guid("e4313f4d-485b-4bab-94f8-c0b8e455198d"), new Guid("7f912da8-d20d-44f1-9c00-80b9b74eae73") },
                    { new Guid("dfac14a5-df83-4a86-a26e-f5e005f068c6"), new Guid("f523f8b7-7a68-4dc9-a256-fbca293f329b"), new Guid("7f912da8-d20d-44f1-9c00-80b9b74eae73") },
                    { new Guid("b72c7526-ea98-4136-a70a-be79e84353ac"), new Guid("f523f8b7-7a68-4dc9-a256-fbca293f329b"), new Guid("0c0e2723-96c2-4983-982e-64f319e44e8d") },
                    { new Guid("55639a4f-b01f-40a5-9821-6d1f70c81451"), new Guid("a3a7f33f-7937-4622-a679-0420ac41f233"), new Guid("8abeeae2-ca9f-4934-8509-8ae96c81a71c") }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "EndDate", "Enrollment", "FirstName", "LastName", "PhoneNumber", "StartDate", "Status", "SubjectId" },
                values: new object[,]
                {
                    { new Guid("39616ebc-bbd3-42b5-9881-9f75ee7ef46a"), null, "211116902", "José", "Roberto", "44778899", new DateTime(2021, 4, 11, 18, 44, 0, 258, DateTimeKind.Local).AddTicks(6683), true, new Guid("f765469e-fe01-4d1b-9e43-6224604ac922") },
                    { new Guid("53d0726f-9850-45ea-9e83-ef95da18b884"), null, "211112461", "Carlos", "Eduardo", "33568941", new DateTime(2021, 4, 11, 18, 44, 0, 258, DateTimeKind.Local).AddTicks(8283), true, new Guid("80827df4-a4be-48db-a445-cba857321da7") },
                    { new Guid("fbf69537-b483-46ca-9071-270b23216248"), null, "211151255", "Manuel", "Nobre", "99587462", new DateTime(2021, 4, 11, 18, 44, 0, 258, DateTimeKind.Local).AddTicks(8464), true, new Guid("7f912da8-d20d-44f1-9c00-80b9b74eae73") },
                    { new Guid("e023f47e-0f28-4532-87c7-aaf65b1fd833"), null, "211116171", "João", "Olavo", "33506987", new DateTime(2021, 4, 11, 18, 44, 0, 258, DateTimeKind.Local).AddTicks(8484), true, new Guid("0c0e2723-96c2-4983-982e-64f319e44e8d") },
                    { new Guid("b4bc9d43-29dc-429d-a535-33b07778968a"), null, "211151863", "Lucas", "Ribas", "33214896", new DateTime(2021, 4, 11, 18, 44, 0, 258, DateTimeKind.Local).AddTicks(8502), true, new Guid("8abeeae2-ca9f-4934-8509-8ae96c81a71c") }
                });

            migrationBuilder.InsertData(
                table: "StudentsCoursesSubjects",
                columns: new[] { "StudentId", "CourseSubjectId", "EndDate", "Grade", "StartDate" },
                values: new object[,]
                {
                    { new Guid("730b5f0f-96ec-42dd-8c1f-2915788ff391"), new Guid("f1f8f10d-2822-44df-a173-9bf891452e80"), null, null, new DateTime(2021, 4, 11, 18, 44, 0, 264, DateTimeKind.Local).AddTicks(2160) },
                    { new Guid("730b5f0f-96ec-42dd-8c1f-2915788ff391"), new Guid("55639a4f-b01f-40a5-9821-6d1f70c81451"), null, null, new DateTime(2021, 4, 11, 18, 44, 0, 264, DateTimeKind.Local).AddTicks(3329) },
                    { new Guid("256c8f1d-38dd-4f47-ac39-3386f77a3d08"), new Guid("b72c7526-ea98-4136-a70a-be79e84353ac"), null, null, new DateTime(2021, 4, 11, 18, 44, 0, 264, DateTimeKind.Local).AddTicks(3463) },
                    { new Guid("58efa297-6a8c-402d-af72-f982d667ad7c"), new Guid("b72c7526-ea98-4136-a70a-be79e84353ac"), null, null, new DateTime(2021, 4, 11, 18, 44, 0, 264, DateTimeKind.Local).AddTicks(3456) },
                    { new Guid("1a84b1bc-6d60-4371-84e7-3383476602fc"), new Guid("b72c7526-ea98-4136-a70a-be79e84353ac"), null, null, new DateTime(2021, 4, 11, 18, 44, 0, 264, DateTimeKind.Local).AddTicks(3365) },
                    { new Guid("256c8f1d-38dd-4f47-ac39-3386f77a3d08"), new Guid("dfac14a5-df83-4a86-a26e-f5e005f068c6"), null, null, new DateTime(2021, 4, 11, 18, 44, 0, 264, DateTimeKind.Local).AddTicks(3460) },
                    { new Guid("58efa297-6a8c-402d-af72-f982d667ad7c"), new Guid("dfac14a5-df83-4a86-a26e-f5e005f068c6"), null, null, new DateTime(2021, 4, 11, 18, 44, 0, 264, DateTimeKind.Local).AddTicks(3453) },
                    { new Guid("1a84b1bc-6d60-4371-84e7-3383476602fc"), new Guid("dfac14a5-df83-4a86-a26e-f5e005f068c6"), null, null, new DateTime(2021, 4, 11, 18, 44, 0, 264, DateTimeKind.Local).AddTicks(3363) },
                    { new Guid("6c6e86c2-d6d0-47b6-bcdd-75cd3dbca562"), new Guid("a926bd0d-2202-4533-92b2-a5c76bd6a50e"), null, null, new DateTime(2021, 4, 11, 18, 44, 0, 264, DateTimeKind.Local).AddTicks(3358) },
                    { new Guid("545c8ff3-1f53-4d1c-bfc9-7a0a40db6deb"), new Guid("a926bd0d-2202-4533-92b2-a5c76bd6a50e"), null, null, new DateTime(2021, 4, 11, 18, 44, 0, 264, DateTimeKind.Local).AddTicks(3353) },
                    { new Guid("db9021d2-63a2-4d20-8460-d27a5b646c45"), new Guid("a926bd0d-2202-4533-92b2-a5c76bd6a50e"), null, null, new DateTime(2021, 4, 11, 18, 44, 0, 264, DateTimeKind.Local).AddTicks(3349) },
                    { new Guid("cf077561-bb0b-4a88-8dfa-de65f35438ca"), new Guid("1d04be58-530b-4505-926d-edf5587c9e9e"), null, null, new DateTime(2021, 4, 11, 18, 44, 0, 264, DateTimeKind.Local).AddTicks(3342) },
                    { new Guid("3ff827a4-5d2b-4169-a93b-828c93d8fe98"), new Guid("1d04be58-530b-4505-926d-edf5587c9e9e"), null, null, new DateTime(2021, 4, 11, 18, 44, 0, 264, DateTimeKind.Local).AddTicks(3335) },
                    { new Guid("730b5f0f-96ec-42dd-8c1f-2915788ff391"), new Guid("1d04be58-530b-4505-926d-edf5587c9e9e"), null, null, new DateTime(2021, 4, 11, 18, 44, 0, 264, DateTimeKind.Local).AddTicks(3295) },
                    { new Guid("6c6e86c2-d6d0-47b6-bcdd-75cd3dbca562"), new Guid("7a03be26-2cca-4b92-8e01-001f2122e20a"), null, null, new DateTime(2021, 4, 11, 18, 44, 0, 264, DateTimeKind.Local).AddTicks(3356) },
                    { new Guid("545c8ff3-1f53-4d1c-bfc9-7a0a40db6deb"), new Guid("7a03be26-2cca-4b92-8e01-001f2122e20a"), null, null, new DateTime(2021, 4, 11, 18, 44, 0, 264, DateTimeKind.Local).AddTicks(3351) },
                    { new Guid("db9021d2-63a2-4d20-8460-d27a5b646c45"), new Guid("7a03be26-2cca-4b92-8e01-001f2122e20a"), null, null, new DateTime(2021, 4, 11, 18, 44, 0, 264, DateTimeKind.Local).AddTicks(3347) },
                    { new Guid("256c8f1d-38dd-4f47-ac39-3386f77a3d08"), new Guid("bd7b773d-e950-477f-96f3-278a82a084af"), null, null, new DateTime(2021, 4, 11, 18, 44, 0, 264, DateTimeKind.Local).AddTicks(3458) },
                    { new Guid("58efa297-6a8c-402d-af72-f982d667ad7c"), new Guid("bd7b773d-e950-477f-96f3-278a82a084af"), null, null, new DateTime(2021, 4, 11, 18, 44, 0, 264, DateTimeKind.Local).AddTicks(3448) },
                    { new Guid("1a84b1bc-6d60-4371-84e7-3383476602fc"), new Guid("bd7b773d-e950-477f-96f3-278a82a084af"), null, null, new DateTime(2021, 4, 11, 18, 44, 0, 264, DateTimeKind.Local).AddTicks(3360) },
                    { new Guid("cf077561-bb0b-4a88-8dfa-de65f35438ca"), new Guid("f1f8f10d-2822-44df-a173-9bf891452e80"), null, null, new DateTime(2021, 4, 11, 18, 44, 0, 264, DateTimeKind.Local).AddTicks(3340) },
                    { new Guid("3ff827a4-5d2b-4169-a93b-828c93d8fe98"), new Guid("f1f8f10d-2822-44df-a173-9bf891452e80"), null, null, new DateTime(2021, 4, 11, 18, 44, 0, 264, DateTimeKind.Local).AddTicks(3333) },
                    { new Guid("3ff827a4-5d2b-4169-a93b-828c93d8fe98"), new Guid("55639a4f-b01f-40a5-9821-6d1f70c81451"), null, null, new DateTime(2021, 4, 11, 18, 44, 0, 264, DateTimeKind.Local).AddTicks(3338) },
                    { new Guid("cf077561-bb0b-4a88-8dfa-de65f35438ca"), new Guid("55639a4f-b01f-40a5-9821-6d1f70c81451"), null, null, new DateTime(2021, 4, 11, 18, 44, 0, 264, DateTimeKind.Local).AddTicks(3344) }
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
                name: "IX_Teachers_SubjectId",
                table: "Teachers",
                column: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentsCoursesSubjects");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "CoursesSubjects");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Subjects");
        }
    }
}
