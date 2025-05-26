using System.Collections.Generic;

namespace ZaicevAntonKt_41_22.Models;

public class Teacher
{
    public int Id { get; set; } // Первичный ключ

    public string Name { get; set; } = null!; // Имя преподавателя

    // Связь "многие-к-одному" с кафедрой
    public int DepartmentId { get; set; }
    public Department Department { get; set; } = null!;

    // Связь "многие-к-одному" с учёной степенью
    public int AcademicDegreeId { get; set; }
    public AcademicDegree AcademicDegree { get; set; } = null!;

    // Связь "многие-к-одному" с должностью
    public int PositionId { get; set; }
    public Position Position { get; set; } = null!;

    // Связь "один-ко-многим" с нагрузкой
    public ICollection<Workload> Workloads { get; set; } = new List<Workload>();
}