using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CursoSwitcher.Migrations
{
    public partial class _20220722_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Campus",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at", "Visible_id" },
                values: new object[] { new DateTime(2022, 7, 12, 21, 22, 29, 401, DateTimeKind.Local).AddTicks(5523), new DateTime(2022, 7, 12, 21, 22, 29, 401, DateTimeKind.Local).AddTicks(5531), "85f5e11d-1471-4570-83be-29885197f02b" });

            migrationBuilder.UpdateData(
                table: "Campus",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at", "Visible_id" },
                values: new object[] { new DateTime(2022, 7, 12, 21, 22, 29, 401, DateTimeKind.Local).AddTicks(5535), new DateTime(2022, 7, 12, 21, 22, 29, 401, DateTimeKind.Local).AddTicks(5535), "accc1307-d939-4b8c-b27c-f5626bb50889" });

            migrationBuilder.UpdateData(
                table: "Careers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at", "Visible_id" },
                values: new object[] { new DateTime(2022, 7, 12, 21, 22, 29, 401, DateTimeKind.Local).AddTicks(5657), new DateTime(2022, 7, 12, 21, 22, 29, 401, DateTimeKind.Local).AddTicks(5658), "f411d13d-1c5f-4cfe-9ee3-f298d9022b7b" });

            migrationBuilder.UpdateData(
                table: "Careers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at", "Visible_id" },
                values: new object[] { new DateTime(2022, 7, 12, 21, 22, 29, 401, DateTimeKind.Local).AddTicks(5661), new DateTime(2022, 7, 12, 21, 22, 29, 401, DateTimeKind.Local).AddTicks(5661), "c5c41f46-b1cc-4974-8ab0-a6c1d2625f67" });

            migrationBuilder.UpdateData(
                table: "Careers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at", "Visible_id" },
                values: new object[] { new DateTime(2022, 7, 12, 21, 22, 29, 401, DateTimeKind.Local).AddTicks(5664), new DateTime(2022, 7, 12, 21, 22, 29, 401, DateTimeKind.Local).AddTicks(5665), "4ac131d9-1f27-46f1-9538-aec04225b9e1" });

            migrationBuilder.UpdateData(
                table: "Careers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at", "Visible_id" },
                values: new object[] { new DateTime(2022, 7, 12, 21, 22, 29, 401, DateTimeKind.Local).AddTicks(5667), new DateTime(2022, 7, 12, 21, 22, 29, 401, DateTimeKind.Local).AddTicks(5667), "020c49ed-9a10-41ca-a662-b8ed8e146489" });

            migrationBuilder.UpdateData(
                table: "Careers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created_at", "Updated_at", "Visible_id" },
                values: new object[] { new DateTime(2022, 7, 12, 21, 22, 29, 401, DateTimeKind.Local).AddTicks(5670), new DateTime(2022, 7, 12, 21, 22, 29, 401, DateTimeKind.Local).AddTicks(5670), "6e503d2e-38d6-49da-9f91-c524e6048154" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created_at", "Description", "Name", "Updated_at", "Visible_id" },
                values: new object[] { new DateTime(2022, 7, 12, 21, 22, 29, 401, DateTimeKind.Local).AddTicks(5688), "Analista de Sistemas 1er año 1°A", "11A", new DateTime(2022, 7, 12, 21, 22, 29, 401, DateTimeKind.Local).AddTicks(5689), "8c968589-19f5-46b2-ba0f-fefb84ea89d4" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created_at", "Description", "Name", "Updated_at", "Visible_id" },
                values: new object[] { new DateTime(2022, 7, 12, 21, 22, 29, 401, DateTimeKind.Local).AddTicks(5695), "Analista de Sistemas 1er año 1°B", "11B", new DateTime(2022, 7, 12, 21, 22, 29, 401, DateTimeKind.Local).AddTicks(5695), "b25259a9-9a6a-48f2-ad86-18317d0b56c6" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created_at", "Description", "Name", "Updated_at", "Visible_id" },
                values: new object[] { new DateTime(2022, 7, 12, 21, 22, 29, 401, DateTimeKind.Local).AddTicks(5698), "Analista de Sistemas 1er año 1°C", "11C", new DateTime(2022, 7, 12, 21, 22, 29, 401, DateTimeKind.Local).AddTicks(5698), "b3183521-5829-4fdb-8224-c063d5e5359b" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created_at", "Description", "Name", "Updated_at", "Visible_id" },
                values: new object[] { new DateTime(2022, 7, 12, 21, 22, 29, 401, DateTimeKind.Local).AddTicks(5701), "Analista de Sistemas 1er año 1°D", "11D", new DateTime(2022, 7, 12, 21, 22, 29, 401, DateTimeKind.Local).AddTicks(5701), "3236f258-9f98-42ff-87df-318dacd8aebd" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created_at", "Description", "Name", "Updated_at", "Visible_id" },
                values: new object[] { new DateTime(2022, 7, 12, 21, 22, 29, 401, DateTimeKind.Local).AddTicks(5704), "Biotecnología Segundo año 1°A", "21A", new DateTime(2022, 7, 12, 21, 22, 29, 401, DateTimeKind.Local).AddTicks(5704), "7af21e2e-df76-4d02-ae08-5daa71ee2b87" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Created_at", "Description", "Name", "Updated_at", "Visible_id" },
                values: new object[] { new DateTime(2022, 7, 12, 21, 22, 29, 401, DateTimeKind.Local).AddTicks(5707), "Biotecnología Segundo año 1°B", "21B", new DateTime(2022, 7, 12, 21, 22, 29, 401, DateTimeKind.Local).AddTicks(5707), "aa86bccd-b6b4-4dcc-b2ee-1570894ec793" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Created_at", "Description", "Name", "Updated_at", "Visible_id" },
                values: new object[] { new DateTime(2022, 7, 12, 21, 22, 29, 401, DateTimeKind.Local).AddTicks(5709), "Biotecnología Segundo año 1°C", "21C", new DateTime(2022, 7, 12, 21, 22, 29, 401, DateTimeKind.Local).AddTicks(5709), "133e7c3f-1f7d-4c79-ad79-fb09e88e433e" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Created_at", "Description", "Name", "Updated_at", "Visible_id" },
                values: new object[] { new DateTime(2022, 7, 12, 21, 22, 29, 401, DateTimeKind.Local).AddTicks(5712), "Biotecnología Segundo año 1°D", "21D", new DateTime(2022, 7, 12, 21, 22, 29, 401, DateTimeKind.Local).AddTicks(5712), "42712507-485b-4769-a1c0-147f342428f3" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CareerId", "Created_at", "Description", "Name", "Updated_at", "Visible_id" },
                values: new object[] { 3, new DateTime(2022, 7, 12, 21, 22, 29, 401, DateTimeKind.Local).AddTicks(5714), "Sonido y Producción Musical Segundo año 2°A", "22A", new DateTime(2022, 7, 12, 21, 22, 29, 401, DateTimeKind.Local).AddTicks(5714), "6b8dee62-4a70-4e44-9aae-a1969c824e72" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CareerId", "Created_at", "Description", "Name", "Updated_at", "Visible_id" },
                values: new object[] { 3, new DateTime(2022, 7, 12, 21, 22, 29, 401, DateTimeKind.Local).AddTicks(5719), "Sonido y Producción Musical Segundo año 2°B", "22B", new DateTime(2022, 7, 12, 21, 22, 29, 401, DateTimeKind.Local).AddTicks(5719), "4c307488-eedc-4b4d-8ab5-548f85f7276b" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CareerId", "Created_at", "Description", "Name", "Updated_at", "Visible_id" },
                values: new object[] { 3, new DateTime(2022, 7, 12, 21, 22, 29, 401, DateTimeKind.Local).AddTicks(5722), "Sonido y Producción Musical Segundo año 2°C", "22C", new DateTime(2022, 7, 12, 21, 22, 29, 401, DateTimeKind.Local).AddTicks(5722), "9db6a4af-ccc7-457e-ab12-06aff66fd3a3" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CareerId", "Created_at", "Description", "Updated_at", "Visible_id" },
                values: new object[] { 3, new DateTime(2022, 7, 12, 21, 22, 29, 401, DateTimeKind.Local).AddTicks(5725), "Sonido y Producción Musical Segundo año 2°D", new DateTime(2022, 7, 12, 21, 22, 29, 401, DateTimeKind.Local).AddTicks(5725), "96cff289-c4df-4508-bb68-b64c3fd4b4b1" });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at", "Visible_id" },
                values: new object[] { new DateTime(2022, 7, 12, 21, 22, 29, 401, DateTimeKind.Local).AddTicks(5741), new DateTime(2022, 7, 12, 21, 22, 29, 401, DateTimeKind.Local).AddTicks(5741), "e81e6e71-48cf-49de-bad0-ce2ddaa67e9d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Campus",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at", "Visible_id" },
                values: new object[] { new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4019), new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4026), "c912a0d6-6602-4efe-8482-e175fa3addfb" });

            migrationBuilder.UpdateData(
                table: "Campus",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at", "Visible_id" },
                values: new object[] { new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4030), new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4030), "3c48b517-a750-4d4f-b23f-311f31ea9836" });

            migrationBuilder.UpdateData(
                table: "Careers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at", "Visible_id" },
                values: new object[] { new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4126), new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4126), "bcbddcc7-d1d4-4623-bd14-02140c8d850a" });

            migrationBuilder.UpdateData(
                table: "Careers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created_at", "Updated_at", "Visible_id" },
                values: new object[] { new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4129), new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4129), "1e60f890-987a-4913-a0ad-ade79856f233" });

            migrationBuilder.UpdateData(
                table: "Careers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created_at", "Updated_at", "Visible_id" },
                values: new object[] { new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4131), new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4131), "ab22a5e1-4963-402a-aa1c-44651c940b7a" });

            migrationBuilder.UpdateData(
                table: "Careers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created_at", "Updated_at", "Visible_id" },
                values: new object[] { new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4134), new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4134), "6548f49d-270a-4eef-814b-3f9bd45b6f72" });

            migrationBuilder.UpdateData(
                table: "Careers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created_at", "Updated_at", "Visible_id" },
                values: new object[] { new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4136), new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4136), "dc25a104-0ee4-4e1f-b8df-1b7e1daad926" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created_at", "Description", "Name", "Updated_at", "Visible_id" },
                values: new object[] { new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4152), "Organización Empresarial 1°1°", "11OEM", new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4153), "72f39a12-a3d1-4582-8c76-9b583ebd8a99" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Created_at", "Description", "Name", "Updated_at", "Visible_id" },
                values: new object[] { new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4158), "Organización Empresarial 1°2°", "12OEM", new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4158), "2484bf46-e683-4361-8ae0-72e054d63884" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Created_at", "Description", "Name", "Updated_at", "Visible_id" },
                values: new object[] { new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4161), "Taller de Programación 1°1°", "11TP", new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4161), "15e9cbde-c156-424c-9dba-6623c7e8e1b1" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Created_at", "Description", "Name", "Updated_at", "Visible_id" },
                values: new object[] { new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4163), "Taller de Programación 1°2°", "12TP", new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4163), "e93d8635-6421-4767-b0dd-f91eba6ad1f1" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Created_at", "Description", "Name", "Updated_at", "Visible_id" },
                values: new object[] { new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4166), "Biotecnología 3°1°", "31BT", new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4166), "0dea8410-8b8b-4a22-9f94-d58f148599f7" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Created_at", "Description", "Name", "Updated_at", "Visible_id" },
                values: new object[] { new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4168), "Biotecnología 3°2°", "32BT", new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4168), "5dab8598-3e1e-440a-a97d-edf19248e831" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Created_at", "Description", "Name", "Updated_at", "Visible_id" },
                values: new object[] { new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4170), "Farmacoquímica 2°1°", "21FA", new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4170), "7993a22c-15f9-42d9-94c0-69e1fbd42498" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Created_at", "Description", "Name", "Updated_at", "Visible_id" },
                values: new object[] { new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4172), "Farmacoquímica 2°2°", "22FA", new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4172), "3d5e230d-eacb-4003-b308-9b59d544d6b0" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CareerId", "Created_at", "Description", "Name", "Updated_at", "Visible_id" },
                values: new object[] { 1, new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4174), "Bases de datos 3°1°", "31BD", new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4175), "0a8546f1-7985-43a9-bfce-a59957751e66" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CareerId", "Created_at", "Description", "Name", "Updated_at", "Visible_id" },
                values: new object[] { 1, new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4178), "Bases de datos 3°2°", "32BD", new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4179), "d7be292f-6cc2-44e9-8db0-d86dd23c417c" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CareerId", "Created_at", "Description", "Name", "Updated_at", "Visible_id" },
                values: new object[] { 1, new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4181), "Programación 2°1°", "21PR", new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4181), "614466e2-b5ba-45c4-971c-0392cd3fdee2" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CareerId", "Created_at", "Description", "Updated_at", "Visible_id" },
                values: new object[] { 1, new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4183), "Programación 2°2°", new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4183), "47654e25-1321-45fe-9534-6799a4ceebfe" });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Created_at", "Updated_at", "Visible_id" },
                values: new object[] { new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4202), new DateTime(2022, 6, 22, 19, 1, 24, 913, DateTimeKind.Local).AddTicks(4203), "9965a503-2d9c-45e1-97fb-2fd137346c1b" });
        }
    }
}
