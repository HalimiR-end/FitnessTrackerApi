using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.DTOs;

namespace Application.Services
{
    public class WorkoutService : IWorkoutService
    {
        public Task<IEnumerable<WorkoutDto>> GetAllAsync() =>
            Task.FromResult<IEnumerable<WorkoutDto>>(new List<WorkoutDto>());

        public Task<WorkoutDto?> GetByIdAsync(int id) =>
            Task.FromResult<WorkoutDto?>(null);

        public Task<WorkoutDto> CreateAsync(WorkoutDto dto) =>
            Task.FromResult(dto);

        public Task<bool> UpdateAsync(int id, WorkoutDto dto)
        {
            return Task.FromResult(true); // ose logjikë reale
        }


        public Task<bool> DeleteAsync(int id) =>
            Task.FromResult(true);
    }
}
