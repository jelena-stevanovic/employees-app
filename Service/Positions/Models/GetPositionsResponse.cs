using EmployeesApp.Data.Models;
using EmployeesApp.Service.Base;

namespace EmployeesApp.Service.Positions.Models;

public class GetPositionsResponse : BaseResponse
{
    public List<Position> Positions { get; set; }
}