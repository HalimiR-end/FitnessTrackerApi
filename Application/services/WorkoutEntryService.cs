using Application.Interfaces;
using Domain.DTOs;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;


namespace Application.Services
{
    public class WorkoutEntryService : IWorkoutEntryService
    {
        private readonly AppDbContext _context;

        public WorkoutEntryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<WorkoutEntryDto>> GetAllAsync()
        {
            return await _context.WorkoutEntries
                .Select(w => new WorkoutEntryDto
                {
                    Id = w.Id,
                    WorkoutId = w.WorkoutId,
                    ExerciseId = w.ExerciseId,
                    Sets = w.Sets,
                    Reps = w.Reps,
                    Weight = w.Weight
                }).ToListAsync();
        }

        public async Task<WorkoutEntryDto> GetByIdAsync(int id)
        {
            var entry = await _context.WorkoutEntries.FindAsync(id);
            if (entry == null) return null;

            return new WorkoutEntryDto
            {
                Id = entry.Id,
                WorkoutId = entry.WorkoutId,
                ExerciseId = entry.ExerciseId,
                Sets = entry.Sets,
                Reps = entry.Reps,
                Weight = entry.Weight
            };
        }

        public async Task<WorkoutEntryDto> CreateAsync(CreateWorkoutEntryDto dto)
        {
            var entry = new Domain.Entities.WorkoutEntry

            {
                WorkoutId = dto.WorkoutId,
                ExerciseId = dto.ExerciseId,
                Sets = dto.Sets,
                Reps = dto.Reps,
                Weight = dto.Weight
            };

            _context.WorkoutEntries.Add(entry);
            await _context.SaveChangesAsync();

            return new WorkoutEntryDto
            {
                Id = entry.Id,
                WorkoutId = entry.WorkoutId,
                ExerciseId = entry.ExerciseId,
                Sets = entry.Sets,
                Reps = entry.Reps,
                Weight = entry.Weight
            };
        }

        public async Task<bool> UpdateAsync(int id, WorkoutEntryDto dto)
        {
            var entry = await _context.WorkoutEntries.FindAsync(id);
            if (entry == null) return false;

            entry.WorkoutId = dto.WorkoutId;
            entry.ExerciseId = dto.ExerciseId;
            entry.Sets = dto.Sets;
            entry.Reps = dto.Reps;
            entry.Weight = dto.Weight;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entry = await _context.WorkoutEntries.FindAsync(id);
            if (entry == null) return false;

            _context.WorkoutEntries.Remove(entry);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
