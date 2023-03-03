using System.Text.Json.Serialization;
using EmployeesApp.Service.Base;

namespace EmployeesApp.Service.Positions.Models;

public class DeletePositionResponse : BaseResponse
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int PositionId { get; set; }
}