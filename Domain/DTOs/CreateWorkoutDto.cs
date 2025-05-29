using System;
namespace Domain.DTOs
{
    public class CreateWorkoutDto
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int UserId { get; set; }
    }
}
