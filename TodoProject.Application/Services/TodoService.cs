using Microsoft.Extensions.Logging;
using TodoProject.Application.Abstractions;
using TodoProject.Domain.Entities;

namespace TodoProject.Application.Services;

public class TodoService : ITodoService
{
    private readonly ITodoRepository _todoRepository;
    private readonly ILogger<TodoService> _logger;

    public TodoService(ITodoRepository todoRepository, ILogger<TodoService> logger)
    {
        _todoRepository = todoRepository;
        _logger = logger;
    }
    
    public async Task<List<Todo>> GetTodos()
    {
        return await _todoRepository.GetTodosAsync();
    }

    public async Task<Todo?> GetTodoById(int id)
    {
        return await _todoRepository.GetTodoByIdAsync(id);
    }

    public async Task<Todo> CreateTodo(Todo todo)
    {
        return await _todoRepository.CreateTodoAsync(todo);
    }

    public async Task<Todo?> UpdateTodo(int id, Todo todo)
    {
        return await _todoRepository.UpdateTodoAsync(id, todo);
    }

    public async Task<Todo?> RemoveTodo(int id)
    {
        return await _todoRepository.RemoveTodoAsync(id);
    }
}