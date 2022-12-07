using TodoProject.Domain.Entities;


namespace TodoProject.Application.Abstractions
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsersAsync();
        Task<User?> GetUserByIdAsync(int id);
        Task<User> CreateUserAsync(User user);
        Task<User?> UpdateUserAsync(int id, User user);
        Task<User?> RemoveUserAsync(int id);
    }
}