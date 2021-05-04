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
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Username = table.Column<string>(maxLength: 20, nullable: false),
                    Password = table.Column<string>(maxLength: 20, nullable: false),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
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
                    { new Guid("354b80ec-9175-4c4f-9f29-d1895e7d128c"), "Informatica" },
                    { new Guid("4e1fe682-fddb-4f33-a2fb-3363cf383375"), "Manutenção de Micros" },
                    { new Guid("2489da8a-53c0-4d2b-a976-a8e7af71843b"), "Redes de Computadores" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "BirthDate", "EndDate", "Enrollment", "FirstName", "LastName", "PhoneNumber", "StartDate", "Status" },
                values: new object[,]
                {
                    { new Guid("5c0cdfa5-a60a-48d3-b943-50a990745ae0"), new DateTime(2005, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "210315742", "Diogenes", "Finético", "22665588", new DateTime(2021, 5, 3, 21, 15, 5, 68, DateTimeKind.Local).AddTicks(1107), true },
                    { new Guid("dec14fa8-a039-4195-a2fb-b18f8d31d071"), new DateTime(2005, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "210316308", "Carlos", "Gaiado", "44558896", new DateTime(2021, 5, 3, 21, 15, 5, 68, DateTimeKind.Local).AddTicks(1069), true },
                    { new Guid("59afd626-77e1-4b16-852a-6ec4fda31c4b"), new DateTime(2005, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "210351164", "José", "Arimatéia", "98745122", new DateTime(2021, 5, 3, 21, 15, 5, 67, DateTimeKind.Local).AddTicks(9846), true },
                    { new Guid("d97854ad-1b35-47fe-902a-69cbcff31e1c"), new DateTime(2005, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "210312405", "João", "Paulo", "98564712", new DateTime(2021, 5, 3, 21, 15, 5, 67, DateTimeKind.Local).AddTicks(9803), true },
                    { new Guid("ea23de23-b0f2-4e77-ac8d-b4b320d271d5"), new DateTime(2005, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "210351103", "Ananias", "Fernandes", "33589624", new DateTime(2021, 5, 3, 21, 15, 5, 67, DateTimeKind.Local).AddTicks(9825), true },
                    { new Guid("7a2b512e-2df8-4a12-ab1b-022b5b60c3ad"), new DateTime(2005, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "210351122", "Vanessa", "Lisboa", "99562341", new DateTime(2021, 5, 3, 21, 15, 5, 67, DateTimeKind.Local).AddTicks(9756), true },
                    { new Guid("38913f47-2140-4718-9cd6-24c44dfc8eb6"), new DateTime(2006, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "210322041", "Joana", "Alves", "33447789", new DateTime(2021, 5, 3, 21, 15, 5, 67, DateTimeKind.Local).AddTicks(9708), true },
                    { new Guid("a156e221-e5e7-4b23-8e66-ccf837c8810f"), new DateTime(2005, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "210349025", "Joana", "Alves", "33556699", new DateTime(2021, 5, 3, 21, 15, 5, 67, DateTimeKind.Local).AddTicks(9040), true },
                    { new Guid("49f6a159-7546-44c2-8987-3d563c16c899"), new DateTime(2005, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "210351102", "Maria", "Madalena", "99452417", new DateTime(2021, 5, 3, 21, 15, 5, 67, DateTimeKind.Local).AddTicks(9780), true }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("543316ef-5f5e-47eb-b36a-11b94df8b2a7"), "Arquitetura de Servidores" },
                    { new Guid("4851ea47-2f4e-4e44-a622-9728f7c35266"), "Matemática" },
                    { new Guid("44b4cc1a-f2df-4573-a6b3-55acd49c226e"), "Limpeza de Gabinete" },
                    { new Guid("67775473-94d3-4f4c-bd42-1fc247b3bfcb"), "Português" },
                    { new Guid("ca80d73c-0aa6-47d8-ae22-c08fdf8fb2d3"), "Programação" }
                });

            migrationBuilder.InsertData(
                table: "CoursesSubjects",
                columns: new[] { "Id", "CourseId", "SubjectId" },
                values: new object[,]
                {
                    { new Guid("9e10de45-65f6-4877-9dc3-c741481c760c"), new Guid("354b80ec-9175-4c4f-9f29-d1895e7d128c"), new Guid("4851ea47-2f4e-4e44-a622-9728f7c35266") },
                    { new Guid("c6f9f026-72a5-4ffd-ba99-e7f1e3f93172"), new Guid("2489da8a-53c0-4d2b-a976-a8e7af71843b"), new Guid("4851ea47-2f4e-4e44-a622-9728f7c35266") },
                    { new Guid("4f527438-a283-411d-8802-340f8bfc70da"), new Guid("4e1fe682-fddb-4f33-a2fb-3363cf383375"), new Guid("44b4cc1a-f2df-4573-a6b3-55acd49c226e") },
                    { new Guid("5f84c724-28b2-42c3-a6a0-1c91eb2be9ab"), new Guid("354b80ec-9175-4c4f-9f29-d1895e7d128c"), new Guid("67775473-94d3-4f4c-bd42-1fc247b3bfcb") },
                    { new Guid("fce6fc71-5f8b-47bd-ab25-aad932b8533a"), new Guid("4e1fe682-fddb-4f33-a2fb-3363cf383375"), new Guid("67775473-94d3-4f4c-bd42-1fc247b3bfcb") },
                    { new Guid("cc99a8c5-9316-45b7-8e74-233f3e56863d"), new Guid("2489da8a-53c0-4d2b-a976-a8e7af71843b"), new Guid("67775473-94d3-4f4c-bd42-1fc247b3bfcb") },
                    { new Guid("a4868bac-11b5-4141-94d1-e5937dd31c20"), new Guid("2489da8a-53c0-4d2b-a976-a8e7af71843b"), new Guid("543316ef-5f5e-47eb-b36a-11b94df8b2a7") },
                    { new Guid("72c41611-5512-444b-928d-37439b0e602e"), new Guid("354b80ec-9175-4c4f-9f29-d1895e7d128c"), new Guid("ca80d73c-0aa6-47d8-ae22-c08fdf8fb2d3") }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "EndDate", "Enrollment", "FirstName", "LastName", "PhoneNumber", "StartDate", "Status", "SubjectId" },
                values: new object[,]
                {
                    { new Guid("a75e8e35-051c-4903-9301-7d23e11b1961"), null, "210351140", "José", "Roberto", "44778899", new DateTime(2021, 5, 3, 21, 15, 5, 40, DateTimeKind.Local).AddTicks(6198), true, new Guid("4851ea47-2f4e-4e44-a622-9728f7c35266") },
                    { new Guid("a987e3d7-6a74-483e-83f5-5ce2ac4e8cd9"), null, "210351630", "Carlos", "Eduardo", "33568941", new DateTime(2021, 5, 3, 21, 15, 5, 40, DateTimeKind.Local).AddTicks(7877), true, new Guid("44b4cc1a-f2df-4573-a6b3-55acd49c226e") },
                    { new Guid("57916942-c682-454f-9d5c-2047fd70f7fd"), null, "210351147", "Manuel", "Nobre", "99587462", new DateTime(2021, 5, 3, 21, 15, 5, 40, DateTimeKind.Local).AddTicks(7956), true, new Guid("67775473-94d3-4f4c-bd42-1fc247b3bfcb") },
                    { new Guid("eeb48fda-a2d9-4151-8bcf-e47ba7e95c6e"), null, "210351116", "João", "Olavo", "33506987", new DateTime(2021, 5, 3, 21, 15, 5, 40, DateTimeKind.Local).AddTicks(7980), true, new Guid("543316ef-5f5e-47eb-b36a-11b94df8b2a7") },
                    { new Guid("ecbb0635-a30a-4b46-8acf-e3a820071145"), null, "210312425", "Lucas", "Ribas", "33214896", new DateTime(2021, 5, 3, 21, 15, 5, 40, DateTimeKind.Local).AddTicks(8001), true, new Guid("ca80d73c-0aa6-47d8-ae22-c08fdf8fb2d3") }
                });

            migrationBuilder.InsertData(
                table: "StudentsCoursesSubjects",
                columns: new[] { "StudentId", "CourseSubjectId", "EndDate", "Grade", "StartDate" },
                values: new object[,]
                {
                    { new Guid("a156e221-e5e7-4b23-8e66-ccf837c8810f"), new Guid("9e10de45-65f6-4877-9dc3-c741481c760c"), null, null, new DateTime(2021, 5, 3, 21, 15, 5, 73, DateTimeKind.Local).AddTicks(4550) },
                    { new Guid("a156e221-e5e7-4b23-8e66-ccf837c8810f"), new Guid("72c41611-5512-444b-928d-37439b0e602e"), null, null, new DateTime(2021, 5, 3, 21, 15, 5, 74, DateTimeKind.Local).AddTicks(6311) },
                    { new Guid("5c0cdfa5-a60a-48d3-b943-50a990745ae0"), new Guid("a4868bac-11b5-4141-94d1-e5937dd31c20"), null, null, new DateTime(2021, 5, 3, 21, 15, 5, 74, DateTimeKind.Local).AddTicks(6377) },
                    { new Guid("dec14fa8-a039-4195-a2fb-b18f8d31d071"), new Guid("a4868bac-11b5-4141-94d1-e5937dd31c20"), null, null, new DateTime(2021, 5, 3, 21, 15, 5, 74, DateTimeKind.Local).AddTicks(6368) },
                    { new Guid("59afd626-77e1-4b16-852a-6ec4fda31c4b"), new Guid("a4868bac-11b5-4141-94d1-e5937dd31c20"), null, null, new DateTime(2021, 5, 3, 21, 15, 5, 74, DateTimeKind.Local).AddTicks(6359) },
                    { new Guid("5c0cdfa5-a60a-48d3-b943-50a990745ae0"), new Guid("cc99a8c5-9316-45b7-8e74-233f3e56863d"), null, null, new DateTime(2021, 5, 3, 21, 15, 5, 74, DateTimeKind.Local).AddTicks(6374) },
                    { new Guid("dec14fa8-a039-4195-a2fb-b18f8d31d071"), new Guid("cc99a8c5-9316-45b7-8e74-233f3e56863d"), null, null, new DateTime(2021, 5, 3, 21, 15, 5, 74, DateTimeKind.Local).AddTicks(6365) },
                    { new Guid("59afd626-77e1-4b16-852a-6ec4fda31c4b"), new Guid("cc99a8c5-9316-45b7-8e74-233f3e56863d"), null, null, new DateTime(2021, 5, 3, 21, 15, 5, 74, DateTimeKind.Local).AddTicks(6356) },
                    { new Guid("ea23de23-b0f2-4e77-ac8d-b4b320d271d5"), new Guid("fce6fc71-5f8b-47bd-ab25-aad932b8533a"), null, null, new DateTime(2021, 5, 3, 21, 15, 5, 74, DateTimeKind.Local).AddTicks(6350) },
                    { new Guid("d97854ad-1b35-47fe-902a-69cbcff31e1c"), new Guid("fce6fc71-5f8b-47bd-ab25-aad932b8533a"), null, null, new DateTime(2021, 5, 3, 21, 15, 5, 74, DateTimeKind.Local).AddTicks(6344) },
                    { new Guid("49f6a159-7546-44c2-8987-3d563c16c899"), new Guid("fce6fc71-5f8b-47bd-ab25-aad932b8533a"), null, null, new DateTime(2021, 5, 3, 21, 15, 5, 74, DateTimeKind.Local).AddTicks(6338) },
                    { new Guid("7a2b512e-2df8-4a12-ab1b-022b5b60c3ad"), new Guid("5f84c724-28b2-42c3-a6a0-1c91eb2be9ab"), null, null, new DateTime(2021, 5, 3, 21, 15, 5, 74, DateTimeKind.Local).AddTicks(6328) },
                    { new Guid("38913f47-2140-4718-9cd6-24c44dfc8eb6"), new Guid("5f84c724-28b2-42c3-a6a0-1c91eb2be9ab"), null, null, new DateTime(2021, 5, 3, 21, 15, 5, 74, DateTimeKind.Local).AddTicks(6320) },
                    { new Guid("a156e221-e5e7-4b23-8e66-ccf837c8810f"), new Guid("5f84c724-28b2-42c3-a6a0-1c91eb2be9ab"), null, null, new DateTime(2021, 5, 3, 21, 15, 5, 74, DateTimeKind.Local).AddTicks(6266) },
                    { new Guid("ea23de23-b0f2-4e77-ac8d-b4b320d271d5"), new Guid("4f527438-a283-411d-8802-340f8bfc70da"), null, null, new DateTime(2021, 5, 3, 21, 15, 5, 74, DateTimeKind.Local).AddTicks(6347) },
                    { new Guid("d97854ad-1b35-47fe-902a-69cbcff31e1c"), new Guid("4f527438-a283-411d-8802-340f8bfc70da"), null, null, new DateTime(2021, 5, 3, 21, 15, 5, 74, DateTimeKind.Local).AddTicks(6341) },
                    { new Guid("49f6a159-7546-44c2-8987-3d563c16c899"), new Guid("4f527438-a283-411d-8802-340f8bfc70da"), null, null, new DateTime(2021, 5, 3, 21, 15, 5, 74, DateTimeKind.Local).AddTicks(6335) },
                    { new Guid("5c0cdfa5-a60a-48d3-b943-50a990745ae0"), new Guid("c6f9f026-72a5-4ffd-ba99-e7f1e3f93172"), null, null, new DateTime(2021, 5, 3, 21, 15, 5, 74, DateTimeKind.Local).AddTicks(6371) },
                    { new Guid("dec14fa8-a039-4195-a2fb-b18f8d31d071"), new Guid("c6f9f026-72a5-4ffd-ba99-e7f1e3f93172"), null, null, new DateTime(2021, 5, 3, 21, 15, 5, 74, DateTimeKind.Local).AddTicks(6362) },
                    { new Guid("59afd626-77e1-4b16-852a-6ec4fda31c4b"), new Guid("c6f9f026-72a5-4ffd-ba99-e7f1e3f93172"), null, null, new DateTime(2021, 5, 3, 21, 15, 5, 74, DateTimeKind.Local).AddTicks(6353) },
                    { new Guid("7a2b512e-2df8-4a12-ab1b-022b5b60c3ad"), new Guid("9e10de45-65f6-4877-9dc3-c741481c760c"), null, null, new DateTime(2021, 5, 3, 21, 15, 5, 74, DateTimeKind.Local).AddTicks(6326) },
                    { new Guid("38913f47-2140-4718-9cd6-24c44dfc8eb6"), new Guid("9e10de45-65f6-4877-9dc3-c741481c760c"), null, null, new DateTime(2021, 5, 3, 21, 15, 5, 74, DateTimeKind.Local).AddTicks(6316) },
                    { new Guid("38913f47-2140-4718-9cd6-24c44dfc8eb6"), new Guid("72c41611-5512-444b-928d-37439b0e602e"), null, null, new DateTime(2021, 5, 3, 21, 15, 5, 74, DateTimeKind.Local).AddTicks(6323) },
                    { new Guid("7a2b512e-2df8-4a12-ab1b-022b5b60c3ad"), new Guid("72c41611-5512-444b-928d-37439b0e602e"), null, null, new DateTime(2021, 5, 3, 21, 15, 5, 74, DateTimeKind.Local).AddTicks(6332) }
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
                name: "Users");

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
