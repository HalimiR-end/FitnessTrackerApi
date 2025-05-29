using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.DTOs;

namespace Application.Services
{
    public class GoalService : IGoalService
    {
        public Task<IEnumerable<GoalDto>> GetAllAsync()
        {
            // implementim i përkohshëm
            return Task.FromResult<IEnumerable<GoalDto>>(new List<GoalDto>());
        }

        public Task<GoalDto?> GetByIdAsync(int id)
        {
            return Task.FromResult<GoalDto?>(null);
        }

        public Task<GoalDto> CreateAsync(GoalDto dto)
        {
            return Task.FromResult(dto);
        }

        public Task<bool> UpdateAsync(int id, GoalDto dto)
        {
            return Task.FromResult(true);
        }

        public Task<bool> DeleteAsync(int id)
        {
            return Task.FromResult(true);
        }
    }
}
