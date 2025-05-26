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
    public class WorkloadService : IWorkloadService
    {
        private readonly PrepodDbContext _context;

        public WorkloadService(PrepodDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<WorkloadDto>> GetWorkloadsAsync(WorkloadFilter filter)
        {
            var query = _context.Workloads.AsQueryable();

            if (filter.TeacherId.HasValue)
                query = query.Where(w => w.TeacherId == filter.TeacherId.Value);

            if (filter.DepartmentId.HasValue)
                query = query.Where(w => w.Teacher.DepartmentId == filter.DepartmentId.Value);

            if (filter.DisciplineId.HasValue)
                query = query.Where(w => w.DisciplineId == filter.DisciplineId.Value);

            return await query
                .Select(w => new WorkloadDto
                {
                    Id = w.Id,
                    Hours = w.Hours,
                    TeacherId = w.TeacherId,
                    DisciplineId = w.DisciplineId
                })
                .ToListAsync();
        }

        public async Task<WorkloadDto> GetWorkloadByIdAsync(int id)
        {
            return await _context.Workloads
                .Where(w => w.Id == id)
                .Select(w => new WorkloadDto
                {
                    Id = w.Id,
                    Hours = w.Hours,
                    TeacherId = w.TeacherId,
                    DisciplineId = w.DisciplineId
                })
                .FirstOrDefaultAsync();
        }

        public async Task<int> CreateWorkloadAsync(WorkloadDto workloadDto)
        {
            var workload = new Workload
            {
                Hours = workloadDto.Hours,
                TeacherId = workloadDto.TeacherId,
                DisciplineId = workloadDto.DisciplineId
            };

            _context.Workloads.Add(workload);
            await _context.SaveChangesAsync();

            return workload.Id;
        }

        public async Task UpdateWorkloadAsync(int id, WorkloadDto workloadDto)
        {
            var workload = await _context.Workloads.FindAsync(id);
            if (workload == null) return;

            workload.Hours = workloadDto.Hours;
            workload.TeacherId = workloadDto.TeacherId;
            workload.DisciplineId = workloadDto.DisciplineId;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteWorkloadAsync(int id)
        {
            var workload = await _context.Workloads.FindAsync(id);
            if (workload != null)
            {
                _context.Workloads.Remove(workload);
                await _context.SaveChangesAsync();
            }
        }
    }
}