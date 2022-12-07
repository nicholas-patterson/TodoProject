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

        public async Task<User?> UpdateUserAsync(int id, User user)
        {
            var userToUpdate = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);

            if (userToUpdate == null)
            {
                return null;
            }
            
            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;

            await _context.SaveChangesAsync();
            return userToUpdate;
        }

        public async Task<User?> RemoveUserAsync(int id)
        {
            var userToDelete = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);

            if (userToDelete == null)
            {
                return null;
            }

            _context.Users.Remove(userToDelete);
            await _context.SaveChangesAsync();
            return userToDelete;
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