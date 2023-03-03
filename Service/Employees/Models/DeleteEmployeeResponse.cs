using System.Text.Json.Serialization;
using EmployeesApp.Service.Base;

namespace EmployeesApp.Service.Employees.Models;

public class DeleteEmployeeResponse : BaseResponse
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int EmployeeId { get; set; }
}