using Microsoft.EntityFrameworkCore;
using TaskAPI.ITaskRepository;
using TaskAPI.Models;

namespace TaskAPI.TaskRepository
{
    public class TaskRepository : ITask
    {
        private readonly DbContext context;

        public TaskRepository(DbContext context)
        {
            this.context = context;
        }

        public Tasks AddTask(Tasks task)
        {
            context.Set<Tasks>().Add(task);
            context.SaveChanges();
            return task;
        }

        public IEnumerable<Tasks> GetAllTasks()
        {
            return context.Set<Tasks>().ToList();
        }

        public Tasks GetTaskById(int id)
        {
            return context.Set<Tasks>().FirstOrDefault(t => t.Id == id);
        }

        public void EditTask(Tasks task)
        {
            context.Set<Tasks>().Update(task);
            context.SaveChanges();
        }

        public void DeleteTask(int id)
        {
            var task = context.Set<Tasks>().FirstOrDefault(t => t.Id == id);
            if (task != null && !HasSubTasks(task))
            {
                context.Set<Tasks>().Remove(task);
                context.SaveChanges();
            }
        }

        private bool HasSubTasks(Tasks task)
        {
            return context.Set<SubTask>().Any(st => st.TaskId == task.Id);
        }
    }

}
