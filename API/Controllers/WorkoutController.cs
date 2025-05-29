using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WorkoutController : ControllerBase
{
    private readonly AppDbContext _context;

    public WorkoutController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var workouts = await _context.Workouts.Include(w => w.WorkoutEntries).ToListAsync();
        return Ok(workouts);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var workout = await _context.Workouts.Include(w => w.WorkoutEntries).FirstOrDefaultAsync(w => w.Id == id);
        if (workout == null) return NotFound();
        return Ok(workout);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Workout workout)
    {
        _context.Workouts.Add(workout);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = workout.Id }, workout);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Workout workout)
    {
        if (id != workout.Id) return BadRequest();
        _context.Workouts.Update(workout);
        await _context.SaveChangesAsync();
        return Ok(workout);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var workout = await _context.Workouts.FindAsync(id);
        if (workout == null) return NotFound();

        _context.Workouts.Remove(workout);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
