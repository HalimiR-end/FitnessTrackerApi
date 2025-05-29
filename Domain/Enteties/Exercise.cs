using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Entities;

public class Exercise
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string MuscleGroup { get; set; } = default!;
    public string Description { get; set; } = default!;

    public ICollection<WorkoutEntry> WorkoutEntries { get; set; } = new List<WorkoutEntry>();
}
