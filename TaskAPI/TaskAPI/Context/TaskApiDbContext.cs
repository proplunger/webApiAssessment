using Microsoft.EntityFrameworkCore;
using TaskAPI.Models;

namespace TaskAPI.Context
{
    public class TaskApiDbContext : DbContext
    {
        public TaskApiDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Tasks> Tasks { get; set; }

        public DbSet<SubTask> SubTasks { get; set; }
    }
}
