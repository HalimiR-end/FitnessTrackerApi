using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.DTOs;

namespace Application.Services
{
    public class NutritionLogService : INutritionLogService
    {
        public Task<IEnumerable<NutritionLogDto>> GetAllAsync() =>
            Task.FromResult<IEnumerable<NutritionLogDto>>(new List<NutritionLogDto>());

        public Task<NutritionLogDto?> GetByIdAsync(int id) =>
            Task.FromResult<NutritionLogDto?>(null);

        public Task<NutritionLogDto> CreateAsync(NutritionLogDto dto) =>
            Task.FromResult(dto);

        public Task<NutritionLogDto> UpdateAsync(int id, NutritionLogDto dto) =>
            Task.FromResult(dto);

        public Task<bool> DeleteAsync(int id) =>
            Task.FromResult(true);
    }
}
