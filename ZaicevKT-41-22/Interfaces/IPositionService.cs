using ZaicevAntonKt_41_22.DTO;
using ZaicevAntonKt_41_22.Filters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ZaicevAntonKt_41_22.Interfaces
{
    public interface IPositionService
    {
        Task<IEnumerable<PositionDto>> GetPositionsAsync(PositionFilter filter);
        Task<PositionDto> GetPositionByIdAsync(int id);
        Task<int> CreatePositionAsync(PositionDto positionDto);
        Task UpdatePositionAsync(int id, PositionDto positionDto);
        Task DeletePositionAsync(int id);
    }
}