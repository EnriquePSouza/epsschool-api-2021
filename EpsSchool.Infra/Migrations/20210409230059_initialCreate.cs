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
                    BirthDate = table.Column<DateTime>(nullable: false)
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
                    { new Guid("f6349625-76a1-4514-b97f-8feb0b189e7f"), "Informatica" },
                    { new Guid("13393928-ee27-4c9e-8885-a1c5d3f15eba"), "Manutenção de Micros" },
                    { new Guid("6004dac6-d601-486f-b0df-43c9ac9bfc9f"), "Redes de Computadores" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "BirthDate", "EndDate", "Enrollment", "Name", "PhoneNumber", "StartDate", "Status", "Surname" },
                values: new object[,]
                {
                    { new Guid("5ef53cec-ae66-4d85-a063-b946ef8f19c6"), new DateTime(2005, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "210951181", "Diogenes", "22665588", new DateTime(2021, 4, 9, 20, 0, 59, 429, DateTimeKind.Local).AddTicks(7795), true, "Finético" },
                    { new Guid("9402bab4-b82c-48e6-9a50-4df91cc9d3a4"), new DateTime(2005, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "210951212", "Carlos", "44558896", new DateTime(2021, 4, 9, 20, 0, 59, 429, DateTimeKind.Local).AddTicks(7782), true, "Gaiado" },
                    { new Guid("522052b4-17e5-489a-aa9e-1387e58fd4bb"), new DateTime(2005, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "210964574", "José", "98745122", new DateTime(2021, 4, 9, 20, 0, 59, 429, DateTimeKind.Local).AddTicks(7769), true, "Arimatéia" },
                    { new Guid("44aedd65-8d2c-456f-9101-a4cadb2d422b"), new DateTime(2005, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "210951534", "João", "98564712", new DateTime(2021, 4, 9, 20, 0, 59, 429, DateTimeKind.Local).AddTicks(7674), true, "Paulo" },
                    { new Guid("0930b59b-1547-45b1-9af2-d093ae00872d"), new DateTime(2005, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "210951220", "Ananias", "33589624", new DateTime(2021, 4, 9, 20, 0, 59, 429, DateTimeKind.Local).AddTicks(7752), true, "Fernandes" },
                    { new Guid("a3d8db68-05e1-4f11-96ac-ea4f27081b6f"), new DateTime(2005, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "210951868", "Vanessa", "99562341", new DateTime(2021, 4, 9, 20, 0, 59, 429, DateTimeKind.Local).AddTicks(7635), true, "Lisboa" },
                    { new Guid("c2b1d1b9-f328-4813-bf7b-530488e9f8a8"), new DateTime(2006, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "210963816", "Joana", "33447789", new DateTime(2021, 4, 9, 20, 0, 59, 429, DateTimeKind.Local).AddTicks(7600), true, "Alves" },
                    { new Guid("92fe8719-8fc6-475b-8c86-8f2935648614"), new DateTime(2005, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "210951391", "Joana", "33556699", new DateTime(2021, 4, 9, 20, 0, 59, 429, DateTimeKind.Local).AddTicks(7154), true, "Alves" },
                    { new Guid("fa56d645-b4db-44ef-8f6f-7ae689578519"), new DateTime(2005, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "210910951", "Maria", "99452417", new DateTime(2021, 4, 9, 20, 0, 59, 429, DateTimeKind.Local).AddTicks(7650), true, "Madalena" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "EndDate", "Enrollment", "Name", "PhoneNumber", "StartDate", "Status", "Surname" },
                values: new object[,]
                {
                    { new Guid("e4e0b72d-84db-4a96-86f8-423f868be140"), null, "210951774", "João", "33506987", new DateTime(2021, 4, 9, 20, 0, 59, 426, DateTimeKind.Local).AddTicks(1971), true, "Olavo" },
                    { new Guid("a3ee4c51-8b23-4af3-8e1d-19f781203aa7"), null, "210951118", "José", "44778899", new DateTime(2021, 4, 9, 20, 0, 59, 426, DateTimeKind.Local).AddTicks(546), true, "Roberto" },
                    { new Guid("0ddb6a1b-a88f-46ff-afbd-2d9705088c8a"), null, "210914515", "Carlos", "33568941", new DateTime(2021, 4, 9, 20, 0, 59, 426, DateTimeKind.Local).AddTicks(1893), true, "Eduardo" },
                    { new Guid("ad9a1002-3cea-4b38-a376-1473ff8b076a"), null, "210951512", "Manuel", "99587462", new DateTime(2021, 4, 9, 20, 0, 59, 426, DateTimeKind.Local).AddTicks(1955), true, "Nobre" },
                    { new Guid("1ec49154-76bc-44b4-b7bd-0f641d59f0bf"), null, "210951212", "Lucas", "33214896", new DateTime(2021, 4, 9, 20, 0, 59, 426, DateTimeKind.Local).AddTicks(1984), true, "Ribas" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name", "TeacherId" },
                values: new object[,]
                {
                    { new Guid("66a6fc32-ee2c-4502-994a-660f98105d95"), "Matemática", new Guid("a3ee4c51-8b23-4af3-8e1d-19f781203aa7") },
                    { new Guid("b93d4f66-69cf-4300-b0e4-f8507c51cc7f"), "Limpeza de Gabinete", new Guid("0ddb6a1b-a88f-46ff-afbd-2d9705088c8a") },
                    { new Guid("419b3939-ec99-4d07-9cde-3ca420f4e499"), "Português", new Guid("ad9a1002-3cea-4b38-a376-1473ff8b076a") },
                    { new Guid("9093635c-ad8a-4eaf-9066-460dc2896dda"), "Arquitetura de Servidores", new Guid("e4e0b72d-84db-4a96-86f8-423f868be140") },
                    { new Guid("b2a786c2-a9fb-4c81-83d7-3fd7f13f4463"), "Programação", new Guid("1ec49154-76bc-44b4-b7bd-0f641d59f0bf") }
                });

            migrationBuilder.InsertData(
                table: "CoursesSubjects",
                columns: new[] { "Id", "CourseId", "SubjectId" },
                values: new object[,]
                {
                    { new Guid("7888445f-42ca-48b6-a0fb-0263914c02b3"), new Guid("f6349625-76a1-4514-b97f-8feb0b189e7f"), new Guid("66a6fc32-ee2c-4502-994a-660f98105d95") },
                    { new Guid("5f867828-a9a1-4e14-ade7-1e98c601eda1"), new Guid("6004dac6-d601-486f-b0df-43c9ac9bfc9f"), new Guid("66a6fc32-ee2c-4502-994a-660f98105d95") },
                    { new Guid("5695ff8f-eb83-41b6-abd2-bde45b34a1f3"), new Guid("13393928-ee27-4c9e-8885-a1c5d3f15eba"), new Guid("b93d4f66-69cf-4300-b0e4-f8507c51cc7f") },
                    { new Guid("ecc850c1-8eb0-4e2e-847f-fdce454284fc"), new Guid("f6349625-76a1-4514-b97f-8feb0b189e7f"), new Guid("419b3939-ec99-4d07-9cde-3ca420f4e499") },
                    { new Guid("ae5b9cbf-6a0b-4cf5-9c79-1776264e250c"), new Guid("13393928-ee27-4c9e-8885-a1c5d3f15eba"), new Guid("419b3939-ec99-4d07-9cde-3ca420f4e499") },
                    { new Guid("3bbe57c3-0e30-48c3-84bf-9360939530a2"), new Guid("6004dac6-d601-486f-b0df-43c9ac9bfc9f"), new Guid("419b3939-ec99-4d07-9cde-3ca420f4e499") },
                    { new Guid("a4abb96d-e7b0-412f-bc08-68f9c7ce260a"), new Guid("6004dac6-d601-486f-b0df-43c9ac9bfc9f"), new Guid("9093635c-ad8a-4eaf-9066-460dc2896dda") },
                    { new Guid("62c00fe2-2158-4ebd-ade4-d3ada623b9d3"), new Guid("f6349625-76a1-4514-b97f-8feb0b189e7f"), new Guid("b2a786c2-a9fb-4c81-83d7-3fd7f13f4463") }
                });

            migrationBuilder.InsertData(
                table: "StudentsCoursesSubjects",
                columns: new[] { "StudentId", "CourseSubjectId", "EndDate", "Grade", "StartDate" },
                values: new object[,]
                {
                    { new Guid("92fe8719-8fc6-475b-8c86-8f2935648614"), new Guid("7888445f-42ca-48b6-a0fb-0263914c02b3"), null, null, new DateTime(2021, 4, 9, 20, 0, 59, 432, DateTimeKind.Local).AddTicks(281) },
                    { new Guid("92fe8719-8fc6-475b-8c86-8f2935648614"), new Guid("62c00fe2-2158-4ebd-ade4-d3ada623b9d3"), null, null, new DateTime(2021, 4, 9, 20, 0, 59, 432, DateTimeKind.Local).AddTicks(1465) },
                    { new Guid("5ef53cec-ae66-4d85-a063-b946ef8f19c6"), new Guid("a4abb96d-e7b0-412f-bc08-68f9c7ce260a"), null, null, new DateTime(2021, 4, 9, 20, 0, 59, 432, DateTimeKind.Local).AddTicks(1519) },
                    { new Guid("9402bab4-b82c-48e6-9a50-4df91cc9d3a4"), new Guid("a4abb96d-e7b0-412f-bc08-68f9c7ce260a"), null, null, new DateTime(2021, 4, 9, 20, 0, 59, 432, DateTimeKind.Local).AddTicks(1511) },
                    { new Guid("522052b4-17e5-489a-aa9e-1387e58fd4bb"), new Guid("a4abb96d-e7b0-412f-bc08-68f9c7ce260a"), null, null, new DateTime(2021, 4, 9, 20, 0, 59, 432, DateTimeKind.Local).AddTicks(1504) },
                    { new Guid("5ef53cec-ae66-4d85-a063-b946ef8f19c6"), new Guid("3bbe57c3-0e30-48c3-84bf-9360939530a2"), null, null, new DateTime(2021, 4, 9, 20, 0, 59, 432, DateTimeKind.Local).AddTicks(1516) },
                    { new Guid("9402bab4-b82c-48e6-9a50-4df91cc9d3a4"), new Guid("3bbe57c3-0e30-48c3-84bf-9360939530a2"), null, null, new DateTime(2021, 4, 9, 20, 0, 59, 432, DateTimeKind.Local).AddTicks(1509) },
                    { new Guid("522052b4-17e5-489a-aa9e-1387e58fd4bb"), new Guid("3bbe57c3-0e30-48c3-84bf-9360939530a2"), null, null, new DateTime(2021, 4, 9, 20, 0, 59, 432, DateTimeKind.Local).AddTicks(1501) },
                    { new Guid("0930b59b-1547-45b1-9af2-d093ae00872d"), new Guid("ae5b9cbf-6a0b-4cf5-9c79-1776264e250c"), null, null, new DateTime(2021, 4, 9, 20, 0, 59, 432, DateTimeKind.Local).AddTicks(1496) },
                    { new Guid("44aedd65-8d2c-456f-9101-a4cadb2d422b"), new Guid("ae5b9cbf-6a0b-4cf5-9c79-1776264e250c"), null, null, new DateTime(2021, 4, 9, 20, 0, 59, 432, DateTimeKind.Local).AddTicks(1491) },
                    { new Guid("fa56d645-b4db-44ef-8f6f-7ae689578519"), new Guid("ae5b9cbf-6a0b-4cf5-9c79-1776264e250c"), null, null, new DateTime(2021, 4, 9, 20, 0, 59, 432, DateTimeKind.Local).AddTicks(1486) },
                    { new Guid("a3d8db68-05e1-4f11-96ac-ea4f27081b6f"), new Guid("ecc850c1-8eb0-4e2e-847f-fdce454284fc"), null, null, new DateTime(2021, 4, 9, 20, 0, 59, 432, DateTimeKind.Local).AddTicks(1479) },
                    { new Guid("c2b1d1b9-f328-4813-bf7b-530488e9f8a8"), new Guid("ecc850c1-8eb0-4e2e-847f-fdce454284fc"), null, null, new DateTime(2021, 4, 9, 20, 0, 59, 432, DateTimeKind.Local).AddTicks(1472) },
                    { new Guid("92fe8719-8fc6-475b-8c86-8f2935648614"), new Guid("ecc850c1-8eb0-4e2e-847f-fdce454284fc"), null, null, new DateTime(2021, 4, 9, 20, 0, 59, 432, DateTimeKind.Local).AddTicks(1428) },
                    { new Guid("0930b59b-1547-45b1-9af2-d093ae00872d"), new Guid("5695ff8f-eb83-41b6-abd2-bde45b34a1f3"), null, null, new DateTime(2021, 4, 9, 20, 0, 59, 432, DateTimeKind.Local).AddTicks(1494) },
                    { new Guid("44aedd65-8d2c-456f-9101-a4cadb2d422b"), new Guid("5695ff8f-eb83-41b6-abd2-bde45b34a1f3"), null, null, new DateTime(2021, 4, 9, 20, 0, 59, 432, DateTimeKind.Local).AddTicks(1489) },
                    { new Guid("fa56d645-b4db-44ef-8f6f-7ae689578519"), new Guid("5695ff8f-eb83-41b6-abd2-bde45b34a1f3"), null, null, new DateTime(2021, 4, 9, 20, 0, 59, 432, DateTimeKind.Local).AddTicks(1484) },
                    { new Guid("5ef53cec-ae66-4d85-a063-b946ef8f19c6"), new Guid("5f867828-a9a1-4e14-ade7-1e98c601eda1"), null, null, new DateTime(2021, 4, 9, 20, 0, 59, 432, DateTimeKind.Local).AddTicks(1513) },
                    { new Guid("9402bab4-b82c-48e6-9a50-4df91cc9d3a4"), new Guid("5f867828-a9a1-4e14-ade7-1e98c601eda1"), null, null, new DateTime(2021, 4, 9, 20, 0, 59, 432, DateTimeKind.Local).AddTicks(1506) },
                    { new Guid("522052b4-17e5-489a-aa9e-1387e58fd4bb"), new Guid("5f867828-a9a1-4e14-ade7-1e98c601eda1"), null, null, new DateTime(2021, 4, 9, 20, 0, 59, 432, DateTimeKind.Local).AddTicks(1499) },
                    { new Guid("a3d8db68-05e1-4f11-96ac-ea4f27081b6f"), new Guid("7888445f-42ca-48b6-a0fb-0263914c02b3"), null, null, new DateTime(2021, 4, 9, 20, 0, 59, 432, DateTimeKind.Local).AddTicks(1477) },
                    { new Guid("c2b1d1b9-f328-4813-bf7b-530488e9f8a8"), new Guid("7888445f-42ca-48b6-a0fb-0263914c02b3"), null, null, new DateTime(2021, 4, 9, 20, 0, 59, 432, DateTimeKind.Local).AddTicks(1469) },
                    { new Guid("c2b1d1b9-f328-4813-bf7b-530488e9f8a8"), new Guid("62c00fe2-2158-4ebd-ade4-d3ada623b9d3"), null, null, new DateTime(2021, 4, 9, 20, 0, 59, 432, DateTimeKind.Local).AddTicks(1474) },
                    { new Guid("a3d8db68-05e1-4f11-96ac-ea4f27081b6f"), new Guid("62c00fe2-2158-4ebd-ade4-d3ada623b9d3"), null, null, new DateTime(2021, 4, 9, 20, 0, 59, 432, DateTimeKind.Local).AddTicks(1481) }
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
