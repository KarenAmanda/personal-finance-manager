
using UserService.Domain.Entities;

namespace UserService.Infrastructure.Data.Repositories.Interfaces;
public interface IUserRepository
{
    Task<User?> GetByUserIdAsync(Guid id);
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task AddUserAsync(User user);
    void UpdateUser(User user);
    void DeleteUser(User user);
}
