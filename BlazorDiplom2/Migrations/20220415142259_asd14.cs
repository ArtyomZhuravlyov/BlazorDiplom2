using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorDiplom2.Migrations
{
    public partial class asd14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Koans",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_NameAndTeacher",
                table: "Koans",
                columns: new[] { "Name", "TeacherId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_NameAndTeacher",
                table: "Koans");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Koans",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
