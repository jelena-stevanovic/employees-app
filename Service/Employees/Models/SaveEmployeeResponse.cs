using EmployeesApp.Data.Models;
using EmployeesApp.Service.Base;

namespace EmployeesApp.Service.Employees.Models;

public class SaveEmployeeResponse : BaseResponse
{
    public Employee Employee { get; set; }
}