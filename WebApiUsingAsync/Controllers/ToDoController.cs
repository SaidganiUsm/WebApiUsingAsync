using Microsoft.AspNetCore.Mvc;
using WebApiUsingAsync.Interfaces;
using WebApiUsingAsync.Models;

namespace WebApiUsingAsync.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoRepo _repository;

        public ToDoController(IToDoRepo repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<List<ToDo>>> GetToDoItems()
        {
            var ToDoItems = await _repository.GetToDosAsync();
            return Ok(ToDoItems);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ToDo>> GetToDoItem(int id)
        {
            var ToDoItem = await _repository.GetToDoAsync(id);
            if (ToDoItem == null)
                return NotFound();
            return Ok(ToDoItem);
        }

        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(422)]
        public async Task<IActionResult> AddToDoItem(ToDo item)
        {
            await _repository.AddToDoAsync(item);
            return Ok();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateTodoItem(int id, [FromBody] ToDo item)
        {
            if (id != item.Id)
                return BadRequest();

            var existingItem = await _repository.GetToDoAsync(id);
            if (existingItem == null)
                return NotFound();

            // Update only specific properties, not the whole object
            existingItem.Title = item.Title;
            existingItem.IsCompleted = item.IsCompleted;
            existingItem.DueDate = item.DueDate;

            await _repository.UpdateToDoAsync(existingItem);
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteToDo(int id)
        {
            var existingItem = await _repository.GetToDoAsync(id);
            if (existingItem == null)
                return NotFound();

            await _repository.DeleteToDoAsync(id);
            return Ok();
        }
    }
}
