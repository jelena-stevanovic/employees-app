using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeesApp.Data.Models;

public class Position
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Title { get; set; }
    
    public ICollection<SalaryHistory> SalaryHistories { get; set; } = new List<SalaryHistory>();
}