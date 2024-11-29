using Microsoft.AspNetCore.Mvc;

namespace TasksForThisWeek.Controllers
{
	public class ManageTaskController : Controller
	{
		public IActionResult GenetalPageManageTask()
		{
			return View();
		}
	}
}
