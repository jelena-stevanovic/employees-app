namespace EmployeesApp.Data.Models
{
    public class EmployeeBonus
    {
        public int Id { get; set; }
        public BonusType BonusType { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}