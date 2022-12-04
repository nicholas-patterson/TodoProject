using TodoProject.Domain.Entities;

namespace TodoProject.Application.Abstractions
{
    public interface ITodoRepository
    {
        Task<List<Todo>> GetTodosAsync();
        Task<Todo?> GetTodoByIdAsync(int id);
        Task<Todo> CreateTodoAsync(Todo todo);
        Task<Todo?> UpdateTodoAsync(int id, Todo todo);
        Task<Todo?> RemoveTodoAsync(int id);
    }
}