using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeesApp.Data.Migrations
{
    public partial class AddNewData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "HireDate",
                value: new DateTime(2019, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "HireDate", "Salary" },
                values: new object[] { new DateTime(2017, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2000m });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                column: "HireDate",
                value: new DateTime(2018, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "HireDate", "Salary" },
                values: new object[] { new DateTime(2017, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2000m });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5,
                column: "Salary",
                value: 1300m);

            migrationBuilder.UpdateData(
                table: "SalaryHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "Salary" },
                values: new object[] { new DateTime(2020, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 1850m });

            migrationBuilder.UpdateData(
                table: "SalaryHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EmployeeId", "PositionId", "Salary" },
                values: new object[] { 2, 5, 3000m });

            migrationBuilder.InsertData(
                table: "SalaryHistories",
                columns: new[] { "Id", "Date", "EmployeeId", "PositionId", "Salary" },
                values: new object[,]
                {
                    { 3, new DateTime(2019, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 1800m },
                    { 4, new DateTime(2018, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 7, 2800m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SalaryHistories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SalaryHistories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "HireDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "HireDate", "Salary" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1141m });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                column: "HireDate",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "HireDate", "Salary" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1362m });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5,
                column: "Salary",
                value: 1141m);

            migrationBuilder.UpdateData(
                table: "SalaryHistories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "Salary" },
                values: new object[] { new DateTime(2015, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 2350m });

            migrationBuilder.UpdateData(
                table: "SalaryHistories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EmployeeId", "PositionId", "Salary" },
                values: new object[] { 3, 2, 2450m });
        }
    }
}
