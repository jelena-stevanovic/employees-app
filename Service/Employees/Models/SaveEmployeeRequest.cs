namespace EmployeesApp.Service.Employees.Models;

public class SaveEmployeeRequest
{
    public int Id { get; set; }
        
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
        
    public decimal Salary  { get; set; }

    public int VacationDays { get; set; }
        
    public int PositionId { get; set; }
    
    public int ManagerId  { get; set; }
}