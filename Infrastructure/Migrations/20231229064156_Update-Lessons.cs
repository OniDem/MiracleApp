using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateLessons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Lesson_time",
                table: "lessons",
                newName: "Time");

            migrationBuilder.RenameColumn(
                name: "Lesson_teacher_id",
                table: "lessons",
                newName: "TeacherId");

            migrationBuilder.RenameColumn(
                name: "Lesson_name",
                table: "lessons",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Lesson_date",
                table: "lessons",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "Lesson_course",
                table: "lessons",
                newName: "CourseNumber");

            migrationBuilder.RenameColumn(
                name: "LessonDoW",
                table: "lessons",
                newName: "StudentCount");

            migrationBuilder.AddColumn<int>(
                name: "DayOfWeek",
                table: "lessons",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Department",
                table: "lessons",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Online",
                table: "lessons",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayOfWeek",
                table: "lessons");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "lessons");

            migrationBuilder.DropColumn(
                name: "Online",
                table: "lessons");

            migrationBuilder.RenameColumn(
                name: "Time",
                table: "lessons",
                newName: "Lesson_time");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "lessons",
                newName: "Lesson_teacher_id");

            migrationBuilder.RenameColumn(
                name: "StudentCount",
                table: "lessons",
                newName: "LessonDoW");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "lessons",
                newName: "Lesson_name");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "lessons",
                newName: "Lesson_date");

            migrationBuilder.RenameColumn(
                name: "CourseNumber",
                table: "lessons",
                newName: "Lesson_course");
        }
    }
}
