using Journal.Domain.Entities;

namespace Journal.Api.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(User user);

        bool Exists(string email);

        Task<User> GetUserByEmailAsync(string email);

        Task UpdatePassWordHashAsync(string email, string passWord);
    }
}