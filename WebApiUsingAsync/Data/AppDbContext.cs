using Microsoft.EntityFrameworkCore;
using WebApiUsingAsync.Models;

namespace WebApiUsingAsync.Data
{
    public class AppDbContext : AppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ToDo> TodoItems { get; set; }
    }
}
