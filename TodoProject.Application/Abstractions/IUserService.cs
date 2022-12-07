using TodoProject.Domain.Entities;

namespace TodoProject.Application.Abstractions;

public interface IUserService
{
    Task<List<User>> GetUsers();
    
    Task<User?> GetUser(int id);
    
    Task<User> CreateUser(User user);
    
    Task<User?> UpdateUser(int id, User user);
    
    Task<User?> RemoveUser(int id);
}