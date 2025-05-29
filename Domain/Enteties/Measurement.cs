using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Domain.Entities;

public class Measurement
{
    public int Id { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public double Weight { get; set; }
    public double Waist { get; set; }
    public double Chest { get; set; }
    public double Biceps { get; set; }

    public int UserId { get; set; }
    public User User { get; set; } = default!;
}