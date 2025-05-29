using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Entities;

public class ProgressPhoto
{
    public int Id { get; set; }
    public DateTime TakenAt { get; set; } = DateTime.UtcNow;
    public string PhotoUrl { get; set; } = default!;

    public int UserId { get; set; }
    public User User { get; set; } = default!;
}
