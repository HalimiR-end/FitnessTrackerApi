using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Domain.DTOs;

public interface IExerciseService
{
    Task<IEnumerable<ExerciseDto>> GetAllAsync();
    Task<ExerciseDto> GetByIdAsync(int id);
    Task<ExerciseDto> CreateAsync(ExerciseDto exercise);
    Task<ExerciseDto> UpdateAsync(int id, ExerciseDto exercise);
    Task<bool> DeleteAsync(int id);
}