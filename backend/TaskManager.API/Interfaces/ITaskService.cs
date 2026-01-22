using TaskManager.API.Models;
using TaskManager.API.DTOs;

namespace TaskManager.API.Interfaces
{
    public interface ITaskService
    {
        List<TaskItem> GetAll();
        TaskItem? GetById(int id);
        TaskItem Create(CreateTaskDto dto);
        TaskItem? Update(int id, UpdateTaskDto dto);
        bool Delete(int id);
    }
}
