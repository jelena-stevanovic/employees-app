using EmployeesApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeesApp.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Employee>()
            .HasMany(g => g.SalaryHistories)
            .WithOne(item => item.Employee);
        
        builder.Entity<Position>()
            .HasMany(g => g.SalaryHistories)
            .WithOne(item => item.Position)
            .OnDelete(DeleteBehavior.ClientNoAction);
    }

    public DbSet<Employee> Employees { get; set; }
    
    public DbSet<Position> Positions { get; set; }
    
    public DbSet<SalaryHistory> SalaryHistories { get; set; }

    public DbSet<EmployeeBonus> Bonuses { get; set; }

    public DbSet<EmployeeDeduction> Deductions { get; set; }
}