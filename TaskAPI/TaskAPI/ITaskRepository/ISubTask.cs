using TaskAPI.Models;

namespace TaskAPI.ITaskRepository
{
    public interface ISubTask
    {
        SubTask AddSubTask(SubTask subTask);
        IEnumerable<SubTask> GetSubTasksForTask(int taskId);
    }
}
