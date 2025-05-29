using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExerciseController : ControllerBase
{
    private readonly AppDbContext _context;

    public ExerciseController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _context.Exercises.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var exercise = await _context.Exercises.FindAsync(id);
        if (exercise == null) return NotFound();
        return Ok(exercise);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Exercise exercise)
    {
        _context.Exercises.Add(exercise);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = exercise.Id }, exercise);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Exercise exercise)
    {
        if (id != exercise.Id) return BadRequest();
        _context.Exercises.Update(exercise);
        await _context.SaveChangesAsync();
        return Ok(exercise);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var exercise = await _context.Exercises.FindAsync(id);
        if (exercise == null) return NotFound();
        _context.Exercises.Remove(exercise);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
