using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TasksForThisWeek.Models;

namespace TasksForThisWeek.Controllers
{
	public class PrintTaskController : Controller
	{
		private readonly ILogger<PrintTaskController> _logger;

		public PrintTaskController(ILogger<PrintTaskController> logger)
		{
			_logger = logger;
		}

		public IActionResult PrintTasks()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
