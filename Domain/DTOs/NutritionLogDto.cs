using System;



namespace Domain.DTOs
{
    public class NutritionLogDto
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public int Calories { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
    }
}
