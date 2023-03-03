using EmployeesApp.Data;
using EmployeesApp.Service;
using EmployeesApp.Service.Employees;
using EmployeesApp.Service.Positions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

const string AllowAllHeadersPolicy = "AllowAllHeadersPolicy";

builder.Services.AddCors(options =>
{
    options.AddPolicy(AllowAllHeadersPolicy,
        builder =>
        {
            builder.WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("ConnStr"),
        x => x.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IEmployeesService, EmployeesService>();
builder.Services.AddTransient<IPositionsService, PositionsService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(AllowAllHeadersPolicy);
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();