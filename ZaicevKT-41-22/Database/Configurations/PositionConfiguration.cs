using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZaicevAntonKt_41_22.Models;

public class PositionConfiguration : IEntityTypeConfiguration<Position>
{
    public void Configure(EntityTypeBuilder<Position> builder)
    {
        builder.ToTable("Positions");
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name).IsRequired().HasMaxLength(100);

        // Связь "один-ко-многим" с преподавателями
        builder.HasMany(p => p.Teachers)
               .WithOne(t => t.Position)
               .HasForeignKey(t => t.PositionId)
               .OnDelete(DeleteBehavior.Restrict);
    }
}