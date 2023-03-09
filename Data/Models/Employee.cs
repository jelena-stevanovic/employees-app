using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeesApp.Data.Models;

public class Employee
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
        
    public string FirstName { get; set; }
        
    public string LastName { get; set; }

    public int PositionId { get; set; }

    public Position Position { get; set; }

    public DateTime HireDate { get; set; }

    public decimal Salary { get; set; }
    
    public int VacationDays { get; set; }

    public int? ManagerId   { get; set; }

    public Employee Manager { get; set; }

    public IEnumerable<SalaryHistory> SalaryHistories { get; set; } = new List<SalaryHistory>();

    public IEnumerable<EmployeeBonus> Bonuses { get; set; } 

    public IEnumerable<EmployeeDeduction> Deductions { get; set; }
}