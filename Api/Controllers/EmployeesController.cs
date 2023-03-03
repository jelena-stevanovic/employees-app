using EmployeesApp.Service;
using EmployeesApp.Service.Employees;
using EmployeesApp.Service.Employees.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesApp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeesController : ControllerBase
{
    private readonly IEmployeesService employeesService;

    public EmployeesController(IEmployeesService employeesService)
    {
        this.employeesService = employeesService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var getEmployeesResponse = await employeesService.GetEmployees();

        if (!getEmployeesResponse.Success)
        {
            return UnprocessableEntity(getEmployeesResponse);
        }

        return Ok(getEmployeesResponse);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var getEmpolyeesResponse = await employeesService.GetEmployees();

        if (!getEmpolyeesResponse.Success)
        {
            return UnprocessableEntity(getEmpolyeesResponse);
        }

        var empolyee = getEmpolyeesResponse.Employees.First(i => i.Id == id);

        return Ok(empolyee);
    }

    [HttpPost]
    public async Task<IActionResult> Post(SaveEmployeeRequest saveEmployeeRequest)
    {
        var saveEmployeeResponse = await employeesService.SaveEmployee(saveEmployeeRequest);

        if (!saveEmployeeResponse.Success)
        {
            return UnprocessableEntity(saveEmployeeResponse);
        }

        return Ok(saveEmployeeResponse);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        if (id == 0)
        {
            return BadRequest(
                new DeleteEmployeeResponse {Success = false, ErrorCode = "D01", Error = "Invalid Position id"});
        }

        var deleteEmployeeResponse = await employeesService.DeleteEmployee(id);
        if (!deleteEmployeeResponse.Success)
        {
            return UnprocessableEntity(deleteEmployeeResponse);
        }

        return Ok(deleteEmployeeResponse.EmployeeId);
    }

    [HttpPut]
    public async Task<IActionResult> Put(SaveEmployeeRequest saveEmployeeRequest)
    {
        var saveEmpolyeeResponse = await employeesService.SaveEmployee(saveEmployeeRequest);

        if (!saveEmpolyeeResponse.Success)
        {
            return UnprocessableEntity(saveEmpolyeeResponse);
        }

        return Ok(saveEmpolyeeResponse);
    }

}