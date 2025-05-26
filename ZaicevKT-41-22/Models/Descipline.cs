using System.Collections.Generic;

namespace ZaicevAntonKt_41_22.Models;

public class Discipline
{
    public int Id { get; set; } // Первичный ключ

    public string Name { get; set; } = null!; // Название дисциплины

    // Связь "один-ко-многим" с нагрузкой
    public ICollection<Workload> Workloads { get; set; } = new List<Workload>();
}