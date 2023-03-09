using EmployeesApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeesApp.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }

    public DbSet<Position> Positions { get; set; }

    public DbSet<SalaryHistory> SalaryHistories { get; set; }

    public DbSet<EmployeeBonus> Bonuses { get; set; }

    public DbSet<EmployeeDeduction> Deductions { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Employee>()
            .HasMany(g => g.SalaryHistories);
        
        builder.Entity<Position>()
            .HasMany(g => g.SalaryHistories)
            .WithOne(item => item.Position)
            .OnDelete(DeleteBehavior.ClientNoAction);

        base.OnModelCreating(builder);
        builder.Entity<Position>().HasData(new Position { Id = 1, Title = "Back-end developer", IsManager = false });
        builder.Entity<Position>().HasData(new Position { Id = 2, Title = "Front-end developer", IsManager = false });
        builder.Entity<Position>().HasData(new Position { Id = 3, Title = "Full-stack developer", IsManager = false });
        builder.Entity<Position>().HasData(new Position { Id = 4, Title = "UI designer", IsManager = false });
        builder.Entity<Position>().HasData(new Position { Id = 5, Title = "Software development manager", IsManager = true });
        builder.Entity<Position>().HasData(new Position { Id = 6, Title = "Software test engineer", IsManager = false });
        builder.Entity<Position>().HasData(new Position { Id = 7, Title = "Lead developer", IsManager = true });

        builder.Entity<Employee>().HasData(new Employee
        {
            Id = 1,
            FirstName = "Shannon",
            LastName = "Smith",
            HireDate = new DateTime(2019, 5, 30),
            PositionId = 1,
            ManagerId = 2,
            Salary = 1141,
            VacationDays = 10
        });

        builder.Entity<Employee>().HasData(new Employee
        {
            Id = 2,
            FirstName = "Harry",
            LastName = "Williams",
            HireDate = new DateTime(2017, 9, 30),
            PositionId = 5,
            ManagerId = null,
            Salary = 2000,
            VacationDays = 13
        });

        builder.Entity<Employee>().HasData(new Employee
        {
            Id = 3,
            FirstName = "Charles",
            LastName = "King",
            HireDate = new DateTime(2018, 9, 1),
            PositionId = 2,
            ManagerId = 2,
            Salary = 1235,
            VacationDays = 20
        });

       builder.Entity<Employee>().HasData(new Employee
        {
            Id = 4,
            FirstName = "Simone",
            LastName = "Harper",
            HireDate = new DateTime(2017, 10, 1),
            PositionId = 7,
            ManagerId = null,
            Salary = 2000,
            VacationDays = 16
        });

       builder.Entity<Employee>().HasData(new Employee
        {
            Id = 5,
            FirstName = "Emma",
            LastName = "Taylor",
            PositionId = 6,
            ManagerId = 4,
            Salary = 1300,
            VacationDays = 13
        });

       builder.Entity<EmployeeBonus>().HasData(new EmployeeBonus
        {
            Id = 1,
            EmployeeId = 1,
            BonusType = BonusType.Annual
        });

        builder.Entity<EmployeeBonus>().HasData(new EmployeeBonus
        {
            Id = 2,
            EmployeeId = 2,
            BonusType = BonusType.Retention
        });

       builder.Entity<EmployeeBonus>().HasData(new EmployeeBonus
        {
            Id = 3,
            EmployeeId = 3,
            BonusType = BonusType.Referral
        });

        builder.Entity<EmployeeBonus>().HasData(new EmployeeBonus
        {
            Id = 4,
            EmployeeId = 4,
            BonusType = BonusType.Retention
        });

        builder.Entity<EmployeeBonus>().HasData(new EmployeeBonus
        {
            Id = 5,
            EmployeeId = 5,
            BonusType = BonusType.Holiday
        });

        builder.Entity<EmployeeDeduction>().HasData(new EmployeeDeduction
        {
            Id = 1,
            EmployeeId = 1,
            DeductionType = DeductionType.Health
        });

        builder.Entity<EmployeeDeduction>().HasData(new EmployeeDeduction
        {
            Id = 2,
            EmployeeId = 2,
            DeductionType = DeductionType.Retirement
        });

       builder.Entity<EmployeeDeduction>().HasData(new EmployeeDeduction
        {
            Id = 3,
            EmployeeId = 3,
            DeductionType = DeductionType.Retirement
        });

        builder.Entity<EmployeeDeduction>().HasData(new EmployeeDeduction
        {
            Id = 4,
            EmployeeId = 4,
            DeductionType = DeductionType.Retirement
        });

        builder.Entity<EmployeeDeduction>().HasData(new EmployeeDeduction
        {
            Id = 5,
            EmployeeId = 5,
            DeductionType = DeductionType.Travel
        });

        builder.Entity<SalaryHistory>().HasData(new SalaryHistory
        {
            Id = 1,
            Salary = 1850,
            EmployeeId = 1,
            PositionId = 1,
            Date = new DateTime(2020, 3, 29)
        });

        builder.Entity<SalaryHistory>().HasData(new SalaryHistory
        {
            Id = 2,
            Salary = 3000,
            EmployeeId = 2,
            PositionId = 5,
            Date = new DateTime(2018, 4, 30)
        });

        builder.Entity<SalaryHistory>().HasData(new SalaryHistory
        {
            Id = 3,
            Salary = 1800,
            EmployeeId = 3,
            PositionId = 2,
            Date = new DateTime(2019, 2, 1)
        });

        builder.Entity<SalaryHistory>().HasData(new SalaryHistory
        {
            Id = 4,
            Salary = 2800,
            EmployeeId = 4,
            PositionId = 7,
            Date = new DateTime(2018, 4, 1)
        });
    }

}