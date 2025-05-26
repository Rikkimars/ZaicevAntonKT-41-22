using System.Collections.Generic;

namespace ZaicevAntonKt_41_22.Models;

public class Position
{
    public int Id { get; set; } // Первичный ключ

    public string Name { get; set; } = null!; // Название должности

    // Связь "один-ко-многим" с преподавателями
    public ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}