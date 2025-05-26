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
    public class AcademicDegreeService : IAcademicDegreeService
    {
        private readonly PrepodDbContext _context;

        public AcademicDegreeService(PrepodDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AcademicDegreeDto>> GetAcademicDegreesAsync(AcademicDegreeFilter filter)
        {
            var query = _context.AcademicDegrees.AsQueryable();

            if (!string.IsNullOrEmpty(filter.Name))
                query = query.Where(d => d.Name.Contains(filter.Name));

            return await query
                .Select(d => new AcademicDegreeDto
                {
                    Id = d.Id,
                    Name = d.Name
                })
                .ToListAsync();
        }

        public async Task<AcademicDegreeDto> GetAcademicDegreeByIdAsync(int id)
        {
            return await _context.AcademicDegrees
                .Where(d => d.Id == id)
                .Select(d => new AcademicDegreeDto
                {
                    Id = d.Id,
                    Name = d.Name
                })
                .FirstOrDefaultAsync();
        }

        public async Task<int> CreateAcademicDegreeAsync(AcademicDegreeDto academicDegreeDto)
        {
            var degree = new AcademicDegree
            {
                Name = academicDegreeDto.Name
            };

            _context.AcademicDegrees.Add(degree);
            await _context.SaveChangesAsync();

            return degree.Id;
        }

        public async Task UpdateAcademicDegreeAsync(int id, AcademicDegreeDto academicDegreeDto)
        {
            var degree = await _context.AcademicDegrees.FindAsync(id);
            if (degree == null) return;

            degree.Name = academicDegreeDto.Name;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAcademicDegreeAsync(int id)
        {
            var degree = await _context.AcademicDegrees.FindAsync(id);
            if (degree != null)
            {
                _context.AcademicDegrees.Remove(degree);
                await _context.SaveChangesAsync();
            }
        }
    }
}