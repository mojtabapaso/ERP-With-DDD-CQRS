using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class C : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSalary_Employee_EmployeeId1",
                schema: "api",
                table: "EmployeeSalary");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeSalary_EmployeeId1",
                schema: "api",
                table: "EmployeeSalary");

            migrationBuilder.DropColumn(
                name: "EmployeeId1",
                schema: "api",
                table: "EmployeeSalary");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                schema: "api",
                table: "Company",
                type: "NVARCHAR(500)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                schema: "api",
                table: "Company",
                type: "NVARCHAR(250)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TaxCode",
                schema: "api",
                table: "Company",
                type: "NVARCHAR(100)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                schema: "api",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                schema: "api",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "TaxCode",
                schema: "api",
                table: "Company");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId1",
                schema: "api",
                table: "EmployeeSalary",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSalary_EmployeeId1",
                schema: "api",
                table: "EmployeeSalary",
                column: "EmployeeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSalary_Employee_EmployeeId1",
                schema: "api",
                table: "EmployeeSalary",
                column: "EmployeeId1",
                principalSchema: "api",
                principalTable: "Employee",
                principalColumn: "Id");
        }
    }
}
