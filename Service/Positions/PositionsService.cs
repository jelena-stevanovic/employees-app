using EmployeesApp.Data;
using EmployeesApp.Data.Models;
using EmployeesApp.Service.Positions.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeesApp.Service.Positions;

public class PositionsService : IPositionsService
{
    private readonly ApplicationDbContext dbContext;

    public PositionsService(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<GetPositionsResponse> GetPositions()
    {
        var positions = await dbContext.Positions
            .Include(i => i.SalaryHistories)
            .ToListAsync();

        return new GetPositionsResponse { Success = true, Positions = positions };
    }

    public async Task<SavePositionResponse> SavePosition(SavePositionRequest position)
    {
        var entry = position.Id == 0
            ? new Position()
            : dbContext.Positions.FirstOrDefault(i => i.Id == position.Id);

        entry.Id = position.Id;
        entry.Title = position.Title;
        entry.IsManager = position.IsManager;

        entry = position.Id == 0 ? (await dbContext.Positions.AddAsync(entry)).Entity : entry;

        var saveResponse = await dbContext.SaveChangesAsync();

        return saveResponse >= 0
            ? new SavePositionResponse { Success = true, Position = entry }
            : new SavePositionResponse { Success = false, Error = "Unable to save position", ErrorCode = "T05" };
    }

    public async Task<DeletePositionResponse> DeletePosition(int epositionId)
    {
        var eposition = await dbContext.Positions.FindAsync(epositionId);

        if (eposition == null)
        {
            return new DeletePositionResponse { Success = false, Error = "Position not found", ErrorCode = "I01" };
        }

        dbContext.Positions.Remove(eposition);

        var saveResponse = await dbContext.SaveChangesAsync();

        return saveResponse >= 0
            ? new DeletePositionResponse { Success = true, PositionId = eposition.Id }
            : new DeletePositionResponse { Success = false, Error = "Unable to delete position", ErrorCode = "I03" };
    }
}