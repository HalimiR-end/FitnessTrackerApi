using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string PasswordHash { get; set; } = default!;
    public string Role { get; set; } = "User";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<Workout> Workouts { get; set; } = new List<Workout>();
    public ICollection<NutritionLog> NutritionLogs { get; set; } = new List<NutritionLog>();
    public ICollection<Goal> Goals { get; set; } = new List<Goal>();
    public ICollection<Measurement> Measurements { get; set; } = new List<Measurement>();
    public ICollection<ProgressPhoto> ProgressPhotos { get; set; } = new List<ProgressPhoto>();
}