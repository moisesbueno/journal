using Journal.Api.Controllers;
using Journal.Data;
using Journal.Data.Interfaces;
using Journal.Data.Models;
using Microsoft.EntityFrameworkCore;

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
