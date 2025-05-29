using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Domain.Entities;

public class WorkoutEntry
{
    public int Id { get; set; }
    public int WorkoutId { get; set; }
    public Workout Workout { get; set; } = default!;

    public int ExerciseId { get; set; }
    public Exercise Exercise { get; set; } = default!;

    public int Sets { get; set; }
    public int Reps { get; set; }
    public double Weight { get; set; }
}