using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZaicevAntonKt_41_22.Models;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable("Departments");
        builder.HasKey(d => d.Id);

        builder.Property(d => d.Name).IsRequired().HasMaxLength(100);

        // Связь "один-к-одному" с заведующим кафедрой
        builder.HasOne(d => d.HeadOfDepartment)
               .WithOne()
               .HasForeignKey<Department>(d => d.HeadOfDepartmentId)
               .OnDelete(DeleteBehavior.Restrict);

        // Связь "один-ко-многим" с преподавателями
        builder.HasMany(d => d.Teachers)
               .WithOne(t => t.Department)
               .HasForeignKey(t => t.DepartmentId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}