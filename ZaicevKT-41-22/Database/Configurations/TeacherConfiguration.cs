using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZaicevAntonKt_41_22.Models;

public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.ToTable("Teachers");
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Name).IsRequired().HasMaxLength(100);

        // Связь "многие-к-одному" с кафедрой
        builder.HasOne(t => t.Department)
               .WithMany(d => d.Teachers)
               .HasForeignKey(t => t.DepartmentId)
               .OnDelete(DeleteBehavior.Restrict);

        // Связь "многие-к-одному" с учёной степенью
        builder.HasOne(t => t.AcademicDegree)
               .WithMany(a => a.Teachers)
               .HasForeignKey(t => t.AcademicDegreeId)
               .OnDelete(DeleteBehavior.Restrict);

        // Связь "многие-к-одному" с должностью
        builder.HasOne(t => t.Position)
               .WithMany(p => p.Teachers)
               .HasForeignKey(t => t.PositionId)
               .OnDelete(DeleteBehavior.Restrict);

        // Связь "один-ко-многим" с нагрузкой
        builder.HasMany(t => t.Workloads)
               .WithOne(w => w.Teacher)
               .HasForeignKey(w => w.TeacherId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}