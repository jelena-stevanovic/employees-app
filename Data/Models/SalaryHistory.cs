using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeesApp.Data.Models;

public class SalaryHistory
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public decimal Salary { get; set; }

    public int EmployeeId { get; set; }
    
    public int PositionId { get; set; }
    
    public Position Position { get; set; }

    public DateTime Date { get; set; } 
}