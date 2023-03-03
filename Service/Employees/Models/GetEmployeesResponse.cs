using EmployeesApp.Data.Models;
using EmployeesApp.Service.Base;

namespace EmployeesApp.Service.Employees.Models;

public class GetEmployeesResponse : BaseResponse
{
    public List<Employee> Employees { get; set; }
}