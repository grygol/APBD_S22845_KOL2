using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kol2.Migrations
{
    public partial class addednullablemusicalbum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IdMusicAlbum",
                table: "Track",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "IdAlbum",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2022, 6, 14, 13, 45, 41, 924, DateTimeKind.Local).AddTicks(8720));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IdMusicAlbum",
                table: "Track",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "IdAlbum",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2022, 6, 14, 13, 29, 57, 274, DateTimeKind.Local).AddTicks(1330));
        }
    }
}
