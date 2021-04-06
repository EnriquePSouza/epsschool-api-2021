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
                    Registration = table.Column<string>(nullable: false),
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
                    Registration = table.Column<string>(nullable: false),
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
                    { new Guid("a31d0ef3-6871-445f-acc0-b77c9a18d1e5"), "Informatica" },
                    { new Guid("883c4831-0201-4529-b533-d8453ffe545b"), "Manutenção de Micros" },
                    { new Guid("56ca4cd3-743c-4f5e-a37a-90e72d67081f"), "Redes de Computadores" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Birthdate", "EndDate", "Name", "PhoneNumber", "Registration", "StartDate", "Status", "Surname" },
                values: new object[,]
                {
                    { new Guid("f60a98be-7e8b-4b64-a90a-020d20e180bf"), new DateTime(2005, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Diogenes", "22665588", "21062671", new DateTime(2021, 4, 6, 19, 10, 46, 514, DateTimeKind.Local).AddTicks(8650), true, "Finético" },
                    { new Guid("06f55e3f-63d8-4732-8f04-bfbf3d05360c"), new DateTime(2005, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Carlos", "44558896", "21060229", new DateTime(2021, 4, 6, 19, 10, 46, 514, DateTimeKind.Local).AddTicks(8638), true, "Gaiado" },
                    { new Guid("42c37773-ebe6-4383-847e-98e9f5da9b2c"), new DateTime(2005, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "José", "98745122", "21060100", new DateTime(2021, 4, 6, 19, 10, 46, 514, DateTimeKind.Local).AddTicks(8606), true, "Arimatéia" },
                    { new Guid("25d44203-6897-4c6c-8ec0-fe689be09bd9"), new DateTime(2005, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "João", "98564712", "21060656", new DateTime(2021, 4, 6, 19, 10, 46, 514, DateTimeKind.Local).AddTicks(8578), true, "Paulo" },
                    { new Guid("3f9a8d15-04e9-4d67-8a77-fdbb62beb014"), new DateTime(2005, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ananias", "33589624", "21060575", new DateTime(2021, 4, 6, 19, 10, 46, 514, DateTimeKind.Local).AddTicks(8593), true, "Fernandes" },
                    { new Guid("4a8730d5-b447-4c0a-b2fa-2950dcb4b819"), new DateTime(2005, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Vanessa", "99562341", "21061327", new DateTime(2021, 4, 6, 19, 10, 46, 514, DateTimeKind.Local).AddTicks(8444), true, "Lisboa" },
                    { new Guid("58527147-3315-4c6d-93b4-82543d3d06b7"), new DateTime(2005, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Fernanda", "33447789", "21060138", new DateTime(2021, 4, 6, 19, 10, 46, 514, DateTimeKind.Local).AddTicks(8322), true, "Silva" },
                    { new Guid("9934948a-1985-4ec5-97c3-18a7dc481d41"), new DateTime(2005, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Joana", "33556699", "21068380", new DateTime(2021, 4, 6, 19, 10, 46, 514, DateTimeKind.Local).AddTicks(6511), true, "Alves" },
                    { new Guid("9dab1d50-9c21-4c04-a097-b0eaaf7cb218"), new DateTime(2005, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Maria", "99452417", "21065985", new DateTime(2021, 4, 6, 19, 10, 46, 514, DateTimeKind.Local).AddTicks(8558), true, "Madalena" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "EndDate", "Name", "PhoneNumber", "Registration", "StartDate", "Status", "Surname" },
                values: new object[,]
                {
                    { new Guid("b27914c8-3b4c-4876-8fdb-5280abd6edd1"), null, "João", "33506987", "21060141", new DateTime(2021, 4, 6, 19, 10, 46, 514, DateTimeKind.Local).AddTicks(9320), true, "Olavo" },
                    { new Guid("17e1c39f-96a3-4941-837f-1d8158e9d5ac"), null, "José", "44778899", "21061936", new DateTime(2021, 4, 6, 19, 10, 46, 514, DateTimeKind.Local).AddTicks(9226), true, "Roberto" },
                    { new Guid("d7ee79b2-517c-43c4-bb43-036fdeaf4a6d"), null, "Carlos", "33568941", "21060177", new DateTime(2021, 4, 6, 19, 10, 46, 514, DateTimeKind.Local).AddTicks(9283), true, "Eduardo" },
                    { new Guid("5e1e44b8-b3ff-4862-83f0-9bc1600dcb58"), null, "Manuel", "99587462", "21060189", new DateTime(2021, 4, 6, 19, 10, 46, 514, DateTimeKind.Local).AddTicks(9301), true, "Nobre" },
                    { new Guid("91d03af7-325b-4542-98fc-bcbd1e99dac5"), null, "Lucas", "33214896", "21060139", new DateTime(2021, 4, 6, 19, 10, 46, 514, DateTimeKind.Local).AddTicks(9342), true, "Ribas" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name", "TeacherId", "Workload" },
                values: new object[,]
                {
                    { new Guid("1d7fd6ca-fbdf-4919-89f3-065a824b20ed"), "Matemática", new Guid("17e1c39f-96a3-4941-837f-1d8158e9d5ac"), null },
                    { new Guid("daa0d0b6-597f-4c46-aa3b-7ece5a65e61d"), "Limpeza de Gabinete", new Guid("d7ee79b2-517c-43c4-bb43-036fdeaf4a6d"), null },
                    { new Guid("8b035092-aba4-41cd-bb1b-0a775790f017"), "Português", new Guid("5e1e44b8-b3ff-4862-83f0-9bc1600dcb58"), null },
                    { new Guid("4c8175d1-da55-4f75-aebf-baf3dba8bdde"), "Arquitetura de Servidores", new Guid("b27914c8-3b4c-4876-8fdb-5280abd6edd1"), null },
                    { new Guid("a14008d6-f7b7-46a2-9920-619039ef22c6"), "Programação", new Guid("91d03af7-325b-4542-98fc-bcbd1e99dac5"), null }
                });

            migrationBuilder.InsertData(
                table: "CoursesSubjects",
                columns: new[] { "Id", "CourseId", "SubjectId" },
                values: new object[,]
                {
                    { new Guid("ed3b1dee-f400-43a7-931a-cf083cd67dce"), new Guid("a31d0ef3-6871-445f-acc0-b77c9a18d1e5"), new Guid("1d7fd6ca-fbdf-4919-89f3-065a824b20ed") },
                    { new Guid("4b6df1ce-ddf1-4f35-a421-ce7c0a4a7fc9"), new Guid("56ca4cd3-743c-4f5e-a37a-90e72d67081f"), new Guid("1d7fd6ca-fbdf-4919-89f3-065a824b20ed") },
                    { new Guid("63b6c6f3-c29b-4e9a-b315-2d0fb2496c18"), new Guid("883c4831-0201-4529-b533-d8453ffe545b"), new Guid("daa0d0b6-597f-4c46-aa3b-7ece5a65e61d") },
                    { new Guid("518ce648-0333-42ad-89cf-0535cdddf639"), new Guid("a31d0ef3-6871-445f-acc0-b77c9a18d1e5"), new Guid("8b035092-aba4-41cd-bb1b-0a775790f017") },
                    { new Guid("bba58a25-a7b5-44d1-a276-0fd651502a79"), new Guid("883c4831-0201-4529-b533-d8453ffe545b"), new Guid("8b035092-aba4-41cd-bb1b-0a775790f017") },
                    { new Guid("f87ce61f-d955-40b8-9522-d1095888b040"), new Guid("56ca4cd3-743c-4f5e-a37a-90e72d67081f"), new Guid("8b035092-aba4-41cd-bb1b-0a775790f017") },
                    { new Guid("a5a4d521-f5c7-4935-9ee9-e050cb0fe2ab"), new Guid("56ca4cd3-743c-4f5e-a37a-90e72d67081f"), new Guid("4c8175d1-da55-4f75-aebf-baf3dba8bdde") },
                    { new Guid("3b6ce767-fa01-4566-80b4-da1d204d42fc"), new Guid("a31d0ef3-6871-445f-acc0-b77c9a18d1e5"), new Guid("a14008d6-f7b7-46a2-9920-619039ef22c6") }
                });

            migrationBuilder.InsertData(
                table: "StudentsCoursesSubjects",
                columns: new[] { "StudentId", "CourseSubjectId", "EndDate", "Grade", "StartDate" },
                values: new object[,]
                {
                    { new Guid("9934948a-1985-4ec5-97c3-18a7dc481d41"), new Guid("ed3b1dee-f400-43a7-931a-cf083cd67dce"), null, null, new DateTime(2021, 4, 6, 19, 10, 46, 525, DateTimeKind.Local).AddTicks(1947) },
                    { new Guid("9934948a-1985-4ec5-97c3-18a7dc481d41"), new Guid("3b6ce767-fa01-4566-80b4-da1d204d42fc"), null, null, new DateTime(2021, 4, 6, 19, 10, 46, 525, DateTimeKind.Local).AddTicks(5016) },
                    { new Guid("f60a98be-7e8b-4b64-a90a-020d20e180bf"), new Guid("a5a4d521-f5c7-4935-9ee9-e050cb0fe2ab"), null, null, new DateTime(2021, 4, 6, 19, 10, 46, 525, DateTimeKind.Local).AddTicks(5108) },
                    { new Guid("06f55e3f-63d8-4732-8f04-bfbf3d05360c"), new Guid("a5a4d521-f5c7-4935-9ee9-e050cb0fe2ab"), null, null, new DateTime(2021, 4, 6, 19, 10, 46, 525, DateTimeKind.Local).AddTicks(5097) },
                    { new Guid("42c37773-ebe6-4383-847e-98e9f5da9b2c"), new Guid("a5a4d521-f5c7-4935-9ee9-e050cb0fe2ab"), null, null, new DateTime(2021, 4, 6, 19, 10, 46, 525, DateTimeKind.Local).AddTicks(5089) },
                    { new Guid("f60a98be-7e8b-4b64-a90a-020d20e180bf"), new Guid("f87ce61f-d955-40b8-9522-d1095888b040"), null, null, new DateTime(2021, 4, 6, 19, 10, 46, 525, DateTimeKind.Local).AddTicks(5105) },
                    { new Guid("06f55e3f-63d8-4732-8f04-bfbf3d05360c"), new Guid("f87ce61f-d955-40b8-9522-d1095888b040"), null, null, new DateTime(2021, 4, 6, 19, 10, 46, 525, DateTimeKind.Local).AddTicks(5095) },
                    { new Guid("42c37773-ebe6-4383-847e-98e9f5da9b2c"), new Guid("f87ce61f-d955-40b8-9522-d1095888b040"), null, null, new DateTime(2021, 4, 6, 19, 10, 46, 525, DateTimeKind.Local).AddTicks(5083) },
                    { new Guid("3f9a8d15-04e9-4d67-8a77-fdbb62beb014"), new Guid("bba58a25-a7b5-44d1-a276-0fd651502a79"), null, null, new DateTime(2021, 4, 6, 19, 10, 46, 525, DateTimeKind.Local).AddTicks(5077) },
                    { new Guid("25d44203-6897-4c6c-8ec0-fe689be09bd9"), new Guid("bba58a25-a7b5-44d1-a276-0fd651502a79"), null, null, new DateTime(2021, 4, 6, 19, 10, 46, 525, DateTimeKind.Local).AddTicks(5071) },
                    { new Guid("9dab1d50-9c21-4c04-a097-b0eaaf7cb218"), new Guid("bba58a25-a7b5-44d1-a276-0fd651502a79"), null, null, new DateTime(2021, 4, 6, 19, 10, 46, 525, DateTimeKind.Local).AddTicks(5065) },
                    { new Guid("4a8730d5-b447-4c0a-b2fa-2950dcb4b819"), new Guid("518ce648-0333-42ad-89cf-0535cdddf639"), null, null, new DateTime(2021, 4, 6, 19, 10, 46, 525, DateTimeKind.Local).AddTicks(5050) },
                    { new Guid("58527147-3315-4c6d-93b4-82543d3d06b7"), new Guid("518ce648-0333-42ad-89cf-0535cdddf639"), null, null, new DateTime(2021, 4, 6, 19, 10, 46, 525, DateTimeKind.Local).AddTicks(5027) },
                    { new Guid("9934948a-1985-4ec5-97c3-18a7dc481d41"), new Guid("518ce648-0333-42ad-89cf-0535cdddf639"), null, null, new DateTime(2021, 4, 6, 19, 10, 46, 525, DateTimeKind.Local).AddTicks(4949) },
                    { new Guid("3f9a8d15-04e9-4d67-8a77-fdbb62beb014"), new Guid("63b6c6f3-c29b-4e9a-b315-2d0fb2496c18"), null, null, new DateTime(2021, 4, 6, 19, 10, 46, 525, DateTimeKind.Local).AddTicks(5074) },
                    { new Guid("25d44203-6897-4c6c-8ec0-fe689be09bd9"), new Guid("63b6c6f3-c29b-4e9a-b315-2d0fb2496c18"), null, null, new DateTime(2021, 4, 6, 19, 10, 46, 525, DateTimeKind.Local).AddTicks(5068) },
                    { new Guid("9dab1d50-9c21-4c04-a097-b0eaaf7cb218"), new Guid("63b6c6f3-c29b-4e9a-b315-2d0fb2496c18"), null, null, new DateTime(2021, 4, 6, 19, 10, 46, 525, DateTimeKind.Local).AddTicks(5060) },
                    { new Guid("f60a98be-7e8b-4b64-a90a-020d20e180bf"), new Guid("4b6df1ce-ddf1-4f35-a421-ce7c0a4a7fc9"), null, null, new DateTime(2021, 4, 6, 19, 10, 46, 525, DateTimeKind.Local).AddTicks(5101) },
                    { new Guid("06f55e3f-63d8-4732-8f04-bfbf3d05360c"), new Guid("4b6df1ce-ddf1-4f35-a421-ce7c0a4a7fc9"), null, null, new DateTime(2021, 4, 6, 19, 10, 46, 525, DateTimeKind.Local).AddTicks(5092) },
                    { new Guid("42c37773-ebe6-4383-847e-98e9f5da9b2c"), new Guid("4b6df1ce-ddf1-4f35-a421-ce7c0a4a7fc9"), null, null, new DateTime(2021, 4, 6, 19, 10, 46, 525, DateTimeKind.Local).AddTicks(5080) },
                    { new Guid("4a8730d5-b447-4c0a-b2fa-2950dcb4b819"), new Guid("ed3b1dee-f400-43a7-931a-cf083cd67dce"), null, null, new DateTime(2021, 4, 6, 19, 10, 46, 525, DateTimeKind.Local).AddTicks(5044) },
                    { new Guid("58527147-3315-4c6d-93b4-82543d3d06b7"), new Guid("ed3b1dee-f400-43a7-931a-cf083cd67dce"), null, null, new DateTime(2021, 4, 6, 19, 10, 46, 525, DateTimeKind.Local).AddTicks(5023) },
                    { new Guid("58527147-3315-4c6d-93b4-82543d3d06b7"), new Guid("3b6ce767-fa01-4566-80b4-da1d204d42fc"), null, null, new DateTime(2021, 4, 6, 19, 10, 46, 525, DateTimeKind.Local).AddTicks(5040) },
                    { new Guid("4a8730d5-b447-4c0a-b2fa-2950dcb4b819"), new Guid("3b6ce767-fa01-4566-80b4-da1d204d42fc"), null, null, new DateTime(2021, 4, 6, 19, 10, 46, 525, DateTimeKind.Local).AddTicks(5054) }
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
