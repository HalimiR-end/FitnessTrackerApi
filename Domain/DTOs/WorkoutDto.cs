using System;

namespace Domain.DTOs
{
    public class WorkoutDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public string? Description { get; set; }

    }
}
