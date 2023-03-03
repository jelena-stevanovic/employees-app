using EmployeesApp.Service.Positions;
using EmployeesApp.Service.Positions.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeesApp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PositionsController : ControllerBase
{
    private readonly IPositionsService positionsService;

    public PositionsController(IPositionsService positionsService)
    {
        this.positionsService = positionsService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var getPositionsResponse = await positionsService.GetPositions();

        if (!getPositionsResponse.Success)
        {
            return UnprocessableEntity(getPositionsResponse);
        }

        return Ok(getPositionsResponse);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var getEmpolyeesResponse = await positionsService.GetPositions();

        if (!getEmpolyeesResponse.Success)
        {
            return UnprocessableEntity(getEmpolyeesResponse);
        }

        var empolyee = getEmpolyeesResponse.Positions.First(i => i.Id == id);

        return Ok(empolyee);
    }

    [HttpPost]
    public async Task<IActionResult> Post(SavePositionRequest savePositionRequest)
    {
        var savePositionResponse = await positionsService.SavePosition(savePositionRequest);

        if (!savePositionResponse.Success)
        {
            return UnprocessableEntity(savePositionResponse);
        }

        return Ok(savePositionResponse);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        if (id == 0)
        {
            return BadRequest(
                new DeletePositionResponse {Success = false, ErrorCode = "D01", Error = "Invalid Position id"});
        }

        var deletePositionResponse = await positionsService.DeletePosition(id);
        if (!deletePositionResponse.Success)
        {
            return UnprocessableEntity(deletePositionResponse);
        }

        return Ok(deletePositionResponse.PositionId);
    }

    [HttpPut]
    public async Task<IActionResult> Put(SavePositionRequest savePositionRequest)
    {
        var saveEmpolyeeResponse = await positionsService.SavePosition(savePositionRequest);

        if (!saveEmpolyeeResponse.Success)
        {
            return UnprocessableEntity(saveEmpolyeeResponse);
        }

        return Ok(saveEmpolyeeResponse);
    }

}