using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clay.AccessManagment.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doors",
                columns: table => new
                {
                    DoorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdentityName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doors", x => x.DoorId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    FamilyName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    Password = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true),
                    HasReportingAccess = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "DoorEmployee",
                columns: table => new
                {
                    DoorsDoorId = table.Column<int>(type: "int", nullable: false),
                    EmployeesEmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoorEmployee", x => new { x.DoorsDoorId, x.EmployeesEmployeeId });
                    table.ForeignKey(
                        name: "FK_DoorEmployee_Doors_DoorsDoorId",
                        column: x => x.DoorsDoorId,
                        principalTable: "Doors",
                        principalColumn: "DoorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoorEmployee_Employees_EmployeesEmployeeId",
                        column: x => x.EmployeesEmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeAccessRecords",
                columns: table => new
                {
                    EmployeeAccessRecordId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", maxLength: 30, nullable: false),
                    DoorId = table.Column<int>(type: "int", maxLength: 30, nullable: false),
                    AccessStatus = table.Column<bool>(type: "bit", nullable: false),
                    AccessTool = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeAccessRecords", x => x.EmployeeAccessRecordId);
                    table.ForeignKey(
                        name: "FK_EmployeeAccessRecords_Doors_DoorId",
                        column: x => x.DoorId,
                        principalTable: "Doors",
                        principalColumn: "DoorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeAccessRecords_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoorEmployee_EmployeesEmployeeId",
                table: "DoorEmployee",
                column: "EmployeesEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAccessRecords_DoorId",
                table: "EmployeeAccessRecords",
                column: "DoorId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAccessRecords_EmployeeId",
                table: "EmployeeAccessRecords",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoorEmployee");

            migrationBuilder.DropTable(
                name: "EmployeeAccessRecords");

            migrationBuilder.DropTable(
                name: "Doors");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
