using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Skillz.Data.Migrations
{
    public partial class skillgroupprofile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProfileId",
                table: "SkillGroups",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SkillGroups_ProfileId",
                table: "SkillGroups",
                column: "ProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_SkillGroups_Profiles_ProfileId",
                table: "SkillGroups",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SkillGroups_Profiles_ProfileId",
                table: "SkillGroups");

            migrationBuilder.DropIndex(
                name: "IX_SkillGroups_ProfileId",
                table: "SkillGroups");

            migrationBuilder.DropColumn(
                name: "ProfileId",
                table: "SkillGroups");
        }
    }
}
