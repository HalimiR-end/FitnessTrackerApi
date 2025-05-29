using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Domain.DTOs;

public interface IWorkoutService
{
	Task<IEnumerable<WorkoutDto>> GetAllAsync();
	Task<WorkoutDto?> GetByIdAsync(int id);
	Task<WorkoutDto> CreateAsync(WorkoutDto dto);
	Task<bool> UpdateAsync(int id, WorkoutDto dto);
	Task<bool> DeleteAsync(int id);
}