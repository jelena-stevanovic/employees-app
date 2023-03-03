namespace EmployeesApp.Data.Models
{
    public class EmployeeDeduction
    {
        public int Id { get; set; }
        public DeductionType DeductionType { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}