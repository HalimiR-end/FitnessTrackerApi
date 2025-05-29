using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Domain.Entities;

public class Workout
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public DateTime Date { get; set; } = DateTime.UtcNow;

    public int UserId { get; set; }
    public User User { get; set; } = default!;
    public string? Description { get; set; }
    public ICollection<WorkoutEntry> WorkoutEntries { get; set; } = new List<WorkoutEntry>();
}
