using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IndianaJonesBlog.Migrations
{
    public partial class ExperienceModelUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Experiences",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Experiences",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Experiences");
        }
    }
}
