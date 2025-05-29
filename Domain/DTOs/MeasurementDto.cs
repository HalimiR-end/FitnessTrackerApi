using System;

namespace Domain.DTOs
{
    public class MeasurementDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Weight { get; set; }
        public double Waist { get; set; }
        public double Chest { get; set; }
        public double Biceps { get; set; }
        public int UserId { get; set; }
    }
}
