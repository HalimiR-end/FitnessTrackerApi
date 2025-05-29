using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GoalController : ControllerBase
{
    private readonly AppDbContext _context;

    public GoalController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _context.Goals.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var goal = await _context.Goals.FindAsync(id);
        if (goal == null) return NotFound();
        return Ok(goal);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Goal goal)
    {
        _context.Goals.Add(goal);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = goal.Id }, goal);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Goal goal)
    {
        if (id != goal.Id) return BadRequest();
        _context.Goals.Update(goal);
        await _context.SaveChangesAsync();
        return Ok(goal);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var goal = await _context.Goals.FindAsync(id);
        if (goal == null) return NotFound();
        _context.Goals.Remove(goal);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
