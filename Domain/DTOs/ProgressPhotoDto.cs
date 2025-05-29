using System;


namespace Domain.DTOs
{
    public class ProgressPhotoDto
    {
        public int Id { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
    }
}
