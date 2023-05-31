using Microsoft.EntityFrameworkCore;
using TaskAPI.ITaskRepository;
using TaskAPI.Models;

namespace TaskAPI.TaskRepository
{
    public class SubTaskRepository : ISubTask
    {
        private readonly DbContext context;

        public SubTaskRepository(DbContext context)
        {
            this.context = context;
        }

        public SubTask AddSubTask(SubTask subTask)
        {
            context.Set<SubTask>().Add(subTask);
            context.SaveChanges();
            return subTask;
        }

        public IEnumerable<SubTask> GetSubTasksForTask(int taskId)
        {
            return context.Set<SubTask>().Where(st => st.TaskId == taskId).ToList();
        }
    }
}
