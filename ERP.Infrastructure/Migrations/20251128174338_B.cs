using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class B : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Company_CompanyId1",
                schema: "api",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_CompanyId1",
                schema: "api",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "CompanyId1",
                schema: "api",
                table: "Employee");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_CompanyId",
                schema: "api",
                table: "Employee",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Company_CompanyId",
                schema: "api",
                table: "Employee",
                column: "CompanyId",
                principalSchema: "api",
                principalTable: "Company",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Company_CompanyId",
                schema: "api",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_CompanyId",
                schema: "api",
                table: "Employee");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId1",
                schema: "api",
                table: "Employee",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_CompanyId1",
                schema: "api",
                table: "Employee",
                column: "CompanyId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Company_CompanyId1",
                schema: "api",
                table: "Employee",
                column: "CompanyId1",
                principalSchema: "api",
                principalTable: "Company",
                principalColumn: "Id");
        }
    }
}
