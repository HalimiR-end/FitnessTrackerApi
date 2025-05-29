using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NutritionLogController : ControllerBase
{
    private readonly AppDbContext _context;

    public NutritionLogController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _context.NutritionLogs.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var log = await _context.NutritionLogs.FindAsync(id);
        if (log == null) return NotFound();
        return Ok(log);
    }

    [HttpPost]
    public async Task<IActionResult> Create(NutritionLog log)
    {
        _context.NutritionLogs.Add(log);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = log.Id }, log);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, NutritionLog log)
    {
        if (id != log.Id) return BadRequest();
        _context.NutritionLogs.Update(log);
        await _context.SaveChangesAsync();
        return Ok(log);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var log = await _context.NutritionLogs.FindAsync(id);
        if (log == null) return NotFound();
        _context.NutritionLogs.Remove(log);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
