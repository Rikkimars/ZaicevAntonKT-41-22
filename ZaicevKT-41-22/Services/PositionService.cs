using Microsoft.EntityFrameworkCore;
using ZaicevAntonKt_41_22.Database;
using ZaicevAntonKt_41_22.DTO;
using ZaicevAntonKt_41_22.Filters;
using ZaicevAntonKt_41_22.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZaicevAntonKt_41_22.Models;

namespace ZaicevAntonKt_41_22.Services
{
    public class PositionService : IPositionService
    {
        private readonly PrepodDbContext _context;

        public PositionService(PrepodDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PositionDto>> GetPositionsAsync(PositionFilter filter)
        {
            var query = _context.Positions.AsQueryable();

            if (!string.IsNullOrEmpty(filter.Name))
                query = query.Where(p => p.Name.Contains(filter.Name));

            return await query
                .Select(p => new PositionDto
                {
                    Id = p.Id,
                    Name = p.Name
                })
                .ToListAsync();
        }

        public async Task<PositionDto> GetPositionByIdAsync(int id)
        {
            return await _context.Positions
                .Where(p => p.Id == id)
                .Select(p => new PositionDto
                {
                    Id = p.Id,
                    Name = p.Name
                })
                .FirstOrDefaultAsync();
        }

        public async Task<int> CreatePositionAsync(PositionDto positionDto)
        {
            var position = new Position
            {
                Name = positionDto.Name
            };

            _context.Positions.Add(position);
            await _context.SaveChangesAsync();

            return position.Id;
        }

        public async Task UpdatePositionAsync(int id, PositionDto positionDto)
        {
            var position = await _context.Positions.FindAsync(id);
            if (position == null) return;

            position.Name = positionDto.Name;

            await _context.SaveChangesAsync();
        }

        public async Task DeletePositionAsync(int id)
        {
            var position = await _context.Positions.FindAsync(id);
            if (position != null)
            {
                _context.Positions.Remove(position);
                await _context.SaveChangesAsync();
            }
        }
    }
}