using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TaskManager.Context;
using TaskManager.Models;
using TaskManager.ViewModels;

namespace TaskManager.Controllers
{
	public class TasksController : Controller
	{
        private readonly ApplicationContext _context;
        public TasksController(ApplicationContext context) 
        {
            _context = context;
        }
        public IActionResult Index(string search)
        {
            var tasks = new List<Models.Task>();
            if (search != null)
            {
                tasks = _context.Tasks
                .Include(t => t.User)
                .Where(task => task.Title.Contains(search)).ToList();
            } 
            else
            {
                tasks = _context.Tasks
                .Include(t => t.User).ToList();
            }
            
            return View(tasks);
        }
        [HttpPost]
        public IActionResult Search(string search)
        {
            return RedirectToAction("Index", new { search = search });
        }
        public IActionResult AddTask()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddTask(TaskViewModel taskViewModel)
        {
            if (ModelState.IsValid)
            {
                var task = new Models.Task
                {
                    Title = taskViewModel.Title,
                    Description = taskViewModel.Description,
                    EndDate = taskViewModel.EndDate,
                    Hashtag = taskViewModel.Hashtag,
                    Priority = taskViewModel.Priority,
                    IsCompleted = false,
                    UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
                };
                _context.Add(task);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Tasks");
            }
            return View();
        }
        public async Task<IActionResult> Edit(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            
            return View(task);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Models.Task task)
        {
            if (ModelState.IsValid)
            {
                _context.Update(task);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Tasks");
            }
            return View(task);
        }

    }
}
