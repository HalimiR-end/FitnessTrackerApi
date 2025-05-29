using Application.Services;
using Domain.DTOs;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Xunit;


namespace FitnessTracker.Tests
{
	public class WorkoutServiceTests
	{
		private readonly AppDbContext _context;
		private readonly WorkoutService _service;

		public WorkoutServiceTests()
		{
			var options = new DbContextOptionsBuilder<AppDbContext>()
				.UseInMemoryDatabase(databaseName: "TestDb_Workout")
				.Options;
			_context = new AppDbContext(options);
			_service = new WorkoutService(_context);
		}

		[Fact]
		public async Task CreateWorkout_ShouldAddWorkout()
		{
			var workoutDto = new CreateWorkoutDto
			{
				UserId = 1,
				Date = DateTime.UtcNow,
				Description = "Leg Day"
			};

			var result = await _service.CreateAsync(workoutDto);

			Assert.NotNull(result);
			Assert.Equal(workoutDto.Description, result.Description);
		}

		[Fact]
		public async Task GetWorkoutById_ShouldReturnWorkout()
		{
			var workout = await _context.Workouts.AddAsync(new Domain.Enteties.Workout
			{
				UserId = 2,
				Date = DateTime.UtcNow,
				Description = "Push"
			});
			await _context.SaveChangesAsync();

			var result = await _service.GetByIdAsync(workout.Entity.Id);

			Assert.NotNull(result);
			Assert.Equal("Push", result.Description);
		}

		[Fact]
		public async Task GetAllWorkouts_ShouldReturnList()
		{
			await _context.Workouts.AddAsync(new Domain.Enteties.Workout
			{
				UserId = 3,
				Date = DateTime.UtcNow,
				Description = "Pull"
			});
			await _context.SaveChangesAsync();

			var results = await _service.GetAllAsync();

			Assert.NotEmpty(results);
		}

		[Fact]
		public async Task UpdateWorkout_ShouldModifyFields()
		{
			var workout = await _context.Workouts.AddAsync(new Domain.Enteties.Workout
			{
				UserId = 4,
				Date = DateTime.UtcNow,
				Description = "Arms"
			});
			await _context.SaveChangesAsync();

			var dto = new WorkoutDto
			{
				Id = workout.Entity.Id,
				UserId = 4,
				Date = DateTime.UtcNow,
				Description = "Biceps & Triceps"
			};

			var success = await _service.UpdateAsync(dto.Id, dto);

			Assert.True(success);
			var updated = await _context.Workouts.FindAsync(dto.Id);
			Assert.Equal("Biceps & Triceps", updated.Description);
		}

		[Fact]
		public async Task DeleteWorkout_ShouldRemoveFromDb()
		{
			var workout = await _context.Workouts.AddAsync(new Domain.Enteties.Workout
			{
				UserId = 5,
				Date = DateTime.UtcNow,
				Description = "Chest"
			});
			await _context.SaveChangesAsync();

			var success = await _service.DeleteAsync(workout.Entity.Id);

			Assert.True(success);
			var deleted = await _context.Workouts.FindAsync(workout.Entity.Id);
			Assert.Null(deleted);
		}
	}
}
