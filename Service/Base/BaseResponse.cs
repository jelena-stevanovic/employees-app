using System.Text.Json.Serialization;

namespace EmployeesApp.Service.Base;

public abstract class BaseResponse
{
    [JsonIgnore]
    public bool Success { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ErrorCode { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Error { get; set; }
}