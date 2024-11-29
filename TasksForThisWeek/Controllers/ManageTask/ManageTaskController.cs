using Microsoft.AspNetCore.Mvc;
using TasksForThisWeek.Models.Data;
using TasksForThisWeek.Models;

namespace TasksForThisWeek.Controllers.ManageTask
{
   
    public class ManageTaskController : Controller
    {
        public IActionResult AddTasks()
        {
            return View();
        }
    }
}
