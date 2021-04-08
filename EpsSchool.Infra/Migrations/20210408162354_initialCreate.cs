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
                    { new Guid("0e6ab627-003f-49ed-9a96-5433b0899de0"), "Informatica" },
                    { new Guid("cd9cb39e-4e77-47a5-abf5-82a3f76d56fe"), "Manutenção de Micros" },
                    { new Guid("598e17a7-3c98-4ba9-9878-0c2b2e78bb91"), "Redes de Computadores" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "BirthDate", "EndDate", "Enrollment", "Name", "PhoneNumber", "StartDate", "Status", "Surname" },
                values: new object[,]
                {
                    { new Guid("331f2e60-858d-4b74-9872-86dd9d526562"), new DateTime(2005, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "21080947", "Diogenes", "22665588", new DateTime(2021, 4, 8, 13, 23, 53, 938, DateTimeKind.Local).AddTicks(8471), true, "Finético" },
                    { new Guid("9b89bf54-4642-40eb-b5d5-5220b4826fd5"), new DateTime(2005, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "21087780", "Carlos", "44558896", new DateTime(2021, 4, 8, 13, 23, 53, 938, DateTimeKind.Local).AddTicks(8449), true, "Gaiado" },
                    { new Guid("4f5e8c46-462a-4510-80db-5835f2d5fee1"), new DateTime(2005, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "21080555", "José", "98745122", new DateTime(2021, 4, 8, 13, 23, 53, 938, DateTimeKind.Local).AddTicks(8436), true, "Arimatéia" },
                    { new Guid("2af684f2-9e20-499d-a548-7c4aff1ea340"), new DateTime(2005, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "21081773", "João", "98564712", new DateTime(2021, 4, 8, 13, 23, 53, 938, DateTimeKind.Local).AddTicks(8402), true, "Paulo" },
                    { new Guid("7869c977-ac91-4cd2-9425-804a70adfdf7"), new DateTime(2005, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "21080198", "Ananias", "33589624", new DateTime(2021, 4, 8, 13, 23, 53, 938, DateTimeKind.Local).AddTicks(8421), true, "Fernandes" },
                    { new Guid("d3cb36ee-f1c2-48ec-a649-0b2e65eed2ad"), new DateTime(2005, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "21084193", "Vanessa", "99562341", new DateTime(2021, 4, 8, 13, 23, 53, 938, DateTimeKind.Local).AddTicks(8377), true, "Lisboa" },
                    { new Guid("435172d4-e829-4775-8b8b-7ca347ec7a17"), new DateTime(2005, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "21080133", "Fernanda", "33447789", new DateTime(2021, 4, 8, 13, 23, 53, 938, DateTimeKind.Local).AddTicks(8276), true, "Silva" },
                    { new Guid("79694048-3183-4c2f-9247-17ec7786d3ac"), new DateTime(2005, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "21081971", "Joana", "33556699", new DateTime(2021, 4, 8, 13, 23, 53, 938, DateTimeKind.Local).AddTicks(6285), true, "Alves" },
                    { new Guid("6a8f5d01-4e5e-4920-a899-82b493146ac5"), new DateTime(2005, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "21081380", "Maria", "99452417", new DateTime(2021, 4, 8, 13, 23, 53, 938, DateTimeKind.Local).AddTicks(8391), true, "Madalena" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "EndDate", "Enrollment", "Name", "PhoneNumber", "StartDate", "Status", "Surname" },
                values: new object[,]
                {
                    { new Guid("e79b39f1-2bde-4389-9d89-74bfb2aee6c5"), null, "21080562", "João", "33506987", new DateTime(2021, 4, 8, 13, 23, 53, 938, DateTimeKind.Local).AddTicks(9028), true, "Olavo" },
                    { new Guid("541e2320-a8ef-401d-a136-63b68946fccc"), null, "21081855", "José", "44778899", new DateTime(2021, 4, 8, 13, 23, 53, 938, DateTimeKind.Local).AddTicks(8966), true, "Roberto" },
                    { new Guid("af621e46-bf5f-4ed7-91b4-ca524787ed07"), null, "21080126", "Carlos", "33568941", new DateTime(2021, 4, 8, 13, 23, 53, 938, DateTimeKind.Local).AddTicks(9002), true, "Eduardo" },
                    { new Guid("90946f61-21dc-4b5f-9b3f-a0ffd002eb62"), null, "21081182", "Manuel", "99587462", new DateTime(2021, 4, 8, 13, 23, 53, 938, DateTimeKind.Local).AddTicks(9015), true, "Nobre" },
                    { new Guid("8e40e177-454d-49c6-a771-a211715b9172"), null, "21080153", "Lucas", "33214896", new DateTime(2021, 4, 8, 13, 23, 53, 938, DateTimeKind.Local).AddTicks(9042), true, "Ribas" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Name", "TeacherId" },
                values: new object[,]
                {
                    { new Guid("843d9700-a152-489f-b76c-921fe20e735b"), "Matemática", new Guid("541e2320-a8ef-401d-a136-63b68946fccc") },
                    { new Guid("9ca5e0dd-1925-4aba-94b2-2c652ab0e36e"), "Limpeza de Gabinete", new Guid("af621e46-bf5f-4ed7-91b4-ca524787ed07") },
                    { new Guid("9751581d-8951-41ea-8f6f-3ae459c72d6d"), "Português", new Guid("90946f61-21dc-4b5f-9b3f-a0ffd002eb62") },
                    { new Guid("50e5eb5a-9cfb-477b-b99a-a1d886b9b987"), "Arquitetura de Servidores", new Guid("e79b39f1-2bde-4389-9d89-74bfb2aee6c5") },
                    { new Guid("c6f329fa-50c4-4471-bc28-ccd3780bd76c"), "Programação", new Guid("8e40e177-454d-49c6-a771-a211715b9172") }
                });

            migrationBuilder.InsertData(
                table: "CoursesSubjects",
                columns: new[] { "Id", "CourseId", "SubjectId" },
                values: new object[,]
                {
                    { new Guid("7eb9af3a-457f-4974-8a40-3b83a42bc527"), new Guid("0e6ab627-003f-49ed-9a96-5433b0899de0"), new Guid("843d9700-a152-489f-b76c-921fe20e735b") },
                    { new Guid("8bce8093-63ea-4404-a678-4d4c3108cb9f"), new Guid("598e17a7-3c98-4ba9-9878-0c2b2e78bb91"), new Guid("843d9700-a152-489f-b76c-921fe20e735b") },
                    { new Guid("518adb37-b8a3-48ed-b0ac-5fa1d77051c6"), new Guid("cd9cb39e-4e77-47a5-abf5-82a3f76d56fe"), new Guid("9ca5e0dd-1925-4aba-94b2-2c652ab0e36e") },
                    { new Guid("b7c6472b-0562-4927-8eba-47e2c7495b5a"), new Guid("0e6ab627-003f-49ed-9a96-5433b0899de0"), new Guid("9751581d-8951-41ea-8f6f-3ae459c72d6d") },
                    { new Guid("665f71d1-f2b6-474d-b79c-d1410114f684"), new Guid("cd9cb39e-4e77-47a5-abf5-82a3f76d56fe"), new Guid("9751581d-8951-41ea-8f6f-3ae459c72d6d") },
                    { new Guid("edca5bb8-a68c-4870-aaf1-3e29378f92fa"), new Guid("598e17a7-3c98-4ba9-9878-0c2b2e78bb91"), new Guid("9751581d-8951-41ea-8f6f-3ae459c72d6d") },
                    { new Guid("f84640c5-6b8d-4971-9c5d-f2cc0159690f"), new Guid("598e17a7-3c98-4ba9-9878-0c2b2e78bb91"), new Guid("50e5eb5a-9cfb-477b-b99a-a1d886b9b987") },
                    { new Guid("39e08dfd-f6d7-4bf6-8a82-f6593761b2b2"), new Guid("0e6ab627-003f-49ed-9a96-5433b0899de0"), new Guid("c6f329fa-50c4-4471-bc28-ccd3780bd76c") }
                });

            migrationBuilder.InsertData(
                table: "StudentsCoursesSubjects",
                columns: new[] { "StudentId", "CourseSubjectId", "EndDate", "Grade", "StartDate" },
                values: new object[,]
                {
                    { new Guid("79694048-3183-4c2f-9247-17ec7786d3ac"), new Guid("7eb9af3a-457f-4974-8a40-3b83a42bc527"), null, null, new DateTime(2021, 4, 8, 13, 23, 53, 948, DateTimeKind.Local).AddTicks(8363) },
                    { new Guid("79694048-3183-4c2f-9247-17ec7786d3ac"), new Guid("39e08dfd-f6d7-4bf6-8a82-f6593761b2b2"), null, null, new DateTime(2021, 4, 8, 13, 23, 53, 948, DateTimeKind.Local).AddTicks(9587) },
                    { new Guid("331f2e60-858d-4b74-9872-86dd9d526562"), new Guid("f84640c5-6b8d-4971-9c5d-f2cc0159690f"), null, null, new DateTime(2021, 4, 8, 13, 23, 53, 948, DateTimeKind.Local).AddTicks(9719) },
                    { new Guid("9b89bf54-4642-40eb-b5d5-5220b4826fd5"), new Guid("f84640c5-6b8d-4971-9c5d-f2cc0159690f"), null, null, new DateTime(2021, 4, 8, 13, 23, 53, 948, DateTimeKind.Local).AddTicks(9711) },
                    { new Guid("4f5e8c46-462a-4510-80db-5835f2d5fee1"), new Guid("f84640c5-6b8d-4971-9c5d-f2cc0159690f"), null, null, new DateTime(2021, 4, 8, 13, 23, 53, 948, DateTimeKind.Local).AddTicks(9636) },
                    { new Guid("331f2e60-858d-4b74-9872-86dd9d526562"), new Guid("edca5bb8-a68c-4870-aaf1-3e29378f92fa"), null, null, new DateTime(2021, 4, 8, 13, 23, 53, 948, DateTimeKind.Local).AddTicks(9716) },
                    { new Guid("9b89bf54-4642-40eb-b5d5-5220b4826fd5"), new Guid("edca5bb8-a68c-4870-aaf1-3e29378f92fa"), null, null, new DateTime(2021, 4, 8, 13, 23, 53, 948, DateTimeKind.Local).AddTicks(9708) },
                    { new Guid("4f5e8c46-462a-4510-80db-5835f2d5fee1"), new Guid("edca5bb8-a68c-4870-aaf1-3e29378f92fa"), null, null, new DateTime(2021, 4, 8, 13, 23, 53, 948, DateTimeKind.Local).AddTicks(9631) },
                    { new Guid("7869c977-ac91-4cd2-9425-804a70adfdf7"), new Guid("665f71d1-f2b6-474d-b79c-d1410114f684"), null, null, new DateTime(2021, 4, 8, 13, 23, 53, 948, DateTimeKind.Local).AddTicks(9626) },
                    { new Guid("2af684f2-9e20-499d-a548-7c4aff1ea340"), new Guid("665f71d1-f2b6-474d-b79c-d1410114f684"), null, null, new DateTime(2021, 4, 8, 13, 23, 53, 948, DateTimeKind.Local).AddTicks(9621) },
                    { new Guid("6a8f5d01-4e5e-4920-a899-82b493146ac5"), new Guid("665f71d1-f2b6-474d-b79c-d1410114f684"), null, null, new DateTime(2021, 4, 8, 13, 23, 53, 948, DateTimeKind.Local).AddTicks(9616) },
                    { new Guid("d3cb36ee-f1c2-48ec-a649-0b2e65eed2ad"), new Guid("b7c6472b-0562-4927-8eba-47e2c7495b5a"), null, null, new DateTime(2021, 4, 8, 13, 23, 53, 948, DateTimeKind.Local).AddTicks(9606) },
                    { new Guid("435172d4-e829-4775-8b8b-7ca347ec7a17"), new Guid("b7c6472b-0562-4927-8eba-47e2c7495b5a"), null, null, new DateTime(2021, 4, 8, 13, 23, 53, 948, DateTimeKind.Local).AddTicks(9594) },
                    { new Guid("79694048-3183-4c2f-9247-17ec7786d3ac"), new Guid("b7c6472b-0562-4927-8eba-47e2c7495b5a"), null, null, new DateTime(2021, 4, 8, 13, 23, 53, 948, DateTimeKind.Local).AddTicks(9546) },
                    { new Guid("7869c977-ac91-4cd2-9425-804a70adfdf7"), new Guid("518adb37-b8a3-48ed-b0ac-5fa1d77051c6"), null, null, new DateTime(2021, 4, 8, 13, 23, 53, 948, DateTimeKind.Local).AddTicks(9623) },
                    { new Guid("2af684f2-9e20-499d-a548-7c4aff1ea340"), new Guid("518adb37-b8a3-48ed-b0ac-5fa1d77051c6"), null, null, new DateTime(2021, 4, 8, 13, 23, 53, 948, DateTimeKind.Local).AddTicks(9618) },
                    { new Guid("6a8f5d01-4e5e-4920-a899-82b493146ac5"), new Guid("518adb37-b8a3-48ed-b0ac-5fa1d77051c6"), null, null, new DateTime(2021, 4, 8, 13, 23, 53, 948, DateTimeKind.Local).AddTicks(9613) },
                    { new Guid("331f2e60-858d-4b74-9872-86dd9d526562"), new Guid("8bce8093-63ea-4404-a678-4d4c3108cb9f"), null, null, new DateTime(2021, 4, 8, 13, 23, 53, 948, DateTimeKind.Local).AddTicks(9713) },
                    { new Guid("9b89bf54-4642-40eb-b5d5-5220b4826fd5"), new Guid("8bce8093-63ea-4404-a678-4d4c3108cb9f"), null, null, new DateTime(2021, 4, 8, 13, 23, 53, 948, DateTimeKind.Local).AddTicks(9703) },
                    { new Guid("4f5e8c46-462a-4510-80db-5835f2d5fee1"), new Guid("8bce8093-63ea-4404-a678-4d4c3108cb9f"), null, null, new DateTime(2021, 4, 8, 13, 23, 53, 948, DateTimeKind.Local).AddTicks(9628) },
                    { new Guid("d3cb36ee-f1c2-48ec-a649-0b2e65eed2ad"), new Guid("7eb9af3a-457f-4974-8a40-3b83a42bc527"), null, null, new DateTime(2021, 4, 8, 13, 23, 53, 948, DateTimeKind.Local).AddTicks(9603) },
                    { new Guid("435172d4-e829-4775-8b8b-7ca347ec7a17"), new Guid("7eb9af3a-457f-4974-8a40-3b83a42bc527"), null, null, new DateTime(2021, 4, 8, 13, 23, 53, 948, DateTimeKind.Local).AddTicks(9591) },
                    { new Guid("435172d4-e829-4775-8b8b-7ca347ec7a17"), new Guid("39e08dfd-f6d7-4bf6-8a82-f6593761b2b2"), null, null, new DateTime(2021, 4, 8, 13, 23, 53, 948, DateTimeKind.Local).AddTicks(9600) },
                    { new Guid("d3cb36ee-f1c2-48ec-a649-0b2e65eed2ad"), new Guid("39e08dfd-f6d7-4bf6-8a82-f6593761b2b2"), null, null, new DateTime(2021, 4, 8, 13, 23, 53, 948, DateTimeKind.Local).AddTicks(9608) }
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
