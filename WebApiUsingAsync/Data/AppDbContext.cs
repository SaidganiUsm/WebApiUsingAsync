using Microsoft.EntityFrameworkCore;
using WebApiUsingAsync.Models;

namespace WebApiUsingAsync.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ToDo> ToDos { get; set; }
    }
}
