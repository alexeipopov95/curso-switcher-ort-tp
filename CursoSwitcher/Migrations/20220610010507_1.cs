using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CursoSwitcher.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Visible_id = table.Column<string>(type: "TEXT", nullable: false),
                    Created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Careers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Visible_id = table.Column<string>(type: "TEXT", nullable: false),
                    Created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Careers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    CareerId = table.Column<int>(type: "INTEGER", nullable: false),
                    Visible_id = table.Column<string>(type: "TEXT", nullable: false),
                    Created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Careers_CareerId",
                        column: x => x.CareerId,
                        principalTable: "Careers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Last_name = table.Column<string>(type: "TEXT", nullable: false),
                    Dni = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Is_moderator = table.Column<bool>(type: "INTEGER", nullable: false),
                    CourseId = table.Column<int>(type: "INTEGER", nullable: true),
                    CareerId = table.Column<int>(type: "INTEGER", nullable: true),
                    CampusId = table.Column<int>(type: "INTEGER", nullable: true),
                    Visible_id = table.Column<string>(type: "TEXT", nullable: false),
                    Created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Profiles_Campus_CampusId",
                        column: x => x.CampusId,
                        principalTable: "Campus",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Profiles_Careers_CareerId",
                        column: x => x.CareerId,
                        principalTable: "Careers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Profiles_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProfileId = table.Column<int>(type: "INTEGER", nullable: false),
                    RequestedCourseId = table.Column<int>(type: "INTEGER", nullable: false),
                    OfferedCourseId = table.Column<int>(type: "INTEGER", nullable: false),
                    status = table.Column<string>(type: "TEXT", nullable: false),
                    Visible_id = table.Column<string>(type: "TEXT", nullable: false),
                    Created_at = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated_at = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_Courses_OfferedCourseId",
                        column: x => x.OfferedCourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requests_Courses_RequestedCourseId",
                        column: x => x.RequestedCourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requests_Profiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "Profiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Campus",
                columns: new[] { "Id", "Created_at", "Description", "Name", "Updated_at", "Visible_id" },
                values: new object[] { 1, new DateTime(2022, 6, 9, 22, 5, 6, 872, DateTimeKind.Local).AddTicks(5771), "Sede Almagro\nDirección: Yatay 240\nProvincia: Buenos Aires\nPais: Argentina\nTeléfono: 4958-9000", "Yatay", new DateTime(2022, 6, 9, 22, 5, 6, 872, DateTimeKind.Local).AddTicks(5777), "ccfb9556-63a6-4767-8079-ced173cfc78c" });

            migrationBuilder.InsertData(
                table: "Campus",
                columns: new[] { "Id", "Created_at", "Description", "Name", "Updated_at", "Visible_id" },
                values: new object[] { 2, new DateTime(2022, 6, 9, 22, 5, 6, 872, DateTimeKind.Local).AddTicks(5781), "Sede Belgrano\nDirección: Av. del Libertador 6796\nProvincia: Buenos Aires\nPais: Argentina\nTeléfono: 4789-6500 ", "Belgrano", new DateTime(2022, 6, 9, 22, 5, 6, 872, DateTimeKind.Local).AddTicks(5782), "417810b9-5aaf-4b4f-a0be-4331a5854360" });

            migrationBuilder.InsertData(
                table: "Careers",
                columns: new[] { "Id", "Created_at", "Description", "Name", "Updated_at", "Visible_id" },
                values: new object[] { 1, new DateTime(2022, 6, 9, 22, 5, 6, 872, DateTimeKind.Local).AddTicks(5849), "Duración: 2 años.\nTitulo Otorgado: Analista de Sistemas.", "Analista de Sistemas", new DateTime(2022, 6, 9, 22, 5, 6, 872, DateTimeKind.Local).AddTicks(5849), "ba054c3e-6746-45da-a4ec-375e409ec118" });

            migrationBuilder.InsertData(
                table: "Careers",
                columns: new[] { "Id", "Created_at", "Description", "Name", "Updated_at", "Visible_id" },
                values: new object[] { 2, new DateTime(2022, 6, 9, 22, 5, 6, 872, DateTimeKind.Local).AddTicks(5852), "Duración: 3 años.\nTitulo Otorgado: Técnico Superior en Química y Biotecnología.", "Biotecnología", new DateTime(2022, 6, 9, 22, 5, 6, 872, DateTimeKind.Local).AddTicks(5852), "5778c9c4-b3d4-41a3-b912-63867d2e21cd" });

            migrationBuilder.InsertData(
                table: "Careers",
                columns: new[] { "Id", "Created_at", "Description", "Name", "Updated_at", "Visible_id" },
                values: new object[] { 3, new DateTime(2022, 6, 9, 22, 5, 6, 872, DateTimeKind.Local).AddTicks(5854), "Duración: 2 años.\nTitulo Otorgado: Técnico Superior en Producción Musical.", "Sonido y Producción Musical", new DateTime(2022, 6, 9, 22, 5, 6, 872, DateTimeKind.Local).AddTicks(5854), "8daad9f2-9890-4f03-990e-86a358a25d55" });

            migrationBuilder.InsertData(
                table: "Careers",
                columns: new[] { "Id", "Created_at", "Description", "Name", "Updated_at", "Visible_id" },
                values: new object[] { 4, new DateTime(2022, 6, 9, 22, 5, 6, 872, DateTimeKind.Local).AddTicks(5856), "Duración: 2 años.\nTitulo Otorgado: Técnico Superior en Diseño Gráfico Digital.", "Diseño Digital", new DateTime(2022, 6, 9, 22, 5, 6, 872, DateTimeKind.Local).AddTicks(5856), "d6d7f230-5755-47c9-a89c-02cf995a0589" });

            migrationBuilder.InsertData(
                table: "Careers",
                columns: new[] { "Id", "Created_at", "Description", "Name", "Updated_at", "Visible_id" },
                values: new object[] { 5, new DateTime(2022, 6, 9, 22, 5, 6, 872, DateTimeKind.Local).AddTicks(5858), "Duración: 2 años.\nTitulo Otorgado: Técnico Superior en Diseño Industrial.", "Diseño Industrial", new DateTime(2022, 6, 9, 22, 5, 6, 872, DateTimeKind.Local).AddTicks(5858), "b31ba083-fbfd-4443-83ad-9499af27ae89" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "CampusId", "CareerId", "CourseId", "Created_at", "Dni", "Email", "Is_moderator", "Last_name", "Name", "Password", "Updated_at", "Visible_id" },
                values: new object[] { 1, null, null, null, new DateTime(2022, 6, 9, 22, 5, 6, 872, DateTimeKind.Local).AddTicks(5911), "ADMIN", "secretaria-ites1@ort.edu.ar", true, "ADMIN", "ADMIN", "ADMIN", new DateTime(2022, 6, 9, 22, 5, 6, 872, DateTimeKind.Local).AddTicks(5912), "91429bd1-710c-4fcf-8bc6-c22825b19f8b" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CareerId", "Created_at", "Description", "Name", "Updated_at", "Visible_id" },
                values: new object[] { 1, 1, new DateTime(2022, 6, 9, 22, 5, 6, 872, DateTimeKind.Local).AddTicks(5870), "Organización Empresarial 1°1°", "11OEM", new DateTime(2022, 6, 9, 22, 5, 6, 872, DateTimeKind.Local).AddTicks(5870), "a6b9c623-b8d8-4b22-8838-1c1fe3413e2d" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CareerId", "Created_at", "Description", "Name", "Updated_at", "Visible_id" },
                values: new object[] { 2, 1, new DateTime(2022, 6, 9, 22, 5, 6, 872, DateTimeKind.Local).AddTicks(5875), "Organización Empresarial 1°2°", "12OEM", new DateTime(2022, 6, 9, 22, 5, 6, 872, DateTimeKind.Local).AddTicks(5875), "dd5a26fb-4fcd-45c4-b527-153417ba57c3" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CareerId", "Created_at", "Description", "Name", "Updated_at", "Visible_id" },
                values: new object[] { 3, 1, new DateTime(2022, 6, 9, 22, 5, 6, 872, DateTimeKind.Local).AddTicks(5878), "Taller de Programación 1°1°", "11TP", new DateTime(2022, 6, 9, 22, 5, 6, 872, DateTimeKind.Local).AddTicks(5878), "4e7baac1-bd7a-47b1-b002-cba851099950" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CareerId", "Created_at", "Description", "Name", "Updated_at", "Visible_id" },
                values: new object[] { 4, 1, new DateTime(2022, 6, 9, 22, 5, 6, 872, DateTimeKind.Local).AddTicks(5880), "Taller de Programación 1°2°", "12TP", new DateTime(2022, 6, 9, 22, 5, 6, 872, DateTimeKind.Local).AddTicks(5880), "113c69cb-59d1-4c0e-ab51-2258995d8584" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CareerId", "Created_at", "Description", "Name", "Updated_at", "Visible_id" },
                values: new object[] { 5, 2, new DateTime(2022, 6, 9, 22, 5, 6, 872, DateTimeKind.Local).AddTicks(5882), "Biotecnología 3°1°", "31BT", new DateTime(2022, 6, 9, 22, 5, 6, 872, DateTimeKind.Local).AddTicks(5882), "fd345f1b-e4d5-4390-a08d-17e2418964d4" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CareerId", "Created_at", "Description", "Name", "Updated_at", "Visible_id" },
                values: new object[] { 6, 2, new DateTime(2022, 6, 9, 22, 5, 6, 872, DateTimeKind.Local).AddTicks(5884), "Biotecnología 3°2°", "32BT", new DateTime(2022, 6, 9, 22, 5, 6, 872, DateTimeKind.Local).AddTicks(5884), "65643569-12c5-46aa-8521-97b4352f0960" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CareerId", "Created_at", "Description", "Name", "Updated_at", "Visible_id" },
                values: new object[] { 7, 2, new DateTime(2022, 6, 9, 22, 5, 6, 872, DateTimeKind.Local).AddTicks(5886), "Farmacoquímica 2°1°", "21FA", new DateTime(2022, 6, 9, 22, 5, 6, 872, DateTimeKind.Local).AddTicks(5886), "60f9f5ad-d3ae-41c0-82b3-c602990302ed" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CareerId", "Created_at", "Description", "Name", "Updated_at", "Visible_id" },
                values: new object[] { 8, 2, new DateTime(2022, 6, 9, 22, 5, 6, 872, DateTimeKind.Local).AddTicks(5888), "Farmacoquímica 2°2°", "22FA", new DateTime(2022, 6, 9, 22, 5, 6, 872, DateTimeKind.Local).AddTicks(5888), "1f32dea7-96f6-400f-85af-a9fae454a017" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CareerId", "Created_at", "Description", "Name", "Updated_at", "Visible_id" },
                values: new object[] { 9, 1, new DateTime(2022, 6, 9, 22, 5, 6, 872, DateTimeKind.Local).AddTicks(5890), "Bases de datos 3°1°", "31BD", new DateTime(2022, 6, 9, 22, 5, 6, 872, DateTimeKind.Local).AddTicks(5891), "7e708df4-b54d-41a3-bb66-59428e9bf2f6" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CareerId", "Created_at", "Description", "Name", "Updated_at", "Visible_id" },
                values: new object[] { 10, 1, new DateTime(2022, 6, 9, 22, 5, 6, 872, DateTimeKind.Local).AddTicks(5894), "Bases de datos 3°2°", "32BD", new DateTime(2022, 6, 9, 22, 5, 6, 872, DateTimeKind.Local).AddTicks(5894), "083c264a-e0f6-429d-bb13-7b599a368a80" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CareerId", "Created_at", "Description", "Name", "Updated_at", "Visible_id" },
                values: new object[] { 11, 1, new DateTime(2022, 6, 9, 22, 5, 6, 872, DateTimeKind.Local).AddTicks(5896), "Programación 2°1°", "21PR", new DateTime(2022, 6, 9, 22, 5, 6, 872, DateTimeKind.Local).AddTicks(5897), "e7669ab8-505b-4461-ba47-8b7fcfd6def8" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CareerId", "Created_at", "Description", "Name", "Updated_at", "Visible_id" },
                values: new object[] { 12, 1, new DateTime(2022, 6, 9, 22, 5, 6, 872, DateTimeKind.Local).AddTicks(5898), "Programación 2°2°", "22PR", new DateTime(2022, 6, 9, 22, 5, 6, 872, DateTimeKind.Local).AddTicks(5899), "fe506d54-afdb-4bb4-b758-41dbda87b354" });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CareerId",
                table: "Courses",
                column: "CareerId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_CampusId",
                table: "Profiles",
                column: "CampusId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_CareerId",
                table: "Profiles",
                column: "CareerId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_CourseId",
                table: "Profiles",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_OfferedCourseId",
                table: "Requests",
                column: "OfferedCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_ProfileId",
                table: "Requests",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_RequestedCourseId",
                table: "Requests",
                column: "RequestedCourseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "Campus");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Careers");
        }
    }
}
