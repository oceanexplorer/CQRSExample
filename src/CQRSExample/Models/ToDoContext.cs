using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace CQRSExample.Models
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
            if (!TodoItems.Any())
            {
                Add(new TodoItem("Buy a new guitar", false));
                Add(new TodoItem("Buy a present for Mike's birthday", false));
                Add(new TodoItem("Ring Grandma", true));
            }

            SaveChanges();
        }

        public DbSet<TodoItem> TodoItems { get; set; }

    }
}
