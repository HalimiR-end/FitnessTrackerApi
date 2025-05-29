using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Domain.DTOs;

public interface INutritionLogService
{
    Task<IEnumerable<NutritionLogDto>> GetAllAsync();
    Task<NutritionLogDto> GetByIdAsync(int id);
    Task<NutritionLogDto> CreateAsync(NutritionLogDto log);
    Task<NutritionLogDto> UpdateAsync(int id, NutritionLogDto log);
    Task<bool> DeleteAsync(int id);
}