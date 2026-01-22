using TaskManager.API.Data;
using TaskManager.API.Interfaces;
using TaskManager.API.Models;
using TaskManager.API.DTOs;

namespace TaskManager.API.Services
{
    public class TaskService : ITaskService
    {
        private readonly AppDbContext _context;

        public TaskService(AppDbContext context)
        {
            _context = context;
        }

        public List<TaskItem> GetAll()
        {
            return _context.Tasks.ToList();
        }

        public TaskItem? GetById(int id)
        {
            return _context.Tasks.Find(id);
        }

        public TaskItem Create(CreateTaskDto dto)
        {
            var task = new TaskItem
            {
                Title = dto.Title,
                Description = dto.Description,
                IsCompleted = false
            };

            _context.Tasks.Add(task);
            _context.SaveChanges();
            return task;
        }

        public TaskItem? Update(int id, UpdateTaskDto dto)
        {
            var task = _context.Tasks.Find(id);
            if (task == null)
                return null;

            task.Title = dto.Title;
            task.Description = dto.Description;
            task.IsCompleted = dto.IsCompleted;

            _context.SaveChanges();
            return task;
        }

        public bool Delete(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task == null)
                return false;

            _context.Tasks.Remove(task);
            _context.SaveChanges();
            return true;
        }
    }
}
