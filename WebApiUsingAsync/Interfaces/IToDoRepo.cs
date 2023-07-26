using WebApiUsingAsync.Models;

namespace WebApiUsingAsync.Interfaces
{
    public interface IToDoRepo
    {
        Task<List<ToDo>> GetTodoItemsAsync();
        Task<ToDo> GetTodoItemAsync(int id);
        Task AddTodoItemAsync(ToDo item);
        Task UpdateTodoItemAsync(ToDo item);
        Task DeleteTodoItemAsync(int id);
    }
}
