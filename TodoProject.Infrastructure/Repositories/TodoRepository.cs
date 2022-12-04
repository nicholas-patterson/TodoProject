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

        public async Task<Todo?> UpdateTodoAsync(int id, Todo todo)
        {
            var todoToUpdate = await _context.Todos.FirstOrDefaultAsync(t => t.TodoId == id);

            if (todoToUpdate == null)
            {
                return null;
            }

            todoToUpdate.Title = todo.Title;
            todoToUpdate.IsComplete = todo.IsComplete;
            await _context.SaveChangesAsync();
            return todoToUpdate;
        }

        public async Task<Todo?> RemoveTodoAsync(int id)
        {
            var todoToDelete = await _context.Todos.FirstOrDefaultAsync(t => t.TodoId == id);

            if (todoToDelete == null)
            {
                return null;
            }

            _context.Todos.Remove(todoToDelete);
            await _context.SaveChangesAsync();
            return todoToDelete;
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