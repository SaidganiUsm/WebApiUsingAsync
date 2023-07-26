using Microsoft.EntityFrameworkCore;
using WebApiUsingAsync.Data;
using WebApiUsingAsync.Interfaces;
using WebApiUsingAsync.Models;

namespace WebApiUsingAsync.Repository
{
    public class ToDoRepository : IToDoRepo
    {
        private readonly AppDbContext _dbContext;

        public ToDoRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ToDo>> GetToDosAsync()
        {
            return await _dbContext.ToDos.ToListAsync();
        }

        public async Task<ToDo> GetToDoAsync(int id)
        {
            return await _dbContext.ToDos.FindAsync(id);
        }

        public async Task AddToDoAsync(ToDo item)
        {
            _dbContext.ToDos.Add(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateToDoAsync(ToDo item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteToDoAsync(int id)
        {
            var item = await _dbContext.ToDos.FindAsync(id);
            if (item != null)
            {
                _dbContext.ToDos.Remove(item);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
