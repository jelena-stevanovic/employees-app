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
            .Include(e => e.Position)
            .Include(e => e.Manager)
            .Include(e => e.Bonuses)
            .Include(e => e.Deductions)
            .Include(e => e.SalaryHistories)
            .ToListAsync();

        return new GetEmployeesResponse { Success = true, Employees = empolyees };
    }

    public async Task<SaveEmployeeResponse> SaveEmployee(SaveEmployeeRequest employee)
    {
        var entry = employee.Id == 0
            ? new Employee()
            : dbContext.Employees.FirstOrDefault(i => i.Id == employee.Id);

        var oldSalary = entry.Salary;

        entry.Id = employee.Id;
        entry.FirstName = employee.FirstName;
        entry.LastName = employee.LastName;
        entry.HireDate = employee.Id == 0 ? DateTime.Now : entry.HireDate;
        entry.Salary = employee.Salary;
        entry.PositionId = employee.PositionId;
        entry.ManagerId = employee.ManagerId;
        entry.VacationDays = employee.VacationDays;
        

        if (employee.Id == 0)
        {
            await dbContext.Employees.AddAsync(entry); 
        }

        var saveResponse = await dbContext.SaveChangesAsync();

        if (oldSalary != employee.Salary)
        {
            await UpdateSalaryHistory(entry);
        }

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
            Date = DateTime.Now
        });
        return dbContext.SaveChangesAsync();
    }
}