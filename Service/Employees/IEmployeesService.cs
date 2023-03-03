using EmployeesApp.Service.Employees.Models;

namespace EmployeesApp.Service.Employees;

public interface IEmployeesService
{
    Task<GetEmployeesResponse> GetEmployees();

    Task<SaveEmployeeResponse> SaveEmployee(SaveEmployeeRequest employee);

    Task<DeleteEmployeeResponse> DeleteEmployee(int employeeId);
}