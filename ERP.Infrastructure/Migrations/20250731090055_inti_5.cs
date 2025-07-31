using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class inti_5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeSalary");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.EnsureSchema(
                name: "api");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Employee",
                newSchema: "api");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "Company",
                newSchema: "api");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                schema: "api",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "api",
                table: "Company",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                schema: "api",
                table: "Employee",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Company",
                schema: "api",
                table: "Company",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                schema: "api",
                table: "Employee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Company",
                schema: "api",
                table: "Company");

            migrationBuilder.DropColumn(
                name: "FirstName",
                schema: "api",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "api",
                table: "Company");

            migrationBuilder.RenameTable(
                name: "Employee",
                schema: "api",
                newName: "Employees");

            migrationBuilder.RenameTable(
                name: "Company",
                schema: "api",
                newName: "Companies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "EmployeeSalary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    RowId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSalary", x => x.Id);
                });
        }
    }
}
