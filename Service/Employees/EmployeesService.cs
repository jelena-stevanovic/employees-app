using EmployeesApp.Data;
using EmployeesApp.Data.Models;
using EmployeesApp.Service.Employees.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeesApp.Service.Employees;

public class EmployeesService : IEmployeesService
{
    private readonly ApplicationDbContext dbContext;

    public EmployeesService(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<GetEmployeesResponse> GetEmployees()
    {
        var empolyees = await dbContext.Employees
            .Include(i => i.SalaryHistories)
            .ToListAsync();

        return new GetEmployeesResponse { Success = true, Employees = empolyees };
    }

    public async Task<SaveEmployeeResponse> SaveEmployee(SaveEmployeeRequest employee)
    {
        var entry = employee.Id == 0
            ? new Employee()
            : dbContext.Employees.FirstOrDefault(i => i.Id == employee.Id);

        entry.Id = employee.Id;
        entry.Salary = employee.Salary;
        entry.FirstName = employee.FirstName;
        entry.LastName = employee.LastName;
        entry.PositionId = employee.PositionId;

        entry = employee.Id == 0 ? (await dbContext.Employees.AddAsync(entry)).Entity : entry;

        if (employee.Salary != entry.Salary)
        {
            await UpdateSalaryHistory(entry);
        }

        var saveResponse = await dbContext.SaveChangesAsync();

        return saveResponse >= 0
            ? new SaveEmployeeResponse { Success = true, Employee = entry }
            : new SaveEmployeeResponse { Success = false, Error = "Unable to save employee", ErrorCode = "T05" };
    }

    public async Task<DeleteEmployeeResponse> DeleteEmployee(int employeeId)
    {
        var employee = await dbContext.Employees.FindAsync(employeeId);

        if (employee == null)
        {
            return new DeleteEmployeeResponse { Success = false, Error = "Position not found", ErrorCode = "I01" };
        }

        dbContext.Employees.Remove(employee);

        var saveResponse = await dbContext.SaveChangesAsync();

        return saveResponse >= 0
            ? new DeleteEmployeeResponse { Success = true, EmployeeId = employee.Id }
            : new DeleteEmployeeResponse { Success = false, Error = "Unable to delete employee", ErrorCode = "I03" };
    }

    private Task<int> UpdateSalaryHistory(Employee employee)
    {
        dbContext.SalaryHistories.Add(new SalaryHistory()
        {
            PositionId = employee.PositionId,
            EmployeeId = employee.Id,
            Salary = employee.Salary,
            Date = new DateTime()
        });
        return dbContext.SaveChangesAsync();
    }
}