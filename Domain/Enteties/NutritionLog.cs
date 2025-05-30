using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Entities;

public class NutritionLog
{
    public int Id { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public string MealType { get; set; } = default!;
    public int Calories { get; set; }
    public int Protein { get; set; }
    public int Carbs { get; set; }
    public int Fat { get; set; }

    public int UserId { get; set; }
    public User User { get; set; } = default!;
}
