using user_service_v1.Models;

namespace user_service_v1.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task DeleteUser(string username);
        Task UpdateUser(User user);
        Task<int> InsertUser(User user);
        Task<User> GetUser(string username);
    }
}
