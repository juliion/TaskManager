using Microsoft.AspNetCore.Mvc;

namespace TaskManager.Controllers
{
    public class CalendarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
