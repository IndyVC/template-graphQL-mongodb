using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Skillz.Data.Migrations
{
    public partial class consultantnotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Consultants_ConsultantId",
                table: "Notes");

            migrationBuilder.AlterColumn<Guid>(
                name: "ConsultantId",
                table: "Notes",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Consultants_ConsultantId",
                table: "Notes",
                column: "ConsultantId",
                principalTable: "Consultants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Consultants_ConsultantId",
                table: "Notes");

            migrationBuilder.AlterColumn<Guid>(
                name: "ConsultantId",
                table: "Notes",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Consultants_ConsultantId",
                table: "Notes",
                column: "ConsultantId",
                principalTable: "Consultants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
