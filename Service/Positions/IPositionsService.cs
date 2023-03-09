using EmployeesApp.Service.Positions.Models;

namespace EmployeesApp.Service.Positions;

public interface IPositionsService
{
        Task<GetPositionsResponse> GetPositions();

        Task<SavePositionResponse> SavePosition(SavePositionRequest position);

        Task<DeletePositionResponse> DeletePosition(int positionId);
}