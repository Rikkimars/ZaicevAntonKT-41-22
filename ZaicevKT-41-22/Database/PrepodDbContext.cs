using Microsoft.EntityFrameworkCore;
using ZaicevAntonKt_41_22.Models;

namespace ZaicevAntonKt_41_22.Database;

public class PrepodDbContext : DbContext
{
    public DbSet<Teacher> Teachers { get; set; } = null!;
    public DbSet<Department> Departments { get; set; } = null!;
    public DbSet<AcademicDegree> AcademicDegrees { get; set; } = null!;
    public DbSet<Position> Positions { get; set; } = null!;
    public DbSet<Discipline> Disciplines { get; set; } = null!;
    public DbSet<Workload> Workloads { get; set; } = null!;

    public PrepodDbContext(DbContextOptions<PrepodDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TeacherConfiguration());
        modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
        modelBuilder.ApplyConfiguration(new AcademicDegreeConfiguration());
        modelBuilder.ApplyConfiguration(new PositionConfiguration());
        modelBuilder.ApplyConfiguration(new DisciplineConfiguration());
        modelBuilder.ApplyConfiguration(new WorkloadConfiguration());

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PrepodDbContext).Assembly);
    }
}