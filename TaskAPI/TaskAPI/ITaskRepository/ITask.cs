using TaskAPI.Models;

namespace TaskAPI.ITaskRepository
{
    public interface ITask
    {
        Tasks AddTask(Tasks task);
        IEnumerable<Tasks> GetAllTasks();
        Tasks GetTaskById(int id);
        void EditTask(Tasks task);
        void DeleteTask(int id);
    }



}
