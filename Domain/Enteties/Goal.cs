using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Domain.Entities;

public class Goal
{
    public int Id { get; set; }
    public string Description { get; set; } = default!;
    public DateTime TargetDate { get; set; }
    public bool IsAchieved { get; set; } = false;

    public int UserId { get; set; }
    public User User { get; set; } = default!;
}
