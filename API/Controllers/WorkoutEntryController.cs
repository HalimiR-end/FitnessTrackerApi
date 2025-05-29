using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Domain.DTOs;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkoutEntryController : ControllerBase
    {
        private readonly IWorkoutEntryService _workoutEntryService;

        public WorkoutEntryController(IWorkoutEntryService workoutEntryService)
        {
            _workoutEntryService = workoutEntryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _workoutEntryService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var entry = await _workoutEntryService.GetByIdAsync(id);
            if (entry == null)
                return NotFound();

            return Ok(entry);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateWorkoutEntryDto dto)
        {
            var created = await _workoutEntryService.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] WorkoutEntryDto dto)
        {
            var updated = await _workoutEntryService.UpdateAsync(id, dto);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _workoutEntryService.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
