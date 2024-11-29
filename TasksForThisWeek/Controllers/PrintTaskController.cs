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

        // Ін'єкція контексту бази даних для доступу до задач
        public PrintTaskController(TasksForThisWeekContext context, ILogger<PrintTaskController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // Дія для виведення всіх задач по дням
        public async Task<IActionResult> PrintTasks()
        {
            var tasks = await _context.TasksThisWeek
                .GroupBy(t => t.Day)
                .ToListAsync(); // Групуємо задачі по дням

            return View(tasks);
        }

        // Дія для видалення задачі
        [HttpPost]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _context.TasksThisWeek.FindAsync(id);
            if (task != null)
            {
                _context.TasksThisWeek.Remove(task);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(PrintTasks)); // Після видалення перенаправляємо назад на сторінку
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}