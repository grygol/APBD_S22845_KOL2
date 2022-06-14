using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kol2.Migrations
{
    public partial class Addedsecondmusician : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "IdAlbum",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2022, 6, 14, 13, 29, 57, 274, DateTimeKind.Local).AddTicks(1330));

            migrationBuilder.InsertData(
                table: "Musician",
                columns: new[] { "IdMusician", "FirstName", "LastName", "Nickname" },
                values: new object[] { 2, "Muzyk", "B", "Drugi" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Musician",
                keyColumn: "IdMusician",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "IdAlbum",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2022, 6, 14, 13, 7, 25, 564, DateTimeKind.Local).AddTicks(710));
        }
    }
}
