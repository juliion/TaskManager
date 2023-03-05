using Microsoft.AspNetCore.Mvc;

namespace TaskManager.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
