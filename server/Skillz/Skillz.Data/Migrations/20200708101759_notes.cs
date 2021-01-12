using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Skillz.Data.Migrations
{
    public partial class notes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Birthdate",
                table: "Consultants",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FunctionLevel",
                table: "Consultants",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FunctionName",
                table: "Consultants",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ConsultantId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notes_Consultants_ConsultantId",
                        column: x => x.ConsultantId,
                        principalTable: "Consultants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notes_ConsultantId",
                table: "Notes",
                column: "ConsultantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropColumn(
                name: "Birthdate",
                table: "Consultants");

            migrationBuilder.DropColumn(
                name: "FunctionLevel",
                table: "Consultants");

            migrationBuilder.DropColumn(
                name: "FunctionName",
                table: "Consultants");
        }
    }
}
