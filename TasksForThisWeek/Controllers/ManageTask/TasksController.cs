using Microsoft.AspNetCore.Mvc;
using TasksForThisWeek.Models.Data;
using TasksForThisWeek.Models;

namespace TasksForThisWeek.Controllers.ManageTask
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly TasksForThisWeekContext _context;

        public TasksController(TasksForThisWeekContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> AddTask([FromBody] TasksThisWeek task)
        {
            if (task == null || string.IsNullOrEmpty(task.Name) || string.IsNullOrEmpty(task.Text))
            {
                return BadRequest("Invalid task data.");
            }

            _context.TasksThisWeek.Add(task);
            await _context.SaveChangesAsync();
            return Ok(task);
        }
    }
}
