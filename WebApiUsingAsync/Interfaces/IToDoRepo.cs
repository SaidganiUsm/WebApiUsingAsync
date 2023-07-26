using WebApiUsingAsync.Models;

namespace WebApiUsingAsync.Interfaces
{
    public interface IToDoRepo
    {
        Task<List<ToDo>> GetToDosAsync();
        Task<ToDo> GetToDoAsync(int id);
        Task AddToDoAsync(ToDo item);
        Task UpdateToDoAsync(ToDo item);
        Task DeleteToDoAsync(int id);
    }
}
