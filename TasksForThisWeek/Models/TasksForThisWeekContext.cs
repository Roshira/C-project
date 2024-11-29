using Microsoft.EntityFrameworkCore;
using TasksForThisWeek.Models.Data;

namespace TasksForThisWeek.Models
{
    public class TasksForThisWeekContext : DbContext
    {
        public TasksForThisWeekContext(DbContextOptions<TasksForThisWeekContext> options)
        : base(options)
        {
        }

        public DbSet<TasksThisWeek> TasksThisWeek { get; set; }

    }
}
