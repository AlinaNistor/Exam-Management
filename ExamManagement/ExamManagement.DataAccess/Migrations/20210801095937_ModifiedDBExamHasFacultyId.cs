using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class ModifiedDBExamHasFacultyId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Faculty",
                table: "Exams");

            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "Exams",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "FacultyId",
                table: "Exams",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Exams_FacultyId",
                table: "Exams",
                column: "FacultyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Faculty_FacultyId",
                table: "Exams",
                column: "FacultyId",
                principalTable: "Faculty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Faculty_FacultyId",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Exams_FacultyId",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "Details",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "FacultyId",
                table: "Exams");

            migrationBuilder.AddColumn<string>(
                name: "Faculty",
                table: "Exams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
