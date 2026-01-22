using TaskManager.API.Models;

namespace TaskManager.API.Interfaces
{
    public interface ITaskService
    {
        List<TaskItem> GetAll();
        TaskItem? GetById(int id);
        TaskItem Create(TaskItem task);
        TaskItem? Update(int id, TaskItem task);
        bool Delete(int id);
    }
}
