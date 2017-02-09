using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IndianaJonesBlog.Migrations
{
    public partial class TryToFixPersonIdInExperience : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_Persons_PersonId",
                table: "Experiences");

            migrationBuilder.DropIndex(
                name: "IX_Experiences_PersonId",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "Experiences");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "Experiences",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_PersonId",
                table: "Experiences",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_Persons_PersonId",
                table: "Experiences",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
