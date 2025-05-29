using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.DTOs;

namespace Application.Services
{
    public class ExerciseService : IExerciseService
    {
        public Task<IEnumerable<ExerciseDto>> GetAllAsync() =>
            Task.FromResult<IEnumerable<ExerciseDto>>(new List<ExerciseDto>());

        public Task<ExerciseDto?> GetByIdAsync(int id) =>
            Task.FromResult<ExerciseDto?>(null);

        public Task<ExerciseDto> CreateAsync(ExerciseDto dto) =>
            Task.FromResult(dto);

        public Task<ExerciseDto> UpdateAsync(int id, ExerciseDto dto) =>
            Task.FromResult(dto);

        public Task<bool> DeleteAsync(int id) =>
            Task.FromResult(true);
    }
}
