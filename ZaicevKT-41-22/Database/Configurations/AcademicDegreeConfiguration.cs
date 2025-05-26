using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZaicevAntonKt_41_22.Models;

public class AcademicDegreeConfiguration : IEntityTypeConfiguration<AcademicDegree>
{
    public void Configure(EntityTypeBuilder<AcademicDegree> builder)
    {
        builder.ToTable("AcademicDegrees");
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Name).IsRequired().HasMaxLength(100);

        // Связь "один-ко-многим" с преподавателями
        builder.HasMany(a => a.Teachers)
               .WithOne(t => t.AcademicDegree)
               .HasForeignKey(t => t.AcademicDegreeId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}