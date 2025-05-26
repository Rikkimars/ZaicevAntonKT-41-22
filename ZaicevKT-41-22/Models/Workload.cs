namespace ZaicevAntonKt_41_22.Models;

public class Workload
{
    public int Id { get; set; } // Первичный ключ

    public int Hours { get; set; } // Количество часов

    // Связь "многие-к-одному" с преподавателем
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; } = null!;

    // Связь "многие-к-одному" с дисциплиной
    public int DisciplineId { get; set; }
    public Discipline Discipline { get; set; } = null!;
}