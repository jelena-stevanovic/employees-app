using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeesApp.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsManager = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VacationDays = table.Column<int>(type: "int", nullable: false),
                    ManagerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Employees_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employees_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bonuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BonusType = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bonuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bonuses_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Deductions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeductionType = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deductions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deductions_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalaryHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalaryHistories_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalaryHistories_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "IsManager", "Title" },
                values: new object[,]
                {
                    { 1, false, "Back-end developer" },
                    { 2, false, "Front-end developer" },
                    { 3, false, "Full-stack developer" },
                    { 4, false, "UI designer" },
                    { 5, true, "Software development manager" },
                    { 6, false, "Software test engineer" },
                    { 7, true, "Lead developer" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "FirstName", "LastName", "ManagerId", "PositionId", "Salary", "VacationDays" },
                values: new object[] { 2, "Harry", "Williams", null, 5, 1141m, 13 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "FirstName", "LastName", "ManagerId", "PositionId", "Salary", "VacationDays" },
                values: new object[] { 4, "Simone", "Harper", null, 7, 1362m, 16 });

            migrationBuilder.InsertData(
                table: "Bonuses",
                columns: new[] { "Id", "BonusType", "EmployeeId" },
                values: new object[,]
                {
                    { 2, 2, 2 },
                    { 4, 2, 4 }
                });

            migrationBuilder.InsertData(
                table: "Deductions",
                columns: new[] { "Id", "DeductionType", "EmployeeId" },
                values: new object[,]
                {
                    { 2, 1, 2 },
                    { 4, 1, 4 }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "FirstName", "LastName", "ManagerId", "PositionId", "Salary", "VacationDays" },
                values: new object[,]
                {
                    { 1, "Shannon", "Smith", 2, 1, 1141m, 10 },
                    { 3, "Charles", "King", 2, 2, 1235m, 20 },
                    { 5, "Emma", "Taylor", 4, 6, 1141m, 13 }
                });

            migrationBuilder.InsertData(
                table: "Bonuses",
                columns: new[] { "Id", "BonusType", "EmployeeId" },
                values: new object[,]
                {
                    { 1, 0, 1 },
                    { 3, 3, 3 },
                    { 5, 1, 5 }
                });

            migrationBuilder.InsertData(
                table: "Deductions",
                columns: new[] { "Id", "DeductionType", "EmployeeId" },
                values: new object[,]
                {
                    { 1, 0, 1 },
                    { 3, 1, 3 },
                    { 5, 2, 5 }
                });

            migrationBuilder.InsertData(
                table: "SalaryHistories",
                columns: new[] { "Id", "Date", "EmployeeId", "PositionId", "Salary" },
                values: new object[,]
                {
                    { 1, new DateTime(2015, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 2350m },
                    { 2, new DateTime(2018, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 2450m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bonuses_EmployeeId",
                table: "Bonuses",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Deductions_EmployeeId",
                table: "Deductions",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ManagerId",
                table: "Employees",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PositionId",
                table: "Employees",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryHistories_EmployeeId",
                table: "SalaryHistories",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryHistories_PositionId",
                table: "SalaryHistories",
                column: "PositionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bonuses");

            migrationBuilder.DropTable(
                name: "Deductions");

            migrationBuilder.DropTable(
                name: "SalaryHistories");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Positions");
        }
    }
}
