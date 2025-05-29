using System;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace Domain.DTOs
{
	public class ExerciseDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string? Description { get; set; }
		public string MuscleGroup { get; set; }
	}

	public class CreateExerciseDto
	{
		public string Name { get; set; }
		public string? Description { get; set; }
		public string MuscleGroup { get; set; }
	}
}