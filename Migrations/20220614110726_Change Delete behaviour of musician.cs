using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kol2.Migrations
{
    public partial class ChangeDeletebehaviourofmusician : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musician_Track_Musician_IdMusician",
                table: "Musician_Track");

            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "IdAlbum",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2022, 6, 14, 13, 7, 25, 564, DateTimeKind.Local).AddTicks(710));

            migrationBuilder.AddForeignKey(
                name: "FK_Musician_Track_Musician_IdMusician",
                table: "Musician_Track",
                column: "IdMusician",
                principalTable: "Musician",
                principalColumn: "IdMusician",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Musician_Track_Musician_IdMusician",
                table: "Musician_Track");

            migrationBuilder.UpdateData(
                table: "Album",
                keyColumn: "IdAlbum",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2022, 6, 14, 12, 36, 23, 312, DateTimeKind.Local).AddTicks(1830));

            migrationBuilder.AddForeignKey(
                name: "FK_Musician_Track_Musician_IdMusician",
                table: "Musician_Track",
                column: "IdMusician",
                principalTable: "Musician",
                principalColumn: "IdMusician",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
