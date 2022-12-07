using TodoProject.Application.Abstractions;
using TodoProject.Domain.Entities;

namespace TodoProject.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }


    public async Task<List<User>> GetUsers()
    {
        return await _userRepository.GetUsersAsync();
    }

    public async Task<User?> GetUser(int id)
    {
        return await _userRepository.GetUserByIdAsync(id);
    }

    public async Task<User> CreateUser(User user)
    {
        return await _userRepository.CreateUserAsync(user);
    }

    public async Task<User?> UpdateUser(int id, User user)
    {
        return await _userRepository.UpdateUserAsync(id, user);
    }

    public async Task<User?> RemoveUser(int id)
    {
        return await _userRepository.RemoveUserAsync(id);
    }
}