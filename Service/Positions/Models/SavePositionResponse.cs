using EmployeesApp.Data.Models;
using EmployeesApp.Service.Base;

namespace EmployeesApp.Service.Positions.Models;

public class SavePositionResponse : BaseResponse
{
    public Position Position { get; set; }
}