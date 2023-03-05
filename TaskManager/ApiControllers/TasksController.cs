using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskManager.Context;

namespace TaskManager.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public TasksController(ApplicationContext context)
        {
            _context = context;
        }
        [HttpPost("MarkAsComplited")]
        public async Task<IActionResult> MarkAsComplited(int taskId)
        {
            var task = _context.Tasks.Find(taskId);
            task.IsCompleted = true;
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPost("MarkAsNotComplited")]
        public async Task<IActionResult> MarkAsNotComplited(int taskId)
        {
            var task = _context.Tasks.Find(taskId);
            task.IsCompleted = false;
            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("DeleteTask")]
        public async Task<IActionResult> DeleteTask(int taskId)
        {
            var task = _context.Tasks.Find(taskId);
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
