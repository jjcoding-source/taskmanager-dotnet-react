using TaskManager.API.Data;
using TaskManager.API.Interfaces;
using TaskManager.API.Models;

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

        public TaskItem Create(TaskItem task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
            return task;
        }

        public TaskItem? Update(int id, TaskItem task)
        {
            var existingTask = _context.Tasks.Find(id);
            if (existingTask == null)
                return null;

            existingTask.Title = task.Title;
            existingTask.Description = task.Description;
            existingTask.IsCompleted = task.IsCompleted;

            _context.SaveChanges();
            return existingTask;
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
