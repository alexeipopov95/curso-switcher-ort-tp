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
                    status = table.Column<string>(type: "TEXT", nullable: true),
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
                values: new object[] { 1, new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4019), "Sede Almagro\nDirección: Yatay 240\nProvincia: Buenos Aires\nPais: Argentina\nTeléfono: 4958-9000", "Yatay", new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4026), "c912a0d6-6602-4efe-8482-e175fa3addfb" });

            migrationBuilder.InsertData(
                table: "Campus",
                columns: new[] { "Id", "Created_at", "Description", "Name", "Updated_at", "Visible_id" },
                values: new object[] { 2, new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4030), "Sede Belgrano\nDirección: Av. del Libertador 6796\nProvincia: Buenos Aires\nPais: Argentina\nTeléfono: 4789-6500 ", "Belgrano", new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4030), "3c48b517-a750-4d4f-b23f-311f31ea9836" });

            migrationBuilder.InsertData(
                table: "Careers",
                columns: new[] { "Id", "Created_at", "Description", "Name", "Updated_at", "Visible_id" },
                values: new object[] { 1, new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4126), "Duración: 2 años.\nTitulo Otorgado: Analista de Sistemas.", "Analista de Sistemas", new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4126), "bcbddcc7-d1d4-4623-bd14-02140c8d850a" });

            migrationBuilder.InsertData(
                table: "Careers",
                columns: new[] { "Id", "Created_at", "Description", "Name", "Updated_at", "Visible_id" },
                values: new object[] { 2, new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4129), "Duración: 3 años.\nTitulo Otorgado: Técnico Superior en Química y Biotecnología.", "Biotecnología", new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4129), "1e60f890-987a-4913-a0ad-ade79856f233" });

            migrationBuilder.InsertData(
                table: "Careers",
                columns: new[] { "Id", "Created_at", "Description", "Name", "Updated_at", "Visible_id" },
                values: new object[] { 3, new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4131), "Duración: 2 años.\nTitulo Otorgado: Técnico Superior en Producción Musical.", "Sonido y Producción Musical", new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4131), "ab22a5e1-4963-402a-aa1c-44651c940b7a" });

            migrationBuilder.InsertData(
                table: "Careers",
                columns: new[] { "Id", "Created_at", "Description", "Name", "Updated_at", "Visible_id" },
                values: new object[] { 4, new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4134), "Duración: 2 años.\nTitulo Otorgado: Técnico Superior en Diseño Gráfico Digital.", "Diseño Digital", new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4134), "6548f49d-270a-4eef-814b-3f9bd45b6f72" });

            migrationBuilder.InsertData(
                table: "Careers",
                columns: new[] { "Id", "Created_at", "Description", "Name", "Updated_at", "Visible_id" },
                values: new object[] { 5, new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4136), "Duración: 2 años.\nTitulo Otorgado: Técnico Superior en Diseño Industrial.", "Diseño Industrial", new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4136), "dc25a104-0ee4-4e1f-b8df-1b7e1daad926" });

            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "CampusId", "CareerId", "CourseId", "Created_at", "Dni", "Email", "Is_moderator", "Last_name", "Name", "Password", "Updated_at", "Visible_id" },
                values: new object[] { 1, null, null, null, new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4202), "ADMIN", "secretaria-ites1@ort.edu.ar", true, "ADMIN", "ADMIN", "ADMIN", new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4203), "9965a503-2d9c-45e1-97fb-2fd137346c1b" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CareerId", "Created_at", "Description", "Name", "Updated_at", "Visible_id" },
                values: new object[] { 1, 1, new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4152), "Organización Empresarial 1°1°", "11OEM", new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4153), "72f39a12-a3d1-4582-8c76-9b583ebd8a99" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CareerId", "Created_at", "Description", "Name", "Updated_at", "Visible_id" },
                values: new object[] { 2, 1, new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4158), "Organización Empresarial 1°2°", "12OEM", new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4158), "2484bf46-e683-4361-8ae0-72e054d63884" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CareerId", "Created_at", "Description", "Name", "Updated_at", "Visible_id" },
                values: new object[] { 3, 1, new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4161), "Taller de Programación 1°1°", "11TP", new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4161), "15e9cbde-c156-424c-9dba-6623c7e8e1b1" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CareerId", "Created_at", "Description", "Name", "Updated_at", "Visible_id" },
                values: new object[] { 4, 1, new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4163), "Taller de Programación 1°2°", "12TP", new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4163), "e93d8635-6421-4767-b0dd-f91eba6ad1f1" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CareerId", "Created_at", "Description", "Name", "Updated_at", "Visible_id" },
                values: new object[] { 5, 2, new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4166), "Biotecnología 3°1°", "31BT", new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4166), "0dea8410-8b8b-4a22-9f94-d58f148599f7" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CareerId", "Created_at", "Description", "Name", "Updated_at", "Visible_id" },
                values: new object[] { 6, 2, new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4168), "Biotecnología 3°2°", "32BT", new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4168), "5dab8598-3e1e-440a-a97d-edf19248e831" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CareerId", "Created_at", "Description", "Name", "Updated_at", "Visible_id" },
                values: new object[] { 7, 2, new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4170), "Farmacoquímica 2°1°", "21FA", new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4170), "7993a22c-15f9-42d9-94c0-69e1fbd42498" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CareerId", "Created_at", "Description", "Name", "Updated_at", "Visible_id" },
                values: new object[] { 8, 2, new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4172), "Farmacoquímica 2°2°", "22FA", new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4172), "3d5e230d-eacb-4003-b308-9b59d544d6b0" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CareerId", "Created_at", "Description", "Name", "Updated_at", "Visible_id" },
                values: new object[] { 9, 1, new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4174), "Bases de datos 3°1°", "31BD", new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4175), "0a8546f1-7985-43a9-bfce-a59957751e66" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CareerId", "Created_at", "Description", "Name", "Updated_at", "Visible_id" },
                values: new object[] { 10, 1, new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4178), "Bases de datos 3°2°", "32BD", new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4179), "d7be292f-6cc2-44e9-8db0-d86dd23c417c" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CareerId", "Created_at", "Description", "Name", "Updated_at", "Visible_id" },
                values: new object[] { 11, 1, new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4181), "Programación 2°1°", "21PR", new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4181), "614466e2-b5ba-45c4-971c-0392cd3fdee2" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CareerId", "Created_at", "Description", "Name", "Updated_at", "Visible_id" },
                values: new object[] { 12, 1, new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4183), "Programación 2°2°", "22PR", new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4183), "47654e25-1321-45fe-9534-6799a4ceebfe" });

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
