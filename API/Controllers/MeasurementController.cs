using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MeasurementController : ControllerBase
{
	private readonly AppDbContext _context;

	public MeasurementController(AppDbContext context)
	{
		_context = context;
	}

	[HttpGet]
	public async Task<IActionResult> GetAll()
	{
		return Ok(await _context.Measurements.ToListAsync());
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> Get(int id)
	{
		var measurement = await _context.Measurements.FindAsync(id);
		if (measurement == null) return NotFound();
		return Ok(measurement);
	}

	[HttpPost]
	public async Task<IActionResult> Create(Measurement measurement)
	{
		_context.Measurements.Add(measurement);
		await _context.SaveChangesAsync();
		return CreatedAtAction(nameof(Get), new { id = measurement.Id }, measurement);
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> Update(int id, Measurement measurement)
	{
		if (id != measurement.Id) return BadRequest();
		_context.Measurements.Update(measurement);
		await _context.SaveChangesAsync();
		return Ok(measurement);
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> Delete(int id)
	{
		var measurement = await _context.Measurements.FindAsync(id);
		if (measurement == null) return NotFound();
		_context.Measurements.Remove(measurement);
		await _context.SaveChangesAsync();
		return NoContent();
	}
}
