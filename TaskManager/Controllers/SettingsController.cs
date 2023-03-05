using Microsoft.AspNetCore.Mvc;

namespace TaskManager.Controllers
{
    public class SettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
