using Microsoft.AspNetCore.Mvc;
using TaskManager.API.Interfaces;
using TaskManager.API.DTOs;

namespace TaskManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_taskService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var task = _taskService.GetById(id);
            if (task == null)
                return NotFound();

            return Ok(task);
        }

        [HttpPost]
        public IActionResult Create(CreateTaskDto dto)
        {
            var task = _taskService.Create(dto);
            return Ok(task);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UpdateTaskDto dto)
        {
            var task = _taskService.Update(id, dto);
            if (task == null)
                return NotFound();

            return Ok(task);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = _taskService.Delete(id);
            if (!success)
                return NotFound();

            return Ok(new { message = "Task deleted successfully" });
        }
    }
}
