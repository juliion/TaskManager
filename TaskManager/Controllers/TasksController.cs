using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManager.Context;

namespace TaskManager.Controllers
{
	public class TasksController : Controller
	{
        private readonly ApplicationContext _context;
        public TasksController(ApplicationContext context) 
        {
            _context = context;
        }
        public IActionResult Index()
		{
            var tasks = _context.Tasks.Include(t => t.User);
            return View(tasks);
		}
        public IActionResult AddTask()
        {
            return View();
        }
    }
}
