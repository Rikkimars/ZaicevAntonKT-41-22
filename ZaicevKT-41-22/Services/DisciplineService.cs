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
    public class DisciplineService : IDisciplineService
    {
        private readonly PrepodDbContext _context;

        public DisciplineService(PrepodDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DisciplineDto>> GetDisciplinesAsync(DisciplineFilter filter)
        {
            var query = _context.Disciplines.AsQueryable();

            if (!string.IsNullOrEmpty(filter.Name))
                query = query.Where(d => d.Name.Contains(filter.Name));

            if (filter.TeacherId.HasValue)
                query = query.Where(d => d.Workloads.Any(w => w.TeacherId == filter.TeacherId.Value));

            if (filter.HoursMin.HasValue)
                query = query.Where(d => d.Workloads.Sum(w => w.Hours) >= filter.HoursMin.Value);

            if (filter.HoursMax.HasValue)
                query = query.Where(d => d.Workloads.Sum(w => w.Hours) <= filter.HoursMax.Value);

            return await query
                .Select(d => new DisciplineDto
                {
                    Id = d.Id,
                    Name = d.Name
                })
                .ToListAsync();
        }

        public async Task<DisciplineDto> GetDisciplineByIdAsync(int id)
        {
            return await _context.Disciplines
                .Where(d => d.Id == id)
                .Select(d => new DisciplineDto
                {
                    Id = d.Id,
                    Name = d.Name
                })
                .FirstOrDefaultAsync();
        }

        public async Task<int> CreateDisciplineAsync(DisciplineDto disciplineDto)
        {
            var discipline = new Discipline
            {
                Name = disciplineDto.Name
            };

            _context.Disciplines.Add(discipline);
            await _context.SaveChangesAsync();

            return discipline.Id;
        }

        public async Task UpdateDisciplineAsync(int id, DisciplineDto disciplineDto)
        {
            var discipline = await _context.Disciplines.FindAsync(id);
            if (discipline == null) return;

            discipline.Name = disciplineDto.Name;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteDisciplineAsync(int id)
        {
            var discipline = await _context.Disciplines.FindAsync(id);
            if (discipline != null)
            {
                _context.Disciplines.Remove(discipline);
                await _context.SaveChangesAsync();
            }
        }
    }
}