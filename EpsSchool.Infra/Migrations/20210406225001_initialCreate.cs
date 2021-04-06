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
                    Id = table.Column<Guid>(nullable: false),
                    Enrollment = table.Column<string>(nullable: false),
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
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 120, nullable: false),
                    Workload = table.Column<int>(maxLength: 9999, nullable: true),
                    TeacherId = table.Column<Guid>(nullable: false)
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
                    { new Guid("b3cc3945-3887-4a1e-a0df-eb4be8466572"), "Informatica" },
                    { new Guid("d2778826-36f9-4406-a01f-1200ad2f8e7f"), "Manutenção de Micros" },
                    { new Guid("819dd682-ae3e-4d2d-914b-d865c15dbb08"), "Redes de Computadores" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Birthdate", "EndDate", "Enrollment", "Name", "PhoneNumber", "StartDate", "Status", "Surname" },
                values: new object[,]
                {
                    { new Guid("13c86ed1-546b-409f-b651-49ab0880ea57"), new DateTime(2005, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "21060134", "Diogenes", "22665588", new DateTime(2021, 4, 6, 19, 50, 1, 7, DateTimeKind.Local).AddTicks(8114), true, "Finético" },
                    { new Guid("6b4d6ee5-7e6a-4921-b0dc-56cb4a95d18c"), new DateTime(2005, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "21061709", "Carlos", "44558896", new DateTime(2021, 4, 6, 19, 50, 1, 7, DateTimeKind.Local).AddTicks(8092), true, "Gaiado" },
                    { new Guid("3091bd0a-ccd5-4522-9ea1-2dd352bc7dac"), new DateTime(2005, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "21061826", "José", "98745122", new DateTime(2021, 4, 6, 19, 50, 1, 7, DateTimeKind.Local).AddTicks(8051), true, "Arimatéia" },
                    { new Guid("8ede74ff-2d41-4ab3-92b5-f97856922c34"), new DateTime(2005, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "21060200", "João", "98564712", new DateTime(2021, 4, 6, 19, 50, 1, 7, DateTimeKind.Local).AddTicks(8014), true, "Paulo" },
                    { new Guid("b41eabe2-afeb-41d5-94b4-396974b31bce"), new DateTime(2005, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "21061391", "Ananias", "33589624", new DateTime(2021, 4, 6, 19, 50, 1, 7, DateTimeKind.Local).AddTicks(8033), true, "Fernandes" },
                    { new Guid("2ba7c6f5-a760-457c-b313-63840d466e2c"), new DateTime(2005, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "21060959", "Vanessa", "99562341", new DateTime(2021, 4, 6, 19, 50, 1, 7, DateTimeKind.Local).AddTicks(7973), true, "Lisboa" },
                    { new Guid("fe7f4c67-ac16-4a34-863a-aaf558da73dd"), new DateTime(2005, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "21060166", "Fernanda", "33447789", new DateTime(2021, 4, 6, 19, 50, 1, 7, DateTimeKind.Local).AddTicks(7885), true, "Silva" },
                    { new Guid("636b8127-2ea5-43aa-9927-c9f9d416d81b"), new DateTime(2005, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "21060102", "Joana", "33556699", new DateTime(2021, 4, 6, 19, 50, 1, 7, DateTimeKind.Local).AddTicks(5725), true, "Alves" },
                    { new Guid("b98f7a83-c82f-46c9-b143-9bf155c3993f"), new DateTime(2005, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "21068265", "Maria", "99452417", new DateTime(2021, 4, 6, 19, 50, 1, 7, DateTimeKind.Local).AddTicks(7993), true, "Madalena" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "EndDate", "Enrollment", "Name", "PhoneNumber", "StartDate", "Status", "Surname" },
                values: new object[,]
                {
                    { new Guid("bff67666-ff36-4ac7-9772-72dca089f6a8"), null, "21060211", "João", "33506987", new DateTime(2021, 4, 6, 19, 50, 1, 7, DateTimeKind.Local).AddTicks(8819), true, "Olavo" },
                    { new Guid("1cdf6fff-3d53-4e96-a8f0-398ce6220694"), null, "21061249", "José", "44778899", new DateTime(2021, 4, 6, 19, 50, 1, 7, DateTimeKind.Local).AddTicks(8722), true, "Roberto" },
                    { new Guid("c4834f2e-37a3-45af-adfd-5abf955f978b"), null, "21060124", "Carlos", "33568941", new DateTime(2021, 4, 6, 19, 50, 1, 7, DateTimeKind.Local).AddTicks(8777), true, "Eduardo" },
                    { new Guid("82b75ab5-e90b-42c1-9202-b8c2d0523717"), null, "21063686", "Manuel", "99587462", new DateTime(2021, 4, 6, 19, 50, 1, 7, DateTimeKind.Local).AddTicks(8798), true, "Nobre" },
                    { new Guid("8d0c4a69-d717-4806-aa19-844472b19338"), null, "21060118", "Lucas", "33214896", new DateTime(2021, 4, 6, 19, 50, 1, 7, DateTimeKind.Local).AddTicks(8840), true, "Ribas" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name", "TeacherId", "Workload" },
                values: new object[,]
                {
                    { new Guid("1cb8021a-acf2-4338-94b0-91a732cb9312"), "Matemática", new Guid("1cdf6fff-3d53-4e96-a8f0-398ce6220694"), null },
                    { new Guid("34a42bd6-2911-42b6-b22a-e4e53fcb3621"), "Limpeza de Gabinete", new Guid("c4834f2e-37a3-45af-adfd-5abf955f978b"), null },
                    { new Guid("0149899a-f860-4cf2-91bc-fbace42a8671"), "Português", new Guid("82b75ab5-e90b-42c1-9202-b8c2d0523717"), null },
                    { new Guid("4d240841-08b0-4bc6-8b53-35e8d370ad9b"), "Arquitetura de Servidores", new Guid("bff67666-ff36-4ac7-9772-72dca089f6a8"), null },
                    { new Guid("9af66b65-f95b-4002-93b2-3016f023ba26"), "Programação", new Guid("8d0c4a69-d717-4806-aa19-844472b19338"), null }
                });

            migrationBuilder.InsertData(
                table: "CoursesSubjects",
                columns: new[] { "Id", "CourseId", "SubjectId" },
                values: new object[,]
                {
                    { new Guid("a517371e-a838-4ab5-84dc-0c9f6fef6503"), new Guid("b3cc3945-3887-4a1e-a0df-eb4be8466572"), new Guid("1cb8021a-acf2-4338-94b0-91a732cb9312") },
                    { new Guid("49a407a3-44cb-4c6a-9970-b943e1d2b068"), new Guid("819dd682-ae3e-4d2d-914b-d865c15dbb08"), new Guid("1cb8021a-acf2-4338-94b0-91a732cb9312") },
                    { new Guid("d7b97ab0-124a-4b6c-87c9-a5c61e12107f"), new Guid("d2778826-36f9-4406-a01f-1200ad2f8e7f"), new Guid("34a42bd6-2911-42b6-b22a-e4e53fcb3621") },
                    { new Guid("11d49b82-dc77-431a-9a36-0e4969bee7ab"), new Guid("b3cc3945-3887-4a1e-a0df-eb4be8466572"), new Guid("0149899a-f860-4cf2-91bc-fbace42a8671") },
                    { new Guid("1ebac466-fae2-4944-9540-ffa47997d45e"), new Guid("d2778826-36f9-4406-a01f-1200ad2f8e7f"), new Guid("0149899a-f860-4cf2-91bc-fbace42a8671") },
                    { new Guid("3d68ac1d-e91b-4b90-9424-9e8a9ae88eee"), new Guid("819dd682-ae3e-4d2d-914b-d865c15dbb08"), new Guid("0149899a-f860-4cf2-91bc-fbace42a8671") },
                    { new Guid("8612e33a-1540-46a2-ab61-d4709b078037"), new Guid("819dd682-ae3e-4d2d-914b-d865c15dbb08"), new Guid("4d240841-08b0-4bc6-8b53-35e8d370ad9b") },
                    { new Guid("12c28ec5-bf08-46e1-a833-2517ed613738"), new Guid("b3cc3945-3887-4a1e-a0df-eb4be8466572"), new Guid("9af66b65-f95b-4002-93b2-3016f023ba26") }
                });

            migrationBuilder.InsertData(
                table: "StudentsCoursesSubjects",
                columns: new[] { "StudentId", "CourseSubjectId", "EndDate", "Grade", "StartDate" },
                values: new object[,]
                {
                    { new Guid("636b8127-2ea5-43aa-9927-c9f9d416d81b"), new Guid("a517371e-a838-4ab5-84dc-0c9f6fef6503"), null, null, new DateTime(2021, 4, 6, 19, 50, 1, 17, DateTimeKind.Local).AddTicks(8001) },
                    { new Guid("636b8127-2ea5-43aa-9927-c9f9d416d81b"), new Guid("12c28ec5-bf08-46e1-a833-2517ed613738"), null, null, new DateTime(2021, 4, 6, 19, 50, 1, 17, DateTimeKind.Local).AddTicks(9197) },
                    { new Guid("13c86ed1-546b-409f-b651-49ab0880ea57"), new Guid("8612e33a-1540-46a2-ab61-d4709b078037"), null, null, new DateTime(2021, 4, 6, 19, 50, 1, 17, DateTimeKind.Local).AddTicks(9319) },
                    { new Guid("6b4d6ee5-7e6a-4921-b0dc-56cb4a95d18c"), new Guid("8612e33a-1540-46a2-ab61-d4709b078037"), null, null, new DateTime(2021, 4, 6, 19, 50, 1, 17, DateTimeKind.Local).AddTicks(9312) },
                    { new Guid("3091bd0a-ccd5-4522-9ea1-2dd352bc7dac"), new Guid("8612e33a-1540-46a2-ab61-d4709b078037"), null, null, new DateTime(2021, 4, 6, 19, 50, 1, 17, DateTimeKind.Local).AddTicks(9302) },
                    { new Guid("13c86ed1-546b-409f-b651-49ab0880ea57"), new Guid("3d68ac1d-e91b-4b90-9424-9e8a9ae88eee"), null, null, new DateTime(2021, 4, 6, 19, 50, 1, 17, DateTimeKind.Local).AddTicks(9317) },
                    { new Guid("6b4d6ee5-7e6a-4921-b0dc-56cb4a95d18c"), new Guid("3d68ac1d-e91b-4b90-9424-9e8a9ae88eee"), null, null, new DateTime(2021, 4, 6, 19, 50, 1, 17, DateTimeKind.Local).AddTicks(9310) },
                    { new Guid("3091bd0a-ccd5-4522-9ea1-2dd352bc7dac"), new Guid("3d68ac1d-e91b-4b90-9424-9e8a9ae88eee"), null, null, new DateTime(2021, 4, 6, 19, 50, 1, 17, DateTimeKind.Local).AddTicks(9238) },
                    { new Guid("b41eabe2-afeb-41d5-94b4-396974b31bce"), new Guid("1ebac466-fae2-4944-9540-ffa47997d45e"), null, null, new DateTime(2021, 4, 6, 19, 50, 1, 17, DateTimeKind.Local).AddTicks(9234) },
                    { new Guid("8ede74ff-2d41-4ab3-92b5-f97856922c34"), new Guid("1ebac466-fae2-4944-9540-ffa47997d45e"), null, null, new DateTime(2021, 4, 6, 19, 50, 1, 17, DateTimeKind.Local).AddTicks(9229) },
                    { new Guid("b98f7a83-c82f-46c9-b143-9bf155c3993f"), new Guid("1ebac466-fae2-4944-9540-ffa47997d45e"), null, null, new DateTime(2021, 4, 6, 19, 50, 1, 17, DateTimeKind.Local).AddTicks(9224) },
                    { new Guid("2ba7c6f5-a760-457c-b313-63840d466e2c"), new Guid("11d49b82-dc77-431a-9a36-0e4969bee7ab"), null, null, new DateTime(2021, 4, 6, 19, 50, 1, 17, DateTimeKind.Local).AddTicks(9215) },
                    { new Guid("fe7f4c67-ac16-4a34-863a-aaf558da73dd"), new Guid("11d49b82-dc77-431a-9a36-0e4969bee7ab"), null, null, new DateTime(2021, 4, 6, 19, 50, 1, 17, DateTimeKind.Local).AddTicks(9204) },
                    { new Guid("636b8127-2ea5-43aa-9927-c9f9d416d81b"), new Guid("11d49b82-dc77-431a-9a36-0e4969bee7ab"), null, null, new DateTime(2021, 4, 6, 19, 50, 1, 17, DateTimeKind.Local).AddTicks(9161) },
                    { new Guid("b41eabe2-afeb-41d5-94b4-396974b31bce"), new Guid("d7b97ab0-124a-4b6c-87c9-a5c61e12107f"), null, null, new DateTime(2021, 4, 6, 19, 50, 1, 17, DateTimeKind.Local).AddTicks(9231) },
                    { new Guid("8ede74ff-2d41-4ab3-92b5-f97856922c34"), new Guid("d7b97ab0-124a-4b6c-87c9-a5c61e12107f"), null, null, new DateTime(2021, 4, 6, 19, 50, 1, 17, DateTimeKind.Local).AddTicks(9227) },
                    { new Guid("b98f7a83-c82f-46c9-b143-9bf155c3993f"), new Guid("d7b97ab0-124a-4b6c-87c9-a5c61e12107f"), null, null, new DateTime(2021, 4, 6, 19, 50, 1, 17, DateTimeKind.Local).AddTicks(9222) },
                    { new Guid("13c86ed1-546b-409f-b651-49ab0880ea57"), new Guid("49a407a3-44cb-4c6a-9970-b943e1d2b068"), null, null, new DateTime(2021, 4, 6, 19, 50, 1, 17, DateTimeKind.Local).AddTicks(9315) },
                    { new Guid("6b4d6ee5-7e6a-4921-b0dc-56cb4a95d18c"), new Guid("49a407a3-44cb-4c6a-9970-b943e1d2b068"), null, null, new DateTime(2021, 4, 6, 19, 50, 1, 17, DateTimeKind.Local).AddTicks(9307) },
                    { new Guid("3091bd0a-ccd5-4522-9ea1-2dd352bc7dac"), new Guid("49a407a3-44cb-4c6a-9970-b943e1d2b068"), null, null, new DateTime(2021, 4, 6, 19, 50, 1, 17, DateTimeKind.Local).AddTicks(9236) },
                    { new Guid("2ba7c6f5-a760-457c-b313-63840d466e2c"), new Guid("a517371e-a838-4ab5-84dc-0c9f6fef6503"), null, null, new DateTime(2021, 4, 6, 19, 50, 1, 17, DateTimeKind.Local).AddTicks(9213) },
                    { new Guid("fe7f4c67-ac16-4a34-863a-aaf558da73dd"), new Guid("a517371e-a838-4ab5-84dc-0c9f6fef6503"), null, null, new DateTime(2021, 4, 6, 19, 50, 1, 17, DateTimeKind.Local).AddTicks(9201) },
                    { new Guid("fe7f4c67-ac16-4a34-863a-aaf558da73dd"), new Guid("12c28ec5-bf08-46e1-a833-2517ed613738"), null, null, new DateTime(2021, 4, 6, 19, 50, 1, 17, DateTimeKind.Local).AddTicks(9210) },
                    { new Guid("2ba7c6f5-a760-457c-b313-63840d466e2c"), new Guid("12c28ec5-bf08-46e1-a833-2517ed613738"), null, null, new DateTime(2021, 4, 6, 19, 50, 1, 17, DateTimeKind.Local).AddTicks(9218) }
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
