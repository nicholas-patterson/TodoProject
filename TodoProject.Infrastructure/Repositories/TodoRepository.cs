using Microsoft.EntityFrameworkCore;
using TodoProject.Application.Abstractions;
using TodoProject.Domain.Entities;
using TodoProject.Infrastructure.Context;

namespace TodoProject.Infrastructure.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly DataContext _context;
        public TodoRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Todo> CreateTodoAsync(Todo todo)
        {
            todo.CreatedAt = DateTime.Now;
            _context.Todos.Add(todo);
            await _context.SaveChangesAsync();
            return todo;
        }

        public async Task<Todo?> GetTodoByIdAsync(int id)
        {
            return await _context.Todos.FirstOrDefaultAsync(todo => todo.TodoId == id);
        }

        public async Task<List<Todo>> GetTodosAsync()
        {
            return await _context.Todos.ToListAsync();
        }
    }
}