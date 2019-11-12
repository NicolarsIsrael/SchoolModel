using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SchoolModel.Data.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_Classroom_ClassroomId",
                table: "Attendance");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_Attendance_AttendanceId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_AttendanceId",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "AttendanceId",
                table: "Student");

            migrationBuilder.AlterColumn<int>(
                name: "ClassroomId",
                table: "Attendance",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AttendanceDate",
                table: "Attendance",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PresetStudentMatricNumber",
                table: "Attendance",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_Classroom_ClassroomId",
                table: "Attendance",
                column: "ClassroomId",
                principalTable: "Classroom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attendance_Classroom_ClassroomId",
                table: "Attendance");

            migrationBuilder.DropColumn(
                name: "AttendanceDate",
                table: "Attendance");

            migrationBuilder.DropColumn(
                name: "PresetStudentMatricNumber",
                table: "Attendance");

            migrationBuilder.AddColumn<int>(
                name: "AttendanceId",
                table: "Student",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClassroomId",
                table: "Attendance",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Student_AttendanceId",
                table: "Student",
                column: "AttendanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendance_Classroom_ClassroomId",
                table: "Attendance",
                column: "ClassroomId",
                principalTable: "Classroom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Attendance_AttendanceId",
                table: "Student",
                column: "AttendanceId",
                principalTable: "Attendance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
