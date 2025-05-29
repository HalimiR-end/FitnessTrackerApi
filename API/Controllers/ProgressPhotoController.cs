using Domain.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProgressPhotoController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProgressPhotoController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _context.ProgressPhotos.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var photo = await _context.ProgressPhotos.FindAsync(id);
        if (photo == null) return NotFound();
        return Ok(photo);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProgressPhoto photo)
    {
        _context.ProgressPhotos.Add(photo);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = photo.Id }, photo);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, ProgressPhoto photo)
    {
        if (id != photo.Id) return BadRequest();
        _context.ProgressPhotos.Update(photo);
        await _context.SaveChangesAsync();
        return Ok(photo);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var photo = await _context.ProgressPhotos.FindAsync(id);
        if (photo == null) return NotFound();
        _context.ProgressPhotos.Remove(photo);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
