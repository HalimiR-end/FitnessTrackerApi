using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Domain.DTOs;

using Domain.DTOs;

public interface IGoalService
{
    Task<IEnumerable<GoalDto>> GetAllAsync();
    Task<GoalDto?> GetByIdAsync(int id);
    Task<GoalDto> CreateAsync(GoalDto dto);
    Task<bool> UpdateAsync(int id, GoalDto dto);
    Task<bool> DeleteAsync(int id);
}
