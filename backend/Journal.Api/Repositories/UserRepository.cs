using Journal.Data.Interfaces;
using Journal.Data.Models;
using Journal.Data;
using Microsoft.EntityFrameworkCore;
using Journal.Api.Service;

namespace Journal.Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly JournalContext _journalContext;
        private readonly IUnitOfWork _unitOfWork;

        public UserRepository(JournalContext journalContext, IUnitOfWork unitOfWork)
        {
            _journalContext = journalContext;
            _unitOfWork = unitOfWork;
        }
        public async Task AddAsync(User user)
        {
            await _journalContext.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _journalContext.Users
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync(c => c.Email == email);
        }

        public bool Exists(string email)
        {
            return _journalContext.Users.Any(u => u.Email == email);
        }

        public async Task UpdatePassWordHashAsync(string email, string passWord)
        {
            var user = await _journalContext.Users
                                            .FirstAsync(c => c.Email == email);

            user.Password = PasswordHasher.HashPassword(passWord);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
