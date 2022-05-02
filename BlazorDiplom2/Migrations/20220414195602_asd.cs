using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorDiplom2.Migrations
{
    public partial class asd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_EducationalInstitutions_EducationalInstitutionId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Koans_TeacherId",
                table: "Koans");

            migrationBuilder.AlterColumn<int>(
                name: "EducationalInstitutionId",
                table: "Groups",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Koans_TeacherId",
                table: "Koans",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_EducationalInstitutions_EducationalInstitutionId",
                table: "Groups",
                column: "EducationalInstitutionId",
                principalTable: "EducationalInstitutions",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_EducationalInstitutions_EducationalInstitutionId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Koans_TeacherId",
                table: "Koans");

            migrationBuilder.AlterColumn<int>(
                name: "EducationalInstitutionId",
                table: "Groups",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Koans_TeacherId",
                table: "Koans",
                column: "TeacherId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_EducationalInstitutions_EducationalInstitutionId",
                table: "Groups",
                column: "EducationalInstitutionId",
                principalTable: "EducationalInstitutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
