using Microsoft.EntityFrameworkCore;
using TodoProject.Infrastructure.Context;
using TodoProject.Domain.Entities;
using TodoProject.Application.Abstractions;

namespace TodoProject.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<User> CreateUserAsync(User todo)
        {
            _context.Users.Add(todo);
            await _context.SaveChangesAsync();
            return todo;
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.UserId == id);
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}