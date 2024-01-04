using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ModifyLessonEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "lessons");

            migrationBuilder.AlterColumn<string>(
                name: "Department",
                table: "lessons",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "Branch",
                table: "lessons",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Extra",
                table: "lessons",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Teacher",
                table: "lessons",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TimeEnd",
                table: "lessons",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TimeStart",
                table: "lessons",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Where",
                table: "lessons",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Branch",
                table: "lessons");

            migrationBuilder.DropColumn(
                name: "Extra",
                table: "lessons");

            migrationBuilder.DropColumn(
                name: "Teacher",
                table: "lessons");

            migrationBuilder.DropColumn(
                name: "TimeEnd",
                table: "lessons");

            migrationBuilder.DropColumn(
                name: "TimeStart",
                table: "lessons");

            migrationBuilder.DropColumn(
                name: "Where",
                table: "lessons");

            migrationBuilder.AlterColumn<int>(
                name: "Department",
                table: "lessons",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<TimeOnly>(
                name: "Time",
                table: "lessons",
                type: "time without time zone",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));
        }
    }
}
