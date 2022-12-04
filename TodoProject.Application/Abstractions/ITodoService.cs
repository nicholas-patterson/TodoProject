using TodoProject.Domain.Entities;

namespace TodoProject.Application.Abstractions;

public interface ITodoService
{
    Task<List<Todo>> GetTodos();
    Task<Todo?> GetTodoById(int id);
    Task<Todo> CreateTodo(Todo todo);
    Task<Todo?> UpdateTodo(int id, Todo todo);
    Task<Todo?> RemoveTodo(int id);
}