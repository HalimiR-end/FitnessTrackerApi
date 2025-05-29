using Domain.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IWorkoutEntryService
    {
        Task<List<WorkoutEntryDto>> GetAllAsync();
        Task<WorkoutEntryDto> GetByIdAsync(int id);
        Task<WorkoutEntryDto> CreateAsync(CreateWorkoutEntryDto dto);
        Task<bool> UpdateAsync(int id, WorkoutEntryDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
