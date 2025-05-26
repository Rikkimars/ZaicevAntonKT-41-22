using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZaicevKT_41_22.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Departments_HeadOfDepartmentId",
                table: "Departments");

            migrationBuilder.AlterColumn<int>(
                name: "HeadOfDepartmentId",
                table: "Departments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_HeadOfDepartmentId",
                table: "Departments",
                column: "HeadOfDepartmentId",
                unique: true,
                filter: "[HeadOfDepartmentId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Departments_HeadOfDepartmentId",
                table: "Departments");

            migrationBuilder.AlterColumn<int>(
                name: "HeadOfDepartmentId",
                table: "Departments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_HeadOfDepartmentId",
                table: "Departments",
                column: "HeadOfDepartmentId",
                unique: true);
        }
    }
}
