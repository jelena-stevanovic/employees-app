// <auto-generated />
using System;
using EmployeesApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmployeesApp.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EmployeesApp.Data.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ManagerId")
                        .HasColumnType("int");

                    b.Property<int>("PositionId")
                        .HasColumnType("int");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("VacationDays")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ManagerId");

                    b.HasIndex("PositionId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Shannon",
                            HireDate = new DateTime(2019, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Smith",
                            ManagerId = 2,
                            PositionId = 1,
                            Salary = 1141m,
                            VacationDays = 10
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Harry",
                            HireDate = new DateTime(2017, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Williams",
                            PositionId = 5,
                            Salary = 2000m,
                            VacationDays = 13
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Charles",
                            HireDate = new DateTime(2018, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "King",
                            ManagerId = 2,
                            PositionId = 2,
                            Salary = 1235m,
                            VacationDays = 20
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "Simone",
                            HireDate = new DateTime(2017, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Harper",
                            PositionId = 7,
                            Salary = 2000m,
                            VacationDays = 16
                        },
                        new
                        {
                            Id = 5,
                            FirstName = "Emma",
                            HireDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastName = "Taylor",
                            ManagerId = 4,
                            PositionId = 6,
                            Salary = 1300m,
                            VacationDays = 13
                        });
                });

            modelBuilder.Entity("EmployeesApp.Data.Models.EmployeeBonus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BonusType")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Bonuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BonusType = 0,
                            EmployeeId = 1
                        },
                        new
                        {
                            Id = 2,
                            BonusType = 2,
                            EmployeeId = 2
                        },
                        new
                        {
                            Id = 3,
                            BonusType = 3,
                            EmployeeId = 3
                        },
                        new
                        {
                            Id = 4,
                            BonusType = 2,
                            EmployeeId = 4
                        },
                        new
                        {
                            Id = 5,
                            BonusType = 1,
                            EmployeeId = 5
                        });
                });

            modelBuilder.Entity("EmployeesApp.Data.Models.EmployeeDeduction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DeductionType")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Deductions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DeductionType = 0,
                            EmployeeId = 1
                        },
                        new
                        {
                            Id = 2,
                            DeductionType = 1,
                            EmployeeId = 2
                        },
                        new
                        {
                            Id = 3,
                            DeductionType = 1,
                            EmployeeId = 3
                        },
                        new
                        {
                            Id = 4,
                            DeductionType = 1,
                            EmployeeId = 4
                        },
                        new
                        {
                            Id = 5,
                            DeductionType = 2,
                            EmployeeId = 5
                        });
                });

            modelBuilder.Entity("EmployeesApp.Data.Models.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("IsManager")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Positions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsManager = false,
                            Title = "Back-end developer"
                        },
                        new
                        {
                            Id = 2,
                            IsManager = false,
                            Title = "Front-end developer"
                        },
                        new
                        {
                            Id = 3,
                            IsManager = false,
                            Title = "Full-stack developer"
                        },
                        new
                        {
                            Id = 4,
                            IsManager = false,
                            Title = "UI designer"
                        },
                        new
                        {
                            Id = 5,
                            IsManager = true,
                            Title = "Software development manager"
                        },
                        new
                        {
                            Id = 6,
                            IsManager = false,
                            Title = "Software test engineer"
                        },
                        new
                        {
                            Id = 7,
                            IsManager = true,
                            Title = "Lead developer"
                        });
                });

            modelBuilder.Entity("EmployeesApp.Data.Models.SalaryHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("PositionId")
                        .HasColumnType("int");

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("PositionId");

                    b.ToTable("SalaryHistories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = new DateTime(2020, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeId = 1,
                            PositionId = 1,
                            Salary = 1850m
                        },
                        new
                        {
                            Id = 2,
                            Date = new DateTime(2018, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeId = 2,
                            PositionId = 5,
                            Salary = 3000m
                        },
                        new
                        {
                            Id = 3,
                            Date = new DateTime(2019, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeId = 3,
                            PositionId = 2,
                            Salary = 1800m
                        },
                        new
                        {
                            Id = 4,
                            Date = new DateTime(2018, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EmployeeId = 4,
                            PositionId = 7,
                            Salary = 2800m
                        });
                });

            modelBuilder.Entity("EmployeesApp.Data.Models.Employee", b =>
                {
                    b.HasOne("EmployeesApp.Data.Models.Employee", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerId");

                    b.HasOne("EmployeesApp.Data.Models.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manager");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("EmployeesApp.Data.Models.EmployeeBonus", b =>
                {
                    b.HasOne("EmployeesApp.Data.Models.Employee", "Employee")
                        .WithMany("Bonuses")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("EmployeesApp.Data.Models.EmployeeDeduction", b =>
                {
                    b.HasOne("EmployeesApp.Data.Models.Employee", "Employee")
                        .WithMany("Deductions")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("EmployeesApp.Data.Models.SalaryHistory", b =>
                {
                    b.HasOne("EmployeesApp.Data.Models.Employee", null)
                        .WithMany("SalaryHistories")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EmployeesApp.Data.Models.Position", "Position")
                        .WithMany("SalaryHistories")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("Position");
                });

            modelBuilder.Entity("EmployeesApp.Data.Models.Employee", b =>
                {
                    b.Navigation("Bonuses");

                    b.Navigation("Deductions");

                    b.Navigation("SalaryHistories");
                });

            modelBuilder.Entity("EmployeesApp.Data.Models.Position", b =>
                {
                    b.Navigation("SalaryHistories");
                });
#pragma warning restore 612, 618
        }
    }
}
