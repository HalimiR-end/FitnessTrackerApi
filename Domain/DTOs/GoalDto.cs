using System;

namespace Domain.DTOs
{
    public class GoalDto
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public DateTime TargetDate { get; set; }
        public int UserId { get; set; }
    }
}
