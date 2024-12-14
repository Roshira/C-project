using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TasksForThisWeek.Models;
using TasksForThisWeek.Models.Data;

namespace TasksForThisWeek.Controllers
{
    public class PrintTaskController : Controller
    {
        private readonly TasksForThisWeekContext _context;
        private readonly ILogger<PrintTaskController> _logger;

        public PrintTaskController(TasksForThisWeekContext context, ILogger<PrintTaskController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> PrintTasks()
        {
            var tasks = await _context.TasksThisWeek
                .GroupBy(t => t.Day)
                .ToListAsync();

            return View(tasks);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _context.TasksThisWeek.FindAsync(id);
            if (task != null)
            {
                _context.TasksThisWeek.Remove(task);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(PrintTasks));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}